set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 27,2011
-- Description:	Duplicate name check -sub
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateSub]
	@Sub_id			INT = NULL,
	@SubName		NVARCHAR(40),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM SubMast
		WHERE upper(SubName)=upper(@SubName) and Sub_id<>@Sub_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END



