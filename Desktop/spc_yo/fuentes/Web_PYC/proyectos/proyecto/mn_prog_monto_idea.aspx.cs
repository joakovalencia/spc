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

public partial class proyecto_mn_prog_monto_idea : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();
    private double suma = 0; 

    protected void Page_Load(object sender, EventArgs e)
    {

        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];


        if (!IsPostBack)
        {

            /**********************************************************************/

            ddlagno.Items.Add("2000");
            ddlagno.Items.Add("2001");
            ddlagno.Items.Add("2002");
            ddlagno.Items.Add("2003");
            ddlagno.Items.Add("2004");
            ddlagno.Items.Add("2005");
            ddlagno.Items.Add("2006");
            ddlagno.Items.Add("2007");
            ddlagno.Items.Add("2008");
            ddlagno.Items.Add("2009");
            ddlagno.Items.Add("2010");
            ddlagno.Items.Add("2011");
            ddlagno.Items.Add("2012");
            ddlagno.Items.Add("2013");
            ddlagno.Items.Add("2014");
            ddlagno.Items.Add("2015");
            ddlagno.Items.Add("2016");
            ddlagno.Items.Add("2017");
            ddlagno.Items.Add("2018");
            ddlagno.Items.Add("2019");
            ddlagno.Items.Add("2020");
            ddlagno.Items.Add("2021");
            ddlagno.Items.Add("2022");
            ddlagno.Items.Add("2023");
            ddlagno.Items.Add("2024");
            ddlagno.Items.Add("2025");
            ddlagno.Items.Add("2026");
            ddlagno.Items.Add("2027");
            ddlagno.Items.Add("2028");
            ddlagno.Items.Add("2029");
            ddlagno.Items.Add("2030");
            ddlagno.Items.Add("2031");
            ddlagno.Items.Add("2032");
            ddlagno.Items.Add("2033");
            ddlagno.Items.Add("2034");
            ddlagno.Items.Add("2035");
            ddlagno.Items.Add("2036");
            ddlagno.Items.Add("2037");
            ddlagno.Items.Add("2038");
            ddlagno.Items.Add("2039");
            ddlagno.Items.Add("2040");
            ddlagno.Items.Add("2041");
            ddlagno.Items.Add("2042");
            ddlagno.Items.Add("2043");
            ddlagno.Items.Add("2044");
            ddlagno.Items.Add("2045");
            ddlagno.Items.Add("2046");
            ddlagno.Items.Add("2047");
            ddlagno.Items.Add("2048");
            ddlagno.Items.Add("2049");
            ddlagno.Items.Add("2050");
            ddlagno.Items.Add("2051");
            ddlagno.Items.Add("2052");
            ddlagno.Items.Add("2053");
            ddlagno.Items.Add("2054");
            ddlagno.Items.Add("2055");
            ddlagno.Items.Add("2056");
            ddlagno.Items.Add("2057");
            ddlagno.Items.Add("2058");
            ddlagno.Items.Add("2059");
            ddlagno.Items.Add("2060");
            ddlagno.Items.Add("2061");
            ddlagno.Items.Add("2062");
            ddlagno.Items.Add("2063");
            ddlagno.Items.Add("2064");
            ddlagno.Items.Add("2065");
            ddlagno.Items.Add("2066");
            ddlagno.Items.Add("2067");
            ddlagno.Items.Add("2068");
            ddlagno.Items.Add("2069");
            ddlagno.Items.Add("2070");

            ddlagno.ClearSelection();
            ListItem olstAno = ddlagno.Items.FindByValue(DateTime.Today.ToString("yyyy"));
            if (olstAno != null) ddlagno.SelectedValue = olstAno.Value;


            /**********************************************************************/

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

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };

            //Busca detalle de programación de monto anual 
            SQL_Execute.FUNC_Ejecuta_SP("GetProgramacionMontoIdea", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Mandantes relacionados al proyecto: 0";

            if (SQL_Execute.numero_error == 0)
            {
                grdProgramacionMonto.DataSource = SQL_Execute.oReader;
                grdProgramacionMonto.DataBind();

                lblCantRegistros.Text = "Mandantes relacionados al proyecto: " + grdProgramacionMonto.Rows.Count.ToString();
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
        string strVRegion = Request.Form["txtRegion"];
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

        arrNombreParametros = new string[] { "region", "codigo_da", "agno" ,"monto"};
        arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlagno"], ""),Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMonto"]) };

        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        SQL_Execute.FUNC_Ejecuta_SP("SetGrabaProgramacionMontoIdea", arrNombreParametros, arrValoresParametros);

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
        ddlagno.ClearSelection();
        ListItem olstMandante = ddlagno.Items.FindByValue(grdProgramacionMonto.SelectedRow.Cells[1].Text);
        if (olstMandante != null) ddlagno.SelectedValue = olstMandante.Value;

        txtMonto.Text = Func_Libreria.FUNC_MontoSQLv2(grdProgramacionMonto.SelectedRow.Cells[2].Text);
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
        string strVRegion = Request.Form["txtRegion"];
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

        arrNombreParametros = new string[] { "region", "codigo_da", "agno" };
        arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlagno"], "") };
        
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        SQL_Execute.FUNC_Ejecuta_SP("SetEliminaProgramacionMontoIdea", arrNombreParametros, arrValoresParametros);

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

    protected void grdProgramacionMonto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            suma = suma +  Convert.ToDouble(e.Row.Cells[2].Text);
        }
        else if(e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total: ";
            e.Row.Cells[2].Text = string.Format("{0:#,##0}",suma).ToString();
            
        }
    }
}