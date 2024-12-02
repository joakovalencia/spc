///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012 
///Descripción: Pantalla ingreso inspector fiscal
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

//CONVENIO_MODIFIC

public partial class mn_convenios_mod_det_proy : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");
        
        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        /**********************************************************************/
        lblUsuario.Text = Session["ID_Usuario"].ToString();
        lblPerfil.Text = Session["ID_Desc_Tipo_Usuario"].ToString();
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");

        txtCorrelativo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");                
        txtNumeroRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

        txtMontoNeto.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMontoNeto.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMontoNeto.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMontoNeto.Attributes.Add("onpaste", "javascript:return false;");

        txtGastosAdmin.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtGastosAdmin.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtGastosAdmin.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtGastosAdmin.Attributes.Add("onpaste", "javascript:return false;");

        txtGastosConsultoria.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtGastosConsultoria.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtGastosConsultoria.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtGastosConsultoria.Attributes.Add("onpaste", "javascript:return false;");

        txtOtrosGastos.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtOtrosGastos.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtOtrosGastos.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtOtrosGastos.Attributes.Add("onpaste", "javascript:return false;");

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
        string strMandante = Page.Request.QueryString["mandante"];
        string strCorrelativo = Page.Request.QueryString["correlativo"];

        txtCorrelativo.Text = strCorrelativo;
        txtMandante.Text = strMandante;

        if (!IsPostBack)
        {

            txtMontoNeto.Text = "0";
            txtGastosAdmin.Text = "0";
            txtGastosConsultoria.Text = "0";
            txtOtrosGastos.Text = "0";

            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region"};
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyecto_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('Proyecto no encontrado.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    txtRegion.Text = SQL_Execute.oReader["region"].ToString();
                    txtObjeto.Text = SQL_Execute.oReader["objeto"].ToString();
                    txtPIA.Text = SQL_Execute.oReader["codigo_da"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["proceso"].ToString();                    
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }            
            /********************************************************************/
            
            arrNombreParametros = new string[] { "region", "codigo_da", "mandante" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA, strMandante };

            SQL_Execute.FUNC_Ejecuta_SP("GetBuscaConveniosModif", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Convenios relacionados al proyecto: 0";

            if (SQL_Execute.numero_error == 0)
            {
                grdConvenio.DataSource = SQL_Execute.oReader;
                grdConvenio.DataBind();

                lblCantRegistros.Text = "Convenios relacionados al proyecto: " + grdConvenio.Rows.Count.ToString();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }            

            /********************************************************************/
        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("mn_convenios_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {

        string strVUsuario = Session["ID_Usuario"].ToString();
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
        string strMandante = Page.Request.QueryString["mandante"];
        string strCorrelativo = Page.Request.QueryString["correlativo"];

        string strURLPostGrabar = "mn_convenios_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] { "region"
                                            , "codigo_da"
                                            , "mandante"

                                            , "fecha_decreto"
                                            , "correlativo" 
                                            , "num_decreto"
                                            , "fecha_convenio"
                                            , "fecha_ingreso"
                                            , "monto_neto_mod"
                                            , "gasto_adm_mod"
                                            , "consul_mod"
                                            , "otros_gastos_mod"
                                            };

        arrValoresParametros = new string[] { strCdigoPIA
                                            , strCdigoRegion
                                            , strMandante

                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaRes"])
                                            , strCorrelativo
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtNumeroRes"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaConvenio"])                                            
                                            , ""
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMontoNeto"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtGastosAdmin"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtGastosConsultoria"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtOtrosGastos"])
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_grabar_convenios_modif_proyecto", arrNombreParametros, arrValoresParametros);
        
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

        string strVUsuario = Session["ID_Usuario"].ToString();
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
        string strMandante = Page.Request.QueryString["mandante"];
        string strCorrelativo = Request.Form["txtCorrelativo"];

        string strURLPostGrabar = "mn_convenios_det_proy.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] { "region"
                                            , "codigo_da"
                                            , "mandante"
                                            , "correlativo"
                                            , "fecha_decreto"
                                            };

        arrValoresParametros = new string[] { strCdigoPIA
                                            , strCdigoRegion
                                            , strMandante
                                            , strCorrelativo
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaRes"])
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_eliminar_convenios_modif_proyecto", arrNombreParametros, arrValoresParametros);

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
    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCorrelativo.Text = grdConvenio.SelectedRow.Cells[1].Text;
        txtMandante.Text = grdConvenio.SelectedRow.Cells[2].Text;
        txtFechaConvenio.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdConvenio.SelectedRow.Cells[3].Text);
        txtNumeroRes.Text = grdConvenio.SelectedRow.Cells[4].Text;
        txtFechaRes.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdConvenio.SelectedRow.Cells[5].Text);
        txtMontoNeto.Text = grdConvenio.SelectedRow.Cells[6].Text;
        txtGastosAdmin.Text = grdConvenio.SelectedRow.Cells[7].Text;
        txtGastosConsultoria.Text = grdConvenio.SelectedRow.Cells[8].Text;
        txtOtrosGastos.Text = grdConvenio.SelectedRow.Cells[9].Text;
    }
}


/*
CORRELATIVO         - txtCorrelativo
MANDANTE            - ddlMandante
FECHA_CONVENIO      - txtFechaConvenio
NUM_DECRETO         - txtNumeroRes
FECHA_DECRETO       - txtFechaRes
MONTO_NETO_MOD      - txtMontoNeto
GASTO_ADM_MOD       - txtGastosAdmin
CONSUL_MOD          - txtGastosConsultoria


*/