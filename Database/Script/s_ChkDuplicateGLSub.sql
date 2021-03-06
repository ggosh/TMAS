set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -sub
-- =============================================
CREATE PROCEDURE [dbo].[s_ChkDuplicateGLSub]
	@GL_id			INT,
	@Sub_id			INT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM SubGL
		WHERE GL_id=@GL_id and Sub_id=@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

