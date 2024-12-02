'///<summary>
'///Creado por: Erick Kleiner - GSI Asesorias
'///Fecha: 23-10-2012
'///Descripción: Pantalla edicion propuesta
'///</summary>
'///
Imports System.Data
Partial Class proyectos_mn_edita_contratos_propuesta_a
    Inherits System.Web.UI.Page

    Dim Func_Libreria As Funciones = New Funciones()
    Dim SQL_Execute As ConexionWS = New ConexionWS()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_propuesta.aspx")

        On Error GoTo error_load

        lblError.Text = ""

        txtPresupEstimado.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);")
        txtPresupEstimado.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0); javascript:return func_txtAnticipoContempladoPorc();")
        txtPresupEstimado.Attributes.Add("onfocus", "javascript:dropComa(this.id);")
        txtPresupEstimado.Attributes.Add("onpaste", "javascript:return false;")

        txtAnticipoContemplado.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);")
        txtAnticipoContemplado.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);")
        txtAnticipoContemplado.Attributes.Add("onfocus", "javascript:dropComa(this.id);")
        txtAnticipoContemplado.Attributes.Add("onpaste", "javascript:return false;")

        txtAnticipoContempladoPorc.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);")
        txtAnticipoContempladoPorc.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2); javascript:return func_txtAnticipoContempladoPorc();")
        txtAnticipoContempladoPorc.Attributes.Add("onfocus", "javascript:dropComa(this.id);")
        txtAnticipoContempladoPorc.Attributes.Add("onpaste", "javascript:return false;")

        '******************************************************************************************************************

        txtPlazoEstimado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtNumeroPermEdificacion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")

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

        'txtFechaPermEdificacion.Text = Func_Libreria.FUNC_Trae_Fecha_Proceso("proceso")

        If Not IsPostBack Then

            txtPresupEstimado.Text = "0"
            txtPlazoEstimado.Text = "0"
            txtAnticipoContemplado.Text = "0"
            txtAnticipoContempladoPorc.Text = "0"
            txtNumeroPermEdificacion.Text = "0"

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
            Dim strCategoria As String = ""

            Dim arrNombreParametros3(2) As String : arrNombreParametros3(0) = "region" : arrNombreParametros3(1) = "codigo_da" : arrNombreParametros3(2) = "sufijo"
            Dim arrValoresParametros3(2) As String : arrValoresParametros3(0) = strCdigoRegion : arrValoresParametros3(1) = strCdigoPIA : arrValoresParametros3(2) = strSufijo

            SQL_Execute.FUNC_Ejecuta_SP("GetContratosPropuestas", arrNombreParametros3, arrValoresParametros3)

            If (SQL_Execute.numero_error = 0) Then

                ddlCes.Items.Insert(0, "(SELECCIONAR)")
                ddlCes.Items.Add("1.TDRe EE y CA")
                ddlCes.Items.Add("2.PreCertificación CES")
                ddlCes.Items.Add("3.Certificación CES")
                ddlCes.Items.Add("4.No")

                ddlCes.SelectedIndex = 0

                While (SQL_Execute.oReader.Read())

                    'A) P R O G R A M A C I O N   L I C I T A C I O N	


                    ddlCes.ClearSelection()
                    Dim olstCes As ListItem
                    olstCes = ddlCes.Items.FindByValue(SQL_Execute.oReader("CES").ToString())
                    If IsNothing(olstCes) = False Then ddlCes.SelectedValue = olstCes.Value


                    ddlReqRegEspecial.ClearSelection()
                    Dim olstReqRegEspecial As ListItem
                    olstReqRegEspecial = ddlReqRegEspecial.Items.FindByValue(SQL_Execute.oReader("REQUIERE_REG_ESPECIAL").ToString())
                    If IsNothing(olstReqRegEspecial) = False Then ddlReqRegEspecial.SelectedValue = olstReqRegEspecial.Value

                    ddlTipoLicitacion.ClearSelection()
                    Dim olstTipoLicitacion As ListItem
                    olstTipoLicitacion = ddlTipoLicitacion.Items.FindByValue(SQL_Execute.oReader("TI_LIC").ToString())
                    If IsNothing(olstTipoLicitacion) = False Then ddlTipoLicitacion.SelectedValue = olstTipoLicitacion.Value

                    ddlMoContratacion.ClearSelection()
                    Dim olstMoContratacion As ListItem
                    olstMoContratacion = ddlMoContratacion.Items.FindByValue(SQL_Execute.oReader("TI_CON").ToString())
                    If IsNothing(olstMoContratacion) = False Then ddlMoContratacion.SelectedValue = olstMoContratacion.Value

                    ddlTipoReajuste.ClearSelection()
                    Dim olstTipoReajuste As ListItem
                    olstTipoReajuste = ddlTipoReajuste.Items.FindByValue(SQL_Execute.oReader("TIPO_REAJUSTE").ToString())
                    If IsNothing(olstTipoReajuste) = False Then ddlTipoReajuste.SelectedValue = olstTipoReajuste.Value

                    'Bases Administrativas	
                    ddlBAEspeciales.ClearSelection()
                    Dim olstBAEspeciales As ListItem
                    olstBAEspeciales = ddlBAEspeciales.Items.FindByValue(SQL_Execute.oReader("BASES_ADMIN_ESPECIALES").ToString())
                    If IsNothing(olstBAEspeciales) = False Then ddlBAEspeciales.SelectedValue = olstBAEspeciales.Value

                    ddlBAGerenciales.ClearSelection()
                    Dim olstBAGerenciales As ListItem
                    olstBAGerenciales = ddlBAGerenciales.Items.FindByValue(SQL_Execute.oReader("BASES_ADMIN_GENERALES").ToString())
                    If IsNothing(olstBAGerenciales) = False Then ddlBAGerenciales.SelectedValue = olstBAGerenciales.Value

                    ddlBATecnicas.ClearSelection()
                    Dim olstBATecnicas As ListItem
                    olstBATecnicas = ddlBATecnicas.Items.FindByValue(SQL_Execute.oReader("BASES_TECNICAS").ToString())
                    If IsNothing(olstBATecnicas) = False Then ddlBATecnicas.SelectedValue = olstBATecnicas.Value

                    ddlBACarpetaTecnica.ClearSelection()
                    Dim olstBACarpetaTecnica As ListItem
                    olstBACarpetaTecnica = ddlBACarpetaTecnica.Items.FindByValue(SQL_Execute.oReader("CARPETA_TECNICA_LICITACION").ToString())
                    If IsNothing(olstBACarpetaTecnica) = False Then ddlBACarpetaTecnica.SelectedValue = olstBACarpetaTecnica.Value

                    txtPresupEstimado.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader("MONTO_PROGRA").ToString(), 0)
                    txtPlazoEstimado.Text = SQL_Execute.oReader("PLAZO_ESTIMADO_EJEC").ToString()

                    ddlRegistro.ClearSelection()
                    Dim olstRegistro As ListItem
                    olstRegistro = ddlRegistro.Items.FindByValue(SQL_Execute.oReader("REGISTRO").ToString())
                    If IsNothing(olstRegistro) = False Then ddlRegistro.SelectedValue = olstRegistro.Value

                    txtAnticipoContemplado.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader("ANTICIPO_CONTEMPLADO").ToString(), 0)

                    txtAnticipoContempladoPorc.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader("ANTIC_CONTEMPL_PORC").ToString(), 2)

                    strCategoria = SQL_Execute.oReader("CATEGORIA").ToString()

                    ddlRespAntPPTA.ClearSelection()
                    Dim olstRespAntPPTA As ListItem
                    olstRespAntPPTA = ddlRespAntPPTA.Items.FindByValue(SQL_Execute.oReader("RESP_ANTECEDENTES_PPTA").ToString())
                    If IsNothing(olstRespAntPPTA) = False Then ddlRespAntPPTA.SelectedValue = olstRespAntPPTA.Value


                    'no se usa	.Text = SQL_Execute.oReader("FECHA_AP_ESTIMADA").ToString()
                    txtIDChileCompra.Text = SQL_Execute.oReader("id_chile_compra").ToString()
                    txtNumeroPermEdificacion.Text = SQL_Execute.oReader("N_PERMISO_EDIFICACION").ToString()
                    txtFechaPermEdificacion.Text = SQL_Execute.oReader("FECHA_PERMISO_EDIFICACION").ToString()

                    txtFechaPublicacion.Text = SQL_Execute.oReader("FECHA_LIC_PR").ToString()
                    txtFechaAperturaTecnica.Text = SQL_Execute.oReader("FECHA_AP_PR").ToString()
                    txtFechaAperturaEconomica.Text = SQL_Execute.oReader("FECHA_AP_PR_ECO").ToString()
                    txtFechaEstimada.Text = SQL_Execute.oReader("FECHA_INICIO_ESTIMADA").ToString()

                    ddlAplicaCartillaR26.ClearSelection()
                    Dim olstAplicaCartillaR26 As ListItem
                    olstAplicaCartillaR26 = ddlAplicaCartillaR26.Items.FindByValue(SQL_Execute.oReader("APLICA_CARTILLA_R_26").ToString())
                    If IsNothing(olstAplicaCartillaR26) = False Then ddlAplicaCartillaR26.SelectedValue = olstAplicaCartillaR26.Value

                    ddlAplicaCartillaR28.ClearSelection()
                    Dim olstAplicaCartillaR28 As ListItem
                    olstAplicaCartillaR28 = ddlAplicaCartillaR28.Items.FindByValue(SQL_Execute.oReader("APLICA_CARTILLA_R_28").ToString())
                    If IsNothing(olstAplicaCartillaR28) = False Then ddlAplicaCartillaR28.SelectedValue = olstAplicaCartillaR28.Value

                    ddlAplicaCartillaR29.ClearSelection()
                    Dim olstAplicaCartillaR29 As ListItem
                    olstAplicaCartillaR29 = ddlAplicaCartillaR29.Items.FindByValue(SQL_Execute.oReader("APLICA_CARTILLA_R_29").ToString())
                    If IsNothing(olstAplicaCartillaR29) = False Then ddlAplicaCartillaR29.SelectedValue = olstAplicaCartillaR29.Value

                    txtFechaDoctoR26.Text = SQL_Execute.oReader("FECHA_DOCTO_R26").ToString()
                    txtFechaDoctoR28.Text = SQL_Execute.oReader("FECHA_DOCTO_R28").ToString()
                    txtFechaDoctoR29.Text = SQL_Execute.oReader("FECHA_DOCTO_R29").ToString()

                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If

            Call Func_Busca_Registros_Conttas_Categoria()

            ddlCategoria.ClearSelection()
            Dim olstCategoria As ListItem
            olstCategoria = ddlCategoria.Items.FindByValue(strCategoria)
            If IsNothing(olstCategoria) = False Then ddlCategoria.SelectedValue = olstCategoria.Value

            '**********************************************************************

        End If

        Exit Sub
error_load:
        If Err.Number = 5 Then Resume Next

    End Sub


    Sub LlenaCombos()

        On Error GoTo erro_label

        ddlBAEspeciales.Items.Insert(0, "(SELECCIONAR)")
        ddlBAEspeciales.Items.Add("SI")
        ddlBAEspeciales.Items.Add("NO")
        ddlBAEspeciales.Items.Add("FI")
        ddlBAEspeciales.SelectedIndex = 0

        ddlBAGerenciales.Items.Insert(0, "(SELECCIONAR)")
        ddlBAGerenciales.Items.Add("SI")
        ddlBAGerenciales.Items.Add("NO")
        ddlBAGerenciales.Items.Add("FI")
        ddlBAGerenciales.SelectedIndex = 0

        ddlBATecnicas.Items.Insert(0, "(SELECCIONAR)")
        ddlBATecnicas.Items.Add("SI")
        ddlBATecnicas.Items.Add("NO")
        ddlBATecnicas.Items.Add("FI")
        ddlBATecnicas.SelectedIndex = 0

        ddlBACarpetaTecnica.Items.Insert(0, "(SELECCIONAR)")
        ddlBACarpetaTecnica.Items.Add("SI")
        ddlBACarpetaTecnica.Items.Add("NO")
        ddlBACarpetaTecnica.Items.Add("FI")
        ddlBACarpetaTecnica.SelectedIndex = 0

        ddlReqRegEspecial.Items.Insert(0, "(SELECCIONAR)")
        ddlReqRegEspecial.Items.Add("S")
        ddlReqRegEspecial.Items.Add("N")
        ddlReqRegEspecial.SelectedIndex = 0

        ddlAplicaCartillaR26.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR26.Items.Add("NO")
        ddlAplicaCartillaR26.Items.Add("SI")
        ddlAplicaCartillaR26.SelectedIndex = 0

        ddlAplicaCartillaR28.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR28.Items.Add("NO")
        ddlAplicaCartillaR28.Items.Add("SI")
        ddlAplicaCartillaR28.SelectedIndex = 0

        ddlAplicaCartillaR29.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR29.Items.Add("NO")
        ddlAplicaCartillaR29.Items.Add("SI")
        ddlAplicaCartillaR29.SelectedIndex = 0

        'tipo_licitacion

        Dim ows As New WSSPC.WSSPC

        Dim oDataset As New DataSet
        Dim xmlSR As System.IO.StringReader
        Dim oxml As System.Xml.XmlNode
        Dim stringXml As String = ""

        oxml = ows.GetConsultaGeneral("<parametros><tipo>tipo_licitacion</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlTipoLicitacion.DataTextField = "descripcion"
        ddlTipoLicitacion.DataValueField = "ti_lic"
        ddlTipoLicitacion.DataSource = oDataset.Tables(1)
        ddlTipoLicitacion.DataBind()
        ddlTipoLicitacion.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        oDataset = New DataSet
        'busca_dom_ti_con
        oxml = ows.GetConsultaGeneral("<parametros><tipo>busca_dom_ti_con</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlMoContratacion.DataTextField = "descripcion"
        ddlMoContratacion.DataValueField = "ti_con"
        ddlMoContratacion.DataSource = oDataset.Tables(1)
        ddlMoContratacion.DataBind()
        ddlMoContratacion.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        oDataset = New DataSet
        'busca_dom_ti_con
        oxml = ows.GetConsultaGeneral("<parametros><tipo>registros_conttas2</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlRegistro.DataTextField = "descripcion"
        ddlRegistro.DataValueField = "registro"
        ddlRegistro.DataSource = oDataset.Tables(1)
        ddlRegistro.DataBind()
        ddlRegistro.Items.Insert(0, "(SELECCIONAR)")

        'ddlCategoria.DataTextField = "descripcion"
        'ddlCategoria.DataValueField = "registro"
        'ddlCategoria.DataSource = oDataset.Tables(1)
        'ddlCategoria.DataBind()
        'ddlCategoria.Items.Insert(0, "(SELECCIONAR)")
        'oDataset = Nothing

        oDataset = New DataSet
        oxml = ows.GetConsultaGeneral("<parametros><tipo>busca_dom_insp_fis</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlRespAntPPTA.DataTextField = "rut_nombre"
        ddlRespAntPPTA.DataValueField = "rut"
        ddlRespAntPPTA.DataSource = oDataset.Tables(1)
        ddlRespAntPPTA.DataBind()
        ddlRespAntPPTA.Items.Insert(0, "(SELECCIONAR)")

        '**********************************************************************

        SQL_Execute.FUNC_Ejecuta_SP("sp_BuscaTipoReajuste")

        If (SQL_Execute.numero_error = 0) Then

            ddlTipoReajuste.DataTextField = "DESCRIP"
            ddlTipoReajuste.DataValueField = "TIPO_REAJUSTE"
            ddlTipoReajuste.DataSource = SQL_Execute.oReader
            ddlTipoReajuste.DataBind()
            ddlTipoReajuste.Items.Insert(0, "(SELECCIONAR)")

        End If

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

            If Request.Form("ddlTipoLicitacion") = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Tipo Licitación."
                ddlTipoLicitacion.Focus()
                Return
            End If

            If Request.Form("ddlMoContratacion") = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Monto Contratacion."
                ddlMoContratacion.Focus()
                Return
            End If

            If Request.Form("txtPresupEstimado") = "0" Or Request.Form("txtPresupEstimado") = "" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Presupuesto Estimado."
                txtPresupEstimado.Focus()
                Return
            End If

            If Request.Form("txtPlazoEstimado") = "0" Or Request.Form("txtPlazoEstimado") = "" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Plazo Estimado."
                txtPlazoEstimado.Focus()
                Return
            End If

            If Request.Form("ddlRegistro") = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Registro."
                ddlRegistro.Focus()
                Return
            End If

            If Request.Form("txtFechaPublicacion") = "" Or Request.Form("txtFechaPublicacion") = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Publicación."
                txtFechaPublicacion.Focus()
                Return
            End If

            If Request.Form("txtFechaAperturaTecnica") = "" Or Request.Form("txtFechaAperturaTecnica") = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Tecnica."
                txtFechaAperturaTecnica.Focus()
                Return
            End If

            If Request.Form("txtFechaAperturaEconomica") = "" Or Request.Form("txtFechaAperturaEconomica") = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Economica."
                txtFechaAperturaEconomica.Focus()
                Return
            End If

            If Request.Form("txtFechaEstimada") = "" Or Request.Form("txtFechaEstimada") = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Inicio Estimada."
                txtFechaEstimada.Focus()
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
            arrValoresParametros(4) = "0"
            arrValoresParametros(5) = ""
            arrValoresParametros(6) = "0"
            arrValoresParametros(7) = ""
            arrValoresParametros(8) = ""
            arrValoresParametros(9) = ""
            arrValoresParametros(10) = "0"
            arrValoresParametros(11) = "0" 'mandante_convenio
            arrValoresParametros(12) = "0" 'correlativo_convenio

            If Request.Form("txtEstado").Trim() = "En Programación" Then
                arrValoresParametros(13) = "Programado"
            Else
                arrValoresParametros(13) = Request.Form("txtEstado").Trim()
            End If

            arrValoresParametros(13) = Request.Form("txtEstado").Trim()
            arrValoresParametros(14) = "0" 'valido

            'seccion A
            arrValoresParametros(15) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlTipoLicitacion"), "")
            arrValoresParametros(16) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlMoContratacion"), "")
            arrValoresParametros(17) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlTipoReajuste"), "")
            arrValoresParametros(18) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaPublicacion"))
            arrValoresParametros(19) = "" 'fecha_ap_estimada 
            arrValoresParametros(20) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaAperturaTecnica"))
            arrValoresParametros(21) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaAperturaEconomica"))
            arrValoresParametros(22) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaEstimada"))
            arrValoresParametros(23) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBAGerenciales"), "")
            arrValoresParametros(24) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBAEspeciales"), "")
            arrValoresParametros(25) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBATecnicas"), "")
            arrValoresParametros(26) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBACarpetaTecnica"), "")
            arrValoresParametros(27) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRegistro"), "")
            arrValoresParametros(28) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlCategoria"), "")
            arrValoresParametros(29) = Func_Libreria.FUNC_MontoSQLv2(Request.Form("txtPresupEstimado"))
            arrValoresParametros(30) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPlazoEstimado"))
            arrValoresParametros(31) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRespAntPPTA"), "")
            arrValoresParametros(32) = Func_Libreria.FUNC_MontoSQLv2(Request.Form("txtAnticipoContemplado"))
            arrValoresParametros(33) = Func_Libreria.FUNC_MontoSQLv2(Request.Form("txtAnticipoContempladoPorc"))
            arrValoresParametros(34) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR26"), "")
            arrValoresParametros(35) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR26"))
            arrValoresParametros(36) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR28"), "")
            arrValoresParametros(37) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR28"))
            arrValoresParametros(38) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR29"), "")
            arrValoresParametros(39) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR29"))
            arrValoresParametros(40) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlReqRegEspecial"), "")
            arrValoresParametros(41) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtNumeroPermEdificacion"))
            arrValoresParametros(42) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaPermEdificacion"))
            arrValoresParametros(43) = Request.Form("txtIDChileCompra")
            arrValoresParametros(44) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlCes"), "")

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

            arrValoresParametros(70) = "A"

            SQL_Execute.FUNC_Ejecuta_SP("SetContratoPropuesta", arrNombreParametros, arrValoresParametros)

            If SQL_Execute.numero_error = 0 Then
                Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
                Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
                Dim strSufijo As String = Page.Request.QueryString("sufijo")

                Dim strURL As String = "mn_edita_contratos_propuesta_b.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo

                Dim strEstatus As String = FUNC_Busca_Estatus_Contrato()

                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
                HttpContext.Current.Response.Write("alert('Este contrato ahora se encuentra en estado (" & strEstatus & ").');")
                HttpContext.Current.Response.Write("window.location.href='" & strURL & "'")
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

    Protected Sub cmdSeguir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSeguir.Click
        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        If Request.Form("txtEstado").Trim() = "En Programación" Then

            Dim strURL As String = "mn_edita_contratos_propuesta_a.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>")
            HttpContext.Current.Response.Write("alert('No puede utilizar esta opción, el contrato no ha cambiado de estado.');")
            HttpContext.Current.Response.Write("window.location.href='" + strURL + "'")
            HttpContext.Current.Response.Write("</SCRIPT>")
            HttpContext.Current.Response.End()
        End If

        Response.Redirect("mn_edita_contratos_propuesta_b.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" & strSufijo)
    End Sub

    Protected Sub ddlRegistro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRegistro.SelectedIndexChanged

        Call Func_Busca_Registros_Conttas_Categoria()

    End Sub

    Private Sub Func_Busca_Registros_Conttas_Categoria()

        Dim strCdigoPIA = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion = Page.Request.QueryString("codigo_region")
        Dim strSufijo = Page.Request.QueryString("sufijo")

        Dim arrNombreParametros(0) As String : arrNombreParametros(0) = "registro"
        Dim arrValoresParametros(0) As String : arrValoresParametros(0) = ddlRegistro.SelectedValue

        SQL_Execute.FUNC_Ejecuta_SP("Get_busca_registros_conttas_categoria", arrNombreParametros, arrValoresParametros)

        If (SQL_Execute.numero_error = 0) Then

            ddlCategoria.DataTextField = "DESC_CATEGORIA"
            ddlCategoria.DataValueField = "categoria"
            ddlCategoria.DataSource = SQL_Execute.oReader
            ddlCategoria.DataBind()
            ddlCategoria.Items.Insert(0, "(SELECCIONAR)")

        Else
            lblError.Text = SQL_Execute.desc_error
        End If

    End Sub

    Protected Sub cmdProgramacion_Tentativa_OnClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPropuestaTentativa.Click
        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        Response.Redirect("propuesta/mn_ing_programacion_tentativa_propuesta.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo)
    End Sub
End Class



