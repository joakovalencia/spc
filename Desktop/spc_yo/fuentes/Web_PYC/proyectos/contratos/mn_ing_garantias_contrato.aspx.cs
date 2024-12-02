///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso garantias
///</summary>
///<summary>
///Modificado por: Alexi Rodriguez B. - MOP
///Fecha: 22-04-2014
///Descripción: Se crea metodo cmdEliminar_click para eliminar boleta de garantia
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

public partial class mn_ing_garantias_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        
        cmdGrabar.Attributes.Add("onClick", "target='_self';");
        cmdSalir.Attributes.Add("onClick", "target='_self';");

        lblError.Text = "";

        txtNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtMonto.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMonto.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMonto.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMonto.Attributes.Add("onpaste", "javascript:return false;");
        
        txtNumOfDestinoDocumento.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumOfSolicitudGarantia.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        //txtFechaNuevoVcto.Attributes.Add("onkeypress", "javascript:return func_vcto_nuevo();");

               
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
            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('Contrato no encontrado.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    txtRegion.Text = SQL_Execute.oReader["region"].ToString();
                    txtObjeto.Text = SQL_Execute.oReader["objeto"].ToString();
                    txtPIA.Text = SQL_Execute.oReader["codigo_da"].ToString();
                    txtSufijo.Text = SQL_Execute.oReader["sufijo"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["TIPO_PROCESO"].ToString();
                    txtCodCon.Text = SQL_Execute.oReader["cod_con"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_monedas");

            if (SQL_Execute.numero_error == 0)
            {
                ddlMoneda.DataSource = SQL_Execute.oReader;
                ddlMoneda.DataTextField = "COD_DESC";
                ddlMoneda.DataValueField = "COD_MONEDA";
                ddlMoneda.DataBind();
                ddlMoneda.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_garantias");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoGarantia.DataSource = SQL_Execute.oReader;
                ddlTipoGarantia.DataTextField = "COD_DESC";
                ddlTipoGarantia.DataValueField = "COD_TIPO";
                ddlTipoGarantia.DataBind();                
                ddlTipoGarantia.Items.Insert(0, "(SELECCIONAR)");
            }

            
            /********************************************************************/

            arrNombreParametros = new string[] { "COD_CON", "LLAVE" };
            arrValoresParametros = new string[] { txtCodCon.Text, "" };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_garantias", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlGarantia.DataSource = SQL_Execute.oReader;
                ddlGarantia.DataTextField = "Glosa_DDL";
                ddlGarantia.DataValueField = "Llave";
                ddlGarantia.DataBind();
                ddlGarantia.Items.Insert(0, "(NUEVO)");
            }
            
            /********************************************************************/
        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        /************************************************************************************************/
        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

        SQL_Execute.FUNC_Ejecuta_SP("Set_actualiza_fecha_contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error != 0) lblError.Text = SQL_Execute.desc_error;
        /************************************************************************************************/

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "COD_CON"
                                            , "COD_TIPO"
                                            , "ENTIDAD_FINANCIERA"
                                            , "NUMERO"
                                            , "FECHA"
                                            , "FECHA_VENCIMIENTO_INICIAL"
                                            , "FECHA_VENCIMIENTO"
                                            , "MONTO"
                                            , "TIPO_MONEDA"
                                            , "NUM_OFICIO_DESTINO_DOCUMENTO"
                                            , "FECHA_OFICIO_DESTINO_DOCUMENTO"
                                            , "ENTIDAD_QUE_CUSTODIA"
                                            , "NUM_OFICIO_SOLICITUD_GARANTIA"
                                            , "FECHA_OFICIO_SOLICITUD_GARANTIA"
                                            , "FECHA_DEVOLUCION_GARANTIA"
                                            , "TIPO_DE_DOCUMENTO"
                                            , "DEVUELTA"
                                            , "FECHA_PRORROGA"
                                            , "FECHA_NUEVO_VENCIMIENTO"
                                            , "DIAS" 
                                            , "Llave" 
                                            };
        arrValoresParametros = new string[] { Request.Form["txtCodCon"]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoGarantia"],"")
                                            , Request.Form["txtEntFinanciera"]
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtNumero"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEmision"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaVctoInicial"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaVctoVig"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMonto"]) 
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMoneda"],"")
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtNumOfDestinoDocumento"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaOfDestinoDocumento"])
                                            , Request.Form["txtEntCustodiaDocumento"]
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtNumOfSolicitudGarantia"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaOfSolicitudGarantia"]) 
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaDevGarantia"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoDoc"],"")
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlDevuelta"],"")
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaProrroga"]) 
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaNuevoVcto"])
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtDiasProrroga"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlGarantia"],"")
                                        };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_garantias", arrNombreParametros, arrValoresParametros);
        
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

    protected void ddlGarantia_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlGarantia.Text == "(NUEVO)") 
        {
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];
            string strSufijo = Page.Request.QueryString["sufijo"];

            Response.Redirect("mn_ing_garantias_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

            return;
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "COD_CON", "LLAVE" };
        arrValoresParametros = new string[] { txtCodCon.Text, ddlGarantia.SelectedValue.ToString() };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_garantias", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                txtCodCon.Text = SQL_Execute.oReader["COD_CON"].ToString();

                ddlTipoGarantia.ClearSelection();
                ListItem olstTipoGarantia = ddlTipoGarantia.Items.FindByValue(SQL_Execute.oReader["COD_TIPO"].ToString());
                if (olstTipoGarantia != null) ddlTipoGarantia.SelectedValue = olstTipoGarantia.Value;

                //ddlTipoGarantia.Text = SQL_Execute.oReader["COD_TIPO"].ToString();

                txtEntFinanciera.Text = SQL_Execute.oReader["ENTIDAD_FINANCIERA"].ToString();
                txtNumero.Text = SQL_Execute.oReader["NUMERO"].ToString();
                txtFechaEmision.Text = SQL_Execute.oReader["FECHA"].ToString();
                txtFechaVctoInicial.Text = SQL_Execute.oReader["FECHA_VENCIMIENTO_INICIAL"].ToString();
                txtFechaVctoVig.Text = SQL_Execute.oReader["FECHA_VENCIMIENTO"].ToString();
                txtMonto.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MONTO"].ToString(),0);

                ddlMoneda.ClearSelection();
                ListItem olstMoneda = ddlMoneda.Items.FindByValue(SQL_Execute.oReader["TIPO_MONEDA"].ToString());
                if (olstMoneda != null) ddlMoneda.SelectedValue = olstMoneda.Value;

                txtNumOfDestinoDocumento.Text = SQL_Execute.oReader["NUM_OFICIO_DESTINO_DOCUMENTO"].ToString();
                txtFechaOfDestinoDocumento.Text = SQL_Execute.oReader["FECHA_OFICIO_DESTINO_DOCUMENTO"].ToString();
                txtEntCustodiaDocumento.Text = SQL_Execute.oReader["ENTIDAD_QUE_CUSTODIA"].ToString();
                txtNumOfSolicitudGarantia.Text = SQL_Execute.oReader["NUM_OFICIO_SOLICITUD_GARANTIA"].ToString();
                txtFechaOfSolicitudGarantia.Text = SQL_Execute.oReader["FECHA_OFICIO_SOLICITUD_GARANTIA"].ToString();
                txtFechaDevGarantia.Text = SQL_Execute.oReader["FECHA_DEVOLUCION_GARANTIA"].ToString();

                ddlTipoDoc.ClearSelection();
                ListItem olstTipoDoc = ddlTipoDoc.Items.FindByValue(SQL_Execute.oReader["TIPO_DE_DOCUMENTO"].ToString());
                if (olstTipoDoc != null) ddlTipoDoc.SelectedValue = olstTipoDoc.Value;

                ddlDevuelta.ClearSelection();
                ListItem olstDevuelta = ddlDevuelta.Items.FindByValue(SQL_Execute.oReader["DEVUELTA"].ToString());
                if (olstDevuelta != null) ddlDevuelta.SelectedValue = olstDevuelta.Value;

                txtFechaProrroga.Text = SQL_Execute.oReader["FECHA_PRORROGA"].ToString();
                txtFechaNuevoVcto.Text = SQL_Execute.oReader["FECHA_NUEVO_VENCIMIENTO"].ToString();
                txtDiasProrroga.Text = SQL_Execute.oReader["DIAS"].ToString();
            }
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
    }
    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        string strCodCon = Request.Form["txtCodCon"];
        string strTipo = "C";

        if (Request.Form["txtCodCon"] == "")
        {
            lblError.Text = "Para conexión con SSD, debe ingresar un codigo de contrato.";
            return;
        }

        Response.Redirect("../ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);        

    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion
        if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
            HttpContext.Current.Response.Write("window.location.href='../../menu_principal_pyc.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        string strURLPostEliminar = "mn_ing_garantias_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "cod_con", "entidad_financiera","numero"};
        arrValoresParametros = new string[] { Request.Form["txtCodCon"], Request.Form["txtEntFinanciera"],Request.Form["txtNumero"]};

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_boleta_garantia_contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Eliminados correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostEliminar + "'\n");
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
