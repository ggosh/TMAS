set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 11,2011
-- Description:	Gets list of S/Tax
-- =============================================
ALTER PROCEDURE [dbo].[s_GetSTList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT Tax_id, Taxtype,stcode, STName, perc, edu_cess, he_cess, 
			tax_start, tax_end, form_due, taxonval
			FROM STMast
			WHERE co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+'   ORDER BY STname'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read Tax list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



