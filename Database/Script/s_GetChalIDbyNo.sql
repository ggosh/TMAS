set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 3,2011
-- Description:	ID of a Challan from Number
-- =============================================
ALTER PROCEDURE [dbo].[s_GetChalIDbyNo]
	@Number			NCHAR(15),
	@Co_cd			NCHAR(1),
	@Yr_cd			NCHAR(2),
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT Chal_id
		FROM Challan
		WHERE Chal_No=@Number and co_cd=@co_cd and yr_cd=@Yr_cd

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
