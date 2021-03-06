set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @SSQL='SELECT t.te_id, t.ExpCode, t.ExpName, g.AcName AS Account
	FROM (TLTexp t INNER JOIN [GLmast] g ON t.gl_id=g.gl_id) 
		WHERE t.co_cd='''+@CO_CD+''''

	SET @SSQL=@SSQL+' ORDER BY t.ExpCode'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


