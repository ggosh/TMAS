set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		G Ghosh
-- Create date: Aug 26,2011
-- Description:	Gets list of T/L transactions
-- =============================================
ALTER PROCEDURE [dbo].[s_GetTLLdg]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	/* tt_id, Trn_Code, TL_Code, TL_No, own, Trn_date, amount, csge_code, qty, unit */
	SET @SSQL='SELECT t.tt_id, t.Trn_Code, m.TL_Code, m.TL_No, m.own, 
	t.Trn_Date, t.Amount, ISNULL(g.csge_code,'''') AS csge_code, 
	ISNULL(c.qty,0) AS Qty, ISNULL(c.unit,'''') AS Unit
	FROM (((TLTrn t INNER JOIN TLmast m ON t.tl_id=m.tl_id) 
		LEFT OUTER JOIN Challan c ON t.vo_id=c.chal_id)
		LEFT OUTER JOIN Consignee g ON c.csge_id=g.csge_id)
		WHERE t.co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY m.TL_No,t.Trn_Date, t.Trn_Code'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

