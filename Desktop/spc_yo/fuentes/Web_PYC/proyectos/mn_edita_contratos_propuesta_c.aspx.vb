'///<summary>
'///Creado por: Erick Kleiner - GSI Asesorias
'///Fecha: 23-10-2012
'///Descripción: Pantalla edicion propuesta
'///</summary>
'///
Imports System.Data
Partial Class proyectos_mn_edita_contratos_propuesta_c
    Inherits System.Web.UI.Page

    Dim Func_Libreria As Funciones = New Funciones()
    Dim SQL_Execute As ConexionWS = New ConexionWS()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_propuesta.aspx")

        On Error GoTo error_load

        lblError.Text = ""

        txtMontoAdjudicado.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);")
        txtMontoAdjudicado.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);")
        txtMontoAdjudicado.Attributes.Add("onfocus", "javascript:dropComa(this.id);")
        txtMontoAdjudicado.Attributes.Add("onpaste", "javascript:return false;")

        txtNumeroRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtPlazoAdjudicado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")

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

            txtNumeroRes.Text = "0"
            txtMontoAdjudicado.Text = "0"
            txtPlazoAdjudicado.Text = "0"

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
                    txtPIA.Text = SQL_Execute.oReader("codigo_da").ToString()
                    txtSufijo.Text = SQL_Execute.oReader("sufijo").ToString()
                    txtProceso.Text = SQL_Execute.oReader("TIPO_PROCESO").ToString()
                    txtCodCon.Text = SQL_Execute.oReader("cod_con").ToString()
                    txtEstado.Text = SQL_Execute.oReader("estatus").ToString()
                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If

            LlenaCombos()

            '**********************************************************************
            'llena pantalla
            '**********************************************************************

            Dim arrNombreParametros3(2) As String : arrNombreParametros3(0) = "region" : arrNombreParametros3(1) = "codigo_da" : arrNombreParametros3(2) = "sufijo"
            Dim arrValoresParametros3(2) As String : arrValoresParametros3(0) = strCdigoRegion : arrValoresParametros3(1) = strCdigoPIA : arrValoresParametros3(2) = strSufijo

            SQL_Execute.FUNC_Ejecuta_SP("GetContratosPropuestas", arrNombreParametros3, arrValoresParametros3)

            If (SQL_Execute.numero_error = 0) Then

                While (SQL_Execute.oReader.Read())

                    'C) P R O C E S O   D E   A D J U D I C A C I  O N	
                    txtComEval1.Text = SQL_Execute.oReader("COM_EVAL_OFERTA1").ToString()
                    txtComEval2.Text = SQL_Execute.oReader("COM_EVAL_OFERTA2").ToString()
                    txtComEval3.Text = SQL_Execute.oReader("COM_EVAL_OFERTA3").ToString()
                    txtFechaInformeAdj.Text = SQL_Execute.oReader("FECHA_INFORME_ADJUDICACION").ToString()

                    ddlResOrigen.ClearSelection()
                    Dim olstResOrigen As ListItem
                    olstResOrigen = ddlResOrigen.Items.FindByValue(SQL_Execute.oReader("OR_RES").ToString())
                    If IsNothing(olstResOrigen) = False Then ddlResOrigen.SelectedValue = olstResOrigen.Value

                    txtNumeroRes.Text = SQL_Execute.oReader("N_RES").ToString()
                    txtFechaRes.Text = SQL_Execute.oReader("F_RES").ToString()

                    txtAdjudicado.Text = SQL_Execute.oReader("adjudicado").ToString()

                    'ddlAdjudicado.ClearSelection()
                    'Dim olstAdjudicado As ListItem
                    'olstAdjudicado = ddlAdjudicado.Items.FindByValue(SQL_Execute.oReader("adjudicado").ToString())
                    'If IsNothing(olstAdjudicado) = False Then ddlAdjudicado.SelectedValue = olstAdjudicado.Value

                    txtFechaTramite.Text = SQL_Execute.oReader("F_TRAMI").ToString()

                    'ddlRutContratista.Text = SQL_Execute.oReader("RUT_CON").ToString()
                    ddlRutContratista.ClearSelection()
                    Dim olstRutContratista As ListItem
                    olstRutContratista = ddlRutContratista.Items.FindByValue(SQL_Execute.oReader("RUT_CON").ToString())
                    If IsNothing(olstRutContratista) = False Then ddlRutContratista.SelectedValue = olstRutContratista.Value

                    txtMontoAdjudicado.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader("MTO_OR").ToString(), 0)
                    txtPlazoAdjudicado.Text = SQL_Execute.oReader("PLAZO_OR").ToString()

                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If

            '**********************************************************************

        End If

        Exit Sub
error_load:
        If Err.Number = 5 Then Resume Next

    End Sub


    Sub LlenaCombos()

        On Error GoTo erro_label

        'tipo_licitacion

        Dim ows As New WSSPC.WSSPC

        Dim oDataset As New DataSet
        Dim xmlSR As System.IO.StringReader
        Dim oxml As System.Xml.XmlNode
        Dim stringXml As String = ""

        'ddlAdjudicado.Items.Insert(0, "(SELECCIONAR)")
        'ddlAdjudicado.Items.Add("SI")
        'ddlAdjudicado.Items.Add("NO")
        'ddlAdjudicado.SelectedIndex = 0

        txtAdjudicado.Text = "No"

        oDataset = New DataSet
        oxml = ows.GetConsultaGeneral("<parametros><tipo>origenes_resolucion</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlResOrigen.DataTextField = "descripcion"
        ddlResOrigen.DataValueField = "codigo"
        ddlResOrigen.DataSource = oDataset.Tables(1)
        ddlResOrigen.DataBind()
        ddlResOrigen.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        oDataset = New DataSet
        oxml = ows.GetContratistaAdjudicado("<parametros><region>" + txtRegion.Text.Trim + "</region><codigo_da>" + txtPIA.Text.Trim + "</codigo_da><sufijo>" + txtSufijo.Text.Trim + "</sufijo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlRutContratista.DataTextField = "n_ctta"
        ddlRutContratista.DataValueField = "rut_ctta"
        ddlRutContratista.DataSource = oDataset.Tables(1)
        ddlRutContratista.DataBind()
        ddlRutContratista.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        Exit Sub

erro_label:

        If Err.Number = 9 Or Err.Description.ToUpper = "CANNOT FIND TABLE 1" Then
            Resume Next
        End If


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

            Dim strEstatus As String = "En proceso de adjudicación"

            'If Request.Form("txtFechaInformeAdj") = "" Or Request.Form("txtFechaInformeAdj") = "01/01/1900" Then
            '    lblError.Text = "Para cambiar a Estado '" & strEstatus & "': Debe ingresar Fecha Apertura Tecnica Prop."
            '    txtFechaInformeAdj.Focus()
            '    Return
            'End If

            If Request.Form("txtFechaTramite") <> "" And Request.Form("txtFechaTramite") <> "01/01/1900" Then
                strEstatus = "En ejecución"
            End If

            'If strEstatus = "En ejecución" Then

            '    If Request.Form("ddlRutContratista") = "(SELECCIONAR)" Then
            '        lblError.Text = "Para cambiar a Estado 'En ejecución': Debe seleccionar un contratista."
            '        ddlRutContratista.Focus()
            '        Return
            '    End If

            '    If Request.Form("txtMontoAdjudicado") = "" Or Request.Form("txtMontoAdjudicado") = "0" Then
            '        lblError.Text = "Para cambiar a Estado 'En ejecución': Debe ingresar el monto adjudicado."
            '        txtMontoAdjudicado.Focus()
            '        Return
            '    End If

            '    If Request.Form("txtPlazoAdjudicado") = "" Or Request.Form("txtPlazoAdjudicado") = "0" Then
            '        lblError.Text = "Para cambiar a Estado 'En ejecución': Debe ingresar el plazo de ejecución."
            '        txtPlazoAdjudicado.Focus()
            '        Return
            '    End If

            '    txtAdjudicado.text = "Si"

            'End If

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
            arrValoresParametros(4) = "0"
            arrValoresParametros(5) = ""
            arrValoresParametros(6) = "0"
            arrValoresParametros(7) = ""
            arrValoresParametros(8) = ""
            arrValoresParametros(9) = ""
            arrValoresParametros(10) = "0"
            arrValoresParametros(11) = "0" 'mandante_convenio
            arrValoresParametros(12) = "0" 'correlativo_convenio

            If Request.Form("txtEstado").Trim() = "Proceso de Publicación" Then
                arrValoresParametros(13) = strEstatus
            Else
                arrValoresParametros(13) = Request.Form("txtEstado")
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
            arrValoresParametros(58) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaInformeAdj"))
            arrValoresParametros(59) = Func_Libreria.FUNC_MontoSQLv2(Request.Form("txtMontoAdjudicado"))
            arrValoresParametros(60) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPlazoAdjudicado"))
            arrValoresParametros(61) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlResOrigen"), "")
            arrValoresParametros(62) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtNumeroRes"))
            arrValoresParametros(63) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaRes"))
            arrValoresParametros(64) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaTramite"))
            arrValoresParametros(65) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRutContratista"), "")
            arrValoresParametros(66) = Request.Form("txtComEval1")
            arrValoresParametros(67) = Request.Form("txtComEval2")
            arrValoresParametros(68) = Request.Form("txtComEval3")
            arrValoresParametros(69) = Request.Form("txtAdjudicado")

            arrValoresParametros(70) = "C"

            SQL_Execute.FUNC_Ejecuta_SP("SetContratoPropuesta", arrNombreParametros, arrValoresParametros)

            If SQL_Execute.numero_error = 0 Then
                Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
                Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")

                Dim strURL As String = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion

                strEstatus = FUNC_Busca_Estatus_Contrato()

                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
                HttpContext.Current.Response.Write("alert('Este contrato ahora se encuentra en estado (" & strEstatus & ").');")
                HttpContext.Current.Response.Write("window.location.href='" & strURL & "'")
                HttpContext.Current.Response.Write("</SCRIPT>")
                HttpContext.Current.Response.End()
            Else

                lblError.Text = "Problemas al actualizar propusta"
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

    Protected Sub ddlRutContratista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRutContratista.SelectedIndexChanged

        Dim strCdigoPIA = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion = Page.Request.QueryString("codigo_region")
        Dim strSufijo = Page.Request.QueryString("sufijo")

        Dim arrNombreParametros(2) As String : arrNombreParametros(0) = "region" : arrNombreParametros(1) = "codigo_da" : arrNombreParametros(2) = "sufijo"
        Dim arrValoresParametros(2) As String : arrValoresParametros(0) = strCdigoRegion : arrValoresParametros(1) = strCdigoPIA : arrValoresParametros(2) = strSufijo

        SQL_Execute.FUNC_Ejecuta_SP("GetOfertasPropuestaContratista", arrNombreParametros, arrValoresParametros)

        If (SQL_Execute.numero_error = 0) Then

            While (SQL_Execute.oReader.Read())

                If (Request.Form("ddlRutContratista") = SQL_Execute.oReader("RUT_CTTA").ToString()) Then
                    txtMontoAdjudicado.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader("MONTO").ToString(), 0)
                    txtPlazoAdjudicado.Text = SQL_Execute.oReader("PLAZO").ToString()
                End If

            End While

        Else
            lblError.Text = SQL_Execute.desc_error
        End If

    End Sub
End Class
