Public Class POPUP
    Sub kosongkan()
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
    Private Sub POPUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        i = TRANSAKSI.DataGridView1.CurrentRow.Index
        TextBox1.Text = TRANSAKSI.DataGridView1.Item(0, i).Value
        TextBox2.Text = TRANSAKSI.DataGridView1.Item(2, i).Value
        TextBox3.Text = TRANSAKSI.DataGridView1.Item(1, i).Value
        Label6.Text = TRANSAKSI.DataGridView1.Item(3, i).Value
        PictureBox1.ImageLocation = Label6.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Label6.Visible = False
        NumericUpDown1.TextAlign = 1
        NumericUpDown1.Text = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TRANSAKSI.DataGridView2.Enabled = True
        TRANSAKSI.DataGridView2.Rows.Add(1)
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(0).Value = TextBox1.Text
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(1).Value = TextBox3.Text
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(2).Value = TextBox2.Text
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(3).Value = NumericUpDown1.Text
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(5).Value = TextBox4.Text
        TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(6).Value = Label6.Text
        If CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = False Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox1.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = False Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox2.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = True Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox3.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 3000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = False Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox1.Text + ", " + CheckBox2.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = True Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox1.Text + ", " + CheckBox3.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox2.Text + ", " + CheckBox3.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 6000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True Then
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = CheckBox1.Text + ", " + CheckBox2.Text + ", " + CheckBox3.Text
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = (Val(NumericUpDown1.Text) * 9000) + Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        Else
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(4).Value = ""
            TRANSAKSI.DataGridView2.Rows(TRANSAKSI.DataGridView2.RowCount - 2).Cells(7).Value = Val(TextBox2.Text) * Val(NumericUpDown1.Text)

        End If
        Me.Close()
        kosongkan()
        TRANSAKSI.Grandtotal()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class