set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate Code check -GL
-- =============================================
ALTER PROCEDURE [dbo].[s_ChkDuplicateCode]
	@GL_id			INT = NULL,
	@AcCode			NVARCHAR(15),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM GLmast
		WHERE upper(AcCode)=upper(@AcCode) and GL_id<>@GL_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



