﻿///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Pantalla de login de la aplicación web PYC
//-----------------------
///Modificado por: Erick Kleiner - GSI Asesorias
///Fecha: 17-10-2012
///Descripción: Pantalla de login de la aplicación web PYC
///</summary>
///
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//Ingreso Proyecto
//ETAPAS_PROY

public partial class mn_etapas_det_proy : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");

        txtMontoTotal.Attributes.Add("onkeypress", "javascript:return isNumberKey(this, event);");
        txtMontoTotal.Attributes.Add("onBlur", "javascript:mathRoundForTaxes(this.id,0);");
        txtMontoTotal.Attributes.Add("onfocus", "javascript:dropComa(this.id);");
        txtMontoTotal.Attributes.Add("onpaste", "javascript:return false;");

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        if (!IsPostBack)
        {
            /******************************************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

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
                    txtTipoProyecto.Text = SQL_Execute.oReader["tipo_proy"].ToString();
                    txtCodigoBIP.Text = SQL_Execute.oReader["codigo_bip"].ToString();
                    txtParte.Text = SQL_Execute.oReader["parte_bip"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            /******************************************************************************************/

            arrNombreParametros = new string[] { "typologia" };
            arrValoresParametros = new string[] { txtTipoProyecto.Text };
            
            SQL_Execute.FUNC_Ejecuta_SP("GetBuscaDomTiposEtapa", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlEtapa.DataSource = SQL_Execute.oReader;
                ddlEtapa.DataTextField = "DESCRIPCION";
                ddlEtapa.DataValueField = "TIPO_ETAPA";
                ddlEtapa.DataBind();
                ddlEtapa.Items.Insert(0, "(SELECCIONAR)");
            }

            /******************************************************************************************/

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };
                        
            SQL_Execute.FUNC_Ejecuta_SP("GetBuscaEtapa", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Etapas relacionados al proyecto: 0";

            if (SQL_Execute.numero_error == 0)
            {
                grdEtapas.DataSource = SQL_Execute.oReader;
                grdEtapas.DataBind();

                lblCantRegistros.Text = "Etapas relacionados al proyecto: " + grdEtapas.Rows.Count.ToString();
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
        }
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

        arrNombreParametros = new string[] { "region"
                                            , "codigo_da"

                                            , "etapa"
                                            , "codigo_bip"
                                            , "parte"

                                            , "monto_etapa"                                            
                                            , "descripcion"
                                            , "fecha_ingreso"
                                            };

        arrValoresParametros = new string[] { strCdigoRegion
                                            , strCdigoPIA
                                            
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEtapa"],"") 
                                            , Request.Form["txtCodigoBIP"] 
                                            , Request.Form["txtParte"] 

                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMontoTotal"])
                                            , Request.Form["txtDescripcion"] 
                                            , "0"
                                            };
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        SQL_Execute.FUNC_Ejecuta_SP("SetGrabaEtapa", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Grabados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("window.window.close();\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
    }

    protected void grdInspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEtapa.ClearSelection();
        ListItem olstEtapa = ddlEtapa.Items.FindByValue(grdEtapas.SelectedRow.Cells[1].Text);
        if (olstEtapa != null) ddlEtapa.SelectedValue = olstEtapa.Value;

        txtMontoTotal.Text = grdEtapas.SelectedRow.Cells[2].Text;
        txtCodigoBIP.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEtapas.SelectedRow.Cells[3].Text);
        txtParte.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEtapas.SelectedRow.Cells[4].Text);
        txtDescripcion.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdEtapas.SelectedRow.Cells[5].Text);
    }

    protected void cmdCerrar_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
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

        arrNombreParametros = new string[] { "region"
                                            , "codigo_da"

                                            , "etapa"
                                            , "codigo_bip"
                                            , "parte"

                                            , "monto_etapa"                                            
                                            , "descripcion"
                                            , "fecha_ingreso"
                                            };
        arrValoresParametros = new string[] { strCdigoRegion
                                            , strCdigoPIA
                                            
                                            , Request.Form["ddlEtapa"] 
                                            , Request.Form["txtCodigoBIP"] 
                                            , Request.Form["txtParte"] 

                                            , Request.Form["txtMontoTotal"] 
                                            , Request.Form["txtDescripcion"] 
                                            , "0"
                                            };
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        SQL_Execute.FUNC_Ejecuta_SP("SetEliminaEtapa", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Datos Eliminados Correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLPostGrabar + "'\n");
            HttpContext.Current.Response.Write("window.window.close();\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
    }
}
