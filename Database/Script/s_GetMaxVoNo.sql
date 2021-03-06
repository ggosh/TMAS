set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2010
-- Description:	Gets last no.of bills 
-- =============================================
ALTER PROCEDURE [dbo].[s_GetMaxVoNo]
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
--'Can not read Voucher list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

