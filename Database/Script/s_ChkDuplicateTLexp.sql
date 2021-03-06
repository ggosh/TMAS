set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G.Ghosh
-- Create date: Jun 27,2011
-- Description:	Duplicate name check -TL exp
-- =============================================
create PROCEDURE [dbo].[s_ChkDuplicateTLexp]
	@TE_id			INT = NULL,
	@ExpName		NVARCHAR(50),
	@Return         INT OUTPUT,
	@ErrMsg			VARCHAR(1000)	OUTPUT
AS
BEGIN
	BEGIN TRY		

		DECLARE @Cn as INT
		SET @ErrMsg = ''

		SELECT @Cn=count(*) 
		FROM TLTexp
		WHERE upper(ExpName)=upper(@ExpName) and TE_id<>@TE_id

		SET @Return=@Cn
		RETURN

	END TRY
	BEGIN CATCH
		SET @ErrMsg = ERROR_MESSAGE()
		RAISERROR(@ErrMsg, 16, 1, 0)
		RETURN
	END CATCH
		
END

