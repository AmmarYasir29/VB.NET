Imports System.Data.SqlClient
Public Class Form1
    Dim sqlCon As New SqlConnection("server=AMMAR\AMMAR; database=Coures; integrated security=true")
    Public Property nameStudent As String
    Public Property theId As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "The Subject that student taken"

        sqlCon.Open()

        'Dim strQuery As String = "SELECT * FROM subject where studentId = '" & nameStudent & "'"
        'Dim strQuery As String = "Select * From dbo.student INNER Join dbo.studentSubject ON '" & nameStudent & "' = dbo.studentSubject.id_student INNER Join dbo.subject ON dbo.studentSubject.id_subject = dbo.subject.ID"
        Dim strQuery As String = "Select * From student Join studentSubject On '" & nameStudent & "' = studentSubject.id_student Join subject On studentSubject.id_subject = subject.ID"

        Dim cmd As New SqlCommand(strQuery, sqlCon)

            Dim reader As SqlDataReader = cmd.ExecuteReader
        ListView1.Columns.Add("ID")
        ListView1.Columns.Add("NameSubject")
        ListView1.Columns.Add("type")
        While reader.Read
            Dim item As New ListViewItem(reader("ID").ToString())
            item.SubItems.Add(reader("nameOfSubject"))
            item.SubItems.Add(reader("type"))
            ListView1.Items.Add(item)
        End While
        reader.Close()

        Dim str2Query As String = "SELECT * FROM student where id = '" & nameStudent & "'" ' يستعلم عن رقم الصف المحدد فقط - يجيب معلومات الطالب واحد 
        Dim cmd2 As New SqlCommand(str2Query, sqlCon)

        Dim reader2 As SqlDataReader = cmd2.ExecuteReader
        ListView2.Columns.Add("ID")
        ListView2.Columns.Add("NameOfStudent")
        ListView1.Columns.Add("level")
        While reader2.Read
            Dim item2 As New ListViewItem(reader2("ID").ToString())
            item2.SubItems.Add(reader2("NameOfStudent"))
            item2.SubItems.Add(reader2("level"))
            ListView2.Items.Add(item2)
        End While
        reader2.Close()
        sqlCon.Close()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Hide()
    End Sub
End Class
