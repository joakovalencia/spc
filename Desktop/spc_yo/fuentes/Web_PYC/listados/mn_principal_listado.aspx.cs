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

public partial class mn_principal_listado : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();
    
    

    protected void Page_Load(object sender, EventArgs e)
    {

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        Func_Libreria.FUNC_Valida_Sesion("/mn_principal_listado.aspx");

        
        cmdSalir.Attributes.Add("onClick", "target='_self';");

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

        string strSQL = "";

        if (!IsPostBack)
        {            
            txtFechaInicio.Text = Func_Libreria.FUNC_Trae_Fecha_Proceso("proceso");            
            txtFechaFinal.Text = Func_Libreria.FUNC_Trae_Fecha_Proceso("proceso");
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_region");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegionInicio.DataSource = SQL_Execute.oReader;
                ddlRegionInicio.DataTextField = "NOMBRE_REGION";
                ddlRegionInicio.DataValueField = "REG_ORDEN_LISTADO";
                ddlRegionInicio.DataBind();
            }
                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_llena_region");

            if (SQL_Execute.numero_error == 0)
            {
                ddlRegionFinal.DataSource = SQL_Execute.oReader;
                ddlRegionFinal.DataTextField = "NOMBRE_REGION";
                ddlRegionFinal.DataValueField = "REG_ORDEN_LISTADO";
                ddlRegionFinal.DataBind();
            }

            txtFechaInicio.Text = "01/01/" + DateTime.Today.Year;
            
            ddlRegionFinal.SelectedIndex = 15;

        }
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal_pyc.aspx");
    }


    protected void cmdConvenios_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("convenios/rpt_convenios.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }
    protected void cmdPropuestasProgramadas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Propuestas/rpt_propuestas.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdPropuestasAbiertas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Abiertas/rpt_abiertas.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdPropuestasAdjudicadas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Adjudicadas/rpt_adjudicadas.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdContratos_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("contratos_ito/rpt_contratos_ito.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }
    protected void cmbContratoRecepProvi_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_recep_provi/rpt_contratos_recep_provi.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }
    protected void cmbContratoActEntExp_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_acta_explo/rpt_contratos_acta_explo.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmbContratosLiquidados_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_liquidados/rpt_contratos_liquidados.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmbContratoOrdenProvi_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_orden_provi/rpt_contratos_orden_provi.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmbContratosObraTermino_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_De_Obra_terminados/rpt_Contratos_De_Obra_Terminados.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbMonitoreoPlzosLici_ProgObras_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reporte_monitoreo_plazos_lici_prog_obra/rpt_monitoreo_plazos_lici_prog_obras.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmbContratos_ordenados_por_Provincias_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reportes_obras_contrato_ordenado_provincia/reportes_obras_contrato_ordenado_provincia.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CMB_RP8_Cartilla_Chequeo_Previo_Obras_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reportes_cartilla_chequeo_previo_obras/reportes_cartilla_chequeo_previo_obras.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmb_VIGENTES_OBRAS_Contratos_ordenados_por_Tipo_de_Fondo_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reportes_contratos_tipo_fondo/reportes_contratos_tipo_fondo.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdVIG_Ordenado_Sector_Destino_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_Sector_Destino/rpt_Contratos_ordenados_por_Sector_Destino.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdVIG_Cttos_Sec_Destino_Sectorial_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Cttos_por_Sector_Destino_solo_Sectorial/rpt_Cttos_por_Sector_Destino_solo_Sectorial.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdVIG_Ordenado_Tipo_Fondo_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_Tipo_de_Fondo_General/rpt_Contratos_ord_por_Tipo_de_Fondo_General.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdVIG_Contrato_Vig_Prod_Estrategico_Click(object sender, EventArgs e)
    {

        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_vigentes_por_Prod_Estrategico/rpt_Contratos_vigentes_por_Prod_Estrategico.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");

    }
    protected void CmbDIS_Contratos_Orden_Sec_Desti_Click(object sender, EventArgs e)
    {

        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_Sector_Destino_Diseno/rpt_Contratos_ordenados_por_Sector_Destino_Diseno.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbDIS_Contra_Ord_TipoFondo_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_Tipo_de_Fondo_Diseno/rpt_Contratos_ordenados_por_Tipo_de_Fondo_Diseno.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
                   
    }
    protected void CmdOBRA_Contrato_Observaciones_Click(object sender, EventArgs e)
    {

   
    }
    protected void CmbOBRA_Tipo_de_Fondo_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reportes_contratos_tipo_fondo/reportes_contratos_tipo_fondo.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmdOBRA_Contra_Orden_Sec_Destino_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_Sector_Destino_Obras/rpt_Contratos_ordenados_por_Sector_Destino_Obras.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbEJE_Ordenados_provincias_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_ordenados_por_provincia/rpt_Contratos_ordenados_por_provincia.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbEJE_Ordenado_por_Comuna_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_en_Ejecucion_Agrupados_Por_Comuna/rpt_Ejec_Gen_Contratos_Ordenados_por_Comunas.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbEJE_progra_avance_finan_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Programacion_de_Avance_financiero/rpt_Programacion_de_Avance_financiero.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbEJE_Orden_Provi_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_orden_provi/rpt_contratos_orden_provi.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbTER_GEN_fecha_ito_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_terminados_segun_fecha_ITO_General/rpt_Contratos_terminados_segun_fecha_ITO_General.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmbTER_GEN_proyec_termino_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Proyeccion_de_termino_de_Contratos_General/rpt_Proyeccion_de_termino_de_Contratos_General.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }
    protected void CmbTER_DIS_segun_fecha_ITO_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_terminados_segun_fecha_I_T_O_Diseno/rpt_Contratos_terminados_segun_fecha_I_T_O_Diseno.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");

    }
    protected void CmbTER_OBRA_contratos_terminados_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_De_Obra_Terminados/rpt_Contratos_De_Obra_Terminados.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");

    }
    protected void CmbTER_OBRA_termindas_plazo_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Obras_nuevas_terminadas_en_plazo/rpt_Obras_nuevas_terminadas_en_plazo.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");        
    }
    protected void CmbREC_OBRA_recepcion_provisoria_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_recep_provi/rpt_contratos_recep_provi.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta"); 
    }
    protected void CmbACT_GEN_acta_explotacion_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_acta_explo/rpt_contratos_acta_explo.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbLIQ_DIS_Contratos_Liquidados_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_liquidados/rpt_contratos_liquidados.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbLIQ_DIS_cont_liq_anti_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Contratos_liq_anti/rpt_contratos_liq_anti.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbLIQ_OBRAS_Contratos_Liquidados_Click(object sender, EventArgs e)
    {

        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Liquidacion_Obras_Contratos_Terminados/rpt_Liquidacion_Obras_Contratos_Terminados.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");

    }
    protected void CmbLIQ_OBRAS_Cont_Liq_Anti_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Liquidacion_Obras_Contratos_Con_liquidacion_Anticipada/rpt_Liquidacion_Obras_Contratos_Con_liquidacion_Anticipada.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RF2_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde_OPL"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta_OPL"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde_OPL"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta_OPL"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Propuestas_sin_oferentes_al_primer_llamado/rpt_Propuestas_sin_oferentes_al_primer_llamado.aspx");

        Session.Remove("tmp_region_desde_OPL");
        Session.Remove("tmp_region_hasta_OPL");
        Session.Remove("tmp_fecha_desde_OPL");
        Session.Remove("tmp_fecha_hasta_OPL");
    }
    protected void RP2_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reporte_monitoreo_plazos_lici_prog_obra/rpt_monitoreo_plazos_lici_prog_obras.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void RF3_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Llamados_a_Licitacion_no_adjudicados/rpt_Llamados_a_Licitacion_no_adjudicados.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RP3_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Cartilla_chequeo_propuesta_tecnica/rpt_cartilla_chequeo_propuesta_tecnica.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void RF4_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Monitoreo_de_nuevas_boletas_de_garantias/rpt_Monitoreo_de_nuevas_boletas_de_garantias.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void RP4_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("demora_mandante_aprobar_modificaciones/rpt_demora_mandante_aprobar_modificaciones.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void RF5_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Obras_mal_valorizadas_en_liquidacones_anticipadas/rpt_Obras_mal_valorizadas_en_liquidacones_anticipadas.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RP5_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("recepcion_definitiva_contratos_obras/rpt_recepcion_definitiva_contratos_obras.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void RF6_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Cancelacion_de_estados_de_pagos_sobre_avances_reales/rpt_Cancelacion_de_estados_de_pagos_sobre_avances_reales.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RP6_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Riesgos_Rp6_Seguimiento_consultorias/rpt_Riesgos_Rp6_Seguimiento_consultorias.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RF7_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Vencimiento_boletas_de_Garantia/rpt_Vencimiento_boletas_de_Garantia.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RP7_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Riesgos_Rp7_Chequeo_Previo_Terreno/rpt_Riesgos_Rp7_Chequeo_Previo_Terreno.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void RP8_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Rp8_chequeo_obras/rp8_chequeo_obras.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmdPRO_proy_estado_idea_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("proyecto_estado_idea/rpt_proyecto_estado_idea.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void CmdPRO_propuestas_abiertas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Abiertas/rpt_abiertas.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }

    protected void CmbPRO_Proyectos_Mandatado_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"]; 
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("proyectos_mandatados/rpt_proyectos_mandatados.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_adjudicadas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"]; 
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Adjudicadas/rpt_adjudicadas.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_estado_ejecucion_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("reporte_proyecto_estado_ejec/rpt_proyecto_estado_ejec.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_Convenios_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("convenios/rpt_convenios.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_contratos_ITO_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("contratos_ito/rpt_contratos_ito.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_estado_liquidado_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("proyectos_estado_liquidado/rpt_proyectos_estado_liquidado.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_estado_otro_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("proyecto_estado_otro/rpt_proyecto_estado_otros.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void CmbPRO_VAR_Info_contratista_Click(object sender, EventArgs e)
    {
        Session["tmp_fecha_hasta2"] = Request.Form["txtFechaFinal"].ToString();

        Response.Redirect("inf_contratista_especifico/rpt_inf_contratista_especifico_ayuda.aspx");

        Session.Remove("tmp_fecha_hasta2");
    }
    protected void CmbPRO_VAR_inver_mandante_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"];

        Response.Redirect("inf_contratista_especifico/rpt_inf_contratista_especifico.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");
    }
    protected void cmdInversionMandante_Click(object sender, EventArgs e)
    {
        
        Session["tmp_region_desde3"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta3"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde3"] = Request.Form["txtFechaInicio"].ToString();
        Session["tmp_fecha_hasta3"] = Request.Form["txtFechaFinal"].ToString();

        Response.Redirect("inversion_por_mandante/rpt_inversion_por_mandante_ayuda.aspx");

        Session.Remove("tmp_region_desde3");
        Session.Remove("tmp_region_hasta3");
        Session.Remove("tmp_fecha_desde3");
        Session.Remove("tmp_fecha_hasta3");

    }
    protected void CmbPRO_estado_terminado_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"].ToString();
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"].ToString();

        Response.Redirect("proyectos_terminados/rpt_proyectos_terminados.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }

    protected void Btn_Cartolas_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desdeX"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hastaX"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desdeX"] = Request.Form["txtFechaInicio"].ToString();
        Session["tmp_fecha_hastaX"] = Request.Form["txtFechaFinal"].ToString();

        Response.Redirect("Cartola_Contratos/rpt_cartola_contratos_ayuda.aspx?");

        Session.Remove("tmp_region_desdeX");
        Session.Remove("tmp_region_hastaX");
        Session.Remove("tmp_fecha_desdeX");
        Session.Remove("tmp_fecha_hastaX");
    }
   
    /*
    * protected void cmdContratoSectorialXSector_Click(object sender, EventArgs e)
    {
        string strRegInicio = Request.Form["ddlRegionInicio"].Replace("01","1");
        string strRegFin = Request.Form["ddlRegionFinal"].Replace("01", "1");
        string strClave = Session["ID_Usuario"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss").ToString();

        string strErrores = Func_Libreria.FUNC_WS_Reporte_Contratos_Sectorial(strRegInicio, strRegFin, strClave);

        if (strErrores != "")
        { 
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Error al procesar algunos registros del WS MDC Contratos Sectoriales" + strErrores + ".');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_principal_listado.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        Session["tmp_llave"] = strClave;
        Session["tmp_orden"] = "S"; //orden por Sector

        Response.Redirect("Contratos_Sectorial_Sector/rpt_contratos_sectorial_sector.aspx");

        Session.Remove("tmp_llave");
        Session.Remove("tmp_orden");

    }
    
    protected void cmdContratoSectorialXFondo_Click(object sender, EventArgs e)
    {
        string strRegInicio = Request.Form["ddlRegionInicio"].Replace("01", "1");
        string strRegFin = Request.Form["ddlRegionFinal"].Replace("01", "1");
        string strClave = Session["ID_Usuario"].ToString() + DateTime.Now.ToString("yyyyMMddhhmmss").ToString();

        string strErrores = Func_Libreria.FUNC_WS_Reporte_Contratos_Sectorial(strRegInicio, strRegFin, strClave);

        if (strErrores != "")
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Error al procesar algunos registros del WS MDC Contratos Sectoriales" + strErrores + ".');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_principal_listado.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        Session["tmp_llave"] = strClave;
        Session["tmp_orden"] = "F"; //orden por Fondo

        Response.Redirect("Contratos_Sectorial_Sector/rpt_contratos_sectorial_sector.aspx");

        Session.Remove("tmp_llave");
        Session.Remove("tmp_orden");
    }
    protected void CmbEJE_OBRA_orden_provincias_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Eje_Obra_Orden_Provi/rpt_eje_obra_orden_provi.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }

    protected void cmdVIG_excel_territorio_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Excel_territorio/rpt_excel_territorio.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    protected void cmdBase_valores_unitarios_Click(object sender, EventArgs e)
    {
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Excel_base/rpt_excel_base.aspx");

        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");

    }
    protected void cmdVIG_excel_inv_por_mes_Click(object sender, EventArgs e)
    {
        Session["tmp_region_desde"] = Request.Form["ddlRegionInicio"];
        Session["tmp_region_hasta"] = Request.Form["ddlRegionFinal"];
        Session["tmp_fecha_desde"] = Request.Form["txtFechaInicio"];
        Session["tmp_fecha_hasta"] = Request.Form["txtFechaFinal"];

        Response.Redirect("Excel_inv_por_mes/rpt_excel_inv_por_mes.aspx");

        Session.Remove("tmp_region_desde");
        Session.Remove("tmp_region_hasta");
        Session.Remove("tmp_fecha_desde");
        Session.Remove("tmp_fecha_hasta");
    }
    */
    protected void Cmd_flujo_financiero_Click(object sender, EventArgs e)
    {
        Response.Redirect("Flujo_financiero/rpt_flujo_financiero.aspx");
    }
}
