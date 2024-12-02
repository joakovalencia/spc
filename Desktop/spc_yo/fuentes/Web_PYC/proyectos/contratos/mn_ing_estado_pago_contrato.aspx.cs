///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso estado pago
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

public partial class mn_ing_estado_pago_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");
        
        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        //txtContratoMatriz.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtContratoMatriz.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtContratoMatriz.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtContratoMatriz.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtContratoMatriz.Attributes.Add("onpaste", "javascript:return false;");


        //txtAumenoContrato.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtAumenoContrato.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAumenoContrato.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtAumenoContrato.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAumenoContrato.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtReajuste.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtReajuste.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtReajuste.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtReajuste.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtReajuste.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtAnticipo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtAnticipo.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAnticipo.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtAnticipo.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAnticipo.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtCanjeRetencion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtCanjeRetencion.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtCanjeRetencion.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtCanjeRetencion.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtCanjeRetencion.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtDevolucionRetencion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtDevolucionRetencion.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtDevolucionRetencion.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtDevolucionRetencion.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtDevolucionRetencion.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtDevolucionAnticipo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtDevolucionAnticipo.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtDevolucionAnticipo.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtDevolucionAnticipo.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtDevolucionAnticipo.Attributes.Add("onpaste", "javascript:return false;");

        
        //txtReajusteDevolucionAnticipo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtReajusteDevolucionAnticipo.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtReajusteDevolucionAnticipo.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtReajusteDevolucionAnticipo.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtReajusteDevolucionAnticipo.Attributes.Add("onpaste", "javascript:return false;");


        //txtRetencion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtRetencion.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtRetencion.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtRetencion.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtRetencion.Attributes.Add("onpaste", "javascript:return false;");


        //txtMulta.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtMulta.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMulta.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMulta.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMulta.Attributes.Add("onpaste", "javascript:return false;");


        //txtImpuestoHonorarios.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtImpuestoHonorarios.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtImpuestoHonorarios.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtImpuestoHonorarios.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtImpuestoHonorarios.Attributes.Add("onpaste", "javascript:return false;");


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

            txtContratoMatriz.Text = "0";
            txtAumenoContrato.Text = "0";
            txtReajuste.Text = "0";
            txtAnticipo.Text = "0";
            txtCanjeRetencion.Text = "0";
            txtDevolucionRetencion.Text = "0";
            txtDevolucionAnticipo.Text = "0";
            txtReajusteDevolucionAnticipo.Text = "0";
            txtRetencion.Text = "0";
            txtMulta.Text = "0";
            txtImpuestoHonorarios.Text = "0";

            lblVEPContratoMatriz.Text = "0";
            lblVEPAumenoContrato.Text = "0";
            lblVEPReajuste.Text = "0";
            lblVEPAnticipo.Text = "0";
            lblVEPCanjeRetencion.Text = "0";
            lblVEPDevolucionRetencion.Text = "0";
            lblVEPReajusteDevolucionAnticipo.Text = "0";

            lblCAPContratoMatriz.Text = "0";
            lblCAPAumenoContrato.Text = "0";
            lblCAPReajuste.Text = "0";
            lblCAPAnticipo.Text = "0";
            lblCAPDevolucionAnticipo.Text = "0";
            lblCAPReajusteDevolucionAnticipo.Text = "0";

            lblLiquidoPagar.Text = "0";
            lblValorEstadoPago.Text = "0";
            lblCargoAPresupuesto.Text = "0";

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

            /*************************************************************************/
        
            arrNombreParametros = new string[] { "cod_con", "NUM_EPAGO" };        
            arrValoresParametros = new string[] { txtCodCon.Text, "0" };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_estado_pago", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlNumEstadoPago.DataSource = SQL_Execute.oReader;

                ddlNumEstadoPago.DataTextField = "NUM_EPAGO";
                ddlNumEstadoPago.DataValueField = "NUM_EPAGO";

                ddlNumEstadoPago.DataBind();
                
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            ddlNumEstadoPago.Items.Insert(0, "(NUEVO)");

            
            /**********************************************************************/

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

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        /************************************************************************************************/
        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

        SQL_Execute.FUNC_Ejecuta_SP("Set_actualiza_fecha_contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error != 0) lblError.Text = SQL_Execute.desc_error;
        /************************************************************************************************/

        string strNumEstadoPago = "0";

        if (Request.Form["ddlNumEstadoPago"] == "(NUEVO)")
            strNumEstadoPago = "0";
        else
            strNumEstadoPago = Request.Form["ddlNumEstadoPago"];

        arrNombreParametros = new string[] { "cod_con",
                                            "NUM_EPAGO",
                                            "FECHA_EPAGO" ,
                                            "PAG_CTTO_MATRIZ" ,
                                            "PAG_MOD_CTTO" ,
                                            "PAG_REAJ" ,
                                            "PAG_ANTICIPO" ,
                                            "PAG_CANJE_RET" ,
                                            "PAG_DEVOL_RET" ,
                                            "DEVOL_ANTICIPO" ,
                                            "REAJ_DEVOL_ANTIC" ,
                                            "RETENCIONES" ,
                                            "MULTAS" ,
                                            "IMPUESTO" ,
                                            "LIQUIDO_A_PAGAR" ,
                                            "VALOR_E_PAGO" ,
                                            "CARGO_A_PRES" 
                                        };        
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                strNumEstadoPago,
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstadoPago"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtContratoMatriz"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtAumenoContrato"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtReajuste"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtAnticipo"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtCanjeRetencion"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtDevolucionRetencion"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtDevolucionAnticipo"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtReajusteDevolucionAnticipo"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtRetencion"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtMulta"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtImpuestoHonorarios"]),

                                                Func_Libreria.FUNC_MontoSQL(Request.Form["lblLiquidoPagar"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["lblValorEstadoPago"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["lblCargoAPresupuesto"]),
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGrabar_contratos_detalle_estado_pago", arrNombreParametros, arrValoresParametros);
        
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
    
    private void FUNC_Busca_Estado_Pago()
    {

        lblError.Text = "";

        if (ddlNumEstadoPago.Text.Trim() == "0" || ddlNumEstadoPago.Text.Trim() == "")
        {
            lblError.Text = "Debe Ingresar Numero Estado Pago";
            return;
        }

        if (ddlNumEstadoPago.Text.Trim() == "(NUEVO)")
        {
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];
            string strSufijo = Page.Request.QueryString["sufijo"];

            Response.Redirect("mn_ing_estado_pago_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);

            return;
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "cod_con", "NUM_EPAGO" };
        arrValoresParametros = new string[] { txtCodCon.Text, ddlNumEstadoPago.Text };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_estado_pago", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                txtFechaEstadoPago.Text = SQL_Execute.oReader["FECHA_EPAGO"].ToString();
                txtContratoMatriz.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_CTTO_MATRIZ"].ToString(),0);
                txtAumenoContrato.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_MOD_CTTO"].ToString(),0);
                txtReajuste.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_REAJ"].ToString(),0);
                txtAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_ANTICIPO"].ToString(),0);
                txtCanjeRetencion.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_CANJE_RET"].ToString(),0);
                txtDevolucionRetencion.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_DEVOL_RET"].ToString(),0);
                txtDevolucionAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["DEVOL_ANTICIPO"].ToString(),0);
                txtReajusteDevolucionAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["REAJ_DEVOL_ANTIC"].ToString(),0);
                txtRetencion.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["RETENCIONES"].ToString(),0);
                txtMulta.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MULTAS"].ToString(),0);
                txtImpuestoHonorarios.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["IMPUESTO"].ToString(),0);

                lblVEPContratoMatriz.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_CTTO_MATRIZ"].ToString(),0);
                lblVEPAumenoContrato.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_MOD_CTTO"].ToString(),0);
                lblVEPReajuste.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_REAJ"].ToString(),0);
                lblVEPAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_ANTICIPO"].ToString(),0);
                lblVEPCanjeRetencion.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_CANJE_RET"].ToString(),0);
                lblVEPDevolucionRetencion.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_DEVOL_RET"].ToString(),0);
                lblVEPReajusteDevolucionAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["REAJ_DEVOL_ANTIC"].ToString(),0);

                lblCAPContratoMatriz.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_CTTO_MATRIZ"].ToString(),0);
                lblCAPAumenoContrato.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_MOD_CTTO"].ToString(),0);
                lblCAPReajuste.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_REAJ"].ToString(),0);
                lblCAPAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["PAG_ANTICIPO"].ToString(),0);
                lblCAPDevolucionAnticipo.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["DEVOL_ANTICIPO"].ToString(),0);
                lblCAPReajusteDevolucionAnticipo.Text =Func_Libreria.FUNC_MontoASPv2( SQL_Execute.oReader["REAJ_DEVOL_ANTIC"].ToString(),0);

                lblLiquidoPagar.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["LiquidoAPagar"].ToString(),0);
                lblValorEstadoPago.Text = Func_Libreria.FUNC_MontoASPv2( SQL_Execute.oReader["ValorEstadoPago"].ToString(),0);
                lblCargoAPresupuesto.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["CargoAPresupuesto"].ToString(),0);
            }
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }

        //ddlNumEstadoPago.Attributes.Add("disabled", "true");
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

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        string strNumEstadoPago = "";
        
        lblError.Text = "";

        if (Request.Form["ddlNumEstadoPago"] == "(NUEVO)")
        {
            strNumEstadoPago = "0";
            lblError.Text = "Error al eliminar.";
            return;
        }
        else
            strNumEstadoPago = Request.Form["ddlNumEstadoPago"];

        arrNombreParametros = new string[] { "cod_con",
                                            "num_epago"
                                        };
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                strNumEstadoPago                                           
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_contratos_detalle_estado_pago", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos elimados correctamente.');\n");
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

    protected void cmdBuscaEstadoPago_Click(object sender, ImageClickEventArgs e)
    {
        FUNC_Busca_Estado_Pago();
    }
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("mn_ing_estado_pago_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }
    protected void cmdCargoPresup_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        string strCodCon = Request.Form["txtCodCon"];
        string strNumEPago = Request.Form["ddlNumEstadoPago"];
                
        string strFechaPago = Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaEstadoPago"]);

        string strContratoMatriz = Func_Libreria.FUNC_MontoSQL(Request.Form["lblCargoAPresupuesto"]);

        if (strNumEPago == "(NUEVO)")
        {
            lblError.Text = "Debe seleccionar un Estado Pago.";
        }
        else
        {
            Response.Redirect("mn_ing_cargo_presup_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo + "&cod_con=" + strCodCon + "&num_epago=" + strNumEPago + "&fecha_pago=" + strFechaPago + "&contrato_matriz=" + strContratoMatriz);
        }
        
    }
    protected void ddlNumEstadoPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        FUNC_Busca_Estado_Pago();
    }
}
