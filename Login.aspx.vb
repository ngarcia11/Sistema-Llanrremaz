Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones   
    Protected Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Dim dsa As New DataSet
        dsa = CC.Consultas("Select NomUsr, PassUsr, NvlUsr from Usuarios Where NomUsr = '" & txtUser.Text & "' AND PassUsr = '" & txtPass.Text & "' AND EstUsr = '" & 1 & "'")
        Session("user") = txtUser.Text
        If dsa.Tables(0).Rows.Count = 0 Then
            Response.Write("<script>alert('" & "Usuario y/o Contraseña incorrectos" & "');</script>")
            txtUser.Text = ""
            txtPass.Text = ""
        Else
            If dsa.Tables(0).Rows(0).Item(2) = 0 Then
                Server.Transfer("~\RegistroClientes.aspx")
            Else
                Server.Transfer("~\Usuarios.aspx")


            End If

        End If
    End Sub
End Class
