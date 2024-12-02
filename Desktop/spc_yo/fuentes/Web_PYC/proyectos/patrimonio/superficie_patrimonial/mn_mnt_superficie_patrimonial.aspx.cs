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
///Modificado por: Alexi Rodriguez Barrientos - MOP
///Fecha: 05-05-2014
///Descripción: Mostrar datos para eliminar registro.
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

public partial class mn_mnt_superficie_patrimonial : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    protected void Page_Load(object sender, EventArgs e)
    {
               
        Func_Libreria.FUNC_Valida_Sesion("///mn_ing_proyectos.aspx");

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];
                
        txtM2.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        //txtNivel.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtNivel.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtNivel.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtNivel.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtNivel.Attributes.Add("onpaste", "javascript:return false;");

        txtM2.Text = "0";
        txtNivel.Text = "0";

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
            arrNombreParametros = new string[] { "accion"
                                            , "CODIGO_PROYECTO"
                                            , "NIVEL"
                                            , "M2" 
                                            , "proceso_asociado"
                                            };
            arrValoresParametros = new string[] { "B"
                                            , strCodigoExploratorio
                                            , ""
                                            , "0"
                                            , "0"
                                            };

            SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Superficie", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdSuperficie.DataSource = SQL_Execute.oReader;
                grdSuperficie.DataBind();
            }

            int suma = 0;
            int acum = 0;
            foreach (GridViewRow row in grdSuperficie.Rows)
            {
                suma += Convert.ToInt32(grdSuperficie.Rows[acum].Cells[3].Text);
                acum = acum + 1;
            }
            txtM2Total.Text = Convert.ToString(suma);

            /*ddlProcesoAsoc.Items.Insert(0, "(SELECCIONAR)");
            ddlProcesoAsoc.Items.Insert(1, "Restauración");
            ddlProcesoAsoc.Items.Insert(2, "Obra Nueva");
             * */

            /********************************************************************/
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_proceso_asociado");

            if (SQL_Execute.numero_error == 0)
            {
                ddlProcesoAsoc.DataSource = SQL_Execute.oReader;
                ddlProcesoAsoc.DataTextField = "descripcion";
                ddlProcesoAsoc.DataValueField = "codigo";
                ddlProcesoAsoc.DataBind();
                ddlProcesoAsoc.Items.Insert(0, "(SELECCIONAR)");
            }

            /********************************************************************/

        }
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Page.Request.QueryString["codigo_region"]; //strCdigoRegion
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
                                            , "NIVEL"
                                            , "M2" 
                                            , "proceso_asociado"
                                            };
        arrValoresParametros = new string[] { "G"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNivel"])
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtM2"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProcesoAsoc"],"0")
                                            };
        //test
        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Superficie", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_superficie_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Superficie creada o modificada correctamente.');\n");
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

        Response.Redirect("mn_mnt_superficie_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Page.Request.QueryString["codigo_region"]; //strCdigoRegion
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
                                            , "NIVEL"
                                            , "M2"
                                            , "proceso_asociado"
                                            };
        arrValoresParametros = new string[] { "E"
                                            , strCodigoExploratorio
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNivel"])
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtM2"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProcesoAsoc"],"0")
                                            };
        //test
        SQL_Execute.FUNC_Ejecuta_SP("Set_Mnt_Superficie", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            string strURLBack = "mn_mnt_superficie_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Superficie creada o modificada correctamente.');\n");
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
       
    protected void grdSuperficie_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNivel.Text = grdSuperficie.Rows[grdSuperficie.SelectedIndex].Cells[2].Text.Trim();
        txtM2.Text = grdSuperficie.Rows[grdSuperficie.SelectedIndex].Cells[3].Text.Trim();

        ddlProcesoAsoc.ClearSelection();
        ListItem olstProcesoAsoc = ddlProcesoAsoc.Items.FindByValue(grdSuperficie.Rows[grdSuperficie.SelectedIndex].Cells[1].Text);//Se modifica valor de la celda a 1 estaba en 4
        if (olstProcesoAsoc != null) ddlProcesoAsoc.SelectedValue = olstProcesoAsoc.Value;        

        //Convert.ToInt32(grdSuperficie.Rows[grdSuperficie.SelectedIndex].Cells[2].Text);
    }
}
