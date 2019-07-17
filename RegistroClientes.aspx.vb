Imports System.Data

Partial Class RegistroClientes
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        carga()
    End Sub
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If txtId.Text = "" Or txtApellido.Text = "" Or txtNombres.Text = "" Or txtSaldo.Text = "" Then
            Response.Write("<script>alert('" & "No pueden haber campos vacios" & "')</script>")
        Else
            Try
                CC.Modificaciones("exec IngresarClientes '" & txtId.Text & "','" & txtNombres.Text & "','" & txtApellido.Text & "','" & txtSaldo.Text & "','" & 1 & "'")
                Response.Write("<script>alert('" & "Realizado Correctamente Correctamente" & "')</script>")
                carga()
                txtId.ReadOnly = False
                limpiar()
            Catch ex As Exception
                Response.Write("<script>alert('" & "Este Codigo de Cliente ya Esta Registrado" & "')</script>")
                limpiar()
            End Try
        End If

    End Sub
    Sub limpiar()
        txtId.Text = " "
        txtNombres.Text = ""
        txtApellido.Text = ""
        txtSaldo.Text = ""
    End Sub

    Sub carga()
        Dim dta As New DataSet
        dta = CC.Consultas("exec VerClientes ")
        GvClientes.DataSource = dta
        GvClientes.DataBind()
    End Sub

  
    Protected Sub GvClientes_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvClientes.RowCommand
        If e.CommandName = "btnEliminar" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvClientes.Rows(crow).Cells(0).Text
            CC.Modificaciones("exec EliminarClientes '" & u & "','" & 0 & "'")
            carga()

        End If
        If e.CommandName = "btnModi" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvClientes.Rows(crow).Cells(0).Text
            Dim c As String = GvClientes.Rows(crow).Cells(1).Text
            Dim n As String = GvClientes.Rows(crow).Cells(2).Text
            Dim s As String = GvClientes.Rows(crow).Cells(3).Text
            txtId.Text = u
            txtId.ReadOnly = True
            txtNombres.Text = c
            txtApellido.Text = n
            txtSaldo.Text = s
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiar()
        txtId.ReadOnly = False
    End Sub
End Class
