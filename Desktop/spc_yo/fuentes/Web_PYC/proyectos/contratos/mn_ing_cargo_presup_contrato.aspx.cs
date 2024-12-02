///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso estado pago - cargo presupuestario
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

public partial class mn_ing_cargo_presup_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtMonto.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMonto.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMonto.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMonto.Attributes.Add("onpaste", "javascript:return false;");        

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

        string strCodCon = Page.Request.QueryString["cod_con"];
        string strNumEPago = Page.Request.QueryString["num_epago"];
                
        string strFechaPago = Page.Request.QueryString["fecha_pago"];

        string strMes = strFechaPago.Substring(4, 2);
        string strAno = strFechaPago.Substring(2, 2);

        string strContratoMatriz = Func_Libreria.FUNC_MontoSQL( Page.Request.QueryString["contrato_matriz"] );

        if (!IsPostBack)
        {
            txtMonto.Text = "0";

            txtEP.Text = strNumEPago;
            txtAno.Text = strAno;
            txtMes.Text = strMes;
            txtFechaEstadoPago.Value = strFechaPago;
            txtMonto.Text = Func_Libreria.FUNC_MontoASPv2(strContratoMatriz, 0);

            /*************************************************************************/

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

            arrNombreParametros = new string[] { "cod_con", "num_epago" };
            arrValoresParametros = new string[] { strCodCon, strNumEPago };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdUno.DataSource = SQL_Execute.oReader;
                grdUno.DataBind();


            }
            else
            {

              
              lblError.Text = SQL_Execute.desc_error;

           
            }

            
            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { strCodCon };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_mandantes_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlMandante.DataSource = SQL_Execute.oReader;

                ddlMandante.DataTextField = "MANDANTE";
                ddlMandante.DataValueField = "MANDANTE";

                ddlMandante.DataBind();
                ddlMandante.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /*************************************************************************/

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { strCodCon };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_fondos_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlFondo.DataSource = SQL_Execute.oReader;

                ddlFondo.DataTextField = "T_F1";
                ddlFondo.DataValueField = "T_F1";

                ddlFondo.DataBind();
                ddlFondo.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /**********************************************************************/

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { strCodCon };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_item_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlItem.DataSource = SQL_Execute.oReader;

                ddlItem.DataTextField = "IT";
                ddlItem.DataValueField = "IT";

                ddlItem.DataBind();
                ddlItem.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /**********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_subt_cargo_presupuesto");

            if (SQL_Execute.numero_error == 0)
            {
                ddlSUBT.DataSource = SQL_Execute.oReader;

                ddlSUBT.DataTextField = "glosa";
                ddlSUBT.DataValueField = "codigo";

                ddlSUBT.DataBind();
                ddlSUBT.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /**********************************************************************/

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { strCodCon };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_item_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlItem.DataSource = SQL_Execute.oReader;

                ddlItem.DataTextField = "IT";
                ddlItem.DataValueField = "IT";

                ddlItem.DataBind();
                ddlItem.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /**********************************************************************/

            arrNombreParametros = new string[] { "cod_con" };
            arrValoresParametros = new string[] { strCodCon };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_asig_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlAsig.DataSource = SQL_Execute.oReader;

                ddlAsig.DataTextField = "ASIG";
                ddlAsig.DataValueField = "ASIG";

                ddlAsig.DataBind();
                ddlAsig.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /**********************************************************************/

        }
        
    }
       

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("mn_ing_estado_pago_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
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
        string strCodCon = Page.Request.QueryString["cod_con"];

        string strNumEPago = Page.Request.QueryString["num_epago"];

        string strFechaPago = Page.Request.QueryString["fecha_pago"];

        string strURLPostGrabar = "mn_ing_cargo_presup_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo + "&cod_con=" + strCodCon + "&num_epago=" + strNumEPago + "&fecha_pago=" + strFechaPago;

        /************************************************************************************************/
        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

        SQL_Execute.FUNC_Ejecuta_SP("Set_actualiza_fecha_contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error != 0) lblError.Text = SQL_Execute.desc_error;
        /************************************************************************************************/

        arrNombreParametros = new string[] { "cod_con"
                                            ,"num_epago"
                                            ,"fecha_epago"
                                            ,"mandante"
                                            ,"t_f1"
                                            ,"agno"
                                            ,"subt"
                                            ,"item"
                                            ,"asig"
                                            ,"mes_cargo"
                                            ,"monto"
                                            };
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                Request.Form["txtEP"],
                                                Request.Form["txtFechaEstadoPago"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFondo"],"0"),
                                                Request.Form["txtAno"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSUBT"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlItem"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlAsig"],"0"),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtMes"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtMonto"])
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_graba_cargo_presupuesto", arrNombreParametros, arrValoresParametros);
        
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
        string strCodCon = Page.Request.QueryString["cod_con"];

        string strNumEPago = Page.Request.QueryString["num_epago"];

        string strFechaPago = Page.Request.QueryString["fecha_pago"];

        string strURLPostGrabar = "mn_ing_cargo_presup_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo + "&cod_con=" + strCodCon + "&num_epago=" + strNumEPago + "&fecha_pago=" + strFechaPago;
        
        lblError.Text = "";

        arrNombreParametros = new string[] { "cod_con"
                                            ,"num_epago"
                                            ,"mandante"
                                            ,"t_f1"
                                            ,"agno"
                                            ,"subt"
                                            ,"item"
                                            ,"asig"
                                            ,"mes_cargo"
                                            };
        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                Request.Form["txtEP"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFondo"],"0"),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtAno"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSUBT"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlItem"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlAsig"],"0"),
                                                Func_Libreria.FUNC_EnteroSQL(Request.Form["txtMes"]),
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_elimina_cargo_presupuesto", arrNombreParametros, arrValoresParametros);

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
        
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        string strCodCon = Page.Request.QueryString["cod_con"];

        string strNumEPago = Page.Request.QueryString["num_epago"];
                
        string strFechaPago = Page.Request.QueryString["fecha_pago"];

        Response.Redirect("mn_ing_cargo_presup_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo + "&cod_con=" + strCodCon + "&num_epago=" + strNumEPago + "&fecha_pago=" + strFechaPago);
    }


    protected void grdUno_SelectedIndexChanged(object sender, EventArgs e)
    {                
        //txtEP.Text = grdUno.SelectedRow.Cells[1].Text;
        //txtAno.Text = grdUno.SelectedRow.Cells[2].Text;

        ddlMandante.ClearSelection();
        ListItem olstMandante = ddlMandante.Items.FindByValue(grdUno.SelectedRow.Cells[3].Text);
        if (olstMandante != null) ddlMandante.SelectedValue = olstMandante.Value;
                
        ddlFondo.ClearSelection();
        ListItem olstFondo = ddlFondo.Items.FindByValue(grdUno.SelectedRow.Cells[4].Text);
        if (olstFondo != null) ddlFondo.SelectedValue = olstFondo.Value;

        txtMes.Text = grdUno.SelectedRow.Cells[5].Text;
                
        ddlSUBT.ClearSelection();
        ListItem olstSUBT = ddlSUBT.Items.FindByValue(grdUno.SelectedRow.Cells[6].Text);
        if (olstSUBT != null) ddlSUBT.SelectedValue = olstSUBT.Value;

        ddlItem.ClearSelection();
        ListItem olstItem = ddlItem.Items.FindByValue(grdUno.SelectedRow.Cells[7].Text);
        if (olstItem != null) ddlItem.SelectedValue = olstItem.Value;
                
        ddlAsig.ClearSelection();
        ListItem olstAsig = ddlAsig.Items.FindByValue(grdUno.SelectedRow.Cells[8].Text);
        if (olstAsig != null) ddlAsig.SelectedValue = olstAsig.Value;

        txtMonto.Text = grdUno.SelectedRow.Cells[9].Text;
        
    }   
}
