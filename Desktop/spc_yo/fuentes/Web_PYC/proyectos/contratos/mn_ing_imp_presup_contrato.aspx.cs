///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla imputaciones presupuestarias
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

public partial class mn_ing_imp_presup_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtFecha.Attributes["onclick"] = "GetFecha(this, 1, null, null)";
        //txtAno.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtSUBT.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtIT.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtASIG.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtMontoImputado.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMontoImputado.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMontoImputado.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMontoImputado.Attributes.Add("onpaste", "javascript:return false;");        
                
        //txtAno.Text = "0";
        txtNumero.Text = "0";
        txtSUBT.Text = "0";
        txtIT.Text = "0";
        txtASIG.Text = "0";
        txtMontoImputado.Text = "0";

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

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_imputacion_presup", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdImputacion.DataSource = SQL_Execute.oReader;
                grdImputacion.DataBind();

                lblCantRegistros.Text = "Imputaciones Presupuestarias relacionadas al contrato: " + grdImputacion.Rows.Count.ToString();

            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
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

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_tipo_fondos");

            if (SQL_Execute.numero_error == 0)
            {
                ddlTipoFondo.DataSource = SQL_Execute.oReader;
                ddlTipoFondo.DataTextField = "codigo_nombre";
                ddlTipoFondo.DataValueField = "CODIGO";
                ddlTipoFondo.DataBind();                
                ddlTipoFondo.Items.Insert(0, "(SELECCIONAR)");
            }

            /********************************************************************/

            ddlAno.Items.Add("50");
            ddlAno.Items.Add("51");
            ddlAno.Items.Add("52");
            ddlAno.Items.Add("53");
            ddlAno.Items.Add("54");
            ddlAno.Items.Add("55");
            ddlAno.Items.Add("56");
            ddlAno.Items.Add("57");
            ddlAno.Items.Add("58");
            ddlAno.Items.Add("59");
            ddlAno.Items.Add("60");
            ddlAno.Items.Add("61");
            ddlAno.Items.Add("62");
            ddlAno.Items.Add("63");
            ddlAno.Items.Add("64");
            ddlAno.Items.Add("65");
            ddlAno.Items.Add("66");
            ddlAno.Items.Add("67");
            ddlAno.Items.Add("68");
            ddlAno.Items.Add("69");
            ddlAno.Items.Add("70");
            ddlAno.Items.Add("71");
            ddlAno.Items.Add("72");
            ddlAno.Items.Add("73");
            ddlAno.Items.Add("74");
            ddlAno.Items.Add("75");
            ddlAno.Items.Add("76");
            ddlAno.Items.Add("77");
            ddlAno.Items.Add("78");
            ddlAno.Items.Add("79");
            ddlAno.Items.Add("80");
            ddlAno.Items.Add("81");
            ddlAno.Items.Add("82");
            ddlAno.Items.Add("83");
            ddlAno.Items.Add("84");
            ddlAno.Items.Add("85");
            ddlAno.Items.Add("86");
            ddlAno.Items.Add("87");
            ddlAno.Items.Add("88");
            ddlAno.Items.Add("89");
            ddlAno.Items.Add("90");
            ddlAno.Items.Add("91");
            ddlAno.Items.Add("92");
            ddlAno.Items.Add("93");
            ddlAno.Items.Add("94");
            ddlAno.Items.Add("95");
            ddlAno.Items.Add("96");
            ddlAno.Items.Add("97");
            ddlAno.Items.Add("98");
            ddlAno.Items.Add("99");
            ddlAno.Items.Add("00");
            ddlAno.Items.Add("01");
            ddlAno.Items.Add("02");
            ddlAno.Items.Add("03");
            ddlAno.Items.Add("04");
            ddlAno.Items.Add("05");
            ddlAno.Items.Add("06");
            ddlAno.Items.Add("07");
            ddlAno.Items.Add("08");
            ddlAno.Items.Add("09");
            ddlAno.Items.Add("10");
            ddlAno.Items.Add("11");
            ddlAno.Items.Add("12");
            ddlAno.Items.Add("13");
            ddlAno.Items.Add("14");
            ddlAno.Items.Add("15");
            ddlAno.Items.Add("16");
            ddlAno.Items.Add("17");
            ddlAno.Items.Add("18");
            ddlAno.Items.Add("19");
            ddlAno.Items.Add("20");
            ddlAno.Items.Add("21");
            ddlAno.Items.Add("22");
            ddlAno.Items.Add("23");
            ddlAno.Items.Add("24");
            ddlAno.Items.Add("25");
            ddlAno.Items.Add("26");
            ddlAno.Items.Add("27");
            ddlAno.Items.Add("28");
            ddlAno.Items.Add("29");
            ddlAno.Items.Add("30");
            ddlAno.Items.Add("31");
            ddlAno.Items.Add("32");
            ddlAno.Items.Add("33");
            ddlAno.Items.Add("34");
            ddlAno.Items.Add("35");
            ddlAno.Items.Add("36");
            ddlAno.Items.Add("37");
            ddlAno.Items.Add("38");
            ddlAno.Items.Add("39");
            ddlAno.Items.Add("40");
            ddlAno.Items.Add("41");
            ddlAno.Items.Add("42");
            ddlAno.Items.Add("43");
            ddlAno.Items.Add("44");
            ddlAno.Items.Add("45");
            ddlAno.Items.Add("46");
            ddlAno.Items.Add("47");
            ddlAno.Items.Add("48");
            ddlAno.Items.Add("49");
            ddlAno.Items.Add("50");
            ddlAno.Items.Add("51");
            ddlAno.Items.Add("52");
            ddlAno.Items.Add("53");
            ddlAno.Items.Add("54");
            ddlAno.Items.Add("55");
            ddlAno.Items.Add("56");
            ddlAno.Items.Add("57");
            ddlAno.Items.Add("58");
            ddlAno.Items.Add("59");
            ddlAno.Items.Add("60");
            ddlAno.Items.Add("61");
            ddlAno.Items.Add("62");
            ddlAno.Items.Add("63");
            ddlAno.Items.Add("64");
            ddlAno.Items.Add("65");
            ddlAno.Items.Add("66");
            ddlAno.Items.Add("67");
            ddlAno.Items.Add("68");
            ddlAno.Items.Add("69");
            ddlAno.Items.Add("70");

            ddlAno.ClearSelection();
            ListItem olstAno = ddlAno.Items.FindByValue(DateTime.Today.ToString("yyyy").Substring(2,2));
            if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;

            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_origenes_resolucion");

            if (SQL_Execute.numero_error == 0)
            {
                ddlResOrig.DataSource = SQL_Execute.oReader;
                ddlResOrig.DataTextField = "codigo_nombre";
                ddlResOrig.DataValueField = "CODIGO";
                ddlResOrig.DataBind();
                ddlResOrig.Items.Insert(0, "(SELECCIONAR)");
            }

            
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

        /*
        Decimal  {0:D}
        Scientifico  {1:E}
        General  {0:G}
        Numerico {0:N}
        Percentaje  {1:P}
        Hexadecimal  {0:X}
        */

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
    
        string strMandante = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"], "");
        string strTipoFondo = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoFondo"], "");
        string strResOrigen = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResOrig"], "");        
        string strMontoImp = Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMontoImputado"]);
        string strFechaRes = Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFecha"]);
        string strLlave = Request.Form["txtLlave"];

        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo", "Ano", "Mandante", "TipoFondo", "ResOrig", "NumeroRes", "FechaRes", "SUBT", "IT", "ASIG", "MontoImputado", "Codigo_Contrato", "llave"};
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo, Request.Form["ddlAno"], strMandante, strTipoFondo, strResOrigen, Request.Form["txtNumero"], strFechaRes, Request.Form["txtSUBT"], Request.Form["txtIT"], Request.Form["txtASIG"], strMontoImp, Request.Form["txtCodCon"], strLlave };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_imputacion_presup", arrNombreParametros, arrValoresParametros);
        
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
        //txtAno.Text = grdImputacion.SelectedRow.Cells[1].Text;

        ddlAno.ClearSelection();
        ListItem olstAno = ddlAno.Items.FindByValue(grdImputacion.SelectedRow.Cells[1].Text);
        if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;

        ddlMandante.ClearSelection();
        ListItem olstMandante = ddlMandante.Items.FindByValue(grdImputacion.SelectedRow.Cells[2].Text);
        if (olstMandante != null) ddlMandante.SelectedValue = olstMandante.Value;        

        ddlTipoFondo.ClearSelection();
        ListItem olstTipoFondo = ddlTipoFondo.Items.FindByValue(grdImputacion.SelectedRow.Cells[3].Text);
        if (olstTipoFondo != null) ddlTipoFondo.SelectedValue = olstTipoFondo.Value;        

        ddlResOrig.ClearSelection();
        ListItem olstResOrig = ddlResOrig.Items.FindByValue(grdImputacion.SelectedRow.Cells[4].Text);
        if (olstResOrig != null) ddlResOrig.SelectedValue = olstResOrig.Value;        
        
        txtNumero.Text = grdImputacion.SelectedRow.Cells[5].Text;
        txtFecha.Text = grdImputacion.SelectedRow.Cells[6].Text;
        txtSUBT.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdImputacion.SelectedRow.Cells[7].Text);
        txtIT.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdImputacion.SelectedRow.Cells[8].Text);
        txtASIG.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdImputacion.SelectedRow.Cells[9].Text);

        txtMontoImputado.Text = grdImputacion.SelectedRow.Cells[10].Text.ToString();

        txtLlave.Value = grdImputacion.SelectedRow.Cells[11].Text.ToString();

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
        string strCdigoRegion = Page.Request.QueryString["codigo_region"]; //codigo de la region 
        string strSufijo = Page.Request.QueryString["sufijo"];

        string strURLPostGrabar = "../mn_edita_contratos_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        string strMandante = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"], "");
        string strTipoFondo = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoFondo"], "");
        string strResOrigen = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlResOrig"], "");
        string strMontoImp = Func_Libreria.FUNC_MontoSQL(Request.Form["txtMontoImputado"]);
        string strFechaRes = Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFecha"]);
        string strLlave = Request.Form["txtLlave"];

        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo", "llave" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo, strLlave };

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_contratos_detalle_imputacion_presup", arrNombreParametros, arrValoresParametros);

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
