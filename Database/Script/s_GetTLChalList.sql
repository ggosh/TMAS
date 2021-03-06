set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 28,2013
-- Description:	Challan List of a T/L
-- =============================================
ALTER PROCEDURE [dbo].[s_GetTLChalList]
	@TL_id			INT,
	@StartDate		DATETIME,
	@EndDate		DATETIME,
	@Stat			NCHAR(1),	/* A=All,U=Unbilled,B=Billed */
	@bill_id		INT=NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

	SET @ErrMsg = '';
	DECLARE @SSQL	VARCHAR(2000);
	/* branch, date,challan,party,csge,loading, destination, qty, unit */
	SET @SSQL='SELECT t.tt_id, c.branch, c.chal_dt as Date, c.chal_no as Challan,
		g.AcName as Party, ce.csge_code as Consignee, pl.pl_name as Loading,
        pd.pl_name as Destination, c.qty as Quantity, c.unit 
		FROM (((((TLTrn t left join challan c on t.vo_id=c.chal_id) 
			left join glmast g on c.gl_id=g=gl_id) 
			left join consignee s on c.csge_id=s.csge_id)
			left join place l on c.ldpt_id=l.pl_id)
			left join place d on c.dest_id=d.pl_id)
		WHERE c.TL_id=' + @TL_id + ' and c.chal_dt>=''' + convert(varchar(20),@Startdate,103) 
		+ ''' and c.chal_dt<=''' + 	convert(varchar(20),@EndDate,103) + ''''

	IF @Stat='U'
		SET @SSQL=@SSQL+' and ISNULL(tlb_id,0)=0 or ISNULL(tlb_id,0)=ISNULL(@bill_id,0)'
	IF @Stat='B'
		SET @SSQL=@SSQL+' and ISNULL(tlb_id,0)=ISNULL(@bill_id,0)'

	SET @SSQL=@SSQL+' ORDER BY c.chal_dt,c.chal_no'

	print(@SSQL);
	exec(@SSQL);

	RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
