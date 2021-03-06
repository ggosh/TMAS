set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Sep 18,2010
-- Description:	Details of a T/L from No
-- =============================================
ALTER PROCEDURE [dbo].[s_GetTLbyNo]
	@TL_No				NVARCHAR(15),
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT TL_id,TL_code,Own,Bilown,owner_id,start_date,end_date 
		FROM TLmast
		WHERE TL_No=@TL_No
		ORDER BY start_date desc

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


