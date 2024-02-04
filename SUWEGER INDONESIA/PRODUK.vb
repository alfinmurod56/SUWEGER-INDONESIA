Imports System.Data.SqlClient
Public Class PRODUK
    Sub awal()
        Label5.Text = ""
        koneksi()
        Da = New SqlDataAdapter("Select * From VW_PRODUK ORDER BY ID_PRODUK", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "VW_PRODUK")
        DataGridView1.DataSource = (Ds.Tables("VW_PRODUK"))
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

    Sub isicombobox()
        koneksi()
        ComboBox1.Items.Clear()

        Try
            Cmd = New SqlCommand("SELECT ID_UKURAN FROM TB_UKURAN ORDER BY ID_UKURAN", Conn)
            Dim Rd As SqlDataReader
            Rd = Cmd.ExecuteReader
            While Rd.Read
                ComboBox1.Items.Add(Rd("ID_UKURAN"))
            End While

        Catch ex As Exception

        End Try

    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
    End Sub

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
            Cmd = New SqlCommand("Select * FROM TB_UKURAN WHERE ID_UKURAN='" + ComboBox1.Text + "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            If Rd.HasRows Then
                While Rd.Read()
                    TextBox4.Text = Rd("NAMA_UKURAN").ToString
                End While

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PRODUK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Enabled = False
        awal()
        matikan()
        isicombobox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Enabled = False
        If Button1.Text = "INPUT" Then
            Button1.Text = "SIMPAN"
            Call koneksi()
            Cmd = New SqlCommand("Select * From TB_PRODUK where ID_PRODUK in(select max(ID_PRODUK) FROM TB_PRODUK)", Conn)
            Dim urutankode As String
            Dim hitung As Long
            Dim rd = Cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                urutankode = "P" + "001"
            Else
                hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 3) + 1
                urutankode = "P" + Microsoft.VisualBasic.Right("000" & hitung, 3)
            End If
            TextBox1.Text = urutankode
            Button4.Enabled = False
            Button3.Enabled = False
            DataGridView1.Enabled = True
            Button5.Text = "BATAL"
            Call siapisi()

        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim InputData As String = "insert into TB_PRODUK  Values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & Label5.Text & "')"
                Cmd = New SqlCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diinput")
                Call awal()
                kosongkan()
                Button1.Text = "INPUT"
                Button5.Text = "TUTUP"
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True

            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "EDIT" Then
            Button4.Text = "SIMPAN"
            Button1.Enabled = False
            Button3.Enabled = False
            DataGridView1.Enabled = True
            Button5.Text = "BATAL"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim EditData As String = "Update TB_PRODUK set NAMA_PRODUK= '" & TextBox2.Text & "',HARGA='" & TextBox3.Text & "',ID_UKURAN='" & ComboBox1.Text & "', GAMBAR_PRODUK ='" & Label5.Text & "' WHERE ID_PRODUK='" & TextBox1.Text & "'"
                Cmd = New SqlCommand(EditData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diedit")
                Call awal()

                kosongkan()
                Button5.Text = "TUTUP"
                Button1.Text = "INPUT"
                Button4.Text = "EDIT"
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "BATAL" Then
            matikan()
        Else
            Me.Close()
            DASHBOARD.Show()
        End If
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "DELETE" Then
            Button3.Text = "SIMPAN"
            Button4.Enabled = False
            Button1.Enabled = False
            DataGridView1.Enabled = True
            Button5.Text = "BATAL"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or Label5.Text = "" Then
                MsgBox("Data Belum Lengkap!, Silahkan isi Semua Field dan Gambarnya")
            Else
                Call koneksi()
                Dim HapusData As String = "DELETE TB_PRODUK WHERE ID_PRODUK='" & TextBox1.Text & "'"
                Cmd = New SqlCommand(HapusData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Dihapus")
                Call awal()
                kosongkan()
                Button5.Text = "TUTUP"
                Button1.Text = "INPUT"
                Button3.Text = "DELETE"
                Button1.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
            End If
        End If
    End Sub

End Class