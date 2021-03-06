set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: May 23,2011
-- Description:	update GL-subs
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateSubGL]
	@sg_ID		INT=NULL,
	@GL_ID		INT,
	@Sub_ID		INT,
	@CO_CD		CHAR(1),
	@Return     INT OUTPUT,
	@ErrMsg		VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SET @ErrMsg = ''
	BEGIN TRANSACTION
		IF ISNULL(@sg_ID,0) = 0
		BEGIN

			INSERT INTO SubGL(Gl_id,Sub_id,co_cd)
			VALUES(@Gl_id,@Sub_id,@CO_CD)

			SET @Return = SCOPE_IDENTITY()
		END
		ELSE
		BEGIN

			UPDATE SubGL
			SET Gl_id=@Gl_id, Sub_id=@Sub_id, co_cd=@CO_CD
			WHERE sg_ID=@sg_ID

			SET @Return = @sg_ID
		END	
	COMMIT TRANSACTION				
	
	RETURN

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @ErrMsg = 'Can not update GL-Subs'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

