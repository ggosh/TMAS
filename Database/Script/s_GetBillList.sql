set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Dec 21,2009
-- Description:	Gets list of bills 
-- =============================================
ALTER PROCEDURE [dbo].[s_GetBillList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT  b.bill_id, b.bill_dt as Date, b.bill_no as Bill, b.Amount, 
			b.bill_type as Type, p.AcName as Party
			FROM Bill b INNER JOIN Glmast p ON b.gl_id=p.gl_id
			WHERE b.co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY b.bill_dt desc,b.bill_no desc'

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
