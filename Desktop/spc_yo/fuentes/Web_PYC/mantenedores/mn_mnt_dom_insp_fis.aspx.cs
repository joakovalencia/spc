///<summary>
///Creado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Inspectores Fiscales
//-----------------------
///Modificado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Inspectores Fiscales
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
///Menu de mantenedor de Inspectores Fiscales del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Inspectores Fiscales del sistema PYC
///</remarks>
///
public partial class mn_mnt_dom_insp_fis : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    ///<summary>
    ///Metodo de carga pagina mantenedor de Inspectores Fiscales PYC
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
        txtRut.MaxLength = 13;
        txtNombre.MaxLength = 30;
        txtProfesion.MaxLength = 20;
        txtSexo.MaxLength = 1;

        lblError.Text = "";

        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_dom_insp_fis.aspx");

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
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis"); //OK

            if (SQL_Execute.numero_error == 0)
            {
                grdInspectores.DataSource = SQL_Execute.oReader;
                grdInspectores.DataBind();
            }
                       
        }
    }

    ///<summary>
    ///Metodo de guardar datos en mantenedor de Inspectores Fiscales PYC
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

        arrNombreParametros = new string[] { "accion", "rut", "nombre", "profesion", "sexo"};
        arrValoresParametros = new string[] { "G", txtRut.Text.Trim(), txtNombre.Text.Trim(), txtProfesion.Text.Trim(), txtSexo.Text.Trim()};

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Dom_Insp_Fis", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Inspector creado o modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_dom_insp_fis.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    ///<summary>
    ///Metodo limpiar datos en mantenedor de Inspectores Fiscales PYC
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
        txtRut.ReadOnly = false;
        txtRut.Text = "";
        txtNombre.Text = "";
        txtProfesion.Text = "";
        txtSexo.Text = ""; 
    }

    ///<summary>
    ///Metodo de Eliminar datos en mantenedor de Inspectores Fiscales PYC
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

            arrNombreParametros = new string[] { "accion", "rut", "nombre", "profesion", "sexo" };
            arrValoresParametros = new string[] { "E", txtRut.Text.Trim(), txtNombre.Text.Trim(), txtProfesion.Text.Trim(), txtSexo.Text.Trim()};

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Dom_Insp_Fis", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Inspector eliminada correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_dom_insp_fis.aspx'\n");
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
        string attachment = "attachment; filename=listado_Inspectores_Fiscales_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdInspectores.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void grdInspectores_SelectedIndexChanged(object sender, EventArgs e)
    {
         txtRut.ReadOnly = true;
         txtRut.Text = grdInspectores.Rows[grdInspectores.SelectedIndex].Cells[1].Text;
         txtNombre.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdInspectores.Rows[grdInspectores.SelectedIndex].Cells[2].Text);
         txtProfesion.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdInspectores.Rows[grdInspectores.SelectedIndex].Cells[3].Text);
         txtSexo.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdInspectores.Rows[grdInspectores.SelectedIndex].Cells[4].Text);
    }
    protected void txtRut_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtProfesion_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtSexo_TextChanged(object sender, EventArgs e)
    {

    }
}
