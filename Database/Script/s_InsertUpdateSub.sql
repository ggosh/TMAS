set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 18,2011
-- Description:	Inserts or updates a sub a/c head
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateSub]
	@Sub_id			INT = NULL,
	@SubName		NVARCHAR(40),
	@SGr_id			INT,
	@yrOpen			NCHAR(5),
	@OpBal			DECIMAL(18, 2),
	@LyBal			DECIMAL(18, 2),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@AcCode			NCHAR(4),
	@IT_File		NVARCHAR(25),
	@RC_No			NVARCHAR(20),
	@VAT_No			NVARCHAR(15),
	@Addr			NVARCHAR(500),
	@ph_no			NVARCHAR(30),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@Sub_id,0) = 0
			BEGIN

				INSERT INTO SubMast(SubName,SGr_id,yrOpen,opbal,lybal,status,co_cd,
					AcCode,IT_File,RC_No,VAT_No,Addr,ph_no,subtype)
				VALUES(@SubName,@SGr_id,@yrOpen,@opbal,@lybal,@status,@CO_CD,
					@AcCode,@IT_File,@RC_No,@VAT_No,@Addr,@ph_no,'G')

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE SubMast
				SET SubName=@SubName, SGr_id=@SGr_id, opbal=@opbal, 
					lybal=@lybal, status=@status, yrOpen=@yrOpen, co_cd=@CO_CD, AcCode=@AcCode,
					IT_File=@IT_File, RC_No=@RC_No, VAT_No=@VAT_No, Addr=@Addr, ph_no=@ph_no
				WHERE sub_id=@Sub_id

				SET @Return = @Sub_id
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

