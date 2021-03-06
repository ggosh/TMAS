set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Mov 30,2009
-- Description:	Details of a a/c head
-- =============================================
ALTER PROCEDURE [dbo].[s_GetGLDetails]
	@GL_id			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		SET @ErrMsg = ''

		SELECT g.GL_id, g.AcName, g.grp_id, g.yrOpen, g.opBal, g.LyBal,g.HasSub, g.status, 
		g.co_cd, g.Accode, g.IT_file, g.RC_No, g.VAT_No, g.ECC_No, g.Addr, g.ph_no, 
		g.Bill_addr, g.ref_no, g.encl, g.attn, g.kattn, g.dest_id, r.GrpName 
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

