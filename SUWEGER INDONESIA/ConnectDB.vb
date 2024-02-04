Imports System.Data.SqlClient
Imports System.Data.OleDb
Module ConnectDB
    Public Conn As SqlConnection
    Public konn As OleDbConnection
    Public Da As SqlDataAdapter
    Public Cmd As SqlCommand
    Public Cdm As OleDbCommand
    Public dr As OleDbDataAdapter
    Public Ds As DataSet
    Public MyDB As String
    Public Sub koneksi()
        MyDB = "Data Source=LAPTOP-IU3FFJO6\SQLEXPRESS;initial catalog=DB_SUWEGER; integrated security=true"
        Conn = New SqlConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module

