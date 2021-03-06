set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: Jan 11,2010
-- Description:	Gets list of Parties(for combo)
-- =============================================
ALTER PROCEDURE [dbo].[s_GetPartyList]
	@CO_CD			CHAR(1),
	@Filt			VARCHAR(1000),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	DECLARE @SSQL	VARCHAR(2000);
	DECLARE @CSP	BIT;

	SELECT @CSP=CashParty from CoMain where Co_Id=convert(integer,@CO_CD)

	SET @SSQL='SELECT g.GL_id, g.AcName AS Name
  FROM ([GLmast] g JOIN [Grpmast] gr ON g.grp_id=gr.Grp_id)
  WHERE g.co_cd='''+@CO_CD 
	+''' AND gr.Grpcode LIKE ''DA%'''
	IF @CSP=1
	BEGIN
		SET @SSQL=@SSQL+' or g.gl_id=1'
	END

	IF LEN(@Filt)>0
	BEGIN
		SET @SSQL=@SSQL+' AND '+@Filt
	END

	SET @SSQL=@SSQL+' ORDER BY g.AcName'

	exec(@SSQL);

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = ERROR_MESSAGE()
--'Can not read Party list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

