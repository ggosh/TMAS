set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jun 11,2011
-- Description:	Inserts or updates a T/L exp
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateTLexp]
	@te_id			INT = NULL,
	@ExpCode		NCHAR(1),
	@ExpName		NVARCHAR(50),
	@gl_id			INT,
	@CO_CD			NCHAR(1),
	@Return			INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@te_id,0) = 0
			BEGIN

				INSERT INTO TLTexp(ExpCode,ExpName,gl_id,co_cd)
				VALUES(@ExpCode,@ExpName,@gl_id,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE TLTexp
				SET ExpCode=@ExpCode, ExpName=@ExpName, gl_id=@gl_id, 
				co_cd=@CO_CD
				WHERE te_id=@te_id

				SET @Return = @te_id
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

