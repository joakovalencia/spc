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
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;

///<summary>
///Pantalla de login de la aplicación web
///</summary>
///<remarks>
///Pantalla de login de la aplicación web
///</remarks>
///


public partial class _Default : System.Web.UI.Page 
{
    ConexionWS SQL_Execute = new ConexionWS();

    private string str_AD_Path = ConfigurationManager.AppSettings["LDAP"].ToString();
    private string str_Domain = ConfigurationManager.AppSettings["Domain"].ToString();

    ///<summary>
    ///Metodo de carga pagina Login de usuario PYC
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
        string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        
        username = username.Substring(username.IndexOf('\\') + 1);

        txtUsuario.Focus();

        lblVersion.Text = " - Versión " + ConfigurationManager.AppSettings["Versión"].ToString();
    }

    ///<summary>
    ///Metodo de proceso de Login de usuario
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo click del boton Login
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo click del boton Login
    ///</param>
    ///
    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;
        bool strLogin = false;
        string strTipoUsuario = "";
        string strCodTipoUsuario = "0";
        string strNombreCompleto = "";


        //método para solicitar usuario y contraseña obligatorio
        string Usuario = Request.Form["txtUsuario"] != null ? Request.Form["txtUsuario"].ToString() : string.Empty;
        string Clave = Request.Form["txtContrasena"] != null ? Request.Form["txtContrasena"].ToString() : string.Empty;

        if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Clave))
        {
            lblMensajes.Text = "Usuario y contraseña son requeridos.";
            return;
        }
        bool blControlUsuario;

        wscorporativo.AccesoActiveDirectory ws = new wscorporativo.AccesoActiveDirectory();
        string response = ws.ValidaUsuarioAD(Usuario, Clave);
        blControlUsuario = response.Equals("SI existe usuario");

        //LdapAuthentication adAuth = new LdapAuthentication(str_AD_Path);
        //bool blControlUsuario = adAuth.IsAuthenticated(str_Domain, Usuario, Clave);

        if (!blControlUsuario)
        {
            lblMensajes.Text = "Usuario o contraseña incorrectos";

            return;
        }
        

        
        arrNombreParametros = new string[] { "usuario" };
        arrValoresParametros = new string[] { txtUsuario.Text.Trim() };

        SQL_Execute.FUNC_Ejecuta_SP("SetValida_Login_Usuario", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                if (SQL_Execute.oReader["resp"].ToString() == "si")
                {
                    strLogin = true;
                }

                strTipoUsuario = SQL_Execute.oReader["nombre_tipo_usuario"].ToString();
                strCodTipoUsuario = SQL_Execute.oReader["codigo_tipo_usuario"].ToString();
                strNombreCompleto = SQL_Execute.oReader["nombre_completo"].ToString();
            }
        }
        else
        {
            lblMensajes.Text = SQL_Execute.desc_error;
            strLogin = false;
            return;
        }        
        
        if (strLogin)
        {
            Session["ID_Usuario"] = txtUsuario.Text.Trim();
            Session["ID_Desc_Tipo_Usuario"] = strTipoUsuario;
            Session["ID_Codigo_Tipo_Usuario"] = strCodTipoUsuario;
            Session["ID_Sesion"] = Session.SessionID;
            Session["ID_Pregunta"] = "1";
            Session["ID_Nombre_Completo"] = strNombreCompleto;            
                        
            Response.Redirect("menu_principal_pyc.aspx");
            
        }
        else
        {
            lblMensajes.Text = "Usuario o contraseña incorrectos.";
        }
    }
}

