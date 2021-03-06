set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 27,2011
-- Description:	TL exp new code - incomplete
-- =============================================
Create PROCEDURE [dbo].[s_GetNewTLexpCode]
	@GL_id			INT,
	@Return         CHAR(1) OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Ty as CHAR(1)
		SET @ErrMsg = ''

		SELECT @Ty=CASE expcode 
					WHEN '0' THEN 'I'
					WHEN 'C' THEN 'X'
					WHEN 'D' THEN 'X'
					ELSE    'O'
					END
		FROM TLTexp
		WHERE GL_id=@GL_id

		SET @Return=@Ty
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END


