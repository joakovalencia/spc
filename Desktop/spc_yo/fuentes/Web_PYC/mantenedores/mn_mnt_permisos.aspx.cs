///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de Permisos de usuario
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de Permisos de usuario
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
///Menu de Mantenedor de Permisos de usuario del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Permisos de usuario del sistema PYC
///</remarks>
///

public partial class mn_mnt_permisos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();
    
   
    ///<summary>
    ///Metodo de carga pagina Permisos de usuario PYC
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

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_permisos.aspx");

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

        lblError.Text = "";
        
        if (!IsPostBack)
        {            
            SQL_Execute.FUNC_Ejecuta_SP("sp_Busca_Tipos_Usuarios");

            if (SQL_Execute.numero_error == 0)
            {
                ddlUsuario.DataSource = SQL_Execute.oReader;
                ddlUsuario.DataTextField = "nombre_tipo_usuario";
                ddlUsuario.DataValueField = "codigo_tipo_usuario";
                ddlUsuario.DataBind();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error.ToString();
            }

            cmdGrabar.Enabled = false;

            //TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
        }
        
    }

    ///<summary>
    ///Metodo de guardar datos en tabla permisos de usuario PYC
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
        string strCodigoOpc = "0";
        string strAsignar = "";
        string strError = "";

        for (int cont = 0; cont <= TreeView1.Nodes.Count - 1; cont++)
        {
            strCodigoOpc = TreeView1.Nodes[cont].Value;

            if (TreeView1.Nodes[cont].Checked)
                strAsignar = "S";
            else
                strAsignar = "N";

            arrNombreParametros = new string[] { "accion", "codigo_tipo_usuario", "codigo_opcion", "asignar" };
            arrValoresParametros = new string[] { "G", Request.Form["ddlUsuario"], strCodigoOpc, strAsignar };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Permisos_Usuario", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error != 0)
            {
                strError = SQL_Execute + SQL_Execute.desc_error;
            }
            /*
            for (int cont2 = 0; cont2 <= TreeView1.Nodes[cont].ChildNodes.Count - 1; cont2++)
            {
                strCodigoOpc = TreeView1.Nodes[cont].ChildNodes[cont2].Value;

                if (TreeView1.Nodes[cont].ChildNodes[cont2].Checked)
                    strAsignar = "S";
                else
                    strAsignar = "N";

                arrNombreParametros = new string[] { "accion", "nombre_usuario", "codigo_opcion", "asignar" };
                arrValoresParametros = new string[] { "G", Request.Form["ddlUsuario"], strCodigoOpc, strAsignar };

                SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Permisos_Usuario", arrNombreParametros, arrValoresParametros);

                if (SQL_Execute.numero_error != 0)
                {
                    strError = SQL_Execute + SQL_Execute.desc_error;
                }
            }*/

            
        }

        if (strError == "")
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Permiso de Usuario creado o modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_permisos.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = strError;
        }
    }

    ///<summary>
    ///Metodo de limpiar web-form
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo limpiar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo limpiar
    ///</param>
    ///
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mn_mnt_permisos.aspx");
    }

    ///<summary>
    ///Metodo busca permisos de usuario
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Vacio
    ///</param>
    ///<param name="sender">
    ///Vacio
    ///</param>
    ///
    private void Func_Busca_Permisos()
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "accion", "codigo_tipo_usuario", "codigo_opcion", "asignar" };
        arrValoresParametros = new string[] { "B", Request.Form["ddlUsuario"], "0", "" };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Permisos_Usuario", arrNombreParametros, arrValoresParametros);

        TreeView1.Nodes.Clear();

        int intContNode = -1;

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                TreeNode treeNode = new TreeNode(SQL_Execute.oReader["nombre_opcion"].ToString());
                treeNode.Value = SQL_Execute.oReader["codigo_opcion"].ToString();

                treeNode.ShowCheckBox = true;
                treeNode.SelectAction = TreeNodeSelectAction.None;

                if (SQL_Execute.oReader["permiso"].ToString() == "1")
                    treeNode.Checked = true;
                else
                    treeNode.Checked = false;

                TreeView1.Nodes.Add(treeNode);
                intContNode = intContNode + 1;

                /*if (SQL_Execute.oReader["indice"].ToString() == "1")
                {
                    TreeView1.Nodes.Add(treeNode);
                    intContNode = intContNode + 1;
                }
                else
                {
                    TreeView1.Nodes[intContNode].ChildNodes.Add(treeNode);
                }*/

                cmdGrabar.Enabled = true;
            }

            TreeView1.ExpandAll();

        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }

        
    }

    ///<summary>
    ///Metodo salir de web-form mantendor de permisos
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo salir
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo salir
    ///</param>
    ///
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal.aspx");
    }

    ///<summary>
    ///Metodo buscar permisos de usuario
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo buscar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo buscar
    ///</param>
    ///
    protected void cmdBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Func_Busca_Permisos();
    }
}
