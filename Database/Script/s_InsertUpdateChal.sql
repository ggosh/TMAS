set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 10,2009
-- Description:	Inserts or updates a challan
--        CHECK UPDATE PART
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateChal]
	@chal_id		INT = NULL,
	@branch			NCHAR(3),
	@tl_id			INT,
	@Chal_no		NVARCHAR(15),
	@Chal_dt		DATETIME,
	@CN_no			NVARCHAR(15),
	@Csgr_id		INT,
	@ldpt_id		INT,
	@Gl_id			INT,
	@Csge_id		INT,
	@dest_id		INT,
	@trip_days		SMALLINT,
	@driv_id		INT,
	@prod_id		INT,
	@qty			DECIMAL(18, 2),
	@unit			NCHAR(2),
	@rate			DECIMAL(18, 2),
	@per			NCHAR(2),
	@amount			DECIMAL(18, 2),
	@hire_frgt		DECIMAL(18, 2),
	@CO_CD			NCHAR(1),
	@Yr_Cd			NCHAR(2),
	@AcEffctB4dlv	BIT,
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		SET @ErrMsg = ''
		DECLARE @VI	INT
		DECLARE @VDI INT
		DECLARE @LVD INT
		DECLARE @Cnt INT
		DECLARE @Cy INT
		DECLARE @CnS INT
		DECLARE @Cz INT
		DECLARE @TTI INT
		DECLARE @LTT INT
		DECLARE @Own BIT
		DECLARE @Sht DECIMAL(18,2)
		DECLARE @Dtls varchar(4000)
		DECLARE @SubDtls varchar(4000)

		BEGIN TRANSACTION
		IF ISNULL(@chal_id,0) = 0
		BEGIN

			INSERT INTO Challan(branch, tl_id, chal_no, chal_dt, cn_no, csgr_id, ldpt_id, Gl_id,
				csge_id, dest_id, trip_days, driv_id, prod_id, qty, unit, rate, per,
				amount, hire_frgt, co_cd, yr_cd, status)
			VALUES(@branch, @tl_id, @chal_no, @chal_dt, @cn_no, @csgr_id, @ldpt_id, @Gl_id,
				@csge_id, @dest_id, @trip_days, @driv_id, @prod_id, @qty, @unit, @rate,
				@per, @amount, @hire_frgt, @CO_CD, @Yr_Cd,'')

			SET @Return = SCOPE_IDENTITY()

			SELECT @Own=OWN FROM TLMAST WHERE TL_ID=@tl_id
			IF @Own=0
			BEGIN
				INSERT INTO Tltrn(tl_id, trn_code, trn_date, amount, vo_id, co_cd)
				VALUES(@tl_id, '0', @chal_dt, @hire_frgt, @return, @co_cd)
			END
			ELSE
			BEGIN
				INSERT INTO Tltrn(tl_id, trn_code, trn_date, amount, vo_id, co_cd)
				VALUES(@tl_id, '0', @chal_dt, @amount, @return, @co_cd)
			END

			IF @AcEffctB4dlv=1 
			BEGIN
				SET @Dtls=''
				SET @SubDtls=''
				IF @Own=0
				BEGIN
					SET @Sht=0		/* DID-ID-GL_ID-AMOUNT */
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),11)+CONVERT(char(12),@hire_frgt-@Sht)
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),12)+CONVERT(char(12),-@hire_frgt+@Sht)
									/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
					SET @SubDtls=@SubDtls+CONVERT(char(6),0)+CONVERT(char(6),-2)+CONVERT(char(6),0)+CONVERT(char(6),@tl_id)+CONVERT(char(6),0)+CONVERT(char(12),-@hire_frgt+@Sht)+'T'
					EXEC s_InsertUpdateVouch 0, @chal_no, @chal_dt, 'H', '', NULL, @hire_frgt, @CO_CD, 
						@branch, @yr_cd, @Return, 'Payment due against trip.', @Dtls, @SubDtls, @VI, @ErrMsg
				END
				ELSE
				BEGIN
					SET @Sht=0
				END
			END
		END
		ELSE
		BEGIN

			UPDATE Challan
			SET branch=@branch, tl_id=@tl_id, chal_no=@chal_no, chal_dt=@chal_dt, cn_no=@CN_no, 
				csgr_id=@csgr_id, ldpt_id=@ldpt_id, Gl_id=@Gl_id, csge_id=@csge_id, 
				dest_id=@dest_id, trip_days=@trip_days, driv_id=@driv_id, prod_id=@prod_id, 
				qty=@qty, unit=@unit, rate=@rate, per=@per, amount=@amount, hire_frgt=@hire_frgt,
				co_cd=@CO_CD, yr_cd=@Yr_Cd 
			WHERE chal_id=@chal_id

			SET @Return = @chal_id

			SELECT @Own=OWN FROM TLMAST WHERE TL_ID=@tl_id

			SELECT @Sht=sht_amt from ChalUnld where chal_id=@chal_id
			SET @Sht=ISNULL(@Sht,0)

			SELECT @TTI=tt_id FROM Tltrn WHERE vo_id=@chal_id and trn_code='C'
			SET @TTI=ISNULL(@TTI,0)

			IF @Own=0
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@hire_frgt
				WHERE vo_id=@chal_id and trn_code='0'
			END
			ELSE
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@amount
				WHERE vo_id=@chal_id and trn_code='0'
			END
			IF @TTI=0
			BEGIN
				INSERT INTO Tltrn(vo_id, tl_id, trn_date, trn_code, amount)
				VALUES(@chal_id, @tl_id, @chal_dt, 'C', @Sht)
			END
			ELSE
			BEGIN
				UPDATE Tltrn
				SET tl_id=@tl_id, trn_date=@chal_dt, amount=@Sht
				WHERE tt_id=@TTI
			END

			IF @AcEffctB4dlv=1 
			BEGIN
				SET @Dtls=''
				SET @SubDtls=''
				SELECT @VI=Ac_id from AcMast where ref_id=@chal_id
				SET @VI=ISNULL(@VI,0)
				IF (@VI>0)
				BEGIN
					SELECT @Cnt=COUNT(*) FROM AcDtl WHERE Ac_Id=@VI
					SET @VDI=0
					SET @LVD=0
					IF (@Cnt<2)
						SET @Cnt=2
					SET @Cy=0
					WHILE (@Cy < @Cnt)
					BEGIN
						SELECT TOP 1 @VDI=AC_DID FROM AcDtl WHERE Ac_Id=@VI AND Ac_did>@LVD ORDER BY AC_DID
						SET @VDI=ISNULL(@VDI,0)
						IF @VDI>@LVD
							SET @LVD=@VDI
						SET @Cy=@Cy+1
						IF (@Cy=1)		/* DID-ID-GL_ID-AMOUNT */
							SET @Dtls=@Dtls+CONVERT(char(6),@VDI)+CONVERT(char(6),@VI)+CONVERT(char(6),11)+CONVERT(char(12),@hire_frgt-@Sht)
						ELSE
						IF (@Cy=2)
						BEGIN
							SET @Dtls=@Dtls+CONVERT(char(6),@VDI)+CONVERT(char(6),@VI)+CONVERT(char(6),12)+CONVERT(char(12),-@hire_frgt+@Sht)
							SELECT @CnS=COUNT(*) FROM AcSubDtl WHERE Ac_did=@VDI
							SET @TTI=0
							SET @LTT=0
							SET @Cz=0
							WHILE (@Cz < @CnS)
							BEGIN
								SELECT TOP 1 @TTI=SUB_DID FROM AcSubDtl WHERE Ac_did=@VDI AND sub_did>@LTT ORDER BY SUB_DID
								SET @TTI=ISNULL(@TTI,0)
								IF @TTI>@LTT
									SET @LTT=@TTI
								IF (@Cz=1)	/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
									SET @SubDtls=@SubDtls+CONVERT(char(6),@TTI)+CONVERT(char(6),@VDI)+CONVERT(char(6),0)+CONVERT(char(6),@tl_id)+CONVERT(char(6),0)+CONVERT(char(12),-@hire_frgt+@Sht)
								ELSE
									SET @SubDtls=@SubDtls+CONVERT(char(6),-@TTI)+CONVERT(char(6),@VDI)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(12),0)
								SET @Cz=@Cz+1
							END
						END
						ELSE
						BEGIN
							SET @Dtls=@Dtls+CONVERT(char(6),-@VDI)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(12),0)
						END
					END
				END
				EXEC s_InsertUpdateVouch @VI, @chal_no, @chal_dt, 'H', '', NULL, @hire_frgt, @CO_CD, 
					@branch, @yr_cd, @chal_id, 'Payment due against trip.', @Dtls, @SubDtls, @VI, @ErrMsg
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

