set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of A/c groups
-- =============================================
ALTER PROCEDURE [dbo].[s_GetGrpList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);

	SET @SSQL='SELECT Grp_id, GrpCode, GrpName, Status, SchNo 
  FROM GrpMast WHERE co_cd='''+@CO_CD+''''

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND '+@Filt
	END

	SET @SSQL=@SSQL+' ORDER BY GrpName'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read A/c group list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
