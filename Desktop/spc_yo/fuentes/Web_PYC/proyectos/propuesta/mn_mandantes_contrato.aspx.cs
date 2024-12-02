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

public partial class mn_mandantes_contrato : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_propuesta.aspx");

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

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_mandante_convenios", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlMandante.DataSource = SQL_Execute.oReader;
                ddlMandante.DataTextField = "descripcion";
                ddlMandante.DataValueField = "sigla";
                ddlMandante.DataBind();
                ddlMandante.Items.Insert(0, "(SELECCIONAR)");
            }

            /******************************************************************************************/

            arrNombreParametros = new string[] { "region", "codigo_da", "sufijo" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strSufijo };
//sp_buscar_mandantes_del_contrato
            SQL_Execute.FUNC_Ejecuta_SP("Get_buscar_mandantes_del_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdMandantes.DataSource = SQL_Execute.oReader;
                grdMandantes.DataBind();
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
        
        arrNombreParametros = new string[] { "region", "codigo_da", "sufijo", "mandante", "cod_con" };
        arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strSufijo, Request.Form["ddlMandante"], Request.Form["txtCodigoContrato"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetMandantesContrato", arrNombreParametros, arrValoresParametros);

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

    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMandante.ClearSelection();
        ListItem olstMandante = ddlMandante.Items.FindByValue(grdMandantes.SelectedRow.Cells[1].Text);
        if (olstMandante != null) ddlMandante.SelectedValue = olstMandante.Value;
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

        arrNombreParametros = new string[] { "region", "codigo_da", "sufijo", "mandante", "cod_con" };
        arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strSufijo, Request.Form["ddlMandante"], Request.Form["txtCodigoContrato"] };

        SQL_Execute.FUNC_Ejecuta_SP("Set_eliminar_mandantes_del_contrato", arrNombreParametros, arrValoresParametros);

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
}
