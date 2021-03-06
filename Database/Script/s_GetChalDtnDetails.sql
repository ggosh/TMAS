set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 20,2009
-- Description:	Details of a challan detention
-- =============================================
ALTER PROCEDURE [dbo].[s_GetChalDtnDetails]
	@chal_id			INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT dtn_id, pre_dtn, rep_time, rel_time, dtn_days, dtn_rate, dtn_amt, 
		mkt_days, mkt_rate, mkt_amt
		FROM ChallDtn
		WHERE chal_id=@chal_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


