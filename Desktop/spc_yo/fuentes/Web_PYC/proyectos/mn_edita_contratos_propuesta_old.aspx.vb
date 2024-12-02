'///<summary>
'///Creado por: Erick Kleiner - GSI Asesorias
'///Fecha: 23-10-2012
'///Descripción: Pantalla edicion propuesta
'///</summary>
'///
Imports System.Data
Partial Class proyectos_mn_edita_contratos_propuesta_old
    Inherits System.Web.UI.Page

    Dim Func_Libreria As Funciones = New Funciones()
    Dim SQL_Execute As ConexionWS = New ConexionWS()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_propuesta.aspx")

        On Error GoTo error_load

        cmdIngresoMandantes.Attributes.Add("onClick", "target='_blank';")
        cmdRegistroOfertaContratista.Attributes.Add("onClick", "target='_blank';")

        lblError.Text = ""

        txtPresupEstimado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtPlazoEstimado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtAnticipoContemplado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtAnticipoContempladoPorc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtNumeroPermEdificacion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtNDoctoR5.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtPresupuestoOficial.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtPlazoOficial.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtNumResNoAdjudica.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtNumeroRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtMontoAdjudicado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtPlazoAdjudicado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")
        txtDireNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);")

        txtPresupEstimado.Text = "0"
        txtPlazoEstimado.Text = "0"
        txtAnticipoContemplado.Text = "0"
        txtAnticipoContempladoPorc.Text = "0"
        txtNumeroPermEdificacion.Text = "0"
        txtNDoctoR5.Text = "0"
        txtPresupuestoOficial.Text = "0"
        txtPlazoOficial.Text = "0"
        txtNumResNoAdjudica.Text = "0"
        txtNumeroRes.Text = "0"
        txtMontoAdjudicado.Text = "0"
        txtPlazoAdjudicado.Text = "0"
        txtDireNumero.Text = "0"

        txtFechaPermEdificacion.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaPublicacion.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaAperturaTecnica.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaAperturaEconomica.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaDoctoR26.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaDoctoR28.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaDoctoR29.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaDoctoR5.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaLicitacion.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaApertTecnica.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaAperturaTecnicaProp.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaInformeAdj.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaRes.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaTramite.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaResNoAdjudica.Attributes("onclick") = "GetFecha(this, 1, null, null)"

        ddlEstado.Items.Insert(0, "(SELECCIONAR)")
        ddlEstado.Items.Add("Propuesta sin programación")
        ddlEstado.Items.Add("En Programación")
        ddlEstado.Items.Add("Programado")
        ddlEstado.Items.Add("Proceso de Publicación")
        ddlEstado.Items.Add("En proceso de adjudicación")
        ddlEstado.SelectedIndex = 0

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

        txtFechaPermEdificacion.Attributes("onclick") = "GetFecha(this, 1, null, null)"
        txtFechaPermEdificacion.Text = Func_Libreria.FUNC_Trae_Fecha_Proceso("proceso")

        If Not IsPostBack Then

            Dim arrNombreParametros2(2) As String : arrNombreParametros2(0) = "codigo_pia" : arrNombreParametros2(1) = "codigo_region" : arrNombreParametros2(2) = "sufijo"
            Dim arrValoresParametros2(2) As String : arrValoresParametros2(0) = strCdigoPIA : arrValoresParametros2(1) = strCdigoRegion : arrValoresParametros2(2) = strSufijo

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros2, arrValoresParametros2)

            If (SQL_Execute.numero_error = 0) Then

                If (SQL_Execute.oReader.HasRows = False) Then
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n")
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');\n")
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n")
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
                End While

            Else
                lblError.Text = SQL_Execute.desc_error
            End If

            txtAnticipoContempladoPorc.Attributes.Add("onKeyPress", "valida_numeros_decimal(window.event.keyCode, this.value);")

            LlenaCombos()

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

                    ddlComuna.ClearSelection()
                    Dim olstComuna As ListItem
                    olstComuna = ddlComuna.Items.FindByValue(SQL_Execute.oReader("COMUNA").ToString())
                    If IsNothing(olstComuna) = False Then ddlComuna.SelectedValue = olstComuna.Value

                    ddlLocalizacion.ClearSelection()
                    Dim olstLocalizacion As ListItem
                    olstLocalizacion = ddlLocalizacion.Items.FindByValue(SQL_Execute.oReader("CODIGO_LOCALIDAD").ToString())
                    If IsNothing(olstLocalizacion) = False Then ddlLocalizacion.SelectedValue = olstLocalizacion.Value

                    txtDireccion.Text = SQL_Execute.oReader("LOCALIZACION").ToString()
                    txtDireNumero.Text = SQL_Execute.oReader("NUMERO_LOCALIZACION").ToString()

                    'A) P R O G R A M A C I O N   L I C I T A C I O N	

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

                    txtPresupEstimado.Text = SQL_Execute.oReader("MONTO_PROGRAPLAZO_ESTIMADO_EJEC").ToString()
                    txtPlazoEstimado.Text = SQL_Execute.oReader("PLAZO_ESTIMADO_EJEC").ToString()

                    ddlRegistro.ClearSelection()
                    Dim olstRegistro As ListItem
                    olstRegistro = ddlRegistro.Items.FindByValue(SQL_Execute.oReader("REGISTRO").ToString())
                    If IsNothing(olstRegistro) = False Then ddlRegistro.SelectedValue = olstRegistro.Value

                    txtAnticipoContemplado.Text = SQL_Execute.oReader("ANTICIPO_CONTEMPLADO").ToString()
                    txtAnticipoContempladoPorc.Text = SQL_Execute.oReader("ANTIC_CONTEMPL_PORC").ToString()

                    ddlCategoria.ClearSelection()
                    Dim olstCategoria As ListItem
                    olstCategoria = ddlCategoria.Items.FindByValue(SQL_Execute.oReader("CATEGORIA").ToString())
                    If IsNothing(olstCategoria) = False Then ddlCategoria.SelectedValue = olstCategoria.Value

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

                    'B) P R O C E S O   D E   L I C I T A C I O N	

                    ddlResponsableLicitacion.ClearSelection()
                    Dim olstResponsableLicitacion As ListItem
                    olstResponsableLicitacion = ddlResponsableLicitacion.Items.FindByValue(SQL_Execute.oReader("RESP_LCITACION").ToString())
                    If IsNothing(olstResponsableLicitacion) = False Then ddlResponsableLicitacion.SelectedValue = olstResponsableLicitacion.Value

                    ddlLlamado.ClearSelection()
                    Dim olstLlamado As ListItem
                    olstLlamado = ddlLlamado.Items.FindByValue(SQL_Execute.oReader("LLAMADO").ToString())
                    If IsNothing(olstLlamado) = False Then ddlLlamado.SelectedValue = olstLlamado.Value

                    txtNDoctoR5.Text = SQL_Execute.oReader("N_DOCTO_R5").ToString()
                    txtFechaDoctoR5.Text = SQL_Execute.oReader("FECHA_DOCTO_R5").ToString()
                    txtObservaciones.Text = SQL_Execute.oReader("OBSERVACIONES_PROP").ToString()
                    txtPresupuestoOficial.Text = SQL_Execute.oReader("MT_OFI").ToString()
                    txtPlazoOficial.Text = SQL_Execute.oReader("PLAZO_OFICIAL").ToString()
                    txtFechaLicitacion.Text = SQL_Execute.oReader("FECHA_LIC").ToString()
                    txtFechaApertTecnica.Text = SQL_Execute.oReader("F_AP_PROP").ToString()
                    txtFechaAperturaTecnicaProp.Text = SQL_Execute.oReader("F_AP_TECNICA_PROP").ToString()
                    txtNumResNoAdjudica.Text = SQL_Execute.oReader("n_res_no_adjudica").ToString()
                    txtFechaResNoAdjudica.Text = SQL_Execute.oReader("f_res_no_adjudica").ToString()

                    ddlResTipoNoAdjudica.ClearSelection()
                    Dim olstResTipoNoAdjudica As ListItem
                    olstResTipoNoAdjudica = ddlResTipoNoAdjudica.Items.FindByValue(SQL_Execute.oReader("RESULTADO_PROPUESTA").ToString())
                    If IsNothing(olstResTipoNoAdjudica) = False Then ddlResTipoNoAdjudica.SelectedValue = olstResTipoNoAdjudica.Value

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

                    ddlAdjudicado.ClearSelection()
                    Dim olstAdjudicado As ListItem
                    olstAdjudicado = ddlAdjudicado.Items.FindByValue(SQL_Execute.oReader("adjudicado").ToString())
                    If IsNothing(olstAdjudicado) = False Then ddlAdjudicado.SelectedValue = olstAdjudicado.Value

                    txtFechaTramite.Text = SQL_Execute.oReader("F_TRAMI").ToString()

                    'ddlRutContratista.Text = SQL_Execute.oReader("RUT_CON").ToString()
                    ddlRutContratista.ClearSelection()
                    Dim olstRutContratista As ListItem
                    olstRutContratista = ddlRutContratista.Items.FindByValue(SQL_Execute.oReader("RUT_CON").ToString())
                    If IsNothing(olstRutContratista) = False Then ddlRutContratista.SelectedValue = olstRutContratista.Value

                    txtMontoAdjudicado.Text = SQL_Execute.oReader("MTO_OR").ToString()
                    txtPlazoAdjudicado.Text = SQL_Execute.oReader("PLAZO_OR").ToString()

                    'ddlEstado.Text = SQL_Execute.oReader("ESTATUS").ToString()
                    ddlEstado.ClearSelection()
                    Dim olstEstado As ListItem
                    olstEstado = ddlEstado.Items.FindByText(SQL_Execute.oReader("ESTATUS").ToString())
                    If IsNothing(olstEstado) = False Then
                        ddlEstado.SelectedValue = olstEstado.Value
                    Else
                        ddlEstado.Items.Add(SQL_Execute.oReader("ESTATUS").ToString())

                        ddlEstado.ClearSelection()
                        Dim olstEstado2 As ListItem
                        olstEstado2 = ddlEstado.Items.FindByText(SQL_Execute.oReader("ESTATUS").ToString())
                        ddlEstado.SelectedValue = olstEstado2.Value

                    End If


                    txtMandantesConvenio.Value = SQL_Execute.oReader("Cant_Mandantes").ToString()

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
        ddlReqRegEspecial.Items.Add("SI")
        ddlReqRegEspecial.Items.Add("NO")
        ddlReqRegEspecial.Items.Add("FI")
        ddlReqRegEspecial.SelectedIndex = 0

        ddlAplicaCartillaR26.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR26.Items.Add("")
        ddlAplicaCartillaR26.Items.Add("SI")
        ddlAplicaCartillaR26.SelectedIndex = 0

        ddlAplicaCartillaR28.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR28.Items.Add("")
        ddlAplicaCartillaR28.Items.Add("SI")
        ddlAplicaCartillaR28.SelectedIndex = 0

        ddlAplicaCartillaR29.Items.Insert(0, "(SELECCIONAR)")
        ddlAplicaCartillaR29.Items.Add("")
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
        'Provincia
        oxml = ows.GetBusca_Provincia("<parametros><region>" + txtRegion.Text.Trim() + "</region></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)
        Dim DtProvincia As DataTable
        ddlProvincia.DataTextField = "N_PROVI"
        ddlProvincia.DataValueField = "PROVINCIA"
        ddlProvincia.DataSource = oDataset.Tables(1)
        ddlProvincia.DataBind()
        ddlProvincia.Items.Insert(0, "(SELECCIONAR)")
        ' DtProvincia = oDataset.Tables(1)

        oDataset = New DataSet
        'Comunas
        Dim DtComuna As DataTable
        oxml = ows.GetConsultaGeneral("<parametros><tipo>comunas</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)
        DtComuna = oDataset.Tables(1)
        Session("DtComunas") = DtComuna

        Dim Dv As DataView
        Dv = New DataView(DtComuna, "provincia = '" + ddlProvincia.SelectedValue.ToString + "' and region = '" + txtRegion.Text.Trim + "'", "n_comu", DataViewRowState.CurrentRows)

        ddlComuna.Items.Clear()
        ddlComuna.DataTextField = "n_comu"
        ddlComuna.DataValueField = "cod_comun"
        ddlComuna.DataSource = Dv
        ddlComuna.DataBind()
        ddlComuna.Items.Insert(0, "(SELECCIONAR)")

        Dim DtLocal As DataTable
        oDataset = New DataSet
        'Comunas
        oxml = ows.GetConsultaGeneral("<parametros><tipo>localidades</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)
        DtLocal = oDataset.Tables(1)
        Session("DtLocal") = DtLocal

        Dv = New DataView(Session("DtLocal"), "CODIGO_COMUNA = '" + ddlComuna.SelectedValue.ToString() + "'", "NOMBRE_LOCALIDAD", DataViewRowState.CurrentRows)

        ddlLocalizacion.Items.Clear()
        ddlLocalizacion.DataTextField = "NOMBRE_LOCALIDAD"
        ddlLocalizacion.DataValueField = "CODIGO_COMUNA"
        ddlLocalizacion.DataSource = Dv
        ddlLocalizacion.DataBind()
        ddlLocalizacion.Items.Insert(0, "(SELECCIONAR)")

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
        oxml = ows.GetConsultaGeneral("<parametros><tipo>registros_conttas</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlRegistro.DataTextField = "descripcion"
        ddlRegistro.DataValueField = "registro"
        ddlRegistro.DataSource = oDataset.Tables(1)
        ddlRegistro.DataBind()
        ddlRegistro.Items.Insert(0, "(SELECCIONAR)")

        ddlCategoria.DataTextField = "descripcion"
        ddlCategoria.DataValueField = "registro"
        ddlCategoria.DataSource = oDataset.Tables(1)
        ddlCategoria.DataBind()
        ddlCategoria.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        oDataset = New DataSet
        oxml = ows.GetConsultaGeneral("<parametros><tipo>busca_dom_insp_fis</tipo></parametros>")
        stringXml = oxml.OuterXml
        xmlSR = New System.IO.StringReader(stringXml)
        oDataset.ReadXml(xmlSR, XmlReadMode.Auto)

        ddlRespAntPPTA.DataTextField = "nombre"
        ddlRespAntPPTA.DataValueField = "rut"
        ddlRespAntPPTA.DataSource = oDataset.Tables(1)
        ddlRespAntPPTA.DataBind()
        ddlRespAntPPTA.Items.Insert(0, "(SELECCIONAR)")

        ddlResponsableLicitacion.DataTextField = "nombre"
        ddlResponsableLicitacion.DataValueField = "rut"
        ddlResponsableLicitacion.DataSource = oDataset.Tables(1)
        ddlResponsableLicitacion.DataBind()
        ddlResponsableLicitacion.Items.Insert(0, "(SELECCIONAR)")
        oDataset = Nothing

        ddlLlamado.Items.Insert(0, "(SELECCIONAR)")
        ddlLlamado.Items.Add("1")
        ddlLlamado.Items.Add("2")
        ddlLlamado.Items.Add("3")
        ddlLlamado.Items.Add("4")
        ddlLlamado.Items.Add("5")
        ddlLlamado.Items.Add("6")
        ddlLlamado.Items.Add("7")
        ddlLlamado.SelectedIndex = 0

        ddlResTipoNoAdjudica.Items.Insert(0, "(SELECCIONAR)")
        ddlResTipoNoAdjudica.Items.Add("Desierta")
        ddlResTipoNoAdjudica.Items.Add("Fuera de base")
        ddlResTipoNoAdjudica.Items.Add("No conveniente")
        ddlResTipoNoAdjudica.Items.Add("Invalida o Anulada")
        ddlResTipoNoAdjudica.SelectedIndex = 0

        ddlAdjudicado.Items.Insert(0, "(SELECCIONAR)")
        ddlAdjudicado.Items.Add("SI")
        ddlAdjudicado.Items.Add("NO")
        ddlAdjudicado.SelectedIndex = 0

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

        Dim strSeccion As String = ""

        If ddlEstado.Text = "(SELECCIONAR)" Then

            'Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
            'Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
            'Dim strSufijo As String = Page.Request.QueryString("sufijo")

            'Dim strURL As String = "/mn_edita_contratos_propuesta.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo

            'HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n")
            'HttpContext.Current.Response.Write("alert('Debe seleccionar un estado.');\n")
            'HttpContext.Current.Response.Write("window.location.href='" & strURL & "'\n")
            'HttpContext.Current.Response.Write("</SCRIPT>")
            'HttpContext.Current.Response.End()

            lblError.Text = "Debe seleccionar un estado."
            Return
        End If

        If ddlEstado.Text = "Propuesta sin programación" Then
            'seleccionar mandantes
            If txtMandantesConvenio.Value = 0 Then
                lblError.Text = "Para cambiar a Estado 'Propuesta sin programación': Debe ingresar mandantes del convenio."
                txtMandantesConvenio.Focus()
                Return
            End If
        End If

        If ddlEstado.Text = "En Programación" Then
            '0) C A B C E R A
            'SET ESTATUS = "En Programación"
            'PROVINCIA, COMUNA, OBJETO, LOCALIZACION, 

            If ddlProvincia.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe seleccionar provincia."
                ddlProvincia.Focus()
                Return
            End If

            If ddlComuna.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe seleccionar comuna."
                ddlComuna.Focus()
                Return
            End If

            If txtObjeto.Text = "" Then
                lblError.Text = "Para cambiar a Estado 'En Programación': Debe ingresar objeto del contrato."
                txtObjeto.Focus()
                Return
            End If

        End If

        If ddlEstado.Text = "Programado" Then
            'A) P R O G R A M A C I O N   L I C I T A C I O N
            'SET ESTATUS = "Programado"
            'TI_LIC, TI_CON, MONTO_PROGRA, PLAZO_ESTIMADO_EJEC, REGISTRO, FECHA_LIC_PR, FECHA_AP_PR, FECHA_AP_PR_ECO
            'FECHA_AP_PR -> UPDATE PROYECTO SET PROYECTO.ESTADO = 'M' 
            'SQL = "UPDATE CONVENIOS SET CONVENIOS.ESTADO_CONVENIO = 'Por Ejecutar' WHERE (((CONVENIOS.REGION)= Formularios![PropuestasNuevo]!REGION) AND ((CONVENIOS.CODIGO_DA)=Formularios![PropuestasNuevo]!CODIGO_DA) AND ((CONVENIOS.CORRELATIVO)=Formularios![PropuestasNuevo]!CORRELATIVO_CONVENIO)  AND ((CONVENIOS.MANDANTE)=Formularios![PropuestasNuevo]!MANDANTE_CONVENIO));"

            If ddlTipoLicitacion.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Tipo Licitación."
                ddlTipoLicitacion.Focus()
                Return
            End If

            If ddlMoContratacion.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Monto Contratacion."
                ddlMoContratacion.Focus()
                Return
            End If

            If txtPresupEstimado.Text = "0" Or txtPresupEstimado.Text = "" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Presupuesto Estimado."
                txtPresupEstimado.Focus()
                Return
            End If

            If txtPlazoEstimado.Text = "0" Or txtPlazoEstimado.Text = "" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Plazo Estimado."
                txtPlazoEstimado.Focus()
                Return
            End If

            If ddlRegistro.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Registro."
                ddlRegistro.Focus()
                Return
            End If

            If txtFechaPublicacion.Text = "" Or txtFechaPublicacion.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Publicación."
                txtFechaPublicacion.Focus()
                Return
            End If

            If txtFechaAperturaTecnica.Text = "" Or txtFechaAperturaTecnica.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Tecnica."
                txtFechaAperturaTecnica.Focus()
                Return
            End If

            If txtFechaAperturaEconomica.Text = "" Or txtFechaAperturaEconomica.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Economica."
                txtFechaAperturaEconomica.Focus()
                Return
            End If


        End If

        If ddlEstado.Text = "Proceso de Publicación" Then
            'B) P R O C E S O   D E   L I C I T A C I O N
            'SET ESTATUS = "Proceso de Publicación"
            'LLAMADO, MT_OFI, PLAZO_OFICIAL, FECHA_LIC, F_AP_PROP, F_AP_TECNICA_PROP

            If ddlLlamado.Text = "(SELECCIONAR)" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Llamado."
                ddlLlamado.Focus()
                Return
            End If

            If txtPresupuestoOficial.Text = "0" Or txtPresupuestoOficial.Text = "" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Presupuesto Oficial."
                txtPresupuestoOficial.Focus()
                Return
            End If


            If txtPlazoOficial.Text = "0" Or txtPlazoOficial.Text = "" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Plazo Oficial."
                txtPlazoOficial.Focus()
                Return
            End If

            If txtFechaLicitacion.Text = "" Or txtFechaLicitacion.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Licitación."
                txtFechaLicitacion.Focus()
                Return
            End If

            If txtFechaApertTecnica.Text = "" Or txtFechaApertTecnica.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica."
                txtFechaApertTecnica.Focus()
                Return
            End If

            If txtFechaAperturaTecnicaProp.Text = "" Or txtFechaAperturaTecnicaProp.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica Prop."
                txtFechaAperturaTecnicaProp.Focus()
                Return
            End If

        End If

        If ddlEstado.Text = "En proceso de adjudicación" Then
            'C) P R O C E S O   D E   A D J U D I C A C I  O N
            'SET ESTATUS = "En proceso de adjudicación"
            'FECHA_INFORME_ADJUDICACION, 
            'F_TRAMI -> UPDATE PROYECTO SET PROYECTO.ESTADO = 'E'

            If txtFechaInformeAdj.Text = "" Or txtFechaInformeAdj.Text = "01/01/1900" Then
                lblError.Text = "Para cambiar a Estado 'En proceso de adjudicación': Debe ingresar Fecha Apertura Tecnica Prop."
                txtFechaInformeAdj.Focus()
                Return
            End If

        End If

        Dim arrNombreParametros(68) As String
        Dim arrValoresParametros(68) As String

        'nombre parametros
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
        arrNombreParametros(15) = "ti_lic"
        arrNombreParametros(16) = "ti_con"
        arrNombreParametros(17) = "tipo_reajuste"
        arrNombreParametros(18) = "fecha_lic_pr"
        arrNombreParametros(19) = "fecha_ap_estimada"
        arrNombreParametros(20) = "fecha_ap_pr"
        arrNombreParametros(21) = "fecha_ap_pr_eco"
        arrNombreParametros(22) = "bases_admin_generales"
        arrNombreParametros(23) = "bases_admin_especiales"
        arrNombreParametros(24) = "bases_tecnicas"
        arrNombreParametros(25) = "carpeta_tecnica_licitacion"
        arrNombreParametros(26) = "registro"
        arrNombreParametros(27) = "categoria"
        arrNombreParametros(28) = "monto_progra"
        arrNombreParametros(29) = "plazo_estimado_ejec"
        arrNombreParametros(30) = "resp_antecedentes_ppta"
        arrNombreParametros(31) = "anticipo_contemplado"
        arrNombreParametros(32) = "antic_contempl_porc"
        arrNombreParametros(33) = "aplica_cartilla_r_26"
        arrNombreParametros(34) = "fecha_docto_r26"
        arrNombreParametros(35) = "aplica_cartilla_r_28"
        arrNombreParametros(36) = "fecha_docto_r28"
        arrNombreParametros(37) = "aplica_cartilla_r_29"
        arrNombreParametros(38) = "fecha_docto_r29"
        arrNombreParametros(39) = "requiere_reg_especial"
        arrNombreParametros(40) = "n_permiso_edificacion"
        arrNombreParametros(41) = "fecha_permiso_edificacion"
        arrNombreParametros(42) = "id_chile_compra"
        arrNombreParametros(43) = "n_docto_r5"
        arrNombreParametros(44) = "fecha_docto_r5"
        arrNombreParametros(45) = "fecha_lic"
        arrNombreParametros(46) = "f_ap_tecnica_prop"
        arrNombreParametros(47) = "f_ap_prop"
        arrNombreParametros(48) = "plazo_oficial"
        arrNombreParametros(49) = "mt_ofi"
        arrNombreParametros(50) = "observaciones_prop"
        arrNombreParametros(51) = "resultado_propuesta"
        arrNombreParametros(52) = "resp_lcitacion"
        arrNombreParametros(53) = "llamado"
        arrNombreParametros(54) = "n_res_no_adjudica"
        arrNombreParametros(55) = "f_res_no_adjudica"
        arrNombreParametros(56) = "fecha_informe_adjudicacion"
        arrNombreParametros(57) = "mto_or"
        arrNombreParametros(58) = "plazo_or"
        arrNombreParametros(59) = "or_res"
        arrNombreParametros(60) = "n_res"
        arrNombreParametros(61) = "f_res"
        arrNombreParametros(62) = "f_trami"
        arrNombreParametros(63) = "rut_con"
        arrNombreParametros(64) = "com_eval_oferta1"
        arrNombreParametros(65) = "com_eval_oferta2"
        arrNombreParametros(66) = "com_eval_oferta3"
        arrNombreParametros(67) = "adjudicado"
        arrNombreParametros(68) = "seccion"

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
        arrNombreParametros(22) = "bases_admin_generales"
        arrNombreParametros(23) = "bases_admin_especiales"
        arrNombreParametros(24) = "bases_tecnicas"
        arrNombreParametros(25) = "carpeta_tecnica_licitacion"
        arrNombreParametros(26) = "registro"
        arrNombreParametros(27) = "categoria"
        arrNombreParametros(28) = "monto_progra"
        arrNombreParametros(29) = "plazo_estimado_ejec"
        arrNombreParametros(30) = "resp_antecedentes_ppta"
        arrNombreParametros(31) = "anticipo_contemplado"
        arrNombreParametros(32) = "antic_contempl_porc"
        arrNombreParametros(33) = "aplica_cartilla_r_26"
        arrNombreParametros(34) = "fecha_docto_r26"
        arrNombreParametros(35) = "aplica_cartilla_r_28"
        arrNombreParametros(36) = "fecha_docto_r28"
        arrNombreParametros(37) = "aplica_cartilla_r_29"
        arrNombreParametros(38) = "fecha_docto_r29"
        arrNombreParametros(39) = "requiere_reg_especial"
        arrNombreParametros(40) = "n_permiso_edificacion"
        arrNombreParametros(41) = "fecha_permiso_edificacion"
        arrNombreParametros(42) = "id_chile_compra"

        'seccion B
        arrNombreParametros(43) = "n_docto_r5"
        arrNombreParametros(44) = "fecha_docto_r5"
        arrNombreParametros(45) = "fecha_lic"
        arrNombreParametros(46) = "f_ap_tecnica_prop"
        arrNombreParametros(47) = "f_ap_prop"
        arrNombreParametros(48) = "plazo_oficial"
        arrNombreParametros(49) = "mt_ofi"
        arrNombreParametros(50) = "observaciones_prop"
        arrNombreParametros(51) = "resultado_propuesta"
        arrNombreParametros(52) = "resp_lcitacion"
        arrNombreParametros(53) = "llamado"
        arrNombreParametros(54) = "n_res_no_adjudica"
        arrNombreParametros(55) = "f_res_no_adjudica"

        'seccion C
        arrNombreParametros(56) = "fecha_informe_adjudicacion"
        arrNombreParametros(57) = "mto_or"
        arrNombreParametros(58) = "plazo_or"
        arrNombreParametros(59) = "or_res"
        arrNombreParametros(60) = "n_res"
        arrNombreParametros(61) = "f_res"
        arrNombreParametros(62) = "f_trami"
        arrNombreParametros(63) = "rut_con"
        arrNombreParametros(64) = "com_eval_oferta1"
        arrNombreParametros(65) = "com_eval_oferta2"
        arrNombreParametros(66) = "com_eval_oferta3"
        arrNombreParametros(67) = "adjudicado"
        arrNombreParametros(68) = "seccion"

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
        arrValoresParametros(8) = Request.Form("txtObjeto")
        arrValoresParametros(9) = Request.Form("txtDireccion")
        arrValoresParametros(10) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtDireNumero"))
        arrValoresParametros(11) = "0" 'mandante_convenio
        arrValoresParametros(12) = "0" 'correlativo_convenio
        arrValoresParametros(13) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlEstado"), "")
        arrValoresParametros(14) = "0" 'valido

        arrValoresParametros(15) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlTipoLicitacion"), "")
        arrValoresParametros(16) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlMoContratacion"), "")
        arrValoresParametros(17) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlTipoReajuste"), "")
        arrValoresParametros(18) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaPublicacion"))
        arrValoresParametros(19) = "0" 'fecha_ap_estimada 
        arrValoresParametros(20) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaAperturaTecnica"))
        arrValoresParametros(21) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaAperturaEconomica"))
        arrValoresParametros(22) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBAGerenciales"), "")
        arrValoresParametros(23) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBAEspeciales"), "")
        arrValoresParametros(24) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBATecnicas"), "")
        arrValoresParametros(25) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlBACarpetaTecnica"), "")
        arrValoresParametros(26) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRegistro"), "")
        arrValoresParametros(27) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlCategoria"), "")
        arrValoresParametros(28) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPresupEstimado"))
        arrValoresParametros(29) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPresupEstimado"))
        arrValoresParametros(30) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRespAntPPTA"), "")
        arrValoresParametros(31) = Request.Form("txtAnticipoContemplado")
        arrValoresParametros(32) = Request.Form("txtAnticipoContempladoPorc")
        arrValoresParametros(33) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR26"), "")
        arrValoresParametros(34) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR26"))
        arrValoresParametros(35) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR28"), "")
        arrValoresParametros(36) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR28"))
        arrValoresParametros(37) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAplicaCartillaR29"), "")
        arrValoresParametros(38) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR29"))
        arrValoresParametros(39) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlReqRegEspecial"), "")
        arrValoresParametros(40) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtNumeroPermEdificacion"))
        arrValoresParametros(41) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaPermEdificacion"))
        arrValoresParametros(42) = Request.Form("txtIDChileCompra")

        'seccion B
        arrValoresParametros(43) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtNDoctoR5"))
        arrValoresParametros(44) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaDoctoR5"))
        arrValoresParametros(45) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaPublicacion"))
        arrValoresParametros(46) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaAperturaTecnicaProp"))
        arrValoresParametros(47) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaApertTecnica"))
        arrValoresParametros(48) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPlazoOficial"))
        arrValoresParametros(49) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPresupuestoOficial"))
        arrValoresParametros(50) = Request.Form("txtObservaciones")
        arrValoresParametros(51) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlResTipoNoAdjudica"), "")
        arrValoresParametros(52) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlResponsableLicitacion"), "")
        arrValoresParametros(53) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlLlamado"), "0")
        arrValoresParametros(54) = Request.Form("txtNumResNoAdjudica")
        arrValoresParametros(55) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaResNoAdjudica"))

        'seccion C
        arrValoresParametros(56) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaInformeAdj"))
        arrValoresParametros(57) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtMontoAdjudicado"))
        arrValoresParametros(58) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtPlazoAdjudicado"))
        arrValoresParametros(59) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlResOrigen"), "")
        arrValoresParametros(60) = Func_Libreria.FUNC_MontoSQL(Request.Form("txtNumeroRes"))
        arrValoresParametros(61) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaResNoAdjudica"))
        arrValoresParametros(62) = Func_Libreria.FUNC_Fecha_SQL(Request.Form("txtFechaTramite"))
        arrValoresParametros(63) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlRutContratista"), "")
        arrValoresParametros(64) = Request.Form("txtComEval1")
        arrValoresParametros(65) = Request.Form("txtComEval2")
        arrValoresParametros(66) = Request.Form("txtComEval3")
        arrValoresParametros(67) = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form("ddlAdjudicado"), "")
        arrValoresParametros(68) = strSeccion

        SQL_Execute.FUNC_Ejecuta_SP("SetContratoPropuesta", arrNombreParametros, arrValoresParametros)

        If SQL_Execute.numero_error = 0 Then
            Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
            Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")

            Dim strURL As String = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n")
            HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n")
            HttpContext.Current.Response.Write("window.location.href='" & strURL & ".aspx'\n")
            HttpContext.Current.Response.Write("</SCRIPT>")
            HttpContext.Current.Response.End()
        Else

            lblError.Text = "Problemas al actualizar propusta"
        End If


    End Sub

    Protected Sub cmdSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdSalir.Click
        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion)
    End Sub

    Protected Sub ddlProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvincia.SelectedIndexChanged

        Dim Dv As DataView

        Dv = New DataView(Session("DtComunas"), "provincia = '" + ddlProvincia.SelectedValue.ToString() + "' and region = '" + txtRegion.Text.Trim + "'", "n_comu", DataViewRowState.CurrentRows)

        ddlComuna.Items.Clear()
        ddlComuna.DataTextField = "n_comu"
        ddlComuna.DataValueField = "cod_comun"
        ddlComuna.DataSource = Dv
        ddlComuna.DataBind()
        ddlComuna.Items.Insert(0, "(SELECCIONAR)")

    End Sub

    Protected Sub ddlComuna_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlComuna.SelectedIndexChanged

        Dim Dv As DataView

        Dv = New DataView(Session("DtLocal"), "CODIGO_COMUNA = '" + ddlComuna.SelectedValue.ToString() + "'", "NOMBRE_LOCALIDAD", DataViewRowState.CurrentRows)

        ddlLocalizacion.Items.Clear()
        ddlLocalizacion.DataTextField = "NOMBRE_LOCALIDAD"
        ddlLocalizacion.DataValueField = "CODIGO_COMUNA"
        ddlLocalizacion.DataSource = Dv
        ddlLocalizacion.DataBind()
        ddlLocalizacion.Items.Insert(0, "(SELECCIONAR)")

    End Sub

    Protected Sub txtPresupEstimado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPresupEstimado.TextChanged

    End Sub

    Protected Sub FUNC_HabDes(ByVal Estado As Boolean)

        'ddlProvincia.Readonly = Estado
        'ddlComuna.Readonly = Estado
        'ddlLocalizacion.Readonly = Estado
        txtDireccion.ReadOnly = Estado
        txtDireNumero.ReadOnly = Estado

        'ddlReqRegEspecial.Readonly = Estado
        'ddlTipoLicitacion.Readonly = Estado
        'ddlMoContratacion.Readonly = Estado
        'ddlTipoReajuste.Readonly = Estado

        'ddlBAEspeciales.Readonly = Estado
        'ddlBAGerenciales.Readonly = Estado
        'ddlBATecnicas.Readonly = Estado
        'ddlBACarpetaTecnica.Readonly = Estado

        txtPresupEstimado.ReadOnly = Estado
        txtPlazoEstimado.ReadOnly = Estado
        'ddlRegistro.Readonly = Estado
        txtAnticipoContemplado.ReadOnly = Estado
        txtAnticipoContempladoPorc.ReadOnly = Estado
        'ddlCategoria.Readonly = Estado
        'ddlRespAntPPTA.Readonly = Estado

        txtIDChileCompra.ReadOnly = Estado
        txtNumeroPermEdificacion.ReadOnly = Estado
        txtFechaPermEdificacion.ReadOnly = Estado

        txtFechaPublicacion.ReadOnly = Estado
        txtFechaAperturaTecnica.ReadOnly = Estado
        txtFechaAperturaEconomica.ReadOnly = Estado

        'ddlAplicaCartillaR26.Readonly = Estado
        'ddlAplicaCartillaR28.Readonly = Estado
        'ddlAplicaCartillaR29.Readonly = Estado

        txtFechaDoctoR26.ReadOnly = Estado
        txtFechaDoctoR28.ReadOnly = Estado
        txtFechaDoctoR29.ReadOnly = Estado

        'ddlResponsableLicitacion.Readonly = Estado
        'ddlLlamado.Readonly = Estado
        txtNDoctoR5.ReadOnly = Estado
        txtFechaDoctoR5.ReadOnly = Estado
        txtObservaciones.ReadOnly = Estado
        txtPresupuestoOficial.ReadOnly = Estado
        txtPlazoOficial.ReadOnly = Estado
        txtFechaLicitacion.ReadOnly = Estado
        txtFechaApertTecnica.ReadOnly = Estado
        txtFechaAperturaTecnicaProp.ReadOnly = Estado
        txtNumResNoAdjudica.ReadOnly = Estado
        txtFechaResNoAdjudica.ReadOnly = Estado
        'ddlResTipoNoAdjudica.Readonly = Estado

        txtComEval1.ReadOnly = Estado
        txtComEval2.ReadOnly = Estado
        txtComEval3.ReadOnly = Estado
        txtFechaInformeAdj.ReadOnly = Estado

        'ddlResOrigen.Readonly = Estado
        txtNumeroRes.ReadOnly = Estado
        txtFechaRes.ReadOnly = Estado
        'ddlAdjudicado.Readonly = Estado
        txtFechaTramite.ReadOnly = Estado
        'ddlRutContratista.Readonly = Estado
        txtMontoAdjudicado.ReadOnly = Estado
        txtPlazoAdjudicado.ReadOnly = Estado

    End Sub

    Protected Sub FUNC_Estados_Cabecera(ByVal Estado As Boolean)

        If ddlEstado.Text = "Propuesta sin programación" Then

            If Val(txtMandantesConvenio.Value) = 0 Then
                'ddlProvincia.Readonly = Estado
                'ddlComuna.Readonly = Estado
                'ddlLocalizacion.Readonly = Estado
                txtDireccion.ReadOnly = Estado
                txtDireNumero.ReadOnly = Estado
            Else
                'ddlProvincia.Readonly = Estado
                'ddlComuna.Readonly = Estado
                'ddlLocalizacion.Readonly = Estado
                txtDireccion.ReadOnly = Estado
                txtDireNumero.ReadOnly = Estado
            End If

        End If

    End Sub

    Protected Sub FUNC_ProgramacionLicitacion(ByVal Estado As Boolean)

        'ddlReqRegEspecial.Readonly = Estado
        'ddlTipoLicitacion.Readonly = Estado
        'ddlMoContratacion.Readonly = Estado
        'ddlTipoReajuste.Readonly = Estado

        'ddlBAEspeciales.Readonly = Estado
        'ddlBAGerenciales.Readonly = Estado
        'ddlBATecnicas.Readonly = Estado
        'ddlBACarpetaTecnica.Readonly = Estado

        txtPresupEstimado.ReadOnly = Estado
        txtPlazoEstimado.ReadOnly = Estado
        'ddlRegistro.Readonly = Estado
        txtAnticipoContemplado.ReadOnly = Estado
        txtAnticipoContempladoPorc.ReadOnly = Estado
        'ddlCategoria.Readonly = Estado
        'ddlRespAntPPTA.Readonly = Estado

        txtIDChileCompra.ReadOnly = Estado
        txtNumeroPermEdificacion.ReadOnly = Estado
        '--txtFechaPermEdificacion.ReadOnly = Estado

        '--txtFechaPublicacion.ReadOnly = Estado
        '--txtFechaAperturaTecnica.ReadOnly = Estado
        '--txtFechaAperturaEconomica.ReadOnly = Estado

        'ddlAplicaCartillaR26.Readonly = Estado
        'ddlAplicaCartillaR28.Readonly = Estado
        'ddlAplicaCartillaR29.Readonly = Estado

        '--txtFechaDoctoR26.ReadOnly = Estado
        '--txtFechaDoctoR28.ReadOnly = Estado
        '--txtFechaDoctoR29.ReadOnly = Estado

    End Sub

    Protected Sub FUNC_Licitacion(ByVal Estado As Boolean)

        'ddlResponsableLicitacion.Readonly = Estado
        'ddlLlamado.Readonly = Estado
        txtNDoctoR5.ReadOnly = Estado
        '--txtFechaDoctoR5.ReadOnly = Estado
        txtObservaciones.ReadOnly = Estado
        txtPresupuestoOficial.ReadOnly = Estado
        txtPlazoOficial.ReadOnly = Estado
        '--txtFechaLicitacion.ReadOnly = Estado
        '--txtFechaApertTecnica.ReadOnly = Estado
        '--txtFechaAperturaTecnicaProp.ReadOnly = Estado
        txtNumResNoAdjudica.ReadOnly = Estado
        '--txtFechaResNoAdjudica.ReadOnly = Estado
        'ddlResTipoNoAdjudica.Readonly = Estado

    End Sub

    Protected Sub FUNC_Adjudicacion(ByVal Estado As Boolean)
        txtComEval1.ReadOnly = Estado
        txtComEval2.ReadOnly = Estado
        txtComEval3.ReadOnly = Estado
        '--txtFechaInformeAdj.ReadOnly = Estado

        'ddlResOrigen.Readonly = Estado
        txtNumeroRes.ReadOnly = Estado
        '--txtFechaRes.ReadOnly = Estado
        'ddlAdjudicado.Readonly = Estado
        '--txtFechaTramite.ReadOnly = Estado
        'ddlRutContratista.Readonly = Estado
        txtMontoAdjudicado.ReadOnly = Estado
        txtPlazoAdjudicado.ReadOnly = Estado

    End Sub

    Protected Sub cmdIngresoMandantes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIngresoMandantes.Click

        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        Response.Redirect("propuesta/mn_mandantes_contrato.aspx?codigo_pia=" & strCdigoPIA & "&codigo_region=" & strCdigoRegion + "&sufijo=" & strSufijo)

    End Sub

    Protected Sub cmdRegistroOfertaContratista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRegistroOfertaContratista.Click

        Dim strCdigoPIA As String = Page.Request.QueryString("codigo_pia")
        Dim strCdigoRegion As String = Page.Request.QueryString("codigo_region")
        Dim strSufijo As String = Page.Request.QueryString("sufijo")

        Response.Redirect("propuesta/mn_oferta_contrat_contrato.aspx?codigo_pia=" & strCdigoPIA & "&codigo_region=" & strCdigoRegion + "&sufijo=" & strSufijo)

    End Sub
End Class




'estados contrato
'-----------------

'ddlEstado.Items.Add("Propuesta sin programación")
'ddlEstado.Items.Add("En Programación")
'ddlEstado.Items.Add("Programado")
'ddlEstado.Items.Add("Proceso de Publicación")
'ddlEstado.Items.Add("En proceso de adjudicación")


'- Propuesta sin programación
'cuando se crea, se debe ingresar mandantes antes que todo.

'0) C A B C E R A
'SET ESTATUS = "En Programación"
'PROVINCIA, COMUNA, OBJETO, LOCALIZACION, 


'A) P R O G R A M A C I O N   L I C I T A C I O N
'SET ESTATUS = "Programado"
'TI_LIC, TI_CON, MONTO_PROGRA, PLAZO_ESTIMADO_EJEC, REGISTRO, FECHA_LIC_PR, FECHA_AP_PR, FECHA_AP_PR_ECO
'FECHA_AP_PR -> UPDATE PROYECTO SET PROYECTO.ESTADO = 'M' 

'B) P R O C E S O   D E   L I C I T A C I O N
'SET ESTATUS = "Proceso de Publicación"
'LLAMADO, MT_OFI, PLAZO_OFICIAL, FECHA_LIC, F_AP_PROP, F_AP_TECNICA_PROP

'C) P R O C E S O   D E   A D J U D I C A C I  O N
'SET ESTATUS = "En proceso de adjudicación"
'FECHA_INFORME_ADJUDICACION, 

'F_TRAMI -> UPDATE PROYECTO SET PROYECTO.ESTADO = 'E'
