Public Class POPUP2
    Dim index As Integer
    Sub KOSONGKAN()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        NumericUpDown1.Text = 1
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        Label6.Text = ""
    End Sub
    Private Sub POPUP2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim index As Integer
        Dim databaru As DataGridViewRow
        databaru = TRANSAKSI.DataGridView2.CurrentRow
        databaru.Cells(0).Value = TextBox1.Text
        databaru.Cells(1).Value = TextBox3.Text
        databaru.Cells(2).Value = TextBox2.Text
        databaru.Cells(3).Value = NumericUpDown1.Text
        databaru.Cells(5).Value = TextBox4.Text
        If CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = False Then
            databaru.Cells(4).Value = CheckBox1.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = False Then
            databaru.Cells(4).Value = CheckBox2.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = True Then
            databaru.Cells(4).Value = CheckBox3.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = False Then
            databaru.Cells(4).Value = CheckBox1.Text + ", " + CheckBox2.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = True Then
            databaru.Cells(4).Value = CheckBox1.Text + ", " + CheckBox3.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True Then
            databaru.Cells(4).Value = CheckBox2.Text + ", " + CheckBox3.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True Then
            databaru.Cells(4).Value = CheckBox1.Text + ", " + CheckBox2.Text + ", " + CheckBox3.Text
            databaru.Cells(7).Value = (Val(NumericUpDown1.Text) * 9000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        Else
            databaru.Cells(4).Value = ""
            databaru.Cells(7).Value = Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        End If
        Me.Close()
        KOSONGKAN()
        TRANSAKSI.Grandtotal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        If TRANSAKSI.DataGridView2.CurrentCell.Value Is Nothing Then
            MsgBox("Tidak Ada Pesanan!")
        Else
            TRANSAKSI.DataGridView2.Rows.Remove(TRANSAKSI.DataGridView2.CurrentRow)
            Call TRANSAKSI.Grandtotal()
        End If
        Me.Close()
    End Sub
End Class