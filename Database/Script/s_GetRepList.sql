set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 11,2011
-- Description:	Gets list of Reps
-- =============================================
create PROCEDURE [dbo].[s_GetRepList]
	@CO_CD			CHAR(1),
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
SELECT c.Rep_id,c.RepName 
  FROM Rep c 
  WHERE c.co_cd=@CO_CD
  ORDER BY c.Repname

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read Rep list'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END

