set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: May 18,2011
-- Description:	Gets list of Sub A/c heads
-- =============================================
ALTER PROCEDURE [dbo].[s_GetSubGLList]
	@GL_ID			INT=NULL,
	@Sub_ID			INT=NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000)
	DECLARE @WH		BIT

	SET @SSQL='SELECT s.Sub_id, s.SubName AS Name, g.gl_id, g.AcName
		FROM (([SubMast] s INNER JOIN [SubGl] u ON u.sub_id=s.sub_id) 
		INNER JOIN [Glmast] g ON g.gl_id=u.Gl_id)'

	SET @WH=0 
	IF ISNULL(@Gl_id,0)	> 0
	BEGIN
		SET @SSQL=@SSQL+' WHERE g.gl_id='+ convert(varchar(20),@GL_ID)
		SET @WH=1
	END
	IF ISNULL(@Sub_id,0) > 0
	BEGIN
		IF @WH=0
		BEGIN
			SET @SSQL=@SSQL+' WHERE '
		END
		SET @SSQL=@SSQL+'s.sub_id=' + convert(varchar(20),@Sub_ID)
	END

	SET @SSQL=@SSQL+' ORDER BY s.SubName'

	print(@SSQL);
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

