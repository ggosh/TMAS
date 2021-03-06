set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @SSQL='SELECT t.tt_id, t.Trn_Code, m.TL_Code, m.TL_No, o.AcName, 
	t.Trn_Date, t.Amount, ISNULL(g.csge_code,'''') AS csge_code, 
	ISNULL(c.qty,0) AS Qty, ISNULL(c.unit,'''') AS Unit
	FROM ((((TLTrn t INNER JOIN TLmast m ON t.tl_id=m.tl_id) 
		INNER JOIN GLmast o ON m.GL_id=o.GL_id) 
		LEFT OUTER JOIN Challan c ON t.vo_id=c.chal_id)
		LEFT OUTER JOIN Consignee g ON c.csge_id=g.csge_id)
		WHERE t.co_cd='''+@CO_CD+''' AND m.own=0 AND m.BillOwn=1'

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY m.GL_id,t.Trn_Date, t.Trn_Code,m.TL_No'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END




