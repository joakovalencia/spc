Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Web.Services
Imports System.Xml
Imports PYC.Utilities.PYC.Utilities
Imports PYC.Utilities.PYC.Utilities.DataAccess
Imports PYC.Utilities.PYC.Utilities.Input

' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://www.pyc.cl/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Partial Public Class WSSPC
    Inherits System.Web.Services.WebService

#Region "Metodos JG"

    <WebMethod()>
    Public Function GetConsultaGeneral(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim Tipo As String = String.Empty

        Dim dt As DataTable
        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().ValidaConsulta(parametro, Tipo) Then
                Dim ac As New AccessLayer()

                Dim SP As String = GetStoredProcedure(Tipo)

                If SP = "" Then
                    result.Append(ResultMessages.GetInstance().GetResultXML_SinSP())
                    Exit Try
                End If

                dt = ac.GetConsultaGeneral(SP)
                result.Append(GenerateResultXML(dt, 1)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function SetMnt_Ing_Proyectos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim tipo_proy As String = ""
        Dim plan As Long = 0
        Dim producto As String = ""
        Dim proceso As String = ""
        Dim objeto As String = ""
        Dim fondo As String = ""
        Dim sector_destino As String = ""

        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Ing_Proyectos(parametro,
                                                                       region,
                                                                       tipo_proy,
                                                                       plan,
                                                                       producto,
                                                                       proceso,
                                                                       objeto,
                                                                       fondo,
                                                                       sector_destino) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Ing_Proyectos(region,
                                             tipo_proy,
                                             plan,
                                             producto,
                                             proceso,
                                             objeto,
                                             fondo,
                                             sector_destino)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetLlena_Codigo_Contratos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_region_inicio As String
        Dim str_region_fin As String
        Dim str_fecha_inicio As String
        Dim str_fecha_fin As String

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetLlena_Codigo_Contratos(parametro,
                                                                            str_region_inicio,
                                                                            str_region_fin,
                                                                            str_fecha_inicio,
                                                                            str_fecha_fin) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetLlena_Codigo_Contratos(str_region_inicio,
                                                  str_region_fin,
                                                  str_fecha_inicio,
                                                  str_fecha_fin)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Usuarios(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim usuario As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Usuarios(parametro, usuario) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Usuarios(usuario)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Tipos_Usuarios(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_tipo_usuario As Long = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Tipos_Usuarios(parametro, codigo_tipo_usuario) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Tipos_Usuarios(codigo_tipo_usuario)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Proyectos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_tipo_proyecto As String = ""
        Dim str_region_inicio As String = ""
        Dim str_region_fin As String = ""
        Dim str_estado_inicio As String = ""
        Dim str_estado_fin As String = ""
        Dim str_proceso_inicio As String = ""
        Dim str_proceso_fin As String = ""

        Dim str_bd_con_proy As String = ""
        Dim str_con_proy As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Proyectos(parametro,
                                                                     str_tipo_proyecto,
                                                                     str_region_inicio,
                                                                     str_region_fin,
                                                                     str_estado_inicio,
                                                                     str_estado_fin,
                                                                     str_proceso_inicio,
                                                                     str_proceso_fin,
                                                                     str_bd_con_proy,
                                                                     str_con_proy) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Proyectos(str_tipo_proyecto,
                                           str_region_inicio,
                                           str_region_fin,
                                           str_estado_inicio,
                                           str_estado_fin,
                                           str_proceso_inicio,
                                           str_proceso_fin,
                                           str_bd_con_proy,
                                           str_con_proy)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Proyecto_Encabezado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Proyecto_Encabezado(parametro,
                                                                               codigo_pia,
                                                                               codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Proyecto_Encabezado(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Proyecto_Contratos_Relacionados_Encabezado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Proyecto_Contratos_Relacionados_Encabezado(parametro,
                                                                                                      codigo_pia,
                                                                                                      codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Proyecto_Contratos_Relacionados_Encabezado(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Proyecto_Contratos_Relacionados_Detalle(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Proyecto_Contratos_Relacionados_Detalle(parametro,
                                                                                                   codigo_pia,
                                                                                                   codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Proyecto_Contratos_Relacionados_Detalle(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Permisos_usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_tipo_usuario As Long = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Permisos_usuario(parametro, codigo_tipo_usuario) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Permisos_usuario(codigo_tipo_usuario)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Contratos_Encabezado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Contratos_Encabezado(parametro, codigo_pia, codigo_region, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Contratos_Encabezado(codigo_pia, codigo_region, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Contratos_Detalle_Datos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Contratos_Detalle_Datos(parametro, codigo_pia, codigo_region, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Contratos_Detalle_Datos(codigo_pia, codigo_region, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Correlativo_Proceso_Relacionados_Edita(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim tipologia As String = ""
        Dim etapa As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Correlativo_Proceso_Relacionados_Edita(parametro, tipologia, etapa) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Correlativo_Proceso_Relacionados_Edita(tipologia, etapa)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Correlativo_Mandantes_Relacionados_Edita(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Correlativo_Mandantes_Relacionados_Edita(parametro, codigo_pia, codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Correlativo_Mandantes_Relacionados_Edita(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Correlativo_Etapa_Relacionados_Edita(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Correlativo_Etapa_Relacionados_Edita(parametro, codigo_pia, codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Correlativo_Etapa_Relacionados_Edita(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Correlativo_Convenios_Relacionados_Edita(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_correlativo_convenios_relacionados_edita(parametro, codigo_pia, codigo_region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_correlativo_convenios_relacionados_edita(codigo_pia, codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function GetBusca_Datos_Usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim usuario As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Datos_Usuario(parametro, usuario) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Datos_Usuario(usuario)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121125
    <WebMethod()>
    Public Function GetBusca_Provincia(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim Region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Provincia(parametro, Region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Provincia(Region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121125
    <WebMethod()>
    Public Function GetContratistaAdjudicado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetContratistaAdjudicado(parametro, region, codigo_da, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetContratistaAdjudicado(region, codigo_da, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function SetGraba_Contratos_Detalle_Datos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim strlegal As String = ""
        Dim strambiental As String = ""
        Dim strexpropiacion As String = ""
        Dim strlicitacion As String = ""
        Dim strejecucion As String = ""
        Dim straumento_costos As String = ""
        Dim strexplicacion_o_alertas As String = ""
        Dim strapertura_licitacion As String = ""
        Dim strprimera_piedra As String = ""
        Dim strinauguracion As String = ""
        Dim intProximo_Hito As String = ""
        Dim strObservacionMandante As String = ""
        Dim strResp_Administrativo As String = ""

        Dim Retorno As Integer
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_Contratos_Detalle_Datos(parametro,
                                                                                   codigo_pia,
                                                                                   codigo_region,
                                                                                   sufijo,
                                                                                   strlegal,
                                                                                   strambiental,
                                                                                   strexpropiacion,
                                                                                   strlicitacion,
                                                                                   strejecucion,
                                                                                   straumento_costos,
                                                                                   strexplicacion_o_alertas,
                                                                                   strapertura_licitacion,
                                                                                   strprimera_piedra,
                                                                                   strinauguracion,
                                                                                   intProximo_Hito,
                                                                                   strObservacionMandante,
                                                                                   strResp_Administrativo) Then
                Dim ac As New AccessLayer()

                Retorno = ac.SetGraba_Contratos_Detalle_Datos(codigo_pia,
                                                              codigo_region,
                                                              sufijo,
                                                              strlegal,
                                                              strambiental,
                                                              strexpropiacion,
                                                              strlicitacion,
                                                              strejecucion,
                                                              straumento_costos,
                                                              strexplicacion_o_alertas,
                                                              strapertura_licitacion,
                                                              strprimera_piedra,
                                                              strinauguracion,
                                                              intProximo_Hito,
                                                              strObservacionMandante,
                                                              strResp_Administrativo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function SetGraba_Contratos_Detalle_Edicion(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim numcorrelativo_convenio As String = ""
        Dim strmandante_convenio As String = ""
        Dim stretapa As String = ""
        Dim strtipo_proceso As String = ""
        Dim strfinanciamiento As String = ""
        Dim strobjeto As String = ""

        Dim Retorno As Integer
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_Contratos_Detalle_Edicion(parametro,
                                                                                     codigo_pia,
                                                                                     codigo_region,
                                                                                     sufijo,
                                                                                     numcorrelativo_convenio,
                                                                                     strmandante_convenio,
                                                                                     stretapa,
                                                                                     strtipo_proceso,
                                                                                     strfinanciamiento,
                                                                                     strobjeto) Then
                Dim ac As New AccessLayer()

                Retorno = ac.SetGraba_Contratos_Detalle_Edicion(codigo_pia,
                                                                codigo_region,
                                                                sufijo,
                                                                numcorrelativo_convenio,
                                                                strmandante_convenio,
                                                                stretapa,
                                                                strtipo_proceso,
                                                                strfinanciamiento,
                                                                strobjeto)

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function SetMnt_Comunas(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim region As String = ""
        Dim provincia As String = ""
        Dim comuna As String = ""
        Dim cod_comun As String = ""
        Dim n_comu As String = ""
        Dim poblacion As Long = 0

        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Comunas(parametro,
                                                                 accion,
                                                                 region,
                                                                 provincia,
                                                                 comuna,
                                                                 cod_comun,
                                                                 n_comu,
                                                                 poblacion) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Comunas(accion,
                                       region,
                                       provincia,
                                       comuna,
                                       cod_comun,
                                       n_comu,
                                       poblacion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function


    <WebMethod()>
    Public Function SetMnt_Dom_Insp_Fis(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim rut As String = ""
        Dim nombre As String = ""
        Dim profesion As String = ""
        Dim sexo As String = ""

        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Dom_Insp_Fis(parametro, accion, rut, nombre, profesion, sexo) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Dom_Insp_Fis(accion, rut, nombre, profesion, sexo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Permisos_Usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_tipo_usuario As Long = 0
        Dim codigo_opcion As Long = 0
        Dim asignar As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Permisos_Usuario(parametro, accion, codigo_tipo_usuario, codigo_opcion, asignar) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Permisos_Usuario(accion, codigo_tipo_usuario, codigo_opcion, asignar)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim nombre_usuario As String = ""
        Dim correo_electronico As String = ""
        Dim codigo_tipo_usuario As Long = 0
        Dim nombre_completo As String = ""
        Dim nombre_usuario_corto As String = ""
        Dim region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Usuario(parametro, accion, nombre_usuario, correo_electronico, codigo_tipo_usuario, nombre_completo, nombre_usuario_corto, region) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Usuario(accion, nombre_usuario, correo_electronico, codigo_tipo_usuario, nombre_completo, nombre_usuario_corto, region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetValida_Acceso_Menu_Usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_tipo_usuario As Long = 0
        Dim opcion_menu As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetValida_Acceso_Menu_Usuario(parametro, codigo_tipo_usuario, opcion_menu) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetValida_Acceso_Menu_Usuario(codigo_tipo_usuario, opcion_menu)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetValida_Login_Usuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim usuario As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetValida_Login_Usuario(parametro, usuario) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetValida_Login_Usuario(usuario)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Contratista(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim rut_ctta As String = ""
        Dim n_ctta As String = ""
        Dim registro As String = ""
        Dim categoria As String = ""
        Dim telefono_fax As String = ""
        Dim sexo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Contratista(parametro, _
                                                                     accion, _
                                                                     rut_ctta, _
                                                                     n_ctta, _
                                                                     registro, _
                                                                     categoria, _
                                                                     telefono_fax, _
                                                                     sexo) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Contratista(accion, _
                                           rut_ctta, _
                                           n_ctta, _
                                           registro, _
                                           categoria, _
                                           telefono_fax, _
                                           sexo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121127
    <WebMethod()> _
    Public Function GetContratosPropuestas(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetContratosPropuestas(parametro, region, codigo_da, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetContratosPropuestas(region, codigo_da, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121127
    <WebMethod()> _
    Public Function GetOfertasPropuestaContratista(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetOfertasPropuestaContratista(parametro, region, codigo_da, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetOfertasPropuestaContratista(region, codigo_da, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121127
    <WebMethod()> _
    Public Function GetDomMandantes2(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetDomMandantes2(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetDomMandantes2(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121127
    <WebMethod()> _
    Public Function SetMandantesContrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim MANDANTE As String = ""
        Dim REGION As String = ""
        Dim CODIGO_DA As String = ""
        Dim SUFIJO As String = ""
        Dim COD_CON As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMandantesContrato(parametro _
                                                                     , MANDANTE _
                                                                     , REGION _
                                                                     , CODIGO_DA _
                                                                     , SUFIJO _
                                                                     , COD_CON _
                                                                     ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMandantesContrato(MANDANTE _
                                           , REGION _
                                           , CODIGO_DA _
                                           , SUFIJO _
                                           , COD_CON _
                                           )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121127
    <WebMethod()> _
    Public Function SetOfertasPropuestas(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim REGION As String = ""
        Dim CODIGO_DA As String = ""
        Dim SUFIJO As String = ""
        Dim RUT_CTTA As String = ""
        Dim DESCRIPCION As String = ""
        Dim MONTO As Double = 0
        Dim PLAZO As Integer = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetOfertasPropuestas(parametro, _
                                                                     REGION _
                                                                   , CODIGO_DA _
                                                                   , SUFIJO _
                                                                   , RUT_CTTA _
                                                                   , DESCRIPCION _
                                                                   , MONTO _
                                                                   , PLAZO _
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetOfertasPropuestas(REGION _
                                          , CODIGO_DA _
                                          , SUFIJO _
                                          , RUT_CTTA _
                                          , DESCRIPCION _
                                          , MONTO _
                                          , PLAZO _
                                          )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function


    ''JGM 20121127
    <WebMethod()> _
    Public Function SetContratoPropuesta(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim REGION As String = ""
        Dim CODIGO_DA As String = ""
        Dim SUFIJO As String = ""
        Dim T_F1 As String = ""
        Dim PROVINCIA As String = ""
        Dim COMUNA As String = ""
        Dim CODIGO_LOCALIDAD As Long = 0
        Dim TIPO_PROCESO As String = ""
        Dim OBJETO As String = ""
        Dim LOCALIZACION As String = ""
        Dim NUMERO_LOCALIZACION As String = ""
        Dim MANDANTE_CONVENIO As String = ""
        Dim CORRELATIVO_CONVENIO As Integer = 0
        Dim ESTATUS As String = ""
        Dim VALIDO As Integer = 0
        Dim TI_LIC As String = ""
        Dim TI_CON As String = ""
        Dim TIPO_REAJUSTE As String = ""
        Dim FECHA_LIC_PR As String = ""
        Dim FECHA_AP_ESTIMADA As String = ""
        Dim FECHA_AP_PR As String = ""
        Dim FECHA_AP_PR_ECO As String = ""
        Dim FECHA_INICIO_ESTIMADA As String = ""
        Dim BASES_ADMIN_GENERALES As String = ""
        Dim BASES_ADMIN_ESPECIALES As String = ""
        Dim BASES_TECNICAS As String = ""
        Dim CARPETA_TECNICA_LICITACION As String = ""
        Dim REGISTRO As String = ""
        Dim CATEGORIA As String = ""
        Dim MONTO_PROGRA As Double = 0
        Dim PLAZO_ESTIMADO_EJEC As Integer = 0
        Dim RESP_ANTECEDENTES_PPTA As String = ""
        Dim ANTICIPO_CONTEMPLADO As Double = 0
        Dim ANTIC_CONTEMPL_PORC As Double = 0
        Dim APLICA_CARTILLA_R_26 As String = ""
        Dim FECHA_DOCTO_R26 As String = ""
        Dim APLICA_CARTILLA_R_28 As String = ""
        Dim FECHA_DOCTO_R28 As String = ""
        Dim APLICA_CARTILLA_R_29 As String = ""
        Dim FECHA_DOCTO_R29 As String = ""
        Dim REQUIERE_REG_ESPECIAL As String = ""
        Dim N_PERMISO_EDIFICACION As String = ""
        Dim FECHA_PERMISO_EDIFICACION As String = ""
        Dim id_chile_compra As String = ""
        Dim ces As String = ""
        Dim N_DOCTO_R5 As Long = 0
        Dim FECHA_DOCTO_R5 As String = ""
        Dim FECHA_LIC As String = ""
        Dim F_AP_TECNICA_PROP As String = ""
        Dim F_AP_PROP As String = ""
        Dim PLAZO_OFICIAL As Integer = 0
        Dim MT_OFI As Double = 0
        Dim OBSERVACIONES_PROP As String = ""
        Dim RESULTADO_PROPUESTA As String = ""
        Dim RESP_LCITACION As String = ""
        Dim LLAMADO As Integer = 0
        Dim n_res_no_adjudica As Integer = 0
        Dim f_res_no_adjudica As String = ""
        Dim FECHA_INFORME_ADJUDICACION As String = ""
        Dim MTO_OR As Double = 0
        Dim PLAZO_OR As Double = 0
        Dim OR_RES As String = ""
        Dim N_RES As Integer = 0
        Dim F_RES As String = ""
        Dim F_TRAMI As String = ""
        Dim RUT_CON As String = ""
        Dim COM_EVAL_OFERTA1 As String = ""
        Dim COM_EVAL_OFERTA2 As String = ""
        Dim COM_EVAL_OFERTA3 As String = ""
        Dim adjudicado As String = ""
        Dim SECCION As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetContratoPropuesta(parametro, _
                                                                     REGION _
                                                                    , CODIGO_DA _
                                                                    , SUFIJO _
                                                                    , T_F1 _
                                                                    , PROVINCIA _
                                                                    , COMUNA _
                                                                    , CODIGO_LOCALIDAD _
                                                                    , TIPO_PROCESO _
                                                                    , OBJETO _
                                                                    , LOCALIZACION _
                                                                    , NUMERO_LOCALIZACION _
                                                                    , MANDANTE_CONVENIO _
                                                                    , CORRELATIVO_CONVENIO _
                                                                    , ESTATUS _
                                                                    , VALIDO _
                                                                    , TI_LIC _
                                                                    , TI_CON _
                                                                    , TIPO_REAJUSTE _
                                                                    , FECHA_LIC_PR _
                                                                    , FECHA_AP_ESTIMADA _
                                                                    , FECHA_AP_PR _
                                                                    , FECHA_AP_PR_ECO _
                                                                    , FECHA_INICIO_ESTIMADA _
                                                                    , BASES_ADMIN_GENERALES _
                                                                    , BASES_ADMIN_ESPECIALES _
                                                                    , BASES_TECNICAS _
                                                                    , CARPETA_TECNICA_LICITACION _
                                                                    , REGISTRO _
                                                                    , CATEGORIA _
                                                                    , MONTO_PROGRA _
                                                                    , PLAZO_ESTIMADO_EJEC _
                                                                    , RESP_ANTECEDENTES_PPTA _
                                                                    , ANTICIPO_CONTEMPLADO _
                                                                    , ANTIC_CONTEMPL_PORC _
                                                                    , APLICA_CARTILLA_R_26 _
                                                                    , FECHA_DOCTO_R26 _
                                                                    , APLICA_CARTILLA_R_28 _
                                                                    , FECHA_DOCTO_R28 _
                                                                    , APLICA_CARTILLA_R_29 _
                                                                    , FECHA_DOCTO_R29 _
                                                                    , REQUIERE_REG_ESPECIAL _
                                                                    , N_PERMISO_EDIFICACION _
                                                                    , FECHA_PERMISO_EDIFICACION _
                                                                    , id_chile_compra _
                                                                    , ces _
                                                                    , N_DOCTO_R5 _
                                                                    , FECHA_DOCTO_R5 _
                                                                    , FECHA_LIC _
                                                                    , F_AP_TECNICA_PROP _
                                                                    , F_AP_PROP _
                                                                    , PLAZO_OFICIAL _
                                                                    , MT_OFI _
                                                                    , OBSERVACIONES_PROP _
                                                                    , RESULTADO_PROPUESTA _
                                                                    , RESP_LCITACION _
                                                                    , LLAMADO _
                                                                    , n_res_no_adjudica _
                                                                    , f_res_no_adjudica _
                                                                    , FECHA_INFORME_ADJUDICACION _
                                                                    , MTO_OR _
                                                                    , PLAZO_OR _
                                                                    , OR_RES _
                                                                    , N_RES _
                                                                    , F_RES _
                                                                    , F_TRAMI _
                                                                    , RUT_CON _
                                                                    , COM_EVAL_OFERTA1 _
                                                                    , COM_EVAL_OFERTA2 _
                                                                    , COM_EVAL_OFERTA3 _
                                                                    , adjudicado _
                                                                    , SECCION) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetContratoPropuesta(REGION _
                                            , CODIGO_DA _
                                            , SUFIJO _
                                            , T_F1 _
                                            , PROVINCIA _
                                            , COMUNA _
                                            , CODIGO_LOCALIDAD _
                                            , TIPO_PROCESO _
                                            , OBJETO _
                                            , LOCALIZACION _
                                            , NUMERO_LOCALIZACION _
                                            , MANDANTE_CONVENIO _
                                            , CORRELATIVO_CONVENIO _
                                            , ESTATUS _
                                            , VALIDO _
                                            , TI_LIC _
                                            , TI_CON _
                                            , TIPO_REAJUSTE _
                                            , FECHA_LIC_PR _
                                            , FECHA_AP_ESTIMADA _
                                            , FECHA_AP_PR _
                                            , FECHA_AP_PR_ECO _
                                            , FECHA_INICIO_ESTIMADA _
                                            , BASES_ADMIN_GENERALES _
                                            , BASES_ADMIN_ESPECIALES _
                                            , BASES_TECNICAS _
                                            , CARPETA_TECNICA_LICITACION _
                                            , REGISTRO _
                                            , CATEGORIA _
                                            , MONTO_PROGRA _
                                            , PLAZO_ESTIMADO_EJEC _
                                            , RESP_ANTECEDENTES_PPTA _
                                            , ANTICIPO_CONTEMPLADO _
                                            , ANTIC_CONTEMPL_PORC _
                                            , APLICA_CARTILLA_R_26 _
                                            , FECHA_DOCTO_R26 _
                                            , APLICA_CARTILLA_R_28 _
                                            , FECHA_DOCTO_R28 _
                                            , APLICA_CARTILLA_R_29 _
                                            , FECHA_DOCTO_R29 _
                                            , REQUIERE_REG_ESPECIAL _
                                            , N_PERMISO_EDIFICACION _
                                            , FECHA_PERMISO_EDIFICACION _
                                            , id_chile_compra _
                                            , ces _
                                            , N_DOCTO_R5 _
                                            , FECHA_DOCTO_R5 _
                                            , FECHA_LIC _
                                            , F_AP_TECNICA_PROP _
                                            , F_AP_PROP _
                                            , PLAZO_OFICIAL _
                                            , MT_OFI _
                                            , OBSERVACIONES_PROP _
                                            , RESULTADO_PROPUESTA _
                                            , RESP_LCITACION _
                                            , LLAMADO _
                                            , n_res_no_adjudica _
                                            , f_res_no_adjudica _
                                            , FECHA_INFORME_ADJUDICACION _
                                            , MTO_OR _
                                            , PLAZO_OR _
                                            , OR_RES _
                                            , N_RES _
                                            , F_RES _
                                            , F_TRAMI _
                                            , RUT_CON _
                                            , COM_EVAL_OFERTA1 _
                                            , COM_EVAL_OFERTA2 _
                                            , COM_EVAL_OFERTA3 _
                                            , adjudicado _
                                            , SECCION)

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121128
    <WebMethod()> _
    Public Function GetBuscaDomTiposEtapa(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim typologia As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaDomTiposEtapa(parametro, typologia) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaDomTiposEtapa(typologia)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM 20121128
    <WebMethod()> _
    Public Function SetGrabaEtapa(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim etapa As String = ""
        Dim codigo_bip As String = ""
        Dim parte As String = ""
        Dim monto_etapa As Double = 0
        Dim descripcion As String = ""
        Dim fecha_ingreso As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaEtapa(parametro, region, _
                                                                           codigo_da, _
                                                                           etapa, _
                                                                           codigo_bip, _
                                                                           parte, _
                                                                           monto_etapa, _
                                                                           descripcion, _
                                                                           fecha_ingreso) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaEtapa(region, _
                                      codigo_da, _
                                      etapa, _
                                      codigo_bip, _
                                      parte, _
                                      monto_etapa, _
                                      descripcion, _
                                      fecha_ingreso)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121128
    <WebMethod()> _
    Public Function GetBuscaConveniosModif(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As Integer = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaConveniosModif(parametro, region, codigo_da, mandante) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaConveniosModif(region, codigo_da, mandante)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121128
    <WebMethod()> _
    Public Function SetGrabarConveniosModif(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim fecha_decreto As String = ""
        Dim correlativo As Integer = 0
        Dim num_decreto As Integer = 0
        Dim fecha_convenio As String = ""
        Dim fecha_ingreso As String = ""
        Dim monto_neto_mod As Double = 0
        Dim gasto_adm_mod As Double = 0
        Dim consul_mod As Double = 0
        Dim otros_gastos_mod As Double = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabarConveniosModif(parametro, region, _
                                                                            codigo_da, _
                                                                            mandante, _
                                                                            fecha_decreto, _
                                                                            correlativo, _
                                                                            num_decreto, _
                                                                            fecha_convenio, _
                                                                            fecha_ingreso, _
                                                                            monto_neto_mod, _
                                                                            gasto_adm_mod, _
                                                                            consul_mod, _
                                                                            otros_gastos_mod) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabarConveniosModif(region, _
                                                codigo_da, _
                                                mandante, _
                                                fecha_decreto, _
                                                correlativo, _
                                                num_decreto, _
                                                fecha_convenio, _
                                                fecha_ingreso, _
                                                monto_neto_mod, _
                                                gasto_adm_mod, _
                                                consul_mod, _
                                                otros_gastos_mod)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function GetBuscaEtapa(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""


        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaEtapa(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaEtapa(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function GetBuscaConvenios(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As Integer = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaConvenios(parametro, region, codigo_da, mandante, correlativo) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaConvenios(region, codigo_da, mandante, correlativo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function SetGrabaProceso_ssd(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim tipo As String = ""
        Dim cod_con As String = ""
        Dim sufijo As String = ""
        Dim codigo_da As String = ""
        Dim region As String = ""
        Dim numero_proceso As String = ""
        Dim descripcion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaProceso_ssd(parametro, _
                                                                    accion, _
                                                                    tipo, _
                                                                    cod_con, _
                                                                    sufijo, _
                                                                    codigo_da, _
                                                                    region, _
                                                                    numero_proceso, _
                                                                    descripcion) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaProceso_ssd(accion, _
                                            tipo, _
                                            cod_con, _
                                            sufijo, _
                                            codigo_da, _
                                            region, _
                                            numero_proceso, _
                                            descripcion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function GetBuscaProceso_ssd(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim tipo As String = ""
        Dim cod_con As String = ""
        Dim sufijo As String = ""
        Dim codigo_da As String = ""
        Dim region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaProceso_ssd(parametro, _
                                                                    tipo, _
                                                                    cod_con, _
                                                                    sufijo, _
                                                                    codigo_da, _
                                                                    region) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaProceso_ssd(tipo, _
                                            cod_con, _
                                            sufijo, _
                                            codigo_da, _
                                            region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function SetGrabaConvenio(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As Long = 0
        Dim etapa As String = ""
        Dim num_decreto As Long = 0
        Dim fecha_decreto As String = ""
        Dim tipo_convenio As String = ""
        Dim fecha_convenio As String = ""
        Dim monto_neto As Double = 0
        Dim gastos_administrativos As Double = 0
        Dim consul As Double = 0
        Dim descripcion As String = ""
        Dim fecha_ingreso As String = ""
        Dim estado_convenio As String = ""
        Dim observacion As String = ""
        Dim fecha_liquidacion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaConvenio(parametro, _
                                                                 region, _
                                                                 codigo_da, _
                                                                 mandante, _
                                                                 correlativo, _
                                                                 etapa, _
                                                                 num_decreto, _
                                                                 fecha_decreto, _
                                                                 tipo_convenio, _
                                                                 fecha_convenio, _
                                                                 monto_neto, _
                                                                 gastos_administrativos, _
                                                                 consul, _
                                                                 descripcion, _
                                                                 fecha_ingreso, _
                                                                 estado_convenio, _
                                                                 observacion, _
                                                                 fecha_liquidacion) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaConvenio(region, _
                                         codigo_da, _
                                         mandante, _
                                         correlativo, _
                                         etapa, _
                                         num_decreto, _
                                         fecha_decreto, _
                                         tipo_convenio, _
                                         fecha_convenio, _
                                         monto_neto, _
                                         gastos_administrativos, _
                                         consul, _
                                         descripcion, _
                                         fecha_ingreso, _
                                         estado_convenio, _
                                         observacion, _
                                         fecha_liquidacion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function GetBuscaDetalleProyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBuscaDetalleProyecto(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBuscaDetalleProyecto(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    ''JGM20121129
    <WebMethod()> _
    Public Function SetGrabaDetalleProyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim plan As Long = 0
        Dim proceso As String = ""
        Dim objeto As String = ""
        Dim codigo_bip As String = ""
        Dim monto_estimado_idea As Double = 0
        Dim responsable_idea As String = ""
        Dim responsable_convenio As String = ""
        Dim parte_bip As String = ""
        Dim provincia As String = ""
        Dim comuna As String = ""
        Dim ubicacion As String = ""
        Dim terreno_numero_certif As Long = 0
        Dim terreno_fecha_certificado As String = ""
        Dim descripcion_proyecto As String = ""
        Dim factibilidad_electrica As Integer = 0
        Dim factibilidad_agua As Integer = 0
        Dim factibilidad_alcantarillado As Integer = 0
        Dim condiciones_tecnicas As String = ""
        Dim terreno_observaciones As String = ""
        Dim sector_destino As String = ""
        Dim sub_sector As String = ""
        Dim tipologia As String = ""
        Dim fecha_estado As String = ""
        Dim estado As String = ""
        Dim tipo_proy As String = ""
        Dim fecha_evaluacion As String = ""
        Dim monto_estimado As Double = 0
        Dim beneficio As String = ""
        Dim propiedad As String = ""
        Dim superficie As Double = 0
        Dim programa_inicial As Double = 0
        Dim programa_final As Double = 0
        Dim m2_arquitectura As Double = 0
        Dim profesional_arquitectura As String = ""
        Dim m2_ingenieria As Double = 0
        Dim profesional_ingenieria As String = ""
        Dim obras_complementarias As Integer = 0
        Dim fecha_ingreso As String = ""
        Dim fecha_termino_proyecto As String = ""
        Dim fecha_liquidacion_proyecto As String = ""
        Dim coordenadas As String = ""
        Dim usuarios As Long = 0
        Dim beneficiarios As Long = 0
        Dim patrimonial As String = ""
        Dim oficio_apoyo As String = ""
        Dim fecha_oficio_apoyo As String = ""
        Dim f_i_a_t As String = ""
        Dim f_t_a_t_estimada As String = ""
        Dim f_t_a_t As String = ""
        Dim resp_at As String = ""
        Dim producto As String = ""
        Dim fondo As String = ""
        Dim f_hito As String = ""
        Dim seguimiento_p As String = ""
        Dim tipo_apoyo_tecnico As String = ""
        Dim tipo_ase As Long = 0
        Dim proteccion_patrimonial As String = ""
        Dim material As Long = 0
        Dim rate As String = ""
        Dim etapa_idea As Long = 0
        Dim codigo_proyecto_exp As String = ""
        Dim fecha_est_firma_convenio As String = ""
        Dim fecha_est_publicacion As String = ""
        Dim fecha_est_inicio As String = ""
        Dim fecha_est_termino As String = ""
        Dim codigo_prigrh As String = ""
        Dim modalidad As String = ""
        Dim reajuste As String = ""
        Dim ces As String = ""
        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaDetalleProyecto(parametro, _
                                                                        region, _
                                                                        codigo_da, _
                                                                        plan, _
                                                                        proceso, _
                                                                        objeto, _
                                                                        codigo_bip, _
                                                                        monto_estimado_idea, _
                                                                        responsable_idea, _
                                                                        responsable_convenio, _
                                                                        parte_bip, _
                                                                        provincia, _
                                                                        comuna, _
                                                                        ubicacion, _
                                                                        terreno_numero_certif, _
                                                                        terreno_fecha_certificado, _
                                                                        descripcion_proyecto, _
                                                                        factibilidad_electrica, _
                                                                        factibilidad_agua, _
                                                                        factibilidad_alcantarillado, _
                                                                        condiciones_tecnicas, _
                                                                        terreno_observaciones, _
                                                                        sector_destino, _
                                                                        sub_sector, _
                                                                        tipologia, _
                                                                        fecha_estado, _
                                                                        estado, _
                                                                        tipo_proy, _
                                                                        fecha_evaluacion, _
                                                                        monto_estimado, _
                                                                        beneficio, _
                                                                        propiedad, _
                                                                        superficie, _
                                                                        programa_inicial, _
                                                                        programa_final, _
                                                                        m2_arquitectura, _
                                                                        profesional_arquitectura, _
                                                                        m2_ingenieria, _
                                                                        profesional_ingenieria, _
                                                                        obras_complementarias, _
                                                                        fecha_ingreso, _
                                                                        fecha_termino_proyecto, _
                                                                        fecha_liquidacion_proyecto, _
                                                                        coordenadas, _
                                                                        usuarios, _
                                                                        beneficiarios, _
                                                                        patrimonial, _
                                                                        oficio_apoyo, _
                                                                        fecha_oficio_apoyo, _
                                                                        f_i_a_t, _
                                                                        f_t_a_t_estimada, _
                                                                        f_t_a_t, _
                                                                        resp_at, _
                                                                        producto, _
                                                                        fondo, _
                                                                        f_hito, _
                                                                        seguimiento_p, _
                                                                        tipo_apoyo_tecnico, _
                                                                        tipo_ase, _
                                                                        proteccion_patrimonial, _
                                                                        material, _
                                                                        rate, _
                                                                        etapa_idea, _
                                                                        codigo_proyecto_exp, _
                                                                        fecha_est_firma_convenio, _
                                                                        fecha_est_publicacion, _
                                                                        fecha_est_inicio, _
                                                                        fecha_est_termino, _
                                                                        codigo_prigrh, _
                                                                        modalidad, _
                                                                       reajuste, _
                                                                       ces _
                                                                       ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaDetalleProyecto(region, _
                                                codigo_da, _
                                                plan, _
                                                proceso, _
                                                objeto, _
                                                codigo_bip, _
                                                monto_estimado_idea, _
                                                responsable_idea, _
                                                responsable_convenio, _
                                                parte_bip, _
                                                provincia, _
                                                comuna, _
                                                ubicacion, _
                                                terreno_numero_certif, _
                                                terreno_fecha_certificado, _
                                                descripcion_proyecto, _
                                                factibilidad_electrica, _
                                                factibilidad_agua, _
                                                factibilidad_alcantarillado, _
                                                condiciones_tecnicas, _
                                                terreno_observaciones, _
                                                sector_destino, _
                                                sub_sector, _
                                                tipologia, _
                                                fecha_estado, _
                                                estado, _
                                                tipo_proy, _
                                                fecha_evaluacion, _
                                                monto_estimado, _
                                                beneficio, _
                                                propiedad, _
                                                superficie, _
                                                programa_inicial, _
                                                programa_final, _
                                                m2_arquitectura, _
                                                profesional_arquitectura, _
                                                m2_ingenieria, _
                                                profesional_ingenieria, _
                                                obras_complementarias, _
                                                fecha_ingreso, _
                                                fecha_termino_proyecto, _
                                                fecha_liquidacion_proyecto, _
                                                coordenadas, _
                                                usuarios, _
                                                beneficiarios, _
                                                patrimonial, _
                                                oficio_apoyo, _
                                                fecha_oficio_apoyo, _
                                                f_i_a_t, _
                                                f_t_a_t_estimada, _
                                                f_t_a_t, _
                                                resp_at, _
                                                producto, _
                                                fondo, _
                                                f_hito, _
                                                seguimiento_p, _
                                                tipo_apoyo_tecnico, _
                                                tipo_ase, _
                                                proteccion_patrimonial, _
                                                material, _
                                                rate, _
                                                etapa_idea, _
                                                codigo_proyecto_exp, _
                                                fecha_est_firma_convenio, _
                                                fecha_est_publicacion, _
                                                fecha_est_inicio, _
                                                fecha_est_termino, _
                                                codigo_prigrh, _
                                                modalidad, _
                                                reajuste, _
                                                ces _
                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

#Region "Metodos Generales"
    ''JGM 20121125
    Private Function GetStoredProcedure(ByVal Tipo As String) As String

        Dim Salida As String = ""

        Select Case LCase(Tipo)
            Case "alertas"
                Salida = "sp_busca_alertas"

            Case "comunas"
                Salida = "sp_busca_comunas"

            Case "contratistas"
                Salida = "sp_busca_contratistas"

            Case "correlativo_fondo_relacionados_edita"
                Salida = "sp_busca_correlativo_fondo_relacionados_edita"

            Case "datos_proceso"
                Salida = "sp_busca_datos_proceso"

            Case "localidades"
                Salida = "sp_busca_localidades"

            Case "regiones"
                Salida = "sp_busca_regiones"

            Case "registros_conttas"
                Salida = "sp_busca_registros_conttas"

            Case "registros_conttas2"
                Salida = "sp_busca_registros_conttas2"

            Case "tipo_licitacion"
                Salida = "sp_busca_tipo_licitacion"

            Case "llena_comunas"
                Salida = "sp_llena_comunas"

            Case "llena_planes"
                Salida = "sp_llena_planes"

            Case "llena_prod_estrategico"
                Salida = "sp_llena_prod_estrategico"

            Case "llena_sector_destino"
                Salida = "sp_llena_sector_destino"

            Case "llena_tipo_fondos"
                Salida = "sp_llena_tipo_fondos"

            Case "llena_tipologias"
                Salida = "sp_llena_tipologias"

            Case "pry_estadoproys_list"
                Salida = "sp_pry_estadoproys_list"

            Case "busca_dom_insp_fis"
                Salida = "sp_busca_dom_insp_fis"

            Case "busca_dom_mandante"
                Salida = "sp_busca_dom_mandante"

            Case "llena_consultas"
                Salida = "SP_LLENA_COMUNAS"

            Case "busca_dom_ti_con"
                Salida = "sp_busca_dom_ti_con"

            Case "origenes_resolucion"
                Salida = "sp_busca_origenes_resolucion"

            Case "get_flujo_financiero"
                Salida = "SP_BUSCA_FLUJO_FINANCIERO"

            Case Else
                Salida = Tipo.Trim()

        End Select

        Return Salida

    End Function

    Private Function CreateXMLDocument(ByVal result As String) As XmlDocument

        Dim xDoc As New XmlDocument()
        xDoc.LoadXml(result.ToString())

        Return xDoc

    End Function

    Private Function GenerateResultXML(ByVal dt As DataTable, ByVal WsParam As Integer, Optional ByVal Estado As Boolean = True) As String

        Dim result As New StringBuilder()

        If WsParam = 1 Then
            If dt.Rows.Count > 0 Then
                result.Append(ConvertTableToXML(dt))
                result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Success))
            Else
                result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.NoResult))
            End If
        Else
            If Estado Then
                result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Success))
            Else
                result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.NoResult))
            End If
        End If

        Return result.ToString()
    End Function

    Private Function ConvertTableToXML(ByVal dt As DataTable) As String

        Dim result As New StringBuilder()

        Using sw As New StringWriter()
            dt.TableName = "Dato"
            dt.WriteXml(sw)
            result.Append(sw.ToString())
        End Using

        'Reemplazo el nodo padre generado por el XML
        result = New StringBuilder(result.ToString().Replace("NewDataSet", "Datos"))

        Return result.ToString()
    End Function

#End Region

#Region "Metodos Nuevos JQ"

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_avance_fisico(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_avance_fisico(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_avance_fisico(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_avance_fisico_suma(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_avance_fisico_suma(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_avance_fisico_suma(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_edita_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_edita_contrato(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_edita_contrato(codigo_pia, codigo_region, sufijo)


                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_estado_pago(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_estado_pago(parametro, _
                                                                                            cod_con, _
                                                                                            num_epago _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_estado_pago(cod_con, num_epago)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_garantias(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_garantias(parametro, _
                                                                                            cod_con, _
                                                                                            llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_garantias(cod_con, llave)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_imputacion_presup(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_imputacion_presup(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_imputacion_presup(codigo_pia, _
                                                                    codigo_region, _
                                                                    sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_inspector_fiscal(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim rut As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_inspector_fiscal(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_inspector_fiscal(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_modificacion_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_modificacion_contrato(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_modificacion_contrato(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_programacion_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_programacion_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_programacion_financ(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_programacion_financ_suma(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_programacion_financ_suma(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_programacion_financ_sum(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Agregada por Alexi Rodriguez B., creado el 08-04-2015 para funcionalidad de Programación tentativa propuesta
    <WebMethod()> _
    Public Function GetBusca_programacion_tentativa_propuesta_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_programacion_tentativa_propuesta_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_programacion_tentativa_propuesta_financ(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Agregada por Alexi Rodriguez B., creado el 08-04-2015 para funcionalidad de Programación tentativa propuesta
    <WebMethod()> _
    Public Function GetBusca_programacion_tentativa_propuesta_financ_suma(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_programacion_tentativa_propuesta_financ_suma(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_programacion_tentativa_propuesta_financ_sum(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_detalle_termino(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_detalle_termino(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_contratos_resumen_edita_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_contratos_resumen_edita_contrato(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_contratos_resumen_edita_contrato(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_dom_insp_fis(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim rut As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_dom_insp_fis(parametro, _
                                                                        rut _
                                                                        ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_dom_insp_fis(rut)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetCancela_contratos_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetCancela_contratos_detalle_termino(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetCancela_contratos_detalle_termino(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetElimina_contratos_detalle_avance_fisico(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_contratos_detalle_avance_fisico(parametro, _
                                                                                            cod_con, _
                                                                                            llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_contratos_detalle_avance_fisico(cod_con, llave)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetElimina_contratos_detalle_estado_pago(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_contratos_detalle_estado_pago(parametro, _
                                                                                            cod_con, _
                                                                                            num_epago _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_contratos_detalle_estado_pago(cod_con, num_epago)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetElimina_contratos_detalle_imputacion_presup(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_contratos_detalle_imputacion_presup(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_contratos_detalle_imputacion_presup(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo, _
                                                                        llave)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetElimina_contratos_detalle_inspector_fiscal(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim rut As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_contratos_detalle_inspector_fiscal(parametro, _
                                                                                            cod_con, _
                                                                                            rut _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_contratos_detalle_inspector_fiscal(cod_con, rut)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetEliminar_contratos_detalle_programacion_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim agno As String = ""
        Dim mes As String = ""
        Dim monto_vig As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetEliminar_contratos_detalle_programacion_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            agno, _
                                                                                            mes, _
                                                                                            monto_vig _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetEliminar_contratos_detalle_programacion_financ(codigo_pia, _
                                                                            codigo_region, _
                                                                            sufijo, _
                                                                            agno, _
                                                                            mes, _
                                                                            monto_vig)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_avance_fisico(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim agno As String = ""
        Dim mes As String = ""
        Dim av_fis_pr As String = ""
        Dim av_fis_acum As String = ""
        Dim fecha_medicion As String = ""
        Dim av_fis_re As String = ""
        Dim mano_de_obra_calificada As String = ""
        Dim mano_de_obra_semi_calificada As String = ""
        Dim mano_de_obra_no_calificada As String = ""
        Dim observ As String = ""
        Dim llave As String = ""
        Dim av_fis_act As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_avance_fisico(parametro, _
                                                                                            cod_con, _
                                                                                            agno, _
                                                                                            mes, _
                                                                                            av_fis_pr, _
                                                                                            av_fis_acum, _
                                                                                            fecha_medicion, _
                                                                                            av_fis_re, _
                                                                                            mano_de_obra_calificada, _
                                                                                            mano_de_obra_semi_calificada, _
                                                                                            mano_de_obra_no_calificada, _
                                                                                            observ, _
                                                                                            llave, _
                                                                                            av_fis_act _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_avance_fisico(cod_con, _
                                                                    agno, _
                                                                    mes, _
                                                                    av_fis_pr, _
                                                                    av_fis_acum, _
                                                                    fecha_medicion, _
                                                                    av_fis_re, _
                                                                    mano_de_obra_calificada, _
                                                                    mano_de_obra_semi_calificada, _
                                                                    mano_de_obra_no_calificada, _
                                                                    observ, _
                                                                    llave, _
                                                                    av_fis_act)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_contratos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim m2 As Double = 0
        Dim desc_contrato As String = ""
        Dim FechaInicioLegal As String = ""
        Dim FechaEntregaTerreno As String = ""
        Dim PlazoNoComputable As String = ""
        Dim ObsRelContrato As String = ""
        Dim usuario As String = ""
        Dim libro As String = ""
        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_contratos(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            m2, _
                                                                                            desc_contrato, _
                                                                                            FechaInicioLegal, _
                                                                                            FechaEntregaTerreno, _
                                                                                            PlazoNoComputable, _
                                                                                            ObsRelContrato, _
                                                                                            usuario, _
                                                                                            libro) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_contratos(codigo_pia, _
                                                            codigo_region, _
                                                            sufijo, _
                                                            m2, _
                                                            desc_contrato, _
                                                            FechaInicioLegal, _
                                                            FechaEntregaTerreno, _
                                                            PlazoNoComputable, _
                                                            ObsRelContrato, _
                                                            usuario, _
                                                            libro)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_garantias(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim cod_tipo As String = ""
        Dim entidad_financiera As String = ""
        Dim numero As String = ""
        Dim fecha As String = ""
        Dim fecha_vencimiento_inicial As String = ""
        Dim fecha_vencimiento As String = ""
        Dim monto As String = ""
        Dim tipo_moneda As String = ""
        Dim num_oficio_destino_documento As String = ""
        Dim fecha_oficio_destino_documento As String = ""
        Dim entidad_que_custodia As String = ""
        Dim num_oficio_solicitud_garantia As String = ""
        Dim fecha_oficio_solicitud_garantia As String = ""
        Dim fecha_devolucion_garantia As String = ""
        Dim tipo_de_documento As String = ""
        Dim devuelta As String = ""
        Dim fecha_prorroga As String = ""
        Dim fecha_nuevo_vencimiento As String = ""
        Dim dias As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_garantias(parametro, _
                                                                                            cod_con, _
                                                                                            cod_tipo, _
                                                                                            entidad_financiera, _
                                                                                            numero, _
                                                                                            fecha, _
                                                                                            fecha_vencimiento_inicial, _
                                                                                            fecha_vencimiento, _
                                                                                            monto, _
                                                                                            tipo_moneda, _
                                                                                            num_oficio_destino_documento, _
                                                                                            fecha_oficio_destino_documento, _
                                                                                            entidad_que_custodia, _
                                                                                            num_oficio_solicitud_garantia, _
                                                                                            fecha_oficio_solicitud_garantia, _
                                                                                            fecha_devolucion_garantia, _
                                                                                            tipo_de_documento, _
                                                                                            devuelta, _
                                                                                            fecha_prorroga, _
                                                                                            fecha_nuevo_vencimiento, _
                                                                                            dias, _
                                                                                            llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_garantias(cod_con, _
                                                                cod_tipo, _
                                                                entidad_financiera, _
                                                                numero, _
                                                                fecha, _
                                                                fecha_vencimiento_inicial, _
                                                                fecha_vencimiento, _
                                                                monto, _
                                                                tipo_moneda, _
                                                                num_oficio_destino_documento, _
                                                                fecha_oficio_destino_documento, _
                                                                entidad_que_custodia, _
                                                                num_oficio_solicitud_garantia, _
                                                                fecha_oficio_solicitud_garantia, _
                                                                fecha_devolucion_garantia, _
                                                                tipo_de_documento, _
                                                                devuelta, _
                                                                fecha_prorroga, _
                                                                fecha_nuevo_vencimiento, _
                                                                dias, _
                                                                llave _
                                                                )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_imputacion_presup(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim ano As String = ""
        Dim mandante As String = ""
        Dim tipofondo As String = ""
        Dim resorig As String = ""
        Dim numerores As String = ""
        Dim fechares As String = ""
        Dim subt As String = ""
        Dim it As String = ""
        Dim asig As String = ""
        Dim montoimputado As String = ""
        Dim codigo_contrato As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_imputacion_presup(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            ano, _
                                                                                            mandante, _
                                                                                            tipofondo, _
                                                                                            resorig, _
                                                                                            numerores, _
                                                                                            fechares, _
                                                                                            subt, _
                                                                                            it, _
                                                                                            asig, _
                                                                                            montoimputado, _
                                                                                            codigo_contrato, _
                                                                                            llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_imputacion_presup(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo, _
                                                                        ano, _
                                                                        mandante, _
                                                                        tipofondo, _
                                                                        resorig, _
                                                                        numerores, _
                                                                        fechares, _
                                                                        subt, _
                                                                        it, _
                                                                        asig, _
                                                                        montoimputado, _
                                                                        codigo_contrato, _
                                                                        llave)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_inspector_fiscal(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim rut As String = ""
        Dim n_res As String = ""
        Dim f_resol As String = ""
        Dim titularsn As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_inspector_fiscal(parametro, _
                                                                                            cod_con, _
                                                                                            rut, _
                                                                                            n_res, _
                                                                                            f_resol, _
                                                                                            titularsn _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_inspector_fiscal(cod_con, _
                                                                    rut, _
                                                                    n_res, _
                                                                    f_resol, _
                                                                    titularsn)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_modificacion_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim tipo_modif_ctto As String = ""
        Dim n_docto_solicitud_mod As String = ""
        Dim f_solicitud_mod As String = ""
        Dim var_mto As String = ""
        Dim var_pzo As String = ""
        Dim var_tamagno As String = ""
        Dim n_docto_resp_solicitud_mod As String = ""
        Dim f_resp_solicitud_mod As String = ""
        Dim or_res As String = ""
        Dim n_res As String = ""
        Dim f_res As String = ""
        Dim f_tramite As String = ""
        Dim motivo As String = ""
        Dim r_nueva_boleta As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_modificacion_contrato(parametro, _
                                                                                                    cod_con, _
                                                                                                    tipo_modif_ctto, _
                                                                                                    n_docto_solicitud_mod, _
                                                                                                    f_solicitud_mod, _
                                                                                                    var_mto, _
                                                                                                    var_pzo, _
                                                                                                    var_tamagno, _
                                                                                                    n_docto_resp_solicitud_mod, _
                                                                                                    f_resp_solicitud_mod, _
                                                                                                    or_res, _
                                                                                                    n_res, _
                                                                                                    f_res, _
                                                                                                    f_tramite, _
                                                                                                    motivo, _
                                                                                                    r_nueva_boleta, _
                                                                                                    llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_modificacion_contrato(cod_con, _
                                                                            tipo_modif_ctto, _
                                                                            n_docto_solicitud_mod, _
                                                                            f_solicitud_mod, _
                                                                            var_mto, _
                                                                            var_pzo, _
                                                                            var_tamagno, _
                                                                            n_docto_resp_solicitud_mod, _
                                                                            f_resp_solicitud_mod, _
                                                                            or_res, _
                                                                            n_res, _
                                                                            f_res, _
                                                                            f_tramite, _
                                                                            motivo, _
                                                                            r_nueva_boleta, _
                                                                            llave _
                                                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetElimina_contratos_detalle_modificacion_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim tipo_modif_ctto As String = ""
        Dim n_docto_solicitud_mod As String = ""
        Dim f_solicitud_mod As String = ""
        Dim var_mto As String = ""
        Dim var_pzo As String = ""
        Dim var_tamagno As String = ""
        Dim n_docto_resp_solicitud_mod As String = ""
        Dim f_resp_solicitud_mod As String = ""
        Dim or_res As String = ""
        Dim n_res As String = ""
        Dim f_res As String = ""
        Dim f_tramite As String = ""
        Dim motivo As String = ""
        Dim r_nueva_boleta As String = ""
        Dim llave As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_contratos_detalle_modificacion_contrato(parametro, _
                                                                                                    cod_con, _
                                                                                                    llave _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_contratos_detalle_modificacion_contrato(cod_con, _
                                                                            llave _
                                                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_nuevo(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim numcorrelativo_convenio As String = ""
        Dim strmandante_convenio As String = ""
        Dim stretapa As String = ""
        Dim strtipo_proceso As String = ""
        Dim strfinanciamiento As String = ""
        Dim strobjeto As String = ""
        Dim cod_con As String = ""
        Dim estatus As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_nuevo(parametro, _
                                                                                    codigo_pia, _
                                                                                    codigo_region, _
                                                                                    numcorrelativo_convenio, _
                                                                                    strmandante_convenio, _
                                                                                    stretapa, _
                                                                                    strtipo_proceso, _
                                                                                    strfinanciamiento, _
                                                                                    strobjeto, _
                                                                                    cod_con, _
                                                                                    estatus _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_nuevo(codigo_pia, _
                                                            codigo_region, _
                                                            numcorrelativo_convenio, _
                                                            strmandante_convenio, _
                                                            stretapa, _
                                                            strtipo_proceso, _
                                                            strfinanciamiento, _
                                                            strobjeto, _
                                                            cod_con, _
                                                            estatus _
                                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_programacion_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim agno As String = ""
        Dim mes As String = ""
        Dim monto_prog As String = ""
        Dim monto_vig As String = ""
        Dim fondo As String = ""


        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_programacion_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            agno, _
                                                                                            mes, _
                                                                                            monto_prog, _
                                                                                            monto_vig, _
                                                                                            fondo _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_programacion_financ(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo, _
                                                                        agno, _
                                                                        mes, _
                                                                        monto_prog, _
                                                                        monto_vig, _
                                                                        fondo _
                                                                       )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Agregada por Alexi Rodriguez B., creado el 08-04-2015 para funcionalidad de Programación tentativa propuesta
    <WebMethod()> _
    Public Function SetGraba_programacion_tentativa_propuesta_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim agno As String = ""
        Dim mes As String = ""
        Dim monto_prop As String = ""
        Dim monto_vig As String = ""
        Dim MO_CALIFICADA As String = ""
        Dim MO_SEMI_CALIFICADA As String = ""
        Dim MO_NO_CALIFICADA As String = ""
        Dim FONDO As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_programacion_tentativa_propuesta_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            agno, _
                                                                                            mes, _
                                                                                            monto_prop, _
                                                                                            monto_vig, _
                                                                                            MO_CALIFICADA, _
                                                                                            MO_SEMI_CALIFICADA, _
                                                                                            MO_NO_CALIFICADA, _
                                                                                            FONDO _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_programacion_tentativa_propuesta_financ(codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo, _
                                                                        agno, _
                                                                        mes, _
                                                                        monto_prop, _
                                                                        monto_vig, _
                                                                        MO_CALIFICADA, _
                                                                        MO_SEMI_CALIFICADA, _
                                                                        MO_NO_CALIFICADA, _
                                                                        FONDO)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Agregada por Alexi Rodriguez B., creado el 08-04-2015 para funcionalidad de Programación tentativa propuesta
    <WebMethod()> _
    Public Function SetEliminar_programacion_tentativa_propuesta_financ(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim agno As String = ""
        Dim mes As String = ""
        Dim monto_vig As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetEliminar_programacion_tentativa_propuesta_financ(parametro, _
                                                                                            codigo_pia, _
                                                                                            codigo_region, _
                                                                                            sufijo, _
                                                                                            agno, _
                                                                                            mes, _
                                                                                            monto_vig _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetEliminar_programacion_tentativa_propuesta_financ(codigo_pia, _
                                                                            codigo_region, _
                                                                            sufijo, _
                                                                            agno, _
                                                                            mes, _
                                                                            monto_vig)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_contratos_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim fecha_solic_recep_ctta As String = ""
        Dim fecha_termino_fisico_ito As String = ""
        Dim resp_termino As String = ""
        Dim n_res_liq_anticipada As String = ""
        Dim f_acta_recepcion_unica_liq As String = ""
        Dim f_res_liq_anticipada As String = ""
        Dim anticipada As String = ""
        Dim integrantes_com_ru As String = ""
        Dim integrantes_com_ru2 As String = ""
        Dim integrantes_com_ru3 As String = ""
        Dim n_docto_aprueba_liquidacion_anticipada_obra As String = ""
        Dim f_docto_aprueba_liquidacion_anticipada_obra As String = ""
        Dim n_res_com_rp As String = ""
        Dim f_res_com_rp As String = ""
        Dim f_inf_obs_rp As String = ""
        Dim f_r_p As String = ""
        Dim plz_obs_rp As String = ""
        Dim f_ter_real_rp As String = ""
        Dim integrantes_com_rp As String = ""
        Dim integrantes_com_rp2 As String = ""
        Dim integrantes_com_rp3 As String = ""
        Dim n_cerificado_recep_municipal As String = ""
        Dim f_cerificado_recep_municipal As String = ""
        Dim calific As String = ""
        Dim fecha_acta_entrega_explot As String = ""
        Dim mandatario_que_entrega As String = ""
        Dim mandante_que_recibe As String = ""
        Dim reservas As String = ""
        Dim plz_reservsas As String = ""
        Dim monto_reservas As String = ""
        Dim n_res_com_rd As String = ""
        Dim f_inf_obs_rd As String = ""
        Dim f_r_def As String = ""
        Dim f_res_com_rd As String = ""
        Dim plz_obs_rd As String = ""
        Dim integrantes_com_rd As String = ""
        Dim integrantes_com_rd2 As String = ""
        Dim integrantes_com_rd3 As String = ""
        Dim n_res_liquida As String = ""
        Dim f_res_liquida As String = ""
        Dim autoridad_liquida As String = ""
        Dim observacion_termino_contrato As String = ""
        Dim sufijo As String = ""
        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_contratos_detalle_termino(parametro, _
                                                                                        cod_con, _
                                                                                        fecha_solic_recep_ctta, _
                                                                                        fecha_termino_fisico_ito, _
                                                                                        resp_termino, _
                                                                                        n_res_liq_anticipada, _
                                                                                        f_acta_recepcion_unica_liq, _
                                                                                        f_res_liq_anticipada, _
                                                                                        anticipada, _
                                                                                        integrantes_com_ru, _
                                                                                        integrantes_com_ru2, _
                                                                                        integrantes_com_ru3, _
                                                                                        n_docto_aprueba_liquidacion_anticipada_obra, _
                                                                                        f_docto_aprueba_liquidacion_anticipada_obra, _
                                                                                        n_res_com_rp, _
                                                                                        f_res_com_rp, _
                                                                                        f_inf_obs_rp, _
                                                                                        f_r_p, _
                                                                                        plz_obs_rp, _
                                                                                        f_ter_real_rp, _
                                                                                        integrantes_com_rp, _
                                                                                        integrantes_com_rp2, _
                                                                                        integrantes_com_rp3, _
                                                                                        n_cerificado_recep_municipal, _
                                                                                        f_cerificado_recep_municipal, _
                                                                                        calific, _
                                                                                        fecha_acta_entrega_explot, _
                                                                                        mandatario_que_entrega, _
                                                                                        mandante_que_recibe, _
                                                                                        reservas, _
                                                                                        plz_reservsas, _
                                                                                        monto_reservas, _
                                                                                        n_res_com_rd, _
                                                                                        f_inf_obs_rd, _
                                                                                        f_r_def, _
                                                                                        f_res_com_rd, _
                                                                                        plz_obs_rd, _
                                                                                        integrantes_com_rd, _
                                                                                        integrantes_com_rd2, _
                                                                                        integrantes_com_rd3, _
                                                                                        n_res_liquida, _
                                                                                        f_res_liquida, _
                                                                                        autoridad_liquida, _
                                                                                        observacion_termino_contrato, _
                                                                                        sufijo, _
                                                                                        region, _
                                                                                        codigo_da _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_contratos_detalle_termino(cod_con, _
                                                            fecha_solic_recep_ctta, _
                                                            fecha_termino_fisico_ito, _
                                                            resp_termino, _
                                                            n_res_liq_anticipada, _
                                                            f_acta_recepcion_unica_liq, _
                                                            f_res_liq_anticipada, _
                                                            anticipada, _
                                                            integrantes_com_ru, _
                                                            integrantes_com_ru2, _
                                                            integrantes_com_ru3, _
                                                            n_docto_aprueba_liquidacion_anticipada_obra, _
                                                            f_docto_aprueba_liquidacion_anticipada_obra, _
                                                            n_res_com_rp, _
                                                            f_res_com_rp, _
                                                            f_inf_obs_rp, _
                                                            f_r_p, _
                                                            plz_obs_rp, _
                                                            f_ter_real_rp, _
                                                            integrantes_com_rp, _
                                                            integrantes_com_rp2, _
                                                            integrantes_com_rp3, _
                                                            n_cerificado_recep_municipal, _
                                                            f_cerificado_recep_municipal, _
                                                            calific, _
                                                            fecha_acta_entrega_explot, _
                                                            mandatario_que_entrega, _
                                                            mandante_que_recibe, _
                                                            reservas, _
                                                            plz_reservsas, _
                                                            monto_reservas, _
                                                            n_res_com_rd, _
                                                            f_inf_obs_rd, _
                                                            f_r_def, _
                                                            f_res_com_rd, _
                                                            plz_obs_rd, _
                                                            integrantes_com_rd, _
                                                            integrantes_com_rd2, _
                                                            integrantes_com_rd3, _
                                                            n_res_liquida, _
                                                            f_res_liquida, _
                                                            autoridad_liquida, _
                                                            observacion_termino_contrato, _
                                                            sufijo, _
                                                            region, _
                                                            codigo_da _
                                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGrabar_contratos_detalle_estado_pago(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""
        Dim fecha_epago As String = ""
        Dim pag_ctto_matriz As String = ""
        Dim pag_mod_ctto As String = ""
        Dim pag_reaj As String = ""
        Dim pag_anticipo As String = ""
        Dim pag_canje_ret As String = ""
        Dim pag_devol_ret As String = ""
        Dim devol_anticipo As String = ""
        Dim reaj_devol_antic As String = ""
        Dim retenciones As String = ""
        Dim multas As String = ""
        Dim impuesto As String = ""

        Dim liquido_a_pagar As String = ""
        Dim valor_e_pago As String = ""
        Dim cargo_a_pres As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabar_contratos_detalle_estado_pago(parametro, _
                                                                                            cod_con, _
                                                                                            num_epago, _
                                                                                            fecha_epago, _
                                                                                            pag_ctto_matriz, _
                                                                                            pag_mod_ctto, _
                                                                                            pag_reaj, _
                                                                                            pag_anticipo, _
                                                                                            pag_canje_ret, _
                                                                                            pag_devol_ret, _
                                                                                            devol_anticipo, _
                                                                                            reaj_devol_antic, _
                                                                                            retenciones, _
                                                                                            multas, _
                                                                                            impuesto, _
                                                                                            liquido_a_pagar, _
                                                                                            valor_e_pago, _
                                                                                            cargo_a_pres _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabar_contratos_detalle_estado_pago(cod_con, _
                                                                num_epago, _
                                                                fecha_epago, _
                                                                pag_ctto_matriz, _
                                                                pag_mod_ctto, _
                                                                pag_reaj, _
                                                                pag_anticipo, _
                                                                pag_canje_ret, _
                                                                pag_devol_ret, _
                                                                devol_anticipo, _
                                                                reaj_devol_antic, _
                                                                retenciones, _
                                                                multas, _
                                                                impuesto, _
                                                                liquido_a_pagar, _
                                                                valor_e_pago, _
                                                                cargo_a_pres _
                                                            )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetPryProcesosList(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim tipologia As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetPryProcesosList(parametro, _
                                                                    tipologia _
                                                                    ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetPryProcesosList(tipologia)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetPry_procesos_list(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim tipologia As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetPry_procesos_list(parametro, _
                                                                        tipologia _
                                                                        ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetPry_procesos_list(tipologia)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetSetup_grilla(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim tipo_grilla As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetSetup_grilla(parametro, _
                                                                tipo_grilla _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetSetup_grilla(tipo_grilla)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Dom_Mandante(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim sigla As String = ""
        Dim descripcion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Dom_Mandante(parametro, _
                                                                accion, _
                                                                sigla, _
                                                                descripcion _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Dom_Mandante(accion, _
                                            sigla, _
                                            descripcion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_Comunas_Sector(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim provincia As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Comunas_Sector(parametro, _
                                                                region, _
                                                                provincia _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Comunas_Sector(region, provincia)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_SubSector_Sector(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim sector_destino As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_SubSector_Sector(parametro, _
                                                                sector_destino _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_SubSector_Sector(sector_destino)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_Tipologias_Sector(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim sector_destino As String = ""
        Dim sub_sector As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_Tipologias_Sector(parametro, _
                                                                sector_destino, _
                                                                sub_sector _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_Tipologias_Sector(sector_destino, sub_sector)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGrabaMandantesProyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaMandantesProyecto(parametro, _
                                                                region, _
                                                                codigo_da, _
                                                                mandante _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaMandantesProyecto(region, _
                                            codigo_da, _
                                            mandante)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetEliminaMandantesProyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetEliminaMandantesProyecto(parametro, _
                                                                region, _
                                                                codigo_da, _
                                                                mandante _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetEliminaMandantesProyecto(region, _
                                            codigo_da, _
                                            mandante)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_llena_codigo_contratos_cartola_contratos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_region_inicio As String = ""
        Dim str_region_fin As String = ""
        Dim str_fecha_inicio As String = ""
        Dim str_fecha_fin As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_llena_codigo_contratos_cartola_contratos(parametro, str_region_inicio, str_region_fin, str_fecha_inicio, str_fecha_fin) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_llena_codigo_contratos_cartola_contratos(str_region_inicio, str_region_fin, str_fecha_inicio, str_fecha_fin)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_llena_codigo_contratos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_region_inicio As String = ""
        Dim str_region_fin As String = ""
        Dim str_fecha_inicio As String = ""
        Dim str_fecha_fin As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_llena_codigo_contratos(parametro, str_region_inicio, str_region_fin, str_fecha_inicio, str_fecha_fin) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_llena_codigo_contratos(str_region_inicio, str_region_fin, str_fecha_inicio, str_fecha_fin)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_grabar_convenios_modif_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim fecha_decreto As String = ""
        Dim correlativo As String = ""
        Dim num_decreto As String = ""
        Dim fecha_convenio As String = ""
        Dim fecha_ingreso As String = ""
        Dim monto_neto_mod As String = ""
        Dim gasto_adm_mod As String = ""
        Dim consul_mod As String = ""
        Dim otros_gastos_mod As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_grabar_convenios_modif_proyecto(parametro, codigo_da, region, mandante, fecha_decreto, correlativo, num_decreto, fecha_convenio, fecha_ingreso, monto_neto_mod, gasto_adm_mod, consul_mod, otros_gastos_mod) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_grabar_convenios_modif_proyecto(region, codigo_da, mandante, fecha_decreto, correlativo, num_decreto, fecha_convenio, fecha_ingreso, monto_neto_mod, gasto_adm_mod, consul_mod, otros_gastos_mod)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_eliminar_convenios_modif_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As String = ""
        Dim fecha_decreto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_eliminar_convenios_modif_proyecto(parametro, codigo_da, region, mandante, correlativo, fecha_decreto) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_eliminar_convenios_modif_proyecto(region, codigo_da, mandante, correlativo, fecha_decreto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_convenios_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_convenios_proyecto(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_convenios_proyecto(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_mandantes_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_mandantes_proyecto(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_mandantes_proyecto(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function


    <WebMethod()> _
    Public Function Set_grabar_convenios_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As String = ""

        Dim etapa As String = ""
        Dim num_decreto As String = ""
        Dim fecha_decreto As String = ""
        Dim tipo_convenio As String = ""
        Dim fecha_convenio As String = ""
        Dim monto_neto As String = ""
        Dim gastos_administrativos As String = ""
        Dim consul As String = ""
        Dim otros_gastos As String = ""
        Dim descripcion As String = ""
        Dim fecha_ingreso As String = ""
        Dim estado_convenio As String = ""
        Dim observacion As String = ""
        Dim fecha_liquidacion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_grabar_convenios_proyecto(parametro _
                                                                                , region _
                                                                                , codigo_da _
                                                                                , mandante _
                                                                                , correlativo _
                                                                                , etapa _
                                                                                , num_decreto _
                                                                                , fecha_decreto _
                                                                                , tipo_convenio _
                                                                                , fecha_convenio _
                                                                                , monto_neto _
                                                                                , gastos_administrativos _
                                                                                , consul _
                                                                                , otros_gastos _
                                                                                , descripcion _
                                                                                , fecha_ingreso _
                                                                                , estado_convenio _
                                                                                , observacion _
                                                                                , fecha_liquidacion) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_grabar_convenios_proyecto(region _
                                                    , codigo_da _
                                                    , mandante _
                                                    , correlativo _
                                                    , etapa _
                                                    , num_decreto _
                                                    , fecha_decreto _
                                                    , tipo_convenio _
                                                    , fecha_convenio _
                                                    , monto_neto _
                                                    , gastos_administrativos _
                                                    , consul _
                                                    , otros_gastos _
                                                    , descripcion _
                                                    , fecha_ingreso _
                                                    , estado_convenio _
                                                    , observacion _
                                                    , fecha_liquidacion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function


    <WebMethod()> _
    Public Function Set_eliminar_convenios_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_eliminar_convenios_proyecto(parametro _
                                                                                , region _
                                                                                , codigo_da _
                                                                                , mandante _
                                                                                , correlativo _
                                                                                ) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_eliminar_convenios_proyecto(region _
                                                    , codigo_da _
                                                    , mandante _
                                                    , correlativo _
                                                    )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetEliminaEtapa(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim etapa As String = ""
        Dim codigo_bip As String = ""
        Dim parte As String = ""
        Dim monto_etapa As Double = 0
        Dim descripcion As String = ""
        Dim fecha_ingreso As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetEliminaEtapa(parametro, region, _
                                                                           codigo_da, _
                                                                           etapa _
                                                                           ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetEliminaEtapa(region, _
                                      codigo_da, _
                                      etapa _
                                        )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGrabaLog(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim nombre_usuario As String = ""
        Dim codigo_tipo_usuario As String = ""
        Dim url_opcion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaLog(parametro, nombre_usuario, _
                                                                           codigo_tipo_usuario, _
                                                                           url_opcion _
                                                                           ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaLog(nombre_usuario, _
                                       codigo_tipo_usuario, _
                                       url_opcion _
                                        )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_graba_ws_contratos_sectoriales(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim clave As String = ""
        Dim region_inicio As String = ""
        Dim region_fin As String = ""
        Dim codigosafi As String = ""
        Dim descripcionregion As String = ""
        Dim descripcioncomuna As String = ""
        Dim descripcionprovincia As String = ""
        Dim rutcontratista As String = ""
        Dim montocontrato As String = ""
        Dim montoinicial As String = ""
        Dim montovigente As String = ""
        Dim rutinspector As String = ""
        Dim estadocontrato As String = ""
        Dim tipogasto As String = ""
        Dim pptooficial As String = ""
        Dim aumentodisminucion As String = ""
        Dim fechatermino As String = ""
        Dim descripcion_tipo_registro As String = ""
        Dim descripcion_categoria As String = ""
        Dim codigo_bip As String = ""
        Dim proceso As String = ""
        Dim etapa As String = ""
        Dim calificacion As String = ""
        Dim f_recep_provisional As String = ""
        Dim f_recep_definitiva As String = ""
        Dim f_res_liq_contrato As String = ""
        Dim f_termino_ito As String = ""
        Dim ultimo As String = ""
        Dim objeto As String = ""
        Dim sector_destino As String = ""
        Dim sub_sec As String = ""
        Dim tipo_edificacion As String = ""
        Dim plazo_adjudicado As String = ""
        Dim inicio_legal As String = ""
        Dim f_res_adjudicacion As String = ""
        Dim plazo_vigente As String = ""
        Dim inversion_anno As String = ""
        Dim inversion_acumulada As String = ""
        Dim cantidad_obra As String = ""
        Dim observaciones_contrato As String = ""
        Dim av_fin As String = ""
        Dim av_fis_acum As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_graba_ws_contratos_sectoriales(parametro, _
                                                                accion, _
                                                                clave, _
                                                                region_inicio, _
                                                                region_fin, _
                                                                codigosafi, _
                                                                descripcionregion, _
                                                                descripcioncomuna, _
                                                                descripcionprovincia, _
                                                                rutcontratista, _
                                                                montocontrato, _
                                                                montoinicial, _
                                                                montovigente, _
                                                                rutinspector, _
                                                                estadocontrato, _
                                                                tipogasto, _
                                                                pptooficial, _
                                                                aumentodisminucion, _
                                                                fechatermino, _
                                                                descripcion_tipo_registro, _
                                                                descripcion_categoria, _
                                                                codigo_bip, _
                                                                proceso, _
                                                                etapa, _
                                                                calificacion, _
                                                                f_recep_provisional, _
                                                                f_recep_definitiva, _
                                                                f_res_liq_contrato, _
                                                                f_termino_ito, _
                                                                ultimo, _
                                                                objeto, _
                                                                sector_destino, _
                                                                sub_sec, _
                                                                tipo_edificacion, _
                                                                plazo_adjudicado, _
                                                                inicio_legal, _
                                                                f_res_adjudicacion, _
                                                                plazo_vigente, _
                                                                inversion_anno, _
                                                                inversion_acumulada, _
                                                                cantidad_obra, _
                                                                observaciones_contrato, _
                                                                av_fin, _
                                                                av_fis_acum _
                                                                    ) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_graba_ws_contratos_sectoriales(accion, _
                                    clave, _
                                    region_inicio, _
                                    region_fin, _
                                    codigosafi, _
                                    descripcionregion, _
                                    descripcioncomuna, _
                                    descripcionprovincia, _
                                    rutcontratista, _
                                    montocontrato, _
                                    montoinicial, _
                                    montovigente, _
                                    rutinspector, _
                                    estadocontrato, _
                                    tipogasto, _
                                    pptooficial, _
                                    aumentodisminucion, _
                                    fechatermino, _
                                    descripcion_tipo_registro, _
                                    descripcion_categoria, _
                                    codigo_bip, _
                                    proceso, _
                                    etapa, _
                                    calificacion, _
                                    f_recep_provisional, _
                                    f_recep_definitiva, _
                                    f_res_liq_contrato, _
                                    f_termino_ito, _
                                    ultimo, _
                                    objeto, _
                                    sector_destino, _
                                    sub_sec, _
                                    tipo_edificacion, _
                                    plazo_adjudicado, _
                                    inicio_legal, _
                                    f_res_adjudicacion, _
                                    plazo_vigente, _
                                    inversion_anno, _
                                    inversion_acumulada, _
                                    cantidad_obra, _
                                    observaciones_contrato, _
                                    av_fin, _
                                    av_fis_acum _
                                )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_mandante_convenios(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_mandante_convenios(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_mandante_convenios(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_buscar_mandantes_del_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_buscar_mandantes_del_contrato(parametro, region, codigo_da, sufijo) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_buscar_mandantes_del_contrato(region, codigo_da, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_eliminar_mandantes_del_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim REGION As String = ""
        Dim CODIGO_DA As String = ""
        Dim SUFIJO As String = ""
        Dim MANDANTE As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_eliminar_mandantes_del_contrato(parametro _
                                                                     , REGION _
                                                                     , CODIGO_DA _
                                                                     , SUFIJO _
                                                                     , MANDANTE _
                                                                     ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_eliminar_mandantes_del_contrato(REGION _
                                           , CODIGO_DA _
                                           , SUFIJO _
                                           , MANDANTE _
                                           )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetOfertasPropuestas_Elimina(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim REGION As String = ""
        Dim CODIGO_DA As String = ""
        Dim SUFIJO As String = ""
        Dim RUT_CTTA As String = ""
        Dim DESCRIPCION As String = ""
        Dim MONTO As Double = 0
        Dim PLAZO As Integer = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetOfertasPropuestas_Elimina(parametro, _
                                                                     REGION _
                                                                   , CODIGO_DA _
                                                                   , SUFIJO _
                                                                   , RUT_CTTA _
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetOfertasPropuestas_Elimina(REGION _
                                          , CODIGO_DA _
                                          , SUFIJO _
                                          , RUT_CTTA _
                                          )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_TipoUsuario(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim nombre_tipo_usuario As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_TipoUsuario(parametro, _
                                                                     accion _
                                                                   , nombre_tipo_usuario _
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_TipoUsuario(accion, nombre_tipo_usuario)

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_localizacion(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim provincia As String = ""
        Dim comuna As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_localizacion(parametro, region, provincia, comuna) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_localizacion(region, provincia, comuna)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Graba_Contratos_Detalle_Datos(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""
        Dim strLEGAL As String = ""
        Dim strAMBIENTAL As String = ""
        Dim strEXPROPIACION As String = ""
        Dim strLICITACION As String = ""
        Dim strEJECUCION As String = ""
        Dim strAUMENTO_COSTOS As String = ""
        Dim strEXPLICACION_O_ALERTAS As String = ""
        Dim strAPERTURA_LICITACION As String = ""
        Dim strPRIMERA_PIEDRA As String = ""
        Dim strINAUGURACION As String = ""
        Dim intProximo_Hito As String = ""
        Dim strObservacionMandante As String = ""
        Dim strResp_Administrativo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Graba_Contratos_Detalle_Datos(parametro, codigo_pia, codigo_region, _
                                                                                   sufijo, strLEGAL, strAMBIENTAL, _
                                                                                   strEXPROPIACION, strLICITACION, _
                                                                                   strEJECUCION, strAUMENTO_COSTOS, _
                                                                                   strEXPLICACION_O_ALERTAS, strAPERTURA_LICITACION, _
                                                                                   strPRIMERA_PIEDRA, strINAUGURACION, _
                                                                                   intProximo_Hito, strObservacionMandante, strResp_Administrativo) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Graba_Contratos_Detalle_Datos(codigo_pia, codigo_region, _
                                                          sufijo, strLEGAL, strAMBIENTAL, _
                                                          strEXPROPIACION, strLICITACION, _
                                                          strEJECUCION, strAUMENTO_COSTOS, _
                                                          strEXPLICACION_O_ALERTAS, strAPERTURA_LICITACION, _
                                                          strPRIMERA_PIEDRA, strINAUGURACION, intProximo_Hito, strObservacionMandante, strResp_Administrativo)

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Componentes(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim nombre_componente As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Componentes(parametro, accion, codigo_proyecto, nombre_componente) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Componentes(accion, codigo_proyecto, nombre_componente)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Financiamiento(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim descripcion As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Financiamiento(parametro, accion, codigo_proyecto, descripcion) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Financiamiento(accion, codigo_proyecto, descripcion)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Monumento(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim tipo As String = ""
        Dim tipo_doc As String = ""
        Dim num_doc As String = "0"
        Dim fecha As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Monumento(parametro, accion, codigo_proyecto, tipo, tipo_doc, num_doc, fecha) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Monumento(accion, codigo_proyecto, tipo, tipo_doc, num_doc, fecha)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Proceso(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim nombre_proceso As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Proceso(parametro, accion, codigo_proyecto, nombre_proceso) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Proceso(accion, codigo_proyecto, nombre_proceso)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Superficie(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim nivel As String = ""
        Dim M2 As Long = 0
        Dim proceso_asociado As Integer = 0

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Superficie(parametro, accion, codigo_proyecto, nivel, M2, proceso_asociado) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Superficie(accion, codigo_proyecto, nivel, M2, proceso_asociado)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    '//JPQV
    <WebMethod()> _
    Public Function Get_busca_asig_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_asig_cargo_presupuesto(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_asig_cargo_presupuesto(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_cargo_presupuesto(parametro, cod_con, num_epago) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_cargo_presupuesto(cod_con, num_epago)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_fondos_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_fondos_cargo_presupuesto(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_fondos_cargo_presupuesto(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_imgPatrimonio(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_imgPatrimonio(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_imgPatrimonio(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_item_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_item_cargo_presupuesto(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_item_cargo_presupuesto(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_mandantes_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_mandantes_cargo_presupuesto(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_mandantes_cargo_presupuesto(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_elimina_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""
        Dim mandante As String = ""
        Dim t_f1 As String = ""
        Dim agno As String = ""
        Dim subt As String = ""
        Dim item As String = ""
        Dim asig As String = ""
        Dim mes_cargo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_elimina_cargo_presupuesto(parametro _
                                                                                , cod_con _
                                                                                , num_epago _
                                                                                , mandante _
                                                                                , t_f1 _
                                                                                , agno _
                                                                                , subt _
                                                                                , item _
                                                                                , asig _
                                                                                , mes_cargo _
                                                                                ) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_elimina_cargo_presupuesto(cod_con _
                                                    , num_epago _
                                                    , mandante _
                                                    , t_f1 _
                                                    , agno _
                                                    , subt _
                                                    , item _
                                                    , asig _
                                                    , mes_cargo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_graba_cargo_presupuesto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim num_epago As String = ""
        Dim fecha_epago As String = ""
        Dim mandante As String = ""
        Dim t_f1 As String = ""
        Dim agno As String = ""
        Dim subt As String = ""
        Dim item As String = ""
        Dim asig As String = ""
        Dim mes_cargo As String = ""
        Dim monto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_graba_cargo_presupuesto(parametro _
                                                                                , cod_con _
                                                                                , num_epago _
                                                                                , fecha_epago _
                                                                                , mandante _
                                                                                , t_f1 _
                                                                                , agno _
                                                                                , subt _
                                                                                , item _
                                                                                , asig _
                                                                                , mes_cargo _
                                                                                , monto _
                                                                                ) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_graba_cargo_presupuesto(cod_con _
                                                    , num_epago _
                                                    , fecha_epago _
                                                    , mandante _
                                                    , t_f1 _
                                                    , agno _
                                                    , subt _
                                                    , item _
                                                    , asig _
                                                    , mes_cargo _
                                                    , monto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_llena_codigo_contratos_proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_proyecto_exp As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_llena_codigo_contratos_proyecto(parametro, codigo_proyecto_exp) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_llena_codigo_contratos_proyecto(codigo_proyecto_exp)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetValida_Acceso_Region(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim usuario As String = ""
        Dim region As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetValida_Acceso_Region(parametro, usuario, region) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetValida_Acceso_Region(usuario, region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_actualiza_fecha_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_actualiza_fecha_contrato(parametro, codigo_pia, codigo_region, sufijo) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_actualiza_fecha_contrato(codigo_pia, codigo_region, sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_consultoria_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_consultoria_detalle_termino(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_consultoria_detalle_termino(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetBusca_consultoria_detalle_termino_grilla(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetBusca_consultoria_detalle_termino_grilla(parametro, _
                                                                                            cod_con _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetBusca_consultoria_detalle_termino_grilla(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_consultoria_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim fecha_termino_fisico_ito As String = ""
        Dim resp_termino As String = ""
        Dim f_ent_def_con As String = ""
        Dim n_res_liquida_anti_con As String = ""
        Dim f_res_liquida_anti_con As String = ""
        Dim n_docto_aprueba_liquidacion_anticipada_obra As String = ""
        Dim f_docto_aprueba_liquidacion_anticipada_obra As String = ""
        Dim n_res_liquida_con As String = ""
        Dim f_res_liquida_con As String = ""
        Dim autoridad_liquida_con As String = ""
        Dim calificacion_con As Double = 0
        Dim observacion_termino_contrato As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_consultoria_detalle_termino(parametro, _
                                                                                        cod_con, _
                                                                                        fecha_termino_fisico_ito, _
                                                                                        resp_termino, _
                                                                                        f_ent_def_con, _
                                                                                        n_res_liquida_anti_con, _
                                                                                        f_res_liquida_anti_con, _
                                                                                        n_docto_aprueba_liquidacion_anticipada_obra, _
                                                                                        f_docto_aprueba_liquidacion_anticipada_obra, _
                                                                                        n_res_liquida_con, _
                                                                                        f_res_liquida_con, _
                                                                                        autoridad_liquida_con, _
                                                                                        calificacion_con, _
                                                                                        observacion_termino_contrato) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_consultoria_detalle_termino(cod_con, _
                                                            fecha_termino_fisico_ito, _
                                                            resp_termino, _
                                                            f_ent_def_con, _
                                                            n_res_liquida_anti_con, _
                                                            f_res_liquida_anti_con, _
                                                            n_docto_aprueba_liquidacion_anticipada_obra, _
                                                            f_docto_aprueba_liquidacion_anticipada_obra, _
                                                            n_res_liquida_con, _
                                                            f_res_liquida_con, _
                                                            autoridad_liquida_con, _
                                                            calificacion_con, _
                                                            observacion_termino_contrato)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_consultoria_detalle_termino_grilla(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con_c As String = ""
        Dim etapa_c As String = ""
        Dim dias_legales As String = ""
        Dim f_entrega_revision_etapa As String = ""
        Dim plazo_total As String = ""
        Dim dias_revision As String = ""
        Dim observacion_c As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_consultoria_detalle_termino_grilla(parametro, _
                                                                                        cod_con_c, _
                                                                                        etapa_c, _
                                                                                        dias_legales, _
                                                                                        f_entrega_revision_etapa, _
                                                                                        plazo_total, _
                                                                                        dias_revision, _
                                                                                        observacion_c _
                                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_consultoria_detalle_termino_grilla(cod_con_c, _
                                                                    etapa_c, _
                                                                    dias_legales, _
                                                                    f_entrega_revision_etapa, _
                                                                    plazo_total, _
                                                                    dias_revision, _
                                                                    observacion_c)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetCancela_consultoria_detalle_termino(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetCancela_consultoria_detalle_termino(parametro, _
                                                                                        cod_con _
                                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetCancela_consultoria_detalle_termino(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Elimina_Contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Elimina_Contrato(parametro, _
                                                                        codigo_pia, _
                                                                        codigo_region, _
                                                                        sufijo _
                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_Elimina_Contrato(codigo_pia, _
                                            codigo_region, _
                                            sufijo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Elimina_Proyecto(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_pia As String = ""
        Dim codigo_region As String = ""
        Dim sufijo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Elimina_Proyecto(parametro, _
                                                                        codigo_pia, _
                                                                        codigo_region) Then

                Dim ac As New AccessLayer()

                Dt = ac.Set_Elimina_Proyecto(codigo_pia, _
                                            codigo_region)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_registros_conttas_categoria(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim registro As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_registros_conttas_categoria(parametro, _
                                                                                            registro _
                                                                                            ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_registros_conttas_categoria(registro)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Contrato_Estado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim cod_con As String = ""
        Dim region As String = ""
        Dim sufijo As String = ""
        Dim estatus As String = ""
        Dim marca As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Contrato_Estado(parametro, _
                                                                        accion, _
                                                                        cod_con, _
                                                                        region, _
                                                                        sufijo, _
                                                                        estatus, _
                                                                        marca _
                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Contrato_Estado(accion, _
                                                cod_con, _
                                                region, _
                                                sufijo, _
                                                estatus, _
                                                marca _
                                                )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Complemento_Ambiental(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim codigo_complemento As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Complemento_Ambiental(parametro, accion, codigo_proyecto, codigo_complemento) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Complemento_Ambiental(accion, codigo_proyecto, codigo_complemento)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_Mnt_Multi_Financiamiento(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim codigo As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_Mnt_Multi_Financiamiento(parametro, accion, region, codigo_da, codigo) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_Mnt_Multi_Financiamiento(accion, region, codigo_da, codigo)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_Convenio_Estado(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim mandante As String = ""
        Dim correlativo As String = ""
        Dim estado As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Convenio_Estado(parametro, _
                                                                         accion, _
                                                                        region, _
                                                                        codigo_da, _
                                                                        mandante, _
                                                                        correlativo, _
                                                                        estado _
                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_Convenio_Estado(accion, _
                                                region, _
                                                codigo_da, _
                                                mandante, _
                                                correlativo, _
                                                estado _
                                                )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function



#End Region

#Region "Conexion ORACLE"

    <WebMethod()> _
    Public Function GetObtener_Codigo_SAFI() As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            Dim ac As New AccessLayer()

            Dt = ac.GetObtener_Codigo_SAFI()

            result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion

        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetGraba_Codigo_Relacional_Contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")
        Dim codigo_region As String = ""
        Dim codigo_da As String = ""
        Dim cod_con_spc As String = ""
        Dim cod_con_safi As String = ""


        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_Codigo_Relacional_Contrato(parametro, _
                                                                                        codigo_region, _
                                                                                        codigo_da, _
                                                                                        cod_con_spc, _
                                                                                        cod_con_safi _
                                                                                        ) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_Codigo_Relacional_Contrato(codigo_region, _
                                                            codigo_da, _
                                                            cod_con_spc, _
                                                            cod_con_safi _
                                                            )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()>
    Public Function SetGraba_Datos_Exploratorio(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")
        Dim strCodigoProyecto As String = "0"
        Dim strCodigoProceso As String = "0"
        Dim strNombreProyecto As String = ""
        Dim strObjeto As String = ""
        Dim strCodigoRegion As String = ""
        Dim strCodigoProvincia As String = ""
        Dim strCodigoComuna As String = "0"
        Dim strCodigoBip As String = ""
        Dim strAnoInicio As String = "0"
        Dim strMontoEstimado As String = "0"
        Dim strEtapaMideplan As String = ""
        Dim strMontoEstimadoxEtapa As String = "0"

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGraba_Datos_Exploratorio(parametro,
                                                                            strCodigoProyecto,
                                                                            strCodigoProceso,
                                                                            strNombreProyecto,
                                                                            strObjeto,
                                                                            strCodigoRegion,
                                                                            strCodigoProvincia,
                                                                            strCodigoComuna,
                                                                            strCodigoBip,
                                                                            strAnoInicio,
                                                                            strMontoEstimado,
                                                                            strEtapaMideplan,
                                                                            strMontoEstimadoxEtapa
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGraba_Datos_Exploratorio(strCodigoProyecto,
                                                    strCodigoProceso,
                                                    strNombreProyecto,
                                                    strObjeto,
                                                    strCodigoRegion,
                                                    strCodigoProvincia,
                                                    strCodigoComuna,
                                                    strCodigoBip,
                                                    strAnoInicio,
                                                    strMontoEstimado,
                                                    strEtapaMideplan,
                                                    strMontoEstimadoxEtapa
                                                    )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera, 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GetObtener_Numero_Exploratorio(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim Codigo_BIP As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetObtener_Numero_Exploratorio(parametro _
                                                                                 , Codigo_BIP _
                                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetObtener_Numero_Exploratorio(Codigo_BIP)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

#Region "Modulo Patrimonio"

    <WebMethod()> _
    Public Function Get_busca_uso_historico(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_proyecto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_uso_historico(parametro, codigo_proyecto) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_uso_historico(codigo_proyecto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Set_mnt_uso_historico
    <WebMethod()> _
    Public Function Set_mnt_uso_historico(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim categoria_uso As String = ""
        Dim tipologia_de_uso As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_mnt_uso_historico(parametro _
                                                                , accion _
                                                                , codigo_proyecto _
                                                                , categoria_uso _
                                                                , tipologia_de_uso _
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_mnt_uso_historico(accion _
                                              , codigo_proyecto _
                                              , categoria_uso _
                                              , tipologia_de_uso _
                                                )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO
    <WebMethod()> _
    Public Function Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim categoria As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(parametro, categoria) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(categoria)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_uso_actual(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim codigo_proyecto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_uso_actual(parametro, codigo_proyecto) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_uso_actual(codigo_proyecto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Set_mnt_uso_actual
    <WebMethod()> _
    Public Function Set_mnt_uso_actual(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim codigo_proyecto As String = ""
        Dim categoria_uso As String = ""
        Dim tipologia_de_uso As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_mnt_uso_actual(parametro _
                                                                , accion _
                                                                , codigo_proyecto _
                                                                , categoria_uso _
                                                                , tipologia_de_uso _
                                                                   ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_mnt_uso_actual(accion _
                                              , codigo_proyecto _
                                              , categoria_uso _
                                              , tipologia_de_uso _
                                                )

                result.Append(GenerateResultXML(Dt, 2, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    'Get_busca_CODIGO_USOS_PATRIMONIAL
    <WebMethod()> _
    Public Function Get_busca_CODIGO_USOS_PATRIMONIAL(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim categoria As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_CODIGO_USOS_PATRIMONIAL(parametro, categoria) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_CODIGO_USOS_PATRIMONIAL(categoria)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function GET_MANTENCION_PATRIMONIO_BUSCA(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_codigo_proyecto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GET_MANTENCION_PATRIMONIO_BUSCA(parametro, _
                                                                            str_codigo_proyecto) Then
                Dim ac As New AccessLayer()

                Dt = ac.GET_MANTENCION_PATRIMONIO_BUSCA(str_codigo_proyecto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

#Region "EKV"

    <WebMethod()> _
    Public Function Get_rpt_patrimonio(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim str_codigo_proyecto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_rpt_patrimonio(parametro, _
                                                                            str_codigo_proyecto) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_rpt_patrimonio(str_codigo_proyecto)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Set_MANTENCION_PATRIMONIO(ByVal parametro As String) As XmlDocument

        'EKV 18.02.2013

        Dim result As New StringBuilder("<Output>")

        Dim opcion As String = ""
        Dim codigo_proyecto As String = ""
        Dim actualizacion_data_p As String = ""
        Dim autor_ficha As String = ""
        Dim tipo_ubicacion As String = ""
        Dim latitud_coordenada As String = ""
        Dim latitud_grados As String = ""
        Dim latitud_minutos As String = ""
        Dim latitud_segundos As String = ""
        Dim longitud_coordenada As String = ""
        Dim longitud_grados As String = ""
        Dim longitud_minutos As String = ""
        Dim longitud_segundos As String = ""
        Dim utm_x As String = ""
        Dim utm_y As String = ""
        Dim utm_uso As String = ""
        Dim propietario As String = ""
        Dim administrador As String = ""
        Dim figura_legal As String = ""
        Dim modelo_gestion As String = ""
        Dim inmueble_conservacion_historica As String = ""
        Dim zona_conservacion_historica As String = ""
        Dim componente_arqueologico As String = ""
        Dim componente_ambiental As String = ""
        Dim complemento_ambiental As String = ""
        Dim otras_superficies As String = ""
        Dim antecedentes_historicos As String = ""
        Dim estado_conservacion_actual As String = ""
        Dim principales_valores As String = ""
        Dim culturales As String = ""
        Dim proyecto_intervencion As String = ""
        Dim estructura_muros As String = ""
        Dim estructura_techumbre As String = ""
        Dim acabado_fachadas As String = ""
        Dim acabado_cubierta As String = ""
        Dim ornamentacion_relevante As String = ""
        Dim otros As String = ""
        Dim descripcion_componentes As String = ""
        Dim rev_anteproy_cmn_envio As String = ""
        Dim rev_anteproy_cmn_recepcion As String = ""
        Dim rev_proy_cmn_envio As String = ""
        Dim rev_proy_cmn_recepcion As String = ""
        Dim rev_dom_envio As String = ""
        Dim rev_dom_recepcion As String = ""
        Dim rev_sea_envio As String = ""
        Dim rev_sea_recepcion As String = ""
        Dim rev_minvu_envio As String = ""
        Dim rev_minvu_recepcion As String = ""
        Dim rev_otra_envio As String = ""
        Dim rev_otra_recepcionas As String = ""
        Dim monumento_historico As String = ""
        Dim tipo_docto_mh As String = ""
        Dim numero_docto_mh As String = ""
        Dim fecha_docto_mh As String = ""
        Dim zona_tipica As String = ""
        Dim tipo_docto_zt As String = ""
        Dim numero_docto_zt As String = ""
        Dim fecha_docto_zt As String = ""
        Dim monumento_arqueologico As String = ""
        Dim tipo_docto_ma As String = ""
        Dim numero_docto_ma As String = ""
        Dim fecha_docto_ma As String = ""

        Dim sis_contructivo_proy_rest As Integer = 0
        Dim sis_contructivo_obra_nueva As Integer = 0
        Dim princ_caracteristicas_constru As String = ""

        Dim rate As String = ""
        Dim superficie_total As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Set_MANTENCION_PATRIMONIO(parametro, opcion _
                                                                 , codigo_proyecto _
                                                                 , actualizacion_data_p _
                                                                 , autor_ficha _
                                                                 , tipo_ubicacion _
                                                                 , latitud_coordenada _
                                                                 , latitud_grados _
                                                                 , latitud_minutos _
                                                                 , latitud_segundos _
                                                                 , longitud_coordenada _
                                                                 , longitud_grados _
                                                                 , longitud_minutos _
                                                                 , longitud_segundos _
                                                                 , utm_x _
                                                                 , utm_y _
                                                                 , utm_uso _
                                                                 , propietario _
                                                                 , administrador _
                                                                 , figura_legal _
                                                                 , modelo_gestion _
                                                                 , inmueble_conservacion_historica _
                                                                 , zona_conservacion_historica _
                                                                 , componente_arqueologico _
                                                                 , componente_ambiental _
                                                                 , complemento_ambiental _
                                                                 , otras_superficies _
                                                                 , antecedentes_historicos _
                                                                 , estado_conservacion_actual _
                                                                 , principales_valores _
                                                                 , culturales _
                                                                 , proyecto_intervencion _
                                                                 , estructura_muros _
                                                                 , estructura_techumbre _
                                                                 , acabado_fachadas _
                                                                 , acabado_cubierta _
                                                                 , ornamentacion_relevante _
                                                                 , otros _
                                                                 , descripcion_componentes _
                                                                 , rev_anteproy_cmn_envio _
                                                                 , rev_anteproy_cmn_recepcion _
                                                                 , rev_proy_cmn_envio _
                                                                 , rev_proy_cmn_recepcion _
                                                                 , rev_dom_envio _
                                                                 , rev_dom_recepcion _
                                                                 , rev_sea_envio _
                                                                 , rev_sea_recepcion _
                                                                 , rev_minvu_envio _
                                                                 , rev_minvu_recepcion _
                                                                 , rev_otra_envio _
                                                                 , rev_otra_recepcionas _
                                                                 , monumento_historico _
                                                                 , tipo_docto_mh _
                                                                 , numero_docto_mh _
                                                                 , fecha_docto_mh _
                                                                 , zona_tipica _
                                                                 , tipo_docto_zt _
                                                                 , numero_docto_zt _
                                                                 , fecha_docto_zt _
                                                                 , monumento_arqueologico _
                                                                 , tipo_docto_ma _
                                                                 , numero_docto_ma _
                                                                 , fecha_docto_ma _
                                                                 , sis_contructivo_proy_rest _
                                                                 , sis_contructivo_obra_nueva _
                                                                 , princ_caracteristicas_constru _
                                                                 , rate _
                                                                 , superficie_total _
                                                    ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Set_MANTENCION_PATRIMONIO(opcion _
                                                                 , codigo_proyecto _
                                                                 , actualizacion_data_p _
                                                                 , autor_ficha _
                                                                 , tipo_ubicacion _
                                                                 , latitud_coordenada _
                                                                 , latitud_grados _
                                                                 , latitud_minutos _
                                                                 , latitud_segundos _
                                                                 , longitud_coordenada _
                                                                 , longitud_grados _
                                                                 , longitud_minutos _
                                                                 , longitud_segundos _
                                                                 , utm_x _
                                                                 , utm_y _
                                                                 , utm_uso _
                                                                 , propietario _
                                                                 , administrador _
                                                                 , figura_legal _
                                                                 , modelo_gestion _
                                                                 , inmueble_conservacion_historica _
                                                                 , zona_conservacion_historica _
                                                                 , componente_arqueologico _
                                                                 , componente_ambiental _
                                                                 , complemento_ambiental _
                                                                 , otras_superficies _
                                                                 , antecedentes_historicos _
                                                                 , estado_conservacion_actual _
                                                                 , principales_valores _
                                                                 , culturales _
                                                                 , proyecto_intervencion _
                                                                 , estructura_muros _
                                                                 , estructura_techumbre _
                                                                 , acabado_fachadas _
                                                                 , acabado_cubierta _
                                                                 , ornamentacion_relevante _
                                                                 , otros _
                                                                 , descripcion_componentes _
                                                                 , rev_anteproy_cmn_envio _
                                                                 , rev_anteproy_cmn_recepcion _
                                                                 , rev_proy_cmn_envio _
                                                                 , rev_proy_cmn_recepcion _
                                                                 , rev_dom_envio _
                                                                 , rev_dom_recepcion _
                                                                 , rev_sea_envio _
                                                                 , rev_sea_recepcion _
                                                                 , rev_minvu_envio _
                                                                 , rev_minvu_recepcion _
                                                                 , rev_otra_envio _
                                                                 , rev_otra_recepcionas _
                                                                 , monumento_historico _
                                                                 , tipo_docto_mh _
                                                                 , numero_docto_mh _
                                                                 , fecha_docto_mh _
                                                                 , zona_tipica _
                                                                 , tipo_docto_zt _
                                                                 , numero_docto_zt _
                                                                 , fecha_docto_zt _
                                                                 , monumento_arqueologico _
                                                                 , tipo_docto_ma _
                                                                 , numero_docto_ma _
                                                                 , fecha_docto_ma _
                                                                 , sis_contructivo_proy_rest _
                                                                 , sis_contructivo_obra_nueva _
                                                                 , princ_caracteristicas_constru _
                                                                 , rate _
                                                                 , superficie_total _
                                                                 )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_valida_existencia_contrato(ByVal parametro As String) As XmlDocument
        'GSI: 13/01/2012
        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_valida_existencia_contrato(parametro, _
                                                                cod_con, _
                                                                codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_valida_existencia_contrato(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_updateImagenesContratos(ByVal parametro As String) As XmlDocument
        'GSI: 13/01/2012
        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim codigo_da As String = ""
        Dim pathImagen As String = ""
        Dim nombImagen As String = ""
        Dim TipoImagen As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_updateImagenesContratos(parametro, _
                                                                cod_con, _
                                                                codigo_da, _
                                                                pathImagen, _
                                                                nombImagen, _
                                                                TipoImagen) Then

                Dim ac As New AccessLayer()

                Dt = ac.SetMnt_updateImagenesContratos(cod_con,
                                             pathImagen,
                                            nombImagen,
                                            TipoImagen)


                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetMnt_ImagenesContrato_BorraContrato(ByVal parametro As String) As XmlDocument
        'GSI: 13/01/2012
        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_ImagenesContrato_BorraContrato(parametro,
                                                                cod_con) Then

                Dim ac As New AccessLayer()

                Dt = ac.Setmnt_ImagenesContrato_BorraContrato(cod_con)


                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_tipo_proceso(ByVal parametro As String) As XmlDocument
        'GSI: 13/01/2013

        Dim result As New StringBuilder("<Output>")

        Dim codigo_contrato As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_tipo_proceso(parametro, _
                                                                codigo_contrato _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_tipo_proceso(codigo_contrato)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function Get_busca_imgFichaProyecto(ByVal parametro As String) As XmlDocument
        'GSI EK: 14/01/2013
        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_Get_busca_imgFichaProyecto(parametro, cod_con) Then
                Dim ac As New AccessLayer()

                Dt = ac.Get_busca_imgFichaProyecto(cod_con)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

#Region "Creado 22-04-2014 ARB"

    'Elimina Boleta de Garantia de Contrato
    <WebMethod()> _
    Public Function SetElimina_boleta_garantia_contrato(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim cod_con As String = ""
        Dim cod_tipo As String = ""
        Dim entidad_financiera As String = ""
        Dim numero As String = ""
        Dim fecha As String = ""
        Dim fecha_vencimiento_inicial As String = ""
        Dim fecha_vencimiento As String = ""
        Dim monto As String = ""
        Dim tipo_moneda As String = ""
        Dim num_oficio_destino_documento As String = ""
        Dim fecha_oficio_destino_documento As String = ""
        Dim entidad_que_custodia As String = ""
        Dim num_oficio_solicitud_garantia As String = ""
        Dim fecha_oficio_solicitud_garantia As String = ""
        Dim fecha_devolucion_garantia As String = ""
        Dim tipo_de_documento As String = ""
        Dim fecha_ingreso As String = ""
        Dim devuelta As String = ""
        Dim fecha_prorroga As String = ""
        Dim fecha_nuevo_vencimiento As String = ""
        Dim dias As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetElimina_boleta_garantia_contrato(parametro, _
                                                                                      cod_con, _
                                                                                      entidad_financiera, _
                                                                                      numero _
                                                                                      ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetElimina_boleta_garantia_contrato(cod_con, _
                                                            entidad_financiera, _
                                                            numero _
                                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

#Region "Metodos para Programación de Montos IDEA"

    <WebMethod()> _
    Public Function SetGrabaProgramacionMontoIdea(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim agno As String = ""
        Dim monto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetGrabaProgramacionMontoIdea(parametro, _
                                                                region, _
                                                                codigo_da, _
                                                                agno, _
                                                                monto _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetGrabaProgramacionMontoIdea(region, _
                                            codigo_da, _
                                            agno, _
                                            monto _
                                            )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

    <WebMethod()> _
    Public Function SetEliminaProgramacionMontoIdea(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""
        Dim agno As String = ""
        Dim monto As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetEliminaProgramacionMontoIdea(parametro, _
                                                                region, _
                                                                codigo_da, _
                                                                agno _
                                                                ) Then
                Dim ac As New AccessLayer()

                Dt = ac.SetEliminaProgramacionMontoIdea(region, _
                                                        codigo_da, _
                                                        agno _
                                                        )

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function


    <WebMethod()> _
    Public Function GetProgramacionMontoIdea(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim region As String = ""
        Dim codigo_da As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_GetProgramacionMontoIdea(parametro, region, codigo_da) Then
                Dim ac As New AccessLayer()

                Dt = ac.GetProgramacionMontoIdea(region, codigo_da)

                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

#End Region

    <WebMethod()> _
    Public Function SetMnt_Edificacion(ByVal parametro As String) As XmlDocument

        Dim result As New StringBuilder("<Output>")

        Dim accion As String = ""
        Dim sector_destino As String = ""
        Dim subsector As String = ""
        Dim tipologia As String = ""
        Dim descripcion As String = ""
        Dim edi_orden_listado As String = ""

        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try
            'Valido el XML enviado como parametro
            If ValidateInput.GetInstance().Valida_SetMnt_Edificacion(parametro, accion, sector_destino, subsector, tipologia, descripcion, edi_orden_listado) Then
                Dim ac As New AccessLayer()
                Dt = ac.SetMnt_Edificacion(accion, sector_destino, subsector, tipologia, descripcion, edi_orden_listado)
                result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion
            End If
        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())
    End Function

End Class