Imports System.Data.SqlClient
Public Class LOGIN
    Sub TerbukaManager()
        DASHBOARD.LoginToolStripMenuItem.Enabled = False
        DASHBOARD.LogoutToolStripMenuItem.Enabled = True
        DASHBOARD.ExitToolStripMenuItem.Enabled = True
        DASHBOARD.TransaksiToolStripMenuItem.Enabled = True
        DASHBOARD.MasterToolStripMenuItem.Enabled = True
        DASHBOARD.LaporanToolStripMenuItem.Enabled = True
        DASHBOARD.AbsensiToolStripMenuItem.Enabled = True
        DASHBOARD.AboutToolStripMenuItem.Enabled = True
    End Sub

    Sub TerbukaSPV()
        DASHBOARD.LoginToolStripMenuItem.Enabled = False
        DASHBOARD.LogoutToolStripMenuItem.Enabled = True
        DASHBOARD.ExitToolStripMenuItem.Enabled = True
        DASHBOARD.TransaksiToolStripMenuItem.Enabled = True
        DASHBOARD.MasterToolStripMenuItem.Enabled = False
        DASHBOARD.LaporanToolStripMenuItem.Enabled = True
        DASHBOARD.AbsensiToolStripMenuItem.Enabled = True
        DASHBOARD.AboutToolStripMenuItem.Enabled = True
    End Sub

    Sub TerbukaKasir()
        DASHBOARD.LoginToolStripMenuItem.Enabled = False
        DASHBOARD.LogoutToolStripMenuItem.Enabled = True
        DASHBOARD.ExitToolStripMenuItem.Enabled = True
        DASHBOARD.TransaksiToolStripMenuItem.Enabled = True
        DASHBOARD.MasterToolStripMenuItem.Enabled = False
        DASHBOARD.LaporanToolStripMenuItem.Enabled = False
        DASHBOARD.AbsensiToolStripMenuItem.Enabled = True
        DASHBOARD.AboutToolStripMenuItem.Enabled = True
    End Sub



    Private Sub ComboBox1_MouseEnter(sender As Object, e As EventArgs) Handles ComboBox1.MouseEnter
        If ComboBox1.Text = "Pilih Nama" Then
            ComboBox1.Text = ""
            ComboBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ComboBox1_MouseLeave(sender As Object, e As EventArgs) Handles ComboBox1.MouseLeave
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "Pilih Nama"
            ComboBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TextBox1.Text = "" Then
            TextBox1.Text = "Masukkan Password"
            TextBox1.ForeColor = Color.Gray
        End If
        koneksi()
        ComboBox1.Items.Clear()

        Try
            Cmd = New SqlClient.SqlCommand("SELECT NAMA_USER FROM TB_USER ORDER BY NAMA_USER", Conn)
            Dim Rd As SqlDataReader
            Rd = Cmd.ExecuteReader
            While Rd.Read
                ComboBox1.Items.Add(Rd("NAMA_USER"))
            End While

        Catch ex As Exception

        End Try




    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" And TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Nama Akses Dan Isi Password")
        Else
            koneksi()
            Cmd = New SqlCommand("Select * From TB_USER Where NAMA_USER = '" & ComboBox1.Text & "' AND PASSWORD = '" & TextBox1.Text & "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Password Salah!")
                ComboBox1.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.Focus()
            Else Me.Close()
                If TextBox2.Text = "MANAGER" Then
                    TerbukaManager()
                ElseIf TextBox2.Text = "SPV" Then
                    TerbukaSPV()
                Else
                    TerbukaKasir()
                End If
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        Try
            Cmd = New SqlClient.SqlCommand("Select * FROM VW_USER WHERE NAMA_USER='" + ComboBox1.Text + "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            If Rd.HasRows Then
                While Rd.Read()
                    TextBox2.Text = Rd("HAK_AKSES").ToString
                End While

            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub TextBox2_MouseEnter(sender As Object, e As EventArgs) Handles TextBox2.MouseEnter
        If TextBox2.Text = "HAK AKSES" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.Text = "" Then
            TextBox2.Text = "HAK AKSES"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "●"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Focus()
        DASHBOARD.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        If TextBox1.Text = "Masukkan Password" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Masukkan Password"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.PasswordChar = "●"
        TextBox1.ForeColor = Color.Black
    End Sub
End Class