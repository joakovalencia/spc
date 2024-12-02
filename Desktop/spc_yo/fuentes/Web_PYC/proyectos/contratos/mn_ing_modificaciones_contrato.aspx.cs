///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012 
///Descripción: Pantalla modificacion contrato
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

public partial class mn_ing_modificaciones_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");
       
        txtMontoVigente.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        
        txtSMMMonto.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtSMMMonto.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtSMMMonto.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtSMMMonto.Attributes.Add("onpaste", "javascript:return false;");

        txtPlazoVigente.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtSMMNumDocto.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtResMNumdoc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtSMMMonto.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
        txtSMMPlazo.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
        txtSMM_M2.Attributes.Add("onkeypress", "javascript:return ValidNum2(event);");
        txtRMNumDoc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        

        lblError.Text = "";
       
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

            txtMontoVigente.Text = "0";
            txtPlazoVigente.Text = "0";
            txtSMMNumDocto.Text = "0";
            txtResMNumdoc.Text = "0";
            txtSMMMonto.Text = "0";
            txtSMMPlazo.Text = "0";
            txtSMM_M2.Text = "0";
            txtRMNumDoc.Text = "0";

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

            arrNombreParametros = new string[] { "tipo_grilla" };
            arrValoresParametros = new string[] { "mod_con" };

            SQL_Execute.FUNC_Ejecuta_SP("GetSetup_grilla", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {  

                while (SQL_Execute.oReader.Read())
                {
                    BoundField column = new BoundField();

                    HorizontalAlign alineacion_cabecera = new HorizontalAlign();
                    HorizontalAlign alineacion_detalle = new HorizontalAlign();

                    switch (SQL_Execute.oReader["alineacion_cabecera"].ToString().Trim())
                    {
                        case "izquerda":
                            alineacion_cabecera = HorizontalAlign.Left;
                            break;
                        case "derecha":
                            alineacion_cabecera = HorizontalAlign.Right;
                            break;
                        case "justificada":
                            alineacion_cabecera = HorizontalAlign.Justify;
                            break;
                        case "centro":
                            alineacion_cabecera = HorizontalAlign.Center;
                            break;
                        default:
                            alineacion_cabecera = HorizontalAlign.NotSet;
                            break;
                    }

                    switch (SQL_Execute.oReader["alineacion_detalle"].ToString().Trim())
                    {
                        case "izquerda":
                            alineacion_detalle = HorizontalAlign.Left;
                            break;
                        case "derecha":
                            alineacion_detalle = HorizontalAlign.Right;
                            break;
                        case "justificada":
                            alineacion_detalle = HorizontalAlign.Justify;
                            break;
                        case "centro":
                            alineacion_detalle = HorizontalAlign.Center;
                            break;
                        default:
                            alineacion_detalle = HorizontalAlign.NotSet;
                            break;
                    }

                    column.HeaderText = SQL_Execute.oReader["nombre_campo"].ToString().Trim();
                    column.DataField = SQL_Execute.oReader["codigo_campo"].ToString().Trim();
                    column.HeaderStyle.CssClass = SQL_Execute.oReader["css_class"].ToString().Trim();
                    column.ItemStyle.CssClass = SQL_Execute.oReader["css_class"].ToString().Trim();
                    column.HeaderStyle.HorizontalAlign = alineacion_cabecera;
                    column.ItemStyle.HorizontalAlign = alineacion_detalle;
                    column.DataFormatString = SQL_Execute.oReader["formato_detalle"].ToString().Trim();
                    //column.HeaderStyle.Width.Type =
                    column.HeaderStyle.Width = int.Parse(SQL_Execute.oReader["tamano"].ToString().Trim());
                    column.ItemStyle.Width = int.Parse(SQL_Execute.oReader["tamano"].ToString().Trim());

                    grdEdicion.Columns.Add(column);                   

                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            /********************************************************************/
            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_modificacion_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdEdicion.DataSource = SQL_Execute.oReader;
                grdEdicion.DataBind();

                lblCantRegistros.Text = "Registros encontrados: " + grdEdicion.Rows.Count.ToString();

            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            arrNombreParametros = new string[] { "cod_con" };
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_resumen_edita_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtFechaInicioLegal.Text = SQL_Execute.oReader["F_INL"].ToString();
                    txtMontoVigente.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MTO_VIG"].ToString(),0);
                    txtFechaTerminoLegal.Text = SQL_Execute.oReader["F_TL"].ToString();
                    txtPlazoVigente.Text = SQL_Execute.oReader["PLAZO_VIG"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_origenes_resolucion");

            if (SQL_Execute.numero_error == 0)
            {
                ddlResMOrigen.DataSource = SQL_Execute.oReader;
                ddlResMOrigen.DataTextField = "codigo_nombre";
                ddlResMOrigen.DataValueField = "CODIGO";
                ddlResMOrigen.DataBind();
                ddlResMOrigen.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_aumentos");

            if (SQL_Execute.numero_error == 0)
            {
                ddlResMTipo.DataSource = SQL_Execute.oReader;
                ddlResMTipo.DataTextField = "codigo_nombre";
                ddlResMTipo.DataValueField = "aumento";
                ddlResMTipo.DataBind();
                ddlResMTipo.Items.Insert(0, "(SELECCIONAR)");
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /********************************************************************/

            //ddlResMRenovo.Items.Insert(0, "(SELECCIONAR)");
            //ddlResMRenovo.Items.Add("Si");
            //ddlResMRenovo.Items.Add("No");
            
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

        string strURLPostGrabar = "mn_ing_modificaciones_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;
            
        arrNombreParametros = new string[] { "COD_CON" 
                                            ,"TIPO_MODIF_CTTO"
                                            ,"N_DOCTO_SOLICITUD_MOD"
                                            ,"F_SOLICITUD_MOD"
                                            ,"VAR_MTO"
                                            ,"VAR_PZO"
                                            ,"VAR_TAMAGNO"
                                            ,"N_DOCTO_RESP_SOLICITUD_MOD"
                                            ,"F_RESP_SOLICITUD_MOD"
                                            ,"OR_RES"
                                            ,"N_RES"
                                            ,"F_RES"
                                            ,"F_TRAMITE"
                                            ,"MOTIVO"
                                            ,"R_NUEVA_BOLETA" 
                                            ,"llave"    
                                            };

        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoMod"],"0"),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtSMMNumDocto"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtSMMFecha"]),
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtSMMMonto"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtSMMPlazo"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtSMM_M2"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtRMNumDoc"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRMFecha"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResMOrigen"],""),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtResMNumdoc"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtResMFecha"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtResMFechaTram"]),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResMTipo"],"0"),
                                                Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResMRenovo"],""),
                                                Request.Form["txtLlave"]
                                                };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_modificacion_contrato", arrNombreParametros, arrValoresParametros);
        
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
    
    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTipoMod.ClearSelection();
        ListItem olstTipoMod = ddlTipoMod.Items.FindByValue(grdEdicion.SelectedRow.Cells[1].Text);
        if (olstTipoMod != null) ddlTipoMod.SelectedValue = olstTipoMod.Value;

        txtSMMNumDocto.Text = grdEdicion.SelectedRow.Cells[2].Text.ToString();
        txtSMMFecha.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEdicion.SelectedRow.Cells[3].Text.ToString());
        txtSMMMonto.Text = grdEdicion.SelectedRow.Cells[4].Text.ToString();
        txtSMMPlazo.Text = grdEdicion.SelectedRow.Cells[5].Text.ToString();
        txtSMM_M2.Text = grdEdicion.SelectedRow.Cells[6].Text.ToString();
        txtRMNumDoc.Text = grdEdicion.SelectedRow.Cells[7].Text.ToString();
        txtRMFecha.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEdicion.SelectedRow.Cells[8].Text.ToString());
        
        ddlResMOrigen.ClearSelection();
        ListItem olstResMOrigen= ddlResMOrigen.Items.FindByValue(grdEdicion.SelectedRow.Cells[9].Text);
        if (olstResMOrigen!= null) ddlResMOrigen.SelectedValue = olstResMOrigen.Value;

        txtResMNumdoc.Text = grdEdicion.SelectedRow.Cells[10].Text.ToString();
        txtResMFecha.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEdicion.SelectedRow.Cells[11].Text.ToString());
        txtResMFechaTram.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEdicion.SelectedRow.Cells[12].Text.ToString());

        ddlResMRenovo.ClearSelection();
        ListItem olstResMRenovo = ddlResMRenovo.Items.FindByValue(grdEdicion.SelectedRow.Cells[14].Text);
        if (olstResMRenovo != null) ddlResMRenovo.SelectedValue = olstResMRenovo.Value;

        ddlResMTipo.ClearSelection();
        ListItem olstResMTipo = ddlResMTipo.Items.FindByValue(grdEdicion.SelectedRow.Cells[15].Text);
        if (olstResMTipo != null) ddlResMTipo.SelectedValue = olstResMTipo.Value;

        txtLlave.Value = grdEdicion.SelectedRow.Cells[16].Text;

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

        string strURLPostGrabar = "mn_ing_modificaciones_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "cod_con", "llave" };
        arrValoresParametros = new string[] { Request.Form["txtCodCon"], Request.Form["txtLlave"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_contratos_detalle_modificacion_contrato", arrNombreParametros, arrValoresParametros);

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
    
}
