Imports System.Data.SqlClient
Public Class LPENJUALAN
    Sub awal()
        koneksi()
        Da = New SqlDataAdapter("Select ID_TRANSAKSI,WAKTU_ORDER,KASIR,PENJUALAN,JENIS_ORDER,JENIS_PEMBAYARAN FROM TB_TRANSAKSI ", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "TB_TRANSAKSI")
        DataGridView1.DataSource = (Ds.Tables("TB_TRANSAKSI"))
    End Sub

    Private Sub LPENJUALAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd MMMM yyy"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Cmd = New SqlCommand("SELECT ID_TRANSAKSI,WAKTU_ORDER,KASIR,PENJUALAN,JENIS_ORDER,JENIS_PEMBAYARAN FROM TB_TRANSAKSI WHERE WAKTU_ORDER LIKE '" & DateTimePicker1.Text & "%'", Conn)
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call koneksi()
            Da = New SqlDataAdapter("SELECT ID_TRANSAKSI,WAKTU_ORDER,KASIR,PENJUALAN,JENIS_ORDER,JENIS_PEMBAYARAN FROM TB_TRANSAKSI WHERE WAKTU_ORDER LIKE '" & DateTimePicker1.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Ketemu")
            DataGridView1.DataSource = Ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        ElseIf Not rd.HasRows Then
            MsgBox("Tidak Ada Data Yang Cocok!")
            awal()
            DateTimePicker1.Text = Today
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "dd MMMM yyy"

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        awal()
        DateTimePicker1.Text = Today
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd MMMM yyy"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call koneksi()
        Cmd = New SqlCommand("SELECT * FROM TB_TRANSAKSI WHERE ID_TRANSAKSI LIKE '" & TextBox1.Text & "%'", Conn)
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call koneksi()
            Da = New SqlDataAdapter("SELECT * FROM TB_TRANSAKSI WHERE ID_TRANSAKSI LIKE '" & TextBox1.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Ketemu")
            DataGridView1.DataSource = Ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub
End Class