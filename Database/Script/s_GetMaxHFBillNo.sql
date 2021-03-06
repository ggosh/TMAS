set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Feb 25,2013
-- Description:	Gets last no.of H/F bills 
-- =============================================
CREATE PROCEDURE [dbo].[s_GetMaxHFBillNo]
	@CO_CD			CHAR(1),
	@sDate			DATETIME,
	@eDate			DATETIME,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT  max(b.fb_no) as Bill_No
			FROM TLBill b 
			WHERE b.co_cd=@CO_CD and b.fb_date>=@sDate and  b.fb_date<=@eDate

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--'Can not read Bill list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END


