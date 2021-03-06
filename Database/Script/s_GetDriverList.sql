set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: July 11,2011
-- Description:	Gets list of Drivers
-- =============================================
ALTER PROCEDURE [dbo].[s_GetDriverList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT s.sub_id,s.subname as Name,s.subtype,s.YrOpen,s.status
				FROM SubMast s 
				WHERE s.co_cd='''+@CO_CD+''' AND s.sgr_id=1'

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND ('+@Filt+')'
	END

	SET @SSQL=@SSQL+' ORDER BY s.SubName'
	print(@SSQL);
	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read Driver list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END



