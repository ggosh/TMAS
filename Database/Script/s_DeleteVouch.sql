set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Aug 10,2011
-- Description:	Deletes a Voucher
-- =============================================
create PROCEDURE [dbo].[s_DeleteVouch]
	@Ac_id				INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION

		DELETE FROM AcSubDtl
		WHERE Ac_did in (SELECT Ac_Did FROM AcDtl WHERE Ac_id=@Ac_id)
		DELETE FROM AcDtl
		WHERE Ac_id=@Ac_id
		DELETE FROM AcMast
		WHERE Ac_id=@Ac_id

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
