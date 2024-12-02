'<summary>
'Creado por: Erick - GSI Asesorias
'Fecha: 17-10-2012
'Descripción: Reportes Varios
'</summary>

'<summary>
'Modificado por: Alexi Rodriguez B. - MOP
'Fecha: 22-04-2014
'Descripción: Se crea metodo SetElimina_boleta_garantia_contrato
'</summary>

'<summary>
'Modificado por: Alexi Rodriguez B. - MOP
'Fecha: 10-04-2015
'Descripción:   Se crean metodos para agregar funcionalidad de Programación Tentativa propuesta y son los sgtes:
'               - GetBusca_programacion_tentativa_propuesta_financ
'               - GetBusca_programacion_tentativa_propuesta_financ_sum
'               - SetEliminar_programacion_tentativa_propuesta_financ
'               - SetGraba_programacion_tentativa_propuesta_financ
'               Se modifica en metodo
'               - SetGrabaDetalleProyecto
'</summary>

Imports System.Configuration
'Imports Oracle.DataAccess.Client
Imports System.Data.OracleClient
Imports System.Data.SqlClient


Namespace PYC.Utilities.DataAccess

    Partial Public Class AccessLayer

#Region "Metodos JG"

        Public Function GetConsultaGeneral(ByVal StoreProcedure As String) As DataTable
            Dim interfaz As DataTable = Nothing

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand(StoreProcedure, oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
                interfaz = DsSalida.Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return interfaz
        End Function

        Public Function SetMnt_Ing_Proyectos(ByVal region As String _
                                           , ByVal tipo_proy As String _
                                           , ByVal plan As Long _
                                           , ByVal producto As String _
                                           , ByVal proceso As String _
                                           , ByVal objeto As String _
                                           , ByVal fondo As String _
                                           , ByVal sector_destino As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_ing_proyectos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@tipo_proy", tipo_proy)
                oCmd.Parameters.AddWithValue("@plan", plan)
                oCmd.Parameters.AddWithValue("@producto", producto)
                oCmd.Parameters.AddWithValue("@proceso", proceso)
                oCmd.Parameters.AddWithValue("@objeto", objeto)
                oCmd.Parameters.AddWithValue("@fondo", fondo)
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")

            Catch ex As Exception

                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetLlena_Codigo_Contratos(ByVal str_region_inicio As String _
                                                , ByVal str_region_fin As String _
                                                , ByVal str_fecha_inicio As String _
                                                , ByVal str_fecha_fin As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_llena_codigo_contratos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@str_region_inicio", str_region_inicio)
                oCmd.Parameters.AddWithValue("@str_region_fin", str_region_fin)
                oCmd.Parameters.AddWithValue("@str_fecha_inicio", str_fecha_inicio)
                oCmd.Parameters.AddWithValue("@str_fecha_fin", str_fecha_fin)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Usuarios(ByVal usuario As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_usuarios", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@usuario", usuario)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Tipos_Usuarios(ByVal codigo_tipo_usuario As Long) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_tipos_usuarios", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        'JGM 20121125
        Public Function GetContratistaAdjudicado(ByVal region As String _
                                                  , ByVal codigo_da As String _
                                                  , ByVal sufijo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratista_adjudicado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw New Exception("[ff_Dat.Fc_GetContratistaAdjudicado] - " & ex.Message.ToString)
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_Proyectos(ByVal str_tipo_proyecto As String _
                                         , ByVal str_region_inicio As String _
                                         , ByVal str_region_fin As String _
                                         , ByVal str_estado_inicio As String _
                                         , ByVal str_estado_fin As String _
                                         , ByVal str_proceso_inicio As String _
                                         , ByVal str_proceso_fin As String _
                                         , ByVal str_bd_con_proy As String _
                                         , ByVal str_con_proy As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_proyectos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@str_tipo_proyecto", str_tipo_proyecto)
                oCmd.Parameters.AddWithValue("@str_region_inicio", str_region_inicio)
                oCmd.Parameters.AddWithValue("@str_region_fin", str_region_fin)
                oCmd.Parameters.AddWithValue("@str_estado_inicio", str_estado_inicio)
                oCmd.Parameters.AddWithValue("@str_estado_fin", str_estado_fin)
                oCmd.Parameters.AddWithValue("@str_proceso_inicio", str_proceso_inicio)
                oCmd.Parameters.AddWithValue("@str_proceso_fin", str_proceso_fin)

                oCmd.Parameters.AddWithValue("@str_bd_con_proy", str_bd_con_proy)
                oCmd.Parameters.AddWithValue("@str_con_proy", str_con_proy)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Proyecto_Encabezado(ByVal codigo_pia As String _
                                                   , ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_proyecto_encabezado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Proyecto_Contratos_Relacionados_Encabezado(ByVal codigo_pia As String _
                                                                          , ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_proyecto_contratos_relacionados_encabezado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Proyecto_Contratos_Relacionados_Detalle(ByVal codigo_pia As String _
                                                                       , ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_proyecto_contratos_relacionados_detalle", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try
            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Permisos_usuario(ByVal codigo_tipo_usuario As Long) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_permisos_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Contratos_Encabezado(ByVal codigo_pia As String _
                                                    , ByVal codigo_region As String _
                                                    , ByVal sufijo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_encabezado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Contratos_Detalle_Datos(ByVal codigo_pia As String _
                                                       , ByVal codigo_region As String _
                                                       , ByVal sufijo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_datos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Correlativo_Proceso_Relacionados_Edita(ByVal tipologia As String _
                                                                      , ByVal etapa As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_correlativo_proceso_relacionados_edita", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@tipologia", tipologia)
                oCmd.Parameters.AddWithValue("@etapa", etapa)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Correlativo_Mandantes_Relacionados_Edita(ByVal codigo_pia As String _
                                                                        , ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_correlativo_mandantes_relacionados_edita", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_Correlativo_Etapa_Relacionados_Edita(ByVal codigo_pia As String _
                                                                    , ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_correlativo_etapa_relacionados_edita", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        'Public Function SetGraba_contratos_detalle_imputacion_presup(ByVal codigo_pia As String _
        '                                                            , ByVal codigo_region As String _
        '                                                            , ByVal sufijo As String _
        '                                                            , ByVal Ano As Double _
        '                                                            , ByVal Mandante As String _
        '                                                            , ByVal TipoFondo As String _
        '                                                            , ByVal ResOrig As String _
        '                                                            , ByVal NumeroRes As Double _
        '                                                            , ByVal FechaRes As String _
        '                                                            , ByVal SUBT As String _
        '                                                            , ByVal IT As String _
        '                                                            , ByVal ASIG As String _
        '                                                            , ByVal MontoImputado As Double _
        '                                                            , ByVal Codigo_Contrato As String _
        '                                                            , ByVal llave As String _
        '                                                            ) As DataTable

        '    Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
        '    Dim oConn As New SqlConnection
        '    Dim oCmd As SqlCommand = Nothing
        '    Dim Adp As New SqlDataAdapter
        '    Dim DsSalida As New DataSet
        '    oConn.ConnectionString = ConnectionString
        '    Try
        '        oConn.Open()

        '        oCmd = New SqlCommand("sp_graba_contratos_detalle_imputacion_presup", oConn)
        '        oCmd.CommandType = CommandType.StoredProcedure
        '        oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
        '        oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
        '        oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
        '        oCmd.Parameters.AddWithValue("@sufijo", sufijo)
        '        oCmd.Parameters.AddWithValue("@Ano", Ano)
        '        oCmd.Parameters.AddWithValue("@Mandante", Mandante)
        '        oCmd.Parameters.AddWithValue("@TipoFondo", TipoFondo)
        '        oCmd.Parameters.AddWithValue("@ResOrig", ResOrig)
        '        oCmd.Parameters.AddWithValue("@NumeroRes", NumeroRes)
        '        oCmd.Parameters.AddWithValue("@FechaRes", FechaRes)
        '        oCmd.Parameters.AddWithValue("@SUBT", SUBT)
        '        oCmd.Parameters.AddWithValue("@IT", IT)
        '        oCmd.Parameters.AddWithValue("@ASIG", ASIG)
        '        oCmd.Parameters.AddWithValue("@MontoImputado", MontoImputado)
        '        oCmd.Parameters.AddWithValue("@Codigo_Contrato", Codigo_Contrato)
        '        oCmd.Parameters.AddWithValue("@llave", llave)

        '        Adp.SelectCommand = oCmd
        '        Adp.Fill(DsSalida, "Tabla")
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        oCmd.Dispose()
        '        oConn.Dispose()
        '    End Try

        '    Return DsSalida.Tables(0)
        'End Function


        'Public Function GetBusca_Correlativo_Convenios_Relacionados_Edita(ByVal codigo_pia As String _
        '                                                                , ByVal codigo_region As String) As DataTable

        '    Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
        '    Dim oConn As New SqlConnection
        '    Dim oCmd As SqlCommand = Nothing
        '    Dim Adp As New SqlDataAdapter
        '    Dim DsSalida As New DataSet
        '    oConn.ConnectionString = ConnectionString
        '    Try
        '        oConn.Open()

        '        oCmd = New SqlCommand("sp_busca_correlativo_convenios_relacionados_edita", oConn)
        '        oCmd.CommandType = CommandType.StoredProcedure
        '        oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
        '        oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
        '        oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

        '        Adp.SelectCommand = oCmd
        '        Adp.Fill(DsSalida, "Tabla")
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        oCmd.Dispose()
        '        oConn.Dispose()
        '    End Try

        '    Return DsSalida.Tables(0)

        'End Function


        Public Function GetBusca_Datos_Usuario(ByVal usuario As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_datos_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@usuario", usuario)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        'JGM 20121125
        Public Function GetBusca_Provincia(ByVal Region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Busca_Provincia", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", Region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetGraba_Contratos_Detalle_Datos(ByVal codigo_pia As String _
                                                       , ByVal codigo_region As String _
                                                       , ByVal sufijo As String _
                                                       , ByVal strlegal As String _
                                                       , ByVal strambiental As String _
                                                       , ByVal strexpropiacion As String _
                                                       , ByVal strlicitacion As String _
                                                       , ByVal strejecucion As String _
                                                       , ByVal straumento_costos As String _
                                                       , ByVal strexplicacion_o_alertas As String _
                                                       , ByVal strapertura_licitacion As String _
                                                       , ByVal strprimera_piedra As String _
                                                       , ByVal strINAUGURACION As String _
                                                       , ByVal intProximo_Hito As String _
                                                       , ByVal strObservacionMandante As String _
                                                       , ByVal strResp_Administrativo As String) As Integer

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim oSalida As Integer

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_datos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@strLEGAL", strlegal)
                oCmd.Parameters.AddWithValue("@strAMBIENTAL", strambiental)
                oCmd.Parameters.AddWithValue("@strEXPROPIACION", strexpropiacion)
                oCmd.Parameters.AddWithValue("@strLICITACION", strlicitacion)
                oCmd.Parameters.AddWithValue("@strEJECUCION", strejecucion)
                oCmd.Parameters.AddWithValue("@strAUMENTO_COSTOS", straumento_costos)
                oCmd.Parameters.AddWithValue("@strEXPLICACION_O_ALERTAS", strexplicacion_o_alertas)
                oCmd.Parameters.AddWithValue("@strAPERTURA_LICITACION", strapertura_licitacion)
                oCmd.Parameters.AddWithValue("@strPRIMERA_PIEDRA", strprimera_piedra)
                oCmd.Parameters.AddWithValue("@strINAUGURACION", strINAUGURACION)
                oCmd.Parameters.AddWithValue("@intProximo_Hito", intProximo_Hito)
                oCmd.Parameters.AddWithValue("@strOBSERVACIONMANDANTE", strObservacionMandante)
                oCmd.Parameters.AddWithValue("@strResp_Administrativo", strResp_Administrativo)
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return oSalida
        End Function

        Public Function SetGraba_Contratos_Detalle_Edicion(ByVal codigo_pia As String _
                                                         , ByVal codigo_region As String _
                                                         , ByVal sufijo As String _
                                                         , ByVal numcorrelativo_convenio As String _
                                                         , ByVal strmandante_convenio As String _
                                                         , ByVal stretapa As String _
                                                         , ByVal strtipo_proceso As String _
                                                         , ByVal strfinanciamiento As String _
                                                         , ByVal strobjeto As String) As Integer

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim oSalida As Integer

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_edicion", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@numCORRELATIVO_CONVENIO", numcorrelativo_convenio)
                oCmd.Parameters.AddWithValue("@strMANDANTE_CONVENIO", strmandante_convenio)
                oCmd.Parameters.AddWithValue("@strETAPA", stretapa)
                oCmd.Parameters.AddWithValue("@strTIPO_PROCESO", strtipo_proceso)
                oCmd.Parameters.AddWithValue("@strFINANCIAMIENTO", strfinanciamiento)
                oCmd.Parameters.AddWithValue("@strOBJETO", strobjeto)

                oSalida = oCmd.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return oSalida
        End Function

        Public Function SetMnt_Comunas(ByVal accion As String _
                                     , ByVal region As String _
                                     , ByVal provincia As String _
                                     , ByVal comuna As String _
                                     , ByVal cod_comun As String _
                                     , ByVal n_comu As String _
                                     , ByVal poblacion As Long) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_comunas", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@provincia", provincia)
                oCmd.Parameters.AddWithValue("@comuna", comuna)
                oCmd.Parameters.AddWithValue("@cod_comun", cod_comun)
                oCmd.Parameters.AddWithValue("@n_comu", n_comu)
                oCmd.Parameters.AddWithValue("@poblacion", poblacion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function





        Public Function SetMnt_Dom_Insp_Fis(ByVal accion As String _
                                          , ByVal rut As String _
                                          , ByVal nombre As String _
                                          , ByVal profesion As String _
                                          , ByVal sexo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_dom_insp_fis", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@rut", rut)
                oCmd.Parameters.AddWithValue("@nombre", nombre)
                oCmd.Parameters.AddWithValue("@profesion", profesion)
                oCmd.Parameters.AddWithValue("@sexo", sexo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetMnt_Dom_Mandante(ByVal accion As String _
                                          , ByVal sigla As String _
                                          , ByVal descripcion As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_dom_mandante", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@sigla", sigla)
                oCmd.Parameters.AddWithValue("@descripcion", descripcion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetMnt_Permisos_Usuario(ByVal accion As String _
                                              , ByVal codigo_tipo_usuario As Long _
                                              , ByVal codigo_opcion As Long _
                                              , ByVal asignar As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_permisos_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)
                oCmd.Parameters.AddWithValue("@codigo_opcion", codigo_opcion)
                oCmd.Parameters.AddWithValue("@asignar", asignar)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetMnt_Usuario(ByVal accion As String _
                                     , ByVal nombre_usuario As String _
                                     , ByVal correo_electronico As String _
                                     , ByVal codigo_tipo_usuario As Long _
                                     , ByVal nombre_completo As String _
                                     , ByVal nombre_usuario_corto As String _
                                     , ByVal region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@nombre_usuario", nombre_usuario)
                oCmd.Parameters.AddWithValue("@correo_electronico", correo_electronico)
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)
                oCmd.Parameters.AddWithValue("@nombre_completo", nombre_completo)

                oCmd.Parameters.AddWithValue("@nombre_usuario_corto", nombre_usuario_corto)
                oCmd.Parameters.AddWithValue("@region", region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetValida_Acceso_Menu_Usuario(ByVal codigo_tipo_usuario As Long _
                                                    , ByVal opcion_menu As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_valida_acceso_menu_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)
                oCmd.Parameters.AddWithValue("@opcion_menu", opcion_menu)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetValida_Login_Usuario(ByVal usuario As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_valida_login_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@usuario", usuario)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetMnt_Contratista(ByVal accion As String _
                                         , ByVal rut_ctta As String _
                                         , ByVal n_ctta As String _
                                         , ByVal registro As String _
                                         , ByVal categoria As String _
                                         , ByVal telefono_fax As String _
                                         , ByVal sexo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_contratistas", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@rut_ctta", rut_ctta)
                oCmd.Parameters.AddWithValue("@n_ctta", n_ctta)
                oCmd.Parameters.AddWithValue("@registro", registro)
                oCmd.Parameters.AddWithValue("@categoria", categoria)
                oCmd.Parameters.AddWithValue("@telefono_fax", telefono_fax)
                oCmd.Parameters.AddWithValue("@sexo", sexo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Private Function ConvertDate(ByVal value As String) As Date

            If Not value.Length = 8 Then
                Throw New ArgumentException("Fecha inválida, debe venir en formato YYYYMMDD")
            End If

            If Not IsNumeric(value) Then
                Throw New ArgumentException("Fecha inválida, debe venir en formato YYYYMMDD")
            End If

            Dim theYear As String = value.Substring(0, 4)
            Dim theMonth As String = value.Substring(4, 2)
            Dim theDay As String = value.Substring(6, 2)
            Dim result As String = theDay & "/" & theMonth & "/" & theYear

            If Not IsDate(result) Then
                Throw New ArgumentException("Fecha inválida, debe venir en formato YYYYMMDD")
            End If

            Return CDate(result)

        End Function

        'JGM 20121127
        Public Function GetContratosPropuestas(ByVal REGION As String _
                                             , ByVal CODIGO_DA As String _
                                             , ByVal SUFIJO As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Busca_Contrato_Propuesta", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121127
        Public Function GetOfertasPropuestaContratista(ByVal REGION As String _
                                                     , ByVal CODIGO_DA As String _
                                                     , ByVal SUFIJO As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_ofertas_propuesta_contratistas", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121127
        Public Function GetDomMandantes2(ByVal REGION As String _
                                      , ByVal CODIGO_DA As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_dom_mandante2", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121127
        Public Function SetMandantesContrato(ByVal MANDANTE As String _
                                          , ByVal REGION As String _
                                          , ByVal CODIGO_DA As String _
                                          , ByVal SUFIJO As String _
                                          , ByVal COD_CON As String _
                                          ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_mandantes_del_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@MANDANTE", MANDANTE)
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                'oCmd.Parameters.AddWithValue("@FECHA_INGRESO", FECHA_INGRESO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121127
        Public Function SetContratoPropuesta(ByVal REGION As String _
                                            , ByVal CODIGO_DA As String _
                                            , ByVal SUFIJO As String _
                                            , ByVal T_F1 As String _
                                            , ByVal PROVINCIA As String _
                                            , ByVal COMUNA As String _
                                            , ByVal CODIGO_LOCALIDAD As Long _
                                            , ByVal TIPO_PROCESO As String _
                                            , ByVal OBJETO As String _
                                            , ByVal LOCALIZACION As String _
                                            , ByVal NUMERO_LOCALIZACION As String _
                                            , ByVal MANDANTE_CONVENIO As String _
                                            , ByVal CORRELATIVO_CONVENIO As Integer _
                                            , ByVal ESTATUS As String _
                                            , ByVal VALIDO As Integer _
                                            , ByVal TI_LIC As String _
                                            , ByVal TI_CON As String _
                                            , ByVal TIPO_REAJUSTE As String _
                                            , ByVal FECHA_LIC_PR As String _
                                            , ByVal FECHA_AP_ESTIMADA As String _
                                            , ByVal FECHA_AP_PR As String _
                                            , ByVal FECHA_AP_PR_ECO As String _
                                            , ByVal FECHA_INICIO_ESTIMADA As String _
                                            , ByVal BASES_ADMIN_GENERALES As String _
                                            , ByVal BASES_ADMIN_ESPECIALES As String _
                                            , ByVal BASES_TECNICAS As String _
                                            , ByVal CARPETA_TECNICA_LICITACION As String _
                                            , ByVal REGISTRO As String _
                                            , ByVal CATEGORIA As String _
                                            , ByVal MONTO_PROGRA As Double _
                                            , ByVal PLAZO_ESTIMADO_EJEC As Integer _
                                            , ByVal RESP_ANTECEDENTES_PPTA As String _
                                            , ByVal ANTICIPO_CONTEMPLADO As Double _
                                            , ByVal ANTIC_CONTEMPL_PORC As Double _
                                            , ByVal APLICA_CARTILLA_R_26 As String _
                                            , ByVal FECHA_DOCTO_R26 As String _
                                            , ByVal APLICA_CARTILLA_R_28 As String _
                                            , ByVal FECHA_DOCTO_R28 As String _
                                            , ByVal APLICA_CARTILLA_R_29 As String _
                                            , ByVal FECHA_DOCTO_R29 As String _
                                            , ByVal REQUIERE_REG_ESPECIAL As String _
                                            , ByVal N_PERMISO_EDIFICACION As String _
                                            , ByVal FECHA_PERMISO_EDIFICACION As String _
                                            , ByVal id_chile_compra As String _
                                            , ByVal ces As String _
                                            , ByVal N_DOCTO_R5 As Long _
                                            , ByVal FECHA_DOCTO_R5 As String _
                                            , ByVal FECHA_LIC As String _
                                            , ByVal F_AP_TECNICA_PROP As String _
                                            , ByVal F_AP_PROP As String _
                                            , ByVal PLAZO_OFICIAL As Integer _
                                            , ByVal MT_OFI As Double _
                                            , ByVal OBSERVACIONES_PROP As String _
                                            , ByVal RESULTADO_PROPUESTA As String _
                                            , ByVal RESP_LCITACION As String _
                                            , ByVal LLAMADO As Integer _
                                            , ByVal n_res_no_adjudica As Integer _
                                            , ByVal f_res_no_adjudica As String _
                                            , ByVal FECHA_INFORME_ADJUDICACION As String _
                                            , ByVal MTO_OR As Double _
                                            , ByVal PLAZO_OR As Double _
                                            , ByVal OR_RES As String _
                                            , ByVal N_RES As Integer _
                                            , ByVal F_RES As String _
                                            , ByVal F_TRAMI As String _
                                            , ByVal RUT_CON As String _
                                            , ByVal COM_EVAL_OFERTA1 As String _
                                            , ByVal COM_EVAL_OFERTA2 As String _
                                            , ByVal COM_EVAL_OFERTA3 As String _
                                            , ByVal adjudicado As String _
                                            , ByVal SECCION As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Grabar_Contrato_Propuesta", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)
                oCmd.Parameters.AddWithValue("@T_F1", T_F1)
                oCmd.Parameters.AddWithValue("@PROVINCIA", PROVINCIA)
                oCmd.Parameters.AddWithValue("@COMUNA", COMUNA)
                oCmd.Parameters.AddWithValue("@CODIGO_LOCALIDAD", CODIGO_LOCALIDAD)
                oCmd.Parameters.AddWithValue("@TIPO_PROCESO", TIPO_PROCESO)
                oCmd.Parameters.AddWithValue("@OBJETO", OBJETO)
                oCmd.Parameters.AddWithValue("@LOCALIZACION", LOCALIZACION)
                oCmd.Parameters.AddWithValue("@NUMERO_LOCALIZACION", NUMERO_LOCALIZACION)
                oCmd.Parameters.AddWithValue("@MANDANTE_CONVENIO", MANDANTE_CONVENIO)
                oCmd.Parameters.AddWithValue("@CORRELATIVO_CONVENIO", CORRELATIVO_CONVENIO)
                oCmd.Parameters.AddWithValue("@ESTATUS", ESTATUS)
                oCmd.Parameters.AddWithValue("@VALIDO", VALIDO)
                oCmd.Parameters.AddWithValue("@TI_LIC", TI_LIC)
                oCmd.Parameters.AddWithValue("@TI_CON", TI_CON)
                oCmd.Parameters.AddWithValue("@TIPO_REAJUSTE", TIPO_REAJUSTE)
                oCmd.Parameters.AddWithValue("@FECHA_LIC_PR", FECHA_LIC_PR)
                oCmd.Parameters.AddWithValue("@FECHA_AP_ESTIMADA", FECHA_AP_ESTIMADA)
                oCmd.Parameters.AddWithValue("@FECHA_AP_PR", FECHA_AP_PR)
                oCmd.Parameters.AddWithValue("@FECHA_AP_PR_ECO", FECHA_AP_PR_ECO)
                oCmd.Parameters.AddWithValue("@FECHA_INICIO_ESTIMADA", FECHA_INICIO_ESTIMADA)
                oCmd.Parameters.AddWithValue("@BASES_ADMIN_GENERALES", BASES_ADMIN_GENERALES)
                oCmd.Parameters.AddWithValue("@BASES_ADMIN_ESPECIALES", BASES_ADMIN_ESPECIALES)
                oCmd.Parameters.AddWithValue("@BASES_TECNICAS", BASES_TECNICAS)
                oCmd.Parameters.AddWithValue("@CARPETA_TECNICA_LICITACION", CARPETA_TECNICA_LICITACION)
                oCmd.Parameters.AddWithValue("@REGISTRO", REGISTRO)
                oCmd.Parameters.AddWithValue("@CATEGORIA", CATEGORIA)
                oCmd.Parameters.AddWithValue("@MONTO_PROGRA", MONTO_PROGRA)
                oCmd.Parameters.AddWithValue("@PLAZO_ESTIMADO_EJEC", PLAZO_ESTIMADO_EJEC)
                oCmd.Parameters.AddWithValue("@RESP_ANTECEDENTES_PPTA", RESP_ANTECEDENTES_PPTA)
                oCmd.Parameters.AddWithValue("@ANTICIPO_CONTEMPLADO", ANTICIPO_CONTEMPLADO)
                oCmd.Parameters.AddWithValue("@ANTIC_CONTEMPL_PORC", ANTIC_CONTEMPL_PORC)
                oCmd.Parameters.AddWithValue("@APLICA_CARTILLA_R_26", APLICA_CARTILLA_R_26)
                oCmd.Parameters.AddWithValue("@FECHA_DOCTO_R26", FECHA_DOCTO_R26)
                oCmd.Parameters.AddWithValue("@APLICA_CARTILLA_R_28", APLICA_CARTILLA_R_28)
                oCmd.Parameters.AddWithValue("@FECHA_DOCTO_R28", FECHA_DOCTO_R28)
                oCmd.Parameters.AddWithValue("@APLICA_CARTILLA_R_29", APLICA_CARTILLA_R_29)
                oCmd.Parameters.AddWithValue("@FECHA_DOCTO_R29", FECHA_DOCTO_R29)
                oCmd.Parameters.AddWithValue("@REQUIERE_REG_ESPECIAL", REQUIERE_REG_ESPECIAL)
                oCmd.Parameters.AddWithValue("@N_PERMISO_EDIFICACION", N_PERMISO_EDIFICACION)
                oCmd.Parameters.AddWithValue("@FECHA_PERMISO_EDIFICACION", FECHA_PERMISO_EDIFICACION)
                oCmd.Parameters.AddWithValue("@id_chile_compra", id_chile_compra)
                oCmd.Parameters.AddWithValue("@ces", ces)
                oCmd.Parameters.AddWithValue("@N_DOCTO_R5", N_DOCTO_R5)
                oCmd.Parameters.AddWithValue("@FECHA_DOCTO_R5", FECHA_DOCTO_R5)
                oCmd.Parameters.AddWithValue("@FECHA_LIC", FECHA_LIC)
                oCmd.Parameters.AddWithValue("@F_AP_TECNICA_PROP", F_AP_TECNICA_PROP)
                oCmd.Parameters.AddWithValue("@F_AP_PROP", F_AP_PROP)
                oCmd.Parameters.AddWithValue("@PLAZO_OFICIAL", PLAZO_OFICIAL)
                oCmd.Parameters.AddWithValue("@MT_OFI", MT_OFI)
                oCmd.Parameters.AddWithValue("@OBSERVACIONES_PROP", OBSERVACIONES_PROP)
                oCmd.Parameters.AddWithValue("@RESULTADO_PROPUESTA", RESULTADO_PROPUESTA)
                oCmd.Parameters.AddWithValue("@RESP_LCITACION", RESP_LCITACION)
                oCmd.Parameters.AddWithValue("@LLAMADO", LLAMADO)
                oCmd.Parameters.AddWithValue("@n_res_no_adjudica", n_res_no_adjudica)
                oCmd.Parameters.AddWithValue("@f_res_no_adjudica", f_res_no_adjudica)
                oCmd.Parameters.AddWithValue("@FECHA_INFORME_ADJUDICACION", FECHA_INFORME_ADJUDICACION)
                oCmd.Parameters.AddWithValue("@MTO_OR", MTO_OR)
                oCmd.Parameters.AddWithValue("@PLAZO_OR", PLAZO_OR)
                oCmd.Parameters.AddWithValue("@OR_RES", OR_RES)
                oCmd.Parameters.AddWithValue("@N_RES", N_RES)
                oCmd.Parameters.AddWithValue("@F_RES", F_RES)
                oCmd.Parameters.AddWithValue("@F_TRAMI", F_TRAMI)
                oCmd.Parameters.AddWithValue("@RUT_CON", RUT_CON)
                oCmd.Parameters.AddWithValue("@COM_EVAL_OFERTA1", COM_EVAL_OFERTA1)
                oCmd.Parameters.AddWithValue("@COM_EVAL_OFERTA2", COM_EVAL_OFERTA2)
                oCmd.Parameters.AddWithValue("@COM_EVAL_OFERTA3", COM_EVAL_OFERTA3)
                oCmd.Parameters.AddWithValue("@adjudicado", adjudicado)
                oCmd.Parameters.AddWithValue("@SECCION", SECCION)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121127
        Public Function SetOfertasPropuestas(ByVal REGION As String _
                                            , ByVal CODIGO_DA As String _
                                            , ByVal SUFIJO As String _
                                            , ByVal RUT_CTTA As String _
                                            , ByVal DESCRIPCION As String _
                                            , ByVal MONTO As Double _
                                            , ByVal PLAZO As Integer _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_ofertas_propuesta", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)
                oCmd.Parameters.AddWithValue("@RUT_CTTA", RUT_CTTA)
                oCmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION)
                oCmd.Parameters.AddWithValue("@MONTO", MONTO)
                oCmd.Parameters.AddWithValue("@PLAZO", PLAZO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121129
        Public Function SetGrabaProceso_ssd(ByVal accion As String _
                                            , ByVal tipo As String _
                                            , ByVal cod_con As String _
                                            , ByVal sufijo As String _
                                            , ByVal codigo_da As String _
                                            , ByVal region As String _
                                            , ByVal numero_proceso As String _
                                            , ByVal descripcion As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabaproceso_ssd", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@tipo", tipo)
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@numero_proceso", numero_proceso)
                oCmd.Parameters.AddWithValue("@descripcion", descripcion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121129
        Public Function GetBuscaProceso_ssd(ByVal tipo As String _
                                            , ByVal cod_con As String _
                                            , ByVal sufijo As String _
                                            , ByVal codigo_da As String _
                                            , ByVal region As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_buscaproceso_ssd", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@tipo", tipo)
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@region", region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function


        'JGM 20121128
        Public Function GetBuscaDomTiposEtapa(ByVal typologia As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_dom_tipos_etapa", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@typologia", typologia)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121128
        Public Function SetGrabaEtapa(ByVal REGION As String _
                                    , ByVal CODIGO_DA As String _
                                    , ByVal ETAPA As String _
                                    , ByVal CODIGO_BIP As String _
                                    , ByVal PARTE As String _
                                    , ByVal MONTO_ETAPA As Double _
                                    , ByVal DESCRIPCION As String _
                                    , ByVal FECHA_INGRESO As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Grabar_ETAPA", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@ETAPA", ETAPA)
                oCmd.Parameters.AddWithValue("@CODIGO_BIP", CODIGO_BIP)
                oCmd.Parameters.AddWithValue("@PARTE", PARTE)
                oCmd.Parameters.AddWithValue("@MONTO_ETAPA", MONTO_ETAPA)
                oCmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION)
                oCmd.Parameters.AddWithValue("@FECHA_INGRESO", FECHA_INGRESO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121128
        Public Function GetBuscaConveniosModif(ByVal region As String _
                                             , ByVal codigo_da As String _
                                             , ByVal mandante As String _
                                             ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_convenios_modif_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121128
        Public Function SetGrabarConveniosModif(ByVal region As String _
                                                , ByVal codigo_da As String _
                                                , ByVal mandante As String _
                                                , ByVal fecha_decreto As String _
                                                , ByVal correlativo As Integer _
                                                , ByVal num_decreto As Integer _
                                                , ByVal fecha_convenio As String _
                                                , ByVal fecha_ingreso As String _
                                                , ByVal monto_neto_mod As Double _
                                                , ByVal gasto_adm_mod As Double _
                                                , ByVal consul_mod As Double _
                                                , ByVal otros_gastos_mod As Double _
                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_convenios_modif", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@fecha_decreto", fecha_decreto)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)
                oCmd.Parameters.AddWithValue("@num_decreto", num_decreto)
                oCmd.Parameters.AddWithValue("@fecha_convenio", fecha_convenio)
                oCmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso)
                oCmd.Parameters.AddWithValue("@monto_neto_mod", monto_neto_mod)
                oCmd.Parameters.AddWithValue("@gasto_adm_mod", gasto_adm_mod)
                oCmd.Parameters.AddWithValue("@consul_mod", consul_mod)
                oCmd.Parameters.AddWithValue("@otros_gastos_mod", otros_gastos_mod)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121129
        Public Function GetBuscaEtapa(ByVal region As String _
                                    , ByVal codigo_da As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_etapa", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        ''JGM 20121129
        'Public Function SetGrabaProceso_ssd(ByVal cod_con As String _
        '                                    , ByVal numero_proceso As String _
        '                                    ) As DataTable

        '    Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
        '    Dim oConn As New SqlConnection
        '    Dim oCmd As SqlCommand = Nothing
        '    Dim Adp As New SqlDataAdapter
        '    Dim DsSalida As New DataSet
        '    oConn.ConnectionString = ConnectionString
        '    Try
        '        oConn.Open()

        '        oCmd = New SqlCommand("sp_graba_proceso_ssd", oConn)
        '        oCmd.CommandType = CommandType.StoredProcedure
        '        oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
        '        oCmd.Parameters.AddWithValue("@cod_con", cod_con)
        '        oCmd.Parameters.AddWithValue("@numero_proceso", numero_proceso)

        '        Adp.SelectCommand = oCmd
        '        Adp.Fill(DsSalida, "Tabla")
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        oCmd.Dispose()
        '        oConn.Dispose()
        '    End Try

        '    Return DsSalida.Tables(0)
        'End Function

        ''JGM 20121129
        Public Function GetBuscaConvenios(ByVal region As String _
                                        , ByVal codigo_da As String _
                                        , ByVal mandante As String _
                                        , ByVal correlativo As Integer _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_convenios", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        ''JGM 20121129
        Public Function SetGrabaConvenio(ByVal region As String _
                                       , ByVal codigo_da As String _
                                       , ByVal mandante As String _
                                       , ByVal correlativo As Long _
                                       , ByVal etapa As String _
                                       , ByVal num_decreto As Long _
                                       , ByVal fecha_decreto As String _
                                       , ByVal tipo_convenio As String _
                                       , ByVal fecha_convenio As String _
                                       , ByVal monto_neto As Double _
                                       , ByVal gastos_administrativos As Double _
                                       , ByVal consul As Double _
                                       , ByVal descripcion As String _
                                       , ByVal fecha_ingreso As String _
                                       , ByVal estado_convenio As String _
                                       , ByVal observacion As String _
                                       , ByVal fecha_liquidacion As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_convenios", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)
                oCmd.Parameters.AddWithValue("@etapa", etapa)
                oCmd.Parameters.AddWithValue("@num_decreto", num_decreto)
                oCmd.Parameters.AddWithValue("@fecha_decreto", fecha_decreto)
                oCmd.Parameters.AddWithValue("@tipo_convenio", tipo_convenio)
                oCmd.Parameters.AddWithValue("@fecha_convenio", fecha_convenio)
                oCmd.Parameters.AddWithValue("@monto_neto", monto_neto)
                oCmd.Parameters.AddWithValue("@gastos_administrativos", gastos_administrativos)
                oCmd.Parameters.AddWithValue("@consul", consul)
                oCmd.Parameters.AddWithValue("@descripcion", descripcion)
                oCmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso)
                oCmd.Parameters.AddWithValue("@estado_convenio", estado_convenio)
                oCmd.Parameters.AddWithValue("@observacion", observacion)
                oCmd.Parameters.AddWithValue("@fecha_liquidacion", fecha_liquidacion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121129
        Public Function GetBuscaDetalleProyecto(ByVal region As String _
                                              , ByVal codigo_da As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_busca_detalle_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'JGM 20121129
        Public Function SetGrabaDetalleProyecto(ByVal region As String, _
                                                  ByVal codigo_da As String _
                                                , ByVal plan As Long _
                                                , ByVal proceso As String _
                                                , ByVal objeto As String _
                                                , ByVal codigo_bip As String _
                                                , ByVal monto_estimado_idea As Double _
                                                , ByVal responsable_idea As String _
                                                , ByVal responsable_convenio As String _
                                                , ByVal parte_bip As String _
                                                , ByVal provincia As String _
                                                , ByVal comuna As String _
                                                , ByVal ubicacion As String _
                                                , ByVal terreno_numero_certif As Long _
                                                , ByVal terreno_fecha_certificado As String _
                                                , ByVal descripcion_proyecto As String _
                                                , ByVal factibilidad_electrica As Integer _
                                                , ByVal factibilidad_agua As Integer _
                                                , ByVal factibilidad_alcantarillado As Integer _
                                                , ByVal condiciones_tecnicas As String _
                                                , ByVal terreno_observaciones As String _
                                                , ByVal sector_destino As String _
                                                , ByVal sub_sector As String _
                                                , ByVal tipologia As String _
                                                , ByVal fecha_estado As String _
                                                , ByVal estado As String _
                                                , ByVal tipo_proy As String _
                                                , ByVal fecha_evaluacion As String _
                                                , ByVal monto_estimado As Double _
                                                , ByVal beneficio As String _
                                                , ByVal propiedad As String _
                                                , ByVal superficie As Double _
                                                , ByVal programa_inicial As Double _
                                                , ByVal programa_final As Double _
                                                , ByVal m2_arquitectura As Double _
                                                , ByVal profesional_arquitectura As String _
                                                , ByVal m2_ingenieria As Double _
                                                , ByVal profesional_ingenieria As String _
                                                , ByVal obras_complementarias As Integer _
                                                , ByVal fecha_ingreso As String _
                                                , ByVal fecha_termino_proyecto As String _
                                                , ByVal fecha_liquidacion_proyecto As String _
                                                , ByVal coordenadas As String _
                                                , ByVal usuarios As Long _
                                                , ByVal beneficiarios As Long _
                                                , ByVal patrimonial As String _
                                                , ByVal oficio_apoyo As String _
                                                , ByVal fecha_oficio_apoyo As String _
                                                , ByVal f_i_a_t As String _
                                                , ByVal f_t_a_t_estimada As String _
                                                , ByVal f_t_a_t As String _
                                                , ByVal resp_at As String _
                                                , ByVal producto As String _
                                                , ByVal fondo As String _
                                                , ByVal f_hito As String _
                                                , ByVal seguimiento_p As String _
                                                , ByVal tipo_apoyo_tecnico As String _
                                                , ByVal tipo_ase As Long _
                                                , ByVal proteccion_patrimonial As String _
                                                , ByVal material As Long _
                                                , ByVal rate As String _
                                                , ByVal etapa_idea As Long _
                                                , ByVal codigo_proyecto_exp As String _
                                                , ByRef fecha_est_firma_convenio As String _
                                                , ByRef fecha_est_publicacion As String _
                                                , ByRef fecha_est_inicio As String _
                                                , ByRef fecha_est_termino As String _
                                                , ByRef codigo_prigrh As String _
                                                , ByRef modalidad As String _
                                                , ByRef reajuste As String _
                                                , ByRef ces As String _
                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Grabar_detalle_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@plan", plan)
                oCmd.Parameters.AddWithValue("@proceso", proceso)
                oCmd.Parameters.AddWithValue("@objeto", objeto)
                oCmd.Parameters.AddWithValue("@codigo_bip", codigo_bip)
                oCmd.Parameters.AddWithValue("@monto_estimado_idea", monto_estimado_idea)
                oCmd.Parameters.AddWithValue("@responsable_idea", responsable_idea)
                oCmd.Parameters.AddWithValue("@responsable_convenio", responsable_convenio)
                oCmd.Parameters.AddWithValue("@parte_bip", parte_bip)
                oCmd.Parameters.AddWithValue("@provincia", provincia)
                oCmd.Parameters.AddWithValue("@comuna", comuna)
                oCmd.Parameters.AddWithValue("@ubicacion", ubicacion)
                oCmd.Parameters.AddWithValue("@terreno_numero_certif", terreno_numero_certif)
                oCmd.Parameters.AddWithValue("@terreno_fecha_certificado", terreno_fecha_certificado)
                oCmd.Parameters.AddWithValue("@descripcion_proyecto", descripcion_proyecto)
                oCmd.Parameters.AddWithValue("@factibilidad_electrica", factibilidad_electrica)
                oCmd.Parameters.AddWithValue("@factibilidad_agua", factibilidad_agua)
                oCmd.Parameters.AddWithValue("@factibilidad_alcantarillado", factibilidad_alcantarillado)
                oCmd.Parameters.AddWithValue("@condiciones_tecnicas", condiciones_tecnicas)
                oCmd.Parameters.AddWithValue("@terreno_observaciones", terreno_observaciones)
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)
                oCmd.Parameters.AddWithValue("@sub_sector", sub_sector)
                oCmd.Parameters.AddWithValue("@tipologia", tipologia)
                oCmd.Parameters.AddWithValue("@fecha_estado", fecha_estado)
                oCmd.Parameters.AddWithValue("@estado", estado)
                oCmd.Parameters.AddWithValue("@tipo_proy", tipo_proy)
                oCmd.Parameters.AddWithValue("@fecha_evaluacion", fecha_evaluacion)
                oCmd.Parameters.AddWithValue("@monto_estimado", monto_estimado)
                oCmd.Parameters.AddWithValue("@beneficio", beneficio)
                oCmd.Parameters.AddWithValue("@propiedad", propiedad)
                oCmd.Parameters.AddWithValue("@superficie", superficie)
                oCmd.Parameters.AddWithValue("@programa_inicial", programa_inicial)
                oCmd.Parameters.AddWithValue("@programa_final", programa_final)
                oCmd.Parameters.AddWithValue("@m2_arquitectura", m2_arquitectura)
                oCmd.Parameters.AddWithValue("@profesional_arquitectura", profesional_arquitectura)
                oCmd.Parameters.AddWithValue("@m2_ingenieria", m2_ingenieria)
                oCmd.Parameters.AddWithValue("@profesional_ingenieria", profesional_ingenieria)
                oCmd.Parameters.AddWithValue("@obras_complementarias", obras_complementarias)
                oCmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso)
                oCmd.Parameters.AddWithValue("@fecha_termino_proyecto", fecha_termino_proyecto)
                oCmd.Parameters.AddWithValue("@fecha_liquidacion_proyecto", fecha_liquidacion_proyecto)
                oCmd.Parameters.AddWithValue("@coordenadas", coordenadas)
                oCmd.Parameters.AddWithValue("@usuarios", usuarios)
                oCmd.Parameters.AddWithValue("@beneficiarios", beneficiarios)
                oCmd.Parameters.AddWithValue("@patrimonial", patrimonial)
                oCmd.Parameters.AddWithValue("@oficio_apoyo", oficio_apoyo)
                oCmd.Parameters.AddWithValue("@fecha_oficio_apoyo", fecha_oficio_apoyo)
                oCmd.Parameters.AddWithValue("@f_i_a_t", f_i_a_t)
                oCmd.Parameters.AddWithValue("@f_t_a_t_estimada", f_t_a_t_estimada)
                oCmd.Parameters.AddWithValue("@f_t_a_t", f_t_a_t)
                oCmd.Parameters.AddWithValue("@resp_at", resp_at)
                oCmd.Parameters.AddWithValue("@producto", producto)
                oCmd.Parameters.AddWithValue("@fondo", fondo)
                oCmd.Parameters.AddWithValue("@f_hito", f_hito)
                oCmd.Parameters.AddWithValue("@seguimiento_p", seguimiento_p)
                oCmd.Parameters.AddWithValue("@tipo_apoyo_tecnico", tipo_apoyo_tecnico)
                oCmd.Parameters.AddWithValue("@tipo_ase", tipo_ase)
                oCmd.Parameters.AddWithValue("@proteccion_patrimonial", proteccion_patrimonial)
                oCmd.Parameters.AddWithValue("@material", material)
                oCmd.Parameters.AddWithValue("@rate", rate)
                oCmd.Parameters.AddWithValue("@etapa_idea", etapa_idea)
                oCmd.Parameters.AddWithValue("@codigo_proyecto_exp", codigo_proyecto_exp)
                oCmd.Parameters.AddWithValue("@fecha_est_firma_convenio", fecha_est_firma_convenio)
                oCmd.Parameters.AddWithValue("@fecha_est_publicacion", fecha_est_publicacion)
                oCmd.Parameters.AddWithValue("@fecha_est_inicio", fecha_est_inicio)
                oCmd.Parameters.AddWithValue("@fecha_est_termino", fecha_est_termino)
                oCmd.Parameters.AddWithValue("@codigo_prigrh", codigo_prigrh)
                oCmd.Parameters.AddWithValue("@modalidad", modalidad)
                oCmd.Parameters.AddWithValue("@reajuste", reajuste)
                oCmd.Parameters.AddWithValue("@cess", ces)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_grabar_convenios_modif_proyecto(ByRef region As String, _
                                                  ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef fecha_decreto As String _
                                                , ByRef correlativo As Double _
                                                , ByRef num_decreto As String _
                                                , ByRef fecha_convenio As String _
                                                , ByRef fecha_ingreso As String _
                                                , ByRef monto_neto_mod As String _
                                                , ByRef gasto_adm_mod As String _
                                                , ByRef consul_mod As String _
                                                , ByRef otros_gastos_mod As String _
                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_convenios_modif_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@fecha_decreto", fecha_decreto)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)
                oCmd.Parameters.AddWithValue("@num_decreto", num_decreto)
                oCmd.Parameters.AddWithValue("@fecha_convenio", fecha_convenio)
                oCmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso)
                oCmd.Parameters.AddWithValue("@monto_neto_mod", monto_neto_mod)
                oCmd.Parameters.AddWithValue("@gasto_adm_mod", gasto_adm_mod)
                oCmd.Parameters.AddWithValue("@consul_mod", consul_mod)
                oCmd.Parameters.AddWithValue("@otros_gastos_mod", otros_gastos_mod)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_eliminar_convenios_modif_proyecto(ByRef region As String, _
                                          ByRef codigo_da As String _
                                        , ByRef mandante As String _
                                        , ByRef correlativo As String _
                                        , ByRef fecha_decreto As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_eliminar_convenios_modif_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)
                oCmd.Parameters.AddWithValue("@fecha_decreto", fecha_decreto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_convenios_proyecto(ByVal region As String _
                                       , ByVal codigo_da As String _
                                       ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_convenios_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_mandantes_proyecto(ByVal region As String _
                                       , ByVal codigo_da As String _
                                       ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_mandantes_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_grabar_convenios_proyecto(ByRef region As String, _
                                                  ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef correlativo As Double _
                                                , ByRef etapa As String _
                                                , ByRef num_decreto As String _
                                                , ByRef fecha_decreto As String _
                                                , ByRef tipo_convenio As String _
                                                , ByRef fecha_convenio As String _
                                                , ByRef monto_neto As String _
                                                , ByRef gastos_administrativos As String _
                                                , ByRef consul As String _
                                                , ByRef otros_gastos As String _
                                                , ByRef descripcion As String _
                                                , ByRef fecha_ingreso As String _
                                                , ByRef estado_convenio As String _
                                                , ByRef observacion As String _
                                                , ByRef fecha_liquidacion As String _
                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_convenios_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)

                oCmd.Parameters.AddWithValue("@etapa", etapa)
                oCmd.Parameters.AddWithValue("@num_decreto", num_decreto)
                oCmd.Parameters.AddWithValue("@fecha_decreto", fecha_decreto)
                oCmd.Parameters.AddWithValue("@tipo_convenio", tipo_convenio)
                oCmd.Parameters.AddWithValue("@fecha_convenio", fecha_convenio)
                oCmd.Parameters.AddWithValue("@monto_neto", monto_neto)
                oCmd.Parameters.AddWithValue("@gastos_administrativos", gastos_administrativos)
                oCmd.Parameters.AddWithValue("@consul", consul)
                oCmd.Parameters.AddWithValue("@otros_gastos", otros_gastos)
                oCmd.Parameters.AddWithValue("@descripcion", descripcion)
                oCmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso)
                oCmd.Parameters.AddWithValue("@estado_convenio", estado_convenio)
                oCmd.Parameters.AddWithValue("@observacion", observacion)
                oCmd.Parameters.AddWithValue("@fecha_liquidacion", fecha_liquidacion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_eliminar_convenios_proyecto(ByRef region As String, _
                                                  ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef correlativo As String _
                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_convenios_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function
        ' Creado el 22-04-2014 por ARB
        Public Function SetElimina_boleta_garantia_contrato(ByRef cod_con As String, _
                                          ByRef entidad_financiera As String _
                                        , ByRef numero As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_boleta_garantia_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@entidad_financiera", entidad_financiera)
                oCmd.Parameters.AddWithValue("@numero", numero)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function
#End Region

#Region "Eventos Nuevos JQ"

        Public Function GetBusca_contratos_detalle_avance_fisico(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_avance_fisico", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_contratos_detalle_avance_fisico_suma(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_avance_fisico_suma", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        'INICIO 27-11-2012
        Public Function GetBusca_contratos_detalle_edita_contrato(ByVal codigo_pia As String _
        , ByVal codigo_region As String _
        , ByVal sufijo As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_edita_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_contratos_detalle_estado_pago(ByVal cod_con As String _
                                                             , ByVal NUM_EPAGO As Double) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_estado_pago", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@NUM_EPAGO", NUM_EPAGO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_contratos_detalle_garantias(ByVal cod_con As String, ByVal llave As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_contratos_detalle_garantias", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_contratos_detalle_imputacion_presup(ByVal codigo_pia As String _
                                                                   , ByVal codigo_region As String _
                                                                   , ByVal sufijo As String _
                                                                   ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_imputacion_presup", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_contratos_detalle_inspector_fiscal(ByVal COD_CON As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_inspector_fiscal", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_contratos_detalle_modificacion_contrato(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_contratos_detalle_modificacion_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_contratos_detalle_programacion_financ(ByVal codigo_pia As String _
                                                                     , ByVal codigo_region As String _
                                                                     , ByVal sufijo As String _
                                                                     ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_programacion_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_contratos_detalle_programacion_financ_sum(ByVal codigo_pia As String _
                                                                            , ByVal codigo_region As String _
                                                                            , ByVal sufijo As String _
                                                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_contratos_detalle_programacion_financ_suma", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Agregada para ingresar datos de propuesta financiera, creado el 08-04-2015
        Public Function GetBusca_programacion_tentativa_propuesta_financ(ByVal codigo_pia As String _
                                                                     , ByVal codigo_region As String _
                                                                     , ByVal sufijo As String _
                                                                     ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_programacion_tentativa_propuesta_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Agregada para ingresar datos de propuesta financiera, creado el 08-04-2015
        Public Function GetBusca_programacion_tentativa_propuesta_financ_sum(ByVal codigo_pia As String _
                                                                            , ByVal codigo_region As String _
                                                                            , ByVal sufijo As String _
                                                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_programacion_tentativa_propuesta_financ_suma", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function
        Public Function GetBusca_contratos_detalle_termino(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_contratos_detalle_termino", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_contratos_resumen_edita_contrato(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_contratos_resumen_edita_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_correlativo_convenios_relacionados_edita(ByVal codigo_pia As String _
                                                                        , ByVal codigo_region As String _
                                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_correlativo_convenios_relacionados_edita", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_dom_insp_fis(ByVal rut As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_dom_insp_fis", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@rut", rut)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetCancela_contratos_detalle_termino(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Cancela_contratos_detalle_termino", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetElimina_contratos_detalle_avance_fisico(ByVal cod_con As String _
                                                                , ByVal llave As String _
                                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_contratos_detalle_avance_fisico", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetElimina_contratos_detalle_estado_pago(ByVal cod_con As String _
                                                                , ByVal num_epago As Double _
                                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_contratos_detalle_estado_pago", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@num_epago", num_epago)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetElimina_contratos_detalle_imputacion_presup(ByVal codigo_pia As String _
                                                                    , ByVal codigo_region As String _
                                                                    , ByVal sufijo As String _
                                                                    , ByVal llave As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_contratos_detalle_imputacion_presup", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetElimina_contratos_detalle_inspector_fiscal(ByVal COD_CON As String _
                                                                    , ByVal RUT As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_contratos_detalle_inspector_fiscal", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@RUT", RUT)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetEliminar_contratos_detalle_programacion_financ(ByVal codigo_pia As String _
                                                                        , ByVal codigo_region As String _
                                                                        , ByVal sufijo As String _
                                                                        , ByVal AGNO As Double _
                                                                        , ByVal MES As Double _
                                                                        , ByVal MONTO_VIG As Double _
                                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_eliminar_contratos_detalle_programacion_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@AGNO", AGNO)
                oCmd.Parameters.AddWithValue("@MES", MES)
                oCmd.Parameters.AddWithValue("@MONTO_VIG", MONTO_VIG)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_avance_fisico(ByVal cod_con As String _
        , ByVal AGNO As Double _
        , ByVal MES As Double _
        , ByVal AV_FIS_PR As Double _
        , ByVal AV_FIS_ACUM As Double _
        , ByVal FECHA_MEDICION As String _
        , ByVal AV_FIS_RE As Double _
        , ByVal MANO_DE_OBRA_CALIFICADA As Double _
        , ByVal MANO_DE_OBRA_SEMI_CALIFICADA As Double _
        , ByVal MANO_DE_OBRA_NO_CALIFICADA As Double _
        , ByVal OBSERV As String _
        , ByVal llave As String _
        , ByVal av_fis_act As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_avance_fisico", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@AGNO", AGNO)
                oCmd.Parameters.AddWithValue("@MES", MES)
                oCmd.Parameters.AddWithValue("@AV_FIS_PR", AV_FIS_PR)
                oCmd.Parameters.AddWithValue("@AV_FIS_ACUM", AV_FIS_ACUM)
                oCmd.Parameters.AddWithValue("@FECHA_MEDICION", FECHA_MEDICION)
                oCmd.Parameters.AddWithValue("@AV_FIS_RE", AV_FIS_RE)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_CALIFICADA", MANO_DE_OBRA_CALIFICADA)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_SEMI_CALIFICADA", MANO_DE_OBRA_SEMI_CALIFICADA)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_NO_CALIFICADA", MANO_DE_OBRA_NO_CALIFICADA)
                oCmd.Parameters.AddWithValue("@OBSERV", OBSERV)
                oCmd.Parameters.AddWithValue("@llave", llave)
                oCmd.Parameters.AddWithValue("@av_fis_act", av_fis_act)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_contratos(ByVal codigo_pia As String _
                                                            , ByVal codigo_region As String _
                                                            , ByVal sufijo As String _
                                                            , ByVal m2 As Double _
                                                            , ByVal desc_contrato As String _
                                                            , ByVal FechaInicioLegal As String _
                                                            , ByVal FechaEntregaTerreno As String _
                                                            , ByVal PlazoNoComputable As Double _
                                                            , ByVal ObsRelContrato As String _
                                                            , ByVal usuario As String _
                                                            , ByVal libro As String _
                                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_contratos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@m2", m2)
                oCmd.Parameters.AddWithValue("@desc_contrato", desc_contrato)
                oCmd.Parameters.AddWithValue("@FechaInicioLegal", FechaInicioLegal)
                oCmd.Parameters.AddWithValue("@FechaEntregaTerreno", FechaEntregaTerreno)
                oCmd.Parameters.AddWithValue("@PlazoNoComputable", PlazoNoComputable)
                oCmd.Parameters.AddWithValue("@ObsRelContrato", ObsRelContrato)
                oCmd.Parameters.AddWithValue("@usuario", usuario)
                oCmd.Parameters.AddWithValue("@libro", libro)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_garantias(ByVal COD_CON As String _
                                                            , ByVal COD_TIPO As String _
                                                            , ByVal ENTIDAD_FINANCIERA As String _
                                                            , ByVal NUMERO As Double _
                                                            , ByVal FECHA As String _
                                                            , ByVal FECHA_VENCIMIENTO_INICIAL As String _
                                                            , ByVal FECHA_VENCIMIENTO As String _
                                                            , ByVal MONTO As Double _
                                                            , ByVal TIPO_MONEDA As String _
                                                            , ByVal NUM_OFICIO_DESTINO_DOCUMENTO As Double _
                                                            , ByVal FECHA_OFICIO_DESTINO_DOCUMENTO As String _
                                                            , ByVal ENTIDAD_QUE_CUSTODIA As String _
                                                            , ByVal NUM_OFICIO_SOLICITUD_GARANTIA As Double _
                                                            , ByVal FECHA_OFICIO_SOLICITUD_GARANTIA As String _
                                                            , ByVal FECHA_DEVOLUCION_GARANTIA As String _
                                                            , ByVal TIPO_DE_DOCUMENTO As String _
                                                            , ByVal DEVUELTA As String _
                                                            , ByVal FECHA_PRORROGA As String _
                                                            , ByVal FECHA_NUEVO_VENCIMIENTO As String _
                                                            , ByVal DIAS As Double _
                                                            , ByVal LLAVE As String _
                                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_garantias", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@COD_TIPO", COD_TIPO)
                oCmd.Parameters.AddWithValue("@ENTIDAD_FINANCIERA", ENTIDAD_FINANCIERA)
                oCmd.Parameters.AddWithValue("@NUMERO", NUMERO)
                oCmd.Parameters.AddWithValue("@FECHA", FECHA)
                oCmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INICIAL", FECHA_VENCIMIENTO_INICIAL)
                oCmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO", FECHA_VENCIMIENTO)
                oCmd.Parameters.AddWithValue("@MONTO", MONTO)
                oCmd.Parameters.AddWithValue("@TIPO_MONEDA", TIPO_MONEDA)
                oCmd.Parameters.AddWithValue("@NUM_OFICIO_DESTINO_DOCUMENTO", NUM_OFICIO_DESTINO_DOCUMENTO)
                oCmd.Parameters.AddWithValue("@FECHA_OFICIO_DESTINO_DOCUMENTO", FECHA_OFICIO_DESTINO_DOCUMENTO)
                oCmd.Parameters.AddWithValue("@ENTIDAD_QUE_CUSTODIA", ENTIDAD_QUE_CUSTODIA)
                oCmd.Parameters.AddWithValue("@NUM_OFICIO_SOLICITUD_GARANTIA", NUM_OFICIO_SOLICITUD_GARANTIA)
                oCmd.Parameters.AddWithValue("@FECHA_OFICIO_SOLICITUD_GARANTIA", FECHA_OFICIO_SOLICITUD_GARANTIA)
                oCmd.Parameters.AddWithValue("@FECHA_DEVOLUCION_GARANTIA", FECHA_DEVOLUCION_GARANTIA)
                oCmd.Parameters.AddWithValue("@TIPO_DE_DOCUMENTO", TIPO_DE_DOCUMENTO)
                oCmd.Parameters.AddWithValue("@DEVUELTA", DEVUELTA)
                oCmd.Parameters.AddWithValue("@FECHA_PRORROGA", FECHA_PRORROGA)
                oCmd.Parameters.AddWithValue("@FECHA_NUEVO_VENCIMIENTO", FECHA_NUEVO_VENCIMIENTO)
                oCmd.Parameters.AddWithValue("@DIAS", DIAS)
                oCmd.Parameters.AddWithValue("@Llave", LLAVE)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_imputacion_presup(ByVal codigo_pia As String _
                                                                    , ByVal codigo_region As String _
                                                                    , ByVal sufijo As String _
                                                                    , ByVal Ano As String _
                                                                    , ByVal Mandante As String _
                                                                    , ByVal TipoFondo As String _
                                                                    , ByVal ResOrig As String _
                                                                    , ByVal NumeroRes As Double _
                                                                    , ByVal FechaRes As String _
                                                                    , ByVal SUBT As String _
                                                                    , ByVal IT As String _
                                                                    , ByVal ASIG As String _
                                                                    , ByVal MontoImputado As Double _
                                                                    , ByVal Codigo_Contrato As String _
                                                                    , ByVal llave As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_imputacion_presup", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@Ano", Ano)
                oCmd.Parameters.AddWithValue("@Mandante", Mandante)
                oCmd.Parameters.AddWithValue("@TipoFondo", TipoFondo)
                oCmd.Parameters.AddWithValue("@ResOrig", ResOrig)
                oCmd.Parameters.AddWithValue("@NumeroRes", NumeroRes)
                oCmd.Parameters.AddWithValue("@FechaRes", FechaRes)
                oCmd.Parameters.AddWithValue("@SUBT", SUBT)
                oCmd.Parameters.AddWithValue("@IT", IT)
                oCmd.Parameters.AddWithValue("@ASIG", ASIG)
                oCmd.Parameters.AddWithValue("@MontoImputado", MontoImputado)
                oCmd.Parameters.AddWithValue("@Codigo_Contrato", Codigo_Contrato)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_inspector_fiscal(ByVal COD_CON As String _
                                                                    , ByVal RUT As String _
                                                                    , ByVal N_RES As Double _
                                                                    , ByVal F_RESOL As String _
                                                                    , ByVal TITULARSN As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_inspector_fiscal", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@RUT", RUT)
                oCmd.Parameters.AddWithValue("@N_RES", N_RES)
                oCmd.Parameters.AddWithValue("@F_RESOL", F_RESOL)
                oCmd.Parameters.AddWithValue("@TITULARSN", TITULARSN)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_modificacion_contrato(ByVal COD_CON As String _
                                                                        , ByVal TIPO_MODIF_CTTO As Long _
                                                                        , ByVal N_DOCTO_SOLICITUD_MOD As Double _
                                                                        , ByVal F_SOLICITUD_MOD As String _
                                                                        , ByVal VAR_MTO As Double _
                                                                        , ByVal VAR_PZO As Double _
                                                                        , ByVal VAR_TAMAGNO As Double _
                                                                        , ByVal N_DOCTO_RESP_SOLICITUD_MOD As Double _
                                                                        , ByVal F_RESP_SOLICITUD_MOD As String _
                                                                        , ByVal OR_RES As String _
                                                                        , ByVal N_RES As Double _
                                                                        , ByVal F_RES As String _
                                                                        , ByVal F_TRAMITE As String _
                                                                        , ByVal MOTIVO As Double _
                                                                        , ByVal R_NUEVA_BOLETA As String _
                                                                        , ByVal llave As String _
                                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_modificacion_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@TIPO_MODIF_CTTO", TIPO_MODIF_CTTO)
                oCmd.Parameters.AddWithValue("@N_DOCTO_SOLICITUD_MOD", N_DOCTO_SOLICITUD_MOD)
                oCmd.Parameters.AddWithValue("@F_SOLICITUD_MOD", F_SOLICITUD_MOD)
                oCmd.Parameters.AddWithValue("@VAR_MTO", VAR_MTO)
                oCmd.Parameters.AddWithValue("@VAR_PZO", VAR_PZO)
                oCmd.Parameters.AddWithValue("@VAR_TAMAGNO", VAR_TAMAGNO)
                oCmd.Parameters.AddWithValue("@N_DOCTO_RESP_SOLICITUD_MOD", N_DOCTO_RESP_SOLICITUD_MOD)
                oCmd.Parameters.AddWithValue("@F_RESP_SOLICITUD_MOD", F_RESP_SOLICITUD_MOD)
                oCmd.Parameters.AddWithValue("@OR_RES", OR_RES)
                oCmd.Parameters.AddWithValue("@N_RES", N_RES)
                oCmd.Parameters.AddWithValue("@F_RES", F_RES)
                oCmd.Parameters.AddWithValue("@F_TRAMITE", F_TRAMITE)
                oCmd.Parameters.AddWithValue("@MOTIVO", MOTIVO)
                oCmd.Parameters.AddWithValue("@R_NUEVA_BOLETA", R_NUEVA_BOLETA)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetElimina_contratos_detalle_modificacion_contrato(ByVal COD_CON As String _
                                                                        , ByVal llave As String _
                                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_contratos_detalle_modificacion_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@llave", llave)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_nuevo(ByVal codigo_pia As String _
        , ByVal codigo_region As String _
        , ByVal numCORRELATIVO_CONVENIO As String _
        , ByVal strMANDANTE_CONVENIO As String _
        , ByVal strETAPA As String _
        , ByVal strTIPO_PROCESO As String _
        , ByVal strFINANCIAMIENTO As String _
        , ByVal strOBJETO As String _
        , ByVal COD_CON As String _
        , ByVal ESTATUS As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_nuevo", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@numCORRELATIVO_CONVENIO", numCORRELATIVO_CONVENIO)
                oCmd.Parameters.AddWithValue("@strMANDANTE_CONVENIO", strMANDANTE_CONVENIO)
                oCmd.Parameters.AddWithValue("@strETAPA", strETAPA)
                oCmd.Parameters.AddWithValue("@strTIPO_PROCESO", strTIPO_PROCESO)
                oCmd.Parameters.AddWithValue("@strFINANCIAMIENTO", strFINANCIAMIENTO)
                oCmd.Parameters.AddWithValue("@strOBJETO", strOBJETO)
                oCmd.Parameters.AddWithValue("@COD_CON", COD_CON)
                oCmd.Parameters.AddWithValue("@ESTATUS", ESTATUS)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_programacion_financ(ByVal codigo_pia As String _
                                                                    , ByVal codigo_region As String _
                                                                    , ByVal sufijo As String _
                                                                    , ByVal AGNO As Double _
                                                                    , ByVal MES As Double _
                                                                    , ByVal MONTO_PROG As Double _
                                                                    , ByVal MONTO_VIG As Double _
                                                                    , ByVal FONDO As String _
                                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_programacion_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@AGNO", AGNO)
                oCmd.Parameters.AddWithValue("@MES", MES)
                oCmd.Parameters.AddWithValue("@MONTO_PROG", MONTO_PROG)
                oCmd.Parameters.AddWithValue("@MONTO_VIG", MONTO_VIG)
                oCmd.Parameters.AddWithValue("@FONDO", FONDO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Agregada para ingresar datos de propuesta financiera, creado el 08-04-2015
        Public Function SetGraba_programacion_tentativa_propuesta_financ(ByVal codigo_pia As String _
                                                                    , ByVal codigo_region As String _
                                                                    , ByVal sufijo As String _
                                                                    , ByVal AGNO As Double _
                                                                    , ByVal MES As Double _
                                                                    , ByVal MONTO_PROP As Double _
                                                                    , ByVal MONTO_VIG As Double _
                                                                    , ByVal MO_CALIF As Double _
                                                                    , ByVal MO_SEMI_CALIF As Double _
                                                                    , ByVal MO_NO_CALIF As Double _
                                                                    , ByVal FONDO As String _
                                                                    ) As DataTable


            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_programacion_tentativa_propuesta_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@AGNO", AGNO)
                oCmd.Parameters.AddWithValue("@MES", MES)
                oCmd.Parameters.AddWithValue("@MONTO_PROP", MONTO_PROP)
                oCmd.Parameters.AddWithValue("@MONTO_VIG", MONTO_VIG)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_CALIFICADA", MO_CALIF)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_SEMI_CALIFICADA", MO_SEMI_CALIF)
                oCmd.Parameters.AddWithValue("@MANO_DE_OBRA_NO_CALIFICADA", MO_NO_CALIF)
                oCmd.Parameters.AddWithValue("@FONDO", FONDO)

                'DEBE TENER MISMO NOMBRE DEL PROCEDIMIETO ALMADENADO

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Agregada para ingresar datos de propuesta financiera, creado el 08-04-2015
        Public Function SetEliminar_programacion_tentativa_propuesta_financ(ByVal codigo_pia As String _
                                                                        , ByVal codigo_region As String _
                                                                        , ByVal sufijo As String _
                                                                        , ByVal AGNO As Double _
                                                                        , ByVal MES As Double _
                                                                        , ByVal MONTO_VIG As Double _
                                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_eliminar_programacion_tentativa_propuesta_financ", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@AGNO", AGNO)
                oCmd.Parameters.AddWithValue("@MES", MES)
                oCmd.Parameters.AddWithValue("@MONTO_VIG", MONTO_VIG)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_contratos_detalle_termino(ByVal cod_con As String _
                                                        , ByVal FECHA_SOLIC_RECEP_CTTA As String _
                                                        , ByVal FECHA_TERMINO_FISICO_ITO As String _
                                                        , ByVal RESP_TERMINO As String _
                                                        , ByVal n_res_liq_anticipada As Double _
                                                        , ByVal f_acta_recepcion_unica_liq As String _
                                                        , ByVal f_res_liq_anticipada As String _
                                                        , ByVal ANTICIPADA As String _
                                                        , ByVal integrantes_com_ru As String _
                                                        , ByVal integrantes_com_ru2 As String _
                                                        , ByVal integrantes_com_ru3 As String _
                                                        , ByVal N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA As String _
                                                        , ByVal F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA As String _
                                                        , ByVal N_RES_COM_RP As Double _
                                                        , ByVal F_RES_COM_RP As String _
                                                        , ByVal f_inf_obs_rp As String _
                                                        , ByVal F_R_P As String _
                                                        , ByVal plz_obs_rp As Double _
                                                        , ByVal f_ter_real_rp As String _
                                                        , ByVal INTEGRANTES_COM_RP As String _
                                                        , ByVal INTEGRANTES_COM_RP2 As String _
                                                        , ByVal INTEGRANTES_COM_RP3 As String _
                                                        , ByVal N_CERIFICADO_RECEP_MUNICIPAL As String _
                                                        , ByVal F_CERIFICADO_RECEP_MUNICIPAL As String _
                                                        , ByVal CALIFIC As Double _
                                                        , ByVal FECHA_ACTA_ENTREGA_EXPLOT As String _
                                                        , ByVal MANDATARIO_QUE_ENTREGA As String _
                                                        , ByVal MANDANTE_QUE_RECIBE As String _
                                                        , ByVal Reservas As String _
                                                        , ByVal plz_reservsas As Double _
                                                        , ByVal monto_reservas As Double _
                                                        , ByVal N_RES_COM_RD As Double _
                                                        , ByVal f_inf_obs_rd As String _
                                                        , ByVal F_R_DEF As String _
                                                        , ByVal F_RES_COM_RD As String _
                                                        , ByVal plz_obs_rd As Double _
                                                        , ByVal INTEGRANTES_COM_RD As String _
                                                        , ByVal INTEGRANTES_COM_RD2 As String _
                                                        , ByVal INTEGRANTES_COM_RD3 As String _
                                                        , ByVal N_RES_LIQUIDA As Double _
                                                        , ByVal F_RES_LIQUIDA As String _
                                                        , ByVal AUTORIDAD_LIQUIDA As String _
                                                        , ByVal observacion_termino_contrato As String _
                                                        , ByVal sufijo As String _
                                                        , ByVal region As String _
                                                        , ByVal codigo_da As String _
                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_termino", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@FECHA_SOLIC_RECEP_CTTA", FECHA_SOLIC_RECEP_CTTA)
                oCmd.Parameters.AddWithValue("@FECHA_TERMINO_FISICO_ITO", FECHA_TERMINO_FISICO_ITO)
                oCmd.Parameters.AddWithValue("@RESP_TERMINO", RESP_TERMINO)
                oCmd.Parameters.AddWithValue("@n_res_liq_anticipada", n_res_liq_anticipada)
                oCmd.Parameters.AddWithValue("@f_acta_recepcion_unica_liq", f_acta_recepcion_unica_liq)
                oCmd.Parameters.AddWithValue("@f_res_liq_anticipada", f_res_liq_anticipada)
                oCmd.Parameters.AddWithValue("@ANTICIPADA", ANTICIPADA)
                oCmd.Parameters.AddWithValue("@integrantes_com_ru", integrantes_com_ru)
                oCmd.Parameters.AddWithValue("@integrantes_com_ru2", integrantes_com_ru2)
                oCmd.Parameters.AddWithValue("@integrantes_com_ru3", integrantes_com_ru3)
                oCmd.Parameters.AddWithValue("@N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA", N_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA)
                oCmd.Parameters.AddWithValue("@F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA", F_DOCTO_APRUEBA_LIQUIDACION_ANTICIPADA_OBRA)
                oCmd.Parameters.AddWithValue("@N_RES_COM_RP", N_RES_COM_RP)
                oCmd.Parameters.AddWithValue("@F_RES_COM_RP", F_RES_COM_RP)
                oCmd.Parameters.AddWithValue("@f_inf_obs_rp", f_inf_obs_rp)
                oCmd.Parameters.AddWithValue("@F_R_P", F_R_P)
                oCmd.Parameters.AddWithValue("@plz_obs_rp", plz_obs_rp)
                oCmd.Parameters.AddWithValue("@f_ter_real_rp", f_ter_real_rp)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RP", INTEGRANTES_COM_RP)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RP2", INTEGRANTES_COM_RP2)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RP3", INTEGRANTES_COM_RP3)
                oCmd.Parameters.AddWithValue("@N_CERIFICADO_RECEP_MUNICIPAL", N_CERIFICADO_RECEP_MUNICIPAL)
                oCmd.Parameters.AddWithValue("@F_CERIFICADO_RECEP_MUNICIPAL", F_CERIFICADO_RECEP_MUNICIPAL)
                oCmd.Parameters.AddWithValue("@CALIFIC", CALIFIC)
                oCmd.Parameters.AddWithValue("@FECHA_ACTA_ENTREGA_EXPLOT", FECHA_ACTA_ENTREGA_EXPLOT)
                oCmd.Parameters.AddWithValue("@MANDATARIO_QUE_ENTREGA", MANDATARIO_QUE_ENTREGA)
                oCmd.Parameters.AddWithValue("@MANDANTE_QUE_RECIBE", MANDANTE_QUE_RECIBE)
                oCmd.Parameters.AddWithValue("@Reservas", Reservas)
                oCmd.Parameters.AddWithValue("@plz_reservsas", plz_reservsas)
                oCmd.Parameters.AddWithValue("@monto_reservas", monto_reservas)
                oCmd.Parameters.AddWithValue("@N_RES_COM_RD", N_RES_COM_RD)
                oCmd.Parameters.AddWithValue("@f_inf_obs_rd", f_inf_obs_rd)
                oCmd.Parameters.AddWithValue("@F_R_DEF", F_R_DEF)
                oCmd.Parameters.AddWithValue("@F_RES_COM_RD", F_RES_COM_RD)
                oCmd.Parameters.AddWithValue("@plz_obs_rd", plz_obs_rd)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RD", INTEGRANTES_COM_RD)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RD2", INTEGRANTES_COM_RD2)
                oCmd.Parameters.AddWithValue("@INTEGRANTES_COM_RD3", INTEGRANTES_COM_RD3)
                oCmd.Parameters.AddWithValue("@N_RES_LIQUIDA", N_RES_LIQUIDA)
                oCmd.Parameters.AddWithValue("@F_RES_LIQUIDA", F_RES_LIQUIDA)
                oCmd.Parameters.AddWithValue("@AUTORIDAD_LIQUIDA", AUTORIDAD_LIQUIDA)
                oCmd.Parameters.AddWithValue("@observacion_termino_contrato", observacion_termino_contrato)
                oCmd.Parameters.AddWithValue("@Sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGrabar_contratos_detalle_estado_pago(ByVal cod_con As String _
                                                                , ByVal NUM_EPAGO As Double _
                                                                , ByVal FECHA_EPAGO As String _
                                                                , ByVal PAG_CTTO_MATRIZ As Double _
                                                                , ByVal PAG_MOD_CTTO As Double _
                                                                , ByVal PAG_REAJ As Double _
                                                                , ByVal PAG_ANTICIPO As Double _
                                                                , ByVal PAG_CANJE_RET As Double _
                                                                , ByVal PAG_DEVOL_RET As Double _
                                                                , ByVal DEVOL_ANTICIPO As Double _
                                                                , ByVal REAJ_DEVOL_ANTIC As Double _
                                                                , ByVal RETENCIONES As Double _
                                                                , ByVal MULTAS As Double _
                                                                , ByVal IMPUESTO As Double _
                                                                , ByVal LIQUIDO_A_PAGAR As Double _
                                                                , ByVal VALOR_E_PAGO As Double _
                                                                , ByVal CARGO_A_PRES As Double _
                                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_contratos_detalle_estado_pago", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@NUM_EPAGO", NUM_EPAGO)
                oCmd.Parameters.AddWithValue("@FECHA_EPAGO", FECHA_EPAGO)
                oCmd.Parameters.AddWithValue("@PAG_CTTO_MATRIZ", PAG_CTTO_MATRIZ)
                oCmd.Parameters.AddWithValue("@PAG_MOD_CTTO", PAG_MOD_CTTO)
                oCmd.Parameters.AddWithValue("@PAG_REAJ", PAG_REAJ)
                oCmd.Parameters.AddWithValue("@PAG_ANTICIPO", PAG_ANTICIPO)
                oCmd.Parameters.AddWithValue("@PAG_CANJE_RET", PAG_CANJE_RET)
                oCmd.Parameters.AddWithValue("@PAG_DEVOL_RET", PAG_DEVOL_RET)
                oCmd.Parameters.AddWithValue("@DEVOL_ANTICIPO", DEVOL_ANTICIPO)
                oCmd.Parameters.AddWithValue("@REAJ_DEVOL_ANTIC", REAJ_DEVOL_ANTIC)
                oCmd.Parameters.AddWithValue("@RETENCIONES", RETENCIONES)
                oCmd.Parameters.AddWithValue("@MULTAS", MULTAS)
                oCmd.Parameters.AddWithValue("@IMPUESTO", IMPUESTO)

                oCmd.Parameters.AddWithValue("@LIQUIDO_A_PAGAR", LIQUIDO_A_PAGAR)
                oCmd.Parameters.AddWithValue("@VALOR_E_PAGO", VALOR_E_PAGO)
                oCmd.Parameters.AddWithValue("@CARGO_A_PRES", CARGO_A_PRES)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetPryProcesosList(ByVal tipologia As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_pry_procesos_list", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@tipologia", tipologia)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetPry_procesos_list(ByVal tipologia As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_pry_procesos_list", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@tipologia", tipologia)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetSetup_grilla(ByVal tipo_grilla As String _
        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_setup_grilla", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@tipo_grilla", tipo_grilla)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'FIN 27-11-2012

        Public Function GetBusca_Comunas_Sector(ByVal region As String, ByVal provincia As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_comunas_sector", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@provincia", provincia)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_SubSector_Sector(ByVal sector_destino As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_SubSector_Sector", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_Tipologias_Sector(ByVal sector_destino As String, ByVal sub_sector As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Busca_Tipologias_Sector", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)
                oCmd.Parameters.AddWithValue("@sub_sector", sub_sector)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGrabaMandantesProyecto(ByVal region As String _
                                                       , ByVal codigo_da As String _
                                                       , ByVal mandante As String _
                                                       ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_mandantes_del_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetEliminaMandantesProyecto(ByVal region As String _
                                                       , ByVal codigo_da As String _
                                                       , ByVal mandante As String _
                                                       ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_mandantes_del_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_llena_codigo_contratos_cartola_contratos(ByVal str_region_inicio As String, ByVal str_region_fin As String, ByVal str_fecha_inicio As String, ByVal str_fecha_fin As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_llena_codigo_contratos_cartola_contratos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@str_region_inicio", str_region_inicio)
                oCmd.Parameters.AddWithValue("@str_region_fin", str_region_fin)
                oCmd.Parameters.AddWithValue("@str_fecha_inicio", str_fecha_inicio)
                oCmd.Parameters.AddWithValue("@str_fecha_fin", str_fecha_fin)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_llena_codigo_contratos(ByVal str_region_inicio As String, ByVal str_region_fin As String, ByVal str_fecha_inicio As String, ByVal str_fecha_fin As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_llena_codigo_contratos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@str_region_inicio", str_region_inicio)
                oCmd.Parameters.AddWithValue("@str_region_fin", str_region_fin)
                oCmd.Parameters.AddWithValue("@str_fecha_inicio", str_fecha_inicio)
                oCmd.Parameters.AddWithValue("@str_fecha_fin", str_fecha_fin)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetEliminaEtapa(ByVal REGION As String _
                                    , ByVal CODIGO_DA As String _
                                    , ByVal ETAPA As String _
                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_eliminar_ETAPA", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@ETAPA", ETAPA)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGrabaLog(ByVal nombre_usuario As String _
                                    , ByVal codigo_tipo_usuario As String _
                                    , ByVal url_opcion As String _
                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_log", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@nombre_usuario", nombre_usuario)
                oCmd.Parameters.AddWithValue("@codigo_tipo_usuario", codigo_tipo_usuario)
                oCmd.Parameters.AddWithValue("@url_opcion", url_opcion)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function


        Public Function Set_graba_ws_contratos_sectoriales(ByRef accion As String _
                                                            , ByRef clave As String _
                                                            , ByRef region_inicio As String _
                                                            , ByRef region_fin As String _
                                                            , ByRef codigosafi As String _
                                                            , ByRef descripcionregion As String _
                                                            , ByRef descripcioncomuna As String _
                                                            , ByRef descripcionprovincia As String _
                                                            , ByRef rutcontratista As String _
                                                            , ByRef montocontrato As String _
                                                            , ByRef montoinicial As String _
                                                            , ByRef montovigente As String _
                                                            , ByRef rutinspector As String _
                                                            , ByRef estadocontrato As String _
                                                            , ByRef tipogasto As String _
                                                            , ByRef pptooficial As String _
                                                            , ByRef aumentodisminucion As String _
                                                            , ByRef fechatermino As String _
                                                            , ByRef descripcion_tipo_registro As String _
                                                            , ByRef descripcion_categoria As String _
                                                            , ByRef codigo_bip As String _
                                                            , ByRef proceso As String _
                                                            , ByRef etapa As String _
                                                            , ByRef calificacion As String _
                                                            , ByRef f_recep_provisional As String _
                                                            , ByRef f_recep_definitiva As String _
                                                            , ByRef f_res_liq_contrato As String _
                                                            , ByRef f_termino_ito As String _
                                                            , ByRef ultimo As String _
                                                            , ByRef objeto As String _
                                                            , ByRef sector_destino As String _
                                                            , ByRef sub_sec As String _
                                                            , ByRef tipo_edificacion As String _
                                                            , ByRef plazo_adjudicado As String _
                                                            , ByRef inicio_legal As String _
                                                            , ByRef f_res_adjudicacion As String _
                                                            , ByRef plazo_vigente As String _
                                                            , ByRef inversion_anno As String _
                                                            , ByRef inversion_acumulada As String _
                                                            , ByRef cantidad_obra As String _
                                                            , ByRef observaciones_contrato As String _
                                                            , ByRef av_fin As String _
                                                            , ByRef av_fis_acum As String _
                                    ) As DataTable


            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_ws_contratos_sectoriales", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@clave", clave)
                oCmd.Parameters.AddWithValue("@region_inicio", region_inicio)
                oCmd.Parameters.AddWithValue("@region_fin", region_fin)
                oCmd.Parameters.AddWithValue("@codigosafi", codigosafi)
                oCmd.Parameters.AddWithValue("@descripcionregion", descripcionregion)
                oCmd.Parameters.AddWithValue("@descripcioncomuna", descripcioncomuna)
                oCmd.Parameters.AddWithValue("@descripcionprovincia", descripcionprovincia)
                oCmd.Parameters.AddWithValue("@rutcontratista", rutcontratista)
                oCmd.Parameters.AddWithValue("@montocontrato", montocontrato)
                oCmd.Parameters.AddWithValue("@montoinicial", montoinicial)
                oCmd.Parameters.AddWithValue("@montovigente", montovigente)
                oCmd.Parameters.AddWithValue("@rutinspector", rutinspector)
                oCmd.Parameters.AddWithValue("@estadocontrato", estadocontrato)
                oCmd.Parameters.AddWithValue("@tipogasto", tipogasto)
                oCmd.Parameters.AddWithValue("@pptooficial", pptooficial)
                oCmd.Parameters.AddWithValue("@aumentodisminucion", aumentodisminucion)
                oCmd.Parameters.AddWithValue("@fechatermino", fechatermino)
                oCmd.Parameters.AddWithValue("@descripcion_tipo_registro", descripcion_tipo_registro)
                oCmd.Parameters.AddWithValue("@descripcion_categoria", descripcion_categoria)
                oCmd.Parameters.AddWithValue("@codigo_bip", codigo_bip)
                oCmd.Parameters.AddWithValue("@proceso", proceso)
                oCmd.Parameters.AddWithValue("@etapa", etapa)
                oCmd.Parameters.AddWithValue("@calificacion", calificacion)
                oCmd.Parameters.AddWithValue("@f_recep_provisional", f_recep_provisional)
                oCmd.Parameters.AddWithValue("@f_recep_definitiva", f_recep_definitiva)
                oCmd.Parameters.AddWithValue("@f_res_liq_contrato", f_res_liq_contrato)
                oCmd.Parameters.AddWithValue("@f_termino_ito", f_termino_ito)
                oCmd.Parameters.AddWithValue("@ultimo", ultimo)
                oCmd.Parameters.AddWithValue("@objeto", objeto)
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)
                oCmd.Parameters.AddWithValue("@sub_sec", sub_sec)
                oCmd.Parameters.AddWithValue("@tipo_edificacion", tipo_edificacion)
                oCmd.Parameters.AddWithValue("@plazo_adjudicado", plazo_adjudicado)
                oCmd.Parameters.AddWithValue("@inicio_legal", inicio_legal)
                oCmd.Parameters.AddWithValue("@f_res_adjudicacion", f_res_adjudicacion)
                oCmd.Parameters.AddWithValue("@plazo_vigente", plazo_vigente)
                oCmd.Parameters.AddWithValue("@inversion_anno", inversion_anno)
                oCmd.Parameters.AddWithValue("@inversion_acumulada", inversion_acumulada)
                oCmd.Parameters.AddWithValue("@cantidad_obra", cantidad_obra)
                oCmd.Parameters.AddWithValue("@observaciones_contrato", observaciones_contrato)
                oCmd.Parameters.AddWithValue("@av_fin", av_fin)
                oCmd.Parameters.AddWithValue("@av_fis_acum", av_fis_acum)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_mandante_convenios(ByVal region As String, ByVal codigo_da As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_mandante_convenios", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_buscar_mandantes_del_contrato(ByVal region As String, ByVal codigo_da As String, ByVal sufijo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_buscar_mandantes_del_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_eliminar_mandantes_del_contrato(ByVal REGION As String _
                                    , ByVal CODIGO_DA As String _
                                    , ByVal SUFIJO As String _
                                    , ByVal MANDANTE As String _
                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_eliminar_mandantes_del_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)
                oCmd.Parameters.AddWithValue("@MANDANTE", MANDANTE)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetOfertasPropuestas_Elimina(ByVal REGION As String _
                                            , ByVal CODIGO_DA As String _
                                            , ByVal SUFIJO As String _
                                            , ByVal RUT_CTTA As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_eliminar_ofertas_propuesta", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@SUFIJO", SUFIJO)
                oCmd.Parameters.AddWithValue("@RUT_CTTA", RUT_CTTA)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetMnt_TipoUsuario(ByVal accion As String _
                                            , ByVal nombre_tipo_usuario As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_tipo_usuario", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@nombre_tipo_usuario", nombre_tipo_usuario)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_localizacion(ByVal region As String, ByVal provincia As String, ByVal comuna As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_busca_localizacion", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@provincia", provincia)
                oCmd.Parameters.AddWithValue("@comuna", comuna)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Graba_Contratos_Detalle_Datos(ByVal codigo_pia As String _
                                                                , ByVal codigo_region As String _
                                                                , ByVal sufijo As String _
                                                                , ByVal strLEGAL As String _
                                                                , ByVal strAMBIENTAL As String _
                                                                , ByVal strEXPROPIACION As String _
                                                                , ByVal strLICITACION As String _
                                                                , ByVal strEJECUCION As String _
                                                                , ByVal strAUMENTO_COSTOS As String _
                                                                , ByVal strEXPLICACION_O_ALERTAS As String _
                                                                , ByVal strAPERTURA_LICITACION As String _
                                                                , ByVal strPRIMERA_PIEDRA As String _
                                                                , ByVal strINAUGURACION As String _
                                                                , ByVal intProximo_Hito As String _
                                                                , ByVal strObservacionMandante As String _
                                                                , ByVal strResp_Administrativo As String _
                                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_contratos_detalle_datos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@strLEGAL", strLEGAL)
                oCmd.Parameters.AddWithValue("@strAMBIENTAL", strAMBIENTAL)
                oCmd.Parameters.AddWithValue("@strEXPROPIACION", strEXPROPIACION)
                oCmd.Parameters.AddWithValue("@strLICITACION", strLICITACION)
                oCmd.Parameters.AddWithValue("@strEJECUCION", strEJECUCION)
                oCmd.Parameters.AddWithValue("@strAUMENTO_COSTOS", strAUMENTO_COSTOS)
                oCmd.Parameters.AddWithValue("@strEXPLICACION_O_ALERTAS", strEXPLICACION_O_ALERTAS)
                oCmd.Parameters.AddWithValue("@strAPERTURA_LICITACION", strAPERTURA_LICITACION)
                oCmd.Parameters.AddWithValue("@strPRIMERA_PIEDRA", strPRIMERA_PIEDRA)
                oCmd.Parameters.AddWithValue("@strINAUGURACION", strINAUGURACION)
                oCmd.Parameters.AddWithValue("@intProximo_Hito", intProximo_Hito)
                oCmd.Parameters.AddWithValue("@strObservacionMandante", strObservacionMandante)
                oCmd.Parameters.AddWithValue("@strResp_Administrativo", strResp_Administrativo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Mnt_Componentes(ByVal accion As String _
                                           , ByVal CODIGO_PROYECTO As String _
                                           , ByVal NOMBRE_COMPONENTE As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_componentes", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", CODIGO_PROYECTO)
                oCmd.Parameters.AddWithValue("@NOMBRE_COMPONENTE", NOMBRE_COMPONENTE)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function



        Public Function Set_Mnt_Financiamiento(ByVal accion As String _
                                             , ByVal CODIGO_PROYECTO As String _
                                             , ByVal DESCRIPCION As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_financiamiento", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", CODIGO_PROYECTO)
                oCmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function



        Public Function Set_Mnt_Monumento(ByVal accion As String _
                                        , ByVal codigo_proyecto As String _
                                        , ByVal tipo As String _
                                        , ByVal tipo_doc As String _
                                        , ByVal num_doc As String _
                                        , ByVal fecha As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_monumento", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@TIPO", tipo)
                oCmd.Parameters.AddWithValue("@TIPO_DOC", tipo_doc)
                oCmd.Parameters.AddWithValue("@NUM_DOC", num_doc)
                oCmd.Parameters.AddWithValue("@FECHA", fecha)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function



        Public Function Set_Mnt_Proceso(ByVal accion As String _
                                      , ByVal codigo_proyecto As String _
                                      , ByVal nombre_proceso As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_proceso", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@NOMBRE_PROCESO", nombre_proceso)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Mnt_Superficie(ByVal accion As String _
                                         , ByVal codigo_proyecto As String _
                                         , ByVal nivel As String _
                                         , ByVal M2 As Long _
                                         , ByVal proceso_asociado As Integer) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_superficie", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@NIVEL", nivel)
                oCmd.Parameters.AddWithValue("@M2", M2)
                oCmd.Parameters.AddWithValue("@proceso_asociado", proceso_asociado)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        '//JPQV
        Public Function Get_busca_asig_cargo_presupuesto(ByVal cod_con As String _
                                         ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_asig_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_cargo_presupuesto(ByVal cod_con As String, _
                                                       ByVal num_epago As String _
                                         ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@num_epago", num_epago)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_fondos_cargo_presupuesto(ByVal cod_con As String _
                                         ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_fondos_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_imgPatrimonio(ByVal cod_con As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_imgPatrimonio", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_item_cargo_presupuesto(ByVal cod_con As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_item_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_mandantes_cargo_presupuesto(ByVal cod_con As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_mandantes_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_elimina_cargo_presupuesto(ByVal cod_con As String _
                                                        , ByVal num_epago As String _
                                                        , ByVal mandante As String _
                                                        , ByVal t_f1 As String _
                                                        , ByVal agno As String _
                                                        , ByVal subt As String _
                                                        , ByVal item As String _
                                                        , ByVal asig As String _
                                                        , ByVal mes_cargo As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@num_epago", num_epago)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@t_f1", t_f1)
                oCmd.Parameters.AddWithValue("@agno", agno)
                oCmd.Parameters.AddWithValue("@subt", subt)
                oCmd.Parameters.AddWithValue("@item", item)
                oCmd.Parameters.AddWithValue("@asig", asig)
                oCmd.Parameters.AddWithValue("@mes_cargo", mes_cargo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_graba_cargo_presupuesto(ByVal cod_con As String _
                                                        , ByVal num_epago As String _
                                                        , ByVal fecha_epago As String _
                                                        , ByVal mandante As String _
                                                        , ByVal t_f1 As String _
                                                        , ByVal agno As String _
                                                        , ByVal subt As String _
                                                        , ByVal item As String _
                                                        , ByVal asig As String _
                                                        , ByVal mes_cargo As String _
                                                        , ByVal monto As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_cargo_presupuesto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@num_epago", num_epago)
                oCmd.Parameters.AddWithValue("@fecha_epago", fecha_epago)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@t_f1", t_f1)
                oCmd.Parameters.AddWithValue("@agno", agno)
                oCmd.Parameters.AddWithValue("@subt", subt)
                oCmd.Parameters.AddWithValue("@item", item)
                oCmd.Parameters.AddWithValue("@asig", asig)
                oCmd.Parameters.AddWithValue("@mes_cargo", mes_cargo)
                oCmd.Parameters.AddWithValue("@monto", monto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_llena_codigo_contratos_proyecto(ByVal codigo_proyecto_exp As String _
                                                                ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_llena_codigo_contratos_proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_proyecto_exp", codigo_proyecto_exp)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetValida_Acceso_Region(ByVal usuario As String _
                                                        , ByVal region As String _
                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_Valida_Acceso_Region", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@usuario", usuario)
                oCmd.Parameters.AddWithValue("@region", region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_actualiza_fecha_contrato(ByVal codigo_pia As String _
                                                        , ByVal codigo_region As String _
                                                        , ByVal sufijo As String _
                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_actualiza_fecha_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetBusca_consultoria_detalle_termino(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_consultoria_detalle_termino", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function GetBusca_consultoria_detalle_termino_grilla(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_consultoria_detalle_termino_grilla", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetGraba_consultoria_detalle_termino(ByVal cod_con As String, _
                                                            ByVal fecha_termino_fisico_ito As String, _
                                                            ByVal resp_termino As String, _
                                                            ByVal f_ent_def_con As String, _
                                                            ByVal n_res_liquida_anti_con As String, _
                                                            ByVal f_res_liquida_anti_con As String, _
                                                            ByVal n_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                            ByVal f_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                            ByVal n_res_liquida_con As String, _
                                                            ByVal f_res_liquida_con As String, _
                                                            ByVal autoridad_liquida_con As String, _
                                                            ByVal calificacion_con As Double, _
                                                            ByVal observacion_termino_contrato As String _
                                                        ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_consultoria_detalle_termino", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@fecha_termino_fisico_ito ", fecha_termino_fisico_ito)
                oCmd.Parameters.AddWithValue("@resp_termino", resp_termino)
                oCmd.Parameters.AddWithValue("@f_ent_def_con", f_ent_def_con)
                oCmd.Parameters.AddWithValue("@n_res_liquida_anti_con", n_res_liquida_anti_con)
                oCmd.Parameters.AddWithValue("@f_res_liquida_anti_con", f_res_liquida_anti_con)
                oCmd.Parameters.AddWithValue("@n_docto_aprueba_liquidacion_anticipada_obra", n_docto_aprueba_liquidacion_anticipada_obra)
                oCmd.Parameters.AddWithValue("@f_docto_aprueba_liquidacion_anticipada_obra", f_docto_aprueba_liquidacion_anticipada_obra)
                oCmd.Parameters.AddWithValue("@n_res_liquida_con", n_res_liquida_con)
                oCmd.Parameters.AddWithValue("@f_res_liquida_con", f_res_liquida_con)
                oCmd.Parameters.AddWithValue("@autoridad_liquida_con", autoridad_liquida_con)
                oCmd.Parameters.AddWithValue("@calificacion_con", calificacion_con)
                oCmd.Parameters.AddWithValue("@observacion_termino_contrato", observacion_termino_contrato)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetGraba_consultoria_detalle_termino_grilla(ByVal cod_con_c As String, _
                                                            ByVal etapa_c As String, _
                                                            ByVal dias_legales As String, _
                                                            ByVal f_entrega_revision_etapa As String, _
                                                            ByVal plazo_total As String, _
                                                            ByVal dias_revision As String, _
                                                            ByVal observacion_c As String _
                                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_consultoria_detalle_termino_grilla", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@cod_con_c", cod_con_c)
                oCmd.Parameters.AddWithValue("@etapa_c", etapa_c)
                oCmd.Parameters.AddWithValue("@dias_legales", dias_legales)
                oCmd.Parameters.AddWithValue("@f_entrega_revision_etapa", f_entrega_revision_etapa)
                oCmd.Parameters.AddWithValue("@plazo_total", plazo_total)
                oCmd.Parameters.AddWithValue("@dias_revision", dias_revision)
                oCmd.Parameters.AddWithValue("@observacion_c", observacion_c)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetCancela_consultoria_detalle_termino(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_cancela_consultoria_detalle_termino_grilla", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Elimina_Contrato(ByVal codigo_pia As String, ByVal codigo_region As String, ByVal sufijo As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Elimina_Contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Elimina_Proyecto(ByVal codigo_pia As String, ByVal codigo_region As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_Elimina_Proyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@codigo_pia", codigo_pia)
                oCmd.Parameters.AddWithValue("@codigo_region", codigo_region)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_registros_conttas_categoria(ByVal registro As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_registros_conttas_categoria", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@registro", registro)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function


        Public Function SetMnt_Contrato_Estado(ByVal accion As String _
                                               , ByVal cod_con As String _
                                               , ByVal region As String _
                                               , ByVal sufijo As String _
                                               , ByVal estatus As String _
                                               , ByVal marca As String _
                                               ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_contrato_estado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@sufijo", sufijo)
                oCmd.Parameters.AddWithValue("@estatus", estatus)
                oCmd.Parameters.AddWithValue("@marca", marca)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Mnt_Complemento_Ambiental(ByVal accion As String _
                                           , ByVal CODIGO_PROYECTO As String _
                                           , ByVal CODIGO_COMPLEMENTO As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_complemento", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", CODIGO_PROYECTO)
                oCmd.Parameters.AddWithValue("@CODIGO_COMPLEMENTO", CODIGO_COMPLEMENTO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Set_Mnt_Multi_Financiamiento(ByVal accion As String _
                                            , ByVal REGION As String _
                                           , ByVal CODIGO_DA As String _
                                           , ByVal CODIGO As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_multi_financiamiento", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@region", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)
                oCmd.Parameters.AddWithValue("@CODIGO", CODIGO)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetMnt_Convenio_Estado(ByVal accion As String _
                                               , ByVal region As String _
                                               , ByVal codigo_da As String _
                                               , ByVal mandante As String _
                                               , ByVal correlativo As String _
                                               , ByVal estado As String _
                                               ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_convenio_estado", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@mandante", mandante)
                oCmd.Parameters.AddWithValue("@correlativo", correlativo)
                oCmd.Parameters.AddWithValue("@estado", estado)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetMnt_Edificacion(ByVal accion As String _
                                     , ByVal sector_destino As String _
                                     , ByVal subsector As String _
                                     , ByVal tipologia As String _
                                     , ByVal descripcion As String _
                                     , ByVal edi_orden_listado As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_tipos_edificacion", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@sector_destino", sector_destino)
                oCmd.Parameters.AddWithValue("@subsector", subsector)
                oCmd.Parameters.AddWithValue("@tipologia", tipologia)
                oCmd.Parameters.AddWithValue("@descripcion", descripcion)
                oCmd.Parameters.AddWithValue("@edi_orden_listado", edi_orden_listado)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

#End Region

#Region "Conexion ORACLE"

        Public Function GetObtener_Codigo_SAFI() As DataTable

            Dim strCodigoSAFI As String = ""
            Dim strConnectionStrings As String = ""

            Dim oConn As New OracleConnection
            Dim oCmd As New OracleCommand
            Dim retval As New OracleParameter

            Dim dtSalida As New DataTable
            Dim dcColumna As New DataColumn
            Dim drFila As DataRow

            Try

                dtSalida.TableName = "Tabla"

                dcColumna.ColumnName = "CodigoSAFI"
                dcColumna.DataType = System.Type.GetType("System.String")
                dcColumna.AllowDBNull = True
                dcColumna.Caption = "CodigoSAFI"

                dtSalida.Columns.Add(dcColumna)

                strConnectionStrings = ConfigurationManager.ConnectionStrings("conexion_safi_exploratorio").ToString

                oConn = New OracleConnection(strConnectionStrings)

                oConn.Open()

                oCmd.CommandText = "SA.PKG_SA_INTPYC.FN_CODSAFI"
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Connection = oConn

                'retval = New OracleParameter("CodigoSAFI", OracleDbType.Int64, 5)
                retval = New OracleParameter("CodigoSAFI", OracleType.Int32)

                retval.Direction = ParameterDirection.ReturnValue
                oCmd.Parameters.Add(retval)
                oCmd.ExecuteNonQuery()
                strCodigoSAFI = retval.Value.ToString()

                drFila = dtSalida.NewRow()
                drFila("CodigoSAFI") = strCodigoSAFI
                dtSalida.Rows.Add(drFila)

            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try
            Return dtSalida

        End Function

        Public Function SetGraba_Codigo_Relacional_Contrato(ByVal codigo_region As String _
                                                          , ByVal codigo_da As String _
                                                          , ByVal cod_con_spc As String _
                                                          , ByVal cod_con_safi As String _
                                                          ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_codigo_relacional_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@REGION", codigo_region)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", codigo_da)
                oCmd.Parameters.AddWithValue("@COD_CON_SPC", cod_con_spc)
                oCmd.Parameters.AddWithValue("@COD_CON_SAFI", cod_con_safi)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Function SetGraba_Datos_Exploratorio(ByVal strCodigoProyecto As String _
                                            , ByVal strCodigoProceso As String _
                                            , ByVal strNombreProyecto As String _
                                            , ByVal strObjeto As String _
                                            , ByVal strCodigoRegion As String _
                                            , ByVal strCodigoProvincia As String _
                                            , ByVal strCodigoComuna As String _
                                            , ByVal strCodigoBip As String _
                                            , ByVal strAnoInicio As String _
                                            , ByVal strMontoEstimado As String _
                                            , ByVal strEtapaMideplan As String _
                                            , ByVal strMontoEstimadoxEtapa As String _
                                            ) As DataTable

            Dim strConnectionStrings As String = ""

            Dim oConn As New OracleConnection
            Dim oCmd As New OracleCommand
            Dim retval As New OracleParameter

            Dim dtSalida As New DataTable
            Dim dcColumna As New DataColumn
            Dim drFila As DataRow

            Try

                dtSalida.TableName = "Tabla"

                'col1
                dcColumna.ColumnName = "vacio"
                dcColumna.DataType = System.Type.GetType("System.String")
                dcColumna.AllowDBNull = True
                dcColumna.Caption = "vacio"

                'agrega columnas
                dtSalida.Columns.Add(dcColumna)

                'conexion
                strConnectionStrings = ConfigurationManager.ConnectionStrings("conexion_safi_exploratorio").ToString
                oConn = New OracleConnection(strConnectionStrings)
                oConn.Open()

                'comando
                oCmd.CommandText = "EXPLO_ADMI.PKG_EXPLO_INTPYC.SPINSPROYECTO"
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Connection = oConn

                'parametros
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_Proyecto", OracleType.Int32, 10)).Value = Convert.ToInt32(strCodigoProyecto)
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_Proceso", OracleType.VarChar, 10)).Value = strCodigoProceso
                oCmd.Parameters.Add(New OracleParameter("p_Tipo_Inversion", OracleType.VarChar, 10)).Value = "PROYECTO"
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_bip", OracleType.VarChar, 10)).Value = strCodigoBip
                oCmd.Parameters.Add(New OracleParameter("p_Nombre_Proyecto", OracleType.VarChar, 290)).Value = strNombreProyecto
                oCmd.Parameters.Add(New OracleParameter("p_Objeto", OracleType.VarChar, 130)).Value = strObjeto
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_Region", OracleType.Int32, 10)).Value = Convert.ToInt32(strCodigoRegion)
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_Provincia", OracleType.Int32, 10)).Value = Convert.ToInt32(strCodigoProvincia)
                oCmd.Parameters.Add(New OracleParameter("p_Codigo_Comuna", OracleType.Int32, 10)).Value = Convert.ToInt32(strCodigoComuna)
                'oCmd.Parameters.Add(New OracleParameter("p_Direccion_Regional", OracleType.Int32, 10)).Value = Convert.ToInt32(strDireccionRegional)
                oCmd.Parameters.Add(New OracleParameter("p_Agno_Inicio", OracleType.Int32, 10)).Value = Convert.ToInt32(strAnoInicio)
                oCmd.Parameters.Add(New OracleParameter("p_Monto_Estimado", OracleType.Int32, 10)).Value = Convert.ToInt32(strMontoEstimado)
                oCmd.Parameters.Add(New OracleParameter("p_Etapa_Mideplan", OracleType.VarChar, 20)).Value = strEtapaMideplan
                oCmd.Parameters.Add(New OracleParameter("p_Monto_Estimado_Etapa", OracleType.Int32, 10)).Value = Convert.ToInt32(strMontoEstimadoxEtapa)

                oCmd.ExecuteNonQuery()

                drFila = dtSalida.NewRow()
                drFila("vacio") = ""
                dtSalida.Rows.Add(drFila)

            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return dtSalida

        End Function

        Public Function GetObtener_Numero_Exploratorio(ByVal Codigo_BIP As String) As DataTable

            Dim strConnectionStrings As String = ""

            Dim oConn As New OracleConnection
            Dim oCmd As New OracleCommand

            Dim dtSalida As New DataTable

            Dim dcExiste As New DataColumn
            Dim dcCodigoProyecto As New DataColumn
            Dim dcNombreProyecto As New DataColumn
            Dim dcCodigoRegion As New DataColumn
            Dim dcCodigoProvincia As New DataColumn
            Dim dcCodigoComuna As New DataColumn
            Dim dcCodigoProceso As New DataColumn
            Dim dcObjeto As New DataColumn
            Dim dcM2Superficie As New DataColumn
            Dim dcUsuarios As New DataColumn
            Dim dcBeneficiarios As New DataColumn
            'Dim myReader As OracleDataReader
            ' crear un dataset temporal
            Dim da As OracleDataAdapter
            Dim ds As DataSet = New DataSet
            Dim drFila As DataRow

            Try

                dtSalida.TableName = "Tabla"

                dcExiste.ColumnName = "Existe"
                dcExiste.DataType = System.Type.GetType("System.String")
                dcExiste.AllowDBNull = True
                dcExiste.Caption = "Existe"

                dcCodigoProyecto.ColumnName = "CodigoProyecto"
                dcCodigoProyecto.DataType = System.Type.GetType("System.String")
                dcCodigoProyecto.AllowDBNull = True
                dcCodigoProyecto.Caption = "CodigoProyecto"

                dcNombreProyecto.ColumnName = "NombreProyecto"
                dcNombreProyecto.DataType = System.Type.GetType("System.String")
                dcNombreProyecto.AllowDBNull = True
                dcNombreProyecto.Caption = "NombreProyecto"

                dcCodigoRegion.ColumnName = "CodigoRegion"
                dcCodigoRegion.DataType = System.Type.GetType("System.String")
                dcCodigoRegion.AllowDBNull = True
                dcCodigoRegion.Caption = "CodigoRegion"

                dcCodigoProvincia.ColumnName = "CodigoProvincia"
                dcCodigoProvincia.DataType = System.Type.GetType("System.String")
                dcCodigoProvincia.AllowDBNull = True
                dcCodigoProvincia.Caption = "CodigoProvincia"

                dcCodigoComuna.ColumnName = "CodigoComuna"
                dcCodigoComuna.DataType = System.Type.GetType("System.String")
                dcCodigoComuna.AllowDBNull = True
                dcCodigoComuna.Caption = "CodigoComuna"

                dcCodigoProceso.ColumnName = "CodigoProceso"
                dcCodigoProceso.DataType = System.Type.GetType("System.String")
                dcCodigoProceso.AllowDBNull = True
                dcCodigoProceso.Caption = "CodigoProceso"

                dcObjeto.ColumnName = "Objeto"
                dcObjeto.DataType = System.Type.GetType("System.String")
                dcObjeto.AllowDBNull = True
                dcObjeto.Caption = "Objeto"

                dcM2Superficie.ColumnName = "M2Superficie"
                dcM2Superficie.DataType = System.Type.GetType("System.String")
                dcM2Superficie.AllowDBNull = True
                dcM2Superficie.Caption = "M2Superficie"

                dcUsuarios.ColumnName = "Usuarios"
                dcUsuarios.DataType = System.Type.GetType("System.String")
                dcUsuarios.AllowDBNull = True
                dcUsuarios.Caption = "Usuarios"

                dcBeneficiarios.ColumnName = "Beneficiarios"
                dcBeneficiarios.DataType = System.Type.GetType("System.String")
                dcBeneficiarios.AllowDBNull = True
                dcBeneficiarios.Caption = "Beneficiarios"

                dtSalida.Columns.Add(dcExiste)
                dtSalida.Columns.Add(dcCodigoProyecto)
                dtSalida.Columns.Add(dcNombreProyecto)
                dtSalida.Columns.Add(dcCodigoRegion)
                dtSalida.Columns.Add(dcCodigoProvincia)
                dtSalida.Columns.Add(dcCodigoComuna)
                dtSalida.Columns.Add(dcCodigoProceso)
                dtSalida.Columns.Add(dcObjeto)
                dtSalida.Columns.Add(dcM2Superficie)
                dtSalida.Columns.Add(dcUsuarios)
                dtSalida.Columns.Add(dcBeneficiarios)

                strConnectionStrings = ConfigurationManager.ConnectionStrings("conexion_safiq_exploratorio").ToString

                oConn = New OracleConnection(strConnectionStrings)

                oConn.Open()

                oCmd.CommandText = "EXPLO_ADMI.PKG_EXPLO_INTPYC.SPSELPROYECTO"
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Connection = oConn

                oCmd.Parameters.Add(New OracleParameter("p_pro_codigo_bip", OracleType.VarChar, 15)).Value = Codigo_BIP

                oCmd.Parameters.Add(New OracleParameter("RC1", OracleType.Cursor)).Direction = ParameterDirection.Output

                oCmd.ExecuteNonQuery()

                'myReader = oCmd.Parameters("RC1").Value
                da = New OracleDataAdapter(oCmd)
                'con esto traspasamos toda la respuesta del pl a un dataset temporal 
                da.Fill(ds)

                For Each row As DataRow In ds.Tables(0).Rows


                    drFila = dtSalida.NewRow()

                    drFila("Existe") = row(1)
                    drFila("CodigoProyecto") = row(0)
                    drFila("NombreProyecto") = row(2)
                    drFila("CodigoProvincia") = row(4)
                    drFila("CodigoRegion") = row(3)
                    drFila("CodigoComuna") = row(5)
                    drFila("CodigoProceso") = row(6)
                    drFila("Objeto") = row(7)
                    drFila("M2Superficie") = row(10)
                    drFila("Usuarios") = row(11)
                    drFila("Beneficiarios") = row(12)

                    dtSalida.Rows.Add(drFila)

                Next

            Catch ex As Exception
                Throw ex
            Finally
                ds.Dispose()
                da.Dispose()
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return dtSalida

        End Function

#End Region

#Region "Patrimonio"

        Public Function Get_busca_uso_historico(ByVal codigo_proyecto As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_uso_historico", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", codigo_proyecto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function


        Public Function Set_mnt_uso_historico(ByVal accion As String _
                                              , ByVal codigo_proyecto As String _
                                              , ByVal categoria_uso As String _
                                              , ByVal tipologia_de_uso As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_uso_historico", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@codigo_proyecto", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@categoria_uso", categoria_uso)
                oCmd.Parameters.AddWithValue("@tipologia_de_uso", tipologia_de_uso)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(ByVal categoria As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@categoria", categoria)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function


        Public Function Get_busca_uso_actual(ByVal codigo_proyecto As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_uso_actual", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", codigo_proyecto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Set_mnt_uso_actual
        Public Function Set_mnt_uso_actual(ByVal accion As String _
                                              , ByVal codigo_proyecto As String _
                                              , ByVal categoria_uso As String _
                                              , ByVal tipologia_de_uso As String _
                                            ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_uso_actual", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@accion", accion)
                oCmd.Parameters.AddWithValue("@codigo_proyecto", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@categoria_uso", categoria_uso)
                oCmd.Parameters.AddWithValue("@tipologia_de_uso", tipologia_de_uso)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        'Get_busca_CODIGO_USOS_PATRIMONIAL
        Public Function Get_busca_CODIGO_USOS_PATRIMONIAL(ByVal categoria As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_CODIGO_USOS_PATRIMONIAL", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@categoria", categoria)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GET_MANTENCION_PATRIMONIO_BUSCA(ByVal cod_proyecto As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_MANTENCION_PATRIMONIO_BUSCA", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", cod_proyecto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

#End Region

#Region "EKV"

        Public Function Get_rpt_patrimonio(ByVal cod_proyecto As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_rpt_patrimonio", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@CODIGO_PROYECTO", cod_proyecto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        'EKV
        Public Function Set_MANTENCION_PATRIMONIO(ByVal opcion As String _
                                                                 , ByVal codigo_proyecto As String _
                                                                 , ByVal actualizacion_data_p As String _
                                                                 , ByVal autor_ficha As String _
                                                                 , ByVal tipo_ubicacion As String _
                                                                 , ByVal latitud_coordenada As String _
                                                                 , ByVal latitud_grados As String _
                                                                 , ByVal latitud_minutos As String _
                                                                 , ByVal latitud_segundos As String _
                                                                 , ByVal longitud_coordenada As String _
                                                                 , ByVal longitud_grados As String _
                                                                 , ByVal longitud_minutos As String _
                                                                 , ByVal longitud_segundos As String _
                                                                 , ByVal utm_x As String _
                                                                 , ByVal utm_y As String _
                                                                 , ByVal utm_uso As String _
                                                                 , ByVal propietario As String _
                                                                 , ByVal administrador As String _
                                                                 , ByVal figura_legal As String _
                                                                 , ByVal modelo_gestion As String _
                                                                 , ByVal inmueble_conservacion_historica As String _
                                                                 , ByVal zona_conservacion_historica As String _
                                                                 , ByVal componente_arqueologico As String _
                                                                 , ByVal componente_ambiental As String _
                                                                 , ByVal complemento_ambiental As String _
                                                                 , ByVal otras_superficies As String _
                                                                 , ByVal antecedentes_historicos As String _
                                                                 , ByVal estado_conservacion_actual As String _
                                                                 , ByVal principales_valores As String _
                                                                 , ByVal culturales As String _
                                                                 , ByVal proyecto_intervencion As String _
                                                                 , ByVal estructura_muros As String _
                                                                 , ByVal estructura_techumbre As String _
                                                                 , ByVal acabado_fachadas As String _
                                                                 , ByVal acabado_cubierta As String _
                                                                 , ByVal ornamentacion_relevante As String _
                                                                 , ByVal otros As String _
                                                                 , ByVal descripcion_componentes As String _
                                                                 , ByVal rev_anteproy_cmn_envio As String _
                                                                 , ByVal rev_anteproy_cmn_recepcion As String _
                                                                 , ByVal rev_proy_cmn_envio As String _
                                                                 , ByVal rev_proy_cmn_recepcion As String _
                                                                 , ByVal rev_dom_envio As String _
                                                                 , ByVal rev_dom_recepcion As String _
                                                                 , ByVal rev_sea_envio As String _
                                                                 , ByVal rev_sea_recepcion As String _
                                                                 , ByVal rev_minvu_envio As String _
                                                                 , ByVal rev_minvu_recepcion As String _
                                                                 , ByVal rev_otra_envio As String _
                                                                 , ByVal rev_otra_recepcionas As String _
                                                                 , ByVal monumento_historico As String _
                                                                 , ByVal tipo_docto_mh As String _
                                                                 , ByVal numero_docto_mh As String _
                                                                 , ByVal fecha_docto_mh As String _
                                                                 , ByVal zona_tipica As String _
                                                                 , ByVal tipo_docto_zt As String _
                                                                 , ByVal numero_docto_zt As String _
                                                                 , ByVal fecha_docto_zt As String _
                                                                 , ByVal monumento_arqueologico As String _
                                                                 , ByVal tipo_docto_ma As String _
                                                                 , ByVal numero_docto_ma As String _
                                                                 , ByVal fecha_docto_ma As String _
                                                                 , ByVal sis_contructivo_proy_rest As Integer _
                                                                 , ByVal sis_contructivo_obra_nueva As Integer _
                                                                 , ByVal princ_caracteristicas_constru As String _
                                                                 , ByVal rate As String _
                                                                 , ByVal superficie_total As String _
                                                            ) As DataTable
            'EKV

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_MANTENCION_PATRIMONIO", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                oCmd.Parameters.AddWithValue("@opcion", opcion)
                oCmd.Parameters.AddWithValue("@codigo_proyecto", codigo_proyecto)
                oCmd.Parameters.AddWithValue("@actualizacion_data_p", actualizacion_data_p)
                oCmd.Parameters.AddWithValue("@autor_ficha", autor_ficha)
                oCmd.Parameters.AddWithValue("@tipo_ubicacion", tipo_ubicacion)
                oCmd.Parameters.AddWithValue("@latitud_coordenada", latitud_coordenada)
                oCmd.Parameters.AddWithValue("@latitud_grados", latitud_grados)
                oCmd.Parameters.AddWithValue("@latitud_minutos", latitud_minutos)
                oCmd.Parameters.AddWithValue("@latitud_segundos", latitud_segundos)
                oCmd.Parameters.AddWithValue("@longitud_coordenada", longitud_coordenada)
                oCmd.Parameters.AddWithValue("@longitud_grados", longitud_grados)
                oCmd.Parameters.AddWithValue("@longitud_minutos", longitud_minutos)
                oCmd.Parameters.AddWithValue("@longitud_segundos", longitud_segundos)
                oCmd.Parameters.AddWithValue("@utm_x", utm_x)
                oCmd.Parameters.AddWithValue("@utm_y", utm_y)
                oCmd.Parameters.AddWithValue("@utm_uso", utm_uso)
                oCmd.Parameters.AddWithValue("@propietario", propietario)
                oCmd.Parameters.AddWithValue("@administrador", administrador)
                oCmd.Parameters.AddWithValue("@figura_legal", figura_legal)
                oCmd.Parameters.AddWithValue("@modelo_gestion", modelo_gestion)
                oCmd.Parameters.AddWithValue("@inmueble_conservacion_historica", inmueble_conservacion_historica)
                oCmd.Parameters.AddWithValue("@zona_conservacion_historica", zona_conservacion_historica)
                oCmd.Parameters.AddWithValue("@componente_arqueologico", componente_arqueologico)
                oCmd.Parameters.AddWithValue("@componente_ambiental", componente_ambiental)
                oCmd.Parameters.AddWithValue("@complemento_ambiental", complemento_ambiental)
                oCmd.Parameters.AddWithValue("@otras_superficies", otras_superficies)
                oCmd.Parameters.AddWithValue("@antecedentes_historicos", antecedentes_historicos)
                oCmd.Parameters.AddWithValue("@estado_conservacion_actual", estado_conservacion_actual)
                oCmd.Parameters.AddWithValue("@principales_valores", principales_valores)
                oCmd.Parameters.AddWithValue("@culturales", culturales)
                oCmd.Parameters.AddWithValue("@proyecto_intervencion", proyecto_intervencion)
                oCmd.Parameters.AddWithValue("@estructura_muros", estructura_muros)
                oCmd.Parameters.AddWithValue("@estructura_techumbre", estructura_techumbre)
                oCmd.Parameters.AddWithValue("@acabado_fachadas", acabado_fachadas)
                oCmd.Parameters.AddWithValue("@acabado_cubierta", acabado_cubierta)
                oCmd.Parameters.AddWithValue("@ornamentacion_relevante", ornamentacion_relevante)
                oCmd.Parameters.AddWithValue("@otros", otros)
                oCmd.Parameters.AddWithValue("@descripcion_componentes", descripcion_componentes)
                oCmd.Parameters.AddWithValue("@rev_anteproy_cmn_envio", rev_anteproy_cmn_envio)
                oCmd.Parameters.AddWithValue("@rev_anteproy_cmn_recepcion", rev_anteproy_cmn_recepcion)
                oCmd.Parameters.AddWithValue("@rev_proy_cmn_envio", rev_proy_cmn_envio)
                oCmd.Parameters.AddWithValue("@rev_proy_cmn_recepcion", rev_proy_cmn_recepcion)
                oCmd.Parameters.AddWithValue("@rev_dom_envio", rev_dom_envio)
                oCmd.Parameters.AddWithValue("@rev_dom_recepcion", rev_dom_recepcion)
                oCmd.Parameters.AddWithValue("@rev_sea_envio", rev_sea_envio)
                oCmd.Parameters.AddWithValue("@rev_sea_recepcion", rev_sea_recepcion)
                oCmd.Parameters.AddWithValue("@rev_minvu_envio", rev_minvu_envio)
                oCmd.Parameters.AddWithValue("@rev_minvu_recepcion", rev_minvu_recepcion)
                oCmd.Parameters.AddWithValue("@rev_otra_envio", rev_otra_envio)
                oCmd.Parameters.AddWithValue("@rev_otra_recepcionas", rev_otra_recepcionas)
                oCmd.Parameters.AddWithValue("@monumento_historico", monumento_historico)
                oCmd.Parameters.AddWithValue("@tipo_docto_mh", tipo_docto_mh)
                oCmd.Parameters.AddWithValue("@numero_docto_mh", numero_docto_mh)
                oCmd.Parameters.AddWithValue("@fecha_docto_mh", fecha_docto_mh)
                oCmd.Parameters.AddWithValue("@zona_tipica", zona_tipica)
                oCmd.Parameters.AddWithValue("@tipo_docto_zt", tipo_docto_zt)
                oCmd.Parameters.AddWithValue("@numero_docto_zt", numero_docto_zt)
                oCmd.Parameters.AddWithValue("@fecha_docto_zt", fecha_docto_zt)
                oCmd.Parameters.AddWithValue("@monumento_arqueologico", monumento_arqueologico)
                oCmd.Parameters.AddWithValue("@tipo_docto_ma", tipo_docto_ma)
                oCmd.Parameters.AddWithValue("@numero_docto_ma", numero_docto_ma)
                oCmd.Parameters.AddWithValue("@fecha_docto_ma", fecha_docto_ma)

                oCmd.Parameters.AddWithValue("@sis_contructivo_proy_rest", sis_contructivo_proy_rest)
                oCmd.Parameters.AddWithValue("@sis_contructivo_obra_nueva", sis_contructivo_obra_nueva)
                oCmd.Parameters.AddWithValue("@princ_caracteristicas_constru", princ_caracteristicas_constru)

                oCmd.Parameters.AddWithValue("@rate", rate)
                oCmd.Parameters.AddWithValue("@superficie_total", superficie_total)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function


        Public Function SetMnt_valida_existencia_contrato(ByVal cod_con As String) As DataTable




            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_valida_existencia_contrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetMnt_updateImagenesContratos(ByVal cod_con As String _
                                                  , ByVal pathImagen As String _
                                                  , ByVal nombImagen As String _
                                                  , ByVal TipoImagen As String) As DataTable



            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_updateImagenesContratos", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                oCmd.Parameters.AddWithValue("@pathImagen", pathImagen)
                oCmd.Parameters.AddWithValue("@nombImagen", nombImagen)
                oCmd.Parameters.AddWithValue("@TipoImagen", TipoImagen)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

        Public Function SetMnt_Imagen(ByVal codcon As String _
                                     , ByVal fuImgProyecto As String
                                     ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_graba_imagen", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@COD_CON", codcon)
                oCmd.Parameters.AddWithValue("@Imagen", fuImgProyecto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function Setmnt_ImagenesContrato_BorraContrato(ByVal cod_con As String) As DataTable



            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_mnt_ImagenesContrato_BorraContrato", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function


        Public Function Get_busca_tipo_proceso(ByVal codigo_contrato As String _
        ) As DataTable


            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_tipo_proceso", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@codigo_contrato", codigo_contrato)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function


        Public Function Get_busca_imgFichaProyecto(ByVal cod_con As String) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_busca_imgFichaProyecto", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@cod_con", cod_con)
                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function

#End Region


#Region "Metodos para Programación de Montos IDEA"

        Public Function SetGrabaProgramacionMontoIdea(ByVal region As String _
                                                    , ByVal codigo_da As String _
                                                    , ByVal agno As String _
                                                    , ByVal monto As String _
                                                    ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_grabar_programacion_monto_idea", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@agno", agno)
                oCmd.Parameters.AddWithValue("@monto", monto)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function SetEliminaProgramacionMontoIdea(ByVal region As String _
                                                      , ByVal codigo_da As String _
                                                      , ByVal agno As String _
                                                      ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet

            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_elimina_programacion_monto_idea", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@region", region)
                oCmd.Parameters.AddWithValue("@codigo_da", codigo_da)
                oCmd.Parameters.AddWithValue("@agno", agno)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

        Public Function GetProgramacionMontoIdea(ByVal REGION As String _
                                               , ByVal CODIGO_DA As String _
                                               ) As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("sp_busca_Programacion_Monto_Idea", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")
                oCmd.Parameters.AddWithValue("@REGION", REGION)
                oCmd.Parameters.AddWithValue("@CODIGO_DA", CODIGO_DA)

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)
        End Function

#End Region

    End Class

End Namespace