///<summary>
///Creado por: Pablo Miranda Reinoso - Asesor Externo
///Fecha: 02-12-2019
///Descripción: Mantenedor de Tipos de Edificacion
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
///Menu de mantenedor de Tipos de Edificacion del sistema PYC   
///</summary>
///<remarks>
///Muestra menú de Tipos de Edificacion del sistema PYC
///</remarks>
///

public partial class mn_mnt_tipo_edificacion : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    ///<summary>
    ///Metodo de carga pagina mantenedor de Tipos de Edificacion PYC
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
        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_tipo_edificacion.aspx");
        
        txtTopologia.MaxLength = 2;
        txtDescripcion.MaxLength = 70;        
        /**********************************************************************/
        
        lblUsuario.Text = Session["ID_Usuario"].ToString();
        lblPerfil.Text = Session["ID_Desc_Tipo_Usuario"].ToString();
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");               
                
              
        /**********************************************************************/
        if (!IsPostBack)
        {            
            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_sector_destino");

            if (SQL_Execute.numero_error == 0)
            {
                ddlSectorDestino.DataSource = SQL_Execute.oReader;
                ddlSectorDestino.DataTextField = "codigo_nombre";
                ddlSectorDestino.DataValueField = "SECTOR_DESTINO";
                ddlSectorDestino.DataBind();
                ddlSectorDestino.Items.Insert(0, "(SELECCIONAR)");                                
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
        string SectorDestino;
        string SubSector;
        string Topologia;
        string Descripcion;
        string Msg;


        string[] arrNombreParametros;
        string[] arrValoresParametros;

        SectorDestino=ddlSectorDestino.SelectedValue;
        SubSector=ddlSubSector.SelectedValue;
        Topologia = txtTopologia.Text.Trim();
        Descripcion = txtDescripcion.Text.Trim();
        Msg = Validar();

        if (Msg=="")
        {
            arrNombreParametros = new string[] { "ACCION", "SECTOR_DESTINO", "SUBSECTOR", "TIPOLOGIA", "DESCRIPCION", "EDI_ORDEN_LISTADO" };
            arrValoresParametros = new string[] { "G", SectorDestino, SubSector, Topologia, Descripcion, "" };

            SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Edificacion", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                BuscarDatos();
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Tipo de Edificación Creada o Modificada Exitosamente');\n");
                //HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_edificacion.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                //HttpContext.Current.Response.End();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
        }
        else
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('" + Msg + "');\n");            
            HttpContext.Current.Response.Write("</SCRIPT>");
            //HttpContext.Current.Response.End();
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

        txtTopologia.Text="";
        txtTopologia.Enabled = true;
        txtDescripcion.Text = "";
        Habilitar(true);
        BuscarSubSectorDestino();
        BuscarDatos();
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
        string SectorDestino;
        string SubSector;
        string Topologia;
        string Descripcion;


        string[] arrNombreParametros;
        string[] arrValoresParametros;

        SectorDestino = ddlSectorDestino.SelectedValue;
        SubSector = ddlSubSector.SelectedValue;
        Topologia = txtTopologia.Text.Trim();
        Descripcion = txtDescripcion.Text.Trim();

        arrNombreParametros = new string[] { "ACCION", "SECTOR_DESTINO", "SUBSECTOR", "TIPOLOGIA", "DESCRIPCION", "EDI_ORDEN_LISTADO" };
        arrValoresParametros = new string[] { "E", SectorDestino, SubSector, Topologia, Descripcion ,""};


        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Edificacion", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                txtTopologia.Text = "";
                txtDescripcion.Text = "";
                Habilitar(true);
                BuscarDatos();
                HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Tipo de Edificación eliminada correctamente');\n");
                //HttpContext.Current.Response.Write("window.location.href='mn_mnt_tipo_edificacion.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                //HttpContext.Current.Response.End();
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
        string attachment = "attachment; filename=listado_tipoedificacion_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdTiposEdifi.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }
       
    protected void grdTiposEdifi_SelectedIndexChanged(object sender, EventArgs e)
    {

        Habilitar(false);
         ddlSubSector.SelectedValue=grdTiposEdifi.Rows[grdTiposEdifi.SelectedIndex].Cells[2].Text;
         txtTopologia.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdTiposEdifi.Rows[grdTiposEdifi.SelectedIndex].Cells[3].Text);
         txtDescripcion.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdTiposEdifi.Rows[grdTiposEdifi.SelectedIndex].Cells[4].Text);
         BuscarDatos();
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
    protected void ddlSectorDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuscarSubSectorDestino();
        BuscarDatos();

    }
    protected void ddlSubSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTopologia.Text = "";
        txtDescripcion.Text = "";
        txtTopologia.Enabled = true;
        BuscarDatos();
    }

    private void BuscarDatos()
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string SectorDestino;
        string SubSector;
        string Topologia;
        string Descripcion;

        SectorDestino = ddlSectorDestino.SelectedIndex == 0 ? "" : ddlSectorDestino.SelectedValue;
        SubSector = ddlSubSector.SelectedIndex == 0 ? "" : ddlSubSector.SelectedValue;
        Topologia = txtTopologia.Text.Trim();
        Descripcion = txtDescripcion.Text.Trim();

        arrNombreParametros = new string[] { "ACCION", "SECTOR_DESTINO", "SUBSECTOR", "TIPOLOGIA", "DESCRIPCION", "EDI_ORDEN_LISTADO" };
        arrValoresParametros = new string[] { "L", SectorDestino, SubSector, Topologia, Descripcion, "" };
        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_Edificacion", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            grdTiposEdifi.UseAccessibleHeader = true;
            grdTiposEdifi.DataSource = SQL_Execute.oReader;
            grdTiposEdifi.DataBind();

            if (grdTiposEdifi.Rows.Count > 0)
            {
                grdTiposEdifi.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdTiposEdifi.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }
    }

    private void BuscarSubSectorDestino()
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "sector_destino" };
        arrValoresParametros = new string[] { ddlSectorDestino.SelectedValue.ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_SubSector_Sector", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlSubSector.DataSource = SQL_Execute.oReader;
            ddlSubSector.DataTextField = "DESCRIPCION";
            ddlSubSector.DataValueField = "SUBSECTOR";
            ddlSubSector.DataBind();
            ddlSubSector.Items.Insert(0, "(SELECCIONAR)");

            txtTopologia.Text = "";
            txtDescripcion.Text = "";
            txtTopologia.Enabled = true;            
        }
    }

    private void Habilitar(bool modo)
    {
        txtTopologia.Enabled = modo;
        ddlSectorDestino.Enabled = modo;
        ddlSubSector.Enabled = modo;
    }

    private string Validar()
    {
        
        string Msg = "";

        if (txtTopologia.Text == "")
        {
            Msg = "Debe Ingresar la Tipología" + "\\n";
        }

        if (txtDescripcion.Text == "")
        {
            Msg = Msg + "Debe Ingresar la Descripción" + "\\n";
        }

        if (ddlSectorDestino.SelectedIndex == 0)
        {
            Msg = Msg + "Debe Ingresar el Sector" + "\\n";
        }

        if (ddlSubSector.SelectedIndex == 0 || ddlSubSector.Items.Count ==0)
        {
            Msg = Msg + "Debe Ingresar el Sub-Sector" + "\\n";
        }

        return Msg;        
    }
}
