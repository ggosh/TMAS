set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: May 27,2011
-- Description:	Duplicate name check -Csge code
-- =============================================
ALTER PROCEDURE [dbo].[s_ChkDuplicateCsgeCode]
	@Csge_id		INT = NULL,
	@CCode			NVARCHAR(15),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM Consignee
		WHERE upper(Csge_Code)=upper(@CCode) and Csge_id<>@Csge_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

