Imports System.Data

Partial Class TiempoEspera
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If txtNombres.Text = "" Or txtDias.Value = "" Then
            Response.Write("<script>alert('" & "No puede dejar campos vacios" & "')</script>")
        Else
            Try
                CC.Modificaciones("exec InsertarTiempo '" & txtId.Text & "','" & txtNombres.Text & "','" & txtDias.Value & "','" & 1 & "'")
                Response.Write("<script>alert('" & "Datos Guardados Correctamente" & "')</script>")
                MAXI()
                carga()
                limpiar()
            Catch ex As Exception
                Response.Write("<script>alert('" & "Este Codigo ya Esta Registrado" & "')</script>")
                limpiar()
            End Try
        End If
    End Sub
    Private Sub MAXI()
        txtId.Text = CC.Max("SELECT MAX(CodTiempo) from TiempoCredito")
    End Sub
    Private Sub limpiar()
        txtDias.Value = ""
        txtNombres.Text = ""
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        MAXI()
        carga()
    End Sub

    Sub carga()
        Dim dta As New DataSet
        dta = CC.Consultas("exec VerTiempo ")
        GvTiempo.DataSource = dta
        GvTiempo.DataBind()
    End Sub

    Protected Sub GvTiempo_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvTiempo.RowCommand
        If e.CommandName = "btnEliminar" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvTiempo.Rows(crow).Cells(0).Text
            CC.Consultas("exec EliminaTiempo'" & u & "','" & 0 & "'")
            carga()
            'dvExito.Visible = False
            'dvAdvertencia.Visible = False
            'dvError.Visible = True
        End If
        If e.CommandName = "btnModi" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvTiempo.Rows(crow).Cells(1).Text
            Dim c As String = GvTiempo.Rows(crow).Cells(0).Text
            Dim d As String = GvTiempo.Rows(crow).Cells(2).Text
            txtNombres.Text = u
            txtId.ReadOnly = True
            txtId.Text = c
            txtDias.Value = d
        End If
    End Sub
End Class
