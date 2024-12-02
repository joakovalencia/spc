using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mn_ing_programacion_tentativa_propuesta : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        lblError.Text = "";

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtPorc.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtPorc.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtPorc.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtPorc.Attributes.Add("onpaste", "javascript:return false;");

        txtMOC.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMOC.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMOC.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMOC.Attributes.Add("onpaste", "javascript:return false;");

        txtMOSC.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMOSC.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMOSC.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMOSC.Attributes.Add("onpaste", "javascript:return false;");

        txtMONC.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMONC.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMONC.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMONC.Attributes.Add("onpaste", "javascript:return false;");


        /**********************************************************************/
        lblUsuario.Text = Session["ID_Usuario"].ToString();
        lblPerfil.Text = Session["ID_Desc_Tipo_Usuario"].ToString();
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");

        arrNombreParametros = new string[] { "usuario" };
        arrValoresParametros = new string[] { lblUsuario.Text };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Datos_Usuario", arrNombreParametros, arrValoresParametros);

        txtMontoVigente.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMontoVigente.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMontoVigente.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMontoVigente.Attributes.Add("onpaste", "javascript:return false;");

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                lblCorreo.Text = "(" + SQL_Execute.oReader["correo_electronico"].ToString() + ")";
            }
        }

        /**********************************************************************/

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        if (!IsPostBack)
        {

            /**********************************************************************/

            ddlMes.Items.Add("1");
            ddlMes.Items.Add("2");
            ddlMes.Items.Add("3");
            ddlMes.Items.Add("4");
            ddlMes.Items.Add("5");
            ddlMes.Items.Add("6");
            ddlMes.Items.Add("7");
            ddlMes.Items.Add("8");
            ddlMes.Items.Add("9");
            ddlMes.Items.Add("10");
            ddlMes.Items.Add("11");
            ddlMes.Items.Add("12");

            ddlAno.Items.Add("1990");
            ddlAno.Items.Add("1991");
            ddlAno.Items.Add("1992");
            ddlAno.Items.Add("1993");
            ddlAno.Items.Add("1994");
            ddlAno.Items.Add("1995");
            ddlAno.Items.Add("1996");
            ddlAno.Items.Add("1997");
            ddlAno.Items.Add("1998");
            ddlAno.Items.Add("1999");
            ddlAno.Items.Add("2000");
            ddlAno.Items.Add("2001");
            ddlAno.Items.Add("2002");
            ddlAno.Items.Add("2003");
            ddlAno.Items.Add("2004");
            ddlAno.Items.Add("2005");
            ddlAno.Items.Add("2006");
            ddlAno.Items.Add("2007");
            ddlAno.Items.Add("2008");
            ddlAno.Items.Add("2009");
            ddlAno.Items.Add("2010");
            ddlAno.Items.Add("2011");
            ddlAno.Items.Add("2012");
            ddlAno.Items.Add("2013");
            ddlAno.Items.Add("2014");
            ddlAno.Items.Add("2015");
            ddlAno.Items.Add("2016");
            ddlAno.Items.Add("2017");
            ddlAno.Items.Add("2018");
            ddlAno.Items.Add("2019");
            ddlAno.Items.Add("2020");
            ddlAno.Items.Add("2021");
            ddlAno.Items.Add("2022");
            ddlAno.Items.Add("2023");
            ddlAno.Items.Add("2024");
            ddlAno.Items.Add("2025");
            ddlAno.Items.Add("2026");
            ddlAno.Items.Add("2027");
            ddlAno.Items.Add("2028");
            ddlAno.Items.Add("2029");
            ddlAno.Items.Add("2030");
            ddlAno.Items.Add("2031");
            ddlAno.Items.Add("2032");
            ddlAno.Items.Add("2033");
            ddlAno.Items.Add("2034");
            ddlAno.Items.Add("2035");
            ddlAno.Items.Add("2036");
            ddlAno.Items.Add("2037");
            ddlAno.Items.Add("2038");
            ddlAno.Items.Add("2039");
            ddlAno.Items.Add("2040");
            ddlAno.Items.Add("2041");
            ddlAno.Items.Add("2042");
            ddlAno.Items.Add("2043");
            ddlAno.Items.Add("2044");
            ddlAno.Items.Add("2045");
            
            ddlAno.ClearSelection();
            ListItem olstAno = ddlAno.Items.FindByValue(DateTime.Today.ToString("yyyy"));
            if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;


            /**********************************************************************/

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

            arrNombreParametros = new string[] { "cod_con" };
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_resumen_edita_contrato", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtMontoVigente.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["MONTO_PROGRA"].ToString(), 0);
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }


            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_programacion_tentativa_propuesta_financ", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdPrograma.DataSource = SQL_Execute.oReader;
                grdPrograma.DataBind();

                lblCantRegistros.Text = "Registros relacionados al contrato: " + grdPrograma.Rows.Count.ToString();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_correlativo_fondo_relacionados_edita");
            if (SQL_Execute.numero_error == 0)
            {
                ddlFondo.DataSource = SQL_Execute.oReader;
                ddlFondo.DataTextField = "DESC_FONDO";
                ddlFondo.DataValueField = "CODIGO_FONDO";
                ddlFondo.DataBind();
                ddlFondo.Items.Insert(0, "(SELECCIONAR)");
            }

            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_programacion_tentativa_propuesta_financ_suma", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    txtTotalesPorc.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["sum_MONTO_PROG"].ToString(), 2);
                    txtTotales.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["sum_MTOPESOS"].ToString(), 0);

                    txtSaldoXProgramarPorc.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["sum_saldo_MONTO_PROG"].ToString(), 2);
                    txtSaldoXProgramar.Text = Func_Libreria.FUNC_MontoASPv2(SQL_Execute.oReader["sum_saldo_MTOPESOS"].ToString(), 0);

                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

        }


    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];

        Response.Redirect("../mn_edita_contratos_propuesta_a.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo);
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text;
        string strVRegion = Request.Form["txtRegion"];
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

        string strURLPostGrabar = "mn_ing_programacion_tentativa_propuesta.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        string strMontoVigente = Func_Libreria.FUNC_MontoSQL(Request.Form["txtMontoVigente"]);
        string strProg = Request.Form["txtPorc"];

        string strMOC  = Func_Libreria.FUNC_MontoSQL(Request.Form["txtMOC"]);
        string strMOSC = Func_Libreria.FUNC_MontoSQL(Request.Form["txtMOSC"]);
        string strMONC = Func_Libreria.FUNC_MontoSQL(Request.Form["txtMONC"]);
        string strFINANCIAMIENTO = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlFondo"], "");

  
        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo", "AGNO", "MES", "MONTO_PROP", "MONTO_VIG", "MO_CALIFICADA", "MO_SEMI_CALIFICADA","MO_NO_CALIFICADA","FONDO" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo, Request.Form["ddlAno"], Request.Form["ddlMes"], strProg, strMontoVigente, strMOC, strMOSC, strMONC, strFINANCIAMIENTO };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_programacion_tentativa_propuesta_financ", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos guardados correctamente.');\n");
            //HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            //HttpContext.Current.Response.End();

            Response.Redirect(strURLPostGrabar);            

        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }


    }

    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAno.ClearSelection();
        ListItem olstAno = ddlAno.Items.FindByValue(grdPrograma.SelectedRow.Cells[2].Text);
        if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;

        ddlMes.ClearSelection();
        ListItem olstMes = ddlMes.Items.FindByValue(grdPrograma.SelectedRow.Cells[3].Text);
        if (olstMes != null) ddlMes.SelectedValue = olstMes.Value;

        txtPorc.Text = Func_Libreria.FUNC_MontoASPv2(grdPrograma.SelectedRow.Cells[4].Text, 2);
        txtMOC.Text = Func_Libreria.FUNC_MontoSQL(grdPrograma.SelectedRow.Cells[8].Text);
        txtMOSC.Text = Func_Libreria.FUNC_MontoSQL(grdPrograma.SelectedRow.Cells[9].Text);
        txtMONC.Text = Func_Libreria.FUNC_MontoSQL(grdPrograma.SelectedRow.Cells[10].Text);

        ddlFondo.ClearSelection();
        ListItem olstTipoFondo = ddlFondo.Items.FindByValue(grdPrograma.SelectedRow.Cells[1].Text);
        if (olstTipoFondo != null) ddlFondo.SelectedValue = olstTipoFondo.Value;     


    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text;
        string strVRegion = Request.Form["txtRegion"];
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

        string strURLPostGrabar = "mn_ing_programacion_tentativa_propuesta.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo", "AGNO", "MES", "MONTO_VIG" };
        arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo, Request.Form["ddlAno"], Request.Form["ddlMes"], Request.Form["txtMontoVigente"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetEliminar_programacion_tentativa_propuesta_financ", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Eliminados correctamente.');\n");
            //HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            //HttpContext.Current.Response.End();
            Response.Redirect(strURLPostGrabar);
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
            return;
        }

    }

}