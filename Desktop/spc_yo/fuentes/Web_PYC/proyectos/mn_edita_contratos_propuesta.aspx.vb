'///<summary>
'///Creado por: Erick Kleiner - GSI Asesorias
'///Fecha: 23-10-2012
'///Descripción: Pantalla edicion propuesta
'///</summary>
'///
Imports System.Data
Partial Class proyectos_mn_edita_contratos_propuesta
    Inherits System.Web.UI.Page

    Dim Func_Libreria As Funciones = New Funciones()
    Dim SQL_Execute As ConexionWS = New ConexionWS()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_propuesta.aspx")

        Dim strComuna As String
        Dim strLocalizacion As String

        On Error GoTo error_load

        cmdIngresoMandantes.Attributes.Add("onClick", "target='_blank';")
        cmdGrabar.Attributes.Add("onClick", "target='_self';")
        cmdSalir.Attributes.Add("onClick", "target='_self';")
        cmdSeguir2.Attributes.Add("onClick", "target='_self';")



        lblError.Text = ""
        
        txtDireNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")

        txtDireNumero.Text = "0"

        '**********************************************************************
        lblUsuario.Text = Session("ID_Usuario").ToString
        lblPerfil.Text = Session("ID_Desc_Tipo_Usuario").ToString
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy")

        Dim arrNombreParametros(0) As String : arrNombreParametros(0) = "usuario"
        Dim arrValoresParametros(0) As String : arrValoresParametros(0) = lblUsuario.Text

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Datos_Usuario", arrNombreParametros, arrValoresParametros)

        If SQL_Execute.numero_error = 0 Then
            While SQL_Execute.oReader.Read()
                lblCorreo.Text = "(" & SQL_Execute.oReader("correo_electronico").ToString() & ")"
            End While
        End If
        '**********************************************************************

        Dim strCdigoPIA = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion = Page.Request.QueryString("codigo_region")
        Dim strSufijo = Page.Request.QueryString("sufijo")

        If Not IsPostBack Then

            Dim arrNombreParametros2(2) As String : arrNombreParametros2(0) = "codigo_pia" : arrNombreParametros2(1) = "codigo_region" : arrNombreParametros2(2) = "sufijo"
            Dim arrValoresParametros2(2) As String : arrValoresParametros2(0) = strCdigoPIA : arrValoresParametros2(1) = strCdigoRegion : arrValoresParametros2(2) = strSufijo

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros2, arrValoresParametros2)

            If (SQL_Execute.numero_error = 0) Then

                If (SQL_Execute.oReader.HasRows = False) Then
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');")
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'")
                    HttpContext.Current.Response.Write("</SCRIPT>")
                    HttpContext.Current.Response.End()
                End If

                While (SQL_Execute.oReader.Read())
                    txtRegion.Text = SQL_Execute.oReader("region").ToString()
                    txtObjeto.Text = SQL_Execute.oReader("objeto").ToString()
                    txtObjetoNuevo.Text = SQL_Execute.oReader("objeto").ToString()
                    txtPIA.Text = SQL_Execute.oReader("codigo_da").ToString()
                    txtSufijo.Text = SQL_Execute.oReader("sufijo").ToString()
                    txtProceso.Text = SQL_Execute.oReader("TIPO_PROCESO").ToString()
                    txtCodCon.Text = SQL_Execute.oReader("cod_con").ToString()
                    txtEstado.Text = SQL_Execute.oReader("estatus").ToString()
                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If

            '**********************************************************************

            Dim arrNombreParametros4(0) As String

            Dim arrValoresParametros4(0) As String

            arrNombreParametros4(0) = "region"
            arrValoresParametros4(0) = txtRegion.Text

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Provincia", arrNombreParametros4, arrValoresParametros4)

            If SQL_Execute.numero_error = 0 Then
                ddlProvincia.DataSource = SQL_Execute.oReader
                ddlProvincia.DataTextField = "N_PROVI"
                ddlProvincia.DataValueField = "PROVINCIA"
                ddlProvincia.DataBind()
                ddlProvincia.Items.Insert(0, "(SELECCIONAR)")
            End If

            '**********************************************************************
            'llena pantalla
            '**********************************************************************

            Dim arrNombreParametros3(2) As String : arrNombreParametros3(0) = "region" : arrNombreParametros3(1) = "codigo_da" : arrNombreParametros3(2) = "sufijo"
            Dim arrValoresParametros3(2) As String : arrValoresParametros3(0) = strCdigoRegion : arrValoresParametros3(1) = strCdigoPIA : arrValoresParametros3(2) = strSufijo

            SQL_Execute.FUNC_Ejecuta_SP("GetContratosPropuestas", arrNombreParametros3, arrValoresParametros3)

            If (SQL_Execute.numero_error = 0) Then

                While (SQL_Execute.oReader.Read())

                    ddlProvincia.ClearSelection()
                    Dim olstProvincia As ListItem
                    olstProvincia = ddlProvincia.Items.FindByValue(SQL_Execute.oReader("PROVINCIA").ToString())
                    ddlProvincia.SelectedValue = olstProvincia.Value

                    strComuna = SQL_Execute.oReader("COMUNA").ToString()
                    strLocalizacion = SQL_Execute.oReader("CODIGO_LOCALIDAD").ToString()

                    txtDireccion.Text = SQL_Execute.oReader("LOCALIZACION").ToString()
                    txtDireNumero.Text = SQL_Execute.oReader("NUMERO_LOCALIZACION").ToString()
                   
                    txtMandantesConvenio.Value = SQL_Execute.oReader("Cant_Mandantes").ToString()

                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If



            '******************************************************************************************
            Dim arrNombreParametros5(1) As String
            Dim arrValoresParametros5(1) As String

            arrNombreParametros5(0) = "region"
            arrNombreParametros5(1) = "provincia"

            arrValoresParametros5(0) = txtRegion.Text
            arrValoresParametros5(1) = ddlProvincia.SelectedValue.ToString()

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Comunas_Sector", arrNombreParametros5, arrValoresParametros5)

            If SQL_Execute.numero_error = 0 Then

                ddlComuna.DataSource = SQL_Execute.oReader
                ddlComuna.DataTextField = "N_COMU"
                ddlComuna.DataValueField = "COMUNA"
                ddlComuna.DataBind()
                ddlComuna.Items.Insert(0, "(SELECCIONAR)")

            End If

            ddlComuna.ClearSelection()
            Dim olstComuna As ListItem
            olstComuna = ddlComuna.Items.FindByValue(strComuna)
            If IsNothing(olstComuna) = False Then ddlComuna.SelectedValue = olstComuna.Value

            '******************************************************************************************

            Dim arrNombreParametros6(2) As String
            Dim arrValoresParametros6(2) As String

            arrNombreParametros6(0) = "region"
            arrNombreParametros6(1) = "provincia"
            arrNombreParametros6(2) = "comuna"

            arrValoresParametros6(0) = txtRegion.Text
            arrValoresParametros6(1) = ddlProvincia.SelectedValue.ToString()
            arrValoresParametros6(2) = ddlComuna.SelectedValue.ToString()

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_localizacion", arrNombreParametros6, arrValoresParametros6)

            If SQL_Execute.numero_error = 0 Then

                ddlLocalizacion.DataSource = SQL_Execute.oReader
                ddlLocalizacion.DataTextField = "NOMBRE_LOCALIDAD"
                ddlLocalizacion.DataValueField = "CODIGO_LOCALIDAD"
                ddlLocalizacion.DataBind()
                ddlLocalizacion.Items.Insert(0, "(SELECCIONAR)")

            End If

            ddlLocalizacion.ClearSelection()
            Dim olstLocalizacion As ListItem
            olstLocalizacion = ddlLocalizacion.Items.FindByValue(strLocalizacion)
            If IsNothing(olstLocalizacion) = False Then ddlLocalizacion.SelectedValue = olstLocalizacion.Value

            '******************************************************************************************

        End If

        Exit Sub
error_load:
        If Err.Number = 5 Then Resume Next

    End Sub

    Protected Sub cmdGrabar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdGrabar.Click

        Try

            Dim strVUsuario As String = lblUsuario.Text
            Dim strVRegion As String = Request.Form("txtRegion")
            If (Not Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion)) Then
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
                HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');")
                HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'")
                HttpContext.Current.Response.Write("</SCRIPT>")
                HttpContext.Current.Response.End()
            End If

            If Request.Form("ddlProvincia") = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe seleccionar provincia."
                ddlProvincia.Focus()
                Return
            End If

            If Request.Form("ddlComuna") = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe seleccionar comuna."
                ddlComuna.Focus()
                Return
            End If

            'If ddlLocalizacion.Text = "(SELECCIONAR)" Then
            '    lblError.Text = "Para cambiar a Estado 'En Programación': Debe seleccionar localización."
            '    ddlLocalizacion.Focus()
            '    Return
            'End If

            If Request.Form("txtDireNumero") = "" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe ingresar número dirección."
                txtDireNumero.Focus()
                Return
            End If

            If Request.Form("txtObjeto") = "" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe ingresar objeto del contrato."
                txtObjeto.Focus()
                Return
            End If

            Dim arrNombreParametros(70) As String
            Dim arrValoresParametros(70) As String

            'nombre parametros

            'encabezado
            arrNombreParametros(0) = "region"
            arrNombreParametros(1) = "codigo_da"
            arrNombreParametros(2) = "sufijo"
            arrNombreParametros(3) = "t_f1"
            arrNombreParametros(4) = "provincia"
            arrNombreParametros(5) = "comuna"
            arrNombreParametros(6) = "codigo_localidad"
            arrNombreParametros(7) = "tipo_proceso"
            arrNombreParametros(8) = "objeto"
            arrNombreParametros(9) = "localizacion"
            arrNombreParametros(10) = "numero_localizacion"
            arrNombreParametros(11) = "mandante_convenio"
            arrNombreParametros(12) = "correlativo_convenio"
            arrNombreParametros(13) = "estatus"
            arrNombreParametros(14) = "valido"

            'seccion A
            arrNombreParametros(15) = "ti_lic"
            arrNombreParametros(16) = "ti_con"
            arrNombreParametros(17) = "tipo_reajuste"
            arrNombreParametros(18) = "fecha_lic_pr"
            arrNombreParametros(19) = "fecha_ap_estimada"
            arrNombreParametros(20) = "fecha_ap_pr"
            arrNombreParametros(21) = "fecha_ap_pr_eco"
            arrNombreParametros(22) = "fecha_inicio_estimada"
            arrNombreParametros(23) = "bases_admin_generales"
            arrNombreParametros(24) = "bases_admin_especiales"
            arrNombreParametros(25) = "bases_tecnicas"
            arrNombreParametros(26) = "carpeta_tecnica_licitacion"
            arrNombreParametros(27) = "registro"
            arrNombreParametros(28) = "categoria"
            arrNombreParametros(29) = "monto_progra"
            arrNombreParametros(30) = "plazo_estimado_ejec"
            arrNombreParametros(31) = "resp_antecedentes_ppta"
            arrNombreParametros(32) = "anticipo_contemplado"
            arrNombreParametros(33) = "antic_contempl_porc"
            arrNombreParametros(34) = "aplica_cartilla_r_26"
            arrNombreParametros(35) = "fecha_docto_r26"
            arrNombreParametros(36) = "aplica_cartilla_r_28"
            arrNombreParametros(37) = "fecha_docto_r28"
            arrNombreParametros(38) = "aplica_cartilla_r_29"
            arrNombreParametros(39) = "fecha_docto_r29"
            arrNombreParametros(40) = "requiere_reg_especial"
            arrNombreParametros(41) = "n_permiso_edificacion"
            arrNombreParametros(42) = "fecha_permiso_edificacion"
            arrNombreParametros(43) = "id_chile_compra"
            arrNombreParametros(44) = "ces"

            'seccion B
            arrNombreParametros(45) = "n_docto_r5"
            arrNombreParametros(46) = "fecha_docto_r5"
            arrNombreParametros(47) = "fecha_lic"
            arrNombreParametros(48) = "f_ap_tecnica_prop"
            arrNombreParametros(49) = "f_ap_prop"
            arrNombreParametros(50) = "plazo_oficial"
            arrNombreParametros(51) = "mt_ofi"
            arrNombreParametros(52) = "observaciones_prop"
            arrNombreParametros(53) = "resultado_propuesta"
            arrNombreParametros(54) = "resp_lcitacion"
            arrNombreParametros(55) = "llamado"
            arrNombreParametros(56) = "n_res_no_adjudica"
            arrNombreParametros(57) = "f_res_no_adjudica"

            'seccion C
            arrNombreParametros(58) = "fecha_informe_adjudicacion"
            arrNombreParametros(59) = "mto_or"
            arrNombreParametros(60) = "plazo_or"
            arrNombreParametros(61) = "or_res"
            arrNombreParametros(62) = "n_res"
            arrNombreParametros(63) = "f_res"
            arrNombreParametros(64) = "f_trami"
            arrNombreParametros(65) = "rut_con"
            arrNombreParametros(66) = "com_eval_oferta1"
            arrNombreParametros(67) = "com_eval_oferta2"
            arrNombreParametros(68) = "com_eval_oferta3"
            arrNombreParametros(69) = "adjudicado"
            arrNombreParametros(70) = "seccion"

            'Valores

            'encabezado
            arrValoresParametros(0) = Request.Form("txtRegion")
            arrValoresParametros(1) = Request.Form("txtPIA")
            arrValoresParametros(2) = Request.Form("txtSufijo")
            arrValoresParametros(3) = "0" 't_f1
            arrValoresParametros(4) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlProvincia"), "0")
            arrValoresParametros(5) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlComuna"), "")
            arrValoresParametros(6) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlLocalizacion"), "0")
            arrValoresParametros(7) = Request.Form("txtProceso")
            arrValoresParametros(8) = Request.Form("txtObjetoNuevo")
            arrValoresParametros(9) = Request.Form("txtDireccion")
            arrValoresParametros(10) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtDireNumero"))
            arrValoresParametros(11) = "" 'mandante_convenio
            arrValoresParametros(12) = "0" 'correlativo_convenio

            If Request.Form("txtEstado").Trim() = "Propuesta sin programación" Then
                arrValoresParametros(13) = "En Programación"
            Else
                arrValoresParametros(13) = Request.Form("txtEstado").Trim()
            End If

            arrValoresParametros(14) = "0" 'valido

            'seccion A
            arrValoresParametros(15) = ""
            arrValoresParametros(16) = ""
            arrValoresParametros(17) = ""
            arrValoresParametros(18) = ""
            arrValoresParametros(19) = "" 'fecha_ap_estimada 
            arrValoresParametros(20) = ""
            arrValoresParametros(21) = ""
            arrValoresParametros(22) = ""
            arrValoresParametros(23) = ""
            arrValoresParametros(24) = ""
            arrValoresParametros(25) = ""
            arrValoresParametros(26) = ""
            arrValoresParametros(27) = ""
            arrValoresParametros(28) = ""
            arrValoresParametros(29) = "0"
            arrValoresParametros(30) = "0"
            arrValoresParametros(31) = ""
            arrValoresParametros(32) = "0"
            arrValoresParametros(33) = "0"
            arrValoresParametros(34) = ""
            arrValoresParametros(35) = ""
            arrValoresParametros(36) = ""
            arrValoresParametros(37) = ""
            arrValoresParametros(38) = ""
            arrValoresParametros(39) = ""
            arrValoresParametros(40) = ""
            arrValoresParametros(41) = ""
            arrValoresParametros(42) = ""
            arrValoresParametros(43) = ""
            arrValoresParametros(44) = ""

            'seccion B
            arrValoresParametros(45) = "0"
            arrValoresParametros(46) = ""
            arrValoresParametros(47) = ""
            arrValoresParametros(48) = ""
            arrValoresParametros(49) = ""
            arrValoresParametros(50) = "0"
            arrValoresParametros(51) = "0"
            arrValoresParametros(52) = ""
            arrValoresParametros(53) = ""
            arrValoresParametros(54) = ""
            arrValoresParametros(55) = "0"
            arrValoresParametros(56) = "0"
            arrValoresParametros(57) = ""

            'seccion C
            arrValoresParametros(58) = ""
            arrValoresParametros(59) = "0"
            arrValoresParametros(60) = "0"
            arrValoresParametros(61) = ""
            arrValoresParametros(62) = "0"
            arrValoresParametros(63) = ""
            arrValoresParametros(64) = ""
            arrValoresParametros(65) = ""
            arrValoresParametros(66) = ""
            arrValoresParametros(67) = ""
            arrValoresParametros(68) = ""
            arrValoresParametros(69) = ""

            arrValoresParametros(70) = "E"

            SQL_Execute.FUNC_Ejecuta_SP("SetContratoPropuesta", arrNombreParametros, arrValoresParametros)

            If SQL_Execute.numero_error = 0 Then
                Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
                Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
                Dim strSufijo As String = Page.Request.QueryString("sufijo")

                Dim strURL As String = "mn_edita_contratos_propuesta_a.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo

                Dim strEstatus As String = FUNC_Busca_Estatus_Contrato()

                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
                HttpContext.Current.Response.Write("alert('Este contrato ahora se encuentra en estado (" & strEstatus & ").');")
                HttpContext.Current.Response.Write("window.location.href='" + strURL + "'")
                HttpContext.Current.Response.Write("</SCRIPT>")
                HttpContext.Current.Response.End()
            Else
                lblError.Text = "Problemas al actualizar propuesta"
            End If

        Catch ex As Exception
            lblError.Text = "Problemas al actualizar propuesta, intentelo de nuevo."

        End Try

    End Sub

    Protected Function FUNC_Busca_Estatus_Contrato() As String

        Dim strCdigoPIA = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion = Page.Request.QueryString("codigo_region")
        Dim strSufijo = Page.Request.QueryString("sufijo")

        Dim strEstatus As String = ""

        Dim arrNombreParametros2(2) As String : arrNombreParametros2(0) = "codigo_pia" : arrNombreParametros2(1) = "codigo_region" : arrNombreParametros2(2) = "sufijo"
        Dim arrValoresParametros2(2) As String : arrValoresParametros2(0) = strCdigoPIA : arrValoresParametros2(1) = strCdigoRegion : arrValoresParametros2(2) = strSufijo

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros2, arrValoresParametros2)

        If (SQL_Execute.numero_error = 0) Then

            While (SQL_Execute.oReader.Read())
                strEstatus = SQL_Execute.oReader("estatus").ToString()
            End While
        End If

        FUNC_Busca_Estatus_Contrato = strEstatus

    End Function

    Protected Sub cmdSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSalir.Click
        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion)
    End Sub

    Protected Sub ddlProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvincia.SelectedIndexChanged

        Dim arrNombreParametros2(1) As String
        Dim arrValoresParametros2(1) As String

        arrNombreParametros2(0) = "region"
        arrNombreParametros2(1) = "provincia"

        arrValoresParametros2(0) = Request.Form("txtRegion")
        arrValoresParametros2(1) = Request.Form("ddlProvincia")

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Comunas_Sector", arrNombreParametros2, arrValoresParametros2)

        If SQL_Execute.numero_error = 0 Then

            ddlComuna.DataSource = SQL_Execute.oReader
            ddlComuna.DataTextField = "N_COMU"
            ddlComuna.DataValueField = "COMUNA"
            ddlComuna.DataBind()
            ddlComuna.Items.Insert(0, "(SELECCIONAR)")

        End If

    End Sub

    Protected Sub ddlComuna_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlComuna.SelectedIndexChanged

        Dim arrNombreParametros3(2) As String
        Dim arrValoresParametros3(2) As String

        On Error GoTo error_load

        arrNombreParametros3(0) = "region"
        arrNombreParametros3(1) = "provincia"
        arrNombreParametros3(2) = "comuna"

        arrValoresParametros3(0) = Request.Form("txtRegion")
        arrValoresParametros3(1) = Request.Form("ddlProvincia")
        arrValoresParametros3(2) = Request.Form("ddlComuna")

        SQL_Execute.FUNC_Ejecuta_SP("Get_busca_localizacion", arrNombreParametros3, arrValoresParametros3)

        If SQL_Execute.numero_error = 0 Then

            ddlLocalizacion.DataSource = SQL_Execute.oReader
            ddlLocalizacion.DataTextField = "NOMBRE_LOCALIDAD"
            ddlLocalizacion.DataValueField = "CODIGO_LOCALIDAD"
            ddlLocalizacion.DataBind()
            ddlLocalizacion.Items.Insert(0, "(SELECCIONAR)")

        End If

        Exit Sub
error_load:
        If Err.Number = 5 Then Resume Next


    End Sub


    Protected Sub cmdIngresoMandantes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIngresoMandantes.Click

        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        Response.Redirect("propuesta/mn_mandantes_contrato.aspx?codigo_pia=" & strCdigoPIA & "&codigo_region=" & strCdigoRegion + "&sufijo=" & strSufijo)

    End Sub



    Protected Sub cmdSeguir2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSeguir2.Click

        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        If Request.Form("txtEstado").Trim() = "Propuesta sin programación" Then 'Or Request.Form("txtEstado").Trim() = "En Programación"

            Dim strURL As String = "mn_edita_contratos_propuesta.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
            HttpContext.Current.Response.Write("alert('No puede utilizar esta opción, el contrato no ha cambiado de estado.');")
            HttpContext.Current.Response.Write("window.location.href='" + strURL + "'")
            HttpContext.Current.Response.Write("</SCRIPT>")
            HttpContext.Current.Response.End()
        End If

        Response.Redirect("mn_edita_contratos_propuesta_a.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo)

    End Sub
End Class
