SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLmast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TLmast](
	[TL_id] [int] IDENTITY(1,1) NOT NULL,
	[TL_code] [nchar](4) NULL,
	[TL_no] [nvarchar](15) NULL,
	[Own] [bit] NOT NULL,
	[Bilown] [bit] NOT NULL CONSTRAINT [DF_TLmast_Bilown]  DEFAULT ((1)),
	[owner_id] [int] NULL,
	[driver_id] [int] NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_TLmast] PRIMARY KEY CLUSTERED 
(
	[TL_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalUnldDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 20,2009
-- Description:	Details of a challan unloading
-- =============================================
create PROCEDURE [dbo].[s_GetChalUnldDetails]
	@chal_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT unld_id, chal_rcd, deliv_dt, deliv_wt, deliv_unit, shortage, sht_unit, sht_rate,
		sht_amt, mkt_sht
		FROM ChalUnld
		WHERE chal_id=@chal_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HiBal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HiBal](
	[hb_id] [int] IDENTITY(1,1) NOT NULL,
	[hb_name] [nchar](10) NOT NULL,
	[hb_bal] [decimal](18, 2) NOT NULL CONSTRAINT [DF_HiBal_hb_bal]  DEFAULT ((0.00)),
	[gl_id] [int] NULL CONSTRAINT [DF_HiBal_gl_id]  DEFAULT ((0)),
	[grp_id] [int] NULL,
	[Co_cd] [nchar](1) NULL,
	[usr_id] [int] NULL,
	[utime] [datetime] NOT NULL CONSTRAINT [DF_HiBal_utime]  DEFAULT (getdate()),
 CONSTRAINT [PK_HiBal] PRIMARY KEY CLUSTERED 
(
	[hb_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLLdg]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Aug 26,2011
-- Description:	Gets list of T/L transactions
-- =============================================
create PROCEDURE [dbo].[s_GetTLLdg]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT t.tt_id, t.Trn_Code, m.TL_Code, m.TL_No, m.own, 
	t.Trn_Date, t.Amount, ISNULL(g.csge_code,'''''''') AS csge_code, 
	ISNULL(c.qty,0) AS Qty, ISNULL(c.unit,'''''''') AS Unit
	FROM (((TLTrn t INNER JOIN TLmast m ON t.tl_id=m.tl_id) 
		LEFT OUTER JOIN Challan c ON t.vo_id=c.chal_id)
		LEFT OUTER JOIN Consignee g ON c.csge_id=g.csge_id)
		WHERE t.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY m.TL_No,t.Trn_Date, t.Trn_Code''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetOwnrLdg]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Sep 1,2011
-- Description:	Gets list of T/L transactions for Owner
-- =============================================
create PROCEDURE [dbo].[s_GetOwnrLdg]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT t.tt_id, t.Trn_Code, m.TL_Code, m.TL_No, o.AcName, 
	t.Trn_Date, t.Amount, ISNULL(g.csge_code,'''''''') AS csge_code, 
	ISNULL(c.qty,0) AS Qty, ISNULL(c.unit,'''''''') AS Unit
	FROM ((((TLTrn t INNER JOIN TLmast m ON t.tl_id=m.tl_id) 
		INNER JOIN GLmast o ON m.GL_id=o.GL_id) 
		LEFT OUTER JOIN Challan c ON t.vo_id=c.chal_id)
		LEFT OUTER JOIN Consignee g ON c.csge_id=g.csge_id)
		WHERE t.co_cd=''''''+@CO_CD+'''''' AND m.own=0 AND m.BillOwn=1''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY m.GL_id,t.Trn_Date, t.Trn_Code,m.TL_No''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acmast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Acmast](
	[Ac_id] [int] IDENTITY(1,1) NOT NULL,
	[Vo_no] [varchar](50) NOT NULL,
	[Vo_dt] [datetime] NULL,
	[Type] [char](10) NULL,
	[Chq_no] [char](10) NULL,
	[bank_dt] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Narr] [varchar](max) NULL,
	[co_cd] [nchar](1) NULL,
	[yr_cd] [nchar](2) NULL,
	[branch] [nchar](3) NULL CONSTRAINT [DF_Acmast_branch]  DEFAULT ('KOL'),
	[ref_id] [int] NULL CONSTRAINT [DF_Acmast_ref_id]  DEFAULT ((0)),
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [varchar](50) NULL,
 CONSTRAINT [PK_Acmast] PRIMARY KEY CLUSTERED 
(
	[Ac_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPartyFList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of Parties
-- =============================================
CREATE PROCEDURE [dbo].[s_GetPartyFList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT g.GL_id, g.AcName AS Name, g.grp_id, gr.grpname as GrpName,
		g.yrOpen, g.status as Type, Addr as Address,Bill_addr as BillAddress,
		g.IT_file as PAN_No, g.RC_No, g.VAT_No, g.ECC_No, g.ref_no, g.encl, g.attn, g.kattn 
  FROM ([GLmast] g INNER JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id)
  WHERE g.co_cd=''''''+@CO_CD+'''''' AND g.Grp_id=5''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY g.AcName''

print(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Party list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPartyList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of Parties(for combo)
-- =============================================
CREATE PROCEDURE [dbo].[s_GetPartyList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);
	DECLARE @CSP	BIT;

	SELECT @CSP=CashParty from CoMain where Co_Id=convert(integer,@CO_CD)

	SET @SSQL=''SELECT g.GL_id, g.AcName AS Name
  FROM ([GLmast] g JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id)
  WHERE g.co_cd=''''''+@CO_CD 
	+'''''' AND gr.Grpcode LIKE ''''DA%''''''
	IF @CSP=1
	BEGIN
		SET @SSQL=@SSQL+'' or g.gl_id=1''
	END

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY g.AcName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Party list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLexpList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jun 11,2011
-- Description:	Gets list of T/L exp heads
-- =============================================
create PROCEDURE [dbo].[s_GetTLexpList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT t.te_id, t.ExpCode, t.ExpName, g.AcName AS Account
	FROM (TLTexp t INNER JOIN [GLmast] g ON t.gl_id=g.gl_id) 
		WHERE t.co_cd=''''''+@CO_CD+''''''''

	SET @SSQL=@SSQL+'' ORDER BY t.ExpCode''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Warpt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Warpt](
	[Rpt_id] [int] IDENTITY(1,1) NOT NULL,
	[Rcode] [smallint] NULL,
	[Rname] [nvarchar](30) NULL,
	[Period] [bit] NOT NULL,
	[AsOn] [bit] NOT NULL,
	[TL] [bit] NOT NULL,
	[Acc] [bit] NOT NULL,
	[Tag] [nchar](5) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uobj]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[uobj](
	[uobj_id] [int] IDENTITY(1,1) NOT NULL,
	[uoname] [nvarchar](30) NOT NULL,
	[uogrp] [nchar](1) NULL,
	[co_cd] [nchar](1) NULL,
	[vis] [bit] NULL CONSTRAINT [DF_uobj_vis]  DEFAULT ((1)),
 CONSTRAINT [PK_uobj] PRIMARY KEY CLUSTERED 
(
	[uobj_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPartyBillList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2009
-- Description:	Gets list of bills for a party
-- =============================================
CREATE PROCEDURE [dbo].[s_GetPartyBillList]
	@CO_CD			CHAR(1),
	@GL_ID			INT,
	@ASON			DATETIME,
	@ONLYBAL		BIT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT  b.bill_id, b.bill_dt as Date, b.bill_no as Bill, b.Amount
			FROM Bill b 
			WHERE b.co_cd=''''''+@CO_CD+'''''' AND b.gl_id='' + convert(varchar(20),@GL_ID) +
 			'' AND b.bill_dt<='''''' + 	convert(varchar(20),@ASON,103) + ''''''''

	SET @SSQL=@SSQL+'' ORDER BY b.bill_dt desc,b.bill_no desc''

	print(@SSQL);
	exec(@SSQL);

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Bill list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPartyByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =================================================
-- Author:		G Ghosh
-- Create date: Mar 29,2011
-- Description:	Get Party ID by code
-- =================================================
CREATE PROCEDURE [dbo].[s_GetPartyByCode]
	@CO_CD			CHAR(1),
	@PCode			VARCHAR(20),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY

	SELECT tp.Gl_id
	FROM	GlMast tp
	WHERE	tp.co_cd=@CO_CD AND tp.AcCode LIKE @pCode

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Party List''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetMaxBillNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2010
-- Description:	Gets last no.of bills 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetMaxBillNo]
	@CO_CD			CHAR(1),
	@Type			CHAR(1),
	@sDate			DATETIME,
	@eDate			DATETIME,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT  max(b.bill_no) as Bill_No
			FROM Bill b 
			WHERE b.co_cd=@CO_CD and b.bill_type=@Type 
			and b.bill_dt>=@sDate and  b.bill_dt<=@eDate

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Bill list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCreditorList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of Parties(for combo)
-- =============================================
create PROCEDURE [dbo].[s_GetCreditorList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT g.GL_id, g.AcName AS Name
  FROM ([GLmast] g INNER JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id)
  WHERE g.co_cd=''''''+@CO_CD 
	+'''''' AND gr.Grpcode LIKE ''''IA%''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY g.AcName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Party list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		G Ghosh
-- Create date: Oct 17,2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[s_GetUser]
	@UserName		VARCHAR(20),
	@Password		VARCHAR(20),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	tu.fin_ID as usr_ID,
			CASE WHEN tu.fin_cat=2 THEN ''AD''
				 WHEN tu.fin_cat=1 THEN ''SU''
				 ELSE ''LI''
				 END as userType,
			tu.fin_funa as description
	FROM	finats tu
	WHERE	tu.fin_man = @UserName
			AND tu.fin_sap = @Password 
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read user details''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetRepDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 11,2011
-- Description:	Details of a rep
-- =============================================
create PROCEDURE [dbo].[s_GetRepDetails]
	@Rep_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT Rep_id,RepName 
		FROM Rep
		WHERE rep_id=@Rep_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetRepList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 11,2011
-- Description:	Gets list of Reps
-- =============================================
create PROCEDURE [dbo].[s_GetRepList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT c.Rep_id,c.RepName 
  FROM Rep c 
  WHERE c.co_cd=@CO_CD
  ORDER BY c.Repname

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Rep list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateRep]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 11,2011
-- Description:	Inserts or updates a Rep
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateRep]
	@Rep_id				INT = NULL,
	@Repname			NVARCHAR(30),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@Rep_id,0) = 0
			BEGIN

				INSERT INTO Rep(Repname,co_cd)
				VALUES(@Repname,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Rep
				SET Repname=@Repname, co_cd=@CO_CD
				WHERE Rep_id=@Rep_id

				SET @Return = @Rep_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSTList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 11,2011
-- Description:	Gets list of S/Tax
-- =============================================
CREATE PROCEDURE [dbo].[s_GetSTList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT Tax_id, Taxtype,stcode, STName, perc, edu_cess, he_cess, 
			tax_start, tax_end, form_due, taxonval
			FROM STMast
			WHERE co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+''   ORDER BY STname''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Tax list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetYears]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Oct 17, 2009
-- Description:	Gets years for company
-- =============================================
CREATE PROCEDURE [dbo].[s_GetYears] 
	@CO_ID		CHAR(1),
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	Yr_id,YrDesc,YrStart,YrEnd
	FROM	CoYear
	WHERE	Co_Cd = @CO_ID
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read year details''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetMaxVoNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2010
-- Description:	Gets last no.of bills 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetMaxVoNo]
	@CO_CD			CHAR(1),
	@vInit			VARCHAR(15),
	@sDate			DATETIME,
	@eDate			DATETIME,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT  max(b.vo_no) as Vo_No
			FROM AcMast b 
			WHERE b.co_cd=@CO_CD and b.vo_no=@vInit 
			and b.vo_dt>=@sDate and  b.vo_dt<=@eDate

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Voucher list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rep]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rep](
	[rep_id] [bigint] IDENTITY(1,1) NOT NULL,
	[RepName] [varchar](50) NOT NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[co_cd] [nchar](1) NULL CONSTRAINT [DF_Rep_co_cd]  DEFAULT ('1'),
 CONSTRAINT [PK_Rep] PRIMARY KEY CLUSTERED 
(
	[rep_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetHiBals]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		G.Ghosh
-- Create date: Oct 19, 2009
-- Description:	Gets hilight balances for company,user
--              (updated by s_UpdHiBals)
-- =============================================
CREATE PROCEDURE [dbo].[s_GetHiBals] 
	@CO_ID		CHAR(1),
	@USR_ID		INT,
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	hb_id,hb_Name as NAME,hb_bal as BALANCE,gl_id
	FROM	HiBal
	WHERE	Co_Cd = @CO_ID and usr_id=@USR_ID
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read balance details''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalIDbyNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 3,2011
-- Description:	ID of a Challan from Number
-- =============================================
CREATE PROCEDURE [dbo].[s_GetChalIDbyNo]
	@Number			NCHAR(15),
	@Co_cd			NCHAR(1),
	@Yr_cd			NCHAR(2),
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT Chal_id
		FROM Challan
		WHERE Chal_No=@Number and co_cd=@co_cd and yr_cd=@Yr_cd

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalIDbyCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 3,2011
-- Description:	ID of a Challan from C/N Number
-- =============================================
CREATE PROCEDURE [dbo].[s_GetChalIDbyCN]
	@Number			NCHAR(15),
	@Co_cd			NCHAR(1),
	@Yr_cd			NCHAR(2),
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT Chal_id
		FROM Challan
		WHERE CN_No=@Number and co_cd=@co_cd and yr_cd=@Yr_cd

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateChalUnld]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 30,2009
-- Description:	Inserts or updates a challan unload
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateChalUnld]
	@Unld_id		INT = NULL,
	@chal_id		INT,
	@Chal_rcd		DATETIME,
	@Deliv_dt		DATETIME,
	@deliv_wt		DECIMAL(18, 2),
	@deliv_unit		NCHAR(2),
	@shortage		DECIMAL(18, 2),
	@sht_unit		NCHAR(3),
	@sht_rate		DECIMAL(18, 2),
	@sht_amt		DECIMAL(18, 2),
	@Mkt_sht		DECIMAL(18, 2),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@unld_id,0) = 0
			BEGIN

				INSERT INTO ChalUnld(chal_id, chal_rcd, deliv_dt, deliv_wt, deliv_unit, 
					shortage, sht_unit, sht_rate, sht_amt, mkt_sht)
				VALUES(@chal_id, @chal_rcd, @deliv_dt, @deliv_wt, @deliv_unit, 
					@shortage, @sht_unit, @sht_rate, @sht_amt, @mkt_sht)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE ChalUnld
				SET chal_id=@chal_id, chal_rcd=@chal_rcd, deliv_dt=@deliv_dt, deliv_wt=@deliv_wt,
					deliv_unit=@deliv_unit, shortage=@shortage, sht_unit=@sht_unit, 
					sht_rate=@sht_rate, sht_amt=@sht_amt, mkt_sht=@mkt_sht 
				WHERE unld_id=@unld_id

				SET @Return = @unld_id
			END	

		COMMIT TRANSACTION

		RETURN

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateChalDtn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 30,2009
-- Description:	Inserts or updates a challan unload
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateChalDtn]
	@Dtn_id			INT = NULL,
	@chal_id		INT,
	@Pre_Dtn		BIT,
	@Rep_time		DATETIME,
	@Rel_time		DATETIME,
	@dtn_days		INT,
	@dtn_rate		DECIMAL(18, 2),
	@dtn_amt		DECIMAL(18, 2),
	@mkt_days		INT,
	@mkt_rate		DECIMAL(18, 2),
	@mkt_amt		DECIMAL(18, 2),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@dtn_id,0) = 0
			BEGIN

				INSERT INTO ChalDtn(chal_id, pre_dtn, rep_time, rel_time, dtn_days, 
					dtn_rate, dtn_amt, mkt_days, mkt_rate, mkt_amt)
				VALUES(@chal_id, @pre_dtn, @rep_time, @rel_time, @dtn_days, 
					@dtn_rate, @dtn_amt, @mkt_days, @mkt_rate, @mkt_amt)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE ChalDtn
				SET chal_id=@chal_id, pre_dtn=@pre_dtn, rep_time=@rep_time, rel_time=@rel_time, 
					dtn_days=@dtn_days, dtn_rate=@dtn_rate, dtn_amt=@dtn_amt, mkt_days=@mkt_days, 
					mkt_rate=@mkt_rate, mkt_amt=@mkt_amt 
				WHERE dtn_id=@dtn_id

				SET @Return = @dtn_id
			END	

		COMMIT TRANSACTION

		RETURN

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLbyNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Sep 18,2010
-- Description:	Details of a T/L from No
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTLbyNo]
	@TL_No				NVARCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT TL_id,TL_code,Own,Bilown,owner_id,start_date,end_date 
		FROM TLmast
		WHERE TL_No LIKE @TL_No+''%''
		ORDER BY start_date desc

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGLFList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 21,2010
-- Description:	Gets list of A/c heads 
-- =============================================
create PROCEDURE [dbo].[s_GetGLFList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT g.GL_id, g.AcName AS Name, g.grp_id, gr.grpname as Group,
		g.yrOpen, g.status as Type, Addr as Address,Bill_addr as BillAddress,
		g.IT_file as PAN_No, g.RC_No, g.VAT_No, g.ECC_No, g.ref_no, g.encl, g.attn, g.kattn 
  FROM ([GLmast] g INNER JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id)
  WHERE g.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY g.AcName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read A/c head list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGrpList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of A/c groups
-- =============================================
CREATE PROCEDURE [dbo].[s_GetGrpList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT Grp_id, GrpCode, GrpName, Status, SchNo 
  FROM GrpMast WHERE co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY GrpName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read A/c group list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBCal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBCal](
	[gl_id] [int] NULL,
	[ac_group] [nvarchar](40) NULL,
	[ac_name] [nvarchar](40) NULL,
	[op_bal] [decimal](18, 2) NULL,
	[cl_bal] [decimal](18, 2) NULL,
	[uid] [nvarchar](1) NULL,
	[grpcode] [nvarchar](4) NULL,
	[status] [nvarchar](1) NULL,
	[schno] [nvarchar](6) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoMain]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CoMain](
	[Co_id] [int] NOT NULL,
	[Co_Sht] [nchar](6) NULL,
	[Co_name] [nvarchar](50) NULL,
	[Co_add] [nvarchar](250) NULL,
	[Co_last] [datetime] NULL,
	[Co_type] [nchar](1) NULL CONSTRAINT [DF_CoMain_Co_type]  DEFAULT ('P'),
	[CST_no] [nvarchar](25) NULL,
	[WBST_no] [nvarchar](50) NULL,
	[STReg_No] [nvarchar](50) NULL,
	[IT_fileno] [nvarchar](25) NULL,
	[sign_off] [nvarchar](40) NULL,
	[sign_des] [nvarchar](10) NULL,
	[sign_end] [nvarchar](40) NULL,
	[co_email] [nvarchar](50) NULL,
	[co_phone] [nvarchar](50) NULL,
	[co_cd] [nchar](1) NOT NULL,
	[Cobu_type] [nchar](1) NULL CONSTRAINT [DF_CoMain_Cobu_type]  DEFAULT ('T'),
	[Product] [bit] NULL CONSTRAINT [DF_CoMain_Product]  DEFAULT ((0)),
	[Stock] [bit] NULL CONSTRAINT [DF_CoMain_Stock]  DEFAULT ((0)),
	[Accounts] [bit] NULL CONSTRAINT [DF_CoMain_Accounts]  DEFAULT ((0)),
	[Purchase] [bit] NULL CONSTRAINT [DF_CoMain_Purchase]  DEFAULT ((0)),
	[CashParty] [bit] NULL CONSTRAINT [DF_CoMain_CashParty]  DEFAULT ((0)),
	[dtn_b4_ldg] [bit] NULL CONSTRAINT [DF_CoMain_dtn_b4_ldg]  DEFAULT ((0)),
	[AcEffctB4Dlv] [bit] NULL CONSTRAINT [DF_CoMain_AcEffctUnDlv]  DEFAULT ((0)),
	[DrShrtge2Drv] [bit] NULL CONSTRAINT [DF_CoMain_DrShortge2Drv]  DEFAULT ((0)),
	[Dtn2ShrMktTL] [bit] NULL CONSTRAINT [DF_CoMain_Dtn2ShrMktTL]  DEFAULT ((0)),
	[ShrtgeIncldBill] [bit] NULL CONSTRAINT [DF_CoMain_ShortgeIncldBill]  DEFAULT ((0)),
	[MaxChlInBill] [tinyint] NULL CONSTRAINT [DF_CoMain_MaxChlInBill]  DEFAULT ((15)),
	[VoNoGen] [bit] NULL CONSTRAINT [DF_CoMain_VoNoGen]  DEFAULT ((0)),
	[PrintVouch] [bit] NULL CONSTRAINT [DF_CoMain_PrintVouch]  DEFAULT ((0)),
 CONSTRAINT [PK_CoMain] PRIMARY KEY CLUSTERED 
(
	[Co_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'P=prop, R=Partner, V=PvtLtd, L=Ltd, I=indiv' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'CoMain', @level2type=N'COLUMN', @level2name=N'Co_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'T=Transport, G=Gen, H=Homoeo' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'CoMain', @level2type=N'COLUMN', @level2name=N'Cobu_type'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VatCal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VatCal](
	[vc_id] [int] IDENTITY(1,1) NOT NULL,
	[v_date] [datetime] NULL,
	[Guest] [nvarchar](40) NULL,
	[Company] [nvarchar](50) NULL,
	[VAT_no] [nvarchar](11) NULL,
	[v_type] [nchar](2) NULL,
	[v_no] [nvarchar](12) NULL,
	[As_value] [decimal](18, 2) NULL,
	[VAT_amt] [decimal](18, 2) NULL,
	[VAT4] [decimal](18, 2) NULL,
	[VAT12] [decimal](18, 2) NULL,
	[VAToth] [decimal](18, 2) NULL,
	[taxable_amt] [decimal](18, 2) NULL,
	[uid] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VATForm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VATForm](
	[vf_id] [int] NOT NULL,
	[txt1] [nvarchar](100) NULL,
	[amt1] [decimal](18, 2) NULL,
	[txt2] [nvarchar](100) NULL,
	[amt2] [decimal](18, 2) NULL,
	[uid] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RefTbls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RefTbls](
	[tb_id] [int] NOT NULL,
	[tb_cd] [nvarchar](1) NULL,
	[tb_bas] [nvarchar](1) NULL,
	[up_lim] [int] NULL,
	[amt_m] [int] NULL,
	[amt_2] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetBillChalList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 21,2010
-- Description:	Gets list of challan
-- =============================================
CREATE PROCEDURE [dbo].[s_GetBillChalList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT c.chal_id, c.branch, c.chal_dt as Date, c.chal_no as Challan, c.cn_no as CN,
  c.ldpt_id, pl.pl_name as Loading, c.dest_id, pd.pl_name as Destination, pr.product,
  c.qty as Quantity, c.unit, c.rate, c.amount 
  FROM (((((Challan c INNER JOIN Glmast g ON c.Gl_id = g.Gl_id) INNER JOIN TLmast t ON c.TL_id = t.tl_id)
  INNER JOIN Place pl ON c.ldpt_id = pl.pl_id) INNER JOIN Place pd ON c.dest_id = pd.pl_id)
  INNER JOIN Product pr ON c.prod_id = pr.prod_id)
  WHERE c.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY c.chal_dt, c.chal_no''
print(@ssql);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Challan list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCurrUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		G Ghosh
-- Create date: Jul 7,2010
-- Description:	Gets list of logged Users
-- =============================================
CREATE PROCEDURE [dbo].[s_GetCurrUsers]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	distinct tu.fin_ID as usr_ID,
			tu.fin_man as uname
	FROM	finats tu INNER JOIN ulog ul ON tu.fin_id = ul.usr_id
	WHERE	datediff(ss,ltime,getdate())<=60
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read user log''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[finats]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[finats](
	[fin_id] [int] IDENTITY(1,1) NOT NULL,
	[fin_man] [nvarchar](10) NOT NULL,
	[fin_sap] [nvarchar](10) NOT NULL,
	[fin_cat] [tinyint] NOT NULL,
	[fin_funa] [nvarchar](30) NULL,
	[fin_aco] [bit] NOT NULL,
	[fin_com] [tinyint] NULL,
 CONSTRAINT [PK_finats] PRIMARY KEY CLUSTERED 
(
	[fin_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateTLmast]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Inserts or updates a T/L (provide CO_CD)
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateTLmast]
	@TL_id			INT = NULL,
	@TL_code		NCHAR(4),
	@TL_no			NVARCHAR(15),
	@Own			BIT,
	@Bilown			BIT,
	@owner_id		INT = NULL,
	@start_date		DATETIME,
	@end_date		DATETIME = NULL,
	@CO_CD			NCHAR(1),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @MAXCD NCHAR(4)
		DECLARE @NCD INT

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@TL_id,0) = 0
			BEGIN
				SELECT @MAXCD=MAX(TL_code) FROM TLmast
				IF @MAXCD IS NULL
				BEGIN
					SET @MAXCD=''0001''
				END
				ELSE
				BEGIN
					SET @NCD=@MAXCD
					SET @NCD=@NCD+1
					SET @MAXCD=@NCD
					SET @TL_code=RIGHT(''0000''+RTRIM(LTRIM(@MAXCD)),4)
				END

				INSERT INTO TLmast
				(TL_code,TL_no,Own,Bilown,owner_id,start_date,end_date,co_cd)
				VALUES
				(@TL_code,@TL_no,@Own,@Bilown,@owner_id,@start_date,@end_date,@CO_CD)
				SET @Return = SCOPE_IDENTITY()

				UPDATE TLmast
				SET end_date=dateadd(day,-1,@start_date)
				WHERE TL_id<>@Return AND co_cd=@CO_CD AND TL_no=@TL_no 
					AND isnull(end_date,''31 Dec 2099'')=''31 Dec 2099''
			END
			ELSE
			BEGIN
				UPDATE TLmast
				SET TL_code=@TL_code,
				TL_no=@TL_no,
				Own=@Own,
				Bilown=@Bilown,
				owner_id=@owner_id,
				start_date=@start_date,
				end_date=@end_date,
				co_cd=@CO_CD
				WHERE TL_id=@TL_id
				SET @Return = @TL_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Place]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Place](
	[pl_id] [int] IDENTITY(1,1) NOT NULL,
	[pl_sht] [nchar](6) NULL,
	[pl_name] [nvarchar](30) NULL,
	[pl_type] [nchar](1) NULL,
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[pl_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoYear]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CoYear](
	[Yr_id] [int] IDENTITY(1,1) NOT NULL,
	[YrDesc] [nchar](5) NOT NULL,
	[YrStart] [datetime] NOT NULL,
	[YrEnd] [datetime] NOT NULL,
	[Yr_cd] [nchar](2) NOT NULL,
	[Co_cd] [nchar](1) NOT NULL,
	[editlock] [bit] NULL CONSTRAINT [DF_CoYear_editlock]  DEFAULT ((0)),
	[viewlock] [bit] NULL CONSTRAINT [DF_CoYear_viewlock]  DEFAULT ((0)),
 CONSTRAINT [PK_CoYear] PRIMARY KEY CLUSTERED 
(
	[Yr_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSubList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: May 18,2011
-- Description:	Gets list of Sub A/c heads
-- =============================================
CREATE PROCEDURE [dbo].[s_GetSubList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT g.Sub_id, g.SubName AS Name, g.sgr_id, gr.sgrname as SubGrp
		FROM ([SubMast] g INNER JOIN [SubGrmast] gr ON g.sgr_id=gr.sGr_id) 
		WHERE g.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY g.SubName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--= ''Can not read Sub head list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLlist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 1,2009
-- Description:	Gets list of T/Ls
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTLlist]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT t.[TL_id],t.[TL_no] AS [TL No],t.[TL_code] AS Code,
	  CASE WHEN t.[Own]=1 THEN ''''Own''''
		ELSE ''''Mkt'''' 
		END AS O_Ship,
	  t.[owner_id],
	  CASE WHEN g.[AcName] IS NULL THEN ''''''''
		ELSE g.[AcName]
		END AS Owner
      ,[start_date] as [Start Date],[end_date] as [End Date]
  FROM ([TLmast] t LEFT OUTER JOIN [Glmast] g ON t.owner_id=g.Gl_id)
  WHERE t.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY t.TL_no,t.start_date desc''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read T/L list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSGrList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of A/c groups
-- =============================================
CREATE PROCEDURE [dbo].[s_GetSGrList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT SGr_id, SGrName, Status 
    FROM SubGrMast WHERE co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY SGrName''

    print @SSQL;
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read A/c group list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Details of a T/L
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTLDetails]
	@TL_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT TL_code,TL_no,Own,Bilown,owner_id,start_date,end_date 
		FROM TLmast
		WHERE TL_id=@TL_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubGrmast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubGrmast](
	[SGr_Id] [int] IDENTITY(1,1) NOT NULL,
	[SGrName] [nvarchar](30) NOT NULL,
	[Status] [nchar](1) NULL,
	[yrOpen] [nchar](5) NULL,
	[co_cd] [nchar](1) NOT NULL,
 CONSTRAINT [PK_SubGrmast] PRIMARY KEY CLUSTERED 
(
	[SGr_Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPlaceList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 10,2009
-- Description:	Gets list of Places
-- =============================================
CREATE PROCEDURE [dbo].[s_GetPlaceList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT pl_id,pl_name as Place,pl_sht as Code,pl_type,
		CASE WHEN pl_type=''''L'''' THEN ''''Load''''
			WHEN pl_type=''''D'''' THEN ''''Dest''''
			ELSE ''''Othr'''' 
		END AS pType
	FROM Place
	WHERE co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY pl_name'';

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Place list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubMast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubMast](
	[Sub_id] [int] IDENTITY(1,1) NOT NULL,
	[SubName] [nvarchar](40) NOT NULL,
	[SGr_id] [int] NOT NULL,
	[subtype] [nchar](1) NULL,
	[yrOpen] [nchar](5) NULL,
	[OpBal] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SubMast_OpBal]  DEFAULT ((0.00)),
	[LyBal] [decimal](18, 2) NOT NULL CONSTRAINT [DF_SubMast_LyBal]  DEFAULT ((0.00)),
	[Status] [nchar](1) NULL,
	[Co_cd] [nchar](1) NOT NULL,
	[AcCode] [nchar](4) NULL,
	[IT_file] [nvarchar](25) NULL,
	[RC_no] [nvarchar](20) NULL,
	[VAT_NO] [nvarchar](11) NULL,
	[Addr] [nvarchar](max) NULL,
	[ph_no] [nvarchar](30) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL CONSTRAINT [DF_SubMast_edate]  DEFAULT (getdate()),
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_SubMast] PRIMARY KEY CLUSTERED 
(
	[Sub_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdatePlace]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Inserts or updates a place(loading pt./destination)
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdatePlace]
	@pl_id				INT = NULL,
	@pl_sht				NCHAR(6),
	@pl_name			NVARCHAR(30),
	@pl_type			NCHAR(1),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@pl_id,0) = 0
			BEGIN

				INSERT INTO Place(pl_sht,pl_name,pl_type,co_cd)
				VALUES(@pl_sht,@pl_name,@pl_type,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Place
				SET pl_sht=@pl_sht,	pl_name=@pl_name, pl_type=@pl_type, co_cd=@CO_CD
				WHERE pl_id=@pl_id

				SET @Return = @pl_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateSubGL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: May 23,2011
-- Description:	update GL-subs
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateSubGL]
	@sg_ID		INT=NULL,
	@GL_ID		INT,
	@Sub_ID		INT,
	@CO_CD		CHAR(1),
	@Return     INT OUTPUT,
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SET @ErrMsg = ''''
	BEGIN TRANSACTION
		IF ISNULL(@sg_ID,0) = 0
		BEGIN

			INSERT INTO SubGL(Gl_id,Sub_id,co_cd)
			VALUES(@Gl_id,@Sub_id,@CO_CD)

			SET @Return = SCOPE_IDENTITY()
		END
		ELSE
		BEGIN

			UPDATE SubGL
			SET Gl_id=@Gl_id, Sub_id=@Sub_id, co_cd=@CO_CD
			WHERE sg_ID=@sg_ID

			SET @Return = @sg_ID
		END	
	COMMIT TRANSACTION				
	
	RETURN

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @ErrMsg = ''Can not update GL-Subs''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSubGLList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: May 18,2011
-- Description:	Gets list of Sub A/c heads
-- =============================================
CREATE PROCEDURE [dbo].[s_GetSubGLList]
	@GL_ID			INT=NULL,
	@Sub_ID			INT=NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000)
	DECLARE @WH		BIT

	SET @SSQL=''SELECT s.Sub_id, s.SubName AS Name, g.gl_id, g.AcName
		FROM (([SubMast] s INNER JOIN [SubGl] u ON u.sub_id=s.sub_id) 
		INNER JOIN [Glmast] g ON g.gl_id=u.Gl_id)''

	SET @WH=0 
	IF ISNULL(@Gl_id,0)	> 0
	BEGIN
		SET @SSQL=@SSQL+'' WHERE g.gl_id=''+ convert(varchar(20),@GL_ID)
		SET @WH=1
	END
	IF ISNULL(@Sub_id,0) > 0
	BEGIN
		IF @WH=0
		BEGIN
			SET @SSQL=@SSQL+'' WHERE ''
		END
		SET @SSQL=@SSQL+''s.sub_id='' + convert(varchar(20),@Sub_ID)
	END

	SET @SSQL=@SSQL+'' ORDER BY s.SubName''

	print(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--= ''Can not read Sub head list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLbyCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Sep 18,2010
-- Description:	Details of a T/L from Code
-- =============================================
create PROCEDURE [dbo].[s_GetTLbyCode]
	@TL_Code			NCHAR(4),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT TL_id,TL_no,Own,Bilown,owner_id,start_date,end_date 
		FROM TLmast
		WHERE TL_code=@TL_code

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateGLname]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -GL
-- =============================================
CREATE PROCEDURE [dbo].[s_ChkDuplicateGLname]
	@GL_id			INT = NULL,
	@AcName			NVARCHAR(40),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM GLmast
		WHERE upper(AcName)=upper(@AcName) and GL_id<>@GL_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetRateList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Aug 23,2010
-- Description:	Gets list of Challan Rates 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetRateList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(4000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	DECLARE @SSQL	VARCHAR(4500);

	SET @SSQL=''SELECT t.tar_id,g.AcName as Party,c.csge_code as Consignee,i.product,l.pl_name as LodgPt,d.pl_name as Dest,
		t.bill_rate,convert(varchar(20),t.wef,106) as WEF,convert(varchar(20),t.efto,106) as UpTo,
		c.csge_code+'''' - ''''+i.product+'''' - ''''+l.pl_name+'''' - ''''+d.pl_name+convert(varchar(20),t.bill_rate)+
		'''' - ''''+convert(varchar(20),t.wef,106)+'''' - ''''+convert(varchar(20),t.efto,106) as Rates
		FROM (((((Tarset t INNER JOIN Glmast g ON t.gl_id = g.gl_id)
		INNER JOIN Consignee c ON t.csge_id = c.csge_id)
		INNER JOIN Place l ON t.ldpt_id = l.pl_id)
		INNER JOIN Place d ON t.dest_id = d.pl_id)
		INNER JOIN Product i ON t.prod_id = i.prod_id)
		WHERE t.co_cd=''+@CO_CD

	IF LEN(ISNULL(@Filt,'''')) > 0 
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END
	SET @SSQL=@SSQL+''  ORDER BY g.AcName,c.csge_code,i.product,l.pl_name,t.wef''
	PRINT(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Rate list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateGLCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate Code check -GL
-- =============================================
CREATE PROCEDURE [dbo].[s_ChkDuplicateGLCode]
	@GL_id			INT = NULL,
	@AcCode			NVARCHAR(15),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM GLmast
		WHERE upper(AcCode)=upper(@AcCode) and GL_id<>@GL_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateCsgeName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -Csge
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateCsgeName]
	@Csge_id		INT = NULL,
	@CName			NVARCHAR(30),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM Consignee
		WHERE upper(Csge_Name)=upper(@CName) and Csge_id<>@Csge_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateCsgeCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 27,2011
-- Description:	Duplicate name check -Csge code
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateCsgeCode]
	@Csge_id		INT = NULL,
	@CCode			NVARCHAR(15),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM Consignee
		WHERE upper(Csge_Code)=upper(@CCode) and Csge_id<>@Csge_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[STMast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[STMast](
	[tax_id] [int] IDENTITY(1,1) NOT NULL,
	[taxtype] [nchar](1) NULL,
	[stcode] [nchar](4) NOT NULL,
	[stname] [nvarchar](30) NOT NULL,
	[perc] [decimal](18, 2) NOT NULL CONSTRAINT [DF_STMast_perc]  DEFAULT ((0.00)),
	[surch] [decimal](18, 2) NOT NULL CONSTRAINT [DF_STMast_surch]  DEFAULT ((0.00)),
	[adl_sc] [decimal](18, 2) NOT NULL CONSTRAINT [DF_STMast_adl_sc]  DEFAULT ((0.00)),
	[edu_cess] [decimal](18, 2) NOT NULL CONSTRAINT [DF_STMast_edu_cess_1]  DEFAULT ((0.00)),
	[he_cess] [decimal](18, 2) NOT NULL CONSTRAINT [DF_STMast_edu_cess]  DEFAULT ((0.00)),
	[tax_start] [datetime] NOT NULL,
	[tax_end] [datetime] NULL,
	[form_due] [bit] NOT NULL CONSTRAINT [DF_STMast_form_due]  DEFAULT ((0)),
	[taxonval] [decimal](18, 2) NULL CONSTRAINT [DF_STMast_taxonval]  DEFAULT ((0)),
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL CONSTRAINT [DF_STMast_uid]  DEFAULT (N'1'),
	[edate] [datetime] NULL CONSTRAINT [DF_STMast_edate]  DEFAULT (getdate()),
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_STMast] PRIMARY KEY CLUSTERED 
(
	[tax_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grpmast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Grpmast](
	[Grp_Id] [int] IDENTITY(1,1) NOT NULL,
	[GrpCode] [nchar](4) NOT NULL,
	[GrpName] [nvarchar](30) NOT NULL,
	[Status] [nchar](1) NULL,
	[SchNo] [nchar](4) NULL,
	[yrOpen] [nchar](5) NULL,
	[co_cd] [nchar](1) NOT NULL,
 CONSTRAINT [PK_Grpmast] PRIMARY KEY CLUSTERED 
(
	[Grp_Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[prod_id] [int] IDENTITY(1,1) NOT NULL,
	[product] [nchar](6) NULL,
	[proddesc] [nvarchar](40) NULL,
	[yrOpen] [nchar](5) NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCsgeDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 13,2009
-- Description:	Details of a consignee
-- =============================================
create PROCEDURE [dbo].[s_GetCsgeDetails]
	@csge_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT csge_code,csge_name,Gl_id,dest_id,yrOpen 
		FROM Consignee
		WHERE csge_id=@csge_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCsgeList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 13,2009
-- Description:	Gets list of Consignees
-- =============================================
CREATE PROCEDURE [dbo].[s_GetCsgeList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT c.csge_id,c.csge_name as Name,c.csge_code as Code,c.Gl_id,c.dest_id,
		c.YrOpen,g.AcName as Party,p.pl_name as Destination
		FROM ((Consignee c INNER JOIN Glmast g ON c.Gl_id = g.Gl_id)
		INNER JOIN Place p ON c.dest_id = p.pl_id)
		WHERE c.co_cd=''+@CO_CD

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+''	ORDER BY c.csge_name,p.pl_name''
print @ssql;
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Consignee list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateCsge]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 13,2009
-- Description:	Inserts or updates a Consignee
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateCsge]
	@csge_id			INT = NULL,
	@csge_code			NCHAR(10),
	@csge_name			NVARCHAR(30),
	@Gl_id				INT,
	@dest_id			INT,
	@yrOpen				NCHAR(5),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@csge_id,0) = 0
			BEGIN

				INSERT INTO Consignee(csge_code,csge_name,Gl_id,dest_id,yrOpen,co_cd)
				VALUES(@csge_code,@csge_name,@Gl_id,@dest_id,@yrOpen,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Consignee
				SET csge_code=@csge_code, csge_name=@csge_name, Gl_id=@Gl_id,
				dest_id=@dest_id, yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE csge_id=@csge_id

				SET @Return = @csge_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AcList](
	[gl_id] [int] NULL,
	[ac_group] [nvarchar](40) NULL,
	[ac_name] [nvarchar](40) NULL,
	[op_bal] [decimal](18, 2) NULL,
	[cl_bal] [decimal](18, 2) NULL,
	[uid] [nchar](1) NULL,
	[grpcode] [nvarchar](4) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetDriverList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: July 11,2011
-- Description:	Gets list of Drivers
-- =============================================
CREATE PROCEDURE [dbo].[s_GetDriverList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT s.sub_id,s.subname as Name,s.subtype,s.YrOpen,s.status
				FROM SubMast s 
				WHERE s.co_cd=''''''+@CO_CD+'''''' AND s.sgr_id=1''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY s.SubName''
	print(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Driver list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCoDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 17, 2011
-- Description:	Gets company details
-- =============================================
create PROCEDURE [dbo].[s_GetCoDetails] 
	@CO_ID		CHAR(1),
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	*
	FROM	CoMain
	WHERE	Co_Cd = @CO_ID
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read Company details''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 17, 2011
-- Description:	Gets company list
-- =============================================
create PROCEDURE [dbo].[s_GetCos] 
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	*
	FROM	CoMain
	ORDER BY Co_Name
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read Co. list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGLList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of A/c heads
-- =============================================
CREATE PROCEDURE [dbo].[s_GetGLList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT g.GL_id, g.AcName AS Name, g.grp_id, gr.grpname as AcGrp, 
		CASE WHEN g.HasSub=1 THEN ''''Y'''' ELSE ''''N'''' END as SubAc 
		FROM ([GLmast] g INNER JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id) 
		WHERE g.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY g.AcName''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--= ''Can not read A/c head list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetVoList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 11,2011
-- Description:	Gets list of A/c vouchers
-- =============================================
CREATE PROCEDURE [dbo].[s_GetVoList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(4000);

	SET @SSQL=''SELECT a.ac_id,a.vo_no as VoNo, convert(varchar(20),a.vo_dt,103) as VoDate, 
		''''VoType''''=case a.type when ''''P'''' then ''''Payment''''
							 when ''''R'''' then ''''Receipt''''
							 when ''''C'''' then ''''Contra''''
							 when ''''B'''' then ''''Bill''''
							 when ''''Q'''' then ''''Purchase''''
							 else ''''Unknown'''' END, a.chq_no as ChequeNo, 
		g.AcName AS Account, abs(b.amount) as amount, 
		''''DrCr''''= case when b.amount<0 then ''''Cr'''' ELSE ''''Dr'''' END,
		convert(varchar(20),a.narr) as Remarks
		FROM ((Acmast a INNER JOIN AcDtl b ON a.ac_id=b.ac_id) 
		INNER JOIN GlMast g ON b.gl_id=g.gl_id)
		WHERE g.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY a.vo_dt desc, a.type desc, a.vo_no desc''

	print(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read A/c voucher list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 20,2009
-- Description:	Gets list of challan
-- =============================================
CREATE PROCEDURE [dbo].[s_GetChalList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT c.chal_id, c.branch, c.chal_dt as Date, c.chal_no as Challan, c.cn_no as CN,
  c.Gl_id, g.AcName as Party, c.csgr_id, cr.cs_name as Consignor,c.ldpt_id, pl.pl_name as Loading, 
  c.csge_id, ce.csge_code as Consignee, c.dest_id, pd.pl_name as Destination, pr.product,c.qty as Quantity, c.unit,
  (select count(*) from chalunld where chal_id=c.chal_id) as Unloaded 
  FROM (((((((Challan c INNER JOIN Glmast g ON c.Gl_id = g.Gl_id) INNER JOIN TLmast t ON c.TL_id = t.tl_id)
  INNER JOIN Consignee ce on c.csge_id=ce.csge_id) INNER JOIN Consignor cr on c.csgr_id=cr.csgr_id)
  INNER JOIN Place pl ON c.ldpt_id = pl.pl_id) INNER JOIN Place pd ON c.dest_id = pd.pl_id)
  INNER JOIN Product pr ON c.prod_id = pr.prod_id)
  WHERE c.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END

	SET @SSQL=@SSQL+'' ORDER BY c.chal_dt desc,c.chal_no desc''

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Challan list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcTrn]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AcTrn](
	[Mgl_Id] [int] NULL,
	[ac_did] [int] NULL,
	[ac_id] [int] NULL,
	[Gl_Id] [int] NULL,
	[amount] [decimal](18, 2) NULL,
	[uid] [nchar](1) NULL,
	[mAmt] [decimal](18, 2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 10,2009
-- Description:	Details of a challan
-- =============================================
CREATE PROCEDURE [dbo].[s_GetChalDetails]
	@chal_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT chal_id, branch, chal_dt, chal_no, cn_no, tl_id, Gl_id, csgr_id, ldpt_id, 
		csge_id, dest_id, trip_days, driv_id, prod_id, qty, unit, rate, per, amount,
		hire_frgt, unld_id, dtn1_id, dtn2_id, bill_id, suplbill_id, hfbill_id, status
		FROM Challan
		WHERE chal_id=@chal_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetBillDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 21,2009
-- Description:	Details of a Bill
-- =============================================
CREATE PROCEDURE [dbo].[s_GetBillDetails]
	@Bill_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT Bill_no, Bill_dt, Bill_type, Gl_id, iAc_id, nontaxbl, taxbl, lessfrt,
		freight, detention, OthName, OthChgs, total, st_id, ServPc, ServTax, postage, 
		roundoff, amount, ref, lodloc, rep_id, co_cd, branch, uid, edate, upuids
		FROM Bill 
		WHERE Bill_id=@bill_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetBillList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2009
-- Description:	Gets list of bills 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetBillList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT  b.bill_id, b.bill_dt as Date, b.bill_no as Bill, b.Amount, 
			b.bill_type as Type, p.AcName as Party
			FROM Bill b INNER JOIN Glmast p ON b.gl_id=p.gl_id
			WHERE b.co_cd=''''''+@CO_CD+''''''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND (''+@Filt+'')''
	END

	SET @SSQL=@SSQL+'' ORDER BY b.bill_dt desc,b.bill_no desc''

	exec(@SSQL);

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Bill list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 10,2009
-- Description:	Inserts or updates a bill
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateBill]
	@bill_id			INT = NULL,
	@bill_no			NVARCHAR(15),
	@Bill_Dt			DATETIME,
	@Bill_Type			CHAR(1),
	@GL_ID				INT,
	@IAC_ID				INT,
	@nontaxbl			DECIMAL(18,2),
	@taxbl				DECIMAL(18,2),
	@lessfrt			DECIMAL(18,2),
	@freight			DECIMAL(18,2),
	@detention			DECIMAL(18,2),
	@OthName			NVARCHAR(50),
	@OthChgs			DECIMAL(18,2),
	@total				DECIMAL(18,2),
	@st_id				INT,
	@servpc				DECIMAL(18,2),
	@servtax			DECIMAL(18,2),
	@postage			DECIMAL(18,2),
	@roundoff			DECIMAL(18,2),
	@Amount				DECIMAL(18,2),
	@ref				VARCHAR(100),
	@lodloc				VARCHAR(50),
	@rep_id				INT,
	@branch				NCHAR(3),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@bill_id,0) = 0
			BEGIN

				INSERT INTO Bill(bill_no, Bill_Dt, Bill_Type, Gl_id, IAC_ID, nontaxbl, taxbl, lessfrt,
					freight, detention, OthName, OthChgs, total, st_id, servpc,
					servtax, postage, roundoff, Amount, ref, lodloc,
					rep_id, branch, co_cd)
				VALUES(@bill_no, @Bill_Dt, @Bill_Type, @Gl_id, @IAC_ID, @nontaxbl, @taxbl, @lessfrt,
					@freight, @detention, @OthName, @OthChgs, @total, @st_id, @servpc,
					@servtax, @postage, @roundoff, @Amount, @ref, @lodloc,
					@rep_id, @branch, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Bill
				SET bill_no=@bill_no, Bill_Dt=@Bill_Dt, Bill_Type=@Bill_Type, Gl_id=@Gl_id,
				IAC_ID=@IAC_ID, nontaxbl=@nontaxbl, taxbl=@taxbl, lessfrt=@lessfrt,
				freight=@freight, detention=@detention, OthName=@OthName, OthChgs=@OthChgs,
				total=@total, st_id=@st_id, servpc=@servpc,	servtax=@servtax, postage=@postage,
				roundoff=@roundoff, amount=@Amount, ref=@ref, lodloc=@lodloc,
				rep_id=@rep_id, branch=@branch, co_cd=@CO_CD
				WHERE bill_id=@bill_id

				SET @Return = @bill_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTarList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 3,2009
-- Description:	Gets list of rates
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTarList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL=''SELECT t.tar_id,g.AcName as Party,c.csge_code as Consignee,i.product,l.pl_name as LoadPt,d.pl_name as Dest,
	t.bill_rate,convert(varchar(20),t.wef,106) as WEF,convert(varchar(20),t.efto,106) as UpTo
  FROM (((((Tarset t INNER JOIN GlMast g ON t.gl_id = g.gl_id)
  INNER JOIN Consignee c ON t.csge_id = c.csge_id)
  INNER JOIN Place l ON t.ldpt_id = l.pl_id)
  INNER JOIN Place d ON t.dest_id = d.pl_id)
  INNER JOIN Product i ON t.prod_id = i.prod_id)
  WHERE t.co_cd=''''''+@CO_CD 

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+'' AND ''+@Filt
	END
	SET @SSQL=@SSQL+'' ORDER BY c.csge_code,i.product,l.pl_name,t.wef''

	print @SSQL;
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Rate list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Branch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Branch](
	[br_id] [int] IDENTITY(1,1) NOT NULL,
	[br_code] [nchar](3) NOT NULL,
	[br_name] [nvarchar](30) NOT NULL,
	[yrOpen] [nchar](5) NOT NULL,
	[co_cd] [nchar](1) NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[br_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGLIDbyCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 18,2011
-- Description:	Details of a Account from Code
-- =============================================
create PROCEDURE [dbo].[s_GetGLIDbyCode]
	@Accode				NCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT GL_id
		FROM GLmast
		WHERE Accode=@Accode

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteTL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a T/L
-- =============================================
create PROCEDURE [dbo].[s_DeleteTL]
	@tl_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM TLMast
		WHERE tl_id=@tl_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcSubDtl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AcSubDtl](
	[sub_did] [int] IDENTITY(1,1) NOT NULL,
	[ac_did] [int] NULL,
	[sub_id] [int] NULL,
	[tl_id] [int] NULL,
	[bill_id] [int] NULL,
	[amount] [decimal](18, 2) NULL,
	[dtype] [nchar](1) NULL,
 CONSTRAINT [PK_AcSubDtl] PRIMARY KEY CLUSTERED 
(
	[sub_did] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'B, T or S' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AcSubDtl', @level2type=N'COLUMN', @level2name=N'dtype'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLTrn]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TLTrn](
	[tt_id] [int] IDENTITY(1,1) NOT NULL,
	[tl_id] [int] NULL,
	[trn_code] [nchar](1) NULL,
	[trn_date] [datetime] NULL,
	[amount] [decimal](18, 2) NULL,
	[vo_id] [int] NULL,
	[co_cd] [nchar](1) NULL,
	[tlb_id] [int] NULL,
 CONSTRAINT [PK_TLTrn] PRIMARY KEY CLUSTERED 
(
	[tt_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Challan]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Challan](
	[chal_id] [int] IDENTITY(1,1) NOT NULL,
	[branch] [nchar](3) NOT NULL,
	[tl_id] [int] NOT NULL,
	[chal_no] [nvarchar](15) NOT NULL,
	[chal_dt] [datetime] NOT NULL,
	[cn_no] [nvarchar](15) NOT NULL,
	[csgr_id] [int] NOT NULL,
	[ldpt_id] [int] NOT NULL,
	[gl_id] [int] NOT NULL,
	[csge_id] [int] NOT NULL,
	[dest_id] [int] NOT NULL,
	[trip_days] [smallint] NULL,
	[driv_id] [int] NULL,
	[prod_id] [int] NOT NULL,
	[qty] [decimal](18, 2) NOT NULL,
	[unit] [nchar](2) NOT NULL,
	[rate] [decimal](18, 2) NOT NULL,
	[per] [nchar](2) NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[hire_frgt] [decimal](18, 2) NOT NULL,
	[unld_id] [int] NULL,
	[dtn1_id] [int] NULL,
	[dtn2_id] [int] NULL,
	[bill_id] [int] NULL,
	[suplbill_id] [int] NULL,
	[dtnbill_id] [int] NULL,
	[status] [nchar](1) NOT NULL,
	[co_cd] [nchar](1) NOT NULL,
	[yr_cd] [nchar](2) NOT NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Challan] PRIMARY KEY CLUSTERED 
(
	[chal_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLDates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TLDates](
	[tld_id] [int] IDENTITY(1,1) NOT NULL,
	[tl_id] [int] NULL,
	[sale_date] [datetime] NULL,
	[road_tax] [datetime] NULL,
	[w_permit] [datetime] NULL,
	[n_permit] [datetime] NULL,
	[insurance] [datetime] NULL,
	[calibration] [datetime] NULL,
	[c_f] [datetime] NULL,
	[e_license] [datetime] NULL,
	[p_license] [datetime] NULL,
	[status] [nchar](1) NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_TLDates] PRIMARY KEY CLUSTERED 
(
	[tld_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcDtl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AcDtl](
	[ac_did] [int] IDENTITY(1,1) NOT NULL,
	[ac_id] [int] NULL,
	[gl_id] [int] NULL,
	[amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_AcDtl] PRIMARY KEY CLUSTERED 
(
	[ac_did] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecptDtl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RecptDtl](
	[Rc_did] [int] IDENTITY(1,1) NOT NULL,
	[Rc_id] [int] NULL,
	[Bill_id] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[tds_amt] [decimal](18, 2) NULL,
 CONSTRAINT [PK_RecptDtl] PRIMARY KEY CLUSTERED 
(
	[Rc_did] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChalUnld]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChalUnld](
	[unld_id] [int] IDENTITY(1,1) NOT NULL,
	[chal_id] [int] NOT NULL,
	[chal_rcd] [datetime] NULL,
	[deliv_dt] [datetime] NULL,
	[deliv_wt] [decimal](18, 2) NOT NULL,
	[deliv_unit] [nchar](2) NOT NULL,
	[shortage] [decimal](18, 2) NOT NULL,
	[sht_unit] [nchar](3) NOT NULL,
	[sht_rate] [decimal](18, 2) NOT NULL,
	[sht_amt] [decimal](18, 2) NOT NULL,
	[mkt_sht] [decimal](18, 2) NOT NULL,
	[pshtamt] [decimal](18, 2) NULL CONSTRAINT [DF_ChalUnld_pshtamt]  DEFAULT ((0)),
 CONSTRAINT [PK_ChalUnld] PRIMARY KEY CLUSTERED 
(
	[unld_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChallDtn]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChallDtn](
	[dtn_id] [int] IDENTITY(1,1) NOT NULL,
	[chal_id] [int] NULL,
	[pre_dtn] [bit] NOT NULL,
	[rep_time] [datetime] NULL,
	[rel_time] [datetime] NULL,
	[dtn_days] [decimal](18, 2) NULL,
	[dtn_rate] [decimal](18, 2) NULL,
	[dtn_amt] [decimal](18, 2) NULL,
	[mkt_days] [decimal](18, 2) NULL,
	[mkt_rate] [decimal](18, 2) NULL,
	[mkt_amt] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ChallDtn] PRIMARY KEY CLUSTERED 
(
	[dtn_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ulog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ulog](
	[ul_id] [int] IDENTITY(1,1) NOT NULL,
	[co_cd] [nchar](1) NOT NULL,
	[usr_id] [int] NOT NULL,
	[uobj_id] [int] NOT NULL,
	[ltime] [datetime] NOT NULL CONSTRAINT [DF_ulog_ltime]  DEFAULT (getdate()),
	[lstate] [bit] NULL CONSTRAINT [DF_ulog_lstate]  DEFAULT ((0)),
 CONSTRAINT [PK_ulog] PRIMARY KEY CLUSTERED 
(
	[ul_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usrFav]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[usrFav](
	[uf_id] [int] IDENTITY(1,1) NOT NULL,
	[usr_id] [int] NOT NULL,
	[uobj_id] [int] NOT NULL,
	[inFav] [bit] NOT NULL CONSTRAINT [DF_usrFav_inFav]  DEFAULT ((1)),
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_usrFav] PRIMARY KEY CLUSTERED 
(
	[uf_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usrperm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[usrperm](
	[up_id] [int] IDENTITY(1,1) NOT NULL,
	[usr_id] [int] NOT NULL,
	[uobj_id] [int] NOT NULL,
	[addperm] [bit] NOT NULL,
	[editperm] [bit] NOT NULL,
	[delperm] [bit] NOT NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_usrperm] PRIMARY KEY CLUSTERED 
(
	[up_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tarset]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tarset](
	[tar_id] [int] IDENTITY(1,1) NOT NULL,
	[gl_id] [int] NULL,
	[csge_id] [int] NULL,
	[prod_id] [int] NULL,
	[ldpt_id] [int] NULL,
	[dest_id] [int] NULL,
	[bill_rate] [decimal](18, 2) NULL,
	[hire_rate] [decimal](18, 2) NULL,
	[shrt_rate] [decimal](18, 2) NULL,
	[shrt_unit] [nchar](3) NULL,
	[othr_rate] [decimal](18, 2) NULL,
	[othr_name] [nvarchar](20) NULL,
	[othr_unit] [nchar](1) NULL,
	[wef] [datetime] NULL,
	[efto] [datetime] NULL,
	[status] [nchar](1) NULL,
	[co_cd] [nchar](1) NULL,
	[RouteKM] [int] NOT NULL CONSTRAINT [DF_Tarset_RouteKM]  DEFAULT ((0)),
 CONSTRAINT [PK_Tarset] PRIMARY KEY CLUSTERED 
(
	[tar_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consignee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Consignee](
	[csge_id] [int] IDENTITY(1,1) NOT NULL,
	[csge_code] [nvarchar](15) NULL,
	[csge_name] [nvarchar](30) NULL,
	[Gl_id] [int] NULL,
	[dest_id] [int] NULL,
	[yrOpen] [nchar](5) NULL,
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Consignee] PRIMARY KEY CLUSTERED 
(
	[csge_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consignor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Consignor](
	[csgr_id] [int] IDENTITY(1,1) NOT NULL,
	[cs_code] [nchar](10) NOT NULL,
	[cs_name] [nvarchar](30) NOT NULL,
	[ldpt_id] [int] NOT NULL,
	[yrOpen] [nchar](5) NULL,
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Consignor] PRIMARY KEY CLUSTERED 
(
	[csgr_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Glmast]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Glmast](
	[Gl_id] [int] IDENTITY(1,1) NOT NULL,
	[AcName] [nvarchar](40) NOT NULL,
	[Grp_id] [int] NOT NULL,
	[yrOpen] [nchar](5) NULL,
	[OpBal] [decimal](18, 2) NULL,
	[LyBal] [decimal](18, 2) NULL,
	[HasSub] [bit] NOT NULL CONSTRAINT [DF_Glmast_HasSub]  DEFAULT ((0)),
	[Status] [nchar](1) NULL,
	[Co_cd] [nchar](1) NOT NULL,
	[AcCode] [nvarchar](15) NULL,
	[IT_file] [nvarchar](25) NULL,
	[RC_no] [nvarchar](20) NULL,
	[VAT_no] [nvarchar](15) NULL,
	[ECC_no] [nvarchar](50) NULL,
	[Addr] [nvarchar](500) NULL,
	[ph_no] [nvarchar](50) NULL,
	[bill_addr] [nvarchar](500) NULL,
	[ref_no] [nchar](10) NULL,
	[Encl] [nvarchar](50) NULL,
	[attn] [nvarchar](50) NULL,
	[kattn] [nvarchar](50) NULL,
	[dest_id] [int] NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Glmast] PRIMARY KEY CLUSTERED 
(
	[Gl_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubGL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubGL](
	[sg_id] [int] IDENTITY(1,1) NOT NULL,
	[gl_id] [int] NOT NULL,
	[sub_id] [int] NOT NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_tblSubGL] PRIMARY KEY CLUSTERED 
(
	[sg_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpSubGl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OpSubGl](
	[Osg_id] [int] IDENTITY(1,1) NOT NULL,
	[Sub_id] [int] NULL,
	[AcYr] [nchar](2) NOT NULL,
	[Balance] [decimal](18, 2) NULL,
	[LyBal] [decimal](18, 2) NULL,
	[Co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_OpSubGl] PRIMARY KEY CLUSTERED 
(
	[Osg_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bill]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bill](
	[Bill_id] [int] IDENTITY(1,1) NOT NULL,
	[Bill_no] [nvarchar](15) NULL,
	[Bill_dt] [datetime] NULL,
	[Bill_Type] [nchar](1) NULL,
	[Gl_id] [int] NULL,
	[iac_id] [int] NULL,
	[nontaxbl] [decimal](18, 2) NULL,
	[taxbl] [decimal](18, 2) NULL,
	[lessfrt] [decimal](18, 2) NULL,
	[freight] [decimal](18, 2) NULL,
	[detention] [decimal](18, 2) NULL,
	[OthName] [varchar](50) NULL,
	[OthChgs] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[st_id] [int] NULL,
	[ServPc] [decimal](18, 2) NULL,
	[servtax] [decimal](18, 2) NULL,
	[postage] [decimal](18, 2) NULL,
	[roundoff] [decimal](18, 2) NULL,
	[amount] [decimal](18, 2) NULL,
	[ref] [nvarchar](100) NULL,
	[lodloc] [nvarchar](20) NULL,
	[rep_id] [int] NULL,
	[co_cd] [nchar](1) NULL,
	[yr_cd] [nchar](2) NULL,
	[branch] [nchar](3) NULL CONSTRAINT [DF_Bill_branch]  DEFAULT ('KOL'),
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Bill_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpGl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OpGl](
	[Og_id] [int] IDENTITY(1,1) NOT NULL,
	[Gl_id] [int] NULL,
	[AcYr] [nchar](2) NOT NULL,
	[Balance] [decimal](18, 2) NULL,
	[LyBal] [decimal](18, 2) NULL,
	[Co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_OpGl] PRIMARY KEY CLUSTERED 
(
	[Og_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Receipts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Receipts](
	[rc_id] [int] IDENTITY(1,1) NOT NULL,
	[branch] [nchar](3) NULL,
	[rc_No] [nvarchar](10) NULL,
	[rc_Date] [datetime] NULL,
	[rc_type] [nchar](1) NULL,
	[gl_id] [int] NULL,
	[pay_by] [nchar](1) NULL,
	[amount] [decimal](18, 2) NULL,
	[cheque] [nvarchar](50) NULL,
	[tds_amt] [decimal](18, 2) NULL,
	[bank_id] [int] NULL,
	[ac_id] [int] NULL,
	[co_cd] [nchar](1) NULL,
	[uid] [nchar](1) NULL,
	[edate] [datetime] NULL,
	[upuids] [nvarchar](10) NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[rc_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLBill]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TLBill](
	[tlb_id] [int] IDENTITY(1,1) NOT NULL,
	[fb_no] [nvarchar](12) NULL,
	[fb_date] [datetime] NULL,
	[owner_id] [int] NULL,
	[tl_id] [int] NULL,
	[amount] [decimal](18, 2) NULL,
	[p_amount] [decimal](18, 2) NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_TLBill] PRIMARY KEY CLUSTERED 
(
	[tlb_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLTexp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TLTexp](
	[te_id] [int] IDENTITY(1,1) NOT NULL,
	[expCode] [nchar](1) NULL,
	[expName] [nvarchar](50) NULL,
	[gl_id] [int] NULL,
	[co_cd] [nchar](1) NULL,
 CONSTRAINT [PK_TLTexp] PRIMARY KEY CLUSTERED 
(
	[te_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLbyNoPart]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 13,2013
-- Description:	Search T/L from start of Number
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTLbyNoPart]
	@TL_No				NVARCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT TL_No,TL_id,TL_code,Own,Bilown,owner_id,driver_id,start_date,end_date 
		FROM TLmast
		WHERE TL_No LIKE @TL_No+''%''
		ORDER BY TL_No,start_date desc

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateVouch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 31,2011
-- Description:	Inserts or updates a voucher
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateVouch]
	@Ac_id			INT = NULL,
	@Vo_No			VARCHAR(15),
	@Vo_Dt			DATETIME,
	@Vo_Type		CHAR(1),
	@Cheque_No		CHAR(10),
	@bank_dt		DATETIME=NULL,
	@Amount			DECIMAL,
	@CO_CD			NCHAR(1),
	@branch			NCHAR(3),
	@Yr_Cd			NCHAR(2),
	@Ref_id			INT=NULL,
	@Narr			VARCHAR(4000),
	@Dtls			VARCHAR(4000),
	@SubDtls		VARCHAR(4000),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @VI	 INT
		DECLARE @VDI INT
		DECLARE @TTI INT
		DECLARE @Cnt INT
		DECLARE @CnS INT
		DECLARE @I   INT
		DECLARE @J   INT
		DECLARE @GLI INT
		DECLARE @SBI INT
		DECLARE @TLI INT
		DECLARE @BLI INT
		DECLARE @AMT DECIMAL(18,2)
		DECLARE @SAM DECIMAL(18,2)
		DECLARE @DTY NCHAR(1)
		SET @ErrMsg = ''''

		BEGIN TRANSACTION
			IF ISNULL(@Ac_id,0) = 0
			BEGIN

				INSERT INTO AcMast(Vo_No, Vo_Dt, Type, Chq_No, bank_dt, Amount, 
					Narr, co_cd, branch, yr_cd, ref_id)
				VALUES(@Vo_No, @Vo_Dt, @Vo_Type, @Cheque_No, @bank_dt, @Amount, 
					@Narr, @CO_CD, @branch, @yr_cd, @Ref_id)

				SET @Return = SCOPE_IDENTITY()
				SET @VI=@Return

				IF (SELECT COUNT(*) FROM AcSubDtl 
					WHERE Ac_did IN (SELECT Ac_did FROM AcDtl WHERE Ac_id=@VI))>0
					DELETE FROM AcSubDtl WHERE Ac_did IN (SELECT Ac_did FROM AcDtl WHERE Ac_id=@VI)
				IF (SELECT COUNT(*) FROM AcDtl WHERE Ac_id=@VI)>0
					DELETE FROM AcDtl WHERE Ac_id=@VI
				SET @Cnt=LEN(@Dtls)/30
				SET @I=0
				SET @J=0
				WHILE @I<@Cnt 
				BEGIN
					SET @I=@I+1
					/* DID-ID-GL_ID-AMOUNT */
					/* char(6)+char(6)+char(6)+char(12) */
					SET @GLI=CONVERT(INT,SUBSTRING(@Dtls,13,6))
					SET @AMT=CONVERT(DECIMAL,SUBSTRING(@Dtls,19,12))
					SET @Dtls=SUBSTRING(@Dtls,31,LEN(@Dtls)-30)
					INSERT INTO AcDtl(Ac_Id, gl_id, amount) 
						VALUES(@VI, @GLI, @AMT)
					SET @VDI= SCOPE_IDENTITY()

					IF LEN(@SubDtls)>0
					BEGIN
						SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
						WHILE @J=@I
						BEGIN
							/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
							/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12)+char(1) */
							SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
							SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
							SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
							SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
							SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
							SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
							INSERT INTO AcSubDtl(Ac_did, Sub_Id, tl_id, bill_id, amount, dtype) 
								VALUES(@VDI, @SBI, @TLI, @BLI, @AMT, @DTY)

							SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
						END
					END
				END
			END
			ELSE
			BEGIN

				UPDATE AcMast
				SET Vo_No=@Vo_No, Vo_dt=@Vo_Dt, Type=@Vo_Type, Chq_No=@Cheque_No, 
				bank_dt=@bank_dt, Amount=@Amount, narr=@Narr, co_cd=@CO_CD, 
				branch=@branch, yr_cd=@Yr_cd, ref_id=@Ref_id
				WHERE Ac_id=@Ac_id

				SET @Return = @Ac_id
				SET @VI = @Ac_id

				SET @Cnt=LEN(@Dtls)/30
				SET @I=0
				SET @J=0
				WHILE @I<@Cnt
				BEGIN
					SET @I=@I+1
					/* DID-ID-GL_ID-AMOUNT */
					/* char(6)+char(6)+char(6)+char(12) */
					SET @VDI=CONVERT(INT,SUBSTRING(@Dtls,1,6))
					SET @GLI=CONVERT(INT,SUBSTRING(@Dtls,13,6))
					SET @AMT=CONVERT(DECIMAL,SUBSTRING(@Dtls,19,12))
					SET @Dtls=SUBSTRING(@Dtls,31,LEN(@Dtls)-30)
					IF (@VDI>0)
						UPDATE AcDtl SET Ac_Id=@VI, gl_id=@GLI, amount=@AMT 
						WHERE Ac_did=@VDI
					ELSE
					BEGIN
						IF (@VDI<0)
							DELETE FROM AcDtl WHERE Ac_did=ABS(@VDI)
						ELSE
						BEGIN
							INSERT INTO AcDtl(Ac_Id, gl_id, amount) 
								VALUES(@VI, @GLI, @AMT)
							SET @VDI= SCOPE_IDENTITY()
						END
					END

					IF LEN(@SubDtls)>0
					BEGIN
						SET @TTI=CONVERT(INT,SUBSTRING(@SubDtls,1,6))
						IF (@TTI<0)
							DELETE FROM AcSubDtl WHERE Sub_did=ABS(@TTI)
						ELSE
						BEGIN
							IF (@TTI>0)
							BEGIN
								SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
								WHILE @J=@VDI
								BEGIN
									/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
									/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12) */
									SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
									SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
									SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
									SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
									SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
									SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
									UPDATE AcSubDtl SET Ac_did=@VDI, Sub_Id=@SBI, tl_id=@TLI, 
										bill_id=@BLI, amount=@AMT, dtype=@DTY 
										WHERE Sub_did=@TTI

									SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
								END
							END
							ELSE
							BEGIN
								SET @J=CONVERT(INT,SUBSTRING(@SubDtls,7,6))
								IF (@J<0)
								BEGIN
									SET @J=ABS(@J)
									WHILE @J=@I
									BEGIN
										/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
										/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12) */
										SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
										SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
										SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
										SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
										SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
										SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
										INSERT INTO AcSubDtl(Ac_did, Sub_Id, tl_id, bill_id, amount, dtype) 
											VALUES(@VDI, @SBI, @TLI, @BLI, @AMT, @DTY)

										SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
									END
								END
							END
						END
					END
				END
			END	

		COMMIT TRANSACTION				

		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteVouch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Voucher
-- =============================================
create PROCEDURE [dbo].[s_DeleteVouch]
	@Ac_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM AcSubDtl
		WHERE Ac_did in (SELECT Ac_Did FROM AcDtl WHERE Ac_id=@Ac_id)
		DELETE FROM AcDtl
		WHERE Ac_id=@Ac_id
		DELETE FROM AcMast
		WHERE Ac_id=@Ac_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteTLTexp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a T/L exp
-- =============================================
create PROCEDURE [dbo].[s_DeleteTLTexp]
	@te_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM TLTexp
		WHERE te_id=@te_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetNewTLexpCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 27,2011
-- Description:	TL exp new code - incomplete
-- =============================================
Create PROCEDURE [dbo].[s_GetNewTLexpCode]
	@GL_id			INT,
	@Return         CHAR(1) OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Ty as CHAR(1)
		SET @ErrMsg = ''''

		SELECT @Ty=CASE expcode 
					WHEN ''0'' THEN ''I''
					WHEN ''C'' THEN ''X''
					WHEN ''D'' THEN ''X''
					ELSE    ''O''
					END
		FROM TLTexp
		WHERE GL_id=@GL_id

		SET @Return=@Ty
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_NewTLexpCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 30,2011
-- Description:	TL exp-CREATE NEW CODE
-- =============================================
CREATE PROCEDURE [dbo].[s_NewTLexpCode]
	@Return         CHAR(1) OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Ty as CHAR(1)
		DECLARE @xTy as CHAR(1)
		DECLARE @nTy as CHAR(1)
		SET @ErrMsg = ''''

		SELECT @xTy=max(expcode)
		FROM TLTexp
		SELECT @Ty=max(expcode)
		FROM TLTexp
		WHERE expcode<''C'' or expcode>''D''

		IF @xTy>@Ty
			SET @nTy=@xTy
		ELSE
			SET @nTy=@Ty

		/*SET @nTy=CONVERT(CHAR(1),ASC(@nTy)+1)*/
		SET @Return=@nTy
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTLexpDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Details of a T/L exp
-- =============================================
create PROCEDURE [dbo].[s_GetTLexpDetails]
	@Te_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT ExpCode,ExpName,gl_id
		FROM TLtexp
		WHERE Te_id=@Te_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateTLexp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jun 11,2011
-- Description:	Inserts or updates a T/L exp
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateTLexp]
	@te_id			INT = NULL,
	@ExpCode		NCHAR(1),
	@ExpName		NVARCHAR(50),
	@gl_id			INT,
	@CO_CD			NCHAR(1),
	@Return			INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@te_id,0) = 0
			BEGIN

				INSERT INTO TLTexp(ExpCode,ExpName,gl_id,co_cd)
				VALUES(@ExpCode,@ExpName,@gl_id,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE TLTexp
				SET ExpCode=@ExpCode, ExpName=@ExpName, gl_id=@gl_id, 
				co_cd=@CO_CD
				WHERE te_id=@te_id

				SET @Return = @te_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateTLexp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jun 27,2011
-- Description:	Duplicate name check -TL exp
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateTLexp]
	@TE_id			INT = NULL,
	@ExpName		NVARCHAR(50),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM TLTexp
		WHERE upper(ExpName)=upper(@ExpName) and TE_id<>@TE_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkTLexpType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 27,2011
-- Description:	TL exp-check type
-- =============================================
CREATE PROCEDURE [dbo].[s_ChkTLexpType]
	@GL_id			INT,
	@Return         CHAR(1) OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Ty as CHAR(1)
		SET @ErrMsg = ''''

		SELECT @Ty=CASE expcode 
					WHEN ''0'' THEN ''I''
					WHEN ''C'' THEN ''X''
					WHEN ''D'' THEN ''X''
					ELSE    ''O''
					END
		FROM TLTexp
		WHERE GL_id=@GL_id

		SET @Return=@Ty
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetFavs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jun 28, 2010
-- Description:	Gets favourite options for company,user
-- =============================================
CREATE PROCEDURE [dbo].[s_GetFavs] 
	@CO_CD		CHAR(1),
	@USR_ID		INTEGER,
	@Categ		CHAR(1),
	@IsAll		BIT,
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY

	IF @IsAll = 1
	BEGIN
		IF @Categ = ''A''
		BEGIN
			SELECT	f.uf_id,f.uobj_id,o.uoname,f.inFav
			FROM	(uobj o INNER JOIN usrFav f ON o.uobj_id=f.uobj_id)
			WHERE	f.Co_Cd = @CO_CD and f.usr_id = @USR_ID
		END

		ELSE
		BEGIN
			SELECT	f.uf_id,f.uobj_id,o.uoname,f.inFav
			FROM	(uobj o INNER JOIN usrFav f ON o.uobj_id=f.uobj_id)
			WHERE	f.Co_Cd = @CO_CD and f.usr_id = @USR_ID AND o.uogrp=@Categ
		END
	END

	ELSE
	BEGIN
		IF @Categ = ''A''
		BEGIN
			SELECT	f.uf_id,f.uobj_id,o.uoname,f.inFav
			FROM	(uobj o INNER JOIN usrFav f ON o.uobj_id=f.uobj_id)
			WHERE	f.Co_Cd = @CO_CD and f.usr_id = @USR_ID AND f.inFav = 1
		END

		ELSE
		BEGIN
			SELECT	f.uf_id,f.uobj_id,o.uoname,f.inFav
			FROM	(uobj o INNER JOIN usrFav f ON o.uobj_id=f.uobj_id)
			WHERE	f.Co_Cd = @CO_CD and f.usr_id = @USR_ID AND f.inFav = 1 AND o.uogrp=@Categ
		END

	END
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read favourite details''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteCsge]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Consignee
-- =============================================
create PROCEDURE [dbo].[s_DeleteCsge]
	@Csge_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Consignee
		WHERE Csge_id=@Csge_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteRep]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Rep
-- =============================================
create PROCEDURE [dbo].[s_DeleteRep]
	@rep_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Rep
		WHERE rep_id=@rep_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetTarDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 3,2010
-- Description:	Details of a rate
-- =============================================
CREATE PROCEDURE [dbo].[s_GetTarDetails]
	@tar_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT t.tar_id,t.gl_id,t.csge_id,t.prod_id,t.ldpt_id,t.dest_id,t.bill_rate,hire_rate,
			shrt_rate,shrt_unit,othr_rate,othr_name,othr_unit,WEF,EFTO,Status,CO_CD,RouteKM
		FROM Tarset t 
		WHERE t.tar_id=@tar_id 

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteTar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Rate
-- =============================================
create PROCEDURE [dbo].[s_DeleteTar]
	@tar_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM TarSet
		WHERE tar_id=@tar_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetRateFList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Aug 23,2010
-- Description:	Gets list of Challan Rates (all party)
-- =============================================
CREATE PROCEDURE [dbo].[s_GetRateFList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT t.tar_id,g.AcName as Party,c.csge_code as Consignee,i.product,l.pl_name as LoadPt,d.pl_name as Dest,
	t.bill_rate,convert(varchar(20),t.wef,106) as WEF,convert(varchar(20),t.efto,106) as UpTo
  FROM (((((Tarset t INNER JOIN GlMast g ON t.gl_id = g.gl_id)
  INNER JOIN Consignee c ON t.csge_id = c.csge_id)
  INNER JOIN Place l ON t.ldpt_id = l.pl_id)
  INNER JOIN Place d ON t.dest_id = d.pl_id)
  INNER JOIN Product i ON t.prod_id = i.prod_id)
  WHERE t.co_cd=@CO_CD 
  ORDER BY c.csge_code,i.product,l.pl_name,t.wef

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Rate list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateTar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 28,2010
-- Description:	Inserts or updates a rate
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateTar]
	@Tar_id 			INT = NULL,
	@Gl_id				INT,
	@csge_id			INT,
	@prod_id			INT,
	@ldpt_id			INT,
	@dest_id			INT,
	@bill_rate			DECIMAL(18,2),
	@hire_rate			DECIMAL(18,2),
	@shrt_rate			DECIMAL(18,2),
	@shrt_unit			NCHAR(3),
	@othr_rate			DECIMAL(18,2),
	@othr_name			NVARCHAR(30),
	@othr_unit			NCHAR(1),
	@WEF				DATETIME,
	@EFTO				DATETIME=NULL,
	@Status				NCHAR(1),
	@CO_CD				NCHAR(1),
	@RouteKM			INT,
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@tar_id,0) = 0
			BEGIN

				INSERT INTO Tarset(Gl_id,csge_id,prod_id,ldpt_id,dest_id,
					bill_rate,hire_rate,shrt_rate,shrt_unit,othr_rate,othr_name,
					othr_unit,WEF,EFTO,Status,CO_CD,RouteKM)
				VALUES(@Gl_id,@csge_id,@prod_id,@ldpt_id,@dest_id,
					@bill_rate,@hire_rate,@shrt_rate,@shrt_unit,@othr_rate,@othr_name,
					@othr_unit,@WEF,@EFTO,@Status,@CO_CD,@RouteKM)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Tarset
				SET Gl_id=@Gl_id, csge_id=@csge_id, prod_id=@prod_id,ldpt_id=@ldpt_id,
					dest_id=@dest_id,  bill_rate=@bill_rate,hire_rate=@hire_rate,
					shrt_rate=@shrt_rate, shrt_unit=@shrt_unit, othr_rate=@othr_rate,
					othr_name=@othr_name, othr_unit=@othr_unit, wef=@WEF, efto=@EFTO,
					status=@Status, co_cd=@CO_CD, routekm=@RouteKM
				WHERE tar_id=@tar_id

				SET @Return = @tar_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteHFBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Deletes a hire freight bill
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteHFBill]
	@fb_id			INT = NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM TLBill
		WHERE tlb_id=@fb_id

		UPDATE Challans set hfbill_id=0 where hfbill_id=@fb_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetMaxHFBillNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Feb 25,2013
-- Description:	Gets last no.of H/F bills 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetMaxHFBillNo]
	@CO_CD			CHAR(1),
	@sDate			DATETIME,
	@eDate			DATETIME,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT  max(b.fb_no) as Bill_No
			FROM TLBill b 
			WHERE b.co_cd=@CO_CD and b.fb_date>=@sDate and  b.fb_date<=@eDate

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Bill list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateHFBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Feb 25,2013
-- Description:	Insert/update H/F bill
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateHFBill]
	@fb_id			INT = NULL,
	@fb_no			NVARCHAR(12),
	@fb_Date		DATETIME,
	@owner_id		INT=0,
	@TL_id			INT=0,
	@Amount			DECIMAL(18,2),
	@p_amount		DECIMAL(18,2),
	@CO_CD			CHAR(1),
	@ttDtls			NVARCHAR(1000),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
		DECLARE @VI	 INT
		DECLARE @Cnt INT
		DECLARE @I   INT
		DECLARE @GLI INT

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@fb_id,0) = 0
			BEGIN

				INSERT INTO TLBill(fb_no, fb_Date, owner_id, TL_id, amount, p_amount, co_cd)
				VALUES(@fb_no, @fb_Date, @owner_id, @TL_id, @amount, @p_amount, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
				SET @VI = @Return
			END
			ELSE
			BEGIN

				UPDATE TLBill
				SET fb_no=@fb_no, fb_Date=@fb_Date, owner_id=@owner_id,
				TL_id=@TL_id, amount=@amount, p_amount=@p_amount, co_cd=@CO_CD
				WHERE tlb_id=@fb_id

				SET @Return = @fb_id
				SET @VI = @fb_id
			END	
			IF (SELECT COUNT(*) FROM TLTrn WHERE tlb_id=@VI)>0
			BEGIN
				UPDATE TLTrn set tlb_id=0 WHERE tlb_id=@VI
			END
			SET @Cnt=LEN(@ttDtls)/10
			SET @I=0
			WHILE @I<@Cnt 
			BEGIN
				SET @I=@I+1
				/* tt_id */
				/* char(10) */
				SET @GLI=CONVERT(INT,SUBSTRING(@ttDtls,1,10))
				SET @ttDtls=SUBSTRING(@ttDtls,11,LEN(@ttDtls)-10)
				UPDATE TLTrn set tlb_id=@VI WHERE tt_id=@GLI
			END

		COMMIT TRANSACTION				
	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--''Can not read Bill list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateCsgr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 11,2009
-- Description:	Inserts or updates a Consignor
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateCsgr]
	@csgr_id			INT = NULL,
	@cs_code			NCHAR(10),
	@cs_name			NVARCHAR(30),
	@ldpt_id			INT,
	@yrOpen				NCHAR(5),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@csgr_id,0) = 0
			BEGIN

				INSERT INTO Consignor(cs_code,cs_name,ldpt_id,yrOpen,co_cd)
				VALUES(@cs_code,@cs_name,@ldpt_id,@yrOpen,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Consignor
				SET cs_code=@cs_code, cs_name=@cs_name, ldpt_id=@ldpt_id, 
				yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE csgr_id=@csgr_id

				SET @Return = @csgr_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateCsgrName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -Csge
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateCsgrName]
	@Csgr_id		INT = NULL,
	@CName			NVARCHAR(30),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM Consignor
		WHERE upper(Cs_Name)=upper(@CName) and Csgr_id<>@Csgr_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateCsgrCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 27,2011
-- Description:	Duplicate name check -Csgr code
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateCsgrCode]
	@Csgr_id		INT = NULL,
	@CCode			NVARCHAR(10),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM Consignor
		WHERE upper(Cs_Code)=upper(@CCode) and Csgr_id<>@Csgr_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCsgrList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 11,2009
-- Description:	Gets list of Csgrs
-- =============================================
CREATE PROCEDURE [dbo].[s_GetCsgrList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT c.csgr_id,c.cs_name as Name,c.cs_code as Code,c.ldpt_id,c.YrOpen,p.pl_name as Loading
  FROM Consignor c INNER JOIN Place p ON c.ldpt_id = p.pl_id
  WHERE c.co_cd=@CO_CD
  ORDER BY c.cs_name,p.pl_name

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Consignor list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetCsgrDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 11,2009
-- Description:	Details of a consignor
-- =============================================
create PROCEDURE [dbo].[s_GetCsgrDetails]
	@csgr_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT cs_code,cs_name,ldpt_id,yrOpen 
		FROM Consignor
		WHERE csgr_id=@csgr_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteCsgr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Consignor
-- =============================================
create PROCEDURE [dbo].[s_DeleteCsgr]
	@Csgr_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Consignor
		WHERE Csgr_id=@Csgr_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateULog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Jul 7,2010
-- Description:	update user log
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateULog]
	@CO_CD		CHAR(1),
	@USR_ID		INT,
	@UOBJ_ID	INT,
	@Stt		BIT,
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @ULid	INT
	DECLARE @lSt	BIT
	DECLARE @lUObj	INT
	DECLARE @lTm	DATETIME

	SELECT TOP 1 @ULid=ul_id,@lSt=lState,@lUObj=uobj_id,@lTm=lTime 
		from ulog WHERE usr_id=@USR_ID ORDER BY lTime DESC

	BEGIN TRANSACTION
	IF @lUObj is NULL
		BEGIN
		INSERT INTO ULog(co_cd,usr_id,uobj_id,lState) 
			VALUES(@CO_CD,@USR_ID,@UOBJ_ID,@Stt)
		END
	ELSE
		BEGIN
		IF @lSt=1 OR @UOBJ_ID<>@lUObj OR datediff(ss,@lTm,getdate())>60
			BEGIN
			INSERT INTO ULog(co_cd,usr_id,uobj_id,lState) 
				VALUES(@CO_CD,@USR_ID,@UOBJ_ID,@Stt)
			END
		ELSE
			BEGIN
			UPDATE ULog set lTime=getdate() where ul_id=@ULid
			END
		END
	COMMIT TRANSACTION				
	
	RETURN

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @ErrMsg = ''Can not write user log''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateGL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jan 3,2010
-- Description:	Inserts or updates a a/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateGL]
	@GL_id			INT = NULL,
	@AcName			NVARCHAR(40),
	@Grp_id			INT,
	@yrOpen			NCHAR(5),
	@OpBal			DECIMAL(18, 2),
	@LyBal			DECIMAL(18, 2),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@AcCode			NVARCHAR(15),
	@IT_File		NVARCHAR(25),
	@RC_No			NVARCHAR(20),
	@VAT_No			NVARCHAR(15),
	@ECC_No			NVARCHAR(50),
	@Addr			NVARCHAR(500),
	@bill_addr		NVARCHAR(500),
	@Ref_No			NVARCHAR(10),
	@Encl			NVARCHAR(50),
	@attn			NVARCHAR(50),
	@kattn			NVARCHAR(50),
	@ph_no			NVARCHAR(30),
	@HasSub			BIT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AcYr NCHAR(2)
		DECLARE @OG_id	INT
		SET @ErrMsg = ''''
		SET @AcYr=substring(@yrOpen,1,2)

		BEGIN TRANSACTION
			IF ISNULL(@GL_id,0) = 0
			BEGIN

				INSERT INTO Glmast(AcName,Grp_id,yrOpen,opbal,lybal,status,co_cd,
					AcCode,IT_File,RC_No,VAT_No,ECC_No,Addr,bill_addr,Ref_No,Encl,
					attn,kattn,ph_no,HasSub)
				VALUES(@AcName,@Grp_id,@yrOpen,@opbal,@lybal,@status,@CO_CD,
					@AcCode,@IT_File,@RC_No,@VAT_No,@ECC_No,@Addr,@bill_addr,@Ref_No,@Encl,
					@attn,@kattn,@ph_no,@HasSub)

				SET @Return = SCOPE_IDENTITY()

				INSERT INTO OpGl(Gl_id,AcYr,Balance, Lybal,co_cd)
				VALUES(@Return, @AcYr, @opbal, @lybal, @CO_CD)
			END
			ELSE
			BEGIN

				UPDATE Glmast
				SET AcName=@AcName, Grp_id=@Grp_id, opbal=@opbal, lybal=@lybal, 
					status=@status, yrOpen=@yrOpen, co_cd=@CO_CD, AcCode=@AcCode,
					IT_File=@IT_File, RC_No=@RC_No, VAT_No=@VAT_No, ECC_No=@ECC_No,
					Addr=@Addr, bill_addr=@bill_addr, Ref_No=@Ref_No, Encl=@Encl,
					attn=@attn, kattn=@kattn, ph_no=@ph_no, HasSub=@HasSub
				WHERE gl_id=@Gl_id

				SET @Return = @Gl_id

				IF (SELECT COUNT(*) FROM OpGl WHERE Gl_id=@Gl_id AND AcYr=@AcYr)=0
					INSERT INTO OpGl(Gl_id,AcYr,Balance, Lybal,co_cd)
					VALUES(@Return, @AcYr, @opbal, @lybal, @CO_CD)
				ELSE
					UPDATE OpGl SET Balance=@opbal, lybal=@lybal
					WHERE Gl_id=@Gl_id AND AcYr=@AcYr
			END	

		COMMIT TRANSACTION				

		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteGL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes an A/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteGL]
	@GL_id			INT = NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM OpGl
		WHERE GL_id=@GL_id
		DELETE FROM SubGl
		WHERE GL_id=@GL_id
		DELETE FROM GLMast
		WHERE GL_id=@GL_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeletePlace]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a place
-- =============================================
create PROCEDURE [dbo].[s_DeletePlace]
	@pl_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Place
		WHERE pl_id=@pl_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetPlaceDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Details of a place
-- =============================================
CREATE PROCEDURE [dbo].[s_GetPlaceDetails]
	@Pl_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT pl_sht,pl_name,pl_type 
		FROM Place
		WHERE pl_id=@Pl_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateSGr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 18,2011
-- Description:	Inserts or updates a sub a/c group
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateSGr]
	@SGr_id			INT = NULL,
	@SGrName		NVARCHAR(30),
	@status			NCHAR(1),
	@yrOpen			NCHAR(5),
	@CO_CD			NCHAR(1),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@SGr_id,0) = 0
			BEGIN

				INSERT INTO SubGrmast(SGrName,yrOpen,status,co_cd)
				VALUES(@SGrName,@yrOpen,@status,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE SubGrmast
				SET SGrName=@SGrName, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE sgr_id=@SGr_id

				SET @Return = @SGr_id
			END	

		COMMIT TRANSACTION				

		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSubDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 30,2009
-- Description:	Details of a a/c sub head
-- =============================================
CREATE PROCEDURE [dbo].[s_GetSubDetails]
	@Sub_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT g.Sub_id, g.SubName, g.Sgr_id, g.subtype, g.yrOpen, 
		g.opBal, g.LyBal, g.status, g.co_cd, g.Accode, g.IT_file, 
		g.RC_No, g.VAT_No, g.Addr, g.ph_no, r.SGrName 
		FROM SubMast g INNER JOIN SubGrMast r ON g.sgr_id=r.sgr_id
		WHERE g.Sub_id=@Sub_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteSubGr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a SubGroup
-- =============================================
create PROCEDURE [dbo].[s_DeleteSubGr]
	@sgr_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM SubGrmast
		WHERE sgr_id=@sgr_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteSub]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes an A/c Sub head
-- =============================================
create PROCEDURE [dbo].[s_DeleteSub]
	@Sub_id			INT = NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM OpSubGl
		WHERE Sub_id=@Sub_id
		DELETE FROM SubGl
		WHERE Sub_id=@Sub_id
		DELETE FROM SubMast
		WHERE Sub_id=@Sub_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSubIDbyCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 18,2011
-- Description:	Details of a SubAccount from Code
-- =============================================
create PROCEDURE [dbo].[s_GetSubIDbyCode]
	@Accode				NCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT Sub_id
		FROM SubMast
		WHERE Accode=@Accode

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateSub]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 18,2011
-- Description:	Inserts or updates a sub a/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateSub]
	@Sub_id			INT = NULL,
	@SubName		NVARCHAR(40),
	@SGr_id			INT,
	@yrOpen			NCHAR(5),
	@OpBal			DECIMAL(18, 2),
	@LyBal			DECIMAL(18, 2),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@AcCode			NCHAR(4),
	@IT_File		NVARCHAR(25),
	@RC_No			NVARCHAR(20),
	@VAT_No			NVARCHAR(15),
	@Addr			NVARCHAR(500),
	@ph_no			NVARCHAR(30),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@Sub_id,0) = 0
			BEGIN

				INSERT INTO SubMast(SubName,SGr_id,yrOpen,opbal,lybal,status,co_cd,
					AcCode,IT_File,RC_No,VAT_No,Addr,ph_no,subtype)
				VALUES(@SubName,@SGr_id,@yrOpen,@opbal,@lybal,@status,@CO_CD,
					@AcCode,@IT_File,@RC_No,@VAT_No,@Addr,@ph_no,''G'')

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE SubMast
				SET SubName=@SubName, SGr_id=@SGr_id, opbal=@opbal, 
					lybal=@lybal, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD, AcCode=@AcCode,
					IT_File=@IT_File, RC_No=@RC_No, VAT_No=@VAT_No, Addr=@Addr, ph_no=@ph_no
				WHERE sub_id=@Sub_id

				SET @Return = @Sub_id
			END	

		COMMIT TRANSACTION				

		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateSubName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -sub
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateSubName]
	@Sub_id			INT = NULL,
	@SubName		NVARCHAR(40),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM SubMast
		WHERE upper(SubName)=upper(@SubName) and Sub_id<>@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateSubCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 27,2011
-- Description:	Duplicate code check -sub
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateSubCode]
	@Sub_id			INT = NULL,
	@SubCode		NCHAR(4),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM SubMast
		WHERE upper(Accode)=upper(@SubCode) and Sub_id<>@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetVoDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 21,2011
-- Description:	Gets A/c voucher details
-- =============================================
CREATE PROCEDURE [dbo].[s_GetVoDetails]
	@AC_ID			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT a.ac_id,a.vo_no, a.vo_dt, a.type, a.chq_no, a.bank_dt, a.amount, a.narr,
		a.co_cd, a.branch, a.uid, a.edate, a.upuids 
		FROM Acmast a 
		WHERE a.ac_id=@AC_ID

	SELECT b.ac_did, b.gl_id, ''DrCr''= CASE WHEN b.amount<0 THEN ''Cr'' ELSE ''Dr'' END,
		g.AcName AS Account, ''DrAmt''= CASE WHEN b.amount<0 THEN 0.00 ELSE abs(b.amount) END, 
		''CrAmt''= CASE WHEN b.amount<0 THEN abs(b.amount) ELSE 0.00 END,
		0.00 AS Balance, gr.grpcode, g.status
		FROM ((AcDtl b INNER JOIN GlMast g ON b.gl_id=g.gl_id)INNER JOIN GrpMast gr ON g.grp_id=gr.grp_id)
		WHERE b.ac_id=@AC_ID

	SELECT c.sub_did, c.ac_did, c.bill_id, b.bill_no, b.bill_dt, b.amount, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN bill b ON c.bill_id=b.bill_id)
		WHERE c.dtype=''B'' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	SELECT c.sub_did, c.ac_did, c.tl_id, t.tl_code, t.tl_no, '''' as TT, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN TlMast t ON c.tl_id=t.tl_id)
		WHERE c.dtype=''T'' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	SELECT c.sub_did, c.ac_did, c.sub_id, s.SubName, s.AcCode as SubCode, '''' as Su, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN SubMast s ON c.sub_id=s.sub_id)
		WHERE c.dtype=''S'' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read A/c voucher''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_ChkDuplicateGLSub]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -sub
-- =============================================
CREATE PROCEDURE [dbo].[s_ChkDuplicateGLSub]
	@GL_id			INT,
	@Sub_id			INT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''''

		SELECT @Cn=count(*) 
		FROM SubGL
		WHERE GL_id=@GL_id and Sub_id=@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetSTDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 11,2011
-- Description:	Details of a tax
-- =============================================
create PROCEDURE [dbo].[s_GetSTDetails]
	@Tax_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT *
		FROM STMast
		WHERE tax_id=@Tax_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateGrp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Jan 3,2011
-- Description:	Inserts or updates a a/c group
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateGrp]
	@Grp_id			INT = NULL,
	@GrpName		NVARCHAR(40),
	@GrpCode		NCHAR(4),
	@SchNo			NCHAR(4),
	@yrOpen			NCHAR(5),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@Grp_id,0) = 0
			BEGIN

				INSERT INTO Grpmast(GrpName,GrpCode,SchNo,yrOpen,status,co_cd)
				VALUES(@GrpName,@GrpCode,@SchNo,@yrOpen,@status,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Grpmast
				SET GrpName=@GrpName, GrpCode=@GrpCode,SchNo=@SchNo, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE grp_id=@Grp_id

				SET @Return = @Grp_id
			END	

		COMMIT TRANSACTION				

		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGLDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 30,2009
-- Description:	Details of a a/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_GetGLDetails]
	@GL_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT g.GL_id, g.AcName, g.grp_id, g.yrOpen, g.opBal, g.LyBal,g.HasSub, g.status, 
		g.co_cd, g.Accode, g.IT_file, g.RC_No, g.VAT_No, g.ECC_No, g.Addr, g.ph_no, 
		g.Bill_addr, g.ref_no, g.encl, g.attn, g.kattn, g.dest_id, r.GrpName 
		FROM GLmast g INNER JOIN GrpMast r ON g.grp_id=r.grp_id
		WHERE g.GL_id=@GL_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetOwnerList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 18,2009
-- Description:	Gets list of T/Ls
-- =============================================
create PROCEDURE [dbo].[s_GetOwnerList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT o.Gl_id,o.AcName,o.Grp_id,o.yrOpen,o.Addr,o.ph_no,
	o.IT_file,o.attn
	FROM (Glmast o INNER JOIN Grpmast g ON o.Grp_id=g.Grp_id)
	WHERE o.Grp_id=36 and o.Co_cd=@CO_CD
	ORDER BY AcName

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read T/L Owner list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetGLType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Apr 30,2011
-- Description:	Status & Grpcode Details of a a/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_GetGLType]
	@GL_id			INT,
	@Return			NCHAR(5)		OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT @Return=g.status + r.GrpCode
		FROM GLmast g INNER JOIN GrpMast r ON g.grp_id=r.grp_id
		WHERE g.GL_id=@GL_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteGrp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a A/c Group
-- =============================================
create PROCEDURE [dbo].[s_DeleteGrp]
	@grp_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Grpmast
		WHERE grp_id=@grp_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteProduct]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Product
-- =============================================
create PROCEDURE [dbo].[s_DeleteProduct]
	@prod_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Product
		WHERE prod_id=@prod_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetProductDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 21,2009
-- Description:	Details of a Product
-- =============================================
CREATE PROCEDURE [dbo].[s_GetProductDetails]
	@Prod_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT product,proddesc,yrOpen 
		FROM Product
		WHERE prod_id=@Prod_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateProduct]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 29,2009
-- Description:	Inserts or updates a product
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateProduct]
	@prod_id			INT = NULL,
	@product			NCHAR(6),
	@proddesc			NVARCHAR(40),
	@yrOpen				NCHAR(5),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@prod_id,0) = 0
			BEGIN

				INSERT INTO Product(product,proddesc,yrOpen,co_cd)
				VALUES(@product,@proddesc,@yrOpen,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Product
				SET product=@product, proddesc=@proddesc, 
				yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE prod_id=@prod_id

				SET @Return = @prod_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetProductList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G Ghosh
-- Create date: Nov 21,2009
-- Description:	Gets list of Products
-- =============================================
create PROCEDURE [dbo].[s_GetProductList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT prod_id,Product,proddesc as FullName
  FROM Product
  WHERE co_cd=@CO_CD
  ORDER BY proddesc

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Can not read Product list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteChal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Challan
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteChal]
	@Chal_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM ChalUnld
		WHERE Chal_id=@Chal_id
		DELETE FROM ChalDtn
		WHERE Chal_id=@Chal_id
		DELETE FROM Challan
		WHERE Chal_id=@Chal_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateTBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Inserts or updates a Transport bill
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateTBill]
	@bill_id			INT = NULL,
	@bill_no			NVARCHAR(15),
	@Bill_Dt			DATETIME,
	@Bill_Type			CHAR(1),
	@GL_ID				INT,
	@IAC_ID				INT,
	@freight			DECIMAL(18,2),
	@detention			DECIMAL(18,2),
	@OthName			NVARCHAR(50),
	@OthChgs			DECIMAL(18,2),
	@total				DECIMAL(18,2),
	@st_id				INT,
	@servpc				DECIMAL(18,2),
	@servtax			DECIMAL(18,2),
	@roundoff			DECIMAL(18,2),
	@Amount				DECIMAL(18,2),
	@ref				VARCHAR(100),
	@lodloc				VARCHAR(50),
	@branch				NCHAR(3),
	@CO_CD				NCHAR(1),
	@ChalDtls			NVARCHAR(1000),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @VI	 INT
		DECLARE @Cnt INT
		DECLARE @I   INT
		DECLARE @GLI INT

		SET @ErrMsg = ''''
		BEGIN TRANSACTION
			IF ISNULL(@bill_id,0) = 0
			BEGIN

				INSERT INTO Bill(bill_no, Bill_Dt, Bill_Type, Gl_id, IAC_ID, nontaxbl, taxbl, lessfrt,
					freight, detention, OthName, OthChgs, total, st_id, servpc,
					servtax, postage, roundoff, Amount, ref, lodloc,
					rep_id, branch, co_cd)
				VALUES(@bill_no, @Bill_Dt, @Bill_Type, @Gl_id, @IAC_ID, 0, 0, 0,
					@freight, @detention, @OthName, @OthChgs, @total, @st_id, @servpc,
					@servtax, 0, @roundoff, @Amount, @ref, @lodloc,
					0, @branch, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
				SET @VI = @Return
			END
			ELSE
			BEGIN

				UPDATE Bill
				SET bill_no=@bill_no, Bill_Dt=@Bill_Dt, Bill_Type=@Bill_Type, Gl_id=@Gl_id,
				IAC_ID=@IAC_ID, freight=@freight, detention=@detention, OthName=@OthName, OthChgs=@OthChgs,
				total=@total, st_id=@st_id, servpc=@servpc,	servtax=@servtax, 
				roundoff=@roundoff, amount=@Amount, ref=@ref, lodloc=@lodloc,
				branch=@branch, co_cd=@CO_CD
				WHERE bill_id=@bill_id

				SET @Return = @bill_id
				SET @VI = @bill_id
			END	
			IF (SELECT COUNT(*) FROM Challans WHERE bill_id=@VI)>0
			BEGIN
				IF (@Bill_Type=''F'')
				UPDATE Challans set bill_id=0 WHERE bill_id=@VI
				IF (@Bill_Type=''S'')
				UPDATE Challans set suplbill_id=0 WHERE suplbill_id=@VI
				IF (@Bill_Type=''D'') 
				UPDATE Challans set dtnbill_id=0 WHERE dtnbill_id=@VI /* change */
			END
			SET @Cnt=LEN(@ChalDtls)/10
			SET @I=0
			WHILE @I<@Cnt 
			BEGIN
				SET @I=@I+1
				/* CHAL_ID */
				/* char(10) */
				SET @GLI=CONVERT(INT,SUBSTRING(@ChalDtls,1,10))
				SET @ChalDtls=SUBSTRING(@ChalDtls,11,LEN(@ChalDtls)-10)
				IF (@Bill_Type=''F'')
				UPDATE Challans set bill_id=@VI WHERE chal_id=@GLI
				IF (@Bill_Type=''S'')
				UPDATE Challans set suplbill_id=@VI WHERE chal_id=@GLI
				IF (@Bill_Type=''D'')
				UPDATE Challans set dtnbill_id=@VI WHERE chal_id=@GLI /* change */
			END

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteTBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Deletes a transport bill
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteTBill]
	@bill_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Bill
		WHERE bill_id=@bill_id

		UPDATE Challans set bill_id=0 where bill_id=@bill_id
		UPDATE Challans set suplbill_id=0 where suplbill_id=@bill_id
		UPDATE Challans set dtnbill_id=0 where dtnbill_id=@bill_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_DeleteBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a bill
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteBill]
	@bill_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		BEGIN TRANSACTION

		DELETE FROM Bill
		WHERE bill_id=@bill_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetBillIDbyNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 3,2011
-- Description:	ID of a Challan from Number
-- =============================================
CREATE PROCEDURE [dbo].[s_GetBillIDbyNo]
	@Number			NCHAR(15),
	@Co_cd			NCHAR(1),
	@Yr_cd			NCHAR(2),
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''

		SELECT Bill_id
		FROM Bill
		WHERE Bill_No=@Number and co_cd=@co_cd and yr_cd=@Yr_cd

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetBrns]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 17, 2009
-- Description:	Gets branches for company
-- =============================================
create PROCEDURE [dbo].[s_GetBrns] 
	@CO_ID		CHAR(1),
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT	br_id,br_code,br_name,yrOpen
	FROM	Branch
	WHERE	Co_Cd = @CO_ID
	
	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ''Could not read branch list''
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetChalDtnDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 20,2009
-- Description:	Details of a challan detention
-- =============================================
CREATE PROCEDURE [dbo].[s_GetChalDtnDetails]
	@chal_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		SELECT dtn_id, pre_dtn, rep_time, rel_time, dtn_days, dtn_rate, dtn_amt, 
		mkt_days, mkt_rate, mkt_amt
		FROM ChallDtn
		WHERE chal_id=@chal_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_InsertUpdateChal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 10,2009
-- Description:	Inserts or updates a challan
--        CHECK UPDATE PART
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateChal]
	@chal_id		INT = NULL,
	@branch			NCHAR(3),
	@tl_id			INT,
	@Chal_no		NVARCHAR(15),
	@Chal_dt		DATETIME,
	@CN_no			NVARCHAR(15),
	@Csgr_id		INT,
	@ldpt_id		INT,
	@Gl_id			INT,
	@Csge_id		INT,
	@dest_id		INT,
	@trip_days		SMALLINT,
	@driv_id		INT,
	@prod_id		INT,
	@qty			DECIMAL(18, 2),
	@unit			NCHAR(2),
	@rate			DECIMAL(18, 2),
	@per			NCHAR(2),
	@amount			DECIMAL(18, 2),
	@hire_frgt		DECIMAL(18, 2),
	@CO_CD			NCHAR(1),
	@Yr_Cd			NCHAR(2),
	@AcEffctB4dlv	BIT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''''
		DECLARE @VI	INT
		DECLARE @VDI INT
		DECLARE @LVD INT
		DECLARE @Cnt INT
		DECLARE @Cy INT
		DECLARE @CnS INT
		DECLARE @Cz INT
		DECLARE @TTI INT
		DECLARE @LTT INT
		DECLARE @Own BIT
		DECLARE @Sht DECIMAL(18,2)
		DECLARE @Dtls varchar(4000)
		DECLARE @SubDtls varchar(4000)

		BEGIN TRANSACTION
		IF ISNULL(@chal_id,0) = 0
		BEGIN

			INSERT INTO Challan(branch, tl_id, chal_no, chal_dt, cn_no, csgr_id, ldpt_id, Gl_id,
				csge_id, dest_id, trip_days, driv_id, prod_id, qty, unit, rate, per,
				amount, hire_frgt, co_cd, yr_cd, status)
			VALUES(@branch, @tl_id, @chal_no, @chal_dt, @cn_no, @csgr_id, @ldpt_id, @Gl_id,
				@csge_id, @dest_id, @trip_days, @driv_id, @prod_id, @qty, @unit, @rate,
				@per, @amount, @hire_frgt, @CO_CD, @Yr_Cd,'''')

			SET @Return = SCOPE_IDENTITY()

			SELECT @Own=OWN FROM TLMAST WHERE TL_ID=@tl_id
			IF @Own=0
			BEGIN
				INSERT INTO Tltrn(tl_id, trn_code, trn_date, amount, vo_id, co_cd)
				VALUES(@tl_id, ''0'', @chal_dt, @hire_frgt, @return, @co_cd)
			END
			ELSE
			BEGIN
				INSERT INTO Tltrn(tl_id, trn_code, trn_date, amount, vo_id, co_cd)
				VALUES(@tl_id, ''0'', @chal_dt, @amount, @return, @co_cd)
			END

			IF @AcEffctB4dlv=1 
			BEGIN
				SET @Dtls=''''
				SET @SubDtls=''''
				IF @Own=0
				BEGIN
					SET @Sht=0		/* DID-ID-GL_ID-AMOUNT */
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),11)+CONVERT(char(12),@hire_frgt-@Sht)
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),12)+CONVERT(char(12),-@hire_frgt+@Sht)
									/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
					SET @SubDtls=@SubDtls+CONVERT(char(6),0)+CONVERT(char(6),-2)+CONVERT(char(6),0)+CONVERT(char(6),@tl_id)+CONVERT(char(6),0)+CONVERT(char(12),-@hire_frgt+@Sht)+''T''
					EXEC s_InsertUpdateVouch 0, @chal_no, @chal_dt, ''H'', '''', NULL, @hire_frgt, @CO_CD, 
						@branch, @yr_cd, @Return, ''Payment due against trip.'', @Dtls, @SubDtls, @VI, @ErrMsg
				END
				ELSE
				BEGIN
					SET @Sht=0
				END
			END
		END
		ELSE
		BEGIN

			UPDATE Challan
			SET branch=@branch, tl_id=@tl_id, chal_no=@chal_no, chal_dt=@chal_dt, cn_no=@CN_no, 
				csgr_id=@csgr_id, ldpt_id=@ldpt_id, Gl_id=@Gl_id, csge_id=@csge_id, 
				dest_id=@dest_id, trip_days=@trip_days, driv_id=@driv_id, prod_id=@prod_id, 
				qty=@qty, unit=@unit, rate=@rate, per=@per, amount=@amount, hire_frgt=@hire_frgt,
				co_cd=@CO_CD, yr_cd=@Yr_Cd 
			WHERE chal_id=@chal_id

			SET @Return = @chal_id

			SELECT @Own=OWN FROM TLMAST WHERE TL_ID=@tl_id

			SELECT @Sht=sht_amt from ChalUnld where chal_id=@chal_id
			SET @Sht=ISNULL(@Sht,0)

			SELECT @TTI=tt_id FROM Tltrn WHERE vo_id=@chal_id and trn_code=''C''
			SET @TTI=ISNULL(@TTI,0)

			IF @Own=0
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@hire_frgt
				WHERE vo_id=@chal_id and trn_code=''0''
			END
			ELSE
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@amount
				WHERE vo_id=@chal_id and trn_code=''0''
			END
			IF @TTI=0
			BEGIN
				INSERT INTO Tltrn(vo_id, tl_id, trn_date, trn_code, amount)
				VALUES(@chal_id, @tl_id, @chal_dt, ''C'', @Sht)
			END
			ELSE
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@Sht
				WHERE tt_id=@TTI
			END

			IF @AcEffctB4dlv=1 
			BEGIN
				SET @Dtls=''''
				SET @SubDtls=''''
				SELECT @VI=Ac_id from AcMast where ref_id=@chal_id
				SET @VI=ISNULL(@VI,0)
				IF (@VI>0)
				BEGIN
					SELECT @Cnt=COUNT(*) FROM AcDtl WHERE Ac_Id=@VI
					SET @VDI=0
					SET @LVD=0
					IF (@Cnt<2)
						SET @Cnt=2
					SET @Cy=0
					WHILE (@Cy < @Cnt)
					BEGIN
						SELECT TOP 1 @VDI=AC_DID FROM AcDtl WHERE Ac_Id=@VI AND Ac_did>@LVD ORDER BY AC_DID
						SET @VDI=ISNULL(@VDI,0)
						IF @VDI>@LVD
							SET @LVD=@VDI
						SET @Cy=@Cy+1
						IF (@Cy=1)		/* DID-ID-GL_ID-AMOUNT */
							SET @Dtls=@Dtls+CONVERT(char(6),@VDI)+CONVERT(char(6),@VI)+CONVERT(char(6),11)+CONVERT(char(12),@hire_frgt-@Sht)
						ELSE
						IF (@Cy=2)
						BEGIN
							SET @Dtls=@Dtls+CONVERT(char(6),@VDI)+CONVERT(char(6),@VI)+CONVERT(char(6),12)+CONVERT(char(12),-@hire_frgt+@Sht)
							SELECT @CnS=COUNT(*) FROM AcSubDtl WHERE Ac_did=@VDI
							SET @TTI=0
							SET @LTT=0
							SET @Cz=0
							WHILE (@Cz < @CnS)
							BEGIN
								SELECT TOP 1 @TTI=SUB_DID FROM AcSubDtl WHERE Ac_did=@VDI AND sub_did>@LTT ORDER BY SUB_DID
								SET @TTI=ISNULL(@TTI,0)
								IF @TTI>@LTT
									SET @LTT=@TTI
								IF (@Cz=1)	/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
									SET @SubDtls=@SubDtls+CONVERT(char(6),@TTI)+CONVERT(char(6),@VDI)+CONVERT(char(6),0)+CONVERT(char(6),@tl_id)+CONVERT(char(6),0)+CONVERT(char(12),-@hire_frgt+@Sht)
								ELSE
									SET @SubDtls=@SubDtls+CONVERT(char(6),-@TTI)+CONVERT(char(6),@VDI)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(12),0)
								SET @Cz=@Cz+1
							END
						END
						ELSE
						BEGIN
							SET @Dtls=@Dtls+CONVERT(char(6),-@VDI)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(12),0)
						END
					END
				END
				EXEC s_InsertUpdateVouch @VI, @chal_no, @chal_dt, ''H'', '''', NULL, @hire_frgt, @CO_CD, 
					@branch, @yr_cd, @chal_id, ''Payment due against trip.'', @Dtls, @SubDtls, @VI, @ErrMsg
			END
		END	

		COMMIT TRANSACTION

		RETURN

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_GetDriverDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		G.Ghosh
-- Create date: May 30,2011
-- Description:	Details of a Driver
-- =============================================
CREATE PROCEDURE [dbo].[s_GetDriverDetails]
	@Sub_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''''

		exec s_GetSubDetails @Sub_id, @ErrMsg

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcSubDtl_AcDtl]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcSubDtl]'))
ALTER TABLE [dbo].[AcSubDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcSubDtl_AcDtl] FOREIGN KEY([ac_did])
REFERENCES [dbo].[AcDtl] ([ac_did])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcSubDtl_Bill]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcSubDtl]'))
ALTER TABLE [dbo].[AcSubDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcSubDtl_Bill] FOREIGN KEY([bill_id])
REFERENCES [dbo].[Bill] ([Bill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcSubDtl_SubMast]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcSubDtl]'))
ALTER TABLE [dbo].[AcSubDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcSubDtl_SubMast] FOREIGN KEY([sub_id])
REFERENCES [dbo].[SubMast] ([Sub_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcSubDtl_TLmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcSubDtl]'))
ALTER TABLE [dbo].[AcSubDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcSubDtl_TLmast] FOREIGN KEY([tl_id])
REFERENCES [dbo].[TLmast] ([TL_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TLTrn_TLmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[TLTrn]'))
ALTER TABLE [dbo].[TLTrn]  WITH CHECK ADD  CONSTRAINT [FK_TLTrn_TLmast] FOREIGN KEY([tl_id])
REFERENCES [dbo].[TLmast] ([TL_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Bill]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Bill] FOREIGN KEY([bill_id])
REFERENCES [dbo].[Bill] ([Bill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Bill1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Bill1] FOREIGN KEY([suplbill_id])
REFERENCES [dbo].[Bill] ([Bill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Bill2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Bill2] FOREIGN KEY([dtnbill_id])
REFERENCES [dbo].[Bill] ([Bill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_ChallDtn1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_ChallDtn1] FOREIGN KEY([dtn1_id])
REFERENCES [dbo].[ChallDtn] ([dtn_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_ChallDtn2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_ChallDtn2] FOREIGN KEY([dtn2_id])
REFERENCES [dbo].[ChallDtn] ([dtn_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Consignee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Consignee] FOREIGN KEY([csge_id])
REFERENCES [dbo].[Consignee] ([csge_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Consignor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Consignor] FOREIGN KEY([csgr_id])
REFERENCES [dbo].[Consignor] ([csgr_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Places1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Places1] FOREIGN KEY([ldpt_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_Places2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_Places2] FOREIGN KEY([dest_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Challan_TLmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Challan]'))
ALTER TABLE [dbo].[Challan]  WITH CHECK ADD  CONSTRAINT [FK_Challan_TLmast] FOREIGN KEY([tl_id])
REFERENCES [dbo].[TLmast] ([TL_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TLDates_TLmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[TLDates]'))
ALTER TABLE [dbo].[TLDates]  WITH CHECK ADD  CONSTRAINT [FK_TLDates_TLmast] FOREIGN KEY([tl_id])
REFERENCES [dbo].[TLmast] ([TL_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcDtl_Acmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcDtl]'))
ALTER TABLE [dbo].[AcDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcDtl_Acmast] FOREIGN KEY([ac_id])
REFERENCES [dbo].[Acmast] ([Ac_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AcDtl_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[AcDtl]'))
ALTER TABLE [dbo].[AcDtl]  WITH CHECK ADD  CONSTRAINT [FK_AcDtl_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecptDtl_Bill]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecptDtl]'))
ALTER TABLE [dbo].[RecptDtl]  WITH CHECK ADD  CONSTRAINT [FK_RecptDtl_Bill] FOREIGN KEY([Bill_id])
REFERENCES [dbo].[Bill] ([Bill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecptDtl_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecptDtl]'))
ALTER TABLE [dbo].[RecptDtl]  WITH CHECK ADD  CONSTRAINT [FK_RecptDtl_Receipts] FOREIGN KEY([Rc_id])
REFERENCES [dbo].[Receipts] ([rc_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ChalUnld_Challan]') AND parent_object_id = OBJECT_ID(N'[dbo].[ChalUnld]'))
ALTER TABLE [dbo].[ChalUnld]  WITH CHECK ADD  CONSTRAINT [FK_ChalUnld_Challan] FOREIGN KEY([chal_id])
REFERENCES [dbo].[Challan] ([chal_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ChallDtn_Challan]') AND parent_object_id = OBJECT_ID(N'[dbo].[ChallDtn]'))
ALTER TABLE [dbo].[ChallDtn]  WITH CHECK ADD  CONSTRAINT [FK_ChallDtn_Challan] FOREIGN KEY([chal_id])
REFERENCES [dbo].[Challan] ([chal_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ulog_uobj]') AND parent_object_id = OBJECT_ID(N'[dbo].[ulog]'))
ALTER TABLE [dbo].[ulog]  WITH CHECK ADD  CONSTRAINT [FK_ulog_uobj] FOREIGN KEY([uobj_id])
REFERENCES [dbo].[uobj] ([uobj_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usrFav_uobj]') AND parent_object_id = OBJECT_ID(N'[dbo].[usrFav]'))
ALTER TABLE [dbo].[usrFav]  WITH CHECK ADD  CONSTRAINT [FK_usrFav_uobj] FOREIGN KEY([uobj_id])
REFERENCES [dbo].[uobj] ([uobj_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usrperm_uobj]') AND parent_object_id = OBJECT_ID(N'[dbo].[usrperm]'))
ALTER TABLE [dbo].[usrperm]  WITH CHECK ADD  CONSTRAINT [FK_usrperm_uobj] FOREIGN KEY([uobj_id])
REFERENCES [dbo].[uobj] ([uobj_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tarset_Consignee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tarset]'))
ALTER TABLE [dbo].[Tarset]  WITH CHECK ADD  CONSTRAINT [FK_Tarset_Consignee] FOREIGN KEY([csge_id])
REFERENCES [dbo].[Consignee] ([csge_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tarset_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tarset]'))
ALTER TABLE [dbo].[Tarset]  WITH CHECK ADD  CONSTRAINT [FK_Tarset_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tarset_Places]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tarset]'))
ALTER TABLE [dbo].[Tarset]  WITH CHECK ADD  CONSTRAINT [FK_Tarset_Places] FOREIGN KEY([ldpt_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tarset_Places1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tarset]'))
ALTER TABLE [dbo].[Tarset]  WITH CHECK ADD  CONSTRAINT [FK_Tarset_Places1] FOREIGN KEY([dest_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tarset_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tarset]'))
ALTER TABLE [dbo].[Tarset]  WITH CHECK ADD  CONSTRAINT [FK_Tarset_Product] FOREIGN KEY([prod_id])
REFERENCES [dbo].[Product] ([prod_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Consignee_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Consignee]'))
ALTER TABLE [dbo].[Consignee]  WITH CHECK ADD  CONSTRAINT [FK_Consignee_Glmast] FOREIGN KEY([Gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Consignee_Places]') AND parent_object_id = OBJECT_ID(N'[dbo].[Consignee]'))
ALTER TABLE [dbo].[Consignee]  WITH CHECK ADD  CONSTRAINT [FK_Consignee_Places] FOREIGN KEY([dest_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Consignor_Places]') AND parent_object_id = OBJECT_ID(N'[dbo].[Consignor]'))
ALTER TABLE [dbo].[Consignor]  WITH CHECK ADD  CONSTRAINT [FK_Consignor_Places] FOREIGN KEY([ldpt_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Glmast_Grpmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Glmast]'))
ALTER TABLE [dbo].[Glmast]  WITH CHECK ADD  CONSTRAINT [FK_Glmast_Grpmast] FOREIGN KEY([Grp_id])
REFERENCES [dbo].[Grpmast] ([Grp_Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Glmast_Places]') AND parent_object_id = OBJECT_ID(N'[dbo].[Glmast]'))
ALTER TABLE [dbo].[Glmast]  WITH CHECK ADD  CONSTRAINT [FK_Glmast_Places] FOREIGN KEY([dest_id])
REFERENCES [dbo].[Place] ([pl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubGL_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubGL]'))
ALTER TABLE [dbo].[SubGL]  WITH CHECK ADD  CONSTRAINT [FK_SubGL_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubGL_SubMast]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubGL]'))
ALTER TABLE [dbo].[SubGL]  WITH CHECK ADD  CONSTRAINT [FK_SubGL_SubMast] FOREIGN KEY([sub_id])
REFERENCES [dbo].[SubMast] ([Sub_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OpSubGl_SubMast]') AND parent_object_id = OBJECT_ID(N'[dbo].[OpSubGl]'))
ALTER TABLE [dbo].[OpSubGl]  WITH CHECK ADD  CONSTRAINT [FK_OpSubGl_SubMast] FOREIGN KEY([Sub_id])
REFERENCES [dbo].[SubMast] ([Sub_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bill_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bill]'))
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Glmast] FOREIGN KEY([Gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bill_Glmast1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bill]'))
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Glmast1] FOREIGN KEY([iac_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OpGl_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[OpGl]'))
ALTER TABLE [dbo].[OpGl]  WITH CHECK ADD  CONSTRAINT [FK_OpGl_Glmast] FOREIGN KEY([Gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Bank]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Bank] FOREIGN KEY([bank_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TLBill_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[TLBill]'))
ALTER TABLE [dbo].[TLBill]  WITH CHECK ADD  CONSTRAINT [FK_TLBill_Glmast] FOREIGN KEY([owner_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TLTexp_Glmast]') AND parent_object_id = OBJECT_ID(N'[dbo].[TLTexp]'))
ALTER TABLE [dbo].[TLTexp]  WITH CHECK ADD  CONSTRAINT [FK_TLTexp_Glmast] FOREIGN KEY([gl_id])
REFERENCES [dbo].[Glmast] ([Gl_id])
