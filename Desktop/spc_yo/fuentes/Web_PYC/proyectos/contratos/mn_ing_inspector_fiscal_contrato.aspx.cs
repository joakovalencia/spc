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

public partial class mn_ing_inspector_fiscal_contrato : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_edita_contratos_contratos.aspx");

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
                
        txtNumeroRes.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

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

            if (txtCodCon.Text.Trim() != "")
            {
                arrNombreParametros = new string[] { "cod_con" };
                arrValoresParametros = new string[] { txtCodCon.Text };

                SQL_Execute.FUNC_Ejecuta_SP("GetBusca_contratos_detalle_inspector_fiscal", arrNombreParametros, arrValoresParametros);

                if (SQL_Execute.numero_error == 0)
                {
                    grdInspector.DataSource = SQL_Execute.oReader;
                    grdInspector.DataBind();

                    lblCantRegistros.Text = "Inspectores relacionados al contrato: " + grdInspector.Rows.Count.ToString();
                }
                else
                {
                    lblError.Text = SQL_Execute.desc_error;
                }

                
            }
            /********************************************************************/
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRut.DataSource = SQL_Execute.oReader;

                ddlRut.DataTextField = "rut_nombre_prof";
                ddlRut.DataValueField = "rut";
                
                ddlRut.DataBind();
                ddlRut.Items.Insert(0, "(SELECCIONAR)");
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
    
        string strTitular = Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTitular"], "");

        arrNombreParametros = new string[] { "cod_con"
                                            , "rut"
                                            , "n_res"
                                            , "f_resol"
                                            , "titularsn" 
                                            };
        arrValoresParametros = new string[] { Request.Form["txtCodCon"]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlRut"],"")
                                            , Func_Libreria.FUNC_EnteroSQL(Request.Form["txtNumeroRes"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaRes"])
                                            , strTitular 
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("SetGraba_contratos_detalle_inspector_fiscal", arrNombreParametros, arrValoresParametros);
        
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
    protected void ddlRut_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;
        
        string strRut = Request.Form["ddlRut"];

        arrNombreParametros = new string[] { "rut"};
        arrValoresParametros = new string[] { strRut };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_dom_insp_fis", arrNombreParametros, arrValoresParametros);
        
        if (SQL_Execute.numero_error == 0)
        {        
            while (SQL_Execute.oReader.Read())
            {
                txtNombre.Text = SQL_Execute.oReader["nombre"].ToString();
                txtProfesion.Text = SQL_Execute.oReader["profesion"].ToString();
                txtNumeroRes.Text = "";
                txtFechaRes.Text = "";
                ddlTitular.ClearSelection();
                ddlTitular.Items.FindByValue("(SELECCIONAR)").Selected = true;
            }
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }

        
    }
    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRut.ClearSelection();
        ListItem olstRut = ddlRut.Items.FindByValue(grdInspector.SelectedRow.Cells[1].Text);
        if (olstRut != null) ddlRut.SelectedValue = olstRut.Value;

        txtNombre.Text = grdInspector.SelectedRow.Cells[2].Text;
        txtProfesion.Text = grdInspector.SelectedRow.Cells[3].Text;
        txtNumeroRes.Text = grdInspector.SelectedRow.Cells[4].Text;
        txtFechaRes.Text = grdInspector.SelectedRow.Cells[5].Text;

        ddlTitular.ClearSelection();
        ListItem olstTitular = ddlTitular.Items.FindByValue(grdInspector.SelectedRow.Cells[6].Text);
        if (olstTitular != null) ddlTitular.SelectedValue = olstTitular.Value;
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

        arrNombreParametros = new string[] { "cod_con", "rut" };
        arrValoresParametros = new string[] { Request.Form["txtCodCon"], Request.Form["ddlRut"]};

        SQL_Execute.FUNC_Ejecuta_SP("SetElimina_contratos_detalle_inspector_fiscal", arrNombreParametros, arrValoresParametros);

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
