///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla busqueda proyectos
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

public partial class mn_busqueda_proyectos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("/mn_busqueda_proyectos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        txtBusquedaDirecta.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

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

        if (!IsPostBack)
        {            
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_regiones");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegDesde.DataSource = SQL_Execute.oReader;
                ddlRegDesde.DataTextField = "nombre_region";
                ddlRegDesde.DataValueField = "REG_ORDEN_LISTADO";
                ddlRegDesde.DataBind();                
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_regiones");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegHasta.DataSource = SQL_Execute.oReader;
                ddlRegHasta.DataTextField = "nombre_region";
                ddlRegHasta.DataValueField = "REG_ORDEN_LISTADO";
                ddlRegHasta.DataBind();
                //ddlRegHasta.SelectedIndex = int.Parse(ddlRegHasta.Items.Count.ToString()) - 1;
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_pry_estadoproys_list");

            if (SQL_Execute.numero_error == 0)
            {
                ddlEstDesde.DataSource = SQL_Execute.oReader;
                ddlEstDesde.DataTextField = "descripcion";
                ddlEstDesde.DataValueField = "correl";
                ddlEstDesde.DataBind();
                ddlEstDesde.SelectedIndex = 0;
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            /********************************************************************/
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_pry_estadoproys_list");

            if (SQL_Execute.numero_error == 0)
            {
                ddlEstHasta.DataSource = SQL_Execute.oReader;
                ddlEstHasta.DataTextField = "descripcion";
                ddlEstHasta.DataValueField = "correl";
                ddlEstHasta.DataBind();
                ddlEstHasta.SelectedIndex = 0;
                ddlEstHasta.SelectedIndex = int.Parse(ddlEstHasta.Items.Count.ToString()) - 1;
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            _loadddlProceso();

            object objSessionX = HttpContext.Current.Session["SS_tipo_proyecto"];

            if (objSessionX != null)
            {
                if (Session["SS_tipo_proyecto"].ToString() == "EB") this.rdEstudios.Checked = true;
                if (Session["SS_tipo_proyecto"].ToString() == "PRY") this.rdProyectos.Checked = true;
                if (Session["SS_tipo_proyecto"].ToString() == "PRG") this.rdProgramas.Checked = true;
                if (Session["SS_tipo_proyecto"].ToString() == "ATE") this.rdConvenioscol.Checked = true;
                if (Session["SS_tipo_proyecto"].ToString() == "BD") this.rdBusquedaDirecta.Checked = true;
                
                _loadddlProceso();

                ddlRegDesde.ClearSelection();
                ddlRegHasta.ClearSelection();
                ddlEstDesde.ClearSelection();
                ddlEstHasta.ClearSelection();
                ddlProDesde.ClearSelection();
                ddlProHasta.ClearSelection();

                ddlRegDesde.Items.FindByValue(Session["SS_region_inicio"].ToString()).Selected = true;
                ddlRegHasta.Items.FindByValue(Session["SS_region_fin"].ToString()).Selected = true;
                ddlEstDesde.Items.FindByValue(Session["SS_estado_inicio"].ToString()).Selected = true;
                ddlEstHasta.Items.FindByValue(Session["SS_estado_fin"].ToString()).Selected = true;

                ddlProDesde.ClearSelection();
                ListItem olstProDesde = ddlProDesde.Items.FindByValue(Session["SS_proceso_inicio"].ToString());
                if (olstProDesde != null) ddlProDesde.SelectedValue = olstProDesde.Value;

                ddlProHasta.ClearSelection();
                ListItem olstProHasta = ddlProHasta.Items.FindByValue(Session["SS_proceso_fin"].ToString());
                if (olstProHasta != null) ddlProHasta.SelectedValue = olstProHasta.Value;

                txtBusquedaDirecta.Text = Session["SS_con_proy"].ToString();

                if (Session["SS_bd_con_proy"].ToString() == "C")
                    rdContrato.Checked = true;
                else
                    rdProyecto.Checked = true;               


                FUNC_Busca_Proyectos();
            }
                        
        }
    }

    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        Session.Remove("SS_tipo_proyecto");
        Session.Remove("SS_region_inicio");
        Session.Remove("SS_region_fin");
        Session.Remove("SS_estado_inicio");
        Session.Remove("SS_estado_fin");
        Session.Remove("SS_proceso_inicio");
        Session.Remove("SS_proceso_fin");

        Response.Redirect("mn_busqueda_proyectos.aspx");
    }
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal_pyc.aspx");
    }
    protected void cmdExportarExcel_Click(object sender, ImageClickEventArgs e)
    {
        string attachment = "attachment; filename=busqueda_proyectos_" + Session["ID_Usuario"].ToString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdProyectos.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void cmdAgregar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mn_ing_proyectos.aspx");
    }

    protected void cmdBuscar_Click(object sender, ImageClickEventArgs e)
    {
        FUNC_Busca_Proyectos();
    }

    private void FUNC_Busca_Proyectos()
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string _tipo = string.Empty;
        string _tipo_bd = string.Empty;

        if (this.rdProyectos.Checked == true) _tipo = "PRY";
        if (this.rdProgramas.Checked == true) _tipo = "PRG";
        if (this.rdEstudios.Checked == true) _tipo = "EB";
        
        if (this.rdConvenioscol.Checked == true) _tipo = "ATE";
                
        if (this.rdBusquedaDirecta.Checked == true) _tipo = "BD";

        Session["SS_tipo_proyecto"] = _tipo;
        Session["SS_region_inicio"] = ddlRegDesde.SelectedValue;
        Session["SS_region_fin"] = ddlRegHasta.SelectedValue;
        Session["SS_estado_inicio"] = ddlEstDesde.SelectedValue;
        Session["SS_estado_fin"] = ddlEstHasta.SelectedValue;
        Session["SS_proceso_inicio"] = ddlProDesde.SelectedValue;
        Session["SS_proceso_fin"] = ddlProHasta.SelectedValue;

        
        if (this.rdContrato.Checked == true) _tipo_bd = "C";
        if (this.rdProyecto.Checked == true) _tipo_bd = "P";

        Session["SS_bd_con_proy"] = _tipo_bd;
        Session["SS_con_proy"] = txtBusquedaDirecta.Text.Trim();
        

        arrNombreParametros = new string[] { "str_tipo_proyecto"
                                            , "str_region_inicio"
                                            , "str_region_fin"
                                            , "str_estado_inicio"
                                            , "str_estado_fin"
                                            , "str_proceso_inicio"
                                            , "str_proceso_fin"

                                            , "str_bd_con_proy"
                                            , "str_con_proy"
                                            };
        arrValoresParametros = new string[] { Session["SS_tipo_proyecto"].ToString()
                                        , Session["SS_region_inicio"].ToString()
                                        , Session["SS_region_fin"].ToString()
                                        , Session["SS_estado_inicio"].ToString()
                                        , Session["SS_estado_fin"].ToString()
                                        , Session["SS_proceso_inicio"].ToString()
                                        , Session["SS_proceso_fin"].ToString()

                                        , Session["SS_bd_con_proy"].ToString()
                                        , Session["SS_con_proy"].ToString()
                                        };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyectos", arrNombreParametros, arrValoresParametros);

        
        grdProyectos.DataSource = null;
        grdProyectos.UseAccessibleHeader = true;
        grdProyectos.DataBind();
        lblCantRegistros.Text = "Registros encontrados: 0";

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
            else
            {
               

                DataView myDataView = new DataView();
                myDataView = SQL_Execute.oDataTable.DefaultView;

                if (ViewState["sortexpression"] != null)
                {
                    myDataView.Sort = ViewState["sortexpression"].ToString() + " " + ViewState["sortdirection"].ToString();
                }
                                
                grdProyectos.DataSource = myDataView;
                grdProyectos.UseAccessibleHeader = true;
                grdProyectos.DataBind();

                if (grdProyectos.Rows.Count > 0)
                {
                    grdProyectos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdProyectos.FooterRow.TableSection = TableRowSection.TableFooter;
                }

                lblCantRegistros.Text = "Registros encontrados: " + grdProyectos.Rows.Count.ToString();
            }
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }

    private void _loadddlProceso()
    {
        
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string _tipo = string.Empty;

        _tipo = "PRY";
                
        if (this.rdProyectos.Checked == true) _tipo = "PRY";
        if (this.rdProgramas.Checked == true) _tipo = "PRG";
        if (this.rdEstudios.Checked == true) _tipo = "EB";
        
        if (this.rdConvenioscol.Checked == true) _tipo = "ATE";
        

        if (this.rdBusquedaDirecta.Checked == true) _tipo = "BD";

        arrNombreParametros = new string[] { "tipologia" };
        arrValoresParametros = new string[] { _tipo };               

        SQL_Execute.FUNC_Ejecuta_SP("GetPryProcesosList", arrNombreParametros, arrValoresParametros);
        ddlProDesde.Items.Clear();
        if (SQL_Execute.numero_error == 0)
        {
            ddlProDesde.DataSource = SQL_Execute.oReader;
            ddlProDesde.DataTextField = "proceso";
            ddlProDesde.DataValueField = "proceso";
            ddlProDesde.DataBind();
            ddlProDesde.SelectedIndex = 0;            
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
        SQL_Execute.FUNC_Ejecuta_SP("GetPryProcesosList", arrNombreParametros, arrValoresParametros);
        ddlProHasta.Items.Clear();
        if (SQL_Execute.numero_error == 0)
        {
            ddlProHasta.DataSource = SQL_Execute.oReader;
            ddlProHasta.DataTextField = "proceso";
            ddlProHasta.DataValueField = "proceso";
            ddlProHasta.DataBind();
            ddlProHasta.SelectedIndex = 0;
            ddlProHasta.SelectedIndex = int.Parse(ddlProHasta.Items.Count.ToString()) - 1;
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
                        
    }

    protected void radio_CheckedChanged(object sender, EventArgs e)
    {
        _loadddlProceso();
    }
    protected void rdP_CheckedChanged(object sender, EventArgs e)
    {   
        _loadddlProceso();
    }
    protected void rdpr_CheckedChanged(object sender, EventArgs e)
    {
        _loadddlProceso();
    }
    protected void rdE_CheckedChanged(object sender, EventArgs e)
    {        
        _loadddlProceso();        
    }

    protected void grdProyectos_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortexpression"] = e.SortExpression;

        if (ViewState["sortdirection"] == null)
        {
            ViewState["sortdirection"] = "asc";
        }
        else
        {
            if (ViewState["sortdirection"].ToString() == "asc")
            {
                ViewState["sortdirection"] = "desc";
            }
            else
            {
                ViewState["sortdirection"] = "asc";
            }
        }

        FUNC_Busca_Proyectos();
    }
        
   
}
