///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla edicion contrato
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

public partial class mn_edi_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("/mn_edi_contrato.aspx");

        lblError.Text = "";

        txtSufijo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        /**********************************************************************/
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

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        
        if (!IsPostBack)
        {

            ddlProceso.Items.Insert(0, "(SELECCIONAR)");

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region"};
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion};

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyecto_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    txtRegion.Text = SQL_Execute.oReader["region"].ToString();
                    txtObjeto.Text = SQL_Execute.oReader["objeto"].ToString();
                    txtPIA.Text = SQL_Execute.oReader["codigo_da"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["TIPO_PROCESO"].ToString();
                    txtTipoProyecto.Text = SQL_Execute.oReader["tipo_proy"].ToString();                    
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {                       
                    txtCodigoContrato.Text = SQL_Execute.oReader["cod_con"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /********************************************************************/
                        
            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_correlativo_convenios_relacionados_edita", arrNombreParametros, arrValoresParametros);
            
            if (SQL_Execute.numero_error == 0)
            {
                ddlCorrConvenio.DataSource = SQL_Execute.oReader;
                ddlCorrConvenio.DataTextField = "DESC_CONVENIO";
                ddlCorrConvenio.DataValueField = "CODIGO_CONVENIO";
                ddlCorrConvenio.DataBind();
                ddlCorrConvenio.Items.Insert(0, "(SELECCIONAR)");
            }
                       
            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Correlativo_Mandantes_Relacionados_Edita", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlMandante.DataSource = SQL_Execute.oReader;
                ddlMandante.DataTextField = "DESC_MANDANTE";
                ddlMandante.DataValueField = "CODIGO_MANDANTE";
                ddlMandante.DataBind();
                ddlMandante.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Correlativo_Etapa_Relacionados_Edita", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlEtapa.DataSource = SQL_Execute.oReader;
                ddlEtapa.DataTextField = "DESC_ETAPA";
                ddlEtapa.DataValueField = "CODIGO_ETAPA";
                ddlEtapa.DataBind();
                ddlEtapa.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_correlativo_fondo_relacionados_edita");

            if (SQL_Execute.numero_error == 0)
            {
                ddlFinanciamiento.DataSource = SQL_Execute.oReader;
                ddlFinanciamiento.DataTextField = "DESC_FONDO";
                ddlFinanciamiento.DataValueField = "CODIGO_FONDO";
                ddlFinanciamiento.DataBind();
                ddlFinanciamiento.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /********************************************************************/

            string strProceso = "";

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo"};
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Detalle_Datos", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    string strURLBack = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('No se encontraron datos para los filtros seleccionados.');\n");
                    HttpContext.Current.Response.Write("window.location.href='" + strURLBack + "'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    ListItem olstCorrConvenio = ddlCorrConvenio.Items.FindByValue(SQL_Execute.oReader["CORRELATIVO_CONVENIO"].ToString());
                    if (olstCorrConvenio != null) ddlCorrConvenio.SelectedValue = olstCorrConvenio.Value;

                    ListItem olstMandante = ddlMandante.Items.FindByValue(SQL_Execute.oReader["MANDANTE_CONVENIO"].ToString());
                    if (olstMandante != null) ddlMandante.SelectedValue = olstMandante.Value;

                    ListItem olstEtapa = ddlEtapa.Items.FindByValue(SQL_Execute.oReader["ETAPA"].ToString());
                    if (olstEtapa != null) ddlEtapa.SelectedValue = olstEtapa.Value;
                    
                    ListItem olstFinanciamiento = ddlFinanciamiento.Items.FindByValue(SQL_Execute.oReader["FINANCIAMIENTO"].ToString());
                    if (olstFinanciamiento != null) ddlFinanciamiento.SelectedValue = olstFinanciamiento.Value;

                    strProceso = SQL_Execute.oReader["TIPO_PROCESO"].ToString();
                    txtSufijo.Text = SQL_Execute.oReader["SUFIJO"].ToString();                    
                    txtObjetoContrato.Text = SQL_Execute.oReader["OBJETO"].ToString();
                    txtEstatus.Text = SQL_Execute.oReader["ESTATUS"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
                        
            Func_proceso_etapa(txtTipoProyecto.Text, ddlEtapa.Text);

            ListItem olstProceso = ddlProceso.Items.FindByValue(strProceso);
            if (olstProceso != null) ddlProceso.SelectedValue = olstProceso.Value;            

            /********************************************************************/

        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdDetalleProyecto_Click(object sender, ImageClickEventArgs e)
    {
        //abre pantalla detalle proyecto
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        string strURLPostGrabar = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        Int16 numCORRELATIVO_CONVENIO = Int16.Parse(Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlCorrConvenio"], "0"));
        string strMANDANTE_CONVENIO = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"], "");
        string strETAPA = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEtapa"], "");
        string strTIPO_PROCESO = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProceso"], "");
        string strFINANCIAMIENTO = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFinanciamiento"], "");
        string strOBJETO = Request.Form["txtObjetoContrato"];

        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo", "numcorrelativo_convenio", "strmandante_convenio", "stretapa", "strtipo_proceso", "strfinanciamiento", "strobjeto" };
        arrValoresParametros = new string[] { Request.Form["txtPIA"], Request.Form["txtRegion"], Request.Form["txtSufijo"], numCORRELATIVO_CONVENIO.ToString(), strMANDANTE_CONVENIO, strETAPA, strTIPO_PROCESO, strFINANCIAMIENTO, strOBJETO };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_Contratos_Detalle_Edicion", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();            
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }

        
    }
       
    protected void ddlEtapa_SelectedIndexChanged(object sender, EventArgs e)
    {
        Func_proceso_etapa(Request.Form["txtTipoProyecto"], Request.Form["ddlEtapa"]);
    }

    private void Func_proceso_etapa(string strTipoProyecto, string strEtapa){

        string[] arrNombreParametros = new string[] { "tipologia", "etapa" };
        string[] arrValoresParametros = new string[] { strTipoProyecto, strEtapa };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Correlativo_Proceso_Relacionados_Edita", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            ddlProceso.DataSource = SQL_Execute.oReader;
            ddlProceso.DataTextField = "DESC_PROCESO";
            ddlProceso.DataValueField = "CODIGO_PROCESO";
            ddlProceso.DataBind();
            ddlProceso.Items.Insert(0, "(SELECCIONAR)");
        }
                
    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        string strURLPostGrabar = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
        arrValoresParametros = new string[] { Request.Form["txtPIA"], Request.Form["txtRegion"], Request.Form["txtSufijo"] };

        SQL_Execute.FUNC_Ejecuta_SP("Set_Elimina_Contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos eliminados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }
    }
}
