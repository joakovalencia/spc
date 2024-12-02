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

//MANDANTES_ORIGINALES

public partial class mn_multi_financiamientos : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        if (!IsPostBack)
        {
            /******************************************************************************************/
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
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            /******************************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_tipo_fondos");

            if (SQL_Execute.numero_error == 0)
            {
                ddlFinanciamiento.DataSource = SQL_Execute.oReader;
                ddlFinanciamiento.DataTextField = "descripcion";
                ddlFinanciamiento.DataValueField = "codigo";
                ddlFinanciamiento.DataBind();
                ddlFinanciamiento.Items.Insert(0, "(SELECCIONAR)");
            }

            /******************************************************************************************/

            arrNombreParametros = new string[] { "accion", "region", "codigo_da", "codigo" };
            arrValoresParametros = new string[] { "B", strCdigoRegion, strCdigoPIA , ""};

            //sp_busca_dom_mandante2
            SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Multi_Financiamiento", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Financiamientos relacionados al proyecto: 0";

            if (SQL_Execute.numero_error == 0)
            {
                grdFinanciamiento.DataSource = SQL_Execute.oReader;
                grdFinanciamiento.DataBind();

                lblCantRegistros.Text = "Financiamientos relacionados al proyecto: " + grdFinanciamiento.Rows.Count.ToString();
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

        arrNombreParametros = new string[] { "accion", "region", "codigo_da", "codigo" };
        arrValoresParametros = new string[] { "G", strCdigoRegion, strCdigoPIA, Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFinanciamiento"], "") };

        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Multi_Financiamiento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Grabados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
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
        ddlFinanciamiento.ClearSelection();
        ListItem olstMandante = ddlFinanciamiento.Items.FindByValue(grdFinanciamiento.SelectedRow.Cells[1].Text);
        if (olstMandante != null) ddlFinanciamiento.SelectedValue = olstMandante.Value;
    }

    protected void cmdCerrar_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
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

        arrNombreParametros = new string[] { "accion", "region", "codigo_da", "codigo" };
        arrValoresParametros = new string[] { "E", strCdigoRegion, strCdigoPIA, Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFinanciamiento"], "") };
        
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;
        
        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Multi_Financiamiento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Eliminados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
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
