///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Web-Form menu principal de la app web PYC
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Web-Form menu principal de la app web PYC
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

///<summary>
///Pantalla web-form menu principal de la app web PYC
///</summary>
///<remarks>
///Pantalla web-form menu principal de la app web PYC
///</remarks>
///

public partial class menu_principal : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    ///<summary>
    ///Metodo de carga pagina menu principal
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

        string strMenu = "";
        string strCelda = "";
        int intContCol = 1;

        Func_Libreria.FUNC_Valida_Sesion("menu_principal.aspx");

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

        arrNombreParametros = new string[] { "codigo_tipo_usuario" };
        arrValoresParametros = new string[] { Session["ID_Codigo_Tipo_Usuario"].ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Permisos_usuario", arrNombreParametros, arrValoresParametros);
        
        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                
                if ( (intContCol % 3) == 0)
                {
                    strCelda = strCelda + "<td style='text-align: center;'>\n";

                    strCelda = strCelda + "<a href = 'mantenedores/" + SQL_Execute.oReader["url_opcion"].ToString() + "' class='content' >" + SQL_Execute.oReader["nombre_opcion"].ToString() + "</br>";
                    strCelda = strCelda + "<img src='" + SQL_Execute.oReader["path_imagen_opcion"].ToString().Trim() + "' width='64' height='64' border='0'></a>\n";
                    strCelda = strCelda + "</td>\n";

                    strMenu = strMenu + ("<tr>\n" + strCelda + "</tr>\n<tr>\n<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>\n</tr>\n");
                    strCelda = "";
                }
                else
                {
                    strCelda = strCelda + "<td style='text-align: center;'>\n";
                    strCelda = strCelda + "<a href = 'mantenedores/" + SQL_Execute.oReader["url_opcion"].ToString() + "' class='content' >" + SQL_Execute.oReader["nombre_opcion"].ToString() + "</br>";
                    strCelda = strCelda + "<img src='" + SQL_Execute.oReader["path_imagen_opcion"].ToString().Trim() + "' width='64' height='64' border='0'></a>\n";
                    strCelda = strCelda + "</td>\n";
                }                

                intContCol = intContCol + 1;

            }

        }

        strMenu = strMenu + ("<tr>\n" + strCelda + "</tr>\n");
                
        lblTabla.Text = "\n<table style='width:70%;' border='0'>\n" + strMenu + "</table>\n";

        /**********************************************************************/

    }
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("menu_principal_pyc.aspx");
    }
}
