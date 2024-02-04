Imports System.Data.SqlClient
Public Class LABSENSI
    Sub awal()
        koneksi()
        Da = New SqlDataAdapter("Select * From VW_ABSENSI order by tanggal desc ", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "VW_ABSENSI")
        DataGridView1.DataSource = (Ds.Tables("VW_ABSENSI"))
    End Sub

    Private Sub LABSENSI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd MMMM yyy"
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        awal()
        DateTimePicker1.Text = Today
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd MMMM yyy"
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Cmd = New SqlCommand("SELECT * FROM VW_ABSENSI WHERE TANGGAL LIKE '" & DateTimePicker1.Text & "%'", Conn)
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call koneksi()
            Da = New SqlDataAdapter("SELECT * FROM VW_ABSENSI WHERE TANGGAL LIKE '" & DateTimePicker1.Text & "%'", Conn)
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
        Cmd = New SqlCommand("SELECT * FROM VW_ABSENSI WHERE NAMA_USER LIKE '" & TextBox1.Text & "%'", Conn)
        Dim rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call koneksi()
            Da = New SqlDataAdapter("SELECT * FROM VW_ABSENSI WHERE NAMA_USER LIKE '" & TextBox1.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Ketemu")
            DataGridView1.DataSource = Ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub
End Class