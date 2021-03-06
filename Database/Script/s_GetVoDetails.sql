set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		G Ghosh
-- Create date: Mar 21,2011
-- Description:	Gets A/c voucher details
-- =============================================
ALTER PROCEDURE [dbo].[s_GetVoDetails]
	@AC_ID			INT,
	@ErrMsg			VARCHAR(1000)	OUTPUT 
AS
BEGIN
BEGIN TRY
	
	SELECT a.ac_id,a.vo_no, a.vo_dt, a.type, a.chq_no, a.bank_dt, a.amount, a.narr,
		a.co_cd, a.branch, a.uid, a.edate, a.upuids 
		FROM Acmast a 
		WHERE a.ac_id=@AC_ID

	SELECT b.ac_did, b.gl_id, 'DrCr'= CASE WHEN b.amount<0 THEN 'Cr' ELSE 'Dr' END,
		g.AcName AS Account, 'DrAmt'= CASE WHEN b.amount<0 THEN 0.00 ELSE abs(b.amount) END, 
		'CrAmt'= CASE WHEN b.amount<0 THEN abs(b.amount) ELSE 0.00 END,
		0.00 AS Balance, gr.grpcode, g.status
		FROM ((AcDtl b INNER JOIN GlMast g ON b.gl_id=g.gl_id)INNER JOIN GrpMast gr ON g.grp_id=gr.grp_id)
		WHERE b.ac_id=@AC_ID

	SELECT c.sub_did, c.ac_did, c.bill_id, b.bill_no, b.bill_dt, b.amount, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN bill b ON c.bill_id=b.bill_id)
		WHERE c.dtype='B' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	SELECT c.sub_did, c.ac_did, c.tl_id, t.tl_code, t.tl_no, '' as TT, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN TlMast t ON c.tl_id=t.tl_id)
		WHERE c.dtype='T' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	SELECT c.sub_did, c.ac_did, c.sub_id, s.SubName, s.AcCode as SubCode, '' as Su, 
		c.amount as Adjusted
		FROM (acSubDtl c INNER JOIN SubMast s ON c.sub_id=s.sub_id)
		WHERE c.dtype='S' and c.ac_did in (select ac_did from AcDtl where ac_id=@AC_ID)

	RETURN

END TRY
BEGIN CATCH
	SET @ErrMsg = 'Can not read A/c voucher'
	RAISERROR(@ErrMsg, 16, 1, 0)
	RETURN
END CATCH
END
