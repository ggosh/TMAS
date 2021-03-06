set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 10,2009
-- Description:	Inserts or updates a bill
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateBill]
	@bill_id			INT = NULL,
	@bill_no			NVARCHAR(15),
	@Bill_Dt			DATETIME,
	@Bill_Type			CHAR(1),
	@GL_ID				INT,
	@IAC_ID				INT,
	@nontaxbl			DECIMAL(18,2),
	@taxbl				DECIMAL(18,2),
	@lessfrt			DECIMAL(18,2),
	@freight			DECIMAL(18,2),
	@detention			DECIMAL(18,2),
	@OthName			NVARCHAR(50),
	@OthChgs			DECIMAL(18,2),
	@total				DECIMAL(18,2),
	@st_id				INT,
	@servpc				DECIMAL(18,2),
	@servtax			DECIMAL(18,2),
	@postage			DECIMAL(18,2),
	@roundoff			DECIMAL(18,2),
	@Amount				DECIMAL(18,2),
	@ref				VARCHAR(100),
	@lodloc				VARCHAR(50),
	@rep_id				INT,
	@branch				NCHAR(3),
	@CO_CD				NCHAR(1),
	@Return             INT OUTPUT,
	@ErrMsg				VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@bill_id,0) = 0
			BEGIN

				INSERT INTO Bill(bill_no, Bill_Dt, Bill_Type, Gl_id, IAC_ID, nontaxbl, taxbl, lessfrt,
					freight, detention, OthName, OthChgs, total, st_id, servpc,
					servtax, postage, roundoff, Amount, ref, lodloc,
					rep_id, branch, co_cd)
				VALUES(@bill_no, @Bill_Dt, @Bill_Type, @Gl_id, @IAC_ID, @nontaxbl, @taxbl, @lessfrt,
					@freight, @detention, @OthName, @OthChgs, @total, @st_id, @servpc,
					@servtax, @postage, @roundoff, @Amount, @ref, @lodloc,
					@rep_id, @branch, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
			END
			ELSE
			BEGIN

				UPDATE Bill
				SET bill_no=@bill_no, Bill_Dt=@Bill_Dt, Bill_Type=@Bill_Type, Gl_id=@Gl_id,
				IAC_ID=@IAC_ID, nontaxbl=@nontaxbl, taxbl=@taxbl, lessfrt=@lessfrt,
				freight=@freight, detention=@detention, OthName=@OthName, OthChgs=@OthChgs,
				total=@total, st_id=@st_id, servpc=@servpc,	servtax=@servtax, postage=@postage,
				roundoff=@roundoff, amount=@Amount, ref=@ref, lodloc=@lodloc,
				rep_id=@rep_id, branch=@branch, co_cd=@CO_CD
				WHERE bill_id=@bill_id

				SET @Return = @bill_id
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

