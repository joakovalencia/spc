///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla ingreso avances fisicos
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

public partial class mn_ing_avances_fisicos_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {        
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

        txtParcial.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtParcial.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtParcial.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtParcial.Attributes.Add("onpaste", "javascript:return false;");

        txtAcumulado.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtAvancesFiscParcial.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAvancesFiscParcial.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtAvancesFiscParcial.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAvancesFiscParcial.Attributes.Add("onpaste", "javascript:return false;");

        txtCalificada.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtSemiCalificada.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        txtNoCalificada.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtAvancesFiscAct.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtAvancesFiscAct.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,2);");
        txtAvancesFiscAct.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtAvancesFiscAct.Attributes.Add("onpaste", "javascript:return false;");
        
        txtParcial.Text = "0,00";
        txtAcumulado.Text = "0";
        txtAvancesFiscParcial.Text = "0,00";
        txtCalificada.Text = "0";
        txtSemiCalificada.Text = "0";
        txtNoCalificada.Text = "0";
        txtAvancesFiscAct.Text = "0,00";

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

        txtFecha.Attributes["onclick"] = "GetFecha(this, 1, null, null)";

        if (!IsPostBack)
        {

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

            ddlAno.Items.Add("1950");
            ddlAno.Items.Add("1951");
            ddlAno.Items.Add("1952");
            ddlAno.Items.Add("1953");
            ddlAno.Items.Add("1954");
            ddlAno.Items.Add("1955");
            ddlAno.Items.Add("1956");
            ddlAno.Items.Add("1957");
            ddlAno.Items.Add("1958");
            ddlAno.Items.Add("1959");
            ddlAno.Items.Add("1960");
            ddlAno.Items.Add("1961");
            ddlAno.Items.Add("1962");
            ddlAno.Items.Add("1963");
            ddlAno.Items.Add("1964");
            ddlAno.Items.Add("1965");
            ddlAno.Items.Add("1966");
            ddlAno.Items.Add("1967");
            ddlAno.Items.Add("1968");
            ddlAno.Items.Add("1969");
            ddlAno.Items.Add("1970");
            ddlAno.Items.Add("1971");
            ddlAno.Items.Add("1972");
            ddlAno.Items.Add("1973");
            ddlAno.Items.Add("1974");
            ddlAno.Items.Add("1975");
            ddlAno.Items.Add("1976");
            ddlAno.Items.Add("1977");
            ddlAno.Items.Add("1978");
            ddlAno.Items.Add("1979");
            ddlAno.Items.Add("1980");
            ddlAno.Items.Add("1981");
            ddlAno.Items.Add("1982");
            ddlAno.Items.Add("1983");
            ddlAno.Items.Add("1984");
            ddlAno.Items.Add("1985");
            ddlAno.Items.Add("1986");
            ddlAno.Items.Add("1987");
            ddlAno.Items.Add("1988");
            ddlAno.Items.Add("1989");
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
            ddlAno.Items.Add("2046");
            ddlAno.Items.Add("2047");
            ddlAno.Items.Add("2048");
            ddlAno.Items.Add("2049");
            ddlAno.Items.Add("2050");
            ddlAno.Items.Add("2051");
            ddlAno.Items.Add("2052");
            ddlAno.Items.Add("2053");
            ddlAno.Items.Add("2054");
            ddlAno.Items.Add("2055");
            ddlAno.Items.Add("2056");
            ddlAno.Items.Add("2057");
            ddlAno.Items.Add("2058");
            ddlAno.Items.Add("2059");
            ddlAno.Items.Add("2060");
            ddlAno.Items.Add("2061");
            ddlAno.Items.Add("2062");
            ddlAno.Items.Add("2063");
            ddlAno.Items.Add("2064");
            ddlAno.Items.Add("2065");
            ddlAno.Items.Add("2066");
            ddlAno.Items.Add("2067");
            ddlAno.Items.Add("2068");
            ddlAno.Items.Add("2069");
            ddlAno.Items.Add("2070");

            ddlAno.ClearSelection();
            ListItem olstAno = ddlAno.Items.FindByValue(DateTime.Today.ToString("yyyy"));
            if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;

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

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_avance_fisico", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                grdAvanceFisico.DataSource = SQL_Execute.oReader;
                grdAvanceFisico.DataBind();

                lblCantRegistros.Text = "Registro de avances físicos relacionadas al contrato: " + grdAvanceFisico.Rows.Count.ToString();

            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { txtCodCon.Text };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_avance_fisico_suma", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    lblTot.Text = SQL_Execute.oReader["tot_totales"].ToString();
                    lblSxP.Text = SQL_Execute.oReader["tot_saldo_x_program"].ToString();
                    lblAFe.Text = SQL_Execute.oReader["tot_avance_a_fecha"].ToString();
                    lblARe.Text = SQL_Execute.oReader["tot_avance_restante"].ToString();
                    lblMC.Text = SQL_Execute.oReader["tot_MANO_DE_OBRA_CALIFICADA"].ToString();
                    lblMNC.Text = SQL_Execute.oReader["tot_MANO_DE_OBRA_NO_CALIFICADA"].ToString();
                    lblMOSC.Text = SQL_Execute.oReader["tot_MANO_DE_OBRA_SEMI_CALIFICADA"].ToString();
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

        string strURLPostGrabar = "mn_ing_avances_fisicos_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        /************************************************************************************************/
        arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
        arrValoresParametros = new string[] {strCdigoPIA, strCdigoRegion, strSufijo };

        SQL_Execute.FUNC_Ejecuta_SP("Set_actualiza_fecha_contrato", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error != 0) lblError.Text = SQL_Execute.desc_error;
        /************************************************************************************************/

        arrNombreParametros = new string[] {    "COD_CON" 
                                            ,	"AGNO"
                                            ,	"MES"
                                            ,	"AV_FIS_PR"
                                            ,	"AV_FIS_ACUM"
                                            ,	"FECHA_MEDICION"
                                            ,	"AV_FIS_RE"
                                            ,	"MANO_DE_OBRA_CALIFICADA"
                                            ,	"MANO_DE_OBRA_SEMI_CALIFICADA"
                                            ,	"MANO_DE_OBRA_NO_CALIFICADA"
                                            ,	"OBSERV"
                                            ,	"llave" 
                                            ,   "AV_FIS_ACT"
                                            };

        arrValoresParametros = new string[] {   Request.Form["txtCodCon"],             
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["ddlAno"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["ddlMes"]),
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtParcial"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtAcumulado"]),
                                                Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFecha"]),
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtAvancesFiscParcial"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtCalificada"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtSemiCalificada"]),
                                                Func_Libreria.FUNC_MontoSQL(Request.Form["txtNoCalificada"]),
                                                Request.Form["txtObs"],
                                                Request.Form["txtLlave"],
                                                Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtAvancesFiscAct"]).Replace(",",".")
                                             };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_avance_fisico", arrNombreParametros, arrValoresParametros);
        
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
        ddlAno.ClearSelection();
        ListItem olstAno = ddlAno.Items.FindByValue(grdAvanceFisico.SelectedRow.Cells[1].Text);
        if (olstAno != null) ddlAno.SelectedValue = olstAno.Value;

        ddlMes.ClearSelection();
        ListItem olstMes = ddlMes.Items.FindByValue(grdAvanceFisico.SelectedRow.Cells[2].Text);
        if (olstMes != null) ddlMes.SelectedValue = olstMes.Value;

        txtParcial.Text = Func_Libreria.FUNC_MontoASPv2(grdAvanceFisico.SelectedRow.Cells[3].Text,2);
        txtAcumulado.Text = grdAvanceFisico.SelectedRow.Cells[4].Text;

        txtAvancesFiscAct.Text = Func_Libreria.FUNC_MontoASPv2(grdAvanceFisico.SelectedRow.Cells[5].Text,2);

        txtFecha.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdAvanceFisico.SelectedRow.Cells[6].Text);
        
        txtAvancesFiscParcial.Text = Func_Libreria.FUNC_MontoASPv2(grdAvanceFisico.SelectedRow.Cells[7].Text,2);

        txtCalificada.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdAvanceFisico.SelectedRow.Cells[8].Text);
        txtSemiCalificada.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdAvanceFisico.SelectedRow.Cells[9].Text);
        txtNoCalificada.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdAvanceFisico.SelectedRow.Cells[10].Text);
        txtObs.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdAvanceFisico.SelectedRow.Cells[11].Text);

        txtLlave.Value = grdAvanceFisico.SelectedRow.Cells[12].Text.ToString();
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

        string strURLPostGrabar = "mn_ing_avances_fisicos_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&sufijo=" + strSufijo;

        arrNombreParametros = new string[] { "cod_con", "llave" };
        arrValoresParametros = new string[] { Request.Form["txtCodCon"], Request.Form["txtLlave"] };

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_contratos_detalle_avance_fisico", arrNombreParametros, arrValoresParametros);

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
