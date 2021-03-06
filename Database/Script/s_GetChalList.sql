set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 20,2009
-- Description:	Gets list of challan
-- =============================================
ALTER PROCEDURE [dbo].[s_GetChalList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT c.chal_id, c.branch, c.chal_dt as Date, c.chal_no as Challan, c.cn_no as CN,
  c.Gl_id, g.AcName as Party, c.csgr_id, cr.cs_name as Consignor,c.ldpt_id, pl.pl_name as Loading, 
  c.csge_id, ce.csge_code as Consignee, c.dest_id, pd.pl_name as Destination, pr.product,c.qty as Quantity, c.unit,
  (select count(*) from chalunld where chal_id=c.chal_id) as Unloaded 
  FROM (((((((Challan c INNER JOIN Glmast g ON c.Gl_id = g.Gl_id) INNER JOIN TLmast t ON c.TL_id = t.tl_id)
  INNER JOIN Consignee ce on c.csge_id=ce.csge_id) INNER JOIN Consignor cr on c.csgr_id=cr.csgr_id)
  INNER JOIN Place pl ON c.ldpt_id = pl.pl_id) INNER JOIN Place pd ON c.dest_id = pd.pl_id)
  INNER JOIN Product pr ON c.prod_id = pr.prod_id)
  WHERE c.co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND '+@Filt
	END

	SET @SSQL=@SSQL+' ORDER BY c.chal_dt desc,c.chal_no desc'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read Challan list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
