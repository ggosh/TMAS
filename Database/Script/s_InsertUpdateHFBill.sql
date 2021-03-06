set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Feb 25,2013
-- Description:	Insert/update H/F bill
-- =============================================
ALTER PROCEDURE [dbo].[s_InsertUpdateHFBill]
	@fb_id			INT = NULL,
	@fb_no			NVARCHAR(12),
	@fb_Date		DATETIME,
	@owner_id		INT=0,
	@TL_id			INT=0,
	@Amount			DECIMAL(18,2),
	@p_amount		DECIMAL(18,2),
	@CO_CD			CHAR(1),
	@ttDtls			NVARCHAR(1000),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
		DECLARE @VI	 INT
		DECLARE @Cnt INT
		DECLARE @I   INT
		DECLARE @GLI INT

		SET @ErrMsg = ''
		BEGIN TRANSACTION
			IF ISNULL(@fb_id,0) = 0
			BEGIN

				INSERT INTO TLBill(fb_no, fb_Date, owner_id, TL_id, amount, p_amount, co_cd)
				VALUES(@fb_no, @fb_Date, @owner_id, @TL_id, @amount, @p_amount, @CO_CD)

				SET @Return = SCOPE_IDENTITY()
				SET @VI = @Return
			END
			ELSE
			BEGIN

				UPDATE TLBill
				SET fb_no=@fb_no, fb_Date=@fb_Date, owner_id=@owner_id,
				TL_id=@TL_id, amount=@amount, p_amount=@p_amount, co_cd=@CO_CD
				WHERE tlb_id=@fb_id

				SET @Return = @fb_id
				SET @VI = @fb_id
			END	
			IF (SELECT COUNT(*) FROM TLTrn WHERE tlb_id=@VI)>0
			BEGIN
				UPDATE TLTrn set tlb_id=0 WHERE tlb_id=@VI
			END
			SET @Cnt=LEN(@ttDtls)/10
			SET @I=0
			WHILE @I<@Cnt 
			BEGIN
				SET @I=@I+1
				/* tt_id */
				/* char(10) */
				SET @GLI=CONVERT(INT,SUBSTRING(@ttDtls,1,10))
				SET @ttDtls=SUBSTRING(@ttDtls,11,LEN(@ttDtls)-10)
				UPDATE TLTrn set tlb_id=@VI WHERE tt_id=@GLI
			END

		COMMIT TRANSACTION				
	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--'Can not read Bill list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
