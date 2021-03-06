set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 30,2009
-- Description:	Details of a a/c sub head
-- =============================================
ALTER PROCEDURE [dbo].[s_GetSubDetails]
	@Sub_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT g.Sub_id, g.SubName, g.Sgr_id, g.subtype, g.yrOpen, 
		g.opBal, g.LyBal, g.status, g.co_cd, g.Accode, g.IT_file, 
		g.RC_No, g.VAT_No, g.Addr, g.ph_no, r.SGrName 
		FROM SubMast g INNER JOIN SubGrMast r ON g.sgr_id=r.sgr_id
		WHERE g.Sub_id=@Sub_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
