set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 18,2011
-- Description:	Inserts or updates a sub a/c group
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateSGr]
	@SGr_id			INT = NULL,
	@SGrName		NVARCHAR(30),
	@status			NCHAR(1),
	@yrOpen			NCHAR(5),
	@CO_CD			NCHAR(1),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@SGr_id,0) = 0
			BEGIN

				INSERT INTO SubGrmast(SGrName,yrOpen,status,co_cd)
				VALUES(@SGrName,@yrOpen,@status,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE SubGrmast
				SET SGrName=@SGrName, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE sgr_id=@SGr_id

				SET @Return = @SGr_id
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

