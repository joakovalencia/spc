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

public partial class mn_mnt_patrimonio : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("//mn_ing_proyectos.aspx");
                
        cmdSalir.Attributes.Add("onClick", "target='_self';");
        cmdGabar.Attributes.Add("onClick", "target='_self';");

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        txtRegion.Text = strCdigoRegion;
        txtPIA.Text = strCdigoPIA;

        txtCodigo_proyecto.Text = strCodigoExploratorio;
        txtNombreProyecto.Text = strObjeto;
        txtBip.Text = strCodigoBip;        
                
        txtLatitud_coordenada.MaxLength = 1;
        txtLatitud_grados.MaxLength = 7;
        txtLatitud_minutos.MaxLength = 7;
        txtLatitud_segundos.MaxLength = 7;
        txtLongitud_coordenada.MaxLength = 1;
        txtLongitud_grados.MaxLength = 7;
        txtLongitud_minutos.MaxLength = 7;
        txtLongitud_segundos.MaxLength = 7;
        txtUtm_x.MaxLength = 9;
        txtUtm_y.MaxLength = 9;
        txtUtm_uso.MaxLength = 4;
        txtPropietario.MaxLength = 40;
        txtAdministrador.MaxLength = 40;
        //txtFigura_legal.MaxLength = 255;
        //txtModelo_gestion.MaxLength = 2;
        txtOtras_superficies.MaxLength = 9;
        txtAntecedentes_historicos.MaxLength = 500;
        txtEstado_conservacion_actual.MaxLength = 500;
        txtPrincipales_valores.MaxLength = 500;
        //txtCulturales.MaxLength = 500;
        txtProyecto_intervencion.MaxLength = 500;
        //txtEstructura_muros.MaxLength = 400;
        //txtEstructura_techumbre.MaxLength = 400;
        //txtAcabado_fachadas.MaxLength = 400;
        //txtAcabado_cubierta.MaxLength = 400;
        //txtOrnamentacion_relevante.MaxLength = 400;
        //txtOtros.MaxLength = 400;
        txtDescripcion_componentes.MaxLength = 400;
        txtDesc_conts_acabado.MaxLength = 400;

        txtDiasRevision.Text = "0";
        txtDiasRevisionCMN.Text = "0";
        txtDiasRevisionDOM.Text = "0";
        txtDiasRevisionSEA.Text = "0";
        txtDiasRevisionMINVU.Text = "0";
        txtDiasRevisionOTRA.Text = "0";
        txtLatitud_coordenada.Text = "0";
        txtLatitud_grados.Text = "0";
        txtLatitud_minutos.Text = "0";
        txtLatitud_segundos.Text = "0";
        txtLongitud_coordenada.Text = "0";
        txtLongitud_grados.Text = "0";
        txtLongitud_minutos.Text = "0";
        txtLongitud_segundos.Text = "0";
        txtUtm_x.Text = "0";
        txtUtm_y.Text = "0";
        txtSuperficieTotal.Text = "0";        

        cmdObtenerDocSSD.Attributes.Add("onClick", "target='_blank';");
        
        cmdUso_actual.Attributes.Add("onClick", "target='_self';");
        cmdfinanciamiento.Attributes.Add("onClick", "target='_self';");
        cmdUso_historico.Attributes.Add("onClick", "target='_self';");
        cmdMonumentos.Attributes.Add("onClick", "target='_self';");
        btnProcesosPatrimoniales.Attributes.Add("onClick", "target='_self';");
        cmdSuperficie.Attributes.Add("onClick", "target='_self';");
        cmdComponentesDestacados.Attributes.Add("onClick", "target='_self';");

        if (!IsPostBack)
        {

            /**********************************************************************/
            string[] arrNombreParametros;
            string[] arrValoresParametros;

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
                }
            }
            /**********************************************************************/                        
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_inspectores");

            if (SQL_Execute.numero_error == 0)
            {
                ddlInsFiscales.DataSource = SQL_Execute.oReader;
                ddlInsFiscales.DataTextField = "NOMBRE";
                ddlInsFiscales.DataValueField = "RUT";
                ddlInsFiscales.DataBind();
                
                ddlInsFiscales.Items.Insert(0, "(SELECCIONAR)");
            }
            /**********************************************************************/

            ddlTipo_ubicacion.Items.Add("U");
            ddlTipo_ubicacion.Items.Add("R");
            ddlTipo_ubicacion.Items.Insert(0, "(SELECCIONAR)");

            /**********************************************************************/

            txtFigura_legal.Items.Clear();
            txtFigura_legal.Items.Insert(0, "Propietario");
            txtFigura_legal.Items.Insert(0, "Comodato");
            txtFigura_legal.Items.Insert(0, "Usufructo");
            txtFigura_legal.Items.Insert(0, "Arriendo");
            txtFigura_legal.Items.Insert(0, "Concesion");
            txtFigura_legal.Items.Insert(0, "Concesion uso gratuito");
            txtFigura_legal.Items.Insert(0, "Donacion");
            txtFigura_legal.Items.Insert(0, "(SELECCIONAR)");

            ddlModelo_gestion.Items.Insert(0, "N");
            ddlModelo_gestion.Items.Insert(0, "S");
            ddlModelo_gestion.Items.Insert(0, "(SELECCIONAR)");

            /**********************************************************************/
            
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_sistema_constructivo");

            if (SQL_Execute.numero_error == 0)
            {
                ddlSCPredomPR.DataSource = SQL_Execute.oReader;
                ddlSCPredomPR.DataTextField = "descripcion";
                ddlSCPredomPR.DataValueField = "codigo";
                ddlSCPredomPR.DataBind();

                ddlSCPredomPR.Items.Insert(0, "(SELECCIONAR)");
            }

            /**********************************************************************/

            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_sistema_constructivo");

            if (SQL_Execute.numero_error == 0)
            {
                ddlSCPredomON.DataSource = SQL_Execute.oReader;
                ddlSCPredomON.DataTextField = "descripcion";
                ddlSCPredomON.DataValueField = "codigo";
                ddlSCPredomON.DataBind();

                ddlSCPredomON.Items.Insert(0, "(SELECCIONAR)");
            }
            /**********************************************************************/
                        
            ddlRATE.Items.Clear();
            ddlRATE.Items.Add("SR");
            ddlRATE.Items.Add("RS");
            ddlRATE.Items.Add("FI");
            ddlRATE.Items.Add("OT");
            ddlRATE.Items.Add("IN");
            
            /**********************************************************************/

            hddExisteContrato.Value = "N";
            hddCodigoContrato.Value = "";
            hddSufijo.Value = "";

            /**********************************************************************/

            arrNombreParametros = new string[] { "codigo_proyecto" };
            arrValoresParametros = new string[] { strCodigoExploratorio };

            SQL_Execute.FUNC_Ejecuta_SP("GET_MANTENCION_PATRIMONIO_BUSCA", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {
                if (SQL_Execute.retorno_valores == 1) 
                {
                    while (SQL_Execute.oReader.Read())
                    {
                        txtActualizacion_data_p.Text = SQL_Execute.oReader["Actualizacion_data_P"].ToString();
                        
                        ListItem Tipo_ubicacion = ddlTipo_ubicacion.Items.FindByValue(SQL_Execute.oReader["Tipo_ubicacion"].ToString());
                        if (Tipo_ubicacion != null) ddlTipo_ubicacion.SelectedValue = Tipo_ubicacion.Value;

                        ListItem InsFiscales = ddlInsFiscales.Items.FindByValue(SQL_Execute.oReader["Autor_Ficha"].ToString().Trim());
                        if (InsFiscales != null) ddlInsFiscales.SelectedValue = InsFiscales.Value;

                        ListItem Figura_Legal = txtFigura_legal.Items.FindByValue(SQL_Execute.oReader["Figura_legal"].ToString().Trim());
                        if (Figura_Legal != null) txtFigura_legal.SelectedValue = Figura_Legal.Value;

                        txtLatitud_grados.Text = SQL_Execute.oReader["Latitud_grados"].ToString().Trim();
                        txtLatitud_coordenada.Text = SQL_Execute.oReader["Latitud_Coordenada"].ToString().Trim();
                        txtLatitud_minutos.Text = SQL_Execute.oReader["Latitud_minutos"].ToString().Trim();
                        txtLatitud_segundos.Text = SQL_Execute.oReader["Latitud_segundos"].ToString().Trim();
                        txtLongitud_coordenada.Text = SQL_Execute.oReader["longitud_Coordenada"].ToString().Trim();
                        txtLongitud_grados.Text = SQL_Execute.oReader["longitud_grados"].ToString().Trim();
                        txtLongitud_minutos.Text = SQL_Execute.oReader["longitud_minutos"].ToString().Trim();
                        txtLongitud_segundos.Text = SQL_Execute.oReader["longitud_segundos"].ToString().Trim();
                        txtUtm_x.Text = SQL_Execute.oReader["UTM_X"].ToString().Trim();
                        txtUtm_y.Text = SQL_Execute.oReader["UTM_Y"].ToString().Trim();
                        txtUtm_uso.Text = SQL_Execute.oReader["UTM_USO"].ToString().Trim();
                        txtPropietario.Text = SQL_Execute.oReader["Propietario"].ToString().Trim();
                        txtAdministrador.Text = SQL_Execute.oReader["Administrador"].ToString().Trim();
                        //txtFigura_legal.Text = SQL_Execute.oReader["Figura_legal"].ToString().Trim();

                        ListItem InsModelo_gestion = ddlModelo_gestion.Items.FindByValue(SQL_Execute.oReader["Modelo_gestion"].ToString().Trim());
                        if (InsModelo_gestion != null) ddlModelo_gestion.SelectedValue = InsModelo_gestion.Value;

                        txtOtras_superficies.Text = SQL_Execute.oReader["Otras_Superficies"].ToString().Trim();
                        txtAntecedentes_historicos.Text = SQL_Execute.oReader["Antecedentes_historicos"].ToString().Trim();
                        txtEstado_conservacion_actual.Text = SQL_Execute.oReader["Estado_conservacion_actual"].ToString().Trim();
                        txtPrincipales_valores.Text = SQL_Execute.oReader["Principales_valores"].ToString().Trim();
                        //txtCulturales.Text = SQL_Execute.oReader["Culturales"].ToString().Trim();
                        txtProyecto_intervencion.Text = SQL_Execute.oReader["Proyecto_intervencion"].ToString().Trim();
                        //txtEstructura_muros.Text = SQL_Execute.oReader["Estructura_Muros"].ToString().Trim();
                        //txtEstructura_techumbre.Text = SQL_Execute.oReader["Estructura_Techumbre"].ToString().Trim();
                        //txtAcabado_fachadas.Text = SQL_Execute.oReader["Acabado_Fachadas"].ToString().Trim();
                        //txtAcabado_cubierta.Text = SQL_Execute.oReader["Acabado_Cubierta"].ToString().Trim();
                        //txtOrnamentacion_relevante.Text = SQL_Execute.oReader["Ornamentacion_Relevante"].ToString().Trim();
                        //txtOtros.Text = SQL_Execute.oReader["Otros"].ToString().Trim();
                        txtDescripcion_componentes.Text = SQL_Execute.oReader["Descripcion_componentes"].ToString().Trim();
                        txtRev_anteproy_cmn_envio.Text = SQL_Execute.oReader["Rev_anteproy_CMN_envio"].ToString().Trim();
                        txtRev_anteproy_cmn_recepcion.Text = SQL_Execute.oReader["Rev_anteproy_CMN_recepcion"].ToString().Trim();
                        txtRev_proy_cmn_envio.Text = SQL_Execute.oReader["Rev_proy_CMN_envio"].ToString().Trim();
                        txtRev_proy_cmn_recepcion.Text = SQL_Execute.oReader["Rev_proy_CMN_recepcion"].ToString().Trim();
                        txtRev_dom_envio.Text = SQL_Execute.oReader["Rev_DOM_envio"].ToString().Trim();
                        txtRev_dom_recepcion.Text = SQL_Execute.oReader["Rev_DOM_recepcion"].ToString().Trim();
                        txtRev_sea_envio.Text = SQL_Execute.oReader["Rev_SEA_envio"].ToString().Trim();
                        txtRev_sea_recepcion.Text = SQL_Execute.oReader["Rev_SEA_recepcion"].ToString().Trim();
                        txtRev_minvu_envio.Text = SQL_Execute.oReader["Rev_MINVU_envio"].ToString().Trim();
                        txtRev_minvu_recepcion.Text = SQL_Execute.oReader["Rev_MINVU_recepcion"].ToString().Trim();
                        txtRev_otra_envio.Text = SQL_Execute.oReader["Rev_OTRA_envio"].ToString().Trim();
                        txtRev_otra_recepcionas.Text = SQL_Execute.oReader["Rev_OTRA_recepcion"].ToString().Trim();

                        txtDiasRevision.Text = SQL_Execute.oReader["DiasRevision"].ToString().Trim();
                        txtDiasRevisionCMN.Text = SQL_Execute.oReader["DiasRevisionCMN"].ToString().Trim();
                        txtDiasRevisionDOM.Text = SQL_Execute.oReader["DiasRevisionDOM"].ToString().Trim();
                        txtDiasRevisionSEA.Text = SQL_Execute.oReader["DiasRevisionSEA"].ToString().Trim();
                        txtDiasRevisionMINVU.Text = SQL_Execute.oReader["DiasRevisionMINVU"].ToString().Trim();
                        txtDiasRevisionOTRA.Text = SQL_Execute.oReader["DiasRevisionOTRA"].ToString().Trim();

                        //string monumento_historico = SQL_Execute.oReader["monumento_historico"].ToString().Trim();
                        //if (monumento_historico.ToString().Trim() == "1") Chk_Patri_Histo.Checked = true;

                        //txtTipoDoctoMH.Text = SQL_Execute.oReader["tipo_docto_mh"].ToString().Trim();
                        //txtNumeroDoctoMH.Text = SQL_Execute.oReader["numero_docto_mh"].ToString().Trim();
                        //txtFechaDoctoMH.Text = SQL_Execute.oReader["fecha_docto_mh"].ToString().Trim();

                        //string zona_tipica = SQL_Execute.oReader["zona_tipica"].ToString().Trim();
                        //if (zona_tipica.ToString().Trim() == "1") Chk_Zona_Tipica.Checked = true;
                        
                        //txtTipoDoctoZT.Text = SQL_Execute.oReader["tipo_docto_zt"].ToString().Trim();
                        //txtNumeroDoctoZT.Text = SQL_Execute.oReader["numero_docto_zt"].ToString().Trim();
                        //txtFechaDoctoZT.Text = SQL_Execute.oReader["fecha_docto_zt"].ToString().Trim();

                        //string monumento_arqueologico = SQL_Execute.oReader["monumento_arqueologico"].ToString().Trim();
                        //if (monumento_arqueologico.ToString().Trim() == "1") Chk_Monum_Arque.Checked = true;
                        
                        //txtTipoDoctoMA.Text = SQL_Execute.oReader["tipo_docto_ma"].ToString().Trim();
                        //txtNumeroDoctoMA.Text = SQL_Execute.oReader["numero_docto_ma"].ToString().Trim();
                        //txtFechaDoctoMA.Text = SQL_Execute.oReader["fecha_docto_ma"].ToString().Trim();

                        string strInmueble_Conservacion_Historica = SQL_Execute.oReader["Inmueble_Conservacion_Historica"].ToString().Trim();
                        if (strInmueble_Conservacion_Historica.ToString().Trim() == "1") chbInmuebleConservacion.Checked = true;

                        string strZona_Conservacion_Historica = SQL_Execute.oReader["Zona_Conservacion_Histórica"].ToString().Trim();
                        if (strZona_Conservacion_Historica.ToString().Trim() == "1") chbInmuebleHistorica.Checked = true;

                        string strComponenteArqueologico = SQL_Execute.oReader["Componente_arqueologico"].ToString().Trim();
                        if (strComponenteArqueologico.ToString().Trim() == "1") chbComponenteArqueologico.Checked = true;

                        string strComponenteAmbiental = SQL_Execute.oReader["Componente_ambiental"].ToString().Trim();
                        if (strComponenteAmbiental.ToString().Trim() == "1") chbComponenteAmbiental.Checked = true;

                        ListItem lstSCPredomPR = ddlSCPredomPR.Items.FindByValue(SQL_Execute.oReader["sis_contructivo_proy_rest"].ToString().Trim());
                        if (lstSCPredomPR!= null) ddlSCPredomPR.SelectedValue = lstSCPredomPR.Value;

                        ListItem lstSCPredomON = ddlSCPredomON.Items.FindByValue(SQL_Execute.oReader["sis_contructivo_obra_nueva"].ToString().Trim());
                        if (lstSCPredomON!= null) ddlSCPredomON.SelectedValue = lstSCPredomON.Value;

                        txtDesc_conts_acabado.Text = SQL_Execute.oReader["princ_caracteristicas_constru"].ToString().Trim();

                        //ListItem lstComplemento_ambiental = ddlComplemento_ambiental.Items.FindByValue(SQL_Execute.oReader["complemento_ambiental"].ToString().Trim());
                        //if (lstComplemento_ambiental != null) ddlComplemento_ambiental.SelectedValue = lstComplemento_ambiental.Value;

                        ListItem lstRate = ddlRATE.Items.FindByValue(SQL_Execute.oReader["rate"].ToString().Trim());
                        if (lstRate != null) ddlRATE.SelectedValue = lstRate.Value;

                        hddExisteContrato.Value = SQL_Execute.oReader["existe"].ToString().Trim();
                        hddCodigoContrato.Value = SQL_Execute.oReader["cod_con"].ToString().Trim();
                        hddSufijo.Value = SQL_Execute.oReader["sufijo"].ToString().Trim();

                        txtSuperficieTotal.Text = SQL_Execute.oReader["superficie_total"].ToString().Trim();
                        
                    }

                }
            }

            if (hddExisteContrato.Value == "S")
            {
                cmdImprimir.Attributes.Add("onClick", "target='_blank';");
            }
            else
            {
                cmdImprimir.Attributes.Add("onClick", "return func_valida_imprimir();");
            }

        }       

    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];

        Response.Redirect("../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }

    protected void cmdGabar_Click(object sender, ImageClickEventArgs e)
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

        int InmuebleConservacion;
        int InmuebleHistorica;
        int ComponenteArqueologico;
        int ComponenteAmbiental;
        string patri_histo = "";
        string zona_tipica = "";
        string monum_arque = "";

        if (chbInmuebleConservacion.Checked == true)
            InmuebleConservacion = 1;
        else
            InmuebleConservacion = 0;

        if (chbInmuebleHistorica.Checked == true)
            InmuebleHistorica = 1;
        else
            InmuebleHistorica = 0;

        if (chbComponenteArqueologico.Checked == true)
            ComponenteArqueologico = 1;
        else
            ComponenteArqueologico = 0;

        if (chbComponenteAmbiental.Checked == true)
            ComponenteAmbiental = 1;
        else
            ComponenteAmbiental = 0;

        //if (Chk_Patri_Histo.Checked == true)
        //    patri_histo = "1";
        //else
        //    patri_histo = "0";

        //if (Chk_Zona_Tipica.Checked == true)
        //    zona_tipica = "1";
        //else
        //    zona_tipica = "0";

        //if (Chk_Monum_Arque.Checked == true)
        //    monum_arque = "1";
        //else
        //    monum_arque = "0";

        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { 
             "opcion"			 	        //	1
            , "codigo_proyecto"			 	//	2
            , "actualizacion_data_p"		//	3
            , "autor_ficha"			 	    //	4
            , "tipo_ubicacion"			 	//	5
            , "latitud_coordenada"			//	6
            , "latitud_grados"			 	//	7
            , "latitud_minutos"			 	//	8
            , "latitud_segundos"			//	9
            , "longitud_coordenada"			//	10
            , "longitud_grados"			 	//	11
            , "longitud_minutos"			//	12
            , "longitud_segundos"			//	13
            , "utm_x"			 	        //	14
            , "utm_y"			 	        //	15
            , "utm_uso"			 	        //	16
            , "propietario"			 	    //	17
            , "administrador"			 	 //	18
            , "figura_legal"			 	 //	19
            , "modelo_gestion"			 	 //	20
            , "inmueble_conservacion_historica"	    //	21
            , "zona_conservacion_historica"			//	22
            , "componente_arqueologico"			 	//	23
            , "componente_ambiental"			 	//	24
            , "complemento_ambiental"			 	//	25
            , "otras_superficies"			 	    //	26
            , "antecedentes_historicos"			 	//	27
            , "estado_conservacion_actual"			//	28
            , "principales_valores"			 	    //	29
            , "culturales"			 	            //	30
            , "proyecto_intervencion"			 	//	31
            , "estructura_muros"			 	    //	32
            , "estructura_techumbre"			 	//	33
            , "acabado_fachadas"			 	    //	34
            , "acabado_cubierta"			 	    //	35
            , "ornamentacion_relevante"			 	//	36
            , "otros"			 	                //	37
            , "descripcion_componentes"			 	//	38
            , "rev_anteproy_cmn_envio"			 	//	39
            , "rev_anteproy_cmn_recepcion"			//	40
            , "rev_proy_cmn_envio"			 	    //	41
            , "rev_proy_cmn_recepcion"			 	//	42
            , "rev_dom_envio"			 	        //	43
            , "rev_dom_recepcion"			 	    //	44
            , "rev_sea_envio"			 	        //	45
            , "rev_sea_recepcion"			 	    //	46
            , "rev_minvu_envio"			 	        //	47
            , "rev_minvu_recepcion"			 	    //	48
            , "rev_otra_envio"			 	        //	49
            , "rev_otra_recepcionas" 			 	//	50
            , "monumento_historico"                 //  51
            , "tipo_docto_mh"                       //  52
            , "numero_docto_mh"                     //  53
            , "fecha_docto_mh"                      //  54
            , "zona_tipica"                         //  55
            , "tipo_docto_zt"                       //  56
            , "numero_docto_zt"                     //  57
            , "fecha_docto_zt"                      //  58
            , "monumento_arqueologico"              //  59
            , "tipo_docto_ma"                       //  60
            , "numero_docto_ma"                     //  61
            , "fecha_docto_ma"                      //  62
            , "sis_contructivo_proy_rest"           //  63
            , "sis_contructivo_obra_nueva"          //  64 
            , "princ_caracteristicas_constru"       //  65
            , "rate"                                //  66
            , "superficie_total"                    //  67
        };

        string strInspectorFiscal = Request.Form["ddlInsFiscales"];

        if (strInspectorFiscal == "(SELECCIONAR)") strInspectorFiscal = "";

        arrValoresParametros = new string[] { 
        	 "G"		                                                                // 1
        ,   strCodigoExploratorio		                                                // 2
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtActualizacion_data_p"])       // 3
        ,	strInspectorFiscal		                                                    // 4
        ,	Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlTipo_ubicacion"],"")  // 5
        ,	Request.Form["txtLatitud_coordenada"]		                                // 6
        , 	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLatitud_grados"])              // 7
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLatitud_minutos"])		        // 8
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLatitud_segundos"])		    // 9
        ,	Request.Form["txtLongitud_coordenada"]		                                // 10
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLongitud_grados"])		        // 11
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLongitud_minutos"])	        // 12
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtLongitud_segundos"])		    // 13
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtUtm_x"])		                // 14
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtUtm_y"])		                // 15
        ,	Request.Form["txtUtm_uso"]		                                            // 16
        ,	Request.Form["txtPropietario"]		                                        // 17
        ,	Request.Form["txtAdministrador"]		                                    // 18
        ,	Request.Form["txtFigura_legal"]		                                        // 19
        ,	Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlModelo_gestion"],"")  // 20
        ,	InmuebleConservacion.ToString()                                             // 21
        ,	InmuebleHistorica.ToString()		                                        // 22
        ,	ComponenteArqueologico.ToString()		                                    // 23
        ,	ComponenteAmbiental.ToString()		                                        // 24
        ,	""                                                                          // 25 Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlComplemento_ambiental"],"") 
        ,	Func_Libreria.FUNC_MontoSQL(Request.Form["txtOtras_superficies"])           // 26
        ,	Request.Form["txtAntecedentes_historicos"]		                            // 27
        ,	Request.Form["txtEstado_conservacion_actual"]		                        // 28
        ,	Request.Form["txtPrincipales_valores"]		                                // 29
        ,	""		                                                                        // 30 Request.Form["txtCulturales"]
        ,	Request.Form["txtProyecto_intervencion"]		                                // 31
        ,	""		                                                                        // 32 Request.Form["txtEstructura_muros"]
        ,	""		                                                                        // 33 Request.Form["txtEstructura_techumbre"]
        ,	""		                                                                        // 34 Request.Form["txtAcabado_fachadas"]
        ,	""		                                                                        // 35 Request.Form["txtAcabado_cubierta"]
        ,	""		                                                                        // 36 Request.Form["txtOrnamentacion_relevante"]
        ,	""		                                                                        // 37 Request.Form["txtOtros"]
        ,	Request.Form["txtDescripcion_componentes"]		                                // 38
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_anteproy_cmn_envio"])		    // 39
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_anteproy_cmn_recepcion"])		// 40
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_proy_cmn_envio"])		        // 41
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_proy_cmn_recepcion"])		    // 42
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_dom_envio"])		            // 43
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_dom_recepcion"])		        // 44
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_sea_envio"])		            // 45
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_sea_recepcion"])		        // 46
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_minvu_envio"])		        // 47
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_minvu_recepcion"])		    // 48
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_otra_envio"])		            // 49
        ,	Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtRev_otra_recepcionas"])		    // 50
        ,	""                                                                              //  51 patri_histo.ToString()
        ,	""                                                                              //  52 Request.Form["txtTipoDoctoMH"]
        ,	""                                                                              //  53 Request.Form["txtNumeroDoctoMH"]
        ,	""                                                                              //  54 Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaDoctoMH"])
        ,	""                                                                              //  55 zona_tipica.ToString()
        ,	""                                                                              //  56 Request.Form["txtTipoDoctoZT"]
        ,	""                                                                              //  57 Request.Form["txtNumeroDoctoZT"]
        ,	""                                                                              //  58 Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaDoctoZT"])
        ,	""                                                                              //  59 monum_arque.ToString()
        ,	""                                                                              //  60 Request.Form["txtTipoDoctoMA"]
        ,	""                                                                              //  61 Request.Form["txtNumeroDoctoMA"]
        ,	""                                                                              //  62 Func_Libreria.FUNC_Fecha_SQL(Request.Form["txtFechaDoctoMA"])

        ,	Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSCPredomPR"],"0")         //  63
        ,	Func_Libreria.FUNC_Quita_Seleccionar(Request.Form["ddlSCPredomON"],"0")         //  64
        ,	Request.Form["txtDesc_conts_acabado"]                                           //  65
        ,   Request.Form["ddlRATE"]                                                         //  66
        ,   Func_Libreria.FUNC_MontoSQL(Request.Form["txtSuperficieTotal"])                 //  67
        };

        SQL_Execute.FUNC_Ejecuta_SP("Set_MANTENCION_PATRIMONIO", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {               
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];

            string strObjeto = Page.Request.QueryString["objeto"];
            string strCodigoBip = Page.Request.QueryString["codigo_bip"];
                        
            //string strURLBack = "../mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;

            string strURLBack = "mn_mnt_patrimonio.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio;
            
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Ficha de Patrimonio para Proyecto Código " + strCodigoExploratorio + " guardada correctamente.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLBack + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            lblError.Text = SQL_Execute.desc_error;
        }
        
    }   
    

    protected void cmdUso_actual_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];
                
        Response.Redirect("usos_actuales/mn_mnt_uso_patrimonial_actual.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdUso_historico_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("usos_historicos/mn_mnt_uso_patrimonial_Historico.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdfinanciamiento_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("financiamiento_patrimonial/mn_mnt_financiamiento_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdMonumentos_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("monumentos/mn_mnt_monumentos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void btnProcesosPatrimoniales_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("procesos_patrimoniales/mn_mnt_procesos_patrimoniales.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdSuperficie_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("superficie_patrimonial/mn_mnt_superficie_patrimonial.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdComponentesDestacados_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("componentes_destacados/mn_mnt_componentes_destacados.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }

    protected void cmdImprimir_Click(object sender, ImageClickEventArgs e)
    {
        //string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        //string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        //string strObjeto = Page.Request.QueryString["objeto"];
        //string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        //string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        //Response.Redirect("../../Listados/Patrimonio_final/rpt_patrimonio_final_ayuda.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        string strCodigoContrato = hddCodigoContrato.Value;
        string strSufijo = hddSufijo.Value;
        string strMandanteConvenio = "GORE";
        string strCorrelativoConvenio = "1";

        Response.Redirect("../../Listados/Patrimonio_final/rpt_patrimonio_final.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio + "&mandante_convenio=" + strMandanteConvenio + "&cod_con=" + strCodigoContrato + "&correlativo_convenio=" + strCorrelativoConvenio + "&sufijo=" + strSufijo);

    }
    protected void cmdObtenerDocSSD_Click(object sender, ImageClickEventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strSufijo = "0";
        string strCodCon = "";
        string strTipo = "P";

        Response.Redirect("../ssd/mn_mnt_conexion_ssd.aspx?tipo=" + strTipo + "&cod_con=" + strCodCon + "&sufijo=" + strSufijo + "&codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);        
    }
    protected void cmdComplementoAmbiental_Click(object sender, EventArgs e)
    {
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        string strObjeto = Page.Request.QueryString["objeto"];
        string strCodigoBip = Page.Request.QueryString["codigo_bip"];
        string strCodigoExploratorio = Page.Request.QueryString["codigo_exploratorio"];

        Response.Redirect("complemento_ambiental/mn_mnt_complemento_ambiental.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion + "&objeto=" + strObjeto + "&codigo_bip=" + strCodigoBip + "&codigo_exploratorio=" + strCodigoExploratorio);
    }
}
