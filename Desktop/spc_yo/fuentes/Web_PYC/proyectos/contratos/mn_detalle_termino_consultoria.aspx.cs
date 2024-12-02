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

public partial class mn_detalle_termino_consultoria : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtNumResLiqAntCon.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumDocApruebaLiqAnti.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumResLiqCon.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtClasifCon.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtClasifCon.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtClasifCon.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtClasifCon.Attributes.Add("onpaste", "javascript:return false;");
        
        txtNumeroEtapa.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtDiasLegales.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtDiasRevision.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtDiasTotales.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

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
            txtNumResLiqAntCon.Text = "0";
            txtNumDocApruebaLiqAnti.Text = "0";
            txtNumResLiqCon.Text = "0";
            txtClasifCon.Text = "0";
            txtNumeroEtapa.Text = "0";
            txtDiasLegales.Text = "0";
            txtDiasRevision.Text = "0";
            txtDiasTotales.Text = "0";

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
                    txtEtapa.Text = SQL_Execute.oReader["etapa"].ToString();
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

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_consultoria_detalle_termino", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtFechaTermFisInfITO.Text = SQL_Execute.oReader["FECHA_TERMINO_FISICO_ITO"].ToString();
                    txtFechaEntregaDefCon.Text = SQL_Execute.oReader["f_ent_def_con"].ToString();

                    ddlRespTermContrato.ClearSelection();
                    ListItem olstRespTermContrato = ddlRespTermContrato.Items.FindByValue(SQL_Execute.oReader["RESP_TERMINO"].ToString());
                    if (olstRespTermContrato != null) ddlRespTermContrato.SelectedValue = olstRespTermContrato.Value;

                    txtNumResLiqAntCon.Text = SQL_Execute.oReader["n_res_liquida_anti_con"].ToString();
                    txtFechaResLiqAntCon.Text = SQL_Execute.oReader["f_res_liquida_anti_con"].ToString();

                    txtNumDocApruebaLiqAnti.Text = SQL_Execute.oReader["N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"].ToString();
                    txtFechaDocApruebaLiqAnti.Text = SQL_Execute.oReader["F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"].ToString();

                    txtNumResLiqCon.Text = SQL_Execute.oReader["n_res_liquida_con"].ToString();
                    txtFechaResLiqCon.Text = SQL_Execute.oReader["f_res_liquida_con"].ToString();

                    txtAutoridadLiqCon.Text = SQL_Execute.oReader["autoridad_liquida_con"].ToString();
                    txtClasifCon.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["calificacion_con"].ToString(),2);

                    txtObsTerminoContrato.Text = SQL_Execute.oReader["observacion_termino_contrato"].ToString();

                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /**********************************************************************/
            
            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_consultoria_detalle_termino_grilla", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Registro de etapas relacionadas al contrato: 0";

            if (SQL_Execute.numero_error == 0)
            {
                grdEtapas.DataSource = SQL_Execute.oReader;
                grdEtapas.DataBind();

                lblCantRegistros.Text = "Registro de etapas relacionadas al contrato: " + grdEtapas.Rows.Count.ToString();

            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

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

        arrNombreParametros = new string[] {    "cod_con"
                                           ,    "FECHA_TERMINO_FISICO_ITO"
                                           ,    "RESP_TERMINO"
                                           ,    "f_ent_def_con"
                                           ,    "n_res_liquida_anti_con"
                                           ,    "f_res_liquida_anti_con"
                                           ,    "N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"
                                           ,    "F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA"
                                           ,    "n_res_liquida_con"
                                           ,    "f_res_liquida_con"
                                           ,    "autoridad_liquida_con"
                                           ,    "calificacion_con"
                                           ,    "observacion_termino_contrato"
                                        };        
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaTermFisInfITO"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlRespTermContrato"],""),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEntregaDefCon"]),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumResLiqAntCon"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaResLiqAntCon"]),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumDocApruebaLiqAnti"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaDocApruebaLiqAnti"]),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumResLiqCon"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaResLiqCon"]),
                                                Request.Form["txtAutoridadLiqCon"],
                                                Func_Libreria.FUNC_MontoSQL( Request.Form["txtClasifCon"].ToString()),
                                                Request.Form["txtObsTerminoContrato"]
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_consultoria_detalle_termino", arrNombreParametros, arrValoresParametros);

        
        if (SQL_Execute.numero_error != 0)
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }

        /*******************************************************************************************************/

        if (Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumeroEtapa"]) != "0")
        {
            arrNombreParametros = new string[] {    "COD_CON_C"
                                               ,    "ETAPA_C"
                                               ,    "DIAS_LEGALES"
                                               ,    "F_ENTREGA_REVISION_ETAPA"
                                               ,    "DIAS_REVISION"
                                               ,    "PLAZO_TOTAL"
                                               ,    "OBSERVACION_C"
                                                };

            arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                    Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumeroEtapa"]),
                                                    Func_Libreria.FUNC_EnteroSQL(Request.Form["txtDiasLegales"]),
                                                    Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEntRevEta"]),
                                                    Func_Libreria.FUNC_EnteroSQL(Request.Form["txtDiasRevision"]),
                                                    Func_Libreria.FUNC_EnteroSQL(Request.Form["txtDiasTotales"]),
                                                    Request.Form["txtObs"]
                                                };

            SQL_Execute.FUNC_Ejecuta_SP("SetGraba_consultoria_detalle_termino_grilla", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error != 0)
            {
                lblError.Text = SQL_Execute.desc_error;
                return;
            }
        }

        HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
        HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n");
        HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
        HttpContext.Current.Response.Write("</SCRIPT>");
        HttpContext.Current.Response.End();
        
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

        SQL_Execute.FUNC_Ejecuta_SP("SetCancela_consultoria_detalle_termino", arrNombreParametros, arrValoresParametros);

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
    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNumeroEtapa.Text = grdEtapas.SelectedRow.Cells[1].Text;
        txtDiasLegales.Text = grdEtapas.SelectedRow.Cells[2].Text;
        txtFechaEntRevEta.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEtapas.SelectedRow.Cells[3].Text);
        txtDiasRevision.Text = grdEtapas.SelectedRow.Cells[4].Text;
        txtDiasTotales.Text = grdEtapas.SelectedRow.Cells[5].Text;
        txtObs.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEtapas.SelectedRow.Cells[6].Text);
    }
}
