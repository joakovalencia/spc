///<summary>
///Creado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Contratistas
//-----------------------
///Modificado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Contratistas
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
///Menu de mantenedor de Contratistas del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Contratistas del sistema PYC
///</remarks>
///

public partial class mn_mnt_estado_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    ///<summary>
    ///Metodo de carga pagina mantenedor de Contratistas PYC
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

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_contratistas.aspx");

        txtCodCon.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtSufijo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
       
                
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

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_regiones");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegion.DataSource = SQL_Execute.oReader;
                ddlRegion.DataTextField = "nombre_region";
                ddlRegion.DataValueField = "REG";
                ddlRegion.DataBind();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /**********************************************************************/
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add("(SIN ESTADO)");
            ddlEstado.Items.Add("Desierta");
            ddlEstado.Items.Add("Fuera de base");
            ddlEstado.Items.Add("No conveniente");
            ddlEstado.Items.Add("Invalida o Anulada");
            ddlEstado.Items.Add("Propuesta sin programación");
            ddlEstado.Items.Add("En Programación");
            ddlEstado.Items.Add("Programado");
            ddlEstado.Items.Add("Proceso de Publicación");
            ddlEstado.Items.Add("En proceso de adjudicación");
            ddlEstado.Items.Add("En ejecución");
            ddlEstado.Items.Add("Terminado");
            ddlEstado.Items.Add("Recep.Única");
            ddlEstado.Items.Add("Recep.Provisoria");
            ddlEstado.Items.Add("Recep.Definitiva");              
            ddlEstado.Items.Add("Terminno anticipado");
            ddlEstado.Items.Add("Liquidación anticipada");
            ddlEstado.Items.Add("Liquidado");
        }
    }

    ///<summary>
    ///Metodo de guardar datos en mantenedor de Contratistas PYC
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

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "accion"
            , "cod_con"
            , "region"
            , "sufijo"
            , "estatus"
            , "marca"
        };
        arrValoresParametros = new string[] { "G"
            , Request.Form["txtCodCon"]
            , Request.Form["ddlRegion"]
            , Request.Form["txtSufijo"]
            , Request.Form["ddlEstado"] 
            , Request.Form["TextMarca"] 
        };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Contrato_Estado", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Contrato modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_estado_contrato.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    ///<summary>
    ///Metodo limpiar datos en mantenedor de Contratistas PYC
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard del metodo Limpiar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard del metodo Limpiar
    ///</param>
    ///
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mn_mnt_estado_contrato.aspx");
    }

    
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal.aspx");
    }


    protected void cmdBuscar_Click(object sender, ImageClickEventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "accion"
                                            , "cod_con"
                                            , "region"
                                            , "sufijo"
                                            , "estatus"
                                            , "marca"
                                            };
        arrValoresParametros = new string[] { "B"
                                            , Request.Form["txtCodCon"]
                                            , Request.Form["ddlRegion"]
                                            , Request.Form["txtSufijo"]
                                            , ""
                                            , "" 
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Contrato_Estado", arrNombreParametros, arrValoresParametros);
        
        if (SQL_Execute.numero_error == 0)
        {
            
            while (SQL_Execute.oReader.Read())
            {
                TextMarca.Text = SQL_Execute.oReader["marca"].ToString();
                ddlEstado.ClearSelection();
                ListItem olstTipoConvenio = ddlEstado.Items.FindByValue(SQL_Execute.oReader["ESTATUS"].ToString());

               
                
                if (olstTipoConvenio != null) ddlEstado.SelectedValue = olstTipoConvenio.Value;

                
            }           
        }
        else
        {

            if (SQL_Execute.numero_error == 99)
            {
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Contrato no encontrado.');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_estado_contrato.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                HttpContext.Current.Response.End();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
        }

        
    }
}
