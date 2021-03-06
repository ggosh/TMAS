set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2009
-- Description:	Gets last no.of bills 
-- =============================================
create PROCEDURE [dbo].[s_GetMaxBillNo]
	@CO_CD			CHAR(1),
	@Type			CHAR(1),
	@sDate			DATETIME,
	@eDate			DATETIME,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT  max(b.bill_no) as Bill_No
			FROM Bill b 
			WHERE b.co_cd=@CO_CD and b.bill_type=@Type 
			and b.bill_dt>=@sDate and  b.bill_dt<=@eDate

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--'Can not read Bill list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
