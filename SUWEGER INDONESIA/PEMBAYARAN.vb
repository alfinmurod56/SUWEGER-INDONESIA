Imports System.Data.SqlClient
Public Class PEMBAYARAN
    Sub kosongkan()
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox8.Text = ""
    End Sub
    Sub mati()
        Button23.Enabled = False
        Button26.Enabled = False
        GroupBox4.Enabled = False
    End Sub

    Sub kembalian()
        TextBox10.Text = TextBox11.Text - TextBox7.Text

    End Sub
    Sub uang()
        Dim jumlah As Integer = 0
        If TextBox7.Text <= 50000 Then
            Button3.Text = 50000
            Button4.Text = 100000
        ElseIf TextBox7.Text > 50000 And TextBox7.Text <= 100000 Then
            Button3.Text = 100000
            Button4.Text = 150000
        ElseIf TextBox7.Text > 100000 And TextBox7.Text <= 150000 Then
            Button3.Text = 150000
            Button4.Text = 200000
        ElseIf TextBox7.Text > 150000 And TextBox7.Text <= 200000 Then
            Button3.Text = 200000
            Button4.Text = 250000
        ElseIf TextBox7.Text > 200000 And TextBox7.Text <= 250000 Then
            Button3.Text = 250000
            Button4.Text = 300000
        ElseIf TextBox7.Text > 250000 And TextBox7.Text <= 300000 Then
            Button3.Text = 300000
            Button4.Text = 350000
        ElseIf TextBox7.Text > 300000 And TextBox7.Text <= 350000 Then
            Button3.Text = 350000
            Button4.Text = 400000
        ElseIf TextBox7.Text > 350000 And TextBox7.Text <= 400000 Then
            Button3.Text = 400000
            Button4.Text = 450000
        ElseIf TextBox7.Text > 400000 And TextBox7.Text <= 450000 Then
            Button3.Text = 450000
            Button4.Text = 500000
        ElseIf TextBox7.Text > 450000 And TextBox7.Text <= 500000 Then
            Button3.Text = 500000
            Button4.Text = 550000
        End If
    End Sub

    Sub hitungproduk()
        Dim hitung As Integer
        For baris As Integer = 0 To TRANSAKSI.DataGridView2.RowCount - 1
            hitung = hitung + TRANSAKSI.DataGridView2.Rows(baris).Cells(3).Value
        Next
        TextBox2.Text = CType(hitung, String) + " Produk"
    End Sub

    Sub detail()
        TextBox1.Text = TRANSAKSI.TextBox1.Text
        hitungproduk()
        TextBox3.Text = TRANSAKSI.ComboBox1.Text
        TextBox5.Text = TRANSAKSI.TextBox4.Text
        TextBox4.Text = TRANSAKSI.TextBox2.Text
        TextBox7.Text = CType(TRANSAKSI.TextBox3.Text, Integer)
    End Sub
    Dim operasihitung As Boolean = False
    Dim jumlah As Integer = 0
    Private Sub PEMBAYARAN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kosongkan()
        detail()
        uang()
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        GroupBox5.Enabled = False
        TextBox6.Text = ""
        TextBox6.TextAlign = TextBox6.TextAlign.Right



    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "1"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "1"
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "2"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "2"
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "3"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "3"
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "4"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "4"
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "5"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "5"
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "6"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "6"
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "7"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "7"
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "8"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "8"
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "9"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "9"
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If operasihitung = True Or TextBox6.Text = "0" Then
            TextBox6.Text = "0"
            operasihitung = False
        Else
            TextBox6.Text = TextBox6.Text + "0"
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        TextBox6.Text = "0"

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        If TextBox6.Text.Length <> 0 And TextBox6.Text <> 1 And TextBox6.Text <> 2 And TextBox6.Text <> 3 And
            TextBox6.Text <> 4 And TextBox6.Text <> 5 And TextBox6.Text <> 6 And TextBox6.Text <> 7 And TextBox6.Text <> 8 And TextBox6.Text <> 9 And TextBox6.Text <> 0 Then
            TextBox6.Text = TextBox6.Text.Remove(TextBox6.Text.Length - 1)
        Else
            TextBox6.Text = "0"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox6.Text = "0"
        GroupBox5.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox6.Text = ""
        GroupBox5.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = Button12.Text
        TextBox11.Text = TextBox7.Text
        kembalian()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = Button11.Text
        TextBox11.Text = TextBox7.Text
        kembalian()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = Button10.Text
        TextBox11.Text = TextBox7.Text
        kembalian()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = Button9.Text
        TextBox11.Text = TextBox7.Text
        kembalian()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = "Tunai"
        TextBox11.Text = TextBox7.Text
        kembalian()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = "Tunai"
        TextBox11.Text = Button3.Text
        kembalian()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        TextBox8.Text = "Tunai"
        TextBox11.Text = Button4.Text
        kembalian()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox5.Enabled = False
        If TextBox6.Text < TextBox7.Text Then
            MsgBox("Pembayaran Kurang!")
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            GroupBox5.Enabled = True
        Else
            TextBox8.Text = "Tunai"
            TextBox11.Text = TextBox6.Text
            kembalian()
            TextBox6.Text = ""
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            GroupBox5.Enabled = False
        End If

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Close()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        TextBox6.Text = ""
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        kosongkan()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        koneksi()
        Dim simpandata As String = "insert into TB_TRANSAKSI values('" & TextBox1.Text & "','" & Today.ToString("dd MMMM yyy ") + TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox2.Text & "','" & TextBox7.Text & "','" & TextBox3.Text & "','" & TextBox11.Text & "','" & TextBox8.Text & "','" & TextBox10.Text & "')"
        Cmd = New SqlCommand(simpandata, Conn)
        Cmd.ExecuteNonQuery()
        TRANSAKSI.TextBox3.Text = ""
        TRANSAKSI.DataGridView2.Rows.Clear()
        TRANSAKSI.TextBox2.Text = ""
        TRANSAKSI.ComboBox1.Text = "Pilih Jenis Order"
        TRANSAKSI.ComboBox1.ForeColor = Color.Gray
        TRANSAKSI.TextBox1.Text = ""
        TRANSAKSI.TextBox5.Enabled = False
        TRANSAKSI.Button3.Enabled = False
        TRANSAKSI.DataGridView1.Enabled = False
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
        TRANSAKSI.TextBox1.Text = urutankode
        MsgBox("Transaksi Selesai!")
        Me.Close()

    End Sub
End Class