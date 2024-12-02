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

public partial class mn_mnt_contratistas : System.Web.UI.Page 
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

        txtRut.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtTeleFax.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtRut.MaxLength = 13;
        txtNombre.MaxLength = 60;
        txtRegistro.MaxLength = 5;
        txtCategoria.MaxLength = 15;
        txtTeleFax.MaxLength = 25;
        txtSexo.MaxLength = 1;
                
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
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_contratistas");//OK

            if (SQL_Execute.numero_error == 0)
            {
                grdContratistas.DataSource = SQL_Execute.oReader;
                grdContratistas.DataBind();
                
            }
                        
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

        arrNombreParametros = new string[] { "accion", "rut_ctta", "n_ctta", "registro", "categoria", "telefono_fax", "sexo" };
        arrValoresParametros = new string[] { "G", txtRut.Text.Trim(), txtNombre.Text.Trim(), txtRegistro.Text.Trim(), txtCategoria.Text.Trim(), txtTeleFax.Text.Trim(), txtSexo.Text.Trim() };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Contratista", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Contratista creado o modificado correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_contratistas.aspx'\n");
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
        txtRut.ReadOnly = false;
        txtRut.Text = "";
        txtNombre.Text = "";
        txtRegistro.Text = "";
        txtCategoria.Text = "";
        txtTeleFax.Text = "";
        txtSexo.Text = "";
    }

    ///<summary>
    ///Metodo de Eliminar datos en mantenedor de Contratistas PYC
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

            arrNombreParametros = new string[] { "accion", "rut_ctta", "n_ctta", "registro", "categoria", "telefono_fax", "sexo" };
            arrValoresParametros = new string[] { "E", txtRut.Text.Trim(), txtNombre.Text.Trim(), txtRegistro.Text.Trim(), txtCategoria.Text.Trim(), txtTeleFax.Text.Trim(), txtSexo.Text.Trim() };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Contratista", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Contratista eliminado correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_contratistas.aspx'\n");
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
        string attachment = "attachment; filename=listado_Contratistas_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdContratistas.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void grdContratistas_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtRut.ReadOnly = true;
        txtRut.Text = grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[1].Text;
        txtNombre.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[2].Text);
        txtRegistro.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[3].Text);
        txtCategoria.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[4].Text);
        txtTeleFax.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[5].Text);
        txtSexo.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdContratistas.Rows[grdContratistas.SelectedIndex].Cells[6].Text);   
    }
    protected void txtRut_TextChanged(object sender, EventArgs e)
    {
        
  
    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtRegistro_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtCategoria_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtTeleFax_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtSexo_TextChanged(object sender, EventArgs e)
    {
        
    }
}
