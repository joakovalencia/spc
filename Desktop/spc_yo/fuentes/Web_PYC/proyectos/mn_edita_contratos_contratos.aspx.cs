///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla edicion contrato
///</summary>
///
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
//using ConsumirSSD.wscorporativo;
using wsssd;

public partial class mn_edita_contratos_contratos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {

        string strValido = "0";

        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_contratos.aspx");

        lblError.Text = "";               

        txtM2.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtM2.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtM2.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtM2.Attributes.Add("onpaste", "javascript:return false;");           

        txtPlazoNoComputable.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        
        cmdGrabar.Attributes.Add("onClick", "target='_self';");
        cmdSalir.Attributes.Add("onClick", "target='_self';");
        cmdInspectorFiscal.Attributes.Add("onClick", "target='_self';");
        cmdImputaPresup.Attributes.Add("onClick", "target='_self';");
        cmdProgramacion.Attributes.Add("onClick", "target='_self';");
        cmdGarantias.Attributes.Add("onClick", "target='_self';");
        cmdDetalleTerminoContrato.Attributes.Add("onClick", "target='_self';");
        cmdAvancesFisicos.Attributes.Add("onClick", "target='_self';");
        cmdEstadoPagos.Attributes.Add("onClick", "target='_self';");
        cmdModificaciones.Attributes.Add("onClick", "target='_self';");

        string[] arrNombreParametros;
        string[] arrValoresParametros;

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
                //lblMensajes.Text = "Tiene " + SQL_Execute.oReader["cant_mensajes"].ToString() + " mensaje(s)";
            }
        }
        
        /**********************************************************************/

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        if (!IsPostBack)
        {
            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros, arrValoresParametros);

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
                    txtSufijo.Text = SQL_Execute.oReader["sufijo"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["TIPO_PROCESO"].ToString();
                    txtEtapa.Text = SQL_Execute.oReader["etapa"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /**********************************************************************/

            string strFechaTramite = "";

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_edita_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlLod.Items.Insert(0, "(SELECCIONAR)");
                ddlLod.Items.Add("LOD LTEC");
                ddlLod.Items.Add("LOD SGO");
                ddlLod.Items.Add("LOD DUOMO");
    
                while (SQL_Execute.oReader.Read())
                {
                    txtCodigoContrato.Text = SQL_Execute.oReader["COD_CON"].ToString();
                    txtFechaIngreso.Text = SQL_Execute.oReader["FECHA_INGRESO"].ToString();
                    txtDigitador.Text = SQL_Execute.oReader["Usuario"].ToString().Trim();
                    txtFechaActualizacion.Text = SQL_Execute.oReader["FECHA_ACTUALIZ"].ToString();
                    txtRegion.Text = SQL_Execute.oReader["REGION"].ToString().Trim();
                    txtProvincia.Text = SQL_Execute.oReader["N_PROVI"].ToString();// N_PROVI -> tabla provincia
                    txtComuna.Text = SQL_Execute.oReader["N_COMU"].ToString();// N_COMU
                    txtFondo.Text = SQL_Execute.oReader["T_F1"].ToString();// T_F1
                    txtM2.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["CANTIDAD_OBRA"].ToString(),2 );// MTO_OR
                    txtLocalizacion.Text = SQL_Execute.oReader["LOCALIZACION"].ToString();// LOCALIZACION
                    txtDescContrato.Text = SQL_Execute.oReader["DESCRIPCIÓN"].ToString();// DESCRIPCIÓN
                    txtContratista.Text = SQL_Execute.oReader["N_CTTA"].ToString();// N_CTTA
                    txtResAdjuOrig.Text = SQL_Execute.oReader["OR_RES"].ToString();// OR_RES
                    txtNumeroRes.Text = SQL_Execute.oReader["N_RES"].ToString();// N_RES
                    txtFechaRes.Text = SQL_Execute.oReader["F_RES"].ToString();// F_RES
                    txtFechaTramite.Text = SQL_Execute.oReader["F_TRAMI"].ToString();// F_TRAMI
                    txtMontoAdjudicado.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MTO_OR"].ToString(),0);// MTO_OR
                    txtPlazoDias.Text = SQL_Execute.oReader["PLAZO_OR"].ToString();// PLAZO_OR
                    txtFechaInicioLegal.Text = SQL_Execute.oReader["F_INL"].ToString();// F_INL
                    txtFechaEntregaTerreno.Text = SQL_Execute.oReader["FECHA_TERRENO"].ToString();// CONTRATO.FECHA_TERRENO

                    txtFechaTerminoLegalInicial.Text = SQL_Execute.oReader["FechaTerminoLegalInicial"].ToString();//([F_INL]+[PLAZO_OR])-1
                    txtPlazoNoComputable.Text = SQL_Execute.oReader["plazo_no_computable"].ToString();// plazo no computable

                    txtObsRelContrato.Text = SQL_Execute.oReader["observaciones_contrato"].ToString();// observaciones contrato

                    strFechaTramite = SQL_Execute.oReader["F_TRAMI"].ToString();
                    strValido = SQL_Execute.oReader["VALIDO"].ToString();

                    ListItem olstLod = ddlLod.Items.FindByValue(SQL_Execute.oReader["EMPRESA_LOD"].ToString());
                    if (olstLod != null) ddlLod.SelectedValue = olstLod.Value;
    
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
                        
            if (strFechaTramite.Trim() == "")
            {
                string strURLBACK = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('El contrato no se encuentra adjudicado.');\n");
                HttpContext.Current.Response.Write("window.location.href='" + strURLBACK + "'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                HttpContext.Current.Response.End();
            }

            /**********************************************************************/

            arrNombreParametros = new string[] { "cod_con" };
            arrValoresParametros = new string[] { txtCodigoContrato.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_resumen_edita_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtVariacionMonto.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["VAR_MTO"].ToString(),0);                                    // VAR_MTO
                    txtMontoVigente.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MTO_VIG"].ToString(), 0);                                     // MTO_VIG
                    txtInversionAcumulada.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["INV_ACUM"].ToString(),0);                               // INV_ACUM
                    txtSaldoPorInvertir.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["saldo_por_invertir"].ToString(),0);                       // saldo_por_invertir
                    txtVariacionesPlazo.Text = SQL_Execute.oReader["VAR_PZO"].ToString();                                                                   // VAR_PZO
                    txtPlazoVigenteDias.Text = SQL_Execute.oReader["PLAZO_VIG"].ToString();                                                                 // PLAZO_VIG
                    txtFechaTerminoLegal.Text = SQL_Execute.oReader["F_TL"].ToString();                                                                     // F_TL
                    txtPorcAvanceFinanc.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["AV_FIN"].ToString(),2);                                   // AV_FIN
                    txtPorAvanceFisico.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["AVANCE_FISICO_ACUM"].ToString(), 2);                       // =SiInm([MTO_VIG]>0,[T_PAG_CTTO]/[MTO_VIG],Nulo)                    
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            if (strValido == "2")
            {             
                cmdGarantias.Enabled = true ;
                cmdImputaPresup.Enabled = true ;
                cmdProgramacion.Enabled = true ;
                cmdEstadoPagos.Enabled = true ;
                cmdAvancesFisicos.Enabled = true ;
                cmdModificaciones.Enabled = true;            
            }


            
        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdDetalleProyecto_Click(object sender, ImageClickEventArgs e)
    {

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

        /***********************************************************************************************/
        /*
        arrNombreParametros = new string[] { "cod_con"
                                            , "numero_proceso1"
                                            , "numero_proceso2"
                                            };
        arrValoresParametros = new string[] { Request.Form["txtCodigoContrato"]
                                            , Request.Form["txtNmeroProceso1"]
                                            , Request.Form["txtNmeroProceso2"]
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGrabaProceso_ssd", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {

        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }*/
        
        /***********************************************************************************************/

        arrNombreParametros = new string[] { "codigo_pia"
                                            , "codigo_region"
                                            , "sufijo"
                                            , "m2"
                                            , "desc_contrato"
                                            , "fechainiciolegal"
                                            , "fechaentregaterreno"
                                            , "plazonocomputable"
                                            , "obsrelcontrato"
                                            , "usuario" 
                                            , "libro" 
                                            };
        arrValoresParametros = new string[] { Request.Form["txtPIA"]
                                            , Request.Form["txtRegion"]
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtSufijo"])
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtM2"].ToString())
                                            , Request.Form["txtDescContrato"]
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaInicioLegal"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEntregaTerreno"])
                                            , Request.Form["txtPlazoNoComputable"]
                                            , Request.Form["txtObsRelContrato"]
                                            , lblUsuario.Text 
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlLod"], "")
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_contratos", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();            
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }
        

        /***********************************************************************************************/
        
    }


    protected void cmdInspectorFiscal_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_inspector_fiscal_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }
    protected void cmdImputaPresup_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_imp_presup_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

    }
    protected void cmdProgramacion_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_program_financ_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

    }
    protected void cmdGarantias_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_garantias_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

    }
    protected void cmdDetalleTerminoContrato_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        if (Request.Form["txtEtapa"] == "DISE")
            Response.Redirect("contratos/mn_detalle_termino_consultoria.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
        else
            Response.Redirect("contratos/mn_detalle_termino_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }
    protected void cmdAvancesFisicos_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_avances_fisicos_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
        
    }
    protected void cmdEstadoPagos_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_estado_pago_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
        
    }
    protected void cmdModificaciones_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("contratos/mn_ing_modificaciones_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

    }
    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        string strCodCon = Request.Form["txtCodigoContrato"];
        string strTipo = "C";

        if (Request.Form["txtCodigoContrato"] == "")
        {
            lblError.Text = "Para conexión con SSD, debe ingresar un codigo de contrato.";
            return;
        }

        Response.Redirect("ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);        
    }
}


/*
eidion contratos - contratos

txtCodigoContrato - COD_CON
txtFechaIngreso - FECHA_INGRESO
txtDigitador - Usuario
txtFechaActualizacion - FECHA_ACTUALIZ
txtRegion - REGION
txtProvincia - N_PROVI -> tabla provincia
txtComuna - N_COMU
txtFondo - T_F1
txtM2 - CANTIDAD_OBRA
txtLocalizacion - LOCALIZACION
txtDescContrato - DESCRIPCIÓN
txtContratista - N_CTTA
txtResAdjuOrig - OR_RES
txtNumeroRes - N_RES
txtFechaRes - F_RES
txtFechaTramite - F_TRAMI
txtMontoAdjudicado - MTO_OR
txtPlazoDias - PLAZO_OR
txtFechaInicioLegal - F_INL
txtFechaEntregaTerreno - CONTRATO.FECHA_TERRENO
txtFechaTerminoLegalInicial - =([F_INL]+[PLAZO_OR])-1
txtPlazoNoComputable - plazo no computable
txtVariacionMonto - VAR_MTO
txtMontoVigente - =[MTO_OR]+[VAR_MTO]
txtInversionAcumulada - INV_ACUM
txtSaldoPorInvertir - =[MTO_VIG]-[T_PAG_CTTO]
txtVariacionesPlazo - VAR_PZO
txtPlazoVigenteDias - =[PLAZO_OR]+[VAR_PZO]
txtFechaTerminoLegal - =([F_INL]+[PLAZO_VIG])-1
txtPorcAvanceFinanc - =SiInm([MTO_VIG]>0,[T_PAG_CTTO]/[MTO_VIG],Nulo)
txtPorAvanceFisico - =SiInm([MTO_VIG]>0,[T_PAG_CTTO]/[MTO_VIG],Nulo)
txtObsRelContrato - observaciones contrato

c_contrato_datos_vigentes
SELECT DISTINCTROW Consulta_Contrato_Navegar.COD_CON, Consulta_Contrato_Navegar.MTO_OR, Consulta_Contrato_Navegar.PLAZO_OR, Consulta_Contrato_Navegar.F_INL, IIf([SumaDeVAR_MTO] Is Null,0,[SumaDeVAR_MTO]) AS VAR_MTO, IIf([SumaDeVAR_PZO] Is Null,0,[SumaDeVAR_PZO]) AS VAR_PZO, IIf([SumaDeVAR_TAMAGNO] Is Null,0,[SumaDeVAR_TAMAGNO]) AS VAR_TAMAGNO, 0+NZ([AV_FIS_ACUM]) AS AVANCE_FISICO_ACUM, 0+nz(([ACUM]+[DEVOL_ANTICIPO_ACUM])-([PAG_ANTICIPO_ACUM])) AS INV_ACUM
FROM (((Consulta_Contrato_Navegar LEFT JOIN c_suma_avance_fisico ON Consulta_Contrato_Navegar.COD_CON = c_suma_avance_fisico.COD_CON) LEFT JOIN modicontratos2suma_cto ON Consulta_Contrato_Navegar.COD_CON = modicontratos2suma_cto.COD_CON) LEFT JOIN c_cargo_presup_inv_acum_cto ON Consulta_Contrato_Navegar.COD_CON = c_cargo_presup_inv_acum_cto.COD_CON) LEFT JOIN ESTADO_PAGO_SUMA_CTO ON Consulta_Contrato_Navegar.COD_CON = ESTADO_PAGO_SUMA_CTO.COD_CON;


Desarrollo
-	3082625
-	3082675
QA
-	3082625
-	3082675

 
*/