Imports System.Data
Imports System.Data.SqlClient

Public Class Form_Login

    Private Sub username_field_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_username.KeyUp
        If e.KeyCode = Keys.Enter Then
            txt_password.Focus()
        End If
    End Sub

    Private Sub password_field_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_password.KeyUp
        If e.KeyCode = Keys.Enter Then
            button_login.Focus()
        End If
    End Sub

    Private Sub button_login_Click(sender As System.Object, e As System.EventArgs) Handles button_login.Click
        On Error Resume Next
        Dim ObjCmd As New SqlCommand
        Dim ObjDataset As New DataSet
        Dim Objreader As SqlDataReader
        Dim Connection As New Koneksi.db_koneksi
        Dim User As String
        Dim Pass As String

        If txt_username.Text = "" Or txt_password.Text Then
            MsgBox("Username dan Password Anda salah!", MsgBoxStyle.Exclamation, "Kesalahan!!!")
            Exit Sub
        End If

        ObjCmd = Connection.Open.CreateCommand
        ObjCmd.CommandText = ("Select * From Tbl_Login where user='" & txt_username.Text & "' and pass='" & _
                              txt_password.Text & "'")
        Objreader = ObjCmd.ExecuteReader
        Objreader.Read()
        User = Objreader.Item("username")
        Pass = Objreader.Item("password")
        Connection.Close()

        If User = "" Or Pass = "" Then
            MsgBox("Akses Ditolak!", vbCritical, "Akses .....")
            Exit Sub
        Else
            Me.Hide()
            Dim Frm As New Form_Menu_Utama
            Frm.Show()
            txt_username.Text = ""
            txt_password.Text = ""

        End If




    End Sub
End Class
