///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Pantalla de login de la aplicación web PYC
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Pantalla de login de la aplicación web PYC
///</summary>
///
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class mn_oferta_contrat_contrato : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_propuesta.aspx");
        
        txtMontoOfera.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMontoOfera.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMontoOfera.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMontoOfera.Attributes.Add("onpaste", "javascript:return false;");

        txtPlazo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        string[] arrNombreParametros;
        string[] arrValoresParametros;

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
                    txtCodigoContrato.Text = SQL_Execute.oReader["cod_con"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            /******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_contratistas");

            if (SQL_Execute.numero_error == 0)
            {
                ddlContratista.DataSource = SQL_Execute.oReader;
                //ddlContratista.DataTextField = "n_ctta";//Linea original
                ddlContratista.DataTextField = "rut_nombre";//Linea modificada el 03-04-2014 para mostrar rut , nombre del contratista
                ddlContratista.DataValueField = "rut_ctta";
                ddlContratista.DataBind();
                ddlContratista.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            /******************************************************************************************/

            arrNombreParametros = new string[] { "region", "codigo_da", "sufijo" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetOfertasPropuestaContratista", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdOfertas.DataSource = SQL_Execute.oReader;
                grdOfertas.DataBind();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

        }
    }


    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = Session["ID_Usuario"].ToString();
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

        arrNombreParametros = new string[] { "region",
                                            "codigo_da",
                                            "sufijo",
                                            "rut_ctta",
                                            "descripcion",
                                            "monto",
                                            "plazo" };

        arrValoresParametros = new string[] { strCdigoRegion, 
                                                strCdigoPIA, 
                                                strSufijo, 
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlContratista"],""), 
                                                Request.Form["txtDescOferta"], 
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMontoOfera"]), 
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtPlazo"])
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetOfertasPropuestas", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Guardados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.opener = null;\n");
            HttpContext.Current.Response.Write("window.window.close();\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }

    }

    
    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = Session["ID_Usuario"].ToString();
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

        arrNombreParametros = new string[] { "region", "codigo_da", "sufijo", "rut_ctta" };
        arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strSufijo, Request.Form["ddlContratista"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetOfertasPropuestas_Elimina", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Eliminados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.opener = null;\n");
            HttpContext.Current.Response.Write("window.window.close();\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
    }
    protected void grdOfertas_SelectedIndexChanged(object sender, EventArgs e)
    {   
        ddlContratista.ClearSelection();
        ListItem olstContratista = ddlContratista.Items.FindByValue(grdOfertas.SelectedRow.Cells[1].Text);
        if (olstContratista != null) ddlContratista.SelectedValue = olstContratista.Value;

        txtDescOferta.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdOfertas.SelectedRow.Cells[2].Text);
        txtMontoOfera.Text = Func_Libreria.FUNC_MontoASPv2(grdOfertas.SelectedRow.Cells[3].Text, 0);
        txtPlazo.Text = grdOfertas.SelectedRow.Cells[4].Text;
    }
}
