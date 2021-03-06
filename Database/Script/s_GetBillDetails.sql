set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 21,2009
-- Description:	Details of a Bill
-- =============================================
ALTER PROCEDURE [dbo].[s_GetBillDetails]
	@Bill_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT Bill_no, Bill_dt, Bill_type, Gl_id, iAc_id, nontaxbl, taxbl, lessfrt,
		freight, detention, OthName, OthChgs, total, st_id, ServPc, ServTax, postage, 
		roundoff, amount, ref, lodloc, rep_id, co_cd, branch, uid, edate, upuids
		FROM Bill 
		WHERE Bill_id=@bill_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
