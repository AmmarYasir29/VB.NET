Imports System.Data.SqlClient

Public Class Form2
    Dim sqlCon As New SqlConnection("server=AMMAR\AMMAR; database=Coures; integrated security=true")




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim strInsert As String = "INSERT INTO subject (ID, nameOfSubject,requirment, whichCoures, type) " _
            & "VALUES (" & TextBox4.Text & " , '" & TextBox1.Text & "','" & TextBox5.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "')"
            Dim cmd As New SqlCommand(strInsert, sqlCon)
            sqlCon.Open()
            cmd.ExecuteNonQuery()
            MsgBox("worked!")

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            sqlCon.Close()
        End Try


    End Sub
End Class