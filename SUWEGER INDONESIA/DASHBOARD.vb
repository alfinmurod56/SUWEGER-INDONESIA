Imports System.Data.SqlClient
Public Class DASHBOARD
    Sub Terkunci()
        LoginToolStripMenuItem.Enabled = True
        LogoutToolStripMenuItem.Enabled = False
        ExitToolStripMenuItem.Enabled = True
        TransaksiToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        AbsensiToolStripMenuItem.Enabled = False
        AboutToolStripMenuItem.Enabled = False
    End Sub

    Private Sub DASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Terkunci()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        LOGIN.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        LoginToolStripMenuItem.Enabled = True
        Terkunci()
        LOGIN.ComboBox1.Text = ""
        LOGIN.TextBox1.Text = ""
        LOGIN.TextBox2.Text = ""
        LOGIN.ComboBox1.Focus()
    End Sub

    Private Sub AbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbsensiToolStripMenuItem.Click
        ABSENSI.ShowDialog()
    End Sub

    Private Sub DataUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataUserToolStripMenuItem.Click
        KARYAWAN.ShowDialog()
    End Sub

    Private Sub DataBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBarangToolStripMenuItem.Click
        PRODUK.ShowDialog()
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem.Click
        TRANSAKSI.ShowDialog()
    End Sub

    Private Sub LaporanPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPenjualanToolStripMenuItem.Click
        LPENJUALAN.ShowDialog()
    End Sub

    Private Sub LaporanAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanAbsensiToolStripMenuItem.Click
        LABSENSI.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("KELOMPOK 12" & Environment.NewLine & "1. HAIKAL AZAM ASSIDDIQI 035" & Environment.NewLine & "2. ALFIN MUROD 023" & Environment.NewLine & "3. RISKA HARUM DIAN SARI 021" & Environment.NewLine & "-------------------------------------------------------------------------------------------" & Environment.NewLine & "PARALEL A - PEMOGRAMAN DEKSTOP")

    End Sub
End Class
