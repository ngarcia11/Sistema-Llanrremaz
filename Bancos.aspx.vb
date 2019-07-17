Imports System.Data

Partial Class Bancos
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If txtNombres.Text = "" Then
            Response.Write("<script>alert('" & "No puede dejar campos vacios" & "')</script>")
           
        Else
            Try
                CC.Modificaciones("exec InsertarUsuarios '" & txtCod.Text & "','" & txtNombres.Text & "','" & 1 & "'")
                Response.Write("<script>alert('" & "Realizado Correctamente" & "')</script>")
                MAXI()
                carga()
                limpiar()
            Catch ex As Exception
                Response.Write("<script>alert('" & "Este Codigo de Banco ya Esta Registrado" & "')</script>")
                limpiar()
            End Try
        End If
    End Sub

    Private Sub MAXI()
        txtCod.Text = CC.Max("SELECT MAX(CodBanco) from Bancos")
    End Sub
    Private Sub limpiar()

        txtNombres.Text = ""
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        MAXI()
        carga()
    End Sub
    Sub carga()
        Dim dta As New DataSet
        dta = CC.Consultas("exec VerBancos ")
        GvBancos.DataSource = dta
        GvBancos.DataBind()
    End Sub

    Protected Sub GvBancos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvBancos.RowCommand
        If e.CommandName = "btnEliminar" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvBancos.Rows(crow).Cells(0).Text
            CC.Consultas("exec EliminaBanco'" & u & "','" & 0 & "'")
            carga()
            'dvExito.Visible = False
            'dvAdvertencia.Visible = False
            'dvError.Visible = True
        End If
        If e.CommandName = "btnModi" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvBancos.Rows(crow).Cells(1).Text
            Dim c As String = GvBancos.Rows(crow).Cells(0).Text
            txtNombres.Text = u
            txtCod.ReadOnly = True
            txtCod.Text = c
            'CC.Funciones("exec EliminarUsuarios '" & u & "','" & 0 & "'")
            'cargaUsr()

        End If
    End Sub
End Class
