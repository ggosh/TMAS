set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jan 3,2010
-- Description:	Inserts or updates a a/c head
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateGL]
	@GL_id			INT = NULL,
	@AcName			NVARCHAR(40),
	@Grp_id			INT,
	@yrOpen			NCHAR(5),
	@OpBal			DECIMAL(18, 2),
	@LyBal			DECIMAL(18, 2),
	@status			NCHAR(1),
	@CO_CD			NCHAR(1),
	@AcCode			NVARCHAR(15),
	@IT_File		NVARCHAR(25),
	@RC_No			NVARCHAR(20),
	@VAT_No			NVARCHAR(15),
	@ECC_No			NVARCHAR(50),
	@Addr			NVARCHAR(500),
	@bill_addr		NVARCHAR(500),
	@Ref_No			NVARCHAR(10),
	@Encl			NVARCHAR(50),
	@attn			NVARCHAR(50),
	@kattn			NVARCHAR(50),
	@ph_no			NVARCHAR(30),
	@HasSub			BIT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AcYr NCHAR(2)
		DECLARE @OG_id	INT
		SET @ErrMsg = ''
		SET @AcYr=substring(@yrOpen,1,2)

		BEGIN TRANSACTION
			IF ISNULL(@GL_id,0) = 0
			BEGIN

				INSERT INTO Glmast(AcName,Grp_id,yrOpen,opbal,lybal,status,co_cd,
					AcCode,IT_File,RC_No,VAT_No,ECC_No,Addr,bill_addr,Ref_No,Encl,
					attn,kattn,ph_no,HasSub)
				VALUES(@AcName,@Grp_id,@yrOpen,@opbal,@lybal,@status,@CO_CD,
					@AcCode,@IT_File,@RC_No,@VAT_No,@ECC_No,@Addr,@bill_addr,@Ref_No,@Encl,
					@attn,@kattn,@ph_no,@HasSub)

				SET @Return = SCOPE_IDENTITY()

				INSERT INTO OpGl(Gl_id,AcYr,Balance, Lybal,co_cd)
				VALUES(@Return, @AcYr, @opbal, @lybal, @CO_CD)
			END
			ELSE
			BEGIN

				UPDATE Glmast
				SET AcName=@AcName, Grp_id=@Grp_id, opbal=@opbal, lybal=@lybal, 
					status=@status, yrOpen=@yrOpen, co_cd=@CO_CD, AcCode=@AcCode,
					IT_File=@IT_File, RC_No=@RC_No, VAT_No=@VAT_No, ECC_No=@ECC_No,
					Addr=@Addr, bill_addr=@bill_addr, Ref_No=@Ref_No, Encl=@Encl,
					attn=@attn, kattn=@kattn, ph_no=@ph_no, HasSub=@HasSub
				WHERE gl_id=@Gl_id

				SET @Return = @Gl_id

				IF (SELECT COUNT(*) FROM OpGl WHERE Gl_id=@Gl_id AND AcYr=@AcYr)=0
					INSERT INTO OpGl(Gl_id,AcYr,Balance, Lybal,co_cd)
					VALUES(@Return, @AcYr, @opbal, @lybal, @CO_CD)
				ELSE
					UPDATE OpGl SET Balance=@opbal, lybal=@lybal
					WHERE Gl_id=@Gl_id AND AcYr=@AcYr
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



