using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Collections;

public partial class mn_edi_proyectos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        Func_Libreria.FUNC_Valida_Sesion("/mn_ing_proyectos.aspx");
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;


       

        txtOficioApoyo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        
        txtUsuarios.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtBeneficiarios.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtTerritorioNumeroCert.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtProgramaFinal.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtProgramaFinal.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtProgramaFinal.Attributes.Add("onblur", "javascript:mathRoundForTaxes(this.id,2);");

        txtSuperficie.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtSuperficie.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtSuperficie.Attributes.Add("onblur", "javascript:mathRoundForTaxes(this.id,2);");

        
        cmdGrabar.Attributes.Add("onClick", "target='_self';");
        cmdSalir.Attributes.Add("onClick", "target='_self';");
        cmdConveniosMandantes.Attributes.Add("onClick", "target='_self';");
        cmdModuloPatrimonio.Attributes.Add("onClick", "target='_self';");
        
        /**********************************************************************/
        lblUsuario.Text = Session["ID_Usuario"].ToString();
        lblPerfil.Text = Session["ID_Desc_Tipo_Usuario"].ToString();
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");

        arrNombreParametros = new string[] { "usuario" };
        arrValoresParametros = new string[] { lblUsuario.Text };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Datos_Usuario", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                lblCorreo.Text = "(" + SQL_Execute.oReader["correo_electronico"].ToString() + ")";                 
            }
        }
        
        /**********************************************************************/

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
                
        if (!IsPostBack)
        {
            if (lblUsuario.Text.ToUpper() == "JORGE.ESTAY")
                ddlEstadoProyecto.Enabled = true;
            
         
            txtOficioApoyo.Text = "0";
            txtProgramaFinal.Text = "0";
            txtUsuarios.Text = "0";
            txtBeneficiarios.Text = "0";
            txtTerritorioNumeroCert.Text = "0";
            txtSuperficie.Text = "0";


            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyecto_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    txtRegion.Text = SQL_Execute.oReader["region"].ToString();
                    txtObjeto.Text = SQL_Execute.oReader["objeto"].ToString();                    
                    txtPIA.Text = SQL_Execute.oReader["codigo_da"].ToString();                    
                    txtTipoProyecto.Text = SQL_Execute.oReader["tipo_proy"].ToString();
                    txtCodigoPRIGRH.Text = SQL_Execute.oReader["CODIGO_PRIGRH"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /*******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_planes");

            if (SQL_Execute.numero_error == 0)
            {
                ddlPlan.DataSource = SQL_Execute.oReader;
                ddlPlan.DataTextField = "codigo_nombre";
                ddlPlan.DataValueField = "Codigo_plan";
                ddlPlan.DataBind();
                ddlPlan.Items.Insert(0, "(SELECCIONAR)");
            }

            /*******************************************************************************************/

            ddlSeguimiento.Items.Insert(0, "(SELECCIONAR)");
            ddlSeguimiento.Items.Add("Si");
            ddlSeguimiento.Items.Add("No");


            ddlCes.Items.Insert(0, "(SELECCIONAR)");
            ddlCes.Items.Add("1.TDRe EE y CA");
            ddlCes.Items.Add("2.PreCertificación CES");
            ddlCes.Items.Add("3.Certificación CES");
            ddlCes.Items.Add("4.No");


            
            /*******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_pry_estadoproys_list");

            if (SQL_Execute.numero_error == 0)
            {
                ddlEstadoProyecto.DataSource = SQL_Execute.oReader;
                ddlEstadoProyecto.DataTextField = "descripcion";
                ddlEstadoProyecto.DataValueField = "estado";
                ddlEstadoProyecto.DataBind();
                ddlEstadoProyecto.Items.Insert(0, "(SELECCIONAR)");
            }

            /*******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_etapas_bitacora");

            if (SQL_Execute.numero_error == 0)
            {
                ddlEtapaIdea.DataSource = SQL_Execute.oReader;
                ddlEtapaIdea.DataTextField = "NOMBRE";
                ddlEtapaIdea.DataValueField = "NUMERO_ETAPA";
                ddlEtapaIdea.DataBind();
                ddlEtapaIdea.Items.Insert(0, "(SELECCIONAR)");

            }

            /*******************************************************************************************/
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis");

            if (SQL_Execute.numero_error == 0)
            {
                ddlResponsableIdea.DataSource = SQL_Execute.oReader;
       
                ddlResponsableIdea.DataTextField = "rut_nombre"; 
                ddlResponsableIdea.DataValueField = "rut";
                ddlResponsableIdea.DataBind();
                ddlResponsableIdea.Items.Insert(0, "(SELECCIONAR)");
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis");

            if (SQL_Execute.numero_error == 0)
            {
                ddlResponsableConvenio.DataSource = SQL_Execute.oReader;
                
                ddlResponsableConvenio.DataTextField = "rut_nombre"; 
                ddlResponsableConvenio.DataValueField = "rut";
                ddlResponsableConvenio.DataBind();
                ddlResponsableConvenio.Items.Insert(0, "(SELECCIONAR)");
            }
            /*******************************************************************************************/
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_sector_destino");

            if (SQL_Execute.numero_error == 0)
            {
                ddlSectorDestino.DataSource = SQL_Execute.oReader;
                ddlSectorDestino.DataTextField = "codigo_nombre";
                ddlSectorDestino.DataValueField = "SECTOR_DESTINO";
                ddlSectorDestino.DataBind();
                ddlSectorDestino.Items.Insert(0, "(SELECCIONAR)");
            }

            /*******************************************************************************************/
            arrNombreParametros = new string[] { "region" };
            arrValoresParametros = new string[] { txtRegion.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Provincia", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlProvincia.DataSource = SQL_Execute.oReader;
                ddlProvincia.DataTextField = "N_PROVI";
                ddlProvincia.DataValueField = "PROVINCIA";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, "(SELECCIONAR)");
            }            
            
            /*******************************************************************************************/
            arrNombreParametros = new string[] { "tipologia" };
            arrValoresParametros = new string[] { txtTipoProyecto.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetPryProcesosList", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlProceso.DataSource = SQL_Execute.oReader;
                ddlProceso.DataTextField = "codigo_nombre";
                ddlProceso.DataValueField = "proceso";
                ddlProceso.DataBind();
                ddlProceso.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /*******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_tipo_fondos");

            if (SQL_Execute.numero_error == 0)
            {
                ddlFondo.DataSource = SQL_Execute.oReader;
                ddlFondo.DataTextField = "descripcion";
                ddlFondo.DataValueField = "codigo";
                ddlFondo.DataBind();
                ddlFondo.Items.Insert(0, "(SELECCIONAR)");
            }

            /*******************************************************************************************/
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_ti_con");

            if (SQL_Execute.numero_error == 0)
            {
                ddlMoContratacionP.DataSource = SQL_Execute.oReader;
                ddlMoContratacionP.DataTextField = "DESCRIPCION";
                ddlMoContratacionP.DataValueField = "TI_CON";
                ddlMoContratacionP.DataBind();
                ddlMoContratacionP.Items.Insert(0, "(SELECCIONAR)");
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_BuscaTipoReajuste");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoReajusteP.DataSource = SQL_Execute.oReader;
                ddlTipoReajusteP.DataTextField = "DESCRIP";
                ddlTipoReajusteP.DataValueField = "TIPO_REAJUSTE";
                ddlTipoReajusteP.DataBind();
                ddlTipoReajusteP.Items.Insert(0, "(SELECCIONAR)");
            }

            /*******************************************************************************************/
            
            ddlRate.Items.Insert(0, "(SELECCIONAR)");
            ddlRate.Items.Add("RS");
            ddlRate.Items.Add("FI");
            ddlRate.Items.Add("OT");
            
            /*******************************************************************************************/

            ddlPropiedad.Items.Insert(0, "(SELECCIONAR)");
            ddlPropiedad.Items.Add("Fiscal");
            ddlPropiedad.Items.Add("Privado");
            ddlPropiedad.Items.Add("Mixto");
                           
            /*******************************************************************************************/
            
            ddlCondicionesTecnicas.Items.Insert(0, "(SELECCIONAR)");
            ddlCondicionesTecnicas.Items.Insert(1, new ListItem("Si", "S"));
            ddlCondicionesTecnicas.Items.Insert(2, new ListItem("No", "N"));
            ddlCondicionesTecnicas.Items.Insert(3, new ListItem("Falta Inf.","F"));
                        
            /*******************************************************************************************/

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };

            string strComuna = "";
            string strSubSector = "";
            string strTipologia = "";

            SQL_Execute.FUNC_Ejecuta_SP("GetBuscaDetalleProyecto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem olstPlan = ddlPlan.Items.FindByValue(SQL_Execute.oReader["PLAN"].ToString());
                    if (olstPlan != null) ddlPlan.SelectedValue = olstPlan.Value;
                                        
                    ListItem olstSeguimiento = ddlSeguimiento.Items.FindByValue(SQL_Execute.oReader["SEGUIMIENTO_P"].ToString());
                    if (olstSeguimiento != null) ddlSeguimiento.SelectedValue = olstSeguimiento.Value;

                    ListItem olstCes = ddlCes.Items.FindByValue(SQL_Execute.oReader["CES"].ToString());
                    if (olstCes != null) ddlCes.SelectedValue = olstCes.Value;

                    hddEstado.Value = SQL_Execute.oReader["ESTADO"].ToString();

                    ListItem olstEstadoProyecto = ddlEstadoProyecto.Items.FindByValue(SQL_Execute.oReader["ESTADO"].ToString());
                    if (olstEstadoProyecto != null) ddlEstadoProyecto.SelectedValue = olstEstadoProyecto.Value;

                    txtFechaHito.Text = SQL_Execute.oReader["F_HITO"].ToString();
                    txtCodigoBIP.Text = SQL_Execute.oReader["CODIGO_BIP"].ToString();
                    txtDVBIP.Text = SQL_Execute.oReader["PARTE_BIP"].ToString();
                    txtFechaTerminoProyecto.Text = SQL_Execute.oReader["FECHA_TERMINO_PROYECTO"].ToString();
                    ddlEtapaIdea.Text = SQL_Execute.oReader["ETAPA_IDEA"].ToString();
                    
                 

                    txtFechaLiquidacionProyecto.Text = SQL_Execute.oReader["FECHA_LIQUIDACION_PROYECTO"].ToString();
                                        
                    ListItem olstResponsableIdea = ddlResponsableIdea.Items.FindByValue(SQL_Execute.oReader["RESPONSABLE_IDEA"].ToString());
                    if (olstResponsableIdea != null) ddlResponsableIdea.SelectedValue = olstResponsableIdea.Value;

                    ListItem olsResponsableConvenio = ddlResponsableConvenio.Items.FindByValue(SQL_Execute.oReader["RESPONSABLE_CONVENIO"].ToString());
                    if (olsResponsableConvenio != null) ddlResponsableConvenio.SelectedValue = olsResponsableConvenio.Value;

                    txtOficioApoyo.Text = SQL_Execute.oReader["OFICIO_APOYO"].ToString();
                    txtFechaOficioApoyo.Text = SQL_Execute.oReader["FECHA_OFICIO_APOYO"].ToString();

                    ListItem olstSectorDestino = ddlSectorDestino.Items.FindByValue(SQL_Execute.oReader["SECTOR_DESTINO"].ToString());
                    if (olstSectorDestino != null) ddlSectorDestino.SelectedValue = olstSectorDestino.Value;

                    strSubSector = SQL_Execute.oReader["SUB_SECTOR"].ToString();

                    strTipologia = SQL_Execute.oReader["TIPOLOGIA"].ToString();
                                        
                    ListItem olstProvincia = ddlProvincia.Items.FindByValue(SQL_Execute.oReader["PROVINCIA"].ToString());
                    if (olstProvincia != null) ddlProvincia.SelectedValue = olstProvincia.Value;

                    ListItem olstFondo = ddlFondo.Items.FindByValue(SQL_Execute.oReader["FONDO"].ToString());
                    if (olstFondo != null) ddlFondo.SelectedValue = olstFondo.Value;

                    txtProgramaFinal.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PROGRAMA_FINAL"].ToString(), 2); 

                    strComuna = SQL_Execute.oReader["COMUNA"].ToString();

                    ListItem olstRate = ddlRate.Items.FindByValue(SQL_Execute.oReader["RATE"].ToString());
                    if (olstRate != null) ddlRate.SelectedValue = olstRate.Value;
                                        
                    ListItem olstProceso = ddlProceso.Items.FindByValue(SQL_Execute.oReader["PROCESO"].ToString());
                    if (olstProceso != null) ddlProceso.SelectedValue = olstProceso.Value;

                    txtObjeto.Text = SQL_Execute.oReader["OBJETO"].ToString();
                    txtDescripcion.Text = SQL_Execute.oReader["DESCRIPCION_PROYECTO"].ToString();

                    txtUsuarios.Text = SQL_Execute.oReader["USUARIOS"].ToString();
                    txtBeneficiarios.Text = SQL_Execute.oReader["BENEFICIARIOS"].ToString();
                    
                    chkFactElectrica.Checked = Func_Libreria.FUNC_Cheked(SQL_Execute.oReader["FACTIBILIDAD_ELECTRICA"].ToString());
                    chkFactAgua.Checked = Func_Libreria.FUNC_Cheked(SQL_Execute.oReader["FACTIBILIDAD_AGUA"].ToString());
                    chkFactAlcantarillado.Checked = Func_Libreria.FUNC_Cheked(SQL_Execute.oReader["FACTIBILIDAD_ALCANTARILLADO"].ToString());

                    txtTerritorioNumeroCert.Text = SQL_Execute.oReader["TERRENO_NUMERO_CERTIF"].ToString();
                    txtTerritorioFechaCerificado.Text = SQL_Execute.oReader["TERRENO_FECHA_CERTIFICADO"].ToString();
                    txtSuperficie.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["SUPERFICIE"].ToString(), 2);
                    
                    
                    ddlPropiedad.Text = SQL_Execute.oReader["PROPIEDAD"].ToString();
                    ListItem olstPropiedad = ddlPropiedad.Items.FindByValue(SQL_Execute.oReader["PROPIEDAD"].ToString());
                    if (olstPropiedad != null) ddlPropiedad.SelectedValue = olstPropiedad.Value;

                    ListItem olstCondicionesTecnicas = ddlCondicionesTecnicas.Items.FindByValue(SQL_Execute.oReader["CONDICIONES_TECNICAS"].ToString());
                    if (olstCondicionesTecnicas != null) ddlCondicionesTecnicas.SelectedValue = olstCondicionesTecnicas.Value;

                    txtObservaciones.Text = SQL_Execute.oReader["TERRENO_OBSERVACIONES"].ToString();
                    chkObrasComplementarias.Checked = Func_Libreria.FUNC_Cheked(SQL_Execute.oReader["OBRAS_COMPLEMENTARIAS"].ToString());

                    txtCodigoExploratorio.Text = SQL_Execute.oReader["CODIGO_PROYECTO_EXP"].ToString();
               //se consulta en la base de datos por CODIGO_PROYECTO_EXP y se devuelve su valor a traves de txtcodigoexploratorio

                    txtFechaEstimadaFirmaConvenio.Text = SQL_Execute.oReader["FECHA_EST_FIRMA_CONVENIO"].ToString();

                    txtFechaEstimadaPublicacion.Text = SQL_Execute.oReader["FECHA_EST_PUBLICACION"].ToString();

                    txtFechaEstimadaInicio.Text = SQL_Execute.oReader["FECHA_EST_INICIO"].ToString();

                    txtFechaEstimadaTermino.Text = SQL_Execute.oReader["FECHA_EST_TERMINO"].ToString();

                    ListItem olstMoContratacionP = ddlMoContratacionP.Items.FindByValue(SQL_Execute.oReader["TI_CONP"].ToString());
                    if (olstMoContratacionP != null) ddlMoContratacionP.SelectedValue = olstMoContratacionP.Value;

                    ListItem olstReajuste = ddlTipoReajusteP.Items.FindByValue(SQL_Execute.oReader["TIPO_REAJUSTEP"].ToString());
                    if (olstReajuste != null) ddlTipoReajusteP.SelectedValue = olstReajuste.Value;
                 
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /*******************************************************************************************/

            arrNombreParametros = new string[] { "region", "provincia" };
            arrValoresParametros = new string[] { strCdigoRegion, ddlProvincia.SelectedValue.ToString() };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Comunas_Sector", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlComuna.DataSource = SQL_Execute.oReader;
                ddlComuna.DataTextField = "N_COMU";
                ddlComuna.DataValueField = "COMUNA";
                ddlComuna.DataBind();
                ddlComuna.Items.Insert(0, "(SELECCIONAR)");

                ListItem olstComuna = ddlComuna.Items.FindByValue(strComuna);
                if (olstComuna != null) ddlComuna.SelectedValue = olstComuna.Value;
            }

            /*******************************************************************************************/

            arrNombreParametros = new string[] { "sector_destino" };
            arrValoresParametros = new string[] { ddlSectorDestino.SelectedValue.ToString() };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_SubSector_Sector", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlSubSector.DataSource = SQL_Execute.oReader;
                ddlSubSector.DataTextField = "DESCRIPCION";
                ddlSubSector.DataValueField = "SUBSECTOR";
                ddlSubSector.DataBind();
                ddlSubSector.Items.Insert(0, "(SELECCIONAR)");

                ListItem olstSubSector = ddlSubSector.Items.FindByValue(strSubSector);
                if (olstSubSector != null) ddlSubSector.SelectedValue = olstSubSector.Value;
            }

            /*******************************************************************************************/

            arrNombreParametros = new string[] { "sector_destino", "sub_sector" };
            arrValoresParametros = new string[] { ddlSectorDestino.SelectedValue.ToString(), ddlSubSector.SelectedValue.ToString() };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Tipologias_Sector", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipologia.DataSource = SQL_Execute.oReader;
                ddlTipologia.DataTextField = "DESCRIPCION";
                ddlTipologia.DataValueField = "TIPOLOGIA";
                ddlTipologia.DataBind();
                ddlTipologia.Items.Insert(0, "(SELECCIONAR)");

                ListItem olstTipologia = ddlTipologia.Items.FindByValue(strTipologia);
                if (olstTipologia != null) ddlTipologia.SelectedValue = olstTipologia.Value;
            }
            /*******************************************************************************************/

        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }
    
    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        string strURLPostGrabar = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        string strEstadoProyecto = "";

        if (ddlEstadoProyecto.Enabled == true)
            strEstadoProyecto = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEstadoProyecto"],"");
        else
            strEstadoProyecto = hddEstado.Value;

        
        arrNombreParametros = new string[] {    "region",
                                                "codigo_da",
                                                "plan",
                                                "proceso",
                                                "objeto",
                                                "codigo_bip",
                                                "monto_estimado_idea",
                                                "responsable_idea",
                                                "responsable_convenio",
                                                "parte_bip",
                                                "provincia",
                                                "comuna",
                                                "ubicacion",
                                                "terreno_numero_certif",
                                                "terreno_fecha_certificado",
                                                "descripcion_proyecto",
                                                "factibilidad_electrica",
                                                "factibilidad_agua",
                                                "factibilidad_alcantarillado",
                                                "condiciones_tecnicas",
                                                "terreno_observaciones",
                                                "sector_destino",
                                                "sub_sector",
                                                "tipologia",
                                                "fecha_estado",
                                                "estado",
                                                "tipo_proy",
                                                "fecha_evaluacion",
                                                "monto_estimado",
                                                "beneficio",
                                                "propiedad",
                                                "superficie",
                                                "programa_inicial",
                                                "programa_final",
                                                "m2_arquitectura",
                                                "profesional_arquitectura",
                                                "m2_ingenieria",
                                                "profesional_ingenieria",
                                                "obras_complementarias",
                                                "fecha_ingreso",
                                                "fecha_termino_proyecto",
                                                "fecha_liquidacion_proyecto",
                                                "coordenadas",
                                                "usuarios",
                                                "beneficiarios",
                                                "patrimonial",
                                                "oficio_apoyo",
                                                "fecha_oficio_apoyo",
                                                "f_i_a_t",
                                                "f_t_a_t_estimada",
                                                "f_t_a_t",
                                                "resp_at",
                                                "producto",
                                                "fondo",
                                                "f_hito",
                                                "seguimiento_p",
                                                "tipo_apoyo_tecnico",
                                                "tipo_ase",
                                                "proteccion_patrimonial",
                                                "material",
                                                "rate",
                                                "etapa_idea",
                                                "codigo_proyecto_exp",
                                                "fecha_est_firma_convenio",
                                                "fecha_est_publicacion",
                                                "fecha_est_inicio",
                                                "fecha_est_termino",
                                                "codigo_prigrh",
                                                "modalidad",
                                                "reajuste",
                                                "ces",
                                                 };

        arrValoresParametros = new string[] {   Request.Form["txtRegion"],
                                                Request.Form["txtPIA"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlPlan"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProceso"],""),
                                                Request.Form["txtObjeto"],
                                                Request.Form["txtCodigoBIP"],
                                                "",
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResponsableIdea"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResponsableConvenio"],""),
                                                Request.Form["txtDVBIP"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProvincia"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlComuna"],""),
                                                "",
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtTerritorioNumeroCert"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtTerritorioFechaCerificado"]),
                                                Request.Form["txtDescripcion"],
                                                Func_Libreria.FUNC_ChekedSQL(Request.Form["chkFactElectrica"]),
                                                Func_Libreria.FUNC_ChekedSQL(Request.Form["chkFactAgua"]),
                                                Func_Libreria.FUNC_ChekedSQL(Request.Form["chkFactAlcantarillado"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCondicionesTecnicas"],""),
                                                Request.Form["txtObservaciones"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSectorDestino"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSubSector"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipologia"],""),
                                                "",
                                                strEstadoProyecto,
                                                "",
                                                "",
                                                "0",
                                                "",
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlPropiedad"],""),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtSuperficie"]),
                                                "0",
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtProgramaFinal"]),
                                                "0",
                                                "",
                                                "0",
                                                "",
                                                Func_Libreria.FUNC_ChekedSQL(Request.Form["chkObrasComplementarias"]),
                                                "",
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaTerminoProyecto"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaLiquidacionProyecto"]),
                                                "",
                                                Request.Form["txtUsuarios"],
                                                Request.Form["txtBeneficiarios"],                                                
                                                "",
                                                Request.Form["txtOficioApoyo"],
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaOficioApoyo"]),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFondo"],""),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaHito"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSeguimiento"],""),
                                                "",
                                                "0",
                                                "",  
                                                "0", 
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlRate"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEtapaIdea"],"0"),
                                                Request.Form["txtCodigoExploratorio"],
                                                //se solicita el codigo en el formulario
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstimadaFirmaConvenio"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstimadaPublicacion"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstimadaInicio"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstimadaTermino"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtCodigoPRIGRH"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMoContratacionP"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoReajusteP"],""),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCes"],""),
                                                
                                                };


        SQL_Execute.FUNC_Ejecuta_SP("SetGrabaDetalleProyecto", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strBackPage = "mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strBackPage + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();            
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
    }
    
    

    protected void ddlSectorDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "sector_destino" };
        arrValoresParametros = new string[] { ddlSectorDestino.SelectedValue.ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_SubSector_Sector", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlSubSector.DataSource = SQL_Execute.oReader;
            ddlSubSector.DataTextField = "DESCRIPCION";
            ddlSubSector.DataValueField = "SUBSECTOR";
            ddlSubSector.DataBind();
            ddlSubSector.Items.Insert(0, "(SELECCIONAR)");
        }


        /********************************************************************************************************/
        /*
        arrNombreParametros = new string[] { "SECTOR_DESTINO", "SUB_SECTOR" };
        arrValoresParametros = new string[] { ddlSectorDestino.SelectedValue.ToString(), Request.Form["ddlSubSector"] };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Tipologias_Sector", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlTipologia.DataSource = SQL_Execute.oReader;
            ddlTipologia.DataTextField = "DESCRIPCION";
            ddlTipologia.DataValueField = "TIPOLOGIA";
            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, "(SELECCIONAR)");
        }*/

        ddlTipologia.Items.Clear();
        ddlTipologia.Items.Insert(0, "(SELECCIONAR)");

    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "region", "provincia" };
        arrValoresParametros = new string[] { Request.Form["txtRegion"], ddlProvincia.SelectedValue.ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Comunas_Sector", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlComuna.DataSource = SQL_Execute.oReader;
            ddlComuna.DataTextField = "N_COMU";
            ddlComuna.DataValueField = "COMUNA";
            ddlComuna.DataBind();
            ddlComuna.Items.Insert(0, "(SELECCIONAR)");
        }
    }
    protected void ddlSubSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "sector_destino", "sub_sector" };
        arrValoresParametros = new string[] { Request.Form["ddlSectorDestino"], ddlSubSector.SelectedValue.ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Tipologias_Sector", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlTipologia.DataSource = SQL_Execute.oReader;
            ddlTipologia.DataTextField = "DESCRIPCION";
            ddlTipologia.DataValueField = "TIPOLOGIA";
            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, "(SELECCIONAR)");
        }
    }

    //--------------------------------------------------------------------
    protected void cmdConexionExplo_Click(object sender, EventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCodigoBIP = string.Concat(Request.Form["txtCodigoBIP"] + "-" + Request.Form["txtDVBIP"]);
        string strExiste = "";
        string strCodigoProyecto = "";
        string strNombreProyecto = "";
        string strCodigoRegion = "";
        string strCodigoProvincia = "";
        string strCodigoComuna = "";
        string strCodigoProceso = "";
        string strObjeto = "";
        string strM2Superficie = "";
        string strUsuarios = "";
        string strBeneficiarios = "";
        string srtRetorno = "";

        strCodigoProyecto = Request.Form["txtCodigoExploratorio"];
        //una vez hecho el guardado de datos,el input de codigo exploratorio se almacena en strcodigoproyceto
        lblMSGExplo.Text = "";

        if (txtCodigoBIP.Text.Trim().ToString() == "")
        {
            lblError.Text = "Debe Ingresar Codigo BIP";
            return;
        }

        if (ddlEtapaIdea.SelectedValue.Equals("(SELECCIONAR)"))
        {
            lblError.Text = "Debe seleccionar una etapa actual de la IDEA";
            return;
        }

        if (strCodigoProyecto.Trim().ToString() != "")
        {
            lblError.Text = "Proyecto ya posee Código Proyecto Exploratorio, no se puede obtener otro.";
            return;
        }

        if (txtCodigoBIP.Text.Trim().ToString() != "")
        {
            arrNombreParametros = new string[] { "codigo_bip" };
            arrValoresParametros = new string[] { strCodigoBIP };

            SQL_Execute.FUNC_Ejecuta_SP("GetObtener_Numero_Exploratorio", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    strExiste = SQL_Execute.oReader["existe"].ToString();

                    if (strExiste == "0")
                    {
                        strCodigoProyecto = SQL_Execute.oReader["CodigoProyecto"].ToString();//
                        strNombreProyecto = "";
                        strCodigoRegion = "";
                        strCodigoProvincia = "";
                        strCodigoComuna = "";
                        strCodigoProceso = "";
                        strObjeto = "";
                        strM2Superficie = "";
                        strUsuarios = "";
                        strBeneficiarios = "";
                        srtRetorno = "OK0";
                        txtCodigoExploratorio.Text = strCodigoProyecto;
                    }
                    else
                    {
                        strCodigoProyecto = SQL_Execute.oReader["CodigoProyecto"].ToString();
                        strNombreProyecto = SQL_Execute.oReader["NombreProyecto"].ToString();
                        strCodigoRegion = SQL_Execute.oReader["CodigoProvincia"].ToString();
                        strCodigoProvincia = SQL_Execute.oReader["CodigoRegion"].ToString();
                        strCodigoComuna = SQL_Execute.oReader["CodigoComuna"].ToString();
                        strCodigoProceso = SQL_Execute.oReader["CodigoProceso"].ToString();
                        strObjeto = SQL_Execute.oReader["Objeto"].ToString();
                        strM2Superficie = SQL_Execute.oReader["M2Superficie"].ToString();
                        strUsuarios = SQL_Execute.oReader["Usuarios"].ToString();
                        strBeneficiarios = SQL_Execute.oReader["Beneficiarios"].ToString();
                        srtRetorno = "OK1";
                        txtCodigoExploratorio.Text = strCodigoProyecto; //
                    }
                }
            }
            else
            {

                lblMSGExplo.Text = "Problemas de conexion con Exploratorio, no se puede obtener codigo proyecto.";
                srtRetorno = "ERROR";
            }

            if (srtRetorno.Trim().ToUpper() == "ERROR")
            {
                lblMSGExplo.Text = srtRetorno;
                return;
            }

            string EtapaIdea = ddlEtapaIdea.SelectedValue.ToString();
            string strEtapaIdea = "";
            switch(EtapaIdea)
            {
                case "1":
                    strEtapaIdea = "PREFACTIBILIDAD";
                    break;
                case "2":
                    strEtapaIdea = "FACTIBILIDAD";
                    break;
                case "3":
                    strEtapaIdea = "DISEÑO";
                    break;
                case "4":
                    strEtapaIdea = "EJECUCION";
                    break;
                default:
                    break;
            }


            if (srtRetorno.Trim().ToUpper() == "OK0")
            {
                txtCodigoExploratorio.Text = strCodigoProyecto;

                arrNombreParametros = new string[] {"CodigoProyecto",
                                                    "CodigoProceso",
                                                    "NombreProyecto",
                                                    "Objeto",
                                                    "CodigoRegion",
                                                    "CodigoProvincia",
                                                    "CodigoComuna",
                                                    "Codigobip",
                                                    "AnoInicio",
                                                    "MontoEstimado",
                                                    "EtapaMideplan",
                                                    "MontoEstimadoxEtapa"
                                                    };

                arrValoresParametros = new string[] {  strCodigoProyecto
                                                   , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProceso"], "")
                                                   , Request.Form["txtObjeto"]
                                                   , Request.Form["txtObjeto"]
                                                   , Request.Form["txtRegion"]
                                                   , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProvincia"], "0")
                                                   , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlComuna"], "0")
                                                   , strCodigoBIP
                                                   , "0"
                                                   , "0"
                                                   , strEtapaIdea
                                                   , "0"};

                SQL_Execute.FUNC_Ejecuta_SP("SetGraba_Datos_Exploratorio", arrNombreParametros, arrValoresParametros);

                if (SQL_Execute.numero_error == 0)
                {
                    lblMSGExplo.Text = "Código, rescatado con éxito, verifique 'Código Exploratorio' al inicio de la pantalla.";
                }
                else
                {
                    lblMSGExplo.Text = "Problemas de conexion con Exploratorio, no se puede grabar proyecto.";
                }

                return;
            }

            if (srtRetorno.Trim().ToUpper() == "OK1")
            {
                txtCodigoExploratorio.Text = strCodigoProyecto;

                txtObjeto.Text = strObjeto;

                ListItem olstProvincia = ddlProvincia.Items.FindByValue(strCodigoProvincia);
                if (olstProvincia != null) ddlProvincia.SelectedValue = olstProvincia.Value;

                ListItem olstComuna = ddlComuna.Items.FindByValue(strCodigoComuna);
                if (olstComuna != null) ddlComuna.SelectedValue = olstComuna.Value;

                ListItem olstProceso = ddlProceso.Items.FindByValue(strCodigoProceso);
                if (olstProceso != null) ddlProceso.SelectedValue = olstProceso.Value;

                txtSuperficie.Text = strM2Superficie;
                txtUsuarios.Text = strUsuarios;
                txtBeneficiarios.Text = strBeneficiarios;

                lblMSGExplo.Text = "Código y Datos adicionales, rescatados con éxito, verifique 'Código Exploratorio' al inicio de la pantalla.";
                return;
            }
            else
            {
                lblMSGExplo.Text = "Debe ingresar codigo BIP.";
            }
        }
        else
        {
            lblMSGExplo.Text = "Debe ingresar codigo BIP.";
        }
    }
    //----------------------------------------------------------------->>
    protected void cmdModuloPatrimonio_Click(object sender, EventArgs e)
    {

        if (Request.Form["txtCodigoExploratorio"].Trim().ToString() == "")
        {
            lblError.Text = "Debe Ingresar Codigo Exploratorio";
            return;
        }

        if (Request.Form["txtCodigoBIP"].Trim().ToString() == "")
        {
            lblError.Text = "Debe Ingresar Codigo Bip";
            return;
        }
                
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Request.Form["txtObjeto"];
        string strCodigoBip = Request.Form["txtCodigoBIP"];
        string strCodigoExploratorio = Request.Form["txtCodigoExploratorio"];

        Response.Redirect("patrimonio/mn_mnt_patrimonio.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }


    protected void cmdMandantes_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_mandantes_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdProgramacionIDEA_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_prog_monto_idea.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdEtapas_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_etapas_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdFinanciamientos_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_multi_financiamientos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }


    protected void cmdConveniosMandantes_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_convenios_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = "0";
        string strCodCon = "";
        string strTipo = "P";

        Response.Redirect("ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);        
    }
    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        string strURLPostGrabar = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] {    "codigo_region",
                                                "codigo_pia"
                                                };

        arrValoresParametros = new string[] {   Request.Form["txtRegion"],
                                                Request.Form["txtPIA"]
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_Elimina_Proyecto", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strBackPage = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos eliminados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strBackPage + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }

    }
    protected void btnProgMonto_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("proyecto/mn_prog_anual_proy_est_idea.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    
}
