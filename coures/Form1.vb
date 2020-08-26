Imports System.Data.SqlClient
Public Class Form1
    Dim sqlCon As New SqlConnection("server=AMMAR\AMMAR; database=Coures; integrated security=true") ' معلومات الاتصال بالداتابيس
    Public Property nameStudent As String
    Public Property theId As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "The Subject that student taken"
        Dim x As Integer
        x = 1
        sqlCon.Open()
        '---------------كويري لست للمواد ----------------------
        'التكرار بالاستعلام ديصير بسبب الكويري مرتين تنفذ 
        Dim strQuery As String = "Select * From student Join studentSubject On '" & nameStudent & "' = studentSubject.id_student Join subject On studentSubject.id_subject = subject.ID"
        Dim cmd As New SqlCommand(strQuery, sqlCon) ' تنفيذ اوامر الكويري يرجع نتيجة الكويري 
        Dim reader As SqlDataReader = cmd.ExecuteReader ' يقرء نتيجة كومند الذي ينفذ امر الكويري 
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

        '---------------كويري لست لطالب ----------------------
        'Dim str2Query As String = "SELECT * FROM student where id = '" & nameStudent & "'"    ' يستعلم عن رقم الصف المحدد فقط - استلاعم عن معلومات لطالب واحد 
        'Dim str2Query As String = "Select * From student INNER Join degre On student.Id=degre.studentId where student.id = '" & nameStudent & "'"
        Dim str2Query As String = "Select *, (SELECT AVG(degre1) FROM   (VALUES(degre1), (degre2),(degre3),(degre4)) V(degre1)) AS average
                                    From student INNER Join degre On student.Id=degre.studentId where student.id = '" & nameStudent & "'"
        Dim cmd2 As New SqlCommand(str2Query, sqlCon)
        Dim reader2 As SqlDataReader = cmd2.ExecuteReader
        While reader2.Read

            ListView2.Items.Add((x).ToString)
            ListView2.Items(x - 1).SubItems.Add(reader2.Item("nameOfStudent").ToString)
            ListView2.Items(x - 1).SubItems.Add(reader2.Item("class").ToString)
            ListView2.Items(x - 1).SubItems.Add(reader2.Item("Branch").ToString)
            ListView2.Items(x - 1).SubItems.Add(reader2.Item("average").ToString)
            x = x + 1
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
