set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 11,2011
-- Description:	Details of a rep
-- =============================================
ALTER PROCEDURE [dbo].[s_GetRepDetails]
	@Rep_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT Rep_id,RepName 
		FROM Rep
		WHERE rep_id=@Rep_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

