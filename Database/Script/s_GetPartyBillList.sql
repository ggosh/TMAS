set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2009
-- Description:	Gets list of bills for a party
-- =============================================
ALTER PROCEDURE [dbo].[s_GetPartyBillList]
	@CO_CD			CHAR(1),
	@GL_ID			INT,
	@ASON			DATETIME,
	@ONLYBAL		BIT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT  b.bill_id, b.bill_dt as Date, b.bill_no as Bill, b.Amount
			FROM Bill b 
			WHERE b.co_cd='''+@CO_CD+''' AND b.gl_id=' + convert(varchar(20),@GL_ID) +
 			' AND b.bill_dt<=''' + 	convert(varchar(20),@ASON,103) + ''''

	SET @SSQL=@SSQL+' ORDER BY b.bill_dt desc,b.bill_no desc'

	print(@SSQL);
	exec(@SSQL);

	RETURN
END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--'Can not read Bill list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
