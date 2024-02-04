Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class KARYAWAN
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.Filter = "*.jpg|"
        OpenFileDialog1.ShowDialog()
        Label5.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = Label5.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        Try
            Cmd = New SqlCommand("Select * FROM TB_AKSES WHERE ID_AKSES='" + ComboBox1.Text + "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            If Rd.HasRows Then
                While Rd.Read()
                    TextBox4.Text = Rd("HAK_AKSES").ToString
                End While

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        Label5.Text = ""
        TextBox1.Focus()
        PictureBox1.ImageLocation = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "BATAL" Then
            matikan()
        Else
            Me.Close()
            DASHBOARD.Show()
        End If

    End Sub

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        Label5.Text = ""
        TextBox1.Focus()
        PictureBox1.ImageLocation = ""
    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
    End Sub
    Sub KondisiAwal()
        Label5.Text = ""
        koneksi()
        Da = New SqlDataAdapter("Select * From VW_USER ORDER BY ID_USER", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "VW_USER")
        DataGridView1.DataSource = (Ds.Tables("VW_USER"))


    End Sub

    Sub IsiComboBox()
        koneksi()
        ComboBox1.Items.Clear()

        Try
            Cmd = New SqlCommand("SELECT ID_AKSES FROM TB_AKSES ORDER BY ID_AKSES", Conn)
            Dim Rd As SqlDataReader
            Rd = Cmd.ExecuteReader
            While Rd.Read
                ComboBox1.Items.Add(Rd("ID_AKSES"))
            End While

        Catch ex As Exception

        End Try

    End Sub
    Private Sub KARYAWAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call matikan()
        Call IsiComboBox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "INPUT" Then
            Button1.Text = "SIMPAN"
            Call koneksi()
            Cmd = New SqlCommand("Select * From TB_USER where ID_USER in(select max(ID_USER) FROM TB_USER)", Conn)
            Dim urutankode As String
            Dim hitung As Long
            Dim rd = Cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                urutankode = "K" + "001"
            Else
                hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                urutankode = "K" + Microsoft.VisualBasic.Right("000" & hitung, 3)
            End If
            TextBox1.Text = urutankode
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Text = "BATAL"
            Call siapisi()

        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim InputData As String = "insert into TB_USER  Values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & Label5.Text & "')"
                Cmd = New SqlCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diinput")
                Call KondisiAwal()
                kosongkan()

            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "EDIT" Then
            Button4.Text = "SIMPAN"
            Button1.Enabled = False
            Button3.Enabled = False
            Button5.Text = "BATAL"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim EditData As String = "Update TB_USER set NAMA_USER= '" & TextBox2.Text & "',PASSWORD='" & TextBox3.Text & "',ID_AKSES='" & ComboBox1.Text & "', GAMBAR_USER ='" & Label5.Text & "' WHERE ID_USER='" & TextBox1.Text & "'"
                Cmd = New SqlCommand(EditData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diedit")
                Call KondisiAwal()
                kosongkan()
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "DELETE" Then
            Button3.Text = "SIMPAN"
            Button4.Enabled = False
            Button1.Enabled = False
            Button5.Text = "BATAL"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim HapusData As String = "DELETE TB_USER WHERE ID_USER='" & TextBox1.Text & "'"
                Cmd = New SqlCommand(HapusData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus")
                Call KondisiAwal()
                kosongkan()
            End If
        End If
    End Sub


    Sub matikan()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
        Button1.Text = "INPUT"
        Button4.Text = "EDIT"
        Button3.Text = "DELETE"
        Button5.Text = "TUTUP"
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        kosongkan()
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New SqlCommand("Select * From VW_USER where ID_USER='" & TextBox1.Text & "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox2.Text = Rd.Item("NAMA_USER")
                TextBox3.Text = Rd.Item("PASSWORD")
                ComboBox1.Text = Rd.Item("ID_USER")
                Label5.Text = Rd.Item("GAMBAR_USER")
                TextBox4.Text = Rd.Item("HAK_AKSES")
                PictureBox1.ImageLocation = Label5.Text
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(5, i).Value
        ComboBox1.Text = DataGridView1.Item(3, i).Value
        Label5.Text = DataGridView1.Item(4, i).Value
        PictureBox1.ImageLocation = Label5.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub


End Class