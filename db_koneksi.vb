Imports System.Data
Imports System.Data.SqlClient

Namespace Koneksi
    Public Class db_koneksi

        Dim Connection As New SqlConnection("Data Source=TRISNANDA\SQLEXPRESS;Initial Catalog=Db_TI_Malam;Integrated Security=True")

        Public Function Open() As SqlConnection
            Connection.Open()
            Return Connection
        End Function

        Public Sub Close()
            Connection.Close()
        End Sub

    End Class
End Namespace


