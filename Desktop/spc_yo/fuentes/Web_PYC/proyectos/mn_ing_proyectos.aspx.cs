///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso proyecto
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

public partial class mn_ing_proyectos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("/mn_ing_proyectos.aspx");

        lblError.Text = "";
       
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

        if (!IsPostBack)
        {            
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_regiones"); //OK

            if (SQL_Execute.numero_error == 0)
            {
                
                ddlRegion.DataSource = SQL_Execute.oReader;
                ddlRegion.DataTextField = "CODIGO_NOMBRE";
                ddlRegion.DataValueField = "reg";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error.ToString();
            }
  

            /********************************************************************/

            _loadddlTipologia();

            _loadddlProceso();

            _loadddlPlanes();

            _loadddlProdEstrategico();

            _loadddlTipoFondos();

            _loadddlSectorDestino();

            /********************************************************************/
                        
        }

        
    }

    private void _loadddlProceso()
    {
        
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strTipologia = "EB";

        if (Request.Form["ddlTipologia"] != null) strTipologia = Request.Form["ddlTipologia"];

        arrNombreParametros = new string[] { "tipologia" };
        arrValoresParametros = new string[] { strTipologia };
                
        SQL_Execute.FUNC_Ejecuta_SP("GetPry_procesos_list", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlProceso.DataSource = SQL_Execute.oReader;
            ddlProceso.DataTextField = "codigo_nombre";
            ddlProceso.DataValueField = "proceso";
            ddlProceso.DataBind();
            //ddlProceso.SelectedIndex = 0;
            ddlProceso.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

        
    }

    private void _loadddlSectorDestino()
    {
                     
        SQL_Execute.FUNC_Ejecuta_SP("sp_llena_sector_destino"); //OK

        if (SQL_Execute.numero_error == 0)
        {            
            ddlSectorDestino.DataSource = SQL_Execute.oReader;
            ddlSectorDestino.DataTextField = "codigo_nombre";
            ddlSectorDestino.DataValueField = "SECTOR_DESTINO";
            ddlSectorDestino.DataBind();
            //ddlSectorDestino.SelectedIndex = 0;
            ddlSectorDestino.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

        
    }

    private void _loadddlPlanes()
    {
                        
        SQL_Execute.FUNC_Ejecuta_SP("sp_llena_planes"); //OK

        if (SQL_Execute.numero_error == 0)
        {            
            ddlPlanAsociado.DataSource = SQL_Execute.oReader;
            ddlPlanAsociado.DataTextField = "codigo_nombre";
            ddlPlanAsociado.DataValueField = "Codigo_plan";
            ddlPlanAsociado.DataBind();
            //ddlPlanAsociado.SelectedIndex = 0;
            ddlPlanAsociado.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

        
    }

    private void _loadddlTipoFondos()
    {
                        
        SQL_Execute.FUNC_Ejecuta_SP("sp_llena_tipo_fondos"); //OK

        if (SQL_Execute.numero_error == 0)
        {            
            ddlFinanciamiento.DataSource = SQL_Execute.oReader;
            ddlFinanciamiento.DataTextField = "codigo_nombre";
            ddlFinanciamiento.DataValueField = "CODIGO";
            ddlFinanciamiento.DataBind();
            //ddlFinanciamiento.SelectedIndex = 0;
            ddlFinanciamiento.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

        
    }

    private void _loadddlProdEstrategico()
    {
                        
        SQL_Execute.FUNC_Ejecuta_SP("sp_llena_prod_estrategico"); //OK

        if (SQL_Execute.numero_error == 0)
        {            
            ddlProductoEstrategico.DataSource = SQL_Execute.oReader;
            ddlProductoEstrategico.DataTextField = "CODIGO_NOMBRE";
            ddlProductoEstrategico.DataValueField = "PRODUCTO";
            ddlProductoEstrategico.DataBind();
            //ddlProductoEstrategico.SelectedIndex = 0;
            ddlProductoEstrategico.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

        
    }

    private void _loadddlTipologia()
    {
                        
        SQL_Execute.FUNC_Ejecuta_SP("sp_llena_tipologias"); //OK

        if (SQL_Execute.numero_error == 0)
        {            
            ddlTipologia.DataSource = SQL_Execute.oReader;
            ddlTipologia.DataTextField = "codigo_nombre";
            ddlTipologia.DataValueField = "codigo";
            ddlTipologia.DataBind();
            //ddlTipologia.SelectedIndex = 0;
            ddlTipologia.Items.Insert(0, "(SELECCIONAR)");
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error.ToString();
        }

    }

    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("mn_ing_proyectos.aspx");

    }
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mn_busqueda_proyectos.aspx");
    }
    
    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["ddlRegion"]; //strCdigoRegion
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

        arrNombreParametros = new string[] { "region", "tipo_proy", "plan", "producto", "proceso", "objeto", "fondo", "sector_destino" };
        arrValoresParametros = new string[] { Request.Form["ddlRegion"], Request.Form["ddlTipologia"], Request.Form["ddlPlanAsociado"], Request.Form["ddlProductoEstrategico"], Request.Form["ddlProceso"], Request.Form["txtObjeto"], Request.Form["ddlFinanciamiento"], Request.Form["ddlSectorDestino"] };
                
        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Ing_Proyectos", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                if (SQL_Execute.oReader["resp"].ToString().ToUpper() == "SI")
                {
                    string str_resp = SQL_Execute.oReader["descr"].ToString();

                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('" +  str_resp  + "');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_ing_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    lblError.Text = SQL_Execute.oReader["descr"].ToString();
                }                
            }

        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }


    }

    protected void ddlTipologia_SelectedIndexChanged(object sender, EventArgs e)
    {
        _loadddlProceso();
    }
}
