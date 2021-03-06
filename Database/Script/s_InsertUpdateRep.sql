set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 11,2011
-- Description:	Inserts or updates a Rep
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateRep]
	@Rep_id				INT = NULL,
	@Repname			NVARCHAR(30),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@Rep_id,0) = 0
			BEGIN

				INSERT INTO Rep(Repname,co_cd)
				VALUES(@Repname,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Rep
				SET Repname=@Repname, co_cd=@CO_CD
				WHERE Rep_id=@Rep_id

				SET @Return = @Rep_id
			END	
		COMMIT TRANSACTION				
		RETURN
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

