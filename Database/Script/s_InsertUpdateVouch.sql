set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mar 31,2011
-- Description:	Inserts or updates a voucher
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateVouch]
	@Ac_id			INT = NULL,
	@Vo_No			VARCHAR(15),
	@Vo_Dt			DATETIME,
	@Vo_Type		CHAR(1),
	@Cheque_No		CHAR(10),
	@bank_dt		DATETIME=NULL,
	@Amount			DECIMAL,
	@CO_CD			NCHAR(1),
	@branch			NCHAR(3),
	@Yr_Cd			NCHAR(2),
	@Ref_id			INT=NULL,
	@Narr			VARCHAR(4000),
	@Dtls			VARCHAR(4000),
	@SubDtls		VARCHAR(4000),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @VI	 INT
		DECLARE @VDI INT
		DECLARE @TTI INT
		DECLARE @Cnt INT
		DECLARE @CnS INT
		DECLARE @I   INT
		DECLARE @J   INT
		DECLARE @GLI INT
		DECLARE @SBI INT
		DECLARE @TLI INT
		DECLARE @BLI INT
		DECLARE @AMT DECIMAL(18,2)
		DECLARE @SAM DECIMAL(18,2)
		DECLARE @DTY NCHAR(1)
		SET @ErrMsg = ''

		BEGIN TRANSACTION
			IF ISNULL(@Ac_id,0) = 0
			BEGIN

				INSERT INTO AcMast(Vo_No, Vo_Dt, Type, Chq_No, bank_dt, Amount, 
					Narr, co_cd, branch, yr_cd, ref_id)
				VALUES(@Vo_No, @Vo_Dt, @Vo_Type, @Cheque_No, @bank_dt, @Amount, 
					@Narr, @CO_CD, @branch, @yr_cd, @Ref_id)

				SET @Return = SCOPE_IDENTITY()
				SET @VI=@Return

				IF (SELECT COUNT(*) FROM AcSubDtl 
					WHERE Ac_did IN (SELECT Ac_did FROM AcDtl WHERE Ac_id=@VI))>0
					DELETE FROM AcSubDtl WHERE Ac_did IN (SELECT Ac_did FROM AcDtl WHERE Ac_id=@VI)
				IF (SELECT COUNT(*) FROM AcDtl WHERE Ac_id=@VI)>0
					DELETE FROM AcDtl WHERE Ac_id=@VI
				SET @Cnt=LEN(@Dtls)/30
				SET @I=0
				SET @J=0
				WHILE @I<@Cnt 
				BEGIN
					SET @I=@I+1
					/* DID-ID-GL_ID-AMOUNT */
					/* char(6)+char(6)+char(6)+char(12) */
					SET @GLI=CONVERT(INT,SUBSTRING(@Dtls,13,6))
					SET @AMT=CONVERT(DECIMAL,SUBSTRING(@Dtls,19,12))
					SET @Dtls=SUBSTRING(@Dtls,31,LEN(@Dtls)-30)
					INSERT INTO AcDtl(Ac_Id, gl_id, amount) 
						VALUES(@VI, @GLI, @AMT)
					SET @VDI= SCOPE_IDENTITY()

					IF LEN(@SubDtls)>0
					BEGIN
						SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
						WHILE @J=@I
						BEGIN
							/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
							/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12)+char(1) */
							SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
							SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
							SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
							SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
							SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
							SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
							INSERT INTO AcSubDtl(Ac_did, Sub_Id, tl_id, bill_id, amount, dtype) 
								VALUES(@VDI, @SBI, @TLI, @BLI, @AMT, @DTY)

							SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
						END
					END
				END
			END
			ELSE
			BEGIN

				UPDATE AcMast
				SET Vo_No=@Vo_No, Vo_dt=@Vo_Dt, Type=@Vo_Type, Chq_No=@Cheque_No, 
				bank_dt=@bank_dt, Amount=@Amount, narr=@Narr, co_cd=@CO_CD, 
				branch=@branch, yr_cd=@Yr_cd, ref_id=@Ref_id
				WHERE Ac_id=@Ac_id

				SET @Return = @Ac_id
				SET @VI = @Ac_id

				SET @Cnt=LEN(@Dtls)/30
				SET @I=0
				SET @J=0
				WHILE @I<@Cnt
				BEGIN
					SET @I=@I+1
					/* DID-ID-GL_ID-AMOUNT */
					/* char(6)+char(6)+char(6)+char(12) */
					SET @VDI=CONVERT(INT,SUBSTRING(@Dtls,1,6))
					SET @GLI=CONVERT(INT,SUBSTRING(@Dtls,13,6))
					SET @AMT=CONVERT(DECIMAL,SUBSTRING(@Dtls,19,12))
					SET @Dtls=SUBSTRING(@Dtls,31,LEN(@Dtls)-30)
					IF (@VDI>0)
						UPDATE AcDtl SET Ac_Id=@VI, gl_id=@GLI, amount=@AMT 
						WHERE Ac_did=@VDI
					ELSE
					BEGIN
						IF (@VDI<0)
							DELETE FROM AcDtl WHERE Ac_did=ABS(@VDI)
						ELSE
						BEGIN
							INSERT INTO AcDtl(Ac_Id, gl_id, amount) 
								VALUES(@VI, @GLI, @AMT)
							SET @VDI= SCOPE_IDENTITY()
						END
					END

					IF LEN(@SubDtls)>0
					BEGIN
						SET @TTI=CONVERT(INT,SUBSTRING(@SubDtls,1,6))
						IF (@TTI<0)
							DELETE FROM AcSubDtl WHERE Sub_did=ABS(@TTI)
						ELSE
						BEGIN
							IF (@TTI>0)
							BEGIN
								SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
								WHILE @J=@VDI
								BEGIN
									/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
									/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12) */
									SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
									SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
									SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
									SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
									SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
									SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
									UPDATE AcSubDtl SET Ac_did=@VDI, Sub_Id=@SBI, tl_id=@TLI, 
										bill_id=@BLI, amount=@AMT, dtype=@DTY 
										WHERE Sub_did=@TTI

									SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
								END
							END
							ELSE
							BEGIN
								SET @J=CONVERT(INT,SUBSTRING(@SubDtls,7,6))
								IF (@J<0)
								BEGIN
									SET @J=ABS(@J)
									WHILE @J=@I
									BEGIN
										/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
										/* char(6)+char(6)+char(6)+char(6)+char(6)+char(12) */
										SET @SBI=CONVERT(INT,SUBSTRING(@SubDtls,13,6))
										SET @TLI=CONVERT(INT,SUBSTRING(@SubDtls,19,6))
										SET @BLI=CONVERT(INT,SUBSTRING(@SubDtls,25,6))
										SET @SAM=CONVERT(DECIMAL,SUBSTRING(@SubDtls,31,12))
										SET @DTY=CONVERT(NCHAR(1),SUBSTRING(@SubDtls,43,1))
										SET @SubDtls=SUBSTRING(@SubDtls,44,LEN(@SubDtls)-43)
										INSERT INTO AcSubDtl(Ac_did, Sub_Id, tl_id, bill_id, amount, dtype) 
											VALUES(@VDI, @SBI, @TLI, @BLI, @AMT, @DTY)

										SET @J=ABS(CONVERT(INT,SUBSTRING(@SubDtls,7,6)))
									END
								END
							END
						END
					END
				END
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

