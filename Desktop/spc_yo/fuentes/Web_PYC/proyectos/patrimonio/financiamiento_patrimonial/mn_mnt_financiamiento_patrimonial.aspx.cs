///<summary>
///Creado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Alertas
//-----------------------
///Modificado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Alertas
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

///<summary>
///Menu de mantenedor de Alertas del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Alertas del sistema PYC
///</remarks>
///

public partial class mn_mnt_financiamiento_patrimonial : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    ///<summary>
    ///Metodo de carga pagina mantenedor de Alertas PYC
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del page load
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del page load
    ///</param>

    protected void Page_Load(object sender, EventArgs e)
    {  

        Func_Libreria.FUNC_Valida_Sesion("///mn_ing_proyectos.aspx");

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        /**********************************************************************/
        string[] arrNombreParametros;
        string[] arrValoresParametros;

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

        if (!IsPostBack)
        {

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_financiamiento");

            if (SQL_Execute.numero_error == 0)
            {
                ddDescripcion.DataSource = SQL_Execute.oReader;
                ddDescripcion.DataTextField = "DESCRIPCION";
                ddDescripcion.DataValueField = "CODIGO";
                ddDescripcion.DataBind();

                ddDescripcion.Items.Insert(0, "(SELECCIONAR)");
            }

            /**********************************************************************/

            arrNombreParametros = new string[] { "accion"
                                            , "CODIGO_PROYECTO"
                                            , "DESCRIPCION" };
            arrValoresParametros = new string[] { "B"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddDescripcion"],"")
                                            };
            //test
            SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Financiamiento", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdProcesoPatrimonial.DataSource = SQL_Execute.oReader;
                grdProcesoPatrimonial.DataBind();
            }
        }
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Page.Request.QueryString["codigo_region"];
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "accion"
                                            , "CODIGO_PROYECTO"
                                            , "DESCRIPCION" };
        arrValoresParametros = new string[] { "G"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddDescripcion"],"")
                                            };
        //test
        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Financiamiento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_financiamiento_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Financiamiento creado o modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLBack + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End(); 
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }
      
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("mn_mnt_financiamiento_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Page.Request.QueryString["codigo_region"];
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        string[] arrNombreParametros;
        string[] arrValoresParametros;
        
        arrNombreParametros = new string[] { "accion"
                                            , "CODIGO_PROYECTO"
                                            , "DESCRIPCION" };
        arrValoresParametros = new string[] { "E"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddDescripcion"],"0")
                                            };
        //test
        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Financiamiento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_financiamiento_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Financiamiento eliminado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLBack + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        

    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("../mn_mnt_patrimonio.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }   
    
    protected void grdProcesoPatrimonial_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddDescripcion.ClearSelection();
        ListItem olstDescripcion = ddDescripcion.Items.FindByValue(grdProcesoPatrimonial.SelectedRow.Cells[1].Text.Trim());
        if (olstDescripcion != null) ddDescripcion.SelectedValue = olstDescripcion.Value;                
    }
}
