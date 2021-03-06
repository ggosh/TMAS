set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 27,2011
-- Description:	Duplicate code check -sub
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateSubCode]
	@Sub_id			INT = NULL,
	@SubCode		NCHAR(4),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM SubMast
		WHERE upper(Accode)=upper(@SubCode) and Sub_id<>@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END




