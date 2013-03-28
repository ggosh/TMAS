set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 18,2011
-- Description:	Details of a Account from Code
-- =============================================
create PROCEDURE [dbo].[s_GetGLIDbyCode]
	@Accode				NCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT GL_id
		FROM GLmast
		WHERE Accode=@Accode

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

