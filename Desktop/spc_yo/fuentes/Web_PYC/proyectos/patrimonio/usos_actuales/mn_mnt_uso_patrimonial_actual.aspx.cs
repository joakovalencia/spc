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
using System.Data.SqlClient;

///<summary>
///Menu de mantenedor de Alertas del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Alertas del sistema PYC
///</remarks>
///

public partial class mn_mnt_uso_patrimonial_actual : System.Web.UI.Page 
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
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_CATEGORIA_USO");

            if (SQL_Execute.numero_error == 0)
            {                
                ddlCategoria_Uso.DataSource = SQL_Execute.oReader;
                ddlCategoria_Uso.DataTextField = "CATEGORIA_USO";
                ddlCategoria_Uso.DataValueField = "CODIGO";
                ddlCategoria_Uso.DataBind();
                ddlCategoria_Uso.Items.Insert(0, "(SELECCIONAR)");

                ddlCodigo_uso_patrimonial.Items.Insert(0, "(SELECCIONAR)");
            }

            /**********************************************************************/

            arrNombreParametros = new string[] {"CODIGO_PROYECTO"};
            arrValoresParametros = new string[] { strCodigoExploratorio };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_uso_actual", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdUsoActual.DataSource = SQL_Execute.oReader;
                grdUsoActual.DataBind();
            }

            /**********************************************************************/
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

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];
        
        arrNombreParametros = new string[] { "accion"
                                        , "CODIGO_PROYECTO"
                                        , "CATEGORIA_USO"
                                        , "TIPOLOGIA_DE_USO" };
        arrValoresParametros = new string[] { "G"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCategoria_Uso"],"0")
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCodigo_uso_patrimonial"],"0")
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_mnt_uso_actual", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_uso_patrimonial_actual.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Uso creado o modificado correctamente.');\n");
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

        Response.Redirect("mn_mnt_uso_patrimonial_actual.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
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

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        arrNombreParametros = new string[] { "accion"
                                        , "CODIGO_PROYECTO"
                                        , "CATEGORIA_USO"
                                        , "TIPOLOGIA_DE_USO" };
        arrValoresParametros = new string[] { "E"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCategoria_Uso"],"0")
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCodigo_uso_patrimonial"],"0")
                                            };                                     

        SQL_Execute.FUNC_Ejecuta_SP("Set_mnt_uso_actual", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_uso_patrimonial_actual.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Uso eliminado correctamente.');\n");
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
    
    protected void grdUsoActual_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoria_Uso.ClearSelection();
        ListItem olstCategoria_Uso = ddlCategoria_Uso.Items.FindByValue(grdUsoActual.SelectedRow.Cells[2].Text.Trim());
        if (olstCategoria_Uso != null) ddlCategoria_Uso.SelectedValue = olstCategoria_Uso.Value;

        Func_Busca_Categoria_Usos_Patrimoniales(ddlCategoria_Uso.SelectedValue);

        ddlCodigo_uso_patrimonial.ClearSelection();
        ListItem olstCodigo_uso_patrimonial = ddlCodigo_uso_patrimonial.Items.FindByValue(grdUsoActual.SelectedRow.Cells[4].Text.Trim());
        if (olstCodigo_uso_patrimonial != null) ddlCodigo_uso_patrimonial.SelectedValue = olstCodigo_uso_patrimonial.Value;

    }

    protected void ddlCategoria_Uso_SelectedIndexChanged(object sender, EventArgs e)
    {
        Func_Busca_Categoria_Usos_Patrimoniales(Request.Form["ddlCategoria_Uso"]);
    }

    protected void Func_Busca_Categoria_Usos_Patrimoniales(string strCategoriaUso) {

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "categoria" };
        arrValoresParametros = new string[] { strCategoriaUso };

        SQL_Execute.FUNC_Ejecuta_SP("Get_busca_CODIGO_USOS_PATRIMONIAL", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlCodigo_uso_patrimonial.DataSource = SQL_Execute.oReader;
            ddlCodigo_uso_patrimonial.DataTextField = "TIPOLOGIA_DE_USO";
            ddlCodigo_uso_patrimonial.DataValueField = "CODIGO_USO";
            ddlCodigo_uso_patrimonial.DataBind();
        }
        
    }
}
