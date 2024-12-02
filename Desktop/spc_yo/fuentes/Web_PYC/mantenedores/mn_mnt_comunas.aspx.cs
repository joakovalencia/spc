///<summary>
///Creado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Comunas
//-----------------------
///Modificado por: Juan Carlos Aguilera - GSI Asesorias
///Fecha: 10-10-2012
///Descripción: Mantenedor de Comunas
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
///Menu de mantenedor de Comunas del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Comunas del sistema PYC
///</remarks>
///

public partial class mn_mnt_comunas : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    ///<summary>
    ///Metodo de carga pagina mantenedor de Comunas PYC
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
        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_comunas.aspx");

        txtCodigoComuna.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumComuna.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtPoblacion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRegion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtProvincia.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtCodigoComuna.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtNombre.MaxLength = 25;
        txtRegion.MaxLength = 2;
        txtProvincia.MaxLength = 1;
        txtNumComuna.MaxLength = 2;
        txtCodigoComuna.MaxLength = 5;

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
           
           SQL_Execute.FUNC_Ejecuta_SP("sp_busca_comunas");//OK

            if (SQL_Execute.numero_error == 0)
            {
                grdComunas.DataSource = SQL_Execute.oReader;
                grdComunas.DataBind();
            }

            
        }
        
    }

    ///<summary>
    ///Metodo de guardar datos en mantenedor de Comunas PYC
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

        arrNombreParametros = new string[] { "accion", "region", "provincia", "comuna", "cod_comun", "n_comu", "poblacion" };
        arrValoresParametros = new string[] { "G", txtRegion.Text.Trim(), txtProvincia.Text.Trim(), txtNumComuna.Text.Trim(), txtCodigoComuna.Text.Trim(), txtNombre.Text.Trim(), txtPoblacion.Text.Trim() };

        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Comunas", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Comuna Creada o Modificada Exitosamente');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_comunas.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    ///<summary>
    ///Metodo limpiar datos en mantenedor de Comunas PYC
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
        txtCodigoComuna.ReadOnly = false;
        txtNombre.Text = "";
        txtRegion.Text = "";
        txtProvincia.Text = "";
        txtNumComuna.Text = "";
        txtCodigoComuna.Text = "";
        txtPoblacion.Text = "";
    }

    ///<summary>
    ///Metodo de Eliminar datos en mantenedor de Comunas PYC
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

            arrNombreParametros = new string[] { "accion", "region", "provincia", "comuna", "cod_comun", "n_comu", "poblacion" };
            arrValoresParametros = new string[] { "E", txtRegion.Text.Trim(), txtProvincia.Text.Trim(), txtNumComuna.Text.Trim(), txtCodigoComuna.Text.Trim(), txtNombre.Text.Trim(), txtPoblacion.Text.Trim() };


            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Comunas", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Comuna eliminada correctamente');\n");
                HttpContext.Current.Response.Write("window.location.href='mn_mnt_comunas.aspx'\n");
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
        string attachment = "attachment; filename=listado_comunas_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdComunas.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    
    protected void grdComunas_SelectedIndexChanged(object sender, EventArgs e)
    {
         txtCodigoComuna.ReadOnly = true;
         txtRegion.Text  = grdComunas.Rows[grdComunas.SelectedIndex].Cells[1].Text;
         txtProvincia.Text = grdComunas.Rows[grdComunas.SelectedIndex].Cells[2].Text;
         txtNumComuna.Text = grdComunas.Rows[grdComunas.SelectedIndex].Cells[3].Text;
         txtCodigoComuna.Text = grdComunas.Rows[grdComunas.SelectedIndex].Cells[4].Text;
         txtNombre.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdComunas.Rows[grdComunas.SelectedIndex].Cells[5].Text);
         txtPoblacion.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdComunas.Rows[grdComunas.SelectedIndex].Cells[6].Text);
    }

    protected void txtPoblacion_TextChanged(object sender, EventArgs e)
    {
    }
    
    protected void txtRegion_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtProvincia_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtComuna_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtCodigoComuna_TextChanged(object sender, EventArgs e)
    {

    }
}
