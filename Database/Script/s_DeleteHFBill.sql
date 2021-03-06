set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Deletes a hire freight bill
-- =============================================
CREATE PROCEDURE [dbo].[s_DeleteHFBill]
	@fb_id			INT = NULL,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION

		DELETE FROM TLBill
		WHERE tlb_id=@fb_id

		UPDATE Challans set hfbill_id=0 where hfbill_id=@fb_id

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
