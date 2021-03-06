set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jan 3,2011
-- Description:	Inserts or updates a a/c group
-- =============================================
create PROCEDURE [dbo].[s_InsertUpdateGrp]
	@Grp_id			INT = NULL,
	@GrpName		NVARCHAR(40),
	@GrpCode		NCHAR(4),
	@SchNo			NCHAR(4),
	@yrOpen			NCHAR(5),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@Grp_id,0) = 0
			BEGIN

				INSERT INTO Grpmast(GrpName,GrpCode,SchNo,yrOpen,status,co_cd)
				VALUES(@GrpName,@GrpCode,@SchNo,@yrOpen,@status,@CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Grpmast
				SET GrpName=@GrpName, GrpCode=@GrpCode,SchNo=@SchNo, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD
				WHERE grp_id=@Grp_id

				SET @Return = @Grp_id
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
