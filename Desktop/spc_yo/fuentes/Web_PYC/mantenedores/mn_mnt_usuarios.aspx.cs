///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de usuario del sistema
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de usuario del sistema
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
///Menu de Mantenedor de usuario del sistema PYC   
///</summary>
///<remarks>
///Muestra menú Mantenedor de usuario del sistema PYC
///</remarks>
///

public partial class mn_mnt_usuarios : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    ///<summary>
    ///Metodo de carga pagina Mantenedor de usuario PYC
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

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_usuarios.aspx");

        lblError.Text = "";

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
                //lblMensajes.Text = "Tiene " + SQL_Execute.oReader["cant_mensajes"].ToString() + " mensaje(s)";
            }
        }
        /**********************************************************************/

        if (!IsPostBack)
        {   
            SQL_Execute.FUNC_Ejecuta_SP("sp_Busca_Usuarios");

            if (SQL_Execute.numero_error == 0)
            {
                ddlUsuario.DataSource = SQL_Execute.oReader;
                ddlUsuario.DataTextField = "nombre_usuario";
                //ddlUsuario.DataValueField = "codigo_tipo_usuario";
                ddlUsuario.DataBind();
                ddlUsuario.Items.Insert(0, "(NUEVO USUARIO)");
            }

            
            /******************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_Busca_Tipos_Usuarios");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoUsuario.DataSource = SQL_Execute.oReader;
                ddlTipoUsuario.DataTextField = "nombre_tipo_usuario";
                ddlTipoUsuario.DataValueField = "codigo_tipo_usuario";
                ddlTipoUsuario.DataBind();
                ddlTipoUsuario.SelectedIndex = 1;
            }

            
            /******************************************************************************/
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_Busca_Usuarios");

            if (SQL_Execute.numero_error == 0)
            {
                grdUsuarios.DataSource = SQL_Execute.oReader;
                grdUsuarios.DataBind();
            }

            /******************************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_region");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegion.DataSource = SQL_Execute.oReader;
                ddlRegion.DataTextField = "NOMBRE_REGION";
                ddlRegion.DataValueField = "REG";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, "(SELECCIONAR)");
            }

            /******************************************************************************/
        }
        
    }

    ///<summary>
    ///Metodo de seleccion de usuario en el web-form
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.Form["ddlUsuario"] == "(NUEVO USUARIO)")
        {
            txtUsuario.Enabled = true;
            txtUsuario.Text = "";
            //txtContrasena.Text = "";
            //txtContrasenaR.Text = "";
            txtCorreoElectronico.Text = "";
            ddlTipoUsuario.SelectedIndex = 1;
            ddlTipoUsuario.Enabled = true;
            txtNombreCompleto.Text = "";
        }
        else
        {
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] { "accion", "nombre_usuario", "correo_electronico", "codigo_tipo_usuario", "nombre_completo", "nombre_usuario_corto", "region" };
            arrValoresParametros = new string[] { "B", Request.Form["ddlUsuario"], "", "0", "", "", "" };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Usuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtUsuario.Text = SQL_Execute.oReader["nombre_usuario"].ToString();
                    txtCorreoElectronico.Text = SQL_Execute.oReader["correo_electronico"].ToString();
                    ddlTipoUsuario.ClearSelection();
                    ddlTipoUsuario.Items.FindByValue(SQL_Execute.oReader["codigo_tipo_usuario"].ToString()).Selected = true;
                    txtUsuario.Enabled = false;
                    txtNombreCompleto.Text = SQL_Execute.oReader["nombre_completo"].ToString();
                    ddlTipoUsuario.Enabled = false;

                    txtUsuarioCorto.Text = SQL_Execute.oReader["nombre_usuario_corto"].ToString();
                    ddlRegion.ClearSelection();
                    if (SQL_Execute.oReader["region"].ToString() != "") ddlRegion.Items.FindByValue(SQL_Execute.oReader["region"].ToString()).Selected = true; 
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
                        
        }
    }

    ///<summary>
    ///Metodo de guardar usuario en la tabla
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "accion", "nombre_usuario", "correo_electronico", "codigo_tipo_usuario", "nombre_completo", "nombre_usuario_corto", "region" };
        arrValoresParametros = new string[] { "G", txtUsuario.Text.Trim(), txtCorreoElectronico.Text.ToString(), ddlTipoUsuario.Text.ToString(), txtNombreCompleto.Text.Trim(), txtUsuarioCorto.Text.Trim() ,ddlRegion.SelectedValue.Trim() };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Usuario", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usuario creado o modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_usuarios.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    ///<summary>
    ///Metodo de limpiar web-form
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        txtUsuario.Enabled = true;
        txtUsuario.Text = "";
        //txtContrasena.Text = "";
        //txtContrasenaR.Text = "";
        txtCorreoElectronico.Text = "";
        ddlTipoUsuario.SelectedIndex = 1;
        ddlUsuario.SelectedIndex = 0;
        ddlTipoUsuario.Enabled = true;
        txtNombreCompleto.Text = "";        
    }

    ///<summary>
    ///Metodo de eliminar usuario
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUsuario.Text.Trim().ToUpper() == "ADMINISTRADOR")
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usuario ADMINISTRADOR no se puede eliminar.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_usuarios.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] { "accion", "nombre_usuario", "correo_electronico", "codigo_tipo_usuario", "nombre_completo", "nombre_usuario_corto", "region" };
            arrValoresParametros = new string[] { "E", txtUsuario.Text.Trim(), "", "0", "", "", "" };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Usuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Usuario eliminado correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_usuarios.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                HttpContext.Current.Response.End();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
        }
    }

    ///<summary>
    ///Metodo de salir del web-form
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal.aspx");
    }

    ///<summary>
    ///Metodo de exportacion a excel de los usuario del sistema
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo grabar
    ///</param>
    ///
    protected void cmdExportarExcel_Click(object sender, ImageClickEventArgs e)
    {
        string attachment = "attachment; filename=listado_usuarios_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdUsuarios.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
           
}
