set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes an A/c Sub head
-- =============================================
create PROCEDURE [dbo].[s_DeleteSub]
	@Sub_id			INT = NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION

		DELETE FROM OpSubGl
		WHERE Sub_id=@Sub_id
		DELETE FROM SubGl
		WHERE Sub_id=@Sub_id
		DELETE FROM SubMast
		WHERE Sub_id=@Sub_id

		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
