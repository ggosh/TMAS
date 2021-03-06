set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Deletes a transport bill
-- =============================================
ALTER PROCEDURE [dbo].[s_DeleteTBill]
	@bill_id			INT = NULL,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION

		DELETE FROM Bill
		WHERE bill_id=@bill_id

		UPDATE Challans set bill_id=0 where bill_id=@bill_id
		UPDATE Challans set suplbill_id=0 where suplbill_id=@bill_id
		UPDATE Challans set dtnbill_id=0 where dtnbill_id=@bill_id

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
