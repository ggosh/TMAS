Public Class VoucherDTO
    Private _acId As Int32
    Private _voucherNo As String
    Private _voucherDate As Date
    Private _vTyp As String
    Private _chqNo As String
    Private _bankDate As Nullable(Of Date)
    Private _amt As Decimal
    Private _coCd As String
    Private _brn As String
    Private _yrCd As String
    Private _refId As Integer
    Private _narr As String
    Private _dtls As String
    Private _sDtls As String

    Public Property AcId As Int32
        Get
            Return _acId
        End Get
        Set(value As Int32)
            _acId = value
        End Set
    End Property

    Public Property VoucherNo As String
        Get
            Return _voucherNo
        End Get
        Set(value As String)
            _voucherNo = value
        End Set
    End Property

    Public Property VoucherDate As Date
        Get
            Return _voucherDate
        End Get
        Set(value As Date)
            _voucherDate = value
        End Set
    End Property

    Public Property VType As String
        Get
            Return _vTyp
        End Get
        Set(value As String)
            _vTyp = value
        End Set
    End Property

    Public Property ChqNo As String
        Get
            Return _chqNo
        End Get
        Set(value As String)
            _chqNo = value
        End Set
    End Property

    Public Property BankDate As Nullable(Of Date)
        Get
            Return _bankDate
        End Get
        Set(value As Nullable(Of Date))
            _bankDate = value
        End Set
    End Property

    Public Property Amt As Decimal
        Get
            Return _amt
        End Get
        Set(value As Decimal)
            _amt = value
        End Set
    End Property

    Public Property CoCd As String
        Get
            Return _coCd
        End Get
        Set(value As String)
            _coCd = value
        End Set
    End Property

    Public Property Brn As String
        Get
            Return _brn
        End Get
        Set(value As String)
            _brn = value
        End Set
    End Property

    Public Property YrCd As String
        Get
            Return _yrCd
        End Get
        Set(value As String)
            _yrCd = value
        End Set
    End Property

    Public Property RefId As String
        Get
            Return _refId
        End Get
        Set(value As String)
            _refId = value
        End Set
    End Property

    Public Property Narr As String
        Get
            Return _narr
        End Get
        Set(value As String)
            _narr = value
        End Set
    End Property

    Public Property Dtls As String
        Get
            Return _dtls
        End Get
        Set(value As String)
            _dtls = value
        End Set
    End Property

    Public Property SDtls As String
        Get
            Return _sDtls
        End Get
        Set(value As String)
            _sDtls = value
        End Set
    End Property
End Class