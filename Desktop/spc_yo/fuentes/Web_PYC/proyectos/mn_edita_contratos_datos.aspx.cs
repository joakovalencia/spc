///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla edicion datos contrato
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

public partial class mn_edita_contratos_datos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        
        Func_Libreria.FUNC_Valida_Sesion("/mn_edita_contratos_datos.aspx");
       
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

//        cmdObtenerDocSSD.Attributes.Add("onClick", "target='_blank';");
        cmdSalir.Attributes.Add("onClick", "target='_self';");
        cmdGrabar.Attributes.Add("onClick", "target='_self';");            

        if (!IsPostBack)
           {
            ddlRespAdmin.Items.Insert(0, "(SELECCIONAR)");
            ddlRespAdmin.Items.Add("Dirección Regional");
            ddlRespAdmin.Items.Add("Mandante");
            ddlRespAdmin.Items.Add("Nivel Central");

            if (lblUsuario.Text.ToUpper() == "JORGE.ESTAY") 
                txtobservacionM.Visible= true;
            
            if (lblUsuario.Text == "marco.friz") 
                txtobservacionM.Visible= true;
            
            if (lblUsuario.Text == "gonzalo.valdivia") 
                txtobservacionM.Visible= true;
        
            if (lblUsuario.Text == "rene.morales")
                txtobservacionM.Visible = true;

            if (lblUsuario.Text == "banjamin.cruz")
                txtobservacionM.Visible = true;

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo};

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Encabezado", arrNombreParametros, arrValoresParametros);

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
                    txtSufijo.Text = SQL_Execute.oReader["sufijo"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["TIPO_PROCESO"].ToString();
                    txtCodigoContrato.Text = SQL_Execute.oReader["cod_con"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlLegal.Items.Add(item);                    
                }

                ddlLegal.Items.Insert(0, "(SELECCIONAR)");                
            }


            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlAmbiental.Items.Add(item);
                }

                ddlAmbiental.Items.Insert(0, "(SELECCIONAR)");                
            }


            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlExpropiacion.Items.Add(item);
                }

                ddlExpropiacion.Items.Insert(0, "(SELECCIONAR)");
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlLicitacion.Items.Add(item);
                }

                ddlLicitacion.Items.Insert(0, "(SELECCIONAR)");
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlEjecTecnicaObras.Items.Add(item);
                }

                ddlEjecTecnicaObras.Items.Insert(0, "(SELECCIONAR)");
            }

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_alertas"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                while (SQL_Execute.oReader.Read())
                {
                    ListItem item = new ListItem(SQL_Execute.oReader["tipo_alerta"].ToString(), SQL_Execute.oReader["codigo"].ToString());

                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, Func_Libreria.FUNC_Colores_Eng(SQL_Execute.oReader["tipo_alerta"].ToString()));
                    item.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");

                    ddlAumento.Items.Add(item);
                }

                ddlAumento.Items.Insert(0, "(SELECCIONAR)");
            }

            /********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("SP_busca_hitos"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                ddlProximoHito.DataSource = SQL_Execute.oReader;
                ddlProximoHito.DataTextField = "descripcion_hito";
                ddlProximoHito.DataValueField = "codigo_hito";
                ddlProximoHito.DataBind();
                ddlProximoHito.Items.Insert(0, "(SELECCIONAR)");
            }
            
            /********************************************************************/
            
           /* SQL_Execute.FUNC_Ejecuta_SP("sp_busca_dom_insp_fis"); //OK
            if (SQL_Execute.numero_error == 0)
            {
                ddlRespAdmin.DataSource = SQL_Execute.oReader;
                ddlRespAdmin.DataTextField = "rut_nombre_prof";
                ddlRespAdmin.DataValueField = "rut";
                ddlRespAdmin.DataBind();
                ddlRespAdmin.Items.Insert(0, "(SELECCIONAR)");
            }/

            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region", "sufijo" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion, strSufijo };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Contratos_Detalle_Datos", arrNombreParametros, arrValoresParametros);

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
                    ddlLegal.ClearSelection();
                    ListItem olstLegal = ddlLegal.Items.FindByValue(SQL_Execute.oReader["R_LEGAL"].ToString());
                    if(olstLegal != null) ddlLegal.SelectedValue = olstLegal.Value;

                    ddlAmbiental.ClearSelection();
                    ListItem olstAmbiental = ddlAmbiental.Items.FindByValue(SQL_Execute.oReader["R_AMBIENTAL"].ToString());
                    if (olstAmbiental != null) ddlAmbiental.SelectedValue = olstAmbiental.Value;

                    ddlExpropiacion.ClearSelection();
                    ListItem olstExpropiacion = ddlExpropiacion.Items.FindByValue(SQL_Execute.oReader["R_EXPROPIACION"].ToString());
                    if (olstExpropiacion != null) ddlExpropiacion.SelectedValue = olstExpropiacion.Value;

                    ddlLicitacion.ClearSelection();
                    ListItem olstLicitacion = ddlLicitacion.Items.FindByValue(SQL_Execute.oReader["R_LICITACION"].ToString());
                    if (olstLicitacion != null) ddlLicitacion.SelectedValue = olstLicitacion.Value;

                    ddlEjecTecnicaObras.ClearSelection();
                    ListItem olstEjecTecnicaObras = ddlEjecTecnicaObras.Items.FindByValue(SQL_Execute.oReader["R_EJECUCION"].ToString());
                    if (olstEjecTecnicaObras != null) ddlEjecTecnicaObras.SelectedValue = olstEjecTecnicaObras.Value;

                    ddlAumento.ClearSelection();
                    ListItem olstAumento = ddlAumento.Items.FindByValue(SQL_Execute.oReader["R_AUMENTO_COSTOS"].ToString());
                    if (olstAumento != null) ddlAumento.SelectedValue = olstAumento.Value;

                    txtExplicacion.Text = SQL_Execute.oReader["R_EXPLICACION_O_ALERTAS"].ToString();
                    txtobservacionM.Text = SQL_Execute.oReader["ObservacionMandante"].ToString();
                    txtFechaLicitacion.Text = SQL_Execute.oReader["R_APERTURA_LICITACION"].ToString();
                    txtFechaPPiedra.Text = SQL_Execute.oReader["R_PRIMERA_PIEDRA"].ToString();
                    txtFechaInaguracion.Text = SQL_Execute.oReader["R_INAUGURACION"].ToString();
                    ListItem olstra = ddlRespAdmin.Items.FindByValue(SQL_Execute.oReader["resp_administrativo"].ToString());
                    if (olstra != null) ddlRespAdmin.SelectedValue = olstra.Value;

                    //ddlRespAdmin.ClearSelection();
                    //ListItem olsRespAdmin = ddlRespAdmin.Items.FindByValue(SQL_Execute.oReader["resp_administrativo"].ToString());
                    //if (olsRespAdmin != null) ddlRespAdmin.SelectedValue = olsRespAdmin.Value;

                    ddlProximoHito.ClearSelection();
                    ListItem olsProximoHito = ddlProximoHito.Items.FindByValue(SQL_Execute.oReader["proximo_hito"].ToString());
                    if (olsProximoHito != null) ddlProximoHito.SelectedValue = olsProximoHito.Value;

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

        Response.Redirect("mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        string strVUsuario = lblUsuario.Text; //Session["ID_Usuario"].ToString
        string strVRegion = Request.Form["txtRegion"]; //strCdigoRegion

        bool permiso = Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion);

        if (lblUsuario.Text == "gonzalo.valdivia")
            permiso = true;

        if (lblUsuario.Text == "benjamin.cruz")
            permiso = true;
        
        if (lblUsuario.Text == "marco.friz")
            permiso = true;

        if (lblUsuario.Text == "alejandra.bobadilla")
            permiso = true;


        //if (Func_Libreria.FUNC_Valida_Acceso_Region(strVUsuario, strVRegion) == false)

        if (permiso == false)
        {


            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                HttpContext.Current.Response.Write("alert('Usted no tiene permisos para modificar datos de esta región.');\n");
                HttpContext.Current.Response.Write("window.location.href='../menu_principal_pyc.aspx'\n");
                HttpContext.Current.Response.Write("</SCRIPT>");
                HttpContext.Current.Response.End();
           
        }

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        string strURLPostGrabar = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] { "codigo_pia"
                                            , "codigo_region"
                                            , "sufijo"
                                            , "strLEGAL"
                                            , "strAMBIENTAL"
                                            , "strEXPROPIACION"
                                            , "strLICITACION"
                                            , "strEJECUCION"
                                            , "strAUMENTO_COSTOS"
                                            , "strEXPLICACION_O_ALERTAS"
                                            , "strAPERTURA_LICITACION"
                                            , "strPRIMERA_PIEDRA"
                                            , "strINAUGURACION" 
                                            , "intProximo_Hito"
                                            , "strObservacionMandante" 
                                            , "strResp_Administrativo"
                                            };
        arrValoresParametros = new string[] { Request.Form["txtPIA"]
                                            , Request.Form["txtRegion"]
                                            , Request.Form["txtSufijo"]
                                            , Request.Form["ddlLegal"]
                                            , Request.Form["ddlAmbiental"]
                                            , Request.Form["ddlExpropiacion"]
                                            , Request.Form["ddlLicitacion"]
                                            , Request.Form["ddlEjecTecnicaObras"]
                                            , Request.Form["ddlAumento"]
                                            , Request.Form["txtExplicacion"]
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaLicitacion"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaPPiedra"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaInaguracion"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlProximoHito"],"0")
                                            , Request.Form["txtobservacionM"]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlRespAdmin"],"")
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_Graba_Contratos_Detalle_Datos", arrNombreParametros, arrValoresParametros);

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

    /*
    protected void ddlLegal_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLegal.BackColor = Func_Libreria.FUNC_Colores(ddlLegal.SelectedItem.Value);
    }
    protected void ddlAmbiental_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAmbiental.BackColor = Func_Libreria.FUNC_Colores(ddlAmbiental.SelectedItem.Value);
    }
    protected void ddlExpropiacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlExpropiacion.BackColor = Func_Libreria.FUNC_Colores(ddlExpropiacion.SelectedItem.Value);
    }
    protected void ddlLicitacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLicitacion.BackColor = Func_Libreria.FUNC_Colores(ddlLicitacion.SelectedItem.Value);
    }
    protected void ddlEjecTecnicaObras_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEjecTecnicaObras.BackColor = Func_Libreria.FUNC_Colores(ddlEjecTecnicaObras.SelectedItem.Value);
    }
    protected void ddlAumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAumento.BackColor = Func_Libreria.FUNC_Colores(ddlAumento.SelectedItem.Value);
    }*/

    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = Page.Request.QueryString["sufijo"];
        string strCodCon = Request.Form["txtCodigoContrato"];
        string strTipo = "C";

        if (Request.Form["txtCodigoContrato"] == "")
        {
            lblError.Text = "Para conexión con SSD, debe ingresar un codigo de contrato.";
            return;
        }

        Response.Redirect("ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }
}
