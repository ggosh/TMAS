set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 3,2011
-- Description:	ID of a Challan from Number
-- =============================================
CREATE PROCEDURE [dbo].[s_GetBillIDbyNo]
	@Number			NCHAR(15),
	@Co_cd			NCHAR(1),
	@Yr_cd			NCHAR(2),
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''

		SELECT Bill_id
		FROM Bill
		WHERE Bill_No=@Number and co_cd=@co_cd and yr_cd=@Yr_cd

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
