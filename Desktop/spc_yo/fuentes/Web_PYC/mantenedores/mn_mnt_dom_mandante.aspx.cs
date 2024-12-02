///<summary>
///Creado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de Mandantes
//-----------------------
///Modificado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Mantenedor de Mandantes
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
///Menu de Mantenedor de Mandantes del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Mandantes del sistema PYC
///</remarks>
///

public partial class mn_mnt_dom_mandante : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();
   
    ///<summary>
    ///Metodo de carga pagina Mantenedor de Mandantes PYC
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
        txtSigla.MaxLength = 10;
        txtDescripcion.MaxLength = 50;

        lblError.Text = "";

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_dom_mandante.aspx");

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
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_mandante"); //OK

            if (SQL_Execute.numero_error == 0)
            {
                grdMandante.DataSource = SQL_Execute.oReader;
                grdMandante.DataBind();
            }
                        
        }
    }

    ///<summary>
    ///Metodo de guardar datos en Mantenedor de Mandantes PYC
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

        arrNombreParametros = new string[] { "accion", "sigla", "descripcion"};
        arrValoresParametros = new string[] { "G", txtSigla.Text.Trim(), txtDescripcion.Text.Trim()};

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Dom_Mandante", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Alerta creada o modificada correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_dom_mandante.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    ///<summary>
    ///Metodo limpiar datos en Mantenedor de Mandantes PYC
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
        txtSigla.ReadOnly = false;
        txtSigla.Text = "";
        txtDescripcion.Text = "";
    }

    ///<summary>
    ///Metodo de Eliminar datos en Mantenedor de Mandantes PYC
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard para el metodo Eliminar
    ///</param>
    ///<param name="sender">
    ///Parametro estandard para el metodo Eliminar
    ///</param>
    ///
    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] { "accion", "sigla", "descripcion" };
            arrValoresParametros = new string[] { "E", txtSigla.Text.Trim(), txtDescripcion.Text.Trim() };


            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Dom_Mandante", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Alerta eliminada correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_dom_mandante.aspx'\n");
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
        Response.Redirect("../menu_principal.aspx");
    }

    ///<summary>
    ///Metodo de Exportacion a Excel del sistema PYC
    ///</summary>    
    ///<return>
    ///Vacio
    ///</return>
    ///<param name="e">
    ///Parametro estandard para exportar a EXCEL
    ///</param>
    ///<param name="sender">
    ///Parametro estandard para exportar a EXCEL
    ///</param>
    ///

    protected void cmdExportarExcel_Click(object sender, ImageClickEventArgs e)
    {
        string attachment = "attachment; filename=listado_mandantes_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdMandante.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void grdMandante_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSigla.ReadOnly = true;
        txtSigla.Text = grdMandante.Rows[grdMandante.SelectedIndex].Cells[1].Text;
        txtDescripcion.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdMandante.Rows[grdMandante.SelectedIndex].Cells[2].Text);
    }
    protected void txtSigla_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtDescripcion_TextChanged(object sender, EventArgs e)
    {

    }
}
