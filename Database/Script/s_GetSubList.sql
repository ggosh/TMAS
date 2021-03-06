set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: May 18,2011
-- Description:	Gets list of Sub A/c heads
-- =============================================
ALTER PROCEDURE [dbo].[s_GetSubList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT g.Sub_id, g.SubName AS Name, g.sgr_id, gr.sgrname as SubGrp
		FROM ([SubMast] g INNER JOIN [SubGrmast] gr ON g.sgr_id=gr.sGr_id) 
		WHERE g.co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY g.SubName'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--= 'Can not read Sub head list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

