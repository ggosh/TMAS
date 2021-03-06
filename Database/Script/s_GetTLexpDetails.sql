set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 1,2009
-- Description:	Details of a T/L exp
-- =============================================
create PROCEDURE [dbo].[s_GetTLexpDetails]
	@Te_id				INT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT ExpCode,ExpName,gl_id
		FROM TLtexp
		WHERE Te_id=@Te_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

