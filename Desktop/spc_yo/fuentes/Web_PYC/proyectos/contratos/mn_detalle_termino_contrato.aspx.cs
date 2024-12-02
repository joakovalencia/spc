///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso detalle termino contrato
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

public partial class mn_detalle_termino_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    protected void Page_Load(object sender, EventArgs e)
    {        

        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtAEMonto.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAEMonto.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtAEMonto.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAEMonto.Attributes.Add("onpaste", "javascript:return false;");

        txtAEClasif.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAEClasif.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtAEClasif.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAEClasif.Attributes.Add("onpaste", "javascript:return false;");

        txtRDComRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRDPlazoRecepDef.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtLQNumRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRPNumCertRepMuni.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        //txtAEClasif.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRPPlazo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtLANumDoc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtLAComisionNumRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtAEPlazo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRPComisionNumRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtRDComRes.Text = "0";
        txtRDPlazoRecepDef.Text = "0";
        txtLQNumRes.Text = "0";
        txtRPNumCertRepMuni.Text = "0";
        txtAEClasif.Text = "0";
        txtRPPlazo.Text = "0";
        txtLANumDoc.Text = "0";
        txtLAComisionNumRes.Text = "0";
        txtAEMonto.Text = "0";
        txtAEPlazo.Text = "0";
        txtRPComisionNumRes.Text = "0";

        cmdObtenerDocSSD.Attributes.Add("onClick", "target='_blank';");
        cmdGrabar.Attributes.Add("onClick", "target='_self';");
        cmdSalir.Attributes.Add("onClick", "target='_self';");
        cmdEliminar.Attributes.Add("onClick", "target='_self';");

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
                    HttpContext.Current.Response.Write("alert('Contrato no encontrado.');\n");
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
                    txtCodCon.Text = SQL_Execute.oReader["cod_con"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /**********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis"); //OK

            if (SQL_Execute.numero_error == 0)
            {
                ddlRespTermContrato.DataSource = SQL_Execute.oReader;

                ddlRespTermContrato.DataTextField = "rut_nombre_prof";
                ddlRespTermContrato.DataValueField = "rut";

                ddlRespTermContrato.DataBind();
                ddlRespTermContrato.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /**********************************************************************/

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_termino", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {   

                    txtFechaSolRecepContratista.Text = SQL_Execute.oReader["FECHA_SOLIC_RECEP_CTTA"].ToString();
                    txtFechaTermFisInfITO.Text = SQL_Execute.oReader["FECHA_TERMINO_FISICO_ITO"].ToString();
                    
                    ddlRespTermContrato.ClearSelection();
                    ListItem olstRespTermContrato = ddlRespTermContrato.Items.FindByValue(SQL_Execute.oReader["RESP_TERMINO"].ToString());
                    if (olstRespTermContrato != null) ddlRespTermContrato.SelectedValue = olstRespTermContrato.Value;

                    txtLAComisionNumRes.Text = SQL_Execute.oReader["n_res_liq_anticipada"].ToString();
                    txtLAFechaActaRecep.Text = SQL_Execute.oReader["f_acta_recepcion_unica_liq"].ToString();
                    txtLAFechaLiqAnticip.Text = SQL_Execute.oReader["f_res_liq_anticipada"].ToString();

                    ddlLAAnticipada.ClearSelection();
                    ListItem olstLAAnticipada = ddlLAAnticipada.Items.FindByValue(SQL_Execute.oReader["ANTICIPADA"].ToString());
                    if (olstLAAnticipada != null) ddlLAAnticipada.SelectedValue = olstLAAnticipada.Value;

                    txtLAIntegrantes.Text = SQL_Execute.oReader["integrantes_com_ru"].ToString();
                    txtLAIntegrantes2.Text = SQL_Execute.oReader["integrantes_com_ru2"].ToString();
                    txtLAIntegrantes3.Text = SQL_Execute.oReader["integrantes_com_ru3"].ToString();
                    txtLANumDoc.Text = SQL_Execute.oReader["N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"].ToString();
                    txtLAFechaDoc.Text = SQL_Execute.oReader["F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"].ToString();
                    txtRPComisionNumRes.Text = SQL_Execute.oReader["N_RES_COM_RP"].ToString();
                    txtRPFechaResComp.Text = SQL_Execute.oReader["F_RES_COM_RP"].ToString();
                    txtRPFechaInfObs.Text = SQL_Execute.oReader["f_inf_obs_rp"].ToString();
                    txtRPFechaActa.Text = SQL_Execute.oReader["F_R_P"].ToString();
                    txtRPPlazo.Text = SQL_Execute.oReader["plz_obs_rp"].ToString();
                    txtRPFechaTermReal.Text = SQL_Execute.oReader["f_ter_real_rp"].ToString();
                    txtRPIntegrantes.Text = SQL_Execute.oReader["INTEGRANTES_COM_RP"].ToString();
                    txtRPIntegrantes2.Text = SQL_Execute.oReader["INTEGRANTES_COM_RP2"].ToString();
                    txtRPIntegrantes3.Text = SQL_Execute.oReader["INTEGRANTES_COM_RP3"].ToString();
                    txtRPNumCertRepMuni.Text = SQL_Execute.oReader["N_CERIFICADO_RECEP_MUNICIPAL"].ToString();
                    txtRPFechaRepMuni.Text = SQL_Execute.oReader["F_CERIFICADO_RECEP_MUNICIPAL"].ToString();
                    txtAEClasif.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["CALIFIC"].ToString(),2);
                    txtAEFechaActa.Text = SQL_Execute.oReader["FECHA_ACTA_ENTREGA_EXPLOT"].ToString();
                    txtAEMandatEntreg.Text = SQL_Execute.oReader["MANDATARIO_QUE_ENTREGA"].ToString();
                    txtAEMandatRecib.Text = SQL_Execute.oReader["MANDANTE_QUE_RECIBE"].ToString();

                    ddlAEReservadas.ClearSelection();
                    ListItem olstAEReservadas = ddlAEReservadas.Items.FindByValue(SQL_Execute.oReader["Reservas"].ToString());
                    if (olstAEReservadas != null) ddlAEReservadas.SelectedValue = olstAEReservadas.Value;

                    txtAEPlazo.Text = SQL_Execute.oReader["plz_reservsas"].ToString();
                    txtAEMonto.Text = Func_Libreria.FUNC_MontoASPv2( SQL_Execute.oReader["monto_reservas"].ToString(),0);
                    txtRDComRes.Text = SQL_Execute.oReader["N_RES_COM_RD"].ToString();
                    txtRDFechaInfObs.Text = SQL_Execute.oReader["f_inf_obs_rd"].ToString();
                    txtRDFechaActa.Text = SQL_Execute.oReader["F_R_DEF"].ToString();
                    txtRDFechaRecepDef.Text = SQL_Execute.oReader["F_RES_COM_RD"].ToString();
                    txtRDPlazoRecepDef.Text = SQL_Execute.oReader["plz_obs_rd"].ToString();
                    txtRDIntegrantes.Text = SQL_Execute.oReader["INTEGRANTES_COM_RD"].ToString();
                    txtRDIntegrantes2.Text = SQL_Execute.oReader["INTEGRANTES_COM_RD2"].ToString();
                    txtRDIntegrantes3.Text = SQL_Execute.oReader["INTEGRANTES_COM_RD3"].ToString();
                    txtLQNumRes.Text = SQL_Execute.oReader["N_RES_LIQUIDA"].ToString();
                    txtLQFecha.Text = SQL_Execute.oReader["F_RES_LIQUIDA"].ToString();
                    txtLQAutoridasLiq.Text = SQL_Execute.oReader["AUTORIDAD_LIQUIDA"].ToString();
                    txtLQObs.Text = SQL_Execute.oReader["observacion_termino_contrato"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /**********************************************************************/

        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        
        Response.Redirect("../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "cod_con",        
                                            "FECHA_SOLIC_RECEP_CTTA"	,
                                            "FECHA_TERMINO_FISICO_ITO"	,
                                            "RESP_TERMINO"	,
                                            "n_res_liq_anticipada"	,
                                            "f_acta_recepcion_unica_liq"	,
                                            "f_res_liq_anticipada"	,
                                            "ANTICIPADA"	,
                                            "integrantes_com_ru"	,
                                            "integrantes_com_ru2"	,
                                            "integrantes_com_ru3"	,
                                            "N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"	,
                                            "F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"	,
                                            "N_RES_COM_RP"	,
                                            "F_RES_COM_RP"	,
                                            "f_inf_obs_rp"	,
                                            "F_R_P"	,
                                            "plz_obs_rp"	,
                                            "f_ter_real_rp"	,
                                            "INTEGRANTES_COM_RP"	,
                                            "INTEGRANTES_COM_RP2"	,
                                            "INTEGRANTES_COM_RP3"	,
                                            "N_CERIFICADO_RECEP_MUNICIPAL"	,
                                            "F_CERIFICADO_RECEP_MUNICIPAL"	,
                                            "CALIFIC"	,
                                            "FECHA_ACTA_ENTREGA_EXPLOT"	,
                                            "MANDATARIO_QUE_ENTREGA"	,
                                            "MANDANTE_QUE_RECIBE"	,
                                            "Reservas"	,
                                            "plz_reservsas"	,
                                            "monto_reservas"	,
                                            "N_RES_COM_RD"	,
                                            "f_inf_obs_rd"	,
                                            "F_R_DEF"	,
                                            "F_RES_COM_RD"	,
                                            "plz_obs_rd"	,
                                            "INTEGRANTES_COM_RD"	,
                                            "INTEGRANTES_COM_RD2"	,
                                            "INTEGRANTES_COM_RD3"	,
                                            "N_RES_LIQUIDA"	,
                                            "F_RES_LIQUIDA"	,
                                            "AUTORIDAD_LIQUIDA"	,
                                            "observacion_termino_contrato"	,
                                            "sufijo" ,
                                            "region" ,
                                            "codigo_da"
                                        };        
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaSolRecepContratista"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaTermFisInfITO"]), 
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlRespTermContrato"],""), 
                                                Request.Form["txtLAComisionNumRes"], 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtLAFechaActaRecep"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtLAFechaLiqAnticip"]), 
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlLAAnticipada"],""),
                                                Request.Form["txtLAIntegrantes"], 
                                                Request.Form["txtLAIntegrantes2"], 
                                                Request.Form["txtLAIntegrantes3"], 
                                                Request.Form["txtLANumDoc"], 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtLAFechaDoc"]), 
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtRPComisionNumRes"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRPFechaResComp"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRPFechaInfObs"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRPFechaActa"]), 
                                                Request.Form["txtRPPlazo"], 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRPFechaTermReal"]), 
                                                Request.Form["txtRPIntegrantes"], 
                                                Request.Form["txtRPIntegrantes2"], 
                                                Request.Form["txtRPIntegrantes3"], 
                                                Request.Form["txtRPNumCertRepMuni"], 
                                                Request.Form["txtRPFechaRepMuni"],  //no es datetime
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtAEClasif"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtAEFechaActa"]), 
                                                Request.Form["txtAEMandatEntreg"], 
                                                Request.Form["txtAEMandatRecib"], 
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlAEReservadas"],""), 
                                                Request.Form["txtAEPlazo"], 
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtAEMonto"]), 
                                                Request.Form["txtRDComRes"], 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRDFechaInfObs"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRDFechaActa"]), 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRDFechaRecepDef"]), 
                                                Request.Form["txtRDPlazoRecepDef"], 
                                                Request.Form["txtRDIntegrantes"], 
                                                Request.Form["txtRDIntegrantes2"], 
                                                Request.Form["txtRDIntegrantes3"], 
                                                Request.Form["txtLQNumRes"], 
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtLQFecha"]), 
                                                Request.Form["txtLQAutoridasLiq"], 
                                                Request.Form["txtLQObs"],
                                                Request.Form["txtSufijo"],
                                                Request.Form["txtRegion"],
                                                Request.Form["txtPIA"]
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_termino", arrNombreParametros, arrValoresParametros);
        
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

        
    }
   
    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "cod_con"};
        arrValoresParametros = new string[] { Request.Form["txtCodCon"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetCancela_contratos_detalle_termino", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos eliminados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }

    }
    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        string strCodCon = Request.Form["txtCodCon"];
        string strTipo = "C";

        if (Request.Form["txtCodCon"] == "")
        {
            lblError.Text = "Para conexión con SSD, debe ingresar un codigo de contrato.";
            return;
        }

        Response.Redirect("../ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }
}
