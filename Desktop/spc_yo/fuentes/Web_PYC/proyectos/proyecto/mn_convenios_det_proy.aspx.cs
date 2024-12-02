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

public partial class mn_convenios_det_proy : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;

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
        

        if (!IsPostBack)
        {

            txtMontoCompromet.Text = "0";
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

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_convenios_proyecto", arrNombreParametros, arrValoresParametros);

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
            
            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };
                        
            SQL_Execute.FUNC_Ejecuta_SP("GetBuscaEtapa", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlEtapa.DataSource = SQL_Execute.oReader;
                ddlEtapa.DataTextField = "ETAPA";
                ddlEtapa.DataValueField = "ETAPA";
                ddlEtapa.DataBind();
                ddlEtapa.Items.Insert(0, "(SELECCIONAR)");
            }

            /********************************************************************/

            arrNombreParametros = new string[] { "region", "codigo_da" };
            arrValoresParametros = new string[] { strCdigoRegion, strCdigoPIA };

            SQL_Execute.FUNC_Ejecuta_SP("Get_busca_mandantes_proyecto", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                ddlMandante.DataSource = SQL_Execute.oReader;
                ddlMandante.DataTextField = "MANDANTE";
                ddlMandante.DataValueField = "MANDANTE";
                ddlMandante.DataBind();
                ddlMandante.Items.Insert(0, "(SELECCIONAR)");
            }            
            
            /********************************************************************/

            ddlTipoConvenio.Items.Insert(0, "(SELECCIONAR)");
            ddlTipoConvenio.Items.Add("Completo");
            ddlTipoConvenio.Items.Add("Simple");
            ddlTipoConvenio.Items.Add("Otro");            
            
            /********************************************************************/

            ddlEstadoConvenio.Items.Insert(0, "(SELECCIONAR)");
            ddlEstadoConvenio.Items.Add("Por ejecutar");
            ddlEstadoConvenio.Items.Add("En ejecución");
            ddlEstadoConvenio.Items.Add("Ejecutado");
            ddlEstadoConvenio.Items.Add("Liquidado");
            
            /********************************************************************/
        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        
        Response.Redirect("../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
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
        
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] { "region"
                                        , "codigo_da"
                                        , "mandante"
                                        , "correlativo"

                                        , "etapa"
                                        , "num_decreto"
                                        , "fecha_decreto"
                                        , "tipo_convenio"
                                        , "fecha_convenio"

                                        , "monto_neto"
                                        , "gastos_administrativos"
                                        , "consul"
                                        , "otros_gastos"

                                        , "descripcion"
                                        , "fecha_ingreso"
                                        , "estado_convenio"
                                        , "observacion"
                                        , "fecha_liquidacion"
                                        };
        arrValoresParametros = new string[] { Request.Form["txtRegion"]
                                            , Request.Form["txtPIA"]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"],"")
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtCorrelativo"])

                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEtapa"],"")
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtNumeroRes"])
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaRes"])
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipoConvenio"],"")
                                            , Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaConvenio"])
                                            
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtMontoNeto"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtGastosAdmin"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtGastosConsultoria"])
                                            , Func_Libreria.FUNC_MontoSQLv2(Request.Form["txtOtrosGastos"])

                                            , Request.Form[""]
                                            , Request.Form[""]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlEstadoConvenio"],"")
                                            , Request.Form["txtObs"]
                                            , Request.Form[""]

                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_grabar_convenios_proyecto", arrNombreParametros, arrValoresParametros);
        
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
        
        string strURLPostGrabar = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

        arrNombreParametros = new string[] { "region"
                                        , "codigo_da"
                                        , "mandante"
                                        , "correlativo"
                                        };

        arrValoresParametros = new string[] { Request.Form["txtRegion"]
                                            , Request.Form["txtPIA"]
                                            , Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlMandante"],"")
                                            , Func_Libreria.FUNC_MontoSQL(Request.Form["txtCorrelativo"])
                                            };

        SQL_Execute.FUNC_Ejecuta_SP("Set_eliminar_convenios_proyecto", arrNombreParametros, arrValoresParametros);

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

    protected void grdConvenio_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCorrelativo.Text = grdConvenio.SelectedRow.Cells[1].Text;
        
        ddlEtapa.ClearSelection();
        ListItem olstEtapa = ddlEtapa.Items.FindByValue(grdConvenio.SelectedRow.Cells[2].Text);
        if (olstEtapa != null) ddlEtapa.SelectedValue = olstEtapa.Value;

        ddlMandante.ClearSelection();
        ListItem olstMandante = ddlMandante.Items.FindByValue(grdConvenio.SelectedRow.Cells[3].Text);
        if (olstMandante != null) ddlMandante.SelectedValue = olstMandante.Value;
        
        txtFechaConvenio.Text = grdConvenio.SelectedRow.Cells[4].Text;
        txtNumeroRes.Text = grdConvenio.SelectedRow.Cells[5].Text;
        txtFechaRes.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdConvenio.SelectedRow.Cells[6].Text);
                
        ddlTipoConvenio.ClearSelection();
        ListItem olstTipoConvenio = ddlTipoConvenio.Items.FindByValue(grdConvenio.SelectedRow.Cells[7].Text);
        if (olstTipoConvenio != null) ddlTipoConvenio.SelectedValue = olstTipoConvenio.Value;
        
        txtMontoCompromet.Text = grdConvenio.SelectedRow.Cells[8].Text;
        txtMontoNeto.Text = grdConvenio.SelectedRow.Cells[9].Text;
        txtGastosAdmin.Text = grdConvenio.SelectedRow.Cells[10].Text;
        txtGastosConsultoria.Text = grdConvenio.SelectedRow.Cells[11].Text;
        txtOtrosGastos.Text = grdConvenio.SelectedRow.Cells[12].Text;
        
        ddlEstadoConvenio.ClearSelection();
        ListItem olstEstadoConvenio = ddlEstadoConvenio.Items.FindByValue(grdConvenio.SelectedRow.Cells[12].Text);
        if (olstEstadoConvenio != null) ddlEstadoConvenio.SelectedValue = olstEstadoConvenio.Value;

        txtObs.Text = Func_Libreria.FUNC_Quita_Espacio_HTML(grdConvenio.SelectedRow.Cells[14].Text);
    }

    protected void OnRowDataBound(object sender, EventArgs e)
    {
        //GridViewRowEventArgs ea = e as GridViewRowEventArgs;
        //if (ea.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DataRowView drv = ea.Row.DataItem as DataRowView;
        //    Object ob = drv["monto_compromet"];
        //    if (!Convert.IsDBNull(ob))
        //    {
        //        Int64 iParsedValue = 0;
        //        if (Int64.TryParse(ob.ToString(), out iParsedValue))
        //        {
        //            TableCell cell = ea.Row.Cells[4];
        //            cell.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:(###) ###-####}", new object[] { iParsedValue });
        //        }
        //    }
        //}
    }


}


/*
              tabla CONVENIOS
             
              txtCorrelativo - N° - CORRELATIVO
              ddlEtapa -  Etapa - ETAPA  --  SELECT ETAPA.ETAPA FROM ETAPA WHERE (((ETAPA.NIVEL)=[Formularios]![CONVENIO]![NIVEL]) AND ((ETAPA.REGION)=[Formularios]![CONVENIO]![REGION]) AND ((ETAPA.CODIGO_DA)=[Formularios]![CONVENIO]![CODIGO_DA]));
              ddlMandante - Mandante - MANDANTE -- SELECT MANDANTES.MANDANTE FROM MANDANTES WHERE ((MANDANTES.NIVEL=[Formularios]![Ingreso Proyecto]![NIVEL]) AND (MANDANTES.REGION=[Formularios]![Ingreso Proyecto]![REGION]) AND (MANDANTES.CODIGO_DA=[Formularios]![Ingreso Proyecto]![CODIGO_DA])) ORDER BY MANDANTES.MANDANTE;
              txtFechaConvenio - Fecha Convenio - FECHA_CONVENIO
              txtNumeroRes - Res. -  NUM_DECRETO
              txtFechaRes - Fecha Res. - FECHA_DECRETO
              ddlTipoConvenio - Tipo Convenio - TIPO_CONVENIO -- "Completo";"Simple";"Otro"
              txtMontoCompromet - Monto compromet. - =[MONTO_NETO]+[GASTOS_ADMINISTRATIVOS]+[CONSUL]
              txtMontoNeto -  Monto Neto - MONTO_NETO
              txtGastosAdmin - Gastos Admin - GASTOS_ADMINISTRATIVOS
              txtGastosConsultoria - Gastos Consultria - CONSUL
              ddlEstadoConvenio  - Estado Convenio - ESTADO_CONVENIO -- "Por ejecutar";"En ejecución";"Ejecutado";"Liquidado"
              txtObs - Obs - OBSERVACION*/