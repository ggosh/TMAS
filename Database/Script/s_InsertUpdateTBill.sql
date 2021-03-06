set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G.Ghosh
-- Create date: Feb 27,2013
-- Description:	Inserts or updates a Transport bill
-- =============================================
CREATE PROCEDURE [dbo].[s_InsertUpdateTBill]
	@bill_id			INT = NULL,
	@bill_no			NVARCHAR(15),
	@Bill_Dt			DATETIME,
	@Bill_Type			CHAR(1),
	@GL_ID				INT,
	@IAC_ID				INT,
	@freight			DECIMAL(18,2),
	@detention			DECIMAL(18,2),
	@OthName			NVARCHAR(50),
	@OthChgs			DECIMAL(18,2),
	@total				DECIMAL(18,2),
	@st_id				INT,
	@servpc				DECIMAL(18,2),
	@servtax			DECIMAL(18,2),
	@roundoff			DECIMAL(18,2),
	@Amount				DECIMAL(18,2),
	@ref				VARCHAR(100),
	@lodloc				VARCHAR(50),
	@branch				NCHAR(3),
	@CO_CD				NCHAR(1),
	@ChalDtls			NVARCHAR(1000),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @VI	 INT
		DECLARE @Cnt INT
		DECLARE @I   INT
		DECLARE @GLI INT

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@bill_id,0) = 0
			BEGIN

				INSERT INTO Bill(bill_no, Bill_Dt, Bill_Type, Gl_id, IAC_ID, nontaxbl, taxbl, lessfrt,
					freight, detention, OthName, OthChgs, total, st_id, servpc,
					servtax, postage, roundoff, Amount, ref, lodloc,
					rep_id, branch, co_cd)
				VALUES(@bill_no, @Bill_Dt, @Bill_Type, @Gl_id, @IAC_ID, 0, 0, 0,
					@freight, @detention, @OthName, @OthChgs, @total, @st_id, @servpc,
					@servtax, 0, @roundoff, @Amount, @ref, @lodloc,
					0, @branch, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
				SET @VI = @Return
			END
			ELSE
			BEGIN

				UPDATE Bill
				SET bill_no=@bill_no, Bill_Dt=@Bill_Dt, Bill_Type=@Bill_Type, Gl_id=@Gl_id,
				IAC_ID=@IAC_ID, freight=@freight, detention=@detention, OthName=@OthName, OthChgs=@OthChgs,
				total=@total, st_id=@st_id, servpc=@servpc,	servtax=@servtax, 
				roundoff=@roundoff, amount=@Amount, ref=@ref, lodloc=@lodloc,
				branch=@branch, co_cd=@CO_CD
				WHERE bill_id=@bill_id

				SET @Return = @bill_id
				SET @VI = @bill_id
			END	
			IF (SELECT COUNT(*) FROM Challans WHERE bill_id=@VI)>0
			BEGIN
				IF (@Bill_Type='F')
				UPDATE Challans set bill_id=0 WHERE bill_id=@VI
				IF (@Bill_Type='S')
				UPDATE Challans set suplbill_id=0 WHERE suplbill_id=@VI
				IF (@Bill_Type='D') 
				UPDATE Challans set dtnbill_id=0 WHERE dtnbill_id=@VI /* change */
			END
			SET @Cnt=LEN(@ChalDtls)/10
			SET @I=0
			WHILE @I<@Cnt 
			BEGIN
				SET @I=@I+1
				/* CHAL_ID */
				/* char(10) */
				SET @GLI=CONVERT(INT,SUBSTRING(@ChalDtls,1,10))
				SET @ChalDtls=SUBSTRING(@ChalDtls,11,LEN(@ChalDtls)-10)
				IF (@Bill_Type='F')
				UPDATE Challans set bill_id=@VI WHERE chal_id=@GLI
				IF (@Bill_Type='S')
				UPDATE Challans set suplbill_id=@VI WHERE chal_id=@GLI
				IF (@Bill_Type='D')
				UPDATE Challans set dtnbill_id=@VI WHERE chal_id=@GLI /* change */
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
