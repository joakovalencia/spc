///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de tipos de usuario del sistema
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor tipos de usuario del sistema
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

public partial class mn_mnt_tipo_usuarios : System.Web.UI.Page 
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
        lblError.Text = "";

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_tipo_usuarios.aspx");

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
            SQL_Execute.FUNC_Ejecuta_SP("sp_Busca_Tipos_Usuarios");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoUsuario.DataSource = SQL_Execute.oReader;
                ddlTipoUsuario.DataTextField = "nombre_tipo_usuario";
                ddlTipoUsuario.DataValueField = "codigo_tipo_usuario";
                ddlTipoUsuario.DataBind();
                //ddlTipoUsuario.SelectedIndex = 1;
                ddlTipoUsuario.Items.Insert(0, "(NUEVO USUARIO)");
            }            

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
        if (Request.Form["ddlTipoUsuario"] == "(NUEVO USUARIO)")
        {
            txtTipoUsuario.Enabled = true;
            txtTipoUsuario.Text = "";
            //txtContrasena.Text = "";
            //txtContrasenaR.Text = "";
            //ddlTipoUsuario.SelectedIndex = 1;
            ddlTipoUsuario.Enabled = false;
        }
        else
        {/*
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] { "accion", "nombre_tipo_usuario" };
            arrValoresParametros = new string[] { "B", Request.Form["ddlTipoUsuario"] };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_TipoUsuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtTipoUsuario.Text = SQL_Execute.oReader["nombre_usuario"].ToString();                    
                    ddlTipoUsuario.ClearSelection();
                    ddlTipoUsuario.Items.FindByValue(SQL_Execute.oReader["codigo_tipo_usuario"].ToString()).Selected = true;
                    txtTipoUsuario.Enabled = false;                    
                    ddlTipoUsuario.Enabled = false;
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            */

            txtTipoUsuario.Enabled = false;
            txtTipoUsuario.Text = ddlTipoUsuario.SelectedItem.Text;
            
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

        if (Request.Form["ddlTipoUsuario"] == "(NUEVO USUARIO)")
        {
            arrNombreParametros = new string[] { "accion", "nombre_tipo_usuario" };
            arrValoresParametros = new string[] { "G", Request.Form["txtTipoUsuario"] };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_TipoUsuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Grupo Usuario creado correctamente.');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_usuarios.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                HttpContext.Current.Response.End();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
        }
        else
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Grupo Usuario seleccionado, no se puede modificar.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_usuarios.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
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
        txtTipoUsuario.Enabled = true;
        txtTipoUsuario.Text = "";
        ddlTipoUsuario.SelectedIndex = 1;
        ddlTipoUsuario.SelectedIndex = 0;
        ddlTipoUsuario.Enabled = true;
        
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
        if (ddlTipoUsuario.SelectedItem.Text == "ADMINISTRADOR" || Request.Form["ddlTipoUsuario"] == "1")
        {            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Grupo Usuario ADMINISTRADOR no se puede eliminar.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_usuarios.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] { "accion", "nombre_tipo_usuario" };
            arrValoresParametros = new string[] { "E", txtTipoUsuario.Text };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_TipoUsuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Grupo Usuario eliminado correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_usuarios.aspx'\n");
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
}
