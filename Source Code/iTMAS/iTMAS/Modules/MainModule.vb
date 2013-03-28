Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
'Imports System
'Imports System.Data
'Imports System.Data.OleDb

Public Enum OpenModeEnum
    Add = 0
    Edit = 1
    Delete = 2
    View = 3
End Enum
Public Enum TimeType
    Hour12 = 0
    Hour24 = 1
End Enum

Public Enum iRotate
    NoRotate = 0
    Rotate90cw = 1
    Rotate90cc = -1
End Enum
'Public Structure SelectionDateRange
'    Dim FromDate As Date
'    Dim ToDate As Date
'End Structure

Module Module1

#Region " Public Variables "
    'Public fGatePass As FrmGatePass
    Public flog As FrmLogin
    Public dt As DataSet
    Public sConnString As String
    'Public DBConnectionObj As New OleDb.OleDbConnection
    'Public Shared DBConnectionObj As SqlClient.SqlConnection = New SqlClient.SqlConnection("data source=" & Trim(Glb_ServerName) & ";initial catalog=" & Trim(Glb_DBName) & ";uid=" & Trim(Glb_UserName) & ";pwd=" & Trim(Glb_Password))
    'Public ErrorMsg As String

    'Public fReport As FrmReport
    'Public fVRport As FrmReport2
    'Public fVenRpt As FrmReport3
    Public Glb_RptName As String
    Public Astr As String

    Public Glb_Image As Byte()
    Public Glb_User_Id As Long
    Public GLB_UserType As String
    Public Glb_ServerName As String
    Public Glb_DBName As String
    Public Glb_UserName As String
    Public Glb_Password As String
    Public Glb_CurrentSalesOrder As String
    Public Glb_CurrentPurchaseOrder As String
    Public ConfFile As String = Application.StartupPath & "\database\CapConfig.txt"
    Public RunExePath As String = ""
    Public PixSavPath As String = ""
    Public ImgRotate As iRotate = iRotate.NoRotate
    Public click_Time As Date

    Public sel As New Integer
    Public gatepassno As String
    Public gtype As String
    Public stay As String
    Public from As String
    Public gto As String
    Public ename As String
    Public fname As String
    Public cname As String
    Public desg As String
    Public esi As String
    Public dob As String
    Public doj As String
    Public dept As String
    Public srvy As Boolean
    Public gdays As String
    Public ecode As String

    Public ptov As String
    Public prps As String
    Public addr As String
    Public tiin As String
    'Dta.Tables(0).Columns.Add("img", System.Type.GetType("System.Byte[]"))
    'Dta.Tables(0).Columns.Add("GPNO", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("GPDATE", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("NAME", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("Company", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("DESIGNATION", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("PERSONTO", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("PURPOSE", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("TimeIN", System.Type.GetType("System.String"))
    'Dta.Tables(0).Columns.Add("GPTYPE", System.Type.GetType("System.String"))

    Public connstr As String = ("Initial Catalog=" & Glb_DBName & ";Data Source=" & Glb_ServerName & ";User id=" & Glb_UserName & ";pwd=" & Glb_Password)

    'Public Glb_CurrentDealerId As Long = 0
    'Public GLB_CallerFormName As String = ""
    'Public GLB_ShippingId As Long = 0
    'Public GLB_CmpID As Long = 0
    'Public Astr As String
    'Public Glb_RptName As String

#End Region

    Public Sub main()

    End Sub

    Public Function Get_Latest_Photo_File(ByVal str_path As String) As String
        Try
            Dim sDir As String = str_path
            Dim dDir As New DirectoryInfo(sDir)
            Dim fsInfo As FileSystemInfo
            Dim cT As DateTime, Tle As DateTime

            For Each fsInfo In dDir.GetFileSystemInfos()
                Try
                    If TypeOf fsInfo Is FileInfo Then

                        Dim fInfo As FileInfo = CType(fsInfo, FileInfo)

                        cT = fInfo.CreationTime
                        Tle = fInfo.LastWriteTime
                        If cT >= click_Time Or Tle >= click_Time Then
                            Get_Latest_Photo_File = fInfo.FullName
                            Exit Function
                        End If
                    End If
                Catch e1 As Exception
                    MessageBox.Show(e1.Message, "FileInfo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Get_Latest_Photo_File = ""
                    Exit Function
                End Try
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Get_Latest_Photo_File = ""
            Exit Function
        End Try
        Get_Latest_Photo_File = ""

    End Function

    '' Execute the creation of Stored Procedures
    'Sub CreateStoredProc(ByVal sSQL As String)
    '    Dim con As OleDbConnection
    '    Dim cmd As OleDbCommand = New OleDbCommand()
    '    'Dim da As OleDbDataAdapter

    '    ' Change Data Source to the location of Northwind.mdb on your local 
    '    ' system.
    '    'Dim sConStr As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data " _
    '    '    & "Source=C:\Program Files\Microsoft " _
    '    '    & "Office\Office10\Samples\Northwind.mdb"
    '    Dim sConStr As String = _
    '                "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    '                "Data Source=" & Application.StartupPath & "\Database\CONTRACTOR.mdb;" & _
    '                "User ID=Admin;" & _
    '                "Password="

    '    con = New OleDbConnection(sConStr)

    '    cmd.Connection = con
    '    cmd.CommandText = sSQL

    '    con.Open()
    '    cmd.ExecuteNonQuery()
    '    con.Close()

    'End Sub
    Public Function CheckDB() As Boolean
        CheckDB = False
        CheckDB = True

    End Function

    'Sub ProductsProcs()
    '    Dim sSQL As String

    '    '' procProductsList - Retrieves entire table
    '    'sSQL = "CREATE PROC procProductsList AS SELECT * FROM CONTRACTOR;"
    '    'CreateStoredProc(sSQL)

    '    ' procProductsDeleteItem - Returns the details (one record) from the 
    '    ' JobTitle table
    '    'sSQL = "CREATE PROC procProductsDeleteItem(@ProductID LONG) AS " _
    '    '    & "DELETE FROM CONTRACTOR WHERE SLID = @ProductID;"
    '    'CreateStoredProc(sSQL)

    '    '' procProductsAddItem - Add one record to the JobTitle table
    '    'sSQL = "CREATE PROC procProductsAddItem(inProductName VARCHAR(40), " _
    '    '    & "inSupplierID VARCHAR(40), inCategoryID VARCHAR(40)) AS INSERT INTO " _
    '    '    & "CONTRACTOR (NAMEOFEMPLOYEE,NAMEOFCONTRACTOR,address) Values " _
    '    '    & "(inProductName, inSupplierID,   CategoryID);"
    '    'CreateStoredProc(sSQL)

    '    '' procProductsAddItem - Add one record to the JobTitle table
    '    'sSQL = "CREATE PROC procContractorAddItem(inNAMEOFEMPLOYEE VARCHAR(50),inNAMEOFCONTRACTOR VARCHAR(50),inaddress VARCHAR(250),inFATHERSNAME VARCHAR(50),inDATEOFBIRTH Date,inDESIGNATION VARCHAR(50),inDATEOFJOINING date,inLASTDESIGNATION VARCHAR(50),inLASTPROMOTIONDATE date,inDATEOFSEPARATION date,inESINO VARCHAR(50),inESIVALIDUPTO date,inGATEPASSNO VARCHAR(50),inGATEPASSRENEWEDON date,inGATEPASSVALIDUPTO date,inDEPTTOWHICHATTACHED VARCHAR(50),inREMARKS VARCHAR(50),inGPTYPE VARCHAR(50),inGPDAYS VARCHAR(50),inPicture VARCHAR(250),inSTATUS VARCHAR(50)" _
    '    '    & ") AS INSERT INTO " _
    '    '    & "CONTRACTOR (NAMEOFEMPLOYEE,NAMEOFCONTRACTOR,address, FATHERSNAME,DATEOFBIRTH,DESIGNATION,DATEOFJOINING,LASTDESIGNATION,LASTPROMOTIONDATE,DATEOFSEPARATION,ESINO,ESIVALIDUPTO,GATEPASSNO,GATEPASSRENEWEDON,GATEPASSVALIDUPTO,DEPTTOWHICHATTACHED,Survey,REMARKS,GPTYPE,GPDAYS,GPNIGHT,Picture,STATUS) Values " _
    '    '    & "(inNAMEOFEMPLOYEE,inNAMEOFCONTRACTOR,inaddress,inFATHERSNAME,inDATEOFBIRTH,inDESIGNATION,inDATEOFJOINING,inLASTDESIGNATION,inLASTPROMOTIONDATE,inDATEOFSEPARATION,inESINO,inESIVALIDUPTO,inGATEPASSNO,inGATEPASSRENEWEDON,inGATEPASSVALIDUPTO,inDEPTTOWHICHATTACHED,inREMARKS,inGPTYPE,inGPDAYS,inPicture,inSTATUS);"
    '    'CreateStoredProc(sSQL)

    '    ' procProductsAddItem - Add one record to the JobTitle table
    '    sSQL = "CREATE PROC procContractorAddItem(inNAMEOFEMPLOYEE VARCHAR(50),inNAMEOFCONTRACTOR VARCHAR(50),inaddress VARCHAR(250),inFATHERSNAME VARCHAR(50),inDESIGNATION VARCHAR(50),inLASTDESIGNATION VARCHAR(50),inESINO VARCHAR(50),inGATEPASSNO VARCHAR(50),inDEPTTOWHICHATTACHED VARCHAR(50),inREMARKS VARCHAR(50),inGPTYPE VARCHAR(50),inGPDAYS VARCHAR(50),inPicture VARCHAR(250),inSTATUS VARCHAR(50)" _
    '        & ") AS INSERT INTO " _
    '        & "CONTRACTOR (NAMEOFEMPLOYEE,NAMEOFCONTRACTOR,address, FATHERSNAME,DESIGNATION,LASTDESIGNATION,ESINO,GATEPASSNO,DEPTTOWHICHATTACHED,REMARKS,GPTYPE,GPDAYS,Picture,STATUS) Values " _
    '        & "(inNAMEOFEMPLOYEE,inNAMEOFCONTRACTOR,inaddress,inFATHERSNAME,inDESIGNATION,inLASTDESIGNATION,inESINO,inGATEPASSNO,inDEPTTOWHICHATTACHED,inREMARKS,inGPTYPE,inGPDAYS,inPicture,inSTATUS);"
    '    CreateStoredProc(sSQL)

    '    ' procProductsUpdateItem - Update one record on the JobTitle table
    '    'sSQL = "CREATE PROC procProductsUpdateItem(inProductID LONG, " _
    '    '    & "inProductName VARCHAR(40)) AS UPDATE Products SET " _
    '    '    & "ProductName = inProductName WHERE ProductID = inProductID;"
    '    'CreateStoredProc(sSQL)


    '  End Sub
End Module
