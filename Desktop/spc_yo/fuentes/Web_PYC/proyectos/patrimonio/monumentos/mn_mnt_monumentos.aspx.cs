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

public partial class mn_mnt_monumentos : System.Web.UI.Page 
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

        txtNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumero.Text = "0";

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
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_monumento");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoDocumento.DataSource = SQL_Execute.oReader;
                ddlTipoDocumento.DataTextField = "DESCRIPCION";
                ddlTipoDocumento.DataValueField = "CODIGO";
                ddlTipoDocumento.DataBind();

                ddlTipoDocumento.Items.Insert(0, "(SELECCIONAR)");
                ddlProcesos.Items.Insert(0, "(SELECCIONAR)");
            }

            /**********************************************************************/

            arrNombreParametros = new string[] { "accion"
                                            , "TIPO"
                                            , "TIPO_DOC"
                                            , "NUM_DOC"
                                            , "FECHA"
                                            , "CODIGO_PROYECTO" 
                                            };
            arrValoresParametros = new string[] { "B"
                                        , ""
                                        , ""
                                        , ""
                                        , "0"
                                        , strCodigoExploratorio
                                        };
            //test
            SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Monumento", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdMonumentosNacionales.DataSource = SQL_Execute.oReader;
                grdMonumentosNacionales.DataBind();
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
                                            , "TIPO"
                                            , "TIPO_DOC"
                                            , "NUM_DOC"
                                            , "FECHA"
                                            , "CODIGO_PROYECTO" 
                                            };
        arrValoresParametros = new string[] { "G"
                                        , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProcesos"],"")
                                        , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoDocumento"],"")
                                        , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumero"])
                                        , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFecha"])
                                        , strCodigoExploratorio
                                        };

        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Monumento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_monumentos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Monumento creado o modificado correctamente.');\n");
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

        Response.Redirect("mn_mnt_monumentos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
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
                                            , "TIPO"
                                            , "TIPO_DOC"
                                            , "NUM_DOC"
                                            , "FECHA"
                                            , "CODIGO_PROYECTO" 
                                            };
        arrValoresParametros = new string[] { "E"
                                        , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProcesos"],"")
                                        , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoDocumento"],"")
                                        , Request.Form["txtNumero"]
                                        , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFecha"])
                                        , strCodigoExploratorio
                                        };

        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Monumento", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_monumentos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Monemento eliminado correctamente.');\n");
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
    
    protected void grdMonumentosNacionales_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProcesos.ClearSelection();
        ListItem olstProcesos = ddlProcesos.Items.FindByValue(grdMonumentosNacionales.SelectedRow.Cells[1].Text.Trim());
        if (olstProcesos != null) ddlProcesos.SelectedValue = olstProcesos.Value;

        ddlTipoDocumento.ClearSelection();
        ListItem olstTipoDocumento = ddlTipoDocumento.Items.FindByValue(grdMonumentosNacionales.SelectedRow.Cells[3].Text.Trim());
        if (olstTipoDocumento != null) ddlTipoDocumento.SelectedValue = olstTipoDocumento.Value;

        txtNumero.Text = grdMonumentosNacionales.SelectedRow.Cells[5].Text.Trim();
        txtFecha.Text = grdMonumentosNacionales.SelectedRow.Cells[6].Text.Trim();
    }
}
