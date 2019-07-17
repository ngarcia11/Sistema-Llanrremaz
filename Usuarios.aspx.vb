Imports System.IO
Imports System.Data
Partial Class Usuarios
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            If txtNomUsr.Text = "" Or txtPass.Text = "" Then
                limpiar()
                dvAdvertencia.Visible = True
                dvExito.Visible = False
            Else
                CC.Consultas("exec IngresarUsuarios '" & txtNomUsr.Text & "','" & txtPass.Text & "','" & ddlNivel.SelectedValue & "','" & 1 & "'")
                'Response.Write("<script>alert('" & "Realizado Correctamente" & "')</script>")
                txtNomUsr.ReadOnly = False
                dvExito.Visible = True
                dvAdvertencia.Visible = False
                dvError.Visible = False
                Cargar()
                limpiar()
            End If
        Catch ex As Exception
           
            limpiar()
        End Try
    End Sub
    Sub limpiar()
        txtNomUsr.Text = ""
        txtPass.Text = ""
    End Sub

    Sub Cargar()
        Dim dsa As New DataSet
        dsa = CC.Consultas("exec VerUsuarios")
        GvUsuarios.DataSource = dsa
        GvUsuarios.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cargar()

    End Sub

    Protected Sub GvUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvUsuarios.RowCommand
        If e.CommandName = "btnEliminar" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvUsuarios.Rows(crow).Cells(0).Text
            CC.Consultas("exec EliminarUsuarios '" & u & "','" & 0 & "'")
            Cargar()
            dvExito.Visible = False
            dvAdvertencia.Visible = False
            dvError.Visible = True
        End If
        If e.CommandName = "btnModi" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvUsuarios.Rows(crow).Cells(0).Text
            Dim c As String = GvUsuarios.Rows(crow).Cells(1).Text
            Dim n As String = GvUsuarios.Rows(crow).Cells(2).Text
            txtNomUsr.Text = u
            txtNomUsr.ReadOnly = True
            txtPass.Text = c
            ddlNivel.SelectedValue = n
            'CC.Funciones("exec EliminarUsuarios '" & u & "','" & 0 & "'")
            'cargaUsr()

        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiar()
        dvExito.Visible = False
        dvAdvertencia.Visible = False
        dvError.Visible = False
    End Sub
End Class
