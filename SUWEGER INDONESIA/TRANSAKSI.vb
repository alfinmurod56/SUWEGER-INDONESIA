Imports System.Data.SqlClient
Public Class TRANSAKSI
    Sub proses()
        If ComboBox1.Text = "Pilih Jenis Order" Then
            TextBox5.Enabled = False
            Button3.Enabled = False
            DataGridView1.Enabled = False
        Else
            TextBox5.Enabled = True
            Button3.Enabled = True
            DataGridView1.Enabled = True
        End If
    End Sub
    Sub Grandtotal()
        Dim jumlah As Integer = 0
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            jumlah = jumlah + DataGridView2.Rows(i).Cells(7).Value
            TextBox3.Text = jumlah
            TextBox3.Text = Format(jumlah, "###,###,###")
        Next

        If TextBox3.Text = "" Then
            TextBox3.Text = 0
        End If
    End Sub

    Sub awal()
        koneksi()
        Da = New SqlDataAdapter("Select NAMA_PRODUK,NAMA_UKURAN,HARGA,GAMBAR_PRODUK From VW_PRODUK ORDER BY NAMA_PRODUK", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "VW_PRODUK")
        DataGridView1.DataSource = (Ds.Tables("VW_PRODUK"))
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Columns(0).HeaderText = "NAMA PRODUK"
        DataGridView1.Columns(1).HeaderText = "UKURAN"
        DataGridView1.Columns(3).HeaderText = "URL GAMBAR"




    End Sub

    Sub waktu()
        'HR'
        Dim hr As String = TimeOfDay.Hour
        If hr = 1 Then
            hr = "0" + hr
        End If
        If hr = 2 Then
            hr = "0" + hr
        End If
        If hr = 3 Then
            hr = "0" + hr
        End If
        If hr = 4 Then
            hr = "0" + hr
        End If
        If hr = 5 Then
            hr = "0" + hr
        End If
        If hr = 6 Then
            hr = "0" + hr
        End If
        If hr = 7 Then
            hr = "0" + hr
        End If
        If hr = 8 Then
            hr = "0" + hr
        End If
        If hr = 9 Then
            hr = "0" + hr
        End If
        If hr = 0 Then
            hr = "0" + hr
        End If
        'MN'
        Dim mn As String = TimeOfDay.Minute
        If mn = 1 Then
            mn = "0" + mn
        End If
        If mn = 2 Then
            mn = "0" + mn
        End If
        If mn = 3 Then
            mn = "0" + mn
        End If
        If mn = 4 Then
            mn = "0" + mn
        End If
        If mn = 5 Then
            mn = "0" + mn
        End If
        If mn = 6 Then
            mn = "0" + mn
        End If
        If mn = 7 Then
            mn = "0" + mn
        End If
        If mn = 8 Then
            mn = "0" + mn
        End If
        If mn = 9 Then
            mn = "0" + mn
        End If
        If mn = 0 Then
            mn = "0" + mn
        End If
        'SC'
        Dim sc As String = TimeOfDay.Second
        If sc = 1 Then
            sc = "0" + sc
        End If
        If sc = 2 Then
            sc = "0" + sc
        End If
        If sc = 3 Then
            sc = "0" + sc
        End If
        If sc = 4 Then
            sc = "0" + sc
        End If
        If sc = 5 Then
            sc = "0" + sc
        End If
        If sc = 6 Then
            sc = "0" + sc
        End If
        If sc = 7 Then
            sc = "0" + sc
        End If
        If sc = 8 Then
            sc = "0" + sc
        End If
        If sc = 9 Then
            sc = "0" + sc
        End If
        If sc = 0 Then
            sc = "0" + sc
        End If
        TextBox2.Text = hr + "-" + mn + "-" + sc + " WIB"

    End Sub
    Private Sub TRANSAKSI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "Pilih Jenis Order"
            ComboBox1.ForeColor = Color.Gray
        End If
        proses()
        DataGridView2.Enabled = False
        awal()
        waktu()
        Grandtotal()
        TextBox4.Text = LOGIN.ComboBox1.Text
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Offline")
        ComboBox1.Items.Add("Ojek Online")
        Call koneksi()
        Cmd = New SqlCommand("select * from TB_TRANSAKSI where ID_TRANSAKSI in (select max(ID_TRANSAKSI) FROM TB_TRANSAKSI)", Conn)
        Dim urutankode As String
        Dim hitung As Long
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            urutankode = "INV/" + Format(Now, "yyMMdd") + "/01"
        Else
            hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 2) + 1
            urutankode = "INV/" + Format(Now, "yyMMdd/") + Microsoft.VisualBasic.Right("00" & hitung, 2)
        End If
        TextBox1.Text = urutankode
        ComboBox1.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        waktu()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        POPUP.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Text = ""
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Call koneksi()
        Cmd = New SqlCommand("SELECT NAMA_PRODUK,NAMA_UKURAN,HARGA,GAMBAR_PRODUK FROM VW_PRODUK WHERE NAMA_PRODUK LIKE '" & TextBox5.Text & "%'", Conn)
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call koneksi()
            Da = New SqlDataAdapter("SELECT NAMA_PRODUK,NAMA_UKURAN,HARGA,GAMBAR_PRODUK FROM VW_PRODUK WHERE NAMA_PRODUK LIKE '" & TextBox5.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Ketemu")
            DataGridView1.DataSource = Ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        DataGridView2.Rows.Clear()
        TextBox3.Text = ""
        DataGridView2.Enabled = False
    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        If DataGridView2.CurrentCell.Value Is Nothing Then
            MsgBox("Tidak Ada Pesanan!")
        Else
            PEMBAYARAN.ShowDialog()
        End If

    End Sub




    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox5.Enabled = True
        Button3.Enabled = True
        DataGridView1.Enabled = True
        ComboBox1.ForeColor = ForeColor.Black
    End Sub


    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        POPUP2.KOSONGKAN()
        If DataGridView2.CurrentCell.Value Is Nothing Then
            MsgBox("Tidak Ada Pesanan!")
        Else
            Dim i As Integer
            i = e.RowIndex
            Dim pilih As DataGridViewRow
            pilih = DataGridView2.Rows(i)
            POPUP2.TextBox1.Text = pilih.Cells(0).Value.ToString()
            POPUP2.TextBox2.Text = pilih.Cells(2).Value.ToString()
            POPUP2.TextBox3.Text = pilih.Cells(1).Value.ToString()
            POPUP2.NumericUpDown1.TextAlign = 1
            POPUP2.NumericUpDown1.Text = pilih.Cells(3).Value.ToString()
            POPUP2.Label6.Text = pilih.Cells(6).Value.ToString()
            POPUP2.PictureBox1.ImageLocation = POPUP2.Label6.Text
            POPUP2.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            POPUP2.Label6.Visible = False
            If pilih.Cells(4).Value = "Bubble" Then
                POPUP2.CheckBox1.Checked = True
            ElseIf pilih.Cells(4).Value = "Cheese Foam" Then
                POPUP2.CheckBox2.Checked = True
            ElseIf pilih.Cells(4).Value = "Oreo Crumbs" Then
                POPUP2.CheckBox3.Checked = True
            ElseIf pilih.Cells(4).Value = "Bubble" + ", " + "Cheese Foam" Then
                POPUP2.CheckBox1.Checked = True
                POPUP2.CheckBox2.Checked = True
            ElseIf pilih.Cells(4).Value = "Bubble" + ", " + "Oreo Crumbs" Then
                POPUP2.CheckBox1.Checked = True
                POPUP2.CheckBox3.Checked = True
            ElseIf pilih.Cells(4).Value = "Cheese Foam" + ", " + "Oreo Crumbs" Then
                POPUP2.CheckBox2.Checked = True
                POPUP2.CheckBox3.Checked = True
            ElseIf pilih.Cells(4).Value = "Bubble" + ", " + "Cheese Foam" + ", " + "Oreo Crumbs" Then
                POPUP2.CheckBox1.Checked = True
                POPUP2.CheckBox2.Checked = True
                POPUP2.CheckBox3.Checked = True
            Else
                POPUP2.CheckBox1.Checked = False
                POPUP2.CheckBox2.Checked = False
                POPUP2.CheckBox3.Checked = False
            End If

            POPUP2.TextBox4.Text = pilih.Cells(5).Value.ToString()

            POPUP2.ShowDialog()
        End If
    End Sub

    Private Sub ComboBox1_MouseEnter(sender As Object, e As EventArgs) Handles ComboBox1.MouseEnter
        If ComboBox1.Text = "Pilih Jenis Order" Then
            ComboBox1.Text = ""
            ComboBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ComboBox1_MouseLeave(sender As Object, e As EventArgs) Handles ComboBox1.MouseLeave
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "Pilih Jenis Order"
            ComboBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class