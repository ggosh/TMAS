set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 27,2011
-- Description:	Duplicate name check -Csgr code
-- =============================================
ALTER PROCEDURE [dbo].[s_ChkDuplicateCsgrCode]
	@Csgr_id		INT = NULL,
	@CCode			NVARCHAR(10),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM Consignor
		WHERE upper(Cs_Code)=upper(@CCode) and Csgr_id<>@Csgr_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

