Imports System.Data

Partial Class Facturas
    Inherits System.Web.UI.Page
    Dim CC As New Conexiones
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If txtDesc.Value = "" Or txtSal.Value = "" Or TxtRef.Text = "" Or txtSal.Value = "" Then
            Response.Write("<script>alert('" & "No puede dejar campos vacios" & "')</script>")
        Else
            Try
                Dim fecha As String = DateTime.Now
                CC.Modificaciones("exec IngresarFacturaEncabezado '" & LblFac.Text & "','" & TxtRef.Text & "','" & ddlCLIENTES.SelectedValue & "','" & fecha & "','" & txtFch.Value & "','" & ddlDias.SelectedValue & "','" & 1 & "'")
                CC.Modificaciones("exec IngresarFacturaDetalle '" & LblFac.Text & "','" & txtSal.Value & "','" & txtDesc.Value & "'")
                Response.Write("<script>alert('" & "Datos Guardados Correctamente" & "')</script>")
                carga()
                MAXI()
                'carga()
                limpiar()
            Catch ex As Exception
                Response.Write("<script>alert('" & "Error al guardar" & "')</script>")
                limpiar()
            End Try
        End If
    End Sub
    Private Sub MAXI()
        LblFac.Text = CC.Max("SELECT MAX(NumCorreFact) from FacturaEncabezado")
        LblPagos.Text = CC.Max("SELECT MAX(CodPago) from Pagos")
    End Sub
    Private Sub limpiar()
        txtDesc.Value = ""
        txtFch.Value = ""
        TxtRef.Text = ""
        txtSal.Value = ""
        TxtFact.Text = ""
        txtMonto.Value = ""
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        MAXI()
        carga()
    End Sub

    Sub carga()
        Dim dta As New DataSet
        dta = CC.Consultas("exec VerFacturas ")
        GvFacturas.DataSource = dta
        GvFacturas.DataBind()
    End Sub

    Protected Sub GvFacturas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvFacturas.RowCommand
        'If e.CommandName = "btnEliminar" Then
        '    Dim crow As Integer
        '    crow = Convert.ToInt32(e.CommandArgument.ToString())
        '    Dim u As String = GvFacturas.Rows(crow).Cells(0).Text
        '    CC.Modificaciones("exec EliminarClientes '" & u & "','" & 0 & "'")
        '    carga()

        'End If
        If e.CommandName = "btnModi" Then
            Dim crow As Integer
            crow = Convert.ToInt32(e.CommandArgument.ToString())
            Dim u As String = GvFacturas.Rows(crow).Cells(1).Text
            Dim c As String = GvFacturas.Rows(crow).Cells(0).Text
            Dim s As String = GvFacturas.Rows(crow).Cells(5).Text
            TxtFact.Text = c
            TxtFact.ReadOnly = True
            Label1.Text = c
            Lblsal.Text = s
        End If
    End Sub

    Protected Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        If TxtFact.Text = "" Or txtMonto.Value = "" Then
            Response.Write("<script>alert('" & "No puede dejar campos vacios" & "')</script>")
        Else
            Try
                Dim fecha As String = DateTime.Now
                Dim total As Integer
                total = Lblsal.Text - txtMonto.Value
                CC.Modificaciones("exec IngresarPagos '" & LblPagos.Text & "','" & Label1.Text & "','" & Date.Now & "','" & txtMonto.Value & "','" & ddlBanco.SelectedValue & "','" & 1 & "'")
                CC.Modificaciones("exec RestarFact '" & Label1.Text & "','" & total & "'")
                Response.Write("<script>alert('" & "Datos Guardados Correctamente" & "')</script>")
                carga()
                MAXI()
                'carga()
                limpiar()
            Catch ex As Exception
                Response.Write("<script>alert('" & "Error al guardar" & "')</script>")
                limpiar()
            End Try
        End If
    End Sub
End Class
