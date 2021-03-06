set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of A/c heads
-- =============================================
ALTER PROCEDURE [dbo].[s_GetGLList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT g.GL_id, g.AcName AS Name, g.grp_id, gr.grpname as AcGrp, 
		CASE WHEN g.HasSub=1 THEN ''Y'' ELSE ''N'' END as SubAc 
		FROM ([GLmast] g INNER JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id) 
		WHERE g.co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY g.AcName'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--= 'Can not read A/c head list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

