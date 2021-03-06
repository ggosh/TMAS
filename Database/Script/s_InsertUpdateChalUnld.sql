set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Dec 30,2009
-- Description:	Inserts or updates a challan unload
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateChalUnld]
	@Unld_id		INT = NULL,
	@chal_id		INT,
	@Chal_rcd		DATETIME,
	@Deliv_dt		DATETIME,
	@deliv_wt		DECIMAL(18, 2),
	@deliv_unit		NCHAR(2),
	@shortage		DECIMAL(18, 2),
	@sht_unit		NCHAR(3),
	@sht_rate		DECIMAL(18, 2),
	@sht_amt		DECIMAL(18, 2),
	@Mkt_sht		DECIMAL(18, 2),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @tl_id     INT
		DECLARE @drv_id    INT
		DECLARE @chal_dt   DATETIME
		DECLARE @hire_frgt DECIMAL(18,2)
		DECLARE @chal_no   NVARCHAR(15)
		DECLARE @CO_CD     NCHAR(1)
		DECLARE @branch    NCHAR(3)
		DECLARE @yr_cd     NCHAR(2)
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
		SET @ErrMsg = ''

		BEGIN TRANSACTION
			IF ISNULL(@unld_id,0) = 0
			BEGIN

				INSERT INTO ChalUnld(chal_id, chal_rcd, deliv_dt, deliv_wt, deliv_unit, 
					shortage, sht_unit, sht_rate, sht_amt, mkt_sht)
				VALUES(@chal_id, @chal_rcd, @deliv_dt, @deliv_wt, @deliv_unit, 
					@shortage, @sht_unit, @sht_rate, @sht_amt, @mkt_sht)

				SET @Return = SCOPE_IDENTITY()

				SELECT @tl_id=tl_id,@chal_dt=chal_dt,@hire_frgt=hire_frgt,@drv_id=driv_id 
					FROM Challan 
					WHERE chal_id=@chal_id

				SELECT @Own=OWN FROM TLMAST WHERE TL_ID=@tl_id

				INSERT INTO Tltrn(tl_id, trn_code, trn_date, amount, vo_id, co_cd)
				VALUES(@tl_id, 'C', @chal_dt, @sht_amt, @chal_id, @co_cd)

				SET @Dtls=''
				SET @SubDtls=''
				SET @Sht=@sht_amt
				IF @Own=0
				BEGIN
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
				ELSE
				BEGIN
							/* DID-ID-GL_ID-AMOUNT */
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),@VI)+CONVERT(char(6),15)+CONVERT(char(12),@Sht)
					SET @Dtls=@Dtls+CONVERT(char(6),0)+CONVERT(char(6),@VI)+CONVERT(char(6),14)+CONVERT(char(12),-@Sht)
									/* SUB_DID-DID-SUB_ID-TL_ID-BILL_ID-AMOUNT-DTYPE */
					SET @SubDtls=@SubDtls+CONVERT(char(6),0)+CONVERT(char(6),-1)+CONVERT(char(6),@drv_id)+CONVERT(char(6),0)+CONVERT(char(6),0)+CONVERT(char(12),@Sht)+'S'
					SET @SubDtls=@SubDtls+CONVERT(char(6),0)+CONVERT(char(6),-2)+CONVERT(char(6),0)+CONVERT(char(6),@tl_id)+CONVERT(char(6),0)+CONVERT(char(12),-@Sht)+'T'
					EXEC s_InsertUpdateVouch 0, @chal_no, @chal_dt, 'H', '', NULL, @hire_frgt-@Sht, @CO_CD, 
						@branch, @yr_cd, @VI, 'Payment due against trip.', @Dtls, @SubDtls, @VI, @ErrMsg
				END
			END
			ELSE
			BEGIN

				UPDATE ChalUnld
				SET chal_id=@chal_id, chal_rcd=@chal_rcd, deliv_dt=@deliv_dt, deliv_wt=@deliv_wt,
					deliv_unit=@deliv_unit, shortage=@shortage, sht_unit=@sht_unit, 
					sht_rate=@sht_rate, sht_amt=@sht_amt, mkt_sht=@mkt_sht 
				WHERE unld_id=@unld_id

				SET @Return = @unld_id
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

