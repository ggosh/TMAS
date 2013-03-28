set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =================================================
-- Author:		G Ghosh
-- Create date: Mar 29,2011
-- Description:	Get Party ID by code
-- =================================================
alter PROCEDURE [dbo].[s_GetPartyByCode]
	@CO_CD			CHAR(1),
	@PCode			VARCHAR(20),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY

	SELECT tp.Gl_id
	FROM	GlMast tp
	WHERE	tp.co_cd=@CO_CD AND tp.AcCode LIKE @pCode

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read Party List'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
