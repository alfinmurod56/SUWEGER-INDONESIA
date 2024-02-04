Imports System.Data.SqlClient
Imports System.Math 'pembulatan untuk waktu kerja'
Public Class ABSENSI
    Sub Status()
        If TextBox3.Text >= "9.15" Then
            TextBox5.Text = "DITERIMA"
        Else
            TextBox5.Text = "TERLAMBAT"
        End If
    End Sub


    Private Sub ABSENSI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        koneksi()

        Try

            Da = New SqlDataAdapter("Select ID_USER,NAMA_USER FROM TB_USER ORDER BY NAMA_USER", Conn)
            Dim dt As New DataTable
            Da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "NAMA_USER"
            ComboBox1.ValueMember = "ID_USER"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" And TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Nama Dan Isi Password")
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
            Else
                TextBox3.Text = DateTime.Now().ToString("hh.mm")
                Call Status()
                Call koneksi()
                Cmd = New SqlCommand("Select * From TB_ABSENSI where ID_ABSENSI in(select max(ID_ABSENSI) FROM TB_ABSENSI)", Conn)
                Dim urutankode As String
                Dim hitung As Long
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    urutankode = "AB" + "001"
                Else
                    hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                    urutankode = "AB" + Microsoft.VisualBasic.Right("000" & hitung, 3)
                End If
                TextBox4.Text = urutankode
                Button2.Enabled = False
                Button1.Enabled = True
                Call koneksi()
                Dim InputData As String = "insert into TB_ABSENSI(ID_ABSENSI,Tanggal,JAM_MASUK,ID_USER)  Values ('" & TextBox4.Text & "','" & DateTime.Now().ToString("dd MMMM yyy") & "','" & TextBox3.Text & "','" & ComboBox1.SelectedValue & "')"
                Cmd = New SqlCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                DataGridView1.Rows.Add(1)
                DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(0).Value = TextBox4.Text
                DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(1).Value = ComboBox1.Text
                DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(2).Value = TextBox3.Text
                DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(3).Value = TextBox5.Text
                TextBox4.Text = ""
                ComboBox1.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.Focus()



            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" And TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Nama Dan Isi Password")
        Else
            koneksi()
            Cmd = New SqlCommand("Select * From TB_USER Where NAMA_USER = '" & ComboBox1.Text & "' AND PASSWORD = '" & TextBox1.Text & "'", Conn)
            Dim Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Password Salah!")
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.Focus()
            Else
                TextBox2.Text = DateTime.Now().ToString("hh.mm")
                TextBox1.Text = ""
                Dim nilai As Double = Val(TextBox2.Text) - Val(TextBox3.Text)
                ComboBox1.Focus()
                Button1.Enabled = True
                Button2.Enabled = False
                Call koneksi()
                Dim EditData As String = "Update TB_ABSENSI set TANGGAL= '" & DateTime.Now.ToString("dd MMMM yyy") & "',JAM_MASUK='" & TextBox3.Text & "',JAM_PULANG='" & TextBox2.Text & "', STATUS = '" & TextBox5.Text & "', WAKTU_KERJA ='" & Round(nilai, 0) & "' WHERE ID_ABSENSI='" & TextBox4.Text & "'"
                Cmd = New SqlCommand(EditData, Conn)
                Cmd.ExecuteNonQuery()
            End If
        End If
        On Error Resume Next
        If DataGridView1.CurrentCell.Value Is Nothing Then
            MsgBox("Tidak Ada data!")
        Else
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        koneksi()
        Try
            Cmd = New SqlCommand("Select GAMBAR_USER FROM TB_USER WHERE NAMA_USER='" + ComboBox1.Text + "'", Conn)
            Dim rd = Cmd.ExecuteReader
            If rd.HasRows Then
                While rd.Read()
                    PictureBox1.ImageLocation = rd.Item("GAMBAR_USER").ToString
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    Call koneksi()
                    Dim str As String
                    str = "Select * from TB_ABSENSI where Tanggal= '" & DateTime.Now.ToString("dd MMMM yyy") & "' AND NAMA_USER ='" & ComboBox1.Text & "'"
                    Cmd = New SqlCommand(str, Conn)
                    rd = Cmd.ExecuteReader
                    rd.Read()
                    If rd.HasRows Then
                        TextBox3.Text = rd.Item("JAM_MASUK")
                        TextBox2.Text = rd.Item("JAM_PULANG")
                    Else
                        Call koneksi()
                        Cmd = New SqlCommand("Select * From TB_ABSENSI where ID_ABSENSI in(select max(ID_ABSENSI) FROM TB_ABSENSI)", Conn)
                        Dim urutankode As String
                        Dim hitung As Long
                        rd = Cmd.ExecuteReader
                        rd.Read()
                        If Not rd.HasRows Then
                            urutankode = "AB" + "001"
                        Else
                            hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 3) + 1
                            urutankode = "AB" + Microsoft.VisualBasic.Right("000" & hitung, 3)
                        End If
                        TextBox4.Text = urutankode
                    End If
                End While

            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox4.Text = DataGridView1.Item(0, i).Value
        ComboBox1.Text = DataGridView1.Item(1, i).Value
        TextBox2.Text = ""
        TextBox3.Text = DataGridView1.Item(2, i).Value
        Button2.Enabled = True
        Button1.Enabled = False
    End Sub


End Class