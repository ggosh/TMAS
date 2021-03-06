set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Apr 30,2011
-- Description:	Status & Grpcode Details of a a/c head
-- =============================================
CREATE PROCEDURE [dbo].[s_GetGLType]
	@GL_id			INT,
	@Return			NCHAR(5)		OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT @Return=g.status + r.GrpCode
		FROM GLmast g INNER JOIN GrpMast r ON g.grp_id=r.grp_id
		WHERE g.GL_id=@GL_id

		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

