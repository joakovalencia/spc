Imports System.IO

Partial Class listados_Flujo_financiero_rpt_flujo_financiero
    Inherits System.Web.UI.Page
    Private Func_Libreria As New Funciones()
    Private SQL_Execute As New ConexionWS()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arrNombreParametros(0) As String : arrNombreParametros(0) = "usuario"
        Dim arrValoresParametros(0) As String : arrValoresParametros(0) = lblUsuario.Text

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Datos_Usuario", arrNombreParametros, arrValoresParametros)

        If SQL_Execute.numero_error = 0 Then
            While SQL_Execute.oReader.Read()
                lblCorreo.Text = "(" & SQL_Execute.oReader("correo_electronico").ToString() & ")"
            End While
        End If
        BUSCAR()
    End Sub


    Protected Sub CMD_DESCARGAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMD_DESCARGAR.Click
        BUSCAR()
        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Dim FileName As String = "Flujo_Financiero.xls"
        Dim strwritter As StringWriter = New StringWriter()
        Dim htmltextwrtter As HtmlTextWriter = New HtmlTextWriter(strwritter)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & FileName)

        grdFlujoFinanaciero.GridLines = GridLines.Both
        grdFlujoFinanaciero.HeaderStyle.Font.Bold = True
        grdFlujoFinanaciero.RenderControl(htmltextwrtter)

        Response.Write(strwritter.ToString())
        Response.End()
        
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Private Function BUSCAR()
        CMD_DESCARGAR.Visible = True

        Dim Func_Libreria As Funciones = New Funciones()
        Dim SQL_Execute As ConexionWS = New ConexionWS()

        SQL_Execute.FUNC_Ejecuta_SP("Get_Flujo_financiero")

        If SQL_Execute.numero_error = 0 Then
            grdFlujoFinanaciero.DataSource = SQL_Execute.oReader
            grdFlujoFinanaciero.DataBind()
        End If
    End Function


End Class
