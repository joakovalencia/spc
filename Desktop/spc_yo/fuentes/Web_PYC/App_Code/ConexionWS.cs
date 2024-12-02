///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Funciones de conexion web-services
///</summary>
///Modificado por:Alexi Rodriguez B. - MOP
///Fecha: 22-04-2014
/// Descripción: Se agrega strWebMethod SetElimina_boleta_garantia_contrato
///
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class ConexionWS
{
    public int numero_error = 0;
    public int retorno_valores = 0;
    public string desc_error = "";
    public DataTableReader oReader;
    public DataTable oDataTable;

    public SqlDataReader oReaderx;

    static string strConnectionStrings = ConfigurationManager.ConnectionStrings["conexion_bd"].ToString();
    SqlConnection ObjConnection = new SqlConnection();

    public void FUNC_Ejecuta_SP(string strWebMethod)
    {
        try
        {
            numero_error = 0;
            desc_error = "";

            WSSPC.WSSPC ows = new WSSPC.WSSPC();

            DataSet oDataSet = new DataSet();
            System.IO.StringReader xmlSR;
            System.Xml.XmlNode oxml;
            String stringXml = "";

            oxml = ows.GetConsultaGeneral("<parametros><tipo>" + strWebMethod.Trim() + "</tipo></parametros>");

            stringXml = oxml.OuterXml;

            xmlSR = new System.IO.StringReader(stringXml);

            oDataSet.ReadXml(xmlSR, XmlReadMode.Auto);

            if (oDataSet.Tables.Count == 1) //hay error
            {
                System.Data.DataRow drError = oDataSet.Tables[0].Rows[0];

                if (drError["codigo"].ToString() == "2")
                {
                    numero_error = 98;
                    desc_error = drError["descripcion"].ToString();
                    return;
                }

                if (drError["codigo"].ToString() == "1") //no retorno valores
                {
                    numero_error = 99;
                    desc_error = "";
                    retorno_valores = 0;
                    return;
                }
            }
            else //no hay error
            {
                oReader = oDataSet.Tables[1].CreateDataReader();
                oDataTable = oDataSet.Tables[1];
                retorno_valores = 1;
            }

        }
        catch (Exception ex)
        {
            numero_error = 99;
            desc_error = ex.Message.ToString();
        }

    }

    public void FUNC_Ejecuta_SP(string strWebMethod, string[] arrParameterName, string[] arrParameterValue)
    {
        try
        {
            numero_error = 0;
            desc_error = "";

            WSSPC.WSSPC ows = new WSSPC.WSSPC();

            DataSet oDataSet = new DataSet();
            System.IO.StringReader xmlSR;
            System.Xml.XmlNode oxml;
            String stringXml = "";
            int intLlamada = 0;

            string strWebServicesParameters = "";

            int i = 0;

            numero_error = 0;
            desc_error = "";

            strWebServicesParameters = "<parametros>";
            for (i = 0; i < arrParameterName.Length; i++)
            {
                string strParamValue = "<" + arrParameterName[i].ToLower() + ">" + arrParameterValue[i] + "</" + arrParameterName[i].ToLower() + ">";
                strWebServicesParameters = strWebServicesParameters + strParamValue;
            }
            strWebServicesParameters = strWebServicesParameters + "</parametros>";

            /*************************************************************************************/

            if (strWebMethod == "GetBusca_Contratos_Detalle_Datos")
            {
                oxml = ows.GetBusca_Contratos_Detalle_Datos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Contratos_Encabezado")
            {
                oxml = ows.GetBusca_Contratos_Encabezado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Correlativo_Convenios_Relacionados_Edita")
            {
                oxml = ows.GetBusca_Correlativo_Convenios_Relacionados_Edita(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Correlativo_Etapa_Relacionados_Edita")
            {
                oxml = ows.GetBusca_Correlativo_Etapa_Relacionados_Edita(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Correlativo_Mandantes_Relacionados_Edita")
            {
                oxml = ows.GetBusca_Correlativo_Mandantes_Relacionados_Edita(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Correlativo_Proceso_Relacionados_Edita")
            {
                oxml = ows.GetBusca_Correlativo_Proceso_Relacionados_Edita(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Datos_Usuario")
            {
                oxml = ows.GetBusca_Datos_Usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Permisos_usuario")
            {
                oxml = ows.GetBusca_Permisos_usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBusca_Proyecto_Contratos_Relacionados_Detalle")
            {
                oxml = ows.GetBusca_Proyecto_Contratos_Relacionados_Detalle(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Proyecto_Contratos_Relacionados_Detalle")
            {
                oxml = ows.GetBusca_Proyecto_Contratos_Relacionados_Detalle(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Proyecto_Contratos_Relacionados_Encabezado")
            {
                oxml = ows.GetBusca_Proyecto_Contratos_Relacionados_Encabezado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Proyecto_Encabezado")
            {
                oxml = ows.GetBusca_Proyecto_Encabezado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Proyectos")
            {
                oxml = ows.GetBusca_Proyectos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Tipos_Usuarios")
            {
                oxml = ows.GetBusca_Tipos_Usuarios(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Usuarios")
            {
                oxml = ows.GetBusca_Usuarios(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetConsultaGeneral")
            {
                oxml = ows.GetConsultaGeneral(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetLlena_Codigo_Contratos")
            {
                oxml = ows.GetLlena_Codigo_Contratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_Contratos_Detalle_Datos")
            {
                oxml = ows.SetGraba_Contratos_Detalle_Datos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetGraba_Contratos_Detalle_Edicion")
            {
                oxml = ows.SetGraba_Contratos_Detalle_Edicion(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Comunas")
            {
                oxml = ows.SetMnt_Comunas(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Contratista")
            {
                oxml = ows.SetMnt_Contratista(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Dom_Insp_Fis")
            {
                oxml = ows.SetMnt_Dom_Insp_Fis(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Ing_Proyectos")
            {
                oxml = ows.SetMnt_Ing_Proyectos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Permisos_Usuario")
            {
                oxml = ows.SetMnt_Permisos_Usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Usuario")
            {
                oxml = ows.SetMnt_Usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetValida_Acceso_Menu_Usuario")
            {
                oxml = ows.SetValida_Acceso_Menu_Usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetValida_Login_Usuario")
            {
                oxml = ows.SetValida_Login_Usuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;

            }

            //**********************************************************
            //NUEVOS
            //**********************************************************

            if (strWebMethod == "GetBusca_contratos_detalle_avance_fisico")
            {
                oxml = ows.GetBusca_contratos_detalle_avance_fisico(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_avance_fisico_suma")
            {
                oxml = ows.GetBusca_contratos_detalle_avance_fisico_suma(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_edita_contrato")
            {
                oxml = ows.GetBusca_contratos_detalle_edita_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_estado_pago")
            {
                oxml = ows.GetBusca_contratos_detalle_estado_pago(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_garantias")
            {
                oxml = ows.GetBusca_contratos_detalle_garantias(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_imputacion_presup")
            {
                oxml = ows.GetBusca_contratos_detalle_imputacion_presup(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_inspector_fiscal")
            {
                oxml = ows.GetBusca_contratos_detalle_inspector_fiscal(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_modificacion_contrato")
            {
                oxml = ows.GetBusca_contratos_detalle_modificacion_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetElimina_contratos_detalle_modificacion_contrato")
            {
                oxml = ows.SetElimina_contratos_detalle_modificacion_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_programacion_financ")
            {
                oxml = ows.GetBusca_contratos_detalle_programacion_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_programacion_financ_suma")
            {
                oxml = ows.GetBusca_contratos_detalle_programacion_financ_suma(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_programacion_tentativa_propuesta_financ")
            {
                oxml = ows.GetBusca_programacion_tentativa_propuesta_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_programacion_tentativa_propuesta_financ_suma")
            {
                oxml = ows.GetBusca_programacion_tentativa_propuesta_financ_suma(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_detalle_termino")
            {
                oxml = ows.GetBusca_contratos_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_contratos_resumen_edita_contrato")
            {
                oxml = ows.GetBusca_contratos_resumen_edita_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_correlativo_convenios_relacionados_edita")
            {
                oxml = ows.GetBusca_Correlativo_Convenios_Relacionados_Edita(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_dom_insp_fis")
            {
                oxml = ows.GetBusca_dom_insp_fis(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetCancela_contratos_detalle_termino")
            {
                oxml = ows.SetCancela_contratos_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetElimina_contratos_detalle_avance_fisico")
            {
                oxml = ows.SetElimina_contratos_detalle_avance_fisico(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetElimina_contratos_detalle_estado_pago")
            {
                oxml = ows.SetElimina_contratos_detalle_estado_pago(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetElimina_contratos_detalle_imputacion_presup")
            {
                oxml = ows.SetElimina_contratos_detalle_imputacion_presup(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetElimina_contratos_detalle_inspector_fiscal")
            {
                oxml = ows.SetElimina_contratos_detalle_inspector_fiscal(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetEliminar_contratos_detalle_programacion_financ")
            {
                oxml = ows.SetEliminar_contratos_detalle_programacion_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_avance_fisico")
            {
                oxml = ows.SetGraba_contratos_detalle_avance_fisico(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_contratos")
            {
                oxml = ows.SetGraba_contratos_detalle_contratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_garantias")
            {
                oxml = ows.SetGraba_contratos_detalle_garantias(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_imputacion_presup")
            {
                oxml = ows.SetGraba_contratos_detalle_imputacion_presup(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_inspector_fiscal")
            {
                oxml = ows.SetGraba_contratos_detalle_inspector_fiscal(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_modificacion_contrato")
            {
                oxml = ows.SetGraba_contratos_detalle_modificacion_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_nuevo")
            {
                oxml = ows.SetGraba_contratos_detalle_nuevo(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_programacion_financ")
            {
                oxml = ows.SetGraba_contratos_detalle_programacion_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_programacion_tentativa_propuesta_financ")
            {
                oxml = ows.SetGraba_programacion_tentativa_propuesta_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetEliminar_programacion_tentativa_propuesta_financ")
            {
                oxml = ows.SetEliminar_programacion_tentativa_propuesta_financ(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_contratos_detalle_termino")
            {
                oxml = ows.SetGraba_contratos_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabar_contratos_detalle_estado_pago")
            {
                oxml = ows.SetGrabar_contratos_detalle_estado_pago(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetPry_procesos_list")
            {
                oxml = ows.GetPry_procesos_list(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetSetup_grilla")
            {
                oxml = ows.GetSetup_grilla(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Contratista")
            {
                oxml = ows.SetMnt_Contratista(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Dom_Mandante")
            {
                oxml = ows.SetMnt_Dom_Mandante(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabaProceso_ssd")
            {
                oxml = ows.SetGrabaProceso_ssd(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetPryProcesosList")
            {
                oxml = ows.GetPryProcesosList(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetContratosPropuestas")
            {
                oxml = ows.GetContratosPropuestas(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetOfertasPropuestaContratista")
            {
                oxml = ows.GetOfertasPropuestaContratista(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetDomMandantes2")
            {
                oxml = ows.GetDomMandantes2(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBuscaDetalleProyecto")
            {
                oxml = ows.GetBuscaDetalleProyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBuscaConvenios")
            {
                oxml = ows.GetBuscaConvenios(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBuscaDomTiposEtapa")
            {
                oxml = ows.GetBuscaDomTiposEtapa(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBuscaEtapa")
            {
                oxml = ows.GetBuscaEtapa(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetDomMandantes2")
            {
                oxml = ows.GetDomMandantes2(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "GetBuscaConveniosModif")
            {
                oxml = ows.GetBuscaConveniosModif(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetContratoPropuesta")
            {
                oxml = ows.SetContratoPropuesta(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }



            if (strWebMethod == "SetOfertasPropuestas")
            {
                oxml = ows.SetOfertasPropuestas(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetMandantesContrato")
            {
                oxml = ows.SetMandantesContrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetGrabaDetalleProyecto")
            {
                oxml = ows.SetGrabaDetalleProyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetGrabaConvenio")
            {
                oxml = ows.SetGrabaConvenio(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetGrabaEtapa")
            {
                oxml = ows.SetGrabaEtapa(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "SetMandantesContrato")
            {
                oxml = ows.SetMandantesContrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabarConveniosModif")
            {
                oxml = ows.SetGrabarConveniosModif(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Provincia")
            {
                oxml = ows.GetBusca_Provincia(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Comunas_Sector")
            {
                oxml = ows.GetBusca_Comunas_Sector(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_SubSector_Sector")
            {
                oxml = ows.GetBusca_SubSector_Sector(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_Tipologias_Sector")
            {
                oxml = ows.GetBusca_Tipologias_Sector(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabaMandantesProyecto")
            {
                oxml = ows.SetGrabaMandantesProyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetEliminaMandantesProyecto")
            {
                oxml = ows.SetEliminaMandantesProyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_llena_codigo_contratos_cartola_contratos")
            {
                oxml = ows.Get_llena_codigo_contratos_cartola_contratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabaLog")
            {
                oxml = ows.SetGrabaLog(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_convenios_proyecto")
            {
                oxml = ows.Get_busca_convenios_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_mandantes_proyecto")
            {
                oxml = ows.Get_busca_mandantes_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_grabar_convenios_proyecto")
            {
                oxml = ows.Set_grabar_convenios_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_eliminar_convenios_proyecto")
            {
                oxml = ows.Set_eliminar_convenios_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_grabar_convenios_modif_proyecto")
            {
                oxml = ows.Set_grabar_convenios_modif_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_eliminar_convenios_modif_proyecto")
            {
                oxml = ows.Set_eliminar_convenios_modif_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_graba_ws_contratos_sectoriales")
            {
                oxml = ows.Set_graba_ws_contratos_sectoriales(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetContratistaAdjudicado")
            {
                oxml = ows.GetContratistaAdjudicado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetEliminaEtapa")
            {
                oxml = ows.SetEliminaEtapa(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_mandante_convenios")
            {
                oxml = ows.Get_busca_mandante_convenios(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_buscar_mandantes_del_contrato")
            {
                oxml = ows.Get_buscar_mandantes_del_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_eliminar_mandantes_del_contrato")
            {
                oxml = ows.Set_eliminar_mandantes_del_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetOfertasPropuestas_Elimina")
            {
                oxml = ows.SetOfertasPropuestas_Elimina(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetObtener_Codigo_SAFI")
            {
                oxml = ows.GetObtener_Codigo_SAFI();
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_Codigo_Relacional_Contrato")
            {
                oxml = ows.SetGraba_Codigo_Relacional_Contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetObtener_Numero_Exploratorio")
            {
                oxml = ows.GetObtener_Numero_Exploratorio(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_Datos_Exploratorio")
            {
                oxml = ows.SetGraba_Datos_Exploratorio(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_uso_historico")
            {
                oxml = ows.Get_busca_uso_historico(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_mnt_uso_historico")
            {
                oxml = ows.Set_mnt_uso_historico(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO")
            {
                oxml = ows.Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_uso_actual")
            {
                oxml = ows.Get_busca_uso_actual(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_mnt_uso_actual")
            {
                oxml = ows.Set_mnt_uso_actual(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_TipoUsuario")
            {
                oxml = ows.SetMnt_TipoUsuario(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_localizacion")
            {
                oxml = ows.Get_busca_localizacion(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GET_MANTENCION_PATRIMONIO_BUSCA")
            {
                oxml = ows.GET_MANTENCION_PATRIMONIO_BUSCA(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBuscaProceso_ssd")
            {
                oxml = ows.GetBuscaProceso_ssd(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            /****** EKLEINER ******/
            if (strWebMethod == "Get_rpt_patrimonio")
            {
                oxml = ows.Get_rpt_patrimonio(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;

            }

            if (strWebMethod == "Set_MANTENCION_PATRIMONIO")
            {
                oxml = ows.Set_MANTENCION_PATRIMONIO(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_llena_codigo_contratos")
            {
                oxml = ows.Get_llena_codigo_contratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Graba_Contratos_Detalle_Datos")
            {
                oxml = ows.Set_Graba_Contratos_Detalle_Datos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Componentes")
            {
                oxml = ows.Set_Mnt_Componentes(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Financiamiento")
            {
                oxml = ows.Set_Mnt_Financiamiento(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Monumento")
            {
                oxml = ows.Set_Mnt_Monumento(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Proceso")
            {
                oxml = ows.Set_Mnt_Proceso(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Superficie")
            {
                oxml = ows.Set_Mnt_Superficie(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            //EKV2

            if (strWebMethod == "Setmnt_ImagenesContrato_BorraContrato")
            {
                oxml = ows.SetMnt_ImagenesContrato_BorraContrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_valida_existencia_contrato")
            {

                oxml = ows.SetMnt_valida_existencia_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_updateImagenesContratos")
            {

                oxml = ows.SetMnt_updateImagenesContratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_tipo_proceso")
            {

                oxml = ows.Get_busca_tipo_proceso(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_imgFichaProyecto")
            {
                oxml = ows.Get_busca_imgFichaProyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_llena_codigo_contratos")
            {
                oxml = ows.Get_llena_codigo_contratos(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            //JPQV            
            if (strWebMethod == "Get_busca_asig_cargo_presupuesto")
            {
                oxml = ows.Get_busca_asig_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_cargo_presupuesto")
            {
                oxml = ows.Get_busca_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_fondos_cargo_presupuesto")
            {
                oxml = ows.Get_busca_fondos_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_imgPatrimonio")
            {
                oxml = ows.Get_busca_imgPatrimonio(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_item_cargo_presupuesto")
            {
                oxml = ows.Get_busca_item_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_mandantes_cargo_presupuesto")
            {
                oxml = ows.Get_busca_mandantes_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_elimina_cargo_presupuesto")
            {
                oxml = ows.Set_elimina_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_graba_cargo_presupuesto")
            {
                oxml = ows.Set_graba_cargo_presupuesto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_llena_codigo_contratos_proyecto")
            {
                oxml = ows.Get_llena_codigo_contratos_proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetValida_Acceso_Region")
            {
                oxml = ows.SetValida_Acceso_Region(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_CODIGO_USOS_PATRIMONIAL")
            {
                oxml = ows.Get_busca_CODIGO_USOS_PATRIMONIAL(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_actualiza_fecha_contrato")
            {
                oxml = ows.Set_actualiza_fecha_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_consultoria_detalle_termino")
            {
                oxml = ows.GetBusca_consultoria_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_consultoria_detalle_termino")
            {
                oxml = ows.SetGraba_consultoria_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "GetBusca_consultoria_detalle_termino_grilla")
            {
                oxml = ows.GetBusca_consultoria_detalle_termino_grilla(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGraba_consultoria_detalle_termino_grilla")
            {
                oxml = ows.SetGraba_consultoria_detalle_termino_grilla(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetCancela_consultoria_detalle_termino")
            {
                oxml = ows.SetCancela_consultoria_detalle_termino(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Elimina_Contrato")
            {
                oxml = ows.Set_Elimina_Contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Elimina_Proyecto")
            {
                oxml = ows.Set_Elimina_Proyecto(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Get_busca_registros_conttas_categoria")
            {
                oxml = ows.Get_busca_registros_conttas_categoria(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Contrato_Estado")
            {
                oxml = ows.SetMnt_Contrato_Estado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "Set_Mnt_Complemento_Ambiental")
            {
                oxml = ows.Set_Mnt_Complemento_Ambiental(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            if (strWebMethod == "Set_Mnt_Multi_Financiamiento")
            {
                oxml = ows.Set_Mnt_Multi_Financiamiento(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Convenio_Estado")
            {
                oxml = ows.SetMnt_Convenio_Estado(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            // Creado el 22-04-2014 por ARB
            if (strWebMethod == "SetElimina_boleta_garantia_contrato")
            {
                oxml = ows.SetElimina_boleta_garantia_contrato(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            //Metodos para Programación de Montos de proyectos en estado Idea.

            // Creado el 27-05-2015 por ARB 
            if (strWebMethod == "GetProgramacionMontoIdea")
            {
                oxml = ows.GetProgramacionMontoIdea(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetGrabaProgramacionMontoIdea")
            {
                oxml = ows.SetGrabaProgramacionMontoIdea(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetEliminaProgramacionMontoIdea")
            {
                oxml = ows.SetEliminaProgramacionMontoIdea(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }

            if (strWebMethod == "SetMnt_Edificacion")
            {
                oxml = ows.SetMnt_Edificacion(strWebServicesParameters);
                stringXml = oxml.OuterXml;
                intLlamada = 1;
            }


            /*************************************************************************************/

            if (intLlamada == 0) //se envio un nombre de WebMethod incorrecto
            {
                numero_error = 97;
                desc_error = "No existe el WebMethod " + strWebMethod;
                return;
            }

            xmlSR = new System.IO.StringReader(stringXml);

            oDataSet.ReadXml(xmlSR, XmlReadMode.Auto);

            if (oDataSet.Tables.Count == 1) //hay error
            {
                System.Data.DataRow drError = oDataSet.Tables[0].Rows[0];

                if (drError["codigo"].ToString() == "2")
                {
                    numero_error = 98;
                    desc_error = drError["descripcion"].ToString();
                    return;
                }

                if (drError["codigo"].ToString() == "1") //no retorno valores
                {
                    numero_error = 99;
                    desc_error = "";
                    retorno_valores = 0;
                    return;
                }
            }
            else //no hay error
            {
                oReader = oDataSet.Tables[1].CreateDataReader();
                oDataTable = oDataSet.Tables[1];
                retorno_valores = 1;
            }

        }
        catch (Exception ex)
        {
            numero_error = 99;
            desc_error = ex.Message.ToString();
        }
    }


}

