set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 18,2011
-- Description:	Details of a SubAccount from Code
-- =============================================
ALTER PROCEDURE [dbo].[s_GetSubIDbyCode]
	@Accode				NCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT Sub_id
		FROM SubMast
		WHERE Accode=@Accode

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


