set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 4,2013
-- Description:	Gets list of T/L payments
-- =============================================
ALTER PROCEDURE [dbo].[s_GetTLPmts]
	@TL_id			INT,
	@StartDate		DATETIME,
	@EndDate		DATETIME,
	@Stat			NCHAR(1),	/* A=All,U=Unbilled,B=Billed */
	@bill_id		INT=NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	/* tt_id, Trn_Code, TL_Code, TL_No, own, Trn_date, amount, csge_code, qty, unit */
	SET @SSQL='SELECT t.tt_id, t.Trn_Code, t.Trn_Date, t.Amount 
	FROM TLTrn t 
	WHERE t.TL_id=' + @TL_id + ' and t.Trn_date>=''' + convert(varchar(20),@Startdate,103) 
	+ ''' and t.Trn_date<=''' + 	convert(varchar(20),@EndDate,103) + ''''

	IF @Stat='U'
		SET @SSQL=@SSQL+' and ISNULL(tlb_id,0)=0 or ISNULL(tlb_id,0)=ISNULL(@bill_id,0)'
	IF @Stat='B'
		SET @SSQL=@SSQL+' and ISNULL(tlb_id,0)=ISNULL(@bill_id,0)'

	SET @SSQL=@SSQL+' ORDER BY t.Trn_Date, t.Trn_Code'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
