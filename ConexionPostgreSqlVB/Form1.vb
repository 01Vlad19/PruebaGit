Public Class Form1
    Public Conexion As String = "Server=127.0.0.1:5432;Database=oficina;Userid=postgres;Password='Tutoriales123'"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaGid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cnn As New Npgsql.NpgsqlConnection
            cnn.ConnectionString = Conexion
            cnn.Open()
            Dim cmd As New Npgsql.NpgsqlCommand("insert into usuarios(nombre,fecha_nacimiento) values('" & TextBox1.Text & "','" & DateTimePicker1.Value.Date & "')", cnn)
            cmd.ExecuteNonQuery()


        End Using

        LlenaGid()
    End Sub

    Private Sub LlenaGid()
        Using cnn As New Npgsql.NpgsqlConnection
            cnn.ConnectionString = Conexion
            cnn.Open()
            Dim da As New Npgsql.NpgsqlDataAdapter("select * from usuarios", cnn)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables(0)
            Else
                DataGridView1.DataSource = Nothing
            End If



        End Using
    End Sub
End Class
