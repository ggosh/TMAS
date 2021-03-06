set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jul 30,2011
-- Description:	TL exp-CREATE NEW CODE
-- =============================================
CREATE PROCEDURE [dbo].[s_NewTLexpCode]
	@Return         CHAR(1) OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Ty as CHAR(1)
		DECLARE @xTy as CHAR(1)
		DECLARE @nTy as CHAR(1)
		SET @ErrMsg = ''

		SELECT @xTy=max(expcode)
		FROM TLTexp
		SELECT @Ty=max(expcode)
		FROM TLTexp
		WHERE expcode<'C' or expcode>'D'

		IF @xTy>@Ty
			SET @nTy=@xTy
		ELSE
			SET @nTy=@Ty

		/*SET @nTy=CONVERT(CHAR(1),ASC(@nTy)+1)*/
		SET @Return=@nTy
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END
