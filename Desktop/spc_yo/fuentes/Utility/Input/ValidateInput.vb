'<summary>
'Creado por: Erick Kleiner - GSI Asesorias
'Fecha: 17-10-2012
'Descripción: Reportes Varios
'</summary>

'<summary>
'Modificado por: Alexi Rodriguez B. - MOP
'Fecha: 22-04-2014
'Descripción: Se crea metodo Valida_SetElimina_boleta_garantia_contrato
'</summary>

'<summary>
'Modificado por: Alexi Rodriguez B. - MOP
'Fecha: 10-04-2015
'Descripción:   Se crean metodos para agregar funcionalidad de Programación Tentativa propuesta y son los sgtes:
'               - Valida_GetBusca_programacion_tentativa_propuesta_financ
'               - Valida_GetBusca_programacion_tentativa_propuesta_financ_suma
'               - Valida_SetGraba_programacion_tentativa_propuesta_financ
'               - Valida_SetEliminar_programacion_tentativa_propuesta_financ
'               Se modifica en metodo
'               - Valida_SetGrabaDetalleProyecto
'</summary>

Imports System.Globalization
Imports System.Xml
Imports System.Xml.Schema

Namespace PYC.Utilities.Input

    Partial Public Class ValidateInput

#Region "Singleton para acceder a los metodos de esta clase"
        Private Shared hlp As ValidateInput
        Private Shared _classLock As Object = GetType(ValidateInput)

        Private Sub New()
        End Sub
        Public Shared Function GetInstance() As ValidateInput
            SyncLock _classLock
                If hlp Is Nothing Then hlp = New ValidateInput()

                Return hlp
            End SyncLock
        End Function
#End Region

#Region "Metodos JG"

        Public Function ValidaConsulta(ByVal result As String, ByRef Tipo As String) As Boolean

            Dim IsValid As Boolean = False
            Dim FechaPaso As String = ""
            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.ConsultaGeneral.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    Tipo = Trim(element.GetElementsByTagName("tipo")(0).InnerText)
                Next

                'If Tipo = "" Then Throw New Exception("tipo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Ing_Proyectos(ByVal result As String, _
                                                    ByRef region As String, _
                                                    ByRef tipo_proy As String, _
                                                    ByRef plan As Long, _
                                                    ByRef producto As String, _
                                                    ByRef proceso As String, _
                                                    ByRef objeto As String, _
                                                    ByRef fondo As String, _
                                                    ByRef sector_destino As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Ing_Proyectos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    tipo_proy = Trim(element.GetElementsByTagName("tipo_proy")(0).InnerText)
                    plan = Val(element.GetElementsByTagName("plan")(0).InnerText)
                    producto = Trim(element.GetElementsByTagName("producto")(0).InnerText)
                    proceso = Trim(element.GetElementsByTagName("proceso")(0).InnerText)
                    objeto = Trim(element.GetElementsByTagName("objeto")(0).InnerText)
                    fondo = Trim(element.GetElementsByTagName("fondo")(0).InnerText)
                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")
                'If tipo_proy = "" Then Throw New Exception("tipo_proy")
                'If plan = 0 Then Throw New Exception("plan")
                'If producto = "" Then Throw New Exception("producto")
                'If proceso = "" Then Throw New Exception("proceso")
                'If objeto = "" Then Throw New Exception("objeto")
                'If fondo = "" Then Throw New Exception("fondo")
                'If sector_destino = "" Then Throw New Exception("sector_destino")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetLlena_Codigo_Contratos(ByVal result As String, _
                                                         ByRef str_region_inicio As String, _
                                                         ByRef str_region_fin As String, _
                                                         ByRef str_fecha_inicio As String, _
                                                         ByRef str_fecha_fin As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetLlena_Codigo_Contratos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    str_region_inicio = Trim(element.GetElementsByTagName("str_region_inicio")(0).InnerText)
                    str_region_fin = Trim(element.GetElementsByTagName("str_region_fin")(0).InnerText)
                    str_fecha_inicio = Trim(element.GetElementsByTagName("str_fecha_inicio")(0).InnerText)
                    str_fecha_fin = Trim(element.GetElementsByTagName("str_fecha_fin")(0).InnerText)
                Next

                'If str_region_inicio = "" Then Throw New Exception("str_region_inicio")
                'If str_region_fin = "" Then Throw New Exception("str_region_fin")
                'If str_fecha_inicio = "" Then Throw New Exception("str_fecha_inicio")
                'If str_fecha_fin = "" Then Throw New Exception("str_fecha_fin")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Usuarios(ByVal result As String, _
                                                 ByRef usuario As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Usuarios.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    usuario = Trim(element.GetElementsByTagName("usuario")(0).InnerText)
                Next

                'If usuario = "" Then Throw New Exception("usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Tipos_Usuarios(ByVal result As String, _
                                                       ByRef codigo_tipo_usuario As Long) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Tipos_Usuarios.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_tipo_usuario = Val(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                Next

                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Proyectos(ByVal result As String, _
                                                  ByRef str_tipo_proyecto As String, _
                                                  ByRef str_region_inicio As String, _
                                                  ByRef str_region_fin As String, _
                                                  ByRef str_estado_inicio As String, _
                                                  ByRef str_estado_fin As String, _
                                                  ByRef str_proceso_inicio As String, _
                                                  ByRef str_proceso_fin As String, _
                                                  ByRef str_bd_con_proy As String, _
                                                  ByRef str_con_proy As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Proyectos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    str_tipo_proyecto = Trim(element.GetElementsByTagName("str_tipo_proyecto")(0).InnerText)
                    str_region_inicio = Trim(element.GetElementsByTagName("str_region_inicio")(0).InnerText)
                    str_region_fin = Trim(element.GetElementsByTagName("str_region_fin")(0).InnerText)
                    str_estado_inicio = Trim(element.GetElementsByTagName("str_estado_inicio")(0).InnerText)
                    str_estado_fin = Trim(element.GetElementsByTagName("str_estado_fin")(0).InnerText)
                    str_proceso_inicio = Trim(element.GetElementsByTagName("str_proceso_inicio")(0).InnerText)
                    str_proceso_fin = Trim(element.GetElementsByTagName("str_proceso_fin")(0).InnerText)

                    str_bd_con_proy = Trim(element.GetElementsByTagName("str_bd_con_proy")(0).InnerText)
                    str_con_proy = Trim(element.GetElementsByTagName("str_con_proy")(0).InnerText)
                Next

                'If str_tipo_proyecto = "" Then Throw New Exception("str_tipo_proyecto")
                'If str_region_inicio = "" Then Throw New Exception("str_region_inicio")
                'If str_region_fin = "" Then Throw New Exception("str_region_fin")
                'If str_estado_inicio = "" Then Throw New Exception("str_estado_inicio")
                'If str_estado_fin = "" Then Throw New Exception("str_estado_fin")
                'If str_proceso_inicio = "" Then Throw New Exception("str_proceso_inicio")
                'If str_proceso_fin = "" Then Throw New Exception("str_proceso_fin")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Proyecto_Encabezado(ByVal result As String, _
                                                            ByRef codigo_pia As String, _
                                                            ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Proyecto_Encabezado.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = element.GetElementsByTagName("codigo_pia")(0).InnerText
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Proyecto_Contratos_Relacionados_Encabezado(ByVal result As String, _
                                                                                   ByRef codigo_pia As String, _
                                                                                   ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Proyecto_Contratos_Relacionados_Encabezado.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Proyecto_Contratos_Relacionados_Detalle(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Proyecto_Contratos_Relacionados_Detalle.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Permisos_usuario(ByVal result As String, _
                                                         ByRef codigo_tipo_usuario As Long) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Permisos_usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_tipo_usuario = Val(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                Next

                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Contratos_Encabezado(ByVal result As String, _
                                                             ByRef codigo_pia As String, _
                                                             ByRef codigo_region As String, _
                                                             ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Contratos_Encabezado.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Contratos_Detalle_Datos(ByVal result As String, _
                                                                ByRef codigo_pia As String, _
                                                                ByRef codigo_region As String, _
                                                                ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Contratos_Detalle_Datos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Correlativo_Proceso_Relacionados_Edita(ByVal result As String, _
                                                                               ByRef tipologia As String, _
                                                                               ByRef etapa As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Correlativo_Proceso_Relacionados_Edita.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    tipologia = Trim(element.GetElementsByTagName("tipologia")(0).InnerText)
                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                Next

                'If tipologia = "" Then Throw New Exception("tipologia")
                'If etapa = "" Then Throw New Exception("etapa")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Correlativo_Mandantes_Relacionados_Edita(ByVal result As String, _
                                                                                 ByRef codigo_pia As String, _
                                                                                 ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Correlativo_Mandantes_Relacionados_Edita.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Correlativo_Etapa_Relacionados_Edita(ByVal result As String, _
                                                                             ByRef codigo_pia As String, _
                                                                             ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Correlativo_Etapa_Relacionados_Edita.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Public Function Valida_GetBusca_Correlativo_Convenios_Relacionados_Edita(ByVal result As String, _
        '                                                                         ByRef codigo_pia As String, _
        '                                                                         ByRef codigo_region As String) As Boolean

        '    Dim IsValid As Boolean = False

        '    Try
        '        'CambiaConfiguracionRegional()
        '        'Cargo los XSD que estan como atributos del assembly...
        '        Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Correlativo_Convenios_Relacionados_Edita.xsd")
        '        Dim schema As New XmlSchemaSet()
        '        schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
        '        schema.Compile()

        '        'Cargo el XML y asigno el namespace correspondiente
        '        Dim xDoc As New XmlDocument()
        '        xDoc.LoadXml(SetNamespace(result.ToString()))
        '        xDoc.Schemas = schema

        '        'Valido el XML con el XSD
        '        xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

        '        IsValid = True

        '        For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
        '            Dim element As XmlElement = CType(node, XmlElement)
        '            codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
        '            codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
        '        Next

        '        If codigo_pia = "" Then Throw New Exception("codigo_pia")
        '        If codigo_region = "" Then Throw New Exception("codigo_region")


        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        '    Return IsValid
        'End Function

        Public Function Valida_GetBusca_Datos_Usuario(ByVal result As String, _
                                                      ByRef usuario As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    usuario = Trim(element.GetElementsByTagName("usuario")(0).InnerText)
                Next

                'If usuario = "" Then Throw New Exception("usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121125
        Public Function Valida_GetBusca_Provincia(ByVal result As String, _
                                                  ByRef Region As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Provincia.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    Region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                Next

                'If Region = "" Then Throw New Exception("Region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121125
        Public Function Valida_GetContratistaAdjudicado(ByVal result As String, _
                                                        ByRef region As String _
                                                      , ByRef codigo_da As String _
                                                      , ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetContratistaAdjudicado.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                Next

                'If region = "" Then Throw New Exception("Region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_Contratos_Detalle_Datos(ByVal result As String, _
                                                                ByRef codigo_pia As String, _
                                                                ByRef codigo_region As String, _
                                                                ByRef sufijo As String, _
                                                                ByRef strlegal As String, _
                                                                ByRef strambiental As String, _
                                                                ByRef strexpropiacion As String, _
                                                                ByRef strlicitacion As String, _
                                                                ByRef strejecucion As String, _
                                                                ByRef straumento_costos As String, _
                                                                ByRef strexplicacion_o_alertas As String, _
                                                                ByRef strapertura_licitacion As String, _
                                                                ByRef strprimera_piedra As String, _
                                                                ByRef strinauguracion As String, _
                                                                ByRef intProximo_Hito As String, _
                                                                ByRef strObservacionMandante As String, _
                                                                ByRef strResp_Administrativo As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGraba_Contratos_Detalle_Datos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    strlegal = Trim(element.GetElementsByTagName("strlegal")(0).InnerText)
                    strambiental = Trim(element.GetElementsByTagName("strambiental")(0).InnerText)
                    strexpropiacion = Trim(element.GetElementsByTagName("strexpropiacion")(0).InnerText)
                    strlicitacion = Trim(element.GetElementsByTagName("strlicitacion")(0).InnerText)
                    strejecucion = Trim(element.GetElementsByTagName("strejecucion")(0).InnerText)
                    straumento_costos = Trim(element.GetElementsByTagName("straumento_costos")(0).InnerText)
                    strexplicacion_o_alertas = Trim(element.GetElementsByTagName("strexplicacion_o_alertas")(0).InnerText)
                    strapertura_licitacion = Trim(element.GetElementsByTagName("strapertura_licitacion")(0).InnerText)
                    strprimera_piedra = Trim(element.GetElementsByTagName("strprimera_piedra")(0).InnerText)
                    strObservacionMandante = Trim(element.GetElementsByTagName("strObservacionMandante")(0).InnerText)
                    strinauguracion = Trim(element.GetElementsByTagName("strinauguracion")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If strlegal = "" Then Throw New Exception("strlegal")
                'If strambiental = "" Then Throw New Exception("strambiental")
                'If strexpropiacion = "" Then Throw New Exception("strexpropiacion")
                'If strlicitacion = "" Then Throw New Exception("strlicitacion")
                'If strejecucion = "" Then Throw New Exception("strejecucion")
                'If straumento_costos = "" Then Throw New Exception("straumento_costos")
                'If strexplicacion_o_alertas = "" Then Throw New Exception("strexplicacion_o_alertas")
                'If strapertura_licitacion = "" Then Throw New Exception("strapertura_licitacion")
                'If strprimera_piedra = "" Then Throw New Exception("strprimera_piedra")
                'If strinauguracion = "" Then Throw New Exception("strinauguracion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_Contratos_Detalle_Edicion(ByVal result As String, _
                                                                  ByRef codigo_pia As String, _
                                                                  ByRef codigo_region As String, _
                                                                  ByRef sufijo As String, _
                                                                  ByRef numcorrelativo_convenio As String, _
                                                                  ByRef strmandante_convenio As String, _
                                                                  ByRef stretapa As String, _
                                                                  ByRef strtipo_proceso As String, _
                                                                  ByRef strfinanciamiento As String, _
                                                                  ByRef strobjeto As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGraba_Contratos_Detalle_Edicion.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    numcorrelativo_convenio = Trim(element.GetElementsByTagName("numcorrelativo_convenio")(0).InnerText)
                    strmandante_convenio = Trim(element.GetElementsByTagName("strmandante_convenio")(0).InnerText)
                    stretapa = Trim(element.GetElementsByTagName("stretapa")(0).InnerText)
                    strtipo_proceso = Trim(element.GetElementsByTagName("strtipo_proceso")(0).InnerText)
                    strfinanciamiento = Trim(element.GetElementsByTagName("strfinanciamiento")(0).InnerText)
                    strobjeto = Trim(element.GetElementsByTagName("strobjeto")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If numcorrelativo_convenio = 0 Then Throw New Exception("numcorrelativo_convenio")
                'If strmandante_convenio = "" Then Throw New Exception("strmandante_convenio")
                'If stretapa = "" Then Throw New Exception("stretapa")
                'If strtipo_proceso = "" Then Throw New Exception("strtipo_proceso")
                'If strfinanciamiento = "" Then Throw New Exception("strfinanciamiento")
                'If strobjeto = "" Then Throw New Exception("strobjeto")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function
        Public Function Valida_SetMnt_Imagen(ByVal result As String,
                                              ByRef codcon As String,
                                              ByRef fuImgProyecto As Long) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codcon = Trim(element.GetElementsByTagName("codcon")(0).InnerText)
                    fuImgProyecto = Trim(element.GetElementsByTagName("fuImgProyecto")(0).InnerText)

                Next


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function




        Public Function Valida_SetMnt_Comunas(ByVal result As String, _
                                              ByRef accion As String, _
                                              ByRef region As String, _
                                              ByRef provincia As String, _
                                              ByRef comuna As String, _
                                              ByRef cod_comun As String, _
                                              ByRef n_comu As String, _
                                              ByRef poblacion As Long) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Comunas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    provincia = Trim(element.GetElementsByTagName("provincia")(0).InnerText)
                    comuna = Trim(element.GetElementsByTagName("comuna")(0).InnerText)
                    cod_comun = Trim(element.GetElementsByTagName("cod_comun")(0).InnerText)
                    n_comu = Trim(element.GetElementsByTagName("n_comu")(0).InnerText)
                    poblacion = Val(element.GetElementsByTagName("poblacion")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If region = "" Then Throw New Exception("region")
                'If provincia = "" Then Throw New Exception("provincia")
                'If comuna = "" Then Throw New Exception("comuna")
                'If cod_comun = "" Then Throw New Exception("cod_comun")
                'If n_comu = "" Then Throw New Exception("n_comu")
                'If poblacion = 0 Then Throw New Exception("poblacion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Dom_Insp_Fis(ByVal result As String, _
                                                   ByRef accion As String, _
                                                   ByRef rut As String, _
                                                   ByRef nombre As String, _
                                                   ByRef profesion As String, _
                                                   ByRef sexo As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Insp_Fis.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    rut = Trim(element.GetElementsByTagName("rut")(0).InnerText)
                    nombre = Trim(element.GetElementsByTagName("nombre")(0).InnerText)
                    profesion = Trim(element.GetElementsByTagName("profesion")(0).InnerText)
                    sexo = Trim(element.GetElementsByTagName("sexo")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If rut = "" Then Throw New Exception("rut")
                'If nombre = "" Then Throw New Exception("nombre")
                'If profesion = "" Then Throw New Exception("profesion")
                'If sexo = "" Then Throw New Exception("sexo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Permisos_Usuario(ByVal result As String, _
                                                       ByRef accion As String, _
                                                       ByRef codigo_tipo_usuario As Long, _
                                                       ByRef codigo_opcion As Long, _
                                                       ByRef asignar As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Permisos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_tipo_usuario = Val(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                    codigo_opcion = Val(element.GetElementsByTagName("codigo_opcion")(0).InnerText)
                    asignar = Trim(element.GetElementsByTagName("asignar")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")
                'If codigo_opcion = 0 Then Throw New Exception("codigo_opcion")
                'If asignar = "" Then Throw New Exception("asignar")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Usuario(ByVal result As String, _
                                              ByRef accion As String, _
                                              ByRef nombre_usuario As String, _
                                              ByRef correo_electronico As String, _
                                              ByRef codigo_tipo_usuario As Long, _
                                              ByRef nombre_completo As String, _
                                              ByRef nombre_usuario_corto As String, _
                                              ByRef region As String _
                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    nombre_usuario = Trim(element.GetElementsByTagName("nombre_usuario")(0).InnerText)
                    correo_electronico = Trim(element.GetElementsByTagName("correo_electronico")(0).InnerText)
                    codigo_tipo_usuario = Val(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                    nombre_completo = Trim(element.GetElementsByTagName("nombre_completo")(0).InnerText)

                    nombre_usuario_corto = Trim(element.GetElementsByTagName("nombre_usuario_corto")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)

                Next

                'If accion = "" Then Throw New Exception("accion")
                'If nombre_usuario = "" Then Throw New Exception("nombre_usuario")
                'If correo_electronico = "" Then Throw New Exception("correo_electronico")
                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")
                'If nombre_completo = "" Then Throw New Exception("nombre_completo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetValida_Acceso_Menu_Usuario(ByVal result As String, _
                                                             ByRef codigo_tipo_usuario As Long, _
                                                             ByRef opcion_menu As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetValida_Acceso_Menu_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_tipo_usuario = Val(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                    opcion_menu = Trim(element.GetElementsByTagName("opcion_menu")(0).InnerText)

                Next

                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")
                'If opcion_menu = "" Then Throw New Exception("opcion_menu")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetValida_Login_Usuario(ByVal result As String, _
                                                       ByRef usuario As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetValida_Login_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    usuario = Trim(element.GetElementsByTagName("usuario")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Contratista(ByVal result As String, _
                                                  ByRef accion As String _
                                                , ByRef rut_ctta As String _
                                                , ByRef n_ctta As String _
                                                , ByRef registro As String _
                                                , ByRef categoria As String _
                                                , ByRef telefono_fax As String _
                                                , ByRef sexo As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Contratista.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    rut_ctta = Trim(element.GetElementsByTagName("rut_ctta")(0).InnerText)
                    n_ctta = Trim(element.GetElementsByTagName("n_ctta")(0).InnerText)
                    registro = Trim(element.GetElementsByTagName("registro")(0).InnerText)
                    categoria = Trim(element.GetElementsByTagName("categoria")(0).InnerText)
                    telefono_fax = Trim(element.GetElementsByTagName("telefono_fax")(0).InnerText)
                    sexo = Trim(element.GetElementsByTagName("sexo")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If rut_ctta = "" Then Throw New Exception("rut_ctta")
                'If n_ctta = "" Then Throw New Exception("n_ctta")
                'If registro = "" Then Throw New Exception("registro")
                'If categoria = "" Then Throw New Exception("categoria")
                'If telefono_fax = "" Then Throw New Exception("telefono_fax")
                'If sexo = "" Then Throw New Exception("sexo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Asigno el namespace al XML enviado
        Private Function SetNamespace(ByVal file As String) As String
            Dim xml As New XmlDocument()

            xml.LoadXml(file)

            xml.DocumentElement.SetAttribute("xmlns", "http://www.pyc.cl/Consulta")

            Return xml.OuterXml
        End Function

        'Asigno el namespace al XML enviado
        Private Function SetNamespaceSave(ByVal file As String) As String
            Dim xml As New XmlDocument()

            xml.LoadXml(file)

            xml.DocumentElement.SetAttribute("xmlns", "http://www.pyc.cl/Grabar")

            Return xml.OuterXml
        End Function

        Sub CambiaConfiguracionRegional()

            Dim CultureInfo As New System.Globalization.CultureInfo("es-CL")

            CultureInfo.NumberFormat.CurrencySymbol = "$"

            CultureInfo.NumberFormat.CurrencyDecimalSeparator = "."

            CultureInfo.NumberFormat.CurrencyGroupSeparator = ","

            CultureInfo.NumberFormat.CurrencyDecimalDigits = 2

            CultureInfo.NumberFormat.NumberDecimalSeparator = "."

            CultureInfo.NumberFormat.NumberGroupSeparator = ","

            CultureInfo.NumberFormat.NumberDecimalDigits = 2

            CultureInfo.NumberFormat.PercentDecimalSeparator = "."

            CultureInfo.NumberFormat.PercentGroupSeparator = ","


        End Sub

        'JGM 20121127
        Public Function Valida_GetContratosPropuestas(ByVal result As String, _
                                                        ByRef region As String _
                                                      , ByRef codigo_da As String _
                                                      , ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetContratosPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                Next

                'If region = "" Then Throw New Exception("Region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121127
        Public Function Valida_GetOfertasPropuestaContratista(ByVal result As String, _
                                                              ByRef region As String _
                                                            , ByRef codigo_da As String _
                                                            , ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetOfertasPropuestaContratista.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                Next

                'If region = "" Then Throw New Exception("Region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121127
        Public Function Valida_GetDomMandantes2(ByVal result As String, _
                                              ByRef region As String _
                                            , ByRef codigo_da As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetDomMandantes2.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                ' xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))
                '
                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                Next

                'If region = "" Then Throw New Exception("Region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121127
        Public Function Valida_SetOfertasPropuestas(ByVal result As String _
                                                 , ByRef REGION As String _
                                                 , ByRef CODIGO_DA As String _
                                                 , ByRef SUFIJO As String _
                                                 , ByRef RUT_CTTA As String _
                                                 , ByRef DESCRIPCION As String _
                                                 , ByRef MONTO As Double _
                                                 , ByRef PLAZO As Integer _
                                                 ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetOfertasPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    REGION = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    CODIGO_DA = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    SUFIJO = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    RUT_CTTA = Trim(element.GetElementsByTagName("rut_ctta")(0).InnerText)
                    DESCRIPCION = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                    MONTO = CDbl(element.GetElementsByTagName("monto")(0).InnerText)
                    PLAZO = Trim(element.GetElementsByTagName("plazo")(0).InnerText)
                Next

                'If REGION = "" Then Throw New Exception("Region")
                'If CODIGO_DA = "" Then Throw New Exception("codigo_da")
                'If SUFIJO = "" Then Throw New Exception("sufijo")
                'If RUT_CTTA = "" Then Throw New Exception("rut_ctta")
                'If DESCRIPCION = "" Then Throw New Exception("descripcion")
                'If MONTO = 0 Then Throw New Exception("monto")
                'If PLAZO = "" Then Throw New Exception("plazo")
                'If BENEFICIO_PORCENTUAL = 0 Then Throw New Exception("beneficio_porcentual")
                'If FECHA_INGRESO = "" Then Throw New Exception("fecha_ingreso")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121127
        Public Function Valida_SetMandantesContrato(ByVal result As String _
                                                  , ByRef MANDANTE As String _
                                                  , ByRef REGION As String _
                                                  , ByRef CODIGO_DA As String _
                                                  , ByRef SUFIJO As String _
                                                  , ByRef COD_CON As String _
                                                  ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMandantesContrato.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    MANDANTE = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    REGION = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    CODIGO_DA = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    SUFIJO = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    COD_CON = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                Next

                'If MANDANTE = "" Then Throw New Exception("Mandante")
                'If REGION = "" Then Throw New Exception("Region")
                'If CODIGO_DA = "" Then Throw New Exception("codigo_da")
                'If SUFIJO = "" Then Throw New Exception("sufijo")
                'If COD_CON = "" Then Throw New Exception("Cod_Con")
                'If FECHA_INGRESO = "" Then Throw New Exception("fecha_ingreso")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121127
        Public Function Valida_SetContratoPropuesta(ByVal result As String _
                                                  , ByRef REGION As String _
                                                    , ByRef CODIGO_DA As String _
                                                    , ByRef SUFIJO As String _
                                                    , ByRef T_F1 As String _
                                                    , ByRef PROVINCIA As String _
                                                    , ByRef COMUNA As String _
                                                    , ByRef CODIGO_LOCALIDAD As Long _
                                                    , ByRef TIPO_PROCESO As String _
                                                    , ByRef OBJETO As String _
                                                    , ByRef LOCALIZACION As String _
                                                    , ByRef NUMERO_LOCALIZACION As String _
                                                    , ByRef MANDANTE_CONVENIO As String _
                                                    , ByRef CORRELATIVO_CONVENIO As Integer _
                                                    , ByRef ESTATUS As String _
                                                    , ByRef VALIDO As Integer _
                                                    , ByRef TI_LIC As String _
                                                    , ByRef TI_CON As String _
                                                    , ByRef TIPO_REAJUSTE As String _
                                                    , ByRef FECHA_LIC_PR As String _
                                                    , ByRef FECHA_AP_ESTIMADA As String _
                                                    , ByRef FECHA_AP_PR As String _
                                                    , ByRef FECHA_AP_PR_ECO As String _
                                                    , ByRef FECHA_INICIO_ESTIMADA As String _
                                                    , ByRef BASES_ADMIN_GENERALES As String _
                                                    , ByRef BASES_ADMIN_ESPECIALES As String _
                                                    , ByRef BASES_TECNICAS As String _
                                                    , ByRef CARPETA_TECNICA_LICITACION As String _
                                                    , ByRef REGISTRO As String _
                                                    , ByRef CATEGORIA As String _
                                                    , ByRef MONTO_PROGRA As Double _
                                                    , ByRef PLAZO_ESTIMADO_EJEC As Integer _
                                                    , ByRef RESP_ANTECEDENTES_PPTA As String _
                                                    , ByRef ANTICIPO_CONTEMPLADO As Double _
                                                    , ByRef ANTIC_CONTEMPL_PORC As Double _
                                                    , ByRef APLICA_CARTILLA_R_26 As String _
                                                    , ByRef FECHA_DOCTO_R26 As String _
                                                    , ByRef APLICA_CARTILLA_R_28 As String _
                                                    , ByRef FECHA_DOCTO_R28 As String _
                                                    , ByRef APLICA_CARTILLA_R_29 As String _
                                                    , ByRef FECHA_DOCTO_R29 As String _
                                                    , ByRef REQUIERE_REG_ESPECIAL As String _
                                                    , ByRef N_PERMISO_EDIFICACION As String _
                                                    , ByRef FECHA_PERMISO_EDIFICACION As String _
                                                    , ByRef id_chile_compra As String _
                                                    , ByRef ces As String _
                                                    , ByRef N_DOCTO_R5 As Long _
                                                    , ByRef FECHA_DOCTO_R5 As String _
                                                    , ByRef FECHA_LIC As String _
                                                    , ByRef F_AP_TECNICA_PROP As String _
                                                    , ByRef F_AP_PROP As String _
                                                    , ByRef PLAZO_OFICIAL As Integer _
                                                    , ByRef MT_OFI As Double _
                                                    , ByRef OBSERVACIONES_PROP As String _
                                                    , ByRef RESULTADO_PROPUESTA As String _
                                                    , ByRef RESP_LCITACION As String _
                                                    , ByRef LLAMADO As Integer _
                                                    , ByRef n_res_no_adjudica As Integer _
                                                    , ByRef f_res_no_adjudica As String _
                                                    , ByRef FECHA_INFORME_ADJUDICACION As String _
                                                    , ByRef MTO_OR As Double _
                                                    , ByRef PLAZO_OR As Double _
                                                    , ByRef OR_RES As String _
                                                    , ByRef N_RES As Integer _
                                                    , ByRef F_RES As String _
                                                    , ByRef F_TRAMI As String _
                                                    , ByRef RUT_CON As String _
                                                    , ByRef COM_EVAL_OFERTA1 As String _
                                                    , ByRef COM_EVAL_OFERTA2 As String _
                                                    , ByRef COM_EVAL_OFERTA3 As String _
                                                    , ByRef adjudicado As String _
                                                    , ByRef SECCION As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetContratoPropuesta.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    REGION = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    CODIGO_DA = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    SUFIJO = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    T_F1 = Trim(element.GetElementsByTagName("t_f1")(0).InnerText)
                    PROVINCIA = Trim(element.GetElementsByTagName("provincia")(0).InnerText)
                    COMUNA = Trim(element.GetElementsByTagName("comuna")(0).InnerText)
                    CODIGO_LOCALIDAD = CLng(element.GetElementsByTagName("codigo_localidad")(0).InnerText)
                    TIPO_PROCESO = Trim(element.GetElementsByTagName("tipo_proceso")(0).InnerText)
                    OBJETO = Trim(element.GetElementsByTagName("objeto")(0).InnerText)
                    LOCALIZACION = Trim(element.GetElementsByTagName("localizacion")(0).InnerText)
                    NUMERO_LOCALIZACION = Trim(element.GetElementsByTagName("numero_localizacion")(0).InnerText)
                    MANDANTE_CONVENIO = Trim(element.GetElementsByTagName("mandante_convenio")(0).InnerText)
                    CORRELATIVO_CONVENIO = CInt(element.GetElementsByTagName("correlativo_convenio")(0).InnerText)
                    ESTATUS = Trim(element.GetElementsByTagName("estatus")(0).InnerText)
                    VALIDO = CLng(element.GetElementsByTagName("valido")(0).InnerText)
                    TI_LIC = Trim(element.GetElementsByTagName("ti_lic")(0).InnerText)
                    TI_CON = Trim(element.GetElementsByTagName("ti_con")(0).InnerText)
                    TIPO_REAJUSTE = Trim(element.GetElementsByTagName("tipo_reajuste")(0).InnerText)
                    FECHA_LIC_PR = Trim(element.GetElementsByTagName("fecha_lic_pr")(0).InnerText)
                    FECHA_AP_ESTIMADA = Trim(element.GetElementsByTagName("fecha_ap_estimada")(0).InnerText)
                    FECHA_AP_PR = Trim(element.GetElementsByTagName("fecha_ap_pr")(0).InnerText)
                    FECHA_AP_PR_ECO = Trim(element.GetElementsByTagName("fecha_ap_pr_eco")(0).InnerText)
                    FECHA_INICIO_ESTIMADA = Trim(element.GetElementsByTagName("fecha_inicio_estimada")(0).InnerText)
                    BASES_ADMIN_GENERALES = Trim(element.GetElementsByTagName("bases_admin_generales")(0).InnerText)
                    BASES_ADMIN_ESPECIALES = Trim(element.GetElementsByTagName("bases_admin_especiales")(0).InnerText)
                    BASES_TECNICAS = Trim(element.GetElementsByTagName("bases_tecnicas")(0).InnerText)
                    CARPETA_TECNICA_LICITACION = Trim(element.GetElementsByTagName("carpeta_tecnica_licitacion")(0).InnerText)
                    REGISTRO = Trim(element.GetElementsByTagName("registro")(0).InnerText)
                    CATEGORIA = Trim(element.GetElementsByTagName("categoria")(0).InnerText)
                    MONTO_PROGRA = CDbl(element.GetElementsByTagName("monto_progra")(0).InnerText)
                    PLAZO_ESTIMADO_EJEC = CLng(element.GetElementsByTagName("plazo_estimado_ejec")(0).InnerText)
                    RESP_ANTECEDENTES_PPTA = Trim(element.GetElementsByTagName("resp_antecedentes_ppta")(0).InnerText)
                    ANTICIPO_CONTEMPLADO = CDbl(element.GetElementsByTagName("anticipo_contemplado")(0).InnerText)
                    ANTIC_CONTEMPL_PORC = CDbl(element.GetElementsByTagName("antic_contempl_porc")(0).InnerText)
                    APLICA_CARTILLA_R_26 = Trim(element.GetElementsByTagName("aplica_cartilla_r_26")(0).InnerText)
                    FECHA_DOCTO_R26 = Trim(element.GetElementsByTagName("fecha_docto_r26")(0).InnerText)
                    APLICA_CARTILLA_R_28 = Trim(element.GetElementsByTagName("aplica_cartilla_r_28")(0).InnerText)
                    FECHA_DOCTO_R28 = Trim(element.GetElementsByTagName("fecha_docto_r28")(0).InnerText)
                    APLICA_CARTILLA_R_29 = Trim(element.GetElementsByTagName("aplica_cartilla_r_29")(0).InnerText)
                    FECHA_DOCTO_R29 = Trim(element.GetElementsByTagName("fecha_docto_r29")(0).InnerText)
                    REQUIERE_REG_ESPECIAL = Trim(element.GetElementsByTagName("requiere_reg_especial")(0).InnerText)
                    N_PERMISO_EDIFICACION = Trim(element.GetElementsByTagName("n_permiso_edificacion")(0).InnerText)
                    FECHA_PERMISO_EDIFICACION = Trim(element.GetElementsByTagName("fecha_permiso_edificacion")(0).InnerText)
                    id_chile_compra = Trim(element.GetElementsByTagName("id_chile_compra")(0).InnerText)

                    ces = Trim(element.GetElementsByTagName("ces")(0).InnerText)

                    N_DOCTO_R5 = CDbl(element.GetElementsByTagName("n_docto_r5")(0).InnerText)
                    FECHA_DOCTO_R5 = Trim(element.GetElementsByTagName("fecha_docto_r5")(0).InnerText)
                    FECHA_LIC = Trim(element.GetElementsByTagName("fecha_lic")(0).InnerText)
                    F_AP_TECNICA_PROP = Trim(element.GetElementsByTagName("f_ap_tecnica_prop")(0).InnerText)
                    F_AP_PROP = Trim(element.GetElementsByTagName("f_ap_prop")(0).InnerText)
                    PLAZO_OFICIAL = CLng(element.GetElementsByTagName("plazo_oficial")(0).InnerText)
                    MT_OFI = CDbl(element.GetElementsByTagName("mt_ofi")(0).InnerText)
                    OBSERVACIONES_PROP = Trim(element.GetElementsByTagName("observaciones_prop")(0).InnerText)
                    RESULTADO_PROPUESTA = Trim(element.GetElementsByTagName("resultado_propuesta")(0).InnerText)
                    RESP_LCITACION = Trim(element.GetElementsByTagName("resp_lcitacion")(0).InnerText)
                    LLAMADO = CDbl(element.GetElementsByTagName("llamado")(0).InnerText)
                    n_res_no_adjudica = CDbl(element.GetElementsByTagName("n_res_no_adjudica")(0).InnerText)
                    f_res_no_adjudica = Trim(element.GetElementsByTagName("f_res_no_adjudica")(0).InnerText)
                    FECHA_INFORME_ADJUDICACION = Trim(element.GetElementsByTagName("fecha_informe_adjudicacion")(0).InnerText)
                    MTO_OR = CDbl(element.GetElementsByTagName("mto_or")(0).InnerText)
                    PLAZO_OR = CDbl(element.GetElementsByTagName("plazo_or")(0).InnerText)
                    OR_RES = Trim(element.GetElementsByTagName("or_res")(0).InnerText)
                    N_RES = CLng(element.GetElementsByTagName("n_res")(0).InnerText)
                    F_RES = Trim(element.GetElementsByTagName("f_res")(0).InnerText)
                    F_TRAMI = Trim(element.GetElementsByTagName("f_trami")(0).InnerText)
                    RUT_CON = Trim(element.GetElementsByTagName("rut_con")(0).InnerText)
                    COM_EVAL_OFERTA1 = Trim(element.GetElementsByTagName("com_eval_oferta1")(0).InnerText)
                    COM_EVAL_OFERTA2 = Trim(element.GetElementsByTagName("com_eval_oferta2")(0).InnerText)
                    COM_EVAL_OFERTA3 = Trim(element.GetElementsByTagName("com_eval_oferta3")(0).InnerText)
                    adjudicado = Trim(element.GetElementsByTagName("adjudicado")(0).InnerText)
                    SECCION = Trim(element.GetElementsByTagName("seccion")(0).InnerText)


                Next

                If REGION = "" Then Throw New Exception("region")
                If CODIGO_DA = "" Then Throw New Exception("codigo_da")
                If SUFIJO = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_SetGrabaProceso_ssd(ByVal result As String, _
                                                   ByRef accion As String, _
                                                   ByRef tipo As String, _
                                                   ByRef cod_con As String, _
                                                   ByRef sufijo As String, _
                                                   ByRef codigo_da As String, _
                                                   ByRef region As String, _
                                                   ByRef numero_proceso As String, _
                                                   ByRef descripcion As String _
                                                   ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaProceso_ssd.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    tipo = Trim(element.GetElementsByTagName("tipo")(0).InnerText)
                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    numero_proceso = Trim(element.GetElementsByTagName("numero_proceso")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If numero_proceso = "" Then Throw New Exception("numero_proceso")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_GetBuscaProceso_ssd(ByVal result As String, _
                                                   ByRef tipo As String, _
                                                   ByRef cod_con As String, _
                                                   ByRef sufijo As String, _
                                                   ByRef codigo_da As String, _
                                                   ByRef region As String _
                                                   ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaProceso_ssd.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    tipo = Trim(element.GetElementsByTagName("tipo")(0).InnerText)
                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If numero_proceso = "" Then Throw New Exception("numero_proceso")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121128
        Public Function Valida_GetBuscaDomTiposEtapa(ByVal result As String, _
                                                     ByRef typologia As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBuscaDomTiposEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    typologia = Trim(element.GetElementsByTagName("typologia")(0).InnerText)
                Next

                If typologia = "" Then Throw New Exception("typologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121128
        Public Function Valida_SetGrabaEtapa(ByVal result As String, _
                                             ByRef region As String _
                                            , ByRef codigo_da As String _
                                            , ByRef etapa As String _
                                            , ByRef codigo_bip As String _
                                            , ByRef parte As String _
                                            , ByRef monto_etapa As Double _
                                            , ByRef descripcion As String _
                                            , ByRef fecha_ingreso As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                    codigo_bip = Trim(element.GetElementsByTagName("codigo_bip")(0).InnerText)
                    parte = Trim(element.GetElementsByTagName("parte")(0).InnerText)
                    monto_etapa = CDbl(element.GetElementsByTagName("monto_etapa")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_SetGrabaConvenio(ByVal result As String, _
                                                ByRef region As String _
                                                , ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef correlativo As Long _
                                                , ByRef etapa As String _
                                                , ByRef num_decreto As Long _
                                                , ByRef fecha_decreto As String _
                                                , ByRef tipo_convenio As String _
                                                , ByRef fecha_convenio As String _
                                                , ByRef monto_neto As Double _
                                                , ByRef gastos_administrativos As Double _
                                                , ByRef consul As Double _
                                                , ByRef descripcion As String _
                                                , ByRef fecha_ingreso As String _
                                                , ByRef estado_convenio As String _
                                                , ByRef observacion As String _
                                                , ByRef fecha_liquidacion As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaConvenio.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = CLng(element.GetElementsByTagName("correlativo")(0).InnerText)
                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                    num_decreto = CLng(element.GetElementsByTagName("num_decreto")(0).InnerText)
                    fecha_decreto = Trim(element.GetElementsByTagName("fecha_decreto")(0).InnerText)
                    tipo_convenio = Trim(element.GetElementsByTagName("tipo_convenio")(0).InnerText)
                    fecha_convenio = Trim(element.GetElementsByTagName("fecha_convenio")(0).InnerText)
                    monto_neto = CDbl(element.GetElementsByTagName("monto_neto")(0).InnerText)
                    gastos_administrativos = CDbl(element.GetElementsByTagName("gastos_administrativos")(0).InnerText)
                    consul = CDbl(element.GetElementsByTagName("consul")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                    estado_convenio = Trim(element.GetElementsByTagName("estado_convenio")(0).InnerText)
                    observacion = Trim(element.GetElementsByTagName("observacion")(0).InnerText)
                    fecha_liquidacion = Trim(element.GetElementsByTagName("fecha_liquidacion ")(0).InnerText)

                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If mandante = "" Then Throw New Exception("mandante")
                If correlativo = 0 Then Throw New Exception("correlativo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_SetGrabaDetalleProyecto(ByVal result As String, _
                                                      ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef plan As Long _
                                                    , ByRef proceso As String _
                                                    , ByRef objeto As String _
                                                    , ByRef codigo_bip As String _
                                                    , ByRef monto_estimado_idea As Double _
                                                    , ByRef responsable_idea As String _
                                                    , ByRef responsable_convenio As String _
                                                    , ByRef parte_bip As String _
                                                    , ByRef provincia As String _
                                                    , ByRef comuna As String _
                                                    , ByRef ubicacion As String _
                                                    , ByRef terreno_numero_certif As Long _
                                                    , ByRef terreno_fecha_certificado As String _
                                                    , ByRef descripcion_proyecto As String _
                                                    , ByRef factibilidad_electrica As Integer _
                                                    , ByRef factibilidad_agua As Integer _
                                                    , ByRef factibilidad_alcantarillado As Integer _
                                                    , ByRef condiciones_tecnicas As String _
                                                    , ByRef terreno_observaciones As String _
                                                    , ByRef sector_destino As String _
                                                    , ByRef sub_sector As String _
                                                    , ByRef tipologia As String _
                                                    , ByRef fecha_estado As String _
                                                    , ByRef estado As String _
                                                    , ByRef tipo_proy As String _
                                                    , ByRef fecha_evaluacion As String _
                                                    , ByRef monto_estimado As Double _
                                                    , ByRef beneficio As String _
                                                    , ByRef propiedad As String _
                                                    , ByRef superficie As Double _
                                                    , ByRef programa_inicial As Double _
                                                    , ByRef programa_final As Double _
                                                    , ByRef m2_arquitectura As Double _
                                                    , ByRef profesional_arquitectura As String _
                                                    , ByRef m2_ingenieria As Double _
                                                    , ByRef profesional_ingenieria As String _
                                                    , ByRef obras_complementarias As Integer _
                                                    , ByRef fecha_ingreso As String _
                                                    , ByRef fecha_termino_proyecto As String _
                                                    , ByRef fecha_liquidacion_proyecto As String _
                                                    , ByRef coordenadas As String _
                                                    , ByRef usuarios As Long _
                                                    , ByRef beneficiarios As Long _
                                                    , ByRef patrimonial As String _
                                                    , ByRef oficio_apoyo As String _
                                                    , ByRef fecha_oficio_apoyo As String _
                                                    , ByRef f_i_a_t As String _
                                                    , ByRef f_t_a_t_estimada As String _
                                                    , ByRef f_t_a_t As String _
                                                    , ByRef resp_at As String _
                                                    , ByRef producto As String _
                                                    , ByRef fondo As String _
                                                    , ByRef f_hito As String _
                                                    , ByRef seguimiento_p As String _
                                                    , ByRef tipo_apoyo_tecnico As String _
                                                    , ByRef tipo_ase As Long _
                                                    , ByRef proteccion_patrimonial As String _
                                                    , ByRef material As Long _
                                                    , ByRef rate As String _
                                                    , ByRef etapa_idea As Long _
                                                    , ByRef codigo_proyecto_exp As String _
                                                    , ByRef fecha_est_firma_convenio As String _
                                                    , ByRef fecha_est_publicacion As String _
                                                    , ByRef fecha_est_inicio As String _
                                                    , ByRef fecha_est_termino As String _
                                                    , ByRef codigo_prigrh As String _
                                                    , ByRef modalidad As String _
                                                    , ByRef reajuste As String _
                                                    , ByRef ces As String _
                                        ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    plan = CLng(element.GetElementsByTagName("plan")(0).InnerText)
                    proceso = Trim(element.GetElementsByTagName("proceso")(0).InnerText)
                    objeto = Trim(element.GetElementsByTagName("objeto")(0).InnerText)
                    codigo_bip = Trim(element.GetElementsByTagName("codigo_bip")(0).InnerText)
                    'monto_estimado_idea = CDbl(element.GetElementsByTagName("monto_estimado_idea")(0).InnerText)
                    responsable_idea = Trim(element.GetElementsByTagName("responsable_idea")(0).InnerText)
                    responsable_convenio = Trim(element.GetElementsByTagName("responsable_convenio")(0).InnerText)
                    parte_bip = Trim(element.GetElementsByTagName("parte_bip")(0).InnerText)
                    provincia = Trim(element.GetElementsByTagName("provincia")(0).InnerText)
                    comuna = Trim(element.GetElementsByTagName("comuna")(0).InnerText)
                    ubicacion = Trim(element.GetElementsByTagName("ubicacion")(0).InnerText)
                    terreno_numero_certif = CLng(element.GetElementsByTagName("terreno_numero_certif")(0).InnerText)
                    terreno_fecha_certificado = Trim(element.GetElementsByTagName("terreno_fecha_certificado")(0).InnerText)
                    descripcion_proyecto = Trim(element.GetElementsByTagName("descripcion_proyecto")(0).InnerText)
                    factibilidad_electrica = Val(element.GetElementsByTagName("factibilidad_electrica")(0).InnerText)
                    factibilidad_agua = Val(element.GetElementsByTagName("factibilidad_agua")(0).InnerText)
                    factibilidad_alcantarillado = Val(element.GetElementsByTagName("factibilidad_alcantarillado")(0).InnerText)
                    condiciones_tecnicas = Trim(element.GetElementsByTagName("condiciones_tecnicas")(0).InnerText)
                    terreno_observaciones = Trim(element.GetElementsByTagName("terreno_observaciones")(0).InnerText)
                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)
                    sub_sector = Trim(element.GetElementsByTagName("sub_sector")(0).InnerText)
                    tipologia = Trim(element.GetElementsByTagName("tipologia")(0).InnerText)
                    fecha_estado = Trim(element.GetElementsByTagName("fecha_estado")(0).InnerText)
                    estado = Trim(element.GetElementsByTagName("estado")(0).InnerText)
                    tipo_proy = Trim(element.GetElementsByTagName("tipo_proy")(0).InnerText)
                    fecha_evaluacion = Trim(element.GetElementsByTagName("fecha_evaluacion")(0).InnerText)
                    monto_estimado = CDbl(element.GetElementsByTagName("monto_estimado")(0).InnerText)
                    beneficio = Trim(element.GetElementsByTagName("beneficio")(0).InnerText)
                    propiedad = Trim(element.GetElementsByTagName("propiedad")(0).InnerText)
                    superficie = CDbl(element.GetElementsByTagName("superficie")(0).InnerText)
                    programa_inicial = CDbl(element.GetElementsByTagName("programa_inicial")(0).InnerText)
                    programa_final = CDbl(element.GetElementsByTagName("programa_final")(0).InnerText)
                    m2_arquitectura = Trim(element.GetElementsByTagName("m2_arquitectura")(0).InnerText)
                    profesional_arquitectura = Trim(element.GetElementsByTagName("profesional_arquitectura")(0).InnerText)
                    m2_ingenieria = CDbl(element.GetElementsByTagName("m2_ingenieria")(0).InnerText)
                    profesional_ingenieria = Trim(element.GetElementsByTagName("profesional_ingenieria")(0).InnerText)
                    obras_complementarias = Val(element.GetElementsByTagName("obras_complementarias")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                    fecha_termino_proyecto = Trim(element.GetElementsByTagName("fecha_termino_proyecto")(0).InnerText)
                    fecha_liquidacion_proyecto = Trim(element.GetElementsByTagName("fecha_liquidacion_proyecto")(0).InnerText)
                    coordenadas = Trim(element.GetElementsByTagName("coordenadas")(0).InnerText)
                    usuarios = CLng(element.GetElementsByTagName("usuarios")(0).InnerText)
                    beneficiarios = CLng(element.GetElementsByTagName("beneficiarios")(0).InnerText)
                    patrimonial = Trim(element.GetElementsByTagName("patrimonial")(0).InnerText)
                    oficio_apoyo = Trim(element.GetElementsByTagName("oficio_apoyo")(0).InnerText)
                    fecha_oficio_apoyo = Trim(element.GetElementsByTagName("fecha_oficio_apoyo")(0).InnerText)
                    f_i_a_t = Trim(element.GetElementsByTagName("f_i_a_t")(0).InnerText)
                    f_t_a_t_estimada = Trim(element.GetElementsByTagName("f_t_a_t_estimada")(0).InnerText)
                    f_t_a_t = Trim(element.GetElementsByTagName("f_t_a_t")(0).InnerText)
                    resp_at = Trim(element.GetElementsByTagName("resp_at")(0).InnerText)
                    producto = Trim(element.GetElementsByTagName("producto")(0).InnerText)
                    fondo = Trim(element.GetElementsByTagName("fondo")(0).InnerText)
                    f_hito = Trim(element.GetElementsByTagName("f_hito")(0).InnerText)
                    seguimiento_p = Trim(element.GetElementsByTagName("seguimiento_p")(0).InnerText)
                    tipo_apoyo_tecnico = Trim(element.GetElementsByTagName("tipo_apoyo_tecnico")(0).InnerText)
                    tipo_ase = CLng(element.GetElementsByTagName("tipo_ase")(0).InnerText)
                    proteccion_patrimonial = Trim(element.GetElementsByTagName("proteccion_patrimonial")(0).InnerText)
                    material = CLng(element.GetElementsByTagName("material")(0).InnerText)
                    rate = Trim(element.GetElementsByTagName("rate")(0).InnerText)
                    etapa_idea = CLng(element.GetElementsByTagName("etapa_idea")(0).InnerText)
                    codigo_proyecto_exp = Trim(element.GetElementsByTagName("codigo_proyecto_exp")(0).InnerText)
                    fecha_est_firma_convenio = Trim(element.GetElementsByTagName("fecha_est_firma_convenio")(0).InnerText)
                    fecha_est_publicacion = Trim(element.GetElementsByTagName("fecha_est_publicacion")(0).InnerText)
                    fecha_est_inicio = Trim(element.GetElementsByTagName("fecha_est_inicio")(0).InnerText)
                    fecha_est_termino = Trim(element.GetElementsByTagName("fecha_est_termino")(0).InnerText)
                    codigo_prigrh = Trim(element.GetElementsByTagName("codigo_prigrh")(0).InnerText)
                    modalidad = Trim(element.GetElementsByTagName("modalidad")(0).InnerText)
                    reajuste = Trim(element.GetElementsByTagName("reajuste")(0).InnerText)
                    ces = Trim(element.GetElementsByTagName("ces")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_GetBuscaConvenios(ByVal result As String, _
                                                 ByRef region As String, _
                                                 ByRef codigo_da As String, _
                                                 ByRef mandante As String, _
                                                 ByRef correlativo As Integer) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBuscaConvenios.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = Val(element.GetElementsByTagName("correlativo")(0).InnerText)
                Next

                'If region = "" Then Throw New Exception("region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")
                'If mandante = "" Then Throw New Exception("mandante")
                'If correlativo = "" Then Throw New Exception("correlativo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_GetBuscaDetalleProyecto(ByVal result As String, _
                                                       ByRef region As String, _
                                                       ByRef codigo_da As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBuscaDetalleProyecto.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121128
        Public Function Valida_SetGrabarConveniosModif(ByVal result As String, _
                                                      ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    , ByRef fecha_decreto As String _
                                                    , ByRef correlativo As Integer _
                                                    , ByRef num_decreto As Integer _
                                                    , ByRef fecha_convenio As String _
                                                    , ByRef fecha_ingreso As String _
                                                    , ByRef monto_neto_mod As Double _
                                                    , ByRef gasto_adm_mod As Double _
                                                    , ByRef consul_mod As Double _
                                                    , ByRef otros_gastos_mod As Double _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabarConveniosModif.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    fecha_decreto = Trim(element.GetElementsByTagName("fecha_decreto")(0).InnerText)
                    correlativo = Val(element.GetElementsByTagName("correlativo")(0).InnerText)
                    num_decreto = Val(element.GetElementsByTagName("num_decreto")(0).InnerText)
                    fecha_convenio = Trim(element.GetElementsByTagName("fecha_convenio")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                    monto_neto_mod = CDbl(element.GetElementsByTagName("monto_neto_mod")(0).InnerText)
                    gasto_adm_mod = CDbl(element.GetElementsByTagName("gasto_adm_mod")(0).InnerText)
                    consul_mod = CDbl(element.GetElementsByTagName("consul_mod")(0).InnerText)
                    otros_gastos_mod = CDbl(element.GetElementsByTagName("otros_gastos_mod")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")
                'If codigo_da = "" Then Throw New Exception("codigo_da")
                'If mandante = "" Then Throw New Exception("mandante")
                'If fecha_decreto = "" Then Throw New Exception("fecha_decreto")
                'If correlativo = "" Then Throw New Exception("correlativo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121129
        Public Function Valida_GetBuscaEtapa(ByVal result As String, _
                                              ByRef region As String _
                                            , ByRef codigo_da As String) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBuscaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'JGM 20121128
        Public Function Valida_GetBuscaConveniosModif(ByVal result As String, _
                                                      ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBuscaConveniosModif.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)

                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If mandante = "" Then Throw New Exception("mandante")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetEliminaMandantesProyecto(ByVal result As String, _
                                                      ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetEliminaMandantesProyecto.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If mandante = "" Then Throw New Exception("mandante")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGrabaMandantesProyecto(ByVal result As String, _
                                                      ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaMandantesProyecto.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If mandante = "" Then Throw New Exception("mandante")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


#End Region

#Region "Eventos"
        Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
            Throw New Exception(e.Message)
        End Sub
#End Region

#Region "Metodos Nuevos JQ"

        Public Function Valida_GetBusca_contratos_detalle_avance_fisico(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_contratos_detalle_avance_fisico_suma(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico_suma.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_edita_contrato(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_edita_contrato.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_contratos_detalle_estado_pago(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef num_epago As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                ' xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If num_epago = "" Then Throw New Exception("num_epago")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_garantias(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_imputacion_presup(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_inspector_fiscal(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If rut = "" Then Throw New Exception("rut")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_modificacion_contrato(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_programacion_financ(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_detalle_programacion_financ_suma(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Agregada para buscar datos de programación tentativa de propuesta, creado el 08-04-2015 por Alexi Rodriguez B.
        Public Function Valida_GetBusca_programacion_tentativa_propuesta_financ(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Agregada para buscar datos de sumatoria de programación tentativa de propuesta, creado el 08-04-2015 por Alexi Rodriguez B.
        Public Function Valida_GetBusca_programacion_tentativa_propuesta_financ_suma(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try


                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function
        Public Function Valida_GetBusca_contratos_detalle_termino(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_contratos_resumen_edita_contrato(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_resumen_edita_contrato.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_correlativo_convenios_relacionados_edita(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_dom_insp_fis(ByVal result As String, _
                                                                                ByRef rut As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    rut = Trim(element.GetElementsByTagName("rut")(0).InnerText)

                Next

                'If rut = "" Then Throw New Exception("rut")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetCancela_contratos_detalle_termino(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetElimina_contratos_detalle_avance_fisico(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If llave = "" Then Throw New Exception("llave")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetElimina_contratos_detalle_estado_pago(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef num_epago As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If num_epago = "" Then Throw New Exception("num_epago")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetElimina_contratos_detalle_imputacion_presup(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String, _
                                                                                ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If llave = "" Then Throw New Exception("llave")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetElimina_contratos_detalle_inspector_fiscal(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef rut As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    rut = Trim(element.GetElementsByTagName("rut")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If rut = "" Then Throw New Exception("rut")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetEliminar_contratos_detalle_programacion_financ(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String, _
                                                                                ByRef agno As String, _
                                                                                ByRef mes As String, _
                                                                                ByRef monto_vig As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    mes = Trim(element.GetElementsByTagName("mes")(0).InnerText)
                    monto_vig = Trim(element.GetElementsByTagName("monto_vig")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If agno = "" Then Throw New Exception("agno")
                'If mes = "" Then Throw New Exception("mes")
                'If monto_vig = "" Then Throw New Exception("monto_vig")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_avance_fisico(ByVal result As String, _
                                                                            ByRef cod_con As String, _
                                                                            ByRef agno As String, _
                                                                            ByRef mes As String, _
                                                                            ByRef av_fis_pr As String, _
                                                                            ByRef av_fis_acum As String, _
                                                                            ByRef fecha_medicion As String, _
                                                                            ByRef av_fis_re As String, _
                                                                            ByRef mano_de_obra_calificada As String, _
                                                                            ByRef mano_de_obra_semi_calificada As String, _
                                                                            ByRef mano_de_obra_no_calificada As String, _
                                                                            ByRef observ As String, _
                                                                            ByRef llave As String, _
                                                                            ByRef av_fis_act As String _
                                                                               ) As Boolean


            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    mes = Trim(element.GetElementsByTagName("mes")(0).InnerText)
                    av_fis_pr = Trim(element.GetElementsByTagName("av_fis_pr")(0).InnerText)
                    av_fis_acum = Trim(element.GetElementsByTagName("av_fis_acum")(0).InnerText)
                    fecha_medicion = Trim(element.GetElementsByTagName("fecha_medicion")(0).InnerText)
                    av_fis_re = Trim(element.GetElementsByTagName("av_fis_re")(0).InnerText)
                    mano_de_obra_calificada = Trim(element.GetElementsByTagName("mano_de_obra_calificada")(0).InnerText)
                    mano_de_obra_semi_calificada = Trim(element.GetElementsByTagName("mano_de_obra_semi_calificada")(0).InnerText)
                    mano_de_obra_no_calificada = Trim(element.GetElementsByTagName("mano_de_obra_no_calificada")(0).InnerText)
                    observ = Trim(element.GetElementsByTagName("observ")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)
                    av_fis_act = Trim(element.GetElementsByTagName("av_fis_act")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If agno = "" Then Throw New Exception("agno")
                'If mes = "" Then Throw New Exception("mes")
                'If av_fis_pr = "" Then Throw New Exception("av_fis_pr")
                'If av_fis_acum = "" Then Throw New Exception("av_fis_acum")
                'If fecha_medicion = "" Then Throw New Exception("fecha_medicion")
                'If av_fis_re = "" Then Throw New Exception("av_fis_re")
                'If mano_de_obra_calificada = "" Then Throw New Exception("mano_de_obra_calificada")
                'If mano_de_obra_semi_calificada = "" Then Throw New Exception("mano_de_obra_semi_calificada")
                'If mano_de_obra_no_calificada = "" Then Throw New Exception("mano_de_obra_no_calificada")
                'If observ = "" Then Throw New Exception("observ")
                'If llave = "" Then Throw New Exception("llave")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_contratos(ByVal result As String, _
                                                                    ByRef codigo_pia As String, _
                                                                    ByRef codigo_region As String, _
                                                                    ByRef sufijo As String, _
                                                                    ByRef m2 As Double, _
                                                                    ByRef desc_contrato As String, _
                                                                    ByRef fechainiciolegal As String, _
                                                                    ByRef fechaentregaterreno As String, _
                                                                    ByRef plazonocomputable As String, _
                                                                    ByRef obsrelcontrato As String, _
                                                                    ByRef usuario As String, _
                                                                    ByRef libro As String _
                                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGraba_contratos_detalle_contratos.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    m2 = Trim(element.GetElementsByTagName("m2")(0).InnerText)
                    desc_contrato = Trim(element.GetElementsByTagName("desc_contrato")(0).InnerText)
                    fechainiciolegal = Trim(element.GetElementsByTagName("fechainiciolegal")(0).InnerText)
                    fechaentregaterreno = Trim(element.GetElementsByTagName("fechaentregaterreno")(0).InnerText)
                    plazonocomputable = Trim(element.GetElementsByTagName("plazonocomputable")(0).InnerText)
                    obsrelcontrato = Trim(element.GetElementsByTagName("obsrelcontrato")(0).InnerText)
                    usuario = Trim(element.GetElementsByTagName("usuario")(0).InnerText)
                    libro = Trim(element.GetElementsByTagName("libro")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If m2 = "" Then Throw New Exception("m2")
                'If desc_contrato = "" Then Throw New Exception("desc_contrato")
                'If fechainiciolegal = "" Then Throw New Exception("fechainiciolegal")
                'If fechaentregaterreno = "" Then Throw New Exception("fechaentregaterreno")
                'If plazonocomputable = "" Then Throw New Exception("plazonocomputable")
                'If obsrelcontrato = "" Then Throw New Exception("obsrelcontrato")
                'If usuario = "" Then Throw New Exception("usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_garantias(ByVal result As String, _
                                                                    ByRef cod_con As String, _
                                                                    ByRef cod_tipo As String, _
                                                                    ByRef entidad_financiera As String, _
                                                                    ByRef numero As String, _
                                                                    ByRef fecha As String, _
                                                                    ByRef fecha_vencimiento_inicial As String, _
                                                                    ByRef fecha_vencimiento As String, _
                                                                    ByRef monto As String, _
                                                                    ByRef tipo_moneda As String, _
                                                                    ByRef num_oficio_destino_documento As String, _
                                                                    ByRef fecha_oficio_destino_documento As String, _
                                                                    ByRef entidad_que_custodia As String, _
                                                                    ByRef num_oficio_solicitud_garantia As String, _
                                                                    ByRef fecha_oficio_solicitud_garantia As String, _
                                                                    ByRef fecha_devolucion_garantia As String, _
                                                                    ByRef tipo_de_documento As String, _
                                                                    ByRef devuelta As String, _
                                                                    ByRef fecha_prorroga As String, _
                                                                    ByRef fecha_nuevo_vencimiento As String, _
                                                                    ByRef dias As String, _
                                                                    ByRef llave As String _
                                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    cod_tipo = Trim(element.GetElementsByTagName("cod_tipo")(0).InnerText)
                    entidad_financiera = Trim(element.GetElementsByTagName("entidad_financiera")(0).InnerText)
                    numero = Trim(element.GetElementsByTagName("numero")(0).InnerText)
                    fecha = Trim(element.GetElementsByTagName("fecha")(0).InnerText)
                    fecha_vencimiento_inicial = Trim(element.GetElementsByTagName("fecha_vencimiento_inicial")(0).InnerText)
                    fecha_vencimiento = Trim(element.GetElementsByTagName("fecha_vencimiento")(0).InnerText)
                    monto = Trim(element.GetElementsByTagName("monto")(0).InnerText)
                    tipo_moneda = Trim(element.GetElementsByTagName("tipo_moneda")(0).InnerText)
                    num_oficio_destino_documento = Trim(element.GetElementsByTagName("num_oficio_destino_documento")(0).InnerText)
                    fecha_oficio_destino_documento = Trim(element.GetElementsByTagName("fecha_oficio_destino_documento")(0).InnerText)
                    entidad_que_custodia = Trim(element.GetElementsByTagName("entidad_que_custodia")(0).InnerText)
                    num_oficio_solicitud_garantia = Trim(element.GetElementsByTagName("num_oficio_solicitud_garantia")(0).InnerText)
                    fecha_oficio_solicitud_garantia = Trim(element.GetElementsByTagName("fecha_oficio_solicitud_garantia")(0).InnerText)
                    fecha_devolucion_garantia = Trim(element.GetElementsByTagName("fecha_devolucion_garantia")(0).InnerText)
                    tipo_de_documento = Trim(element.GetElementsByTagName("tipo_de_documento")(0).InnerText)
                    devuelta = Trim(element.GetElementsByTagName("devuelta")(0).InnerText)
                    fecha_prorroga = Trim(element.GetElementsByTagName("fecha_prorroga")(0).InnerText)
                    fecha_nuevo_vencimiento = Trim(element.GetElementsByTagName("fecha_nuevo_vencimiento")(0).InnerText)
                    dias = Trim(element.GetElementsByTagName("dias")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If cod_tipo = "" Then Throw New Exception("cod_tipo")
                'If entidad_financiera = "" Then Throw New Exception("entidad_financiera")
                'If numero = "" Then Throw New Exception("numero")
                'If fecha = "" Then Throw New Exception("fecha")
                'If fecha_vencimiento_inicial = "" Then Throw New Exception("fecha_vencimiento_inicial")
                'If fecha_vencimiento = "" Then Throw New Exception("fecha_vencimiento")
                'If monto = "" Then Throw New Exception("monto")
                'If tipo_moneda = "" Then Throw New Exception("tipo_moneda")
                'If num_oficio_destino_documento = "" Then Throw New Exception("num_oficio_destino_documento")
                'If fecha_oficio_destino_documento = "" Then Throw New Exception("fecha_oficio_destino_documento")
                'If entidad_que_custodia = "" Then Throw New Exception("entidad_que_custodia")
                'If num_oficio_solicitud_garantia = "" Then Throw New Exception("num_oficio_solicitud_garantia")
                'If fecha_oficio_solicitud_garantia = "" Then Throw New Exception("fecha_oficio_solicitud_garantia")
                'If fecha_devolucion_garantia = "" Then Throw New Exception("fecha_devolucion_garantia")
                'If tipo_de_documento = "" Then Throw New Exception("tipo_de_documento")
                'If devuelta = "" Then Throw New Exception("devuelta")
                'If fecha_prorroga = "" Then Throw New Exception("fecha_prorroga")
                'If fecha_nuevo_vencimiento = "" Then Throw New Exception("fecha_nuevo_vencimiento")
                'If dias = "" Then Throw New Exception("dias")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_imputacion_presup(ByVal result As String, _
                                                                            ByRef codigo_pia As String, _
                                                                            ByRef codigo_region As String, _
                                                                            ByRef sufijo As String, _
                                                                            ByRef ano As String, _
                                                                            ByRef mandante As String, _
                                                                            ByRef tipofondo As String, _
                                                                            ByRef resorig As String, _
                                                                            ByRef numerores As String, _
                                                                            ByRef fechares As String, _
                                                                            ByRef subt As String, _
                                                                            ByRef it As String, _
                                                                            ByRef asig As String, _
                                                                            ByRef montoimputado As String, _
                                                                            ByRef codigo_contrato As String, _
                                                                            ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    ano = Trim(element.GetElementsByTagName("ano")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    tipofondo = Trim(element.GetElementsByTagName("tipofondo")(0).InnerText)
                    resorig = Trim(element.GetElementsByTagName("resorig")(0).InnerText)
                    numerores = Trim(element.GetElementsByTagName("numerores")(0).InnerText)
                    fechares = Trim(element.GetElementsByTagName("fechares")(0).InnerText)
                    subt = Trim(element.GetElementsByTagName("subt")(0).InnerText)
                    it = Trim(element.GetElementsByTagName("it")(0).InnerText)
                    asig = Trim(element.GetElementsByTagName("asig")(0).InnerText)
                    montoimputado = Trim(element.GetElementsByTagName("montoimputado")(0).InnerText)
                    codigo_contrato = Trim(element.GetElementsByTagName("codigo_contrato")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If ano = "" Then Throw New Exception("ano")
                'If mandante = "" Then Throw New Exception("mandante")
                'If tipofondo = "" Then Throw New Exception("tipofondo")
                'If resorig = "" Then Throw New Exception("resorig")
                'If numerores = "" Then Throw New Exception("numerores")
                'If fechares = "" Then Throw New Exception("fechares")
                'If subt = "" Then Throw New Exception("subt")
                'If it = "" Then Throw New Exception("it")
                'If asig = "" Then Throw New Exception("asig")
                'If montoimputado = "" Then Throw New Exception("montoimputado")
                'If codigo_contrato = "" Then Throw New Exception("codigo_contrato")
                'If llave = "" Then Throw New Exception("llave")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_inspector_fiscal(ByVal result As String, _
                                                                            ByRef cod_con As String, _
                                                                            ByRef rut As String, _
                                                                            ByRef n_res As String, _
                                                                            ByRef f_resol As String, _
                                                                            ByRef titularsn As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    rut = Trim(element.GetElementsByTagName("rut")(0).InnerText)
                    n_res = Trim(element.GetElementsByTagName("n_res")(0).InnerText)
                    f_resol = Trim(element.GetElementsByTagName("f_resol")(0).InnerText)
                    titularsn = Trim(element.GetElementsByTagName("titularsn")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If rut = "" Then Throw New Exception("rut")
                'If n_res = "" Then Throw New Exception("n_res")
                'If f_resol = "" Then Throw New Exception("f_resol")
                'If titularsn = "" Then Throw New Exception("titularsn")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGraba_contratos_detalle_modificacion_contrato(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef tipo_modif_ctto As String, _
                                                                                ByRef n_docto_solicitud_mod As String, _
                                                                                ByRef f_solicitud_mod As String, _
                                                                                ByRef var_mto As String, _
                                                                                ByRef var_pzo As String, _
                                                                                ByRef var_tamagno As String, _
                                                                                ByRef n_docto_resp_solicitud_mod As String, _
                                                                                ByRef f_resp_solicitud_mod As String, _
                                                                                ByRef or_res As String, _
                                                                                ByRef n_res As String, _
                                                                                ByRef f_res As String, _
                                                                                ByRef f_tramite As String, _
                                                                                ByRef motivo As String, _
                                                                                ByRef r_nueva_boleta As String, _
                                                                                ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    tipo_modif_ctto = Trim(element.GetElementsByTagName("tipo_modif_ctto")(0).InnerText)
                    n_docto_solicitud_mod = Trim(element.GetElementsByTagName("n_docto_solicitud_mod")(0).InnerText)
                    f_solicitud_mod = Trim(element.GetElementsByTagName("f_solicitud_mod")(0).InnerText)
                    var_mto = Trim(element.GetElementsByTagName("var_mto")(0).InnerText)
                    var_pzo = Trim(element.GetElementsByTagName("var_pzo")(0).InnerText)
                    var_tamagno = Trim(element.GetElementsByTagName("var_tamagno")(0).InnerText)
                    n_docto_resp_solicitud_mod = Trim(element.GetElementsByTagName("n_docto_resp_solicitud_mod")(0).InnerText)
                    f_resp_solicitud_mod = Trim(element.GetElementsByTagName("f_resp_solicitud_mod")(0).InnerText)
                    or_res = Trim(element.GetElementsByTagName("or_res")(0).InnerText)
                    n_res = Trim(element.GetElementsByTagName("n_res")(0).InnerText)
                    f_res = Trim(element.GetElementsByTagName("f_res")(0).InnerText)
                    f_tramite = Trim(element.GetElementsByTagName("f_tramite")(0).InnerText)
                    motivo = Trim(element.GetElementsByTagName("motivo")(0).InnerText)
                    r_nueva_boleta = Trim(element.GetElementsByTagName("r_nueva_boleta")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)


                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If tipo_modif_ctto = "" Then Throw New Exception("tipo_modif_ctto")
                'If n_docto_solicitud_mod = "" Then Throw New Exception("n_docto_solicitud_mod")
                'If f_solicitud_mod = "" Then Throw New Exception("f_solicitud_mod")
                'If var_mto = "" Then Throw New Exception("var_mto")
                'If var_pzo = "" Then Throw New Exception("var_pzo")
                'If var_tamagno = "" Then Throw New Exception("var_tamagno")
                'If n_docto_resp_solicitud_mod = "" Then Throw New Exception("n_docto_resp_solicitud_mod")
                'If f_resp_solicitud_mod = "" Then Throw New Exception("f_resp_solicitud_mod")
                'If or_res = "" Then Throw New Exception("or_res")
                'If n_res = "" Then Throw New Exception("n_res")
                'If f_res = "" Then Throw New Exception("f_res")
                'If f_tramite = "" Then Throw New Exception("f_tramite")
                'If motivo = "" Then Throw New Exception("motivo")
                'If r_nueva_boleta = "" Then Throw New Exception("r_nueva_boleta")
                'If llave = "" Then Throw New Exception("llave")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetElimina_contratos_detalle_modificacion_contrato(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef llave As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    llave = Trim(element.GetElementsByTagName("llave")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_contratos_detalle_nuevo(ByVal result As String, _
                                                                    ByRef codigo_pia As String, _
                                                                    ByRef codigo_region As String, _
                                                                    ByRef numcorrelativo_convenio As String, _
                                                                    ByRef strmandante_convenio As String, _
                                                                    ByRef stretapa As String, _
                                                                    ByRef strtipo_proceso As String, _
                                                                    ByRef strfinanciamiento As String, _
                                                                    ByRef strobjeto As String, _
                                                                    ByRef cod_con As String, _
                                                                    ByRef estatus As String _
                                                                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    numcorrelativo_convenio = Trim(element.GetElementsByTagName("numcorrelativo_convenio")(0).InnerText)
                    strmandante_convenio = Trim(element.GetElementsByTagName("strmandante_convenio")(0).InnerText)
                    stretapa = Trim(element.GetElementsByTagName("stretapa")(0).InnerText)
                    strtipo_proceso = Trim(element.GetElementsByTagName("strtipo_proceso")(0).InnerText)
                    strfinanciamiento = Trim(element.GetElementsByTagName("strfinanciamiento")(0).InnerText)
                    strobjeto = Trim(element.GetElementsByTagName("strobjeto")(0).InnerText)
                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    estatus = Trim(element.GetElementsByTagName("estatus")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If numcorrelativo_convenio = "" Then Throw New Exception("numcorrelativo_convenio")
                'If strmandante_convenio = "" Then Throw New Exception("strmandante_convenio")
                'If stretapa = "" Then Throw New Exception("stretapa")
                'If strtipo_proceso = "" Then Throw New Exception("strtipo_proceso")
                'If strfinanciamiento = "" Then Throw New Exception("strfinanciamiento")
                'If strobjeto = "" Then Throw New Exception("strobjeto")
                'If cod_con = "" Then Throw New Exception("cod_con")
                'If estatus = "" Then Throw New Exception("estatus")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_contratos_detalle_programacion_financ(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String, _
                                                                                ByRef agno As String, _
                                                                                ByRef mes As String, _
                                                                                ByRef monto_prog As String, _
                                                                                ByRef monto_vig As String, _
                                                                                ByRef FONDO As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    mes = Trim(element.GetElementsByTagName("mes")(0).InnerText)
                    monto_prog = Trim(element.GetElementsByTagName("monto_prog")(0).InnerText)
                    monto_vig = Trim(element.GetElementsByTagName("monto_vig")(0).InnerText)
                    FONDO = Trim(element.GetElementsByTagName("fondo")(0).InnerText)
                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If agno = "" Then Throw New Exception("agno")
                'If mes = "" Then Throw New Exception("mes")
                'If monto_prog = "" Then Throw New Exception("monto_prog")
                'If monto_vig = "" Then Throw New Exception("monto_vig")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Agregada para Grabar datos de programación tentativa de propuesta, creado el 08-04-2015 por Alexi Rodriguez B.
        Public Function Valida_SetGraba_programacion_tentativa_propuesta_financ(ByVal result As String, _
                                                                                ByRef codigo_pia As String, _
                                                                                ByRef codigo_region As String, _
                                                                                ByRef sufijo As String, _
                                                                                ByRef agno As String, _
                                                                                ByRef mes As String, _
                                                                                ByRef monto_prop As String, _
                                                                                ByRef monto_vig As String, _
                                                                                ByRef MO_CALIFICADA As String, _
                                                                                ByRef MO_SEMI_CALIFICADA As String, _
                                                                                ByRef MO_NO_CALIFICADA As String, _
                                                                                ByRef FONDO As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    mes = Trim(element.GetElementsByTagName("mes")(0).InnerText)
                    monto_prop = Trim(element.GetElementsByTagName("monto_prop")(0).InnerText)
                    monto_vig = Trim(element.GetElementsByTagName("monto_vig")(0).InnerText)
                    MO_CALIFICADA = Trim(element.GetElementsByTagName("mo_calificada")(0).InnerText)
                    MO_SEMI_CALIFICADA = Trim(element.GetElementsByTagName("mo_semi_calificada")(0).InnerText)
                    MO_NO_CALIFICADA = Trim(element.GetElementsByTagName("mo_no_calificada")(0).InnerText)
                    FONDO = Trim(element.GetElementsByTagName("fondo")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Agregada para eliminar datos de programación tentativa de propuesta, creado el 08-04-2015 por Alexi Rodriguez B.
        Public Function Valida_SetEliminar_programacion_tentativa_propuesta_financ(ByVal result As String, _
                                                                        ByRef codigo_pia As String, _
                                                                        ByRef codigo_region As String, _
                                                                        ByRef sufijo As String, _
                                                                        ByRef agno As String, _
                                                                        ByRef mes As String, _
                                                                        ByRef monto_vig As String _
                                                                        ) As Boolean

            Dim IsValid As Boolean = False

            Try
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    mes = Trim(element.GetElementsByTagName("mes")(0).InnerText)
                    monto_vig = Trim(element.GetElementsByTagName("monto_vig")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_contratos_detalle_termino(ByVal result As String, _
                                                                    ByRef cod_con As String, _
                                                                    ByRef fecha_solic_recep_ctta As String, _
                                                                    ByRef fecha_termino_fisico_ito As String, _
                                                                    ByRef resp_termino As String, _
                                                                    ByRef n_res_liq_anticipada As String, _
                                                                    ByRef f_acta_recepcion_unica_liq As String, _
                                                                    ByRef f_res_liq_anticipada As String, _
                                                                    ByRef anticipada As String, _
                                                                    ByRef integrantes_com_ru As String, _
                                                                    ByRef integrantes_com_ru2 As String, _
                                                                    ByRef integrantes_com_ru3 As String, _
                                                                    ByRef n_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                                    ByRef f_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                                    ByRef n_res_com_rp As String, _
                                                                    ByRef f_res_com_rp As String, _
                                                                    ByRef f_inf_obs_rp As String, _
                                                                    ByRef f_r_p As String, _
                                                                    ByRef plz_obs_rp As String, _
                                                                    ByRef f_ter_real_rp As String, _
                                                                    ByRef integrantes_com_rp As String, _
                                                                    ByRef integrantes_com_rp2 As String, _
                                                                    ByRef integrantes_com_rp3 As String, _
                                                                    ByRef n_cerificado_recep_municipal As String, _
                                                                    ByRef f_cerificado_recep_municipal As String, _
                                                                    ByRef calific As String, _
                                                                    ByRef fecha_acta_entrega_explot As String, _
                                                                    ByRef mandatario_que_entrega As String, _
                                                                    ByRef mandante_que_recibe As String, _
                                                                    ByRef reservas As String, _
                                                                    ByRef plz_reservsas As String, _
                                                                    ByRef monto_reservas As String, _
                                                                    ByRef n_res_com_rd As String, _
                                                                    ByRef f_inf_obs_rd As String, _
                                                                    ByRef f_r_def As String, _
                                                                    ByRef f_res_com_rd As String, _
                                                                    ByRef plz_obs_rd As String, _
                                                                    ByRef integrantes_com_rd As String, _
                                                                    ByRef integrantes_com_rd2 As String, _
                                                                    ByRef integrantes_com_rd3 As String, _
                                                                    ByRef n_res_liquida As String, _
                                                                    ByRef f_res_liquida As String, _
                                                                    ByRef autoridad_liquida As String, _
                                                                    ByRef observacion_termino_contrato As String, _
                                                                    ByRef sufijo As String, _
                                                                    ByRef region As String, _
                                                                    ByRef codigo_da As String _
                                                                                ) As Boolean


            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    fecha_solic_recep_ctta = Trim(element.GetElementsByTagName("fecha_solic_recep_ctta")(0).InnerText)
                    fecha_termino_fisico_ito = Trim(element.GetElementsByTagName("fecha_termino_fisico_ito")(0).InnerText)
                    resp_termino = Trim(element.GetElementsByTagName("resp_termino")(0).InnerText)
                    n_res_liq_anticipada = Trim(element.GetElementsByTagName("n_res_liq_anticipada")(0).InnerText)
                    f_acta_recepcion_unica_liq = Trim(element.GetElementsByTagName("f_acta_recepcion_unica_liq")(0).InnerText)
                    f_res_liq_anticipada = Trim(element.GetElementsByTagName("f_res_liq_anticipada")(0).InnerText)
                    anticipada = Trim(element.GetElementsByTagName("anticipada")(0).InnerText)
                    integrantes_com_ru = Trim(element.GetElementsByTagName("integrantes_com_ru")(0).InnerText)
                    integrantes_com_ru2 = Trim(element.GetElementsByTagName("integrantes_com_ru2")(0).InnerText)
                    integrantes_com_ru3 = Trim(element.GetElementsByTagName("integrantes_com_ru3")(0).InnerText)
                    n_docto_aprueba_liquidacion_anticipada_obra = Trim(element.GetElementsByTagName("n_docto_aprueba_liquidacion_anticipada_obra")(0).InnerText)
                    f_docto_aprueba_liquidacion_anticipada_obra = Trim(element.GetElementsByTagName("f_docto_aprueba_liquidacion_anticipada_obra")(0).InnerText)
                    n_res_com_rp = Trim(element.GetElementsByTagName("n_res_com_rp")(0).InnerText)
                    f_res_com_rp = Trim(element.GetElementsByTagName("f_res_com_rp")(0).InnerText)
                    f_inf_obs_rp = Trim(element.GetElementsByTagName("f_inf_obs_rp")(0).InnerText)
                    f_r_p = Trim(element.GetElementsByTagName("f_r_p")(0).InnerText)
                    plz_obs_rp = Trim(element.GetElementsByTagName("plz_obs_rp")(0).InnerText)
                    f_ter_real_rp = Trim(element.GetElementsByTagName("f_ter_real_rp")(0).InnerText)
                    integrantes_com_rp = Trim(element.GetElementsByTagName("integrantes_com_rp")(0).InnerText)
                    integrantes_com_rp2 = Trim(element.GetElementsByTagName("integrantes_com_rp2")(0).InnerText)
                    integrantes_com_rp3 = Trim(element.GetElementsByTagName("integrantes_com_rp3")(0).InnerText)
                    n_cerificado_recep_municipal = Trim(element.GetElementsByTagName("n_cerificado_recep_municipal")(0).InnerText)
                    f_cerificado_recep_municipal = Trim(element.GetElementsByTagName("f_cerificado_recep_municipal")(0).InnerText)
                    calific = Trim(element.GetElementsByTagName("calific")(0).InnerText)
                    fecha_acta_entrega_explot = Trim(element.GetElementsByTagName("fecha_acta_entrega_explot")(0).InnerText)
                    mandatario_que_entrega = Trim(element.GetElementsByTagName("mandatario_que_entrega")(0).InnerText)
                    mandante_que_recibe = Trim(element.GetElementsByTagName("mandante_que_recibe")(0).InnerText)
                    reservas = Trim(element.GetElementsByTagName("reservas")(0).InnerText)
                    plz_reservsas = Trim(element.GetElementsByTagName("plz_reservsas")(0).InnerText)
                    monto_reservas = Trim(element.GetElementsByTagName("monto_reservas")(0).InnerText)
                    n_res_com_rd = Trim(element.GetElementsByTagName("n_res_com_rd")(0).InnerText)
                    f_inf_obs_rd = Trim(element.GetElementsByTagName("f_inf_obs_rd")(0).InnerText)
                    f_r_def = Trim(element.GetElementsByTagName("f_r_def")(0).InnerText)
                    f_res_com_rd = Trim(element.GetElementsByTagName("f_res_com_rd")(0).InnerText)
                    plz_obs_rd = Trim(element.GetElementsByTagName("plz_obs_rd")(0).InnerText)
                    integrantes_com_rd = Trim(element.GetElementsByTagName("integrantes_com_rd")(0).InnerText)
                    integrantes_com_rd2 = Trim(element.GetElementsByTagName("integrantes_com_rd2")(0).InnerText)
                    integrantes_com_rd3 = Trim(element.GetElementsByTagName("integrantes_com_rd3")(0).InnerText)
                    n_res_liquida = Trim(element.GetElementsByTagName("n_res_liquida")(0).InnerText)
                    f_res_liquida = Trim(element.GetElementsByTagName("f_res_liquida")(0).InnerText)
                    autoridad_liquida = Trim(element.GetElementsByTagName("autoridad_liquida")(0).InnerText)
                    observacion_termino_contrato = Trim(element.GetElementsByTagName("observacion_termino_contrato")(0).InnerText)

                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If fecha_solic_recep_ctta = "" Then Throw New Exception("fecha_solic_recep_ctta")
                'If fecha_termino_fisico_ito = "" Then Throw New Exception("fecha_termino_fisico_ito")
                'If resp_termino = "" Then Throw New Exception("resp_termino")
                'If n_res_liq_anticipada = "" Then Throw New Exception("n_res_liq_anticipada")
                'If f_acta_recepcion_unica_liq = "" Then Throw New Exception("f_acta_recepcion_unica_liq")
                'If f_res_liq_anticipada = "" Then Throw New Exception("f_res_liq_anticipada")
                'If anticipada = "" Then Throw New Exception("anticipada")
                'If integrantes_com_ru = "" Then Throw New Exception("integrantes_com_ru")
                'If integrantes_com_ru2 = "" Then Throw New Exception("integrantes_com_ru2")
                'If integrantes_com_ru3 = "" Then Throw New Exception("integrantes_com_ru3")
                'If n_docto_aprueba_liquidacion_anticipada_obra = "" Then Throw New Exception("n_docto_aprueba_liquidacion_anticipada_obra")
                'If f_docto_aprueba_liquidacion_anticipada_obra = "" Then Throw New Exception("f_docto_aprueba_liquidacion_anticipada_obra")
                'If n_res_com_rp = "" Then Throw New Exception("n_res_com_rp")
                'If f_res_com_rp = "" Then Throw New Exception("f_res_com_rp")
                'If f_inf_obs_rp = "" Then Throw New Exception("f_inf_obs_rp")
                'If f_r_p = "" Then Throw New Exception("f_r_p")
                'If plz_obs_rp = "" Then Throw New Exception("plz_obs_rp")
                'If f_ter_real_rp = "" Then Throw New Exception("f_ter_real_rp")
                'If integrantes_com_rp = "" Then Throw New Exception("integrantes_com_rp")
                'If integrantes_com_rp2 = "" Then Throw New Exception("integrantes_com_rp2")
                'If integrantes_com_rp3 = "" Then Throw New Exception("integrantes_com_rp3")
                'If n_cerificado_recep_municipal = "" Then Throw New Exception("n_cerificado_recep_municipal")
                'If f_cerificado_recep_municipal = "" Then Throw New Exception("f_cerificado_recep_municipal")
                'If calific = "" Then Throw New Exception("calific")
                'If fecha_acta_entrega_explot = "" Then Throw New Exception("fecha_acta_entrega_explot")
                'If mandatario_que_entrega = "" Then Throw New Exception("mandatario_que_entrega")
                'If mandante_que_recibe = "" Then Throw New Exception("mandante_que_recibe")
                'If reservas = "" Then Throw New Exception("reservas")
                'If plz_reservsas = "" Then Throw New Exception("plz_reservsas")
                'If monto_reservas = "" Then Throw New Exception("monto_reservas")
                'If n_res_com_rd = "" Then Throw New Exception("n_res_com_rd")
                'If f_inf_obs_rd = "" Then Throw New Exception("f_inf_obs_rd")
                'If f_r_def = "" Then Throw New Exception("f_r_def")
                'If f_res_com_rd = "" Then Throw New Exception("f_res_com_rd")
                'If plz_obs_rd = "" Then Throw New Exception("plz_obs_rd")
                'If integrantes_com_rd = "" Then Throw New Exception("integrantes_com_rd")
                'If integrantes_com_rd2 = "" Then Throw New Exception("integrantes_com_rd2")
                'If integrantes_com_rd3 = "" Then Throw New Exception("integrantes_com_rd3")
                'If n_res_liquida = "" Then Throw New Exception("n_res_liquida")
                'If f_res_liquida = "" Then Throw New Exception("f_res_liquida")
                'If autoridad_liquida = "" Then Throw New Exception("autoridad_liquida")
                'If observacion_termino_contrato = "" Then Throw New Exception("observacion_termino_contrato")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGrabar_contratos_detalle_estado_pago(ByVal result As String, _
                                                                        ByRef cod_con As String, _
                                                                        ByRef num_epago As String, _
                                                                        ByRef fecha_epago As String, _
                                                                        ByRef pag_ctto_matriz As String, _
                                                                        ByRef pag_mod_ctto As String, _
                                                                        ByRef pag_reaj As String, _
                                                                        ByRef pag_anticipo As String, _
                                                                        ByRef pag_canje_ret As String, _
                                                                        ByRef pag_devol_ret As String, _
                                                                        ByRef devol_anticipo As String, _
                                                                        ByRef reaj_devol_antic As String, _
                                                                        ByRef retenciones As String, _
                                                                        ByRef multas As String, _
                                                                        ByRef impuesto As String, _
                                                                        ByRef liquido_a_pagar As String, _
                                                                        ByRef valor_e_pago As String, _
                                                                        ByRef cargo_a_pres As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)
                    fecha_epago = Trim(element.GetElementsByTagName("fecha_epago")(0).InnerText)
                    pag_ctto_matriz = Trim(element.GetElementsByTagName("pag_ctto_matriz")(0).InnerText)
                    pag_mod_ctto = Trim(element.GetElementsByTagName("pag_mod_ctto")(0).InnerText)
                    pag_reaj = Trim(element.GetElementsByTagName("pag_reaj")(0).InnerText)
                    pag_anticipo = Trim(element.GetElementsByTagName("pag_anticipo")(0).InnerText)
                    pag_canje_ret = Trim(element.GetElementsByTagName("pag_canje_ret")(0).InnerText)
                    pag_devol_ret = Trim(element.GetElementsByTagName("pag_devol_ret")(0).InnerText)
                    devol_anticipo = Trim(element.GetElementsByTagName("devol_anticipo")(0).InnerText)
                    reaj_devol_antic = Trim(element.GetElementsByTagName("reaj_devol_antic")(0).InnerText)
                    retenciones = Trim(element.GetElementsByTagName("retenciones")(0).InnerText)
                    multas = Trim(element.GetElementsByTagName("multas")(0).InnerText)
                    impuesto = Trim(element.GetElementsByTagName("impuesto")(0).InnerText)

                    liquido_a_pagar = Trim(element.GetElementsByTagName("liquido_a_pagar")(0).InnerText)
                    valor_e_pago = Trim(element.GetElementsByTagName("valor_e_pago")(0).InnerText)
                    cargo_a_pres = Trim(element.GetElementsByTagName("cargo_a_pres")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")
                'If num_epago = "" Then Throw New Exception("num_epago")
                'If fecha_epago = "" Then Throw New Exception("fecha_epago")
                'If pag_ctto_matriz = "" Then Throw New Exception("pag_ctto_matriz")
                'If pag_mod_ctto = "" Then Throw New Exception("pag_mod_ctto")
                'If pag_reaj = "" Then Throw New Exception("pag_reaj")
                'If pag_anticipo = "" Then Throw New Exception("pag_anticipo")
                'If pag_canje_ret = "" Then Throw New Exception("pag_canje_ret")
                'If pag_devol_ret = "" Then Throw New Exception("pag_devol_ret")
                'If devol_anticipo = "" Then Throw New Exception("devol_anticipo")
                'If reaj_devol_antic = "" Then Throw New Exception("reaj_devol_antic")
                'If retenciones = "" Then Throw New Exception("retenciones")
                'If multas = "" Then Throw New Exception("multas")
                'If impuesto = "" Then Throw New Exception("impuesto")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetPryProcesosList(ByVal result As String, ByRef tipologia As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPryProcesosList.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    tipologia = Trim(element.GetElementsByTagName("tipologia")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetPry_procesos_list(ByVal result As String, _
                                                                                ByRef tipologia As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    tipologia = Trim(element.GetElementsByTagName("tipologia")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetSetup_grilla(ByVal result As String, _
                                                                                ByRef tipo_grilla As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    tipo_grilla = Trim(element.GetElementsByTagName("tipo_grilla")(0).InnerText)

                Next

                'If tipo_grilla = "" Then Throw New Exception("tipo_grilla")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Dom_Mandante(ByVal result As String, _
                                                       ByRef accion As String, _
                                                       ByRef sigla As String, _
                                                       ByRef descripcion As String _
                                                       ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = element.GetElementsByTagName("accion")(0).InnerText
                    sigla = element.GetElementsByTagName("sigla")(0).InnerText
                    descripcion = element.GetElementsByTagName("descripcion")(0).InnerText
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_Comunas_Sector(ByVal result As String, _
                                                        ByRef region As String, _
                                                        ByRef provincia As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Comunas_Sector.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    provincia = Trim(element.GetElementsByTagName("provincia")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_SubSector_Sector(ByVal result As String, _
                                                        ByRef sector_destino As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_SubSector_Sector.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_GetBusca_Tipologias_Sector(ByVal result As String, _
                                                        ByRef sector_destino As String, _
                                                        ByRef sub_sector As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Tipologias_Sector.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)
                    sub_sector = Trim(element.GetElementsByTagName("sub_sector")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_Get_llena_codigo_contratos_cartola_contratos(ByVal result As String, _
                                                        ByRef str_region_inicio As String, _
                                                        ByRef str_region_fin As String, _
                                                        ByRef str_fecha_inicio As String, _
                                                        ByRef str_fecha_fin As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Tipologias_Sector.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    str_region_inicio = Trim(element.GetElementsByTagName("str_region_inicio")(0).InnerText)
                    str_region_fin = Trim(element.GetElementsByTagName("str_region_fin")(0).InnerText)
                    str_fecha_inicio = Trim(element.GetElementsByTagName("str_fecha_inicio")(0).InnerText)
                    str_fecha_fin = Trim(element.GetElementsByTagName("str_fecha_fin")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_llena_codigo_contratos(ByVal result As String, _
                                                       ByRef str_region_inicio As String, _
                                                       ByRef str_region_fin As String, _
                                                       ByRef str_fecha_inicio As String, _
                                                       ByRef str_fecha_fin As String _
                                                                               ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Tipologias_Sector.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    str_region_inicio = Trim(element.GetElementsByTagName("str_region_inicio")(0).InnerText)
                    str_region_fin = Trim(element.GetElementsByTagName("str_region_fin")(0).InnerText)
                    str_fecha_inicio = Trim(element.GetElementsByTagName("str_fecha_inicio")(0).InnerText)
                    str_fecha_fin = Trim(element.GetElementsByTagName("str_fecha_fin")(0).InnerText)

                Next

                'If region = "" Then Throw New Exception("region")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_grabar_convenios_modif_proyecto(ByVal result As String _
                                                    , ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    , ByRef fecha_decreto As String _
                                                    , ByRef correlativo As String _
                                                    , ByRef num_decreto As String _
                                                    , ByRef fecha_convenio As String _
                                                    , ByRef fecha_ingreso As String _
                                                    , ByRef monto_neto_mod As String _
                                                    , ByRef gasto_adm_mod As String _
                                                    , ByRef consul_mod As String _
                                                    , ByRef otros_gastos_mod As String _
                                                       ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    fecha_decreto = Trim(element.GetElementsByTagName("fecha_decreto")(0).InnerText)
                    correlativo = Trim(element.GetElementsByTagName("correlativo")(0).InnerText)
                    num_decreto = Trim(element.GetElementsByTagName("num_decreto")(0).InnerText)
                    fecha_convenio = Trim(element.GetElementsByTagName("fecha_convenio")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                    monto_neto_mod = Trim(element.GetElementsByTagName("monto_neto_mod")(0).InnerText)
                    gasto_adm_mod = Trim(element.GetElementsByTagName("gasto_adm_mod")(0).InnerText)
                    consul_mod = Trim(element.GetElementsByTagName("consul_mod")(0).InnerText)
                    otros_gastos_mod = Trim(element.GetElementsByTagName("otros_gastos_mod")(0).InnerText)
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_eliminar_convenios_modif_proyecto(ByVal result As String _
                                                    , ByRef region As String _
                                                    , ByRef codigo_da As String _
                                                    , ByRef mandante As String _
                                                    , ByRef correlativo As String _
                                                    , ByRef fecha_decreto As String _
                                                       ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = Trim(element.GetElementsByTagName("correlativo")(0).InnerText)
                    fecha_decreto = Trim(element.GetElementsByTagName("fecha_decreto")(0).InnerText)
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_convenios_proyecto(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef codigo_da As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_mandantes_proyecto(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef codigo_da As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_grabar_convenios_proyecto(ByVal result As String _
                                                , ByRef region As String _
                                                , ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef correlativo As String _
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
                                                       ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = Trim(element.GetElementsByTagName("correlativo")(0).InnerText)

                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                    num_decreto = Trim(element.GetElementsByTagName("num_decreto")(0).InnerText)
                    fecha_decreto = Trim(element.GetElementsByTagName("fecha_decreto")(0).InnerText)
                    tipo_convenio = Trim(element.GetElementsByTagName("tipo_convenio")(0).InnerText)
                    fecha_convenio = Trim(element.GetElementsByTagName("fecha_convenio")(0).InnerText)
                    monto_neto = Trim(element.GetElementsByTagName("monto_neto")(0).InnerText)

                    gastos_administrativos = Trim(element.GetElementsByTagName("gastos_administrativos")(0).InnerText)
                    consul = Trim(element.GetElementsByTagName("consul")(0).InnerText)
                    otros_gastos = Trim(element.GetElementsByTagName("otros_gastos")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                    fecha_ingreso = Trim(element.GetElementsByTagName("fecha_ingreso")(0).InnerText)
                    estado_convenio = Trim(element.GetElementsByTagName("estado_convenio")(0).InnerText)
                    observacion = Trim(element.GetElementsByTagName("observacion")(0).InnerText)

                    fecha_liquidacion = Trim(element.GetElementsByTagName("fecha_liquidacion")(0).InnerText)
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_Set_eliminar_convenios_proyecto(ByVal result As String _
                                                , ByRef region As String _
                                                , ByRef codigo_da As String _
                                                , ByRef mandante As String _
                                                , ByRef correlativo As String _
                                                       ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = Trim(element.GetElementsByTagName("correlativo")(0).InnerText)

                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetEliminaEtapa(ByVal result As String, _
                                             ByRef region As String _
                                            , ByRef codigo_da As String _
                                            , ByRef etapa As String _
                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetGrabaLog(ByVal result As String, _
                                             ByRef nombre_usuario As String _
                                            , ByRef codigo_tipo_usuario As String _
                                            , ByRef url_opcion As String _
                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    nombre_usuario = Trim(element.GetElementsByTagName("nombre_usuario")(0).InnerText)
                    codigo_tipo_usuario = Trim(element.GetElementsByTagName("codigo_tipo_usuario")(0).InnerText)
                    url_opcion = Trim(element.GetElementsByTagName("url_opcion")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_graba_ws_contratos_sectoriales(ByVal result As String _
                                                            , ByRef accion As String _
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
                                                        ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    clave = Trim(element.GetElementsByTagName("clave")(0).InnerText)
                    region_inicio = Trim(element.GetElementsByTagName("region_inicio")(0).InnerText)
                    region_fin = Trim(element.GetElementsByTagName("region_fin")(0).InnerText)
                    codigosafi = Trim(element.GetElementsByTagName("codigosafi")(0).InnerText)
                    descripcionregion = Trim(element.GetElementsByTagName("descripcionregion")(0).InnerText)
                    descripcioncomuna = Trim(element.GetElementsByTagName("descripcioncomuna")(0).InnerText)
                    descripcionprovincia = Trim(element.GetElementsByTagName("descripcionprovincia")(0).InnerText)
                    rutcontratista = Trim(element.GetElementsByTagName("rutcontratista")(0).InnerText)
                    montocontrato = Trim(element.GetElementsByTagName("montocontrato")(0).InnerText)
                    montoinicial = Trim(element.GetElementsByTagName("montoinicial")(0).InnerText)
                    montovigente = Trim(element.GetElementsByTagName("montovigente")(0).InnerText)
                    rutinspector = Trim(element.GetElementsByTagName("rutinspector")(0).InnerText)
                    estadocontrato = Trim(element.GetElementsByTagName("estadocontrato")(0).InnerText)
                    tipogasto = Trim(element.GetElementsByTagName("tipogasto")(0).InnerText)
                    pptooficial = Trim(element.GetElementsByTagName("pptooficial")(0).InnerText)
                    aumentodisminucion = Trim(element.GetElementsByTagName("aumentodisminucion")(0).InnerText)
                    fechatermino = Trim(element.GetElementsByTagName("fechatermino")(0).InnerText)
                    descripcion_tipo_registro = Trim(element.GetElementsByTagName("descripcion_tipo_registro")(0).InnerText)
                    descripcion_categoria = Trim(element.GetElementsByTagName("descripcion_categoria")(0).InnerText)
                    codigo_bip = Trim(element.GetElementsByTagName("codigo_bip")(0).InnerText)
                    proceso = Trim(element.GetElementsByTagName("proceso")(0).InnerText)
                    etapa = Trim(element.GetElementsByTagName("etapa")(0).InnerText)
                    calificacion = Trim(element.GetElementsByTagName("calificacion")(0).InnerText)
                    f_recep_provisional = Trim(element.GetElementsByTagName("f_recep_provisional")(0).InnerText)
                    f_recep_definitiva = Trim(element.GetElementsByTagName("f_recep_definitiva")(0).InnerText)
                    f_res_liq_contrato = Trim(element.GetElementsByTagName("f_res_liq_contrato")(0).InnerText)
                    f_termino_ito = Trim(element.GetElementsByTagName("f_termino_ito")(0).InnerText)
                    ultimo = Trim(element.GetElementsByTagName("ultimo")(0).InnerText)
                    objeto = Trim(element.GetElementsByTagName("objeto")(0).InnerText)
                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)
                    sub_sec = Trim(element.GetElementsByTagName("sub_sec")(0).InnerText)
                    tipo_edificacion = Trim(element.GetElementsByTagName("tipo_edificacion")(0).InnerText)
                    plazo_adjudicado = Trim(element.GetElementsByTagName("plazo_adjudicado")(0).InnerText)
                    inicio_legal = Trim(element.GetElementsByTagName("inicio_legal")(0).InnerText)
                    f_res_adjudicacion = Trim(element.GetElementsByTagName("f_res_adjudicacion")(0).InnerText)
                    plazo_vigente = Trim(element.GetElementsByTagName("plazo_vigente")(0).InnerText)
                    inversion_anno = Trim(element.GetElementsByTagName("inversion_anno")(0).InnerText)
                    inversion_acumulada = Trim(element.GetElementsByTagName("inversion_acumulada")(0).InnerText)
                    cantidad_obra = Trim(element.GetElementsByTagName("cantidad_obra")(0).InnerText)
                    observaciones_contrato = Trim(element.GetElementsByTagName("observaciones_contrato")(0).InnerText)
                    av_fin = Trim(element.GetElementsByTagName("av_fin")(0).InnerText)
                    av_fis_acum = Trim(element.GetElementsByTagName("av_fis_acum")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_mandante_convenios(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef codigo_da As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_buscar_mandantes_del_contrato(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef codigo_da As String _
                                                           , ByRef sufijo As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_eliminar_mandantes_del_contrato(ByVal result As String _
                                                  , ByRef REGION As String _
                                                  , ByRef CODIGO_DA As String _
                                                  , ByRef SUFIJO As String _
                                                  , ByRef MANDANTE As String _
                                                  ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMandantesContrato.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    REGION = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    CODIGO_DA = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    SUFIJO = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    MANDANTE = Trim(element.GetElementsByTagName("mandante")(0).InnerText)

                Next

                'If MANDANTE = "" Then Throw New Exception("Mandante")
                'If REGION = "" Then Throw New Exception("Region")
                'If CODIGO_DA = "" Then Throw New Exception("codigo_da")
                'If SUFIJO = "" Then Throw New Exception("sufijo")
                'If COD_CON = "" Then Throw New Exception("Cod_Con")
                'If FECHA_INGRESO = "" Then Throw New Exception("fecha_ingreso")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetOfertasPropuestas_Elimina(ByVal result As String _
                                                 , ByRef REGION As String _
                                                 , ByRef CODIGO_DA As String _
                                                 , ByRef SUFIJO As String _
                                                 , ByRef RUT_CTTA As String _
                                                 ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetOfertasPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    REGION = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    CODIGO_DA = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    SUFIJO = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    RUT_CTTA = Trim(element.GetElementsByTagName("rut_ctta")(0).InnerText)
                Next

                'If REGION = "" Then Throw New Exception("Region")
                'If CODIGO_DA = "" Then Throw New Exception("codigo_da")
                'If SUFIJO = "" Then Throw New Exception("sufijo")
                'If RUT_CTTA = "" Then Throw New Exception("rut_ctta")
                'If DESCRIPCION = "" Then Throw New Exception("descripcion")
                'If MONTO = 0 Then Throw New Exception("monto")
                'If PLAZO = "" Then Throw New Exception("plazo")
                'If BENEFICIO_PORCENTUAL = 0 Then Throw New Exception("beneficio_porcentual")
                'If FECHA_INGRESO = "" Then Throw New Exception("fecha_ingreso")


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_TipoUsuario(ByVal result As String _
                                                 , ByRef accion As String _
                                                 , ByRef nombre_tipo_usuario As String _
                                                 ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetOfertasPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    nombre_tipo_usuario = Trim(element.GetElementsByTagName("nombre_tipo_usuario")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_localizacion(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef provincia As String _
                                                           , ByRef comuna As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    provincia = Trim(element.GetElementsByTagName("provincia")(0).InnerText)
                    comuna = Trim(element.GetElementsByTagName("comuna")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Graba_Contratos_Detalle_Datos(ByVal result As String, _
                                                                  ByRef codigo_pia As String _
                                                                , ByRef codigo_region As String _
                                                                , ByRef sufijo As String _
                                                                , ByRef strLEGAL As String _
                                                                , ByRef strAMBIENTAL As String _
                                                                , ByRef strEXPROPIACION As String _
                                                                , ByRef strLICITACION As String _
                                                                , ByRef strEJECUCION As String _
                                                                , ByRef strAUMENTO_COSTOS As String _
                                                                , ByRef strEXPLICACION_O_ALERTAS As String _
                                                                , ByRef strAPERTURA_LICITACION As String _
                                                                , ByRef strPRIMERA_PIEDRA As String _
                                                                , ByRef strINAUGURACION As String _
                                                                , ByRef intProximo_Hito As String _
                                                                , ByRef strObservacionMandante As String _
                                                                , ByRef strResp_Administrativo As String _
                                                                ) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    strLEGAL = Trim(element.GetElementsByTagName("strlegal")(0).InnerText)
                    strAMBIENTAL = Trim(element.GetElementsByTagName("strambiental")(0).InnerText)
                    strEXPROPIACION = Trim(element.GetElementsByTagName("strexpropiacion")(0).InnerText)
                    strLICITACION = Trim(element.GetElementsByTagName("strlicitacion")(0).InnerText)
                    strEJECUCION = Trim(element.GetElementsByTagName("strejecucion")(0).InnerText)
                    strAUMENTO_COSTOS = Trim(element.GetElementsByTagName("straumento_costos")(0).InnerText)
                    strEXPLICACION_O_ALERTAS = Trim(element.GetElementsByTagName("strexplicacion_o_alertas")(0).InnerText)
                    strAPERTURA_LICITACION = Trim(element.GetElementsByTagName("strapertura_licitacion")(0).InnerText)
                    strPRIMERA_PIEDRA = Trim(element.GetElementsByTagName("strprimera_piedra")(0).InnerText)
                    strINAUGURACION = Trim(element.GetElementsByTagName("strinauguracion")(0).InnerText)
                    intProximo_Hito = Trim(element.GetElementsByTagName("intproximo_hito")(0).InnerText)
                    strObservacionMandante = Trim(element.GetElementsByTagName("strobservacionmandante")(0).InnerText)
                    strResp_Administrativo = Trim(element.GetElementsByTagName("strresp_administrativo")(0).InnerText)

                Next

                'If codigo_pia = "" Then Throw New Exception("codigo_pia")
                'If codigo_region = "" Then Throw New Exception("codigo_region")
                'If sufijo = "" Then Throw New Exception("sufijo")
                'If strLEGAL = "" Then Throw New Exception("strLEGAL")
                'If strAMBIENTAL = "" Then Throw New Exception("strAMBIENTAL")
                'If strEXPROPIACION = "" Then Throw New Exception("strEXPROPIACION")
                'If strLICITACION = "" Then Throw New Exception("strLICITACION")
                'If strEJECUCION = "" Then Throw New Exception("strEJECUCION")
                'If strAUMENTO_COSTOS = "" Then Throw New Exception("strAUMENTO_COSTOS")
                'If strEXPLICACION_O_ALERTAS = "" Then Throw New Exception("strEXPLICACION_O_ALERTAS")
                'If strAPERTURA_LICITACION = "" Then Throw New Exception("strAPERTURA_LICITACION")
                'If strPRIMERA_PIEDRA = "" Then Throw New Exception("strPRIMERA_PIEDRA")
                'If strINAUGURACION = "" Then Throw New Exception("strINAUGURACION")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Mnt_Componentes(ByVal result As String, _
                                           ByRef accion As String _
                                         , ByRef codigo_proyecto As String _
                                         , ByRef nombre_componente As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    nombre_componente = Trim(element.GetElementsByTagName("nombre_componente")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If nombre_componente = "" Then Throw New Exception("nombre_componente")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Mnt_Financiamiento(ByVal result As String, _
                                                      ByRef accion As String _
                                                    , ByRef codigo_proyecto As String _
                                                    , ByRef descripcion As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If descripcion = "" Then Throw New Exception("descripcion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_Set_Mnt_Monumento(ByVal result As String, _
                                                  ByRef accion As String _
                                                , ByRef codigo_proyecto As String _
                                                , ByRef tipo As String _
                                                , ByRef tipo_doc As String _
                                                , ByRef num_doc As String _
                                                , ByRef fecha As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    tipo = Trim(element.GetElementsByTagName("tipo")(0).InnerText)
                    tipo_doc = Trim(element.GetElementsByTagName("tipo_doc")(0).InnerText)
                    num_doc = Trim(element.GetElementsByTagName("num_doc")(0).InnerText)
                    fecha = Trim(element.GetElementsByTagName("fecha")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If tipo = "" Then Throw New Exception("tipo")
                'If tipo_doc = "" Then Throw New Exception("tipo_doc")
                'If num_doc = 0 Then Throw New Exception("num_doc")
                'If fecha = "" Then Throw New Exception("fecha")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Mnt_Proceso(ByVal result As String, _
                                                      ByRef accion As String _
                                                    , ByRef codigo_proyecto As String _
                                                    , ByRef nombre_proceso As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    nombre_proceso = Trim(element.GetElementsByTagName("nombre_proceso")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If nombre_proceso = "" Then Throw New Exception("nombre_proceso")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function



        Public Function Valida_Set_Mnt_Superficie(ByVal result As String, _
                                                  ByRef accion As String, _
                                                  ByRef codigo_proyecto As String, _
                                                  ByRef nivel As String, _
                                                  ByRef M2 As Long, _
                                                  ByRef proceso_asociado As Integer) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    nivel = Trim(element.GetElementsByTagName("nivel")(0).InnerText)
                    M2 = Trim(element.GetElementsByTagName("m2")(0).InnerText)
                    proceso_asociado = Trim(element.GetElementsByTagName("proceso_asociado")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If nivel = "" Then Throw New Exception("nivel")
                'If M2 = 0 Then Throw New Exception("M2")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        '//JPQV
        Public Function Valida_Get_busca_asig_cargo_presupuesto(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_cargo_presupuesto(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef num_epago As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_fondos_cargo_presupuesto(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_imgPatrimonio(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_item_cargo_presupuesto(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_mandantes_cargo_presupuesto(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_elimina_cargo_presupuesto(ByVal result As String _
                                                            , ByRef cod_con As String _
                                                            , ByRef num_epago As String _
                                                            , ByRef mandante As String _
                                                            , ByRef t_f1 As String _
                                                            , ByRef agno As String _
                                                            , ByRef subt As String _
                                                            , ByRef item As String _
                                                            , ByRef asig As String _
                                                            , ByRef mes_cargo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    t_f1 = Trim(element.GetElementsByTagName("t_f1")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    subt = Trim(element.GetElementsByTagName("subt")(0).InnerText)
                    item = Trim(element.GetElementsByTagName("item")(0).InnerText)
                    asig = Trim(element.GetElementsByTagName("asig")(0).InnerText)
                    mes_cargo = Trim(element.GetElementsByTagName("mes_cargo")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_graba_cargo_presupuesto(ByVal result As String _
                                                            , ByRef cod_con As String _
                                                            , ByRef num_epago As String _
                                                            , ByRef fecha_epago As String _
                                                            , ByRef mandante As String _
                                                            , ByRef t_f1 As String _
                                                            , ByRef agno As String _
                                                            , ByRef subt As String _
                                                            , ByRef item As String _
                                                            , ByRef asig As String _
                                                            , ByRef mes_cargo As String _
                                                            , ByRef monto As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    num_epago = Trim(element.GetElementsByTagName("num_epago")(0).InnerText)
                    fecha_epago = Trim(element.GetElementsByTagName("fecha_epago")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    t_f1 = Trim(element.GetElementsByTagName("t_f1")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    subt = Trim(element.GetElementsByTagName("subt")(0).InnerText)
                    item = Trim(element.GetElementsByTagName("item")(0).InnerText)
                    asig = Trim(element.GetElementsByTagName("asig")(0).InnerText)
                    mes_cargo = Trim(element.GetElementsByTagName("mes_cargo")(0).InnerText)
                    monto = Trim(element.GetElementsByTagName("monto")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_llena_codigo_contratos_proyecto(ByVal result As String, _
                                                                                ByRef codigo_proyecto_exp As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_proyecto_exp = Trim(element.GetElementsByTagName("codigo_proyecto_exp")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetValida_Acceso_Region(ByVal result As String _
                                                            , ByRef usuario As String _
                                                            , ByRef region As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    usuario = Trim(element.GetElementsByTagName("usuario")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_actualiza_fecha_contrato(ByVal result As String _
                                                            , ByRef codigo_pia As String _
                                                            , ByRef codigo_region As String _
                                                            , ByRef sufijo As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_consultoria_detalle_termino(ByVal result As String, _
                                                                                ByRef cod_con As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetBusca_consultoria_detalle_termino_grilla(ByVal result As String, _
                                                                        ByRef cod_con As String _
                                                                        ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_consultoria_detalle_termino(ByVal result As String, _
                                                            ByRef cod_con As String, _
                                                            ByRef fecha_termino_fisico_ito As String, _
                                                            ByRef resp_termino As String, _
                                                            ByRef f_ent_def_con As String, _
                                                            ByRef n_res_liquida_anti_con As String, _
                                                            ByRef f_res_liquida_anti_con As String, _
                                                            ByRef n_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                            ByRef f_docto_aprueba_liquidacion_anticipada_obra As String, _
                                                            ByRef n_res_liquida_con As String, _
                                                            ByRef f_res_liquida_con As String, _
                                                            ByRef autoridad_liquida_con As String, _
                                                            ByRef calificacion_con As Double, _
                                                            ByRef observacion_termino_contrato As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    fecha_termino_fisico_ito = Trim(element.GetElementsByTagName("fecha_termino_fisico_ito")(0).InnerText)
                    resp_termino = Trim(element.GetElementsByTagName("resp_termino")(0).InnerText)
                    f_ent_def_con = Trim(element.GetElementsByTagName("f_ent_def_con")(0).InnerText)
                    n_res_liquida_anti_con = Trim(element.GetElementsByTagName("n_res_liquida_anti_con")(0).InnerText)
                    f_res_liquida_anti_con = Trim(element.GetElementsByTagName("f_res_liquida_anti_con")(0).InnerText)
                    n_docto_aprueba_liquidacion_anticipada_obra = Trim(element.GetElementsByTagName("n_docto_aprueba_liquidacion_anticipada_obra")(0).InnerText)
                    f_docto_aprueba_liquidacion_anticipada_obra = Trim(element.GetElementsByTagName("f_docto_aprueba_liquidacion_anticipada_obra")(0).InnerText)
                    n_res_liquida_con = Trim(element.GetElementsByTagName("n_res_liquida_con")(0).InnerText)
                    f_res_liquida_con = Trim(element.GetElementsByTagName("f_res_liquida_con")(0).InnerText)
                    autoridad_liquida_con = Trim(element.GetElementsByTagName("autoridad_liquida_con")(0).InnerText)
                    calificacion_con = CDbl(Trim(element.GetElementsByTagName("calificacion_con")(0).InnerText))
                    observacion_termino_contrato = Trim(element.GetElementsByTagName("observacion_termino_contrato")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetGraba_consultoria_detalle_termino_grilla(ByVal result As String, _
                                                            ByRef cod_con_c As String, _
                                                            ByRef etapa_c As String, _
                                                            ByRef dias_legales As String, _
                                                            ByRef f_entrega_revision_etapa As String, _
                                                            ByRef plazo_total As String, _
                                                            ByRef dias_revision As String, _
                                                            ByRef observacion_c As String _
                                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con_c = Trim(element.GetElementsByTagName("cod_con_c")(0).InnerText)
                    etapa_c = Trim(element.GetElementsByTagName("etapa_c")(0).InnerText)
                    dias_legales = Trim(element.GetElementsByTagName("dias_legales")(0).InnerText)
                    f_entrega_revision_etapa = Trim(element.GetElementsByTagName("f_entrega_revision_etapa")(0).InnerText)
                    plazo_total = Trim(element.GetElementsByTagName("plazo_total")(0).InnerText)
                    dias_revision = Trim(element.GetElementsByTagName("dias_revision")(0).InnerText)
                    observacion_c = Trim(element.GetElementsByTagName("observacion_c")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetCancela_consultoria_detalle_termino(ByVal result As String, _
                                                            ByRef cod_con As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Elimina_Contrato(ByVal result As String, _
                                                    ByRef codigo_pia As String, _
                                                    ByRef codigo_region As String, _
                                                    ByRef sufijo As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Elimina_Proyecto(ByVal result As String, _
                                                    ByRef codigo_pia As String, _
                                                    ByRef codigo_region As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_pia = Trim(element.GetElementsByTagName("codigo_pia")(0).InnerText)
                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_Get_busca_registros_conttas_categoria(ByVal result As String, _
                                                            ByRef registro As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    registro = Trim(element.GetElementsByTagName("registro")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Contrato_Estado(ByVal result As String, _
                                                    ByRef accion As String, _
                                                    ByRef cod_con As String, _
                                                    ByRef region As String, _
                                                    ByRef sufijo As String, _
                                                    ByRef estatus As String, _
                                                    ByRef marca As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    sufijo = Trim(element.GetElementsByTagName("sufijo")(0).InnerText)
                    estatus = Trim(element.GetElementsByTagName("estatus")(0).InnerText)
                    marca = Trim(element.GetElementsByTagName("marca")(0).InnerText)
                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Mnt_Complemento_Ambiental(ByVal result As String, _
                                   ByRef accion As String _
                                 , ByRef codigo_proyecto As String _
                                 , ByRef codigo_complemento As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    codigo_complemento = Trim(element.GetElementsByTagName("codigo_complemento")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If nombre_componente = "" Then Throw New Exception("nombre_componente")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_Mnt_Multi_Financiamiento(ByVal result As String, _
                                   ByRef accion As String _
                                 , ByRef region As String _
                                 , ByRef codigo_da As String _
                                 , ByRef codigo As String) As Boolean
            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional() 
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    codigo = Trim(element.GetElementsByTagName("codigo")(0).InnerText)
                Next

                'If accion = "" Then Throw New Exception("accion")
                'If codigo_proyecto = "" Then Throw New Exception("codigo_proyecto")
                'If nombre_componente = "" Then Throw New Exception("nombre_componente")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_Convenio_Estado(ByVal result As String, _
                                                    ByRef accion As String, _
                                                    ByRef region As String, _
                                                    ByRef codigo_da As String, _
                                                    ByRef mandante As String, _
                                                    ByRef correlativo As String, _
                                                    ByRef estado As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    mandante = Trim(element.GetElementsByTagName("mandante")(0).InnerText)
                    correlativo = Trim(element.GetElementsByTagName("correlativo")(0).InnerText)
                    estado = Trim(element.GetElementsByTagName("estado")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        ' Nueva Función creada el 22-04-2014

        Public Function Valida_SetElimina_boleta_garantia_contrato(ByVal result As String, _
                                                                                ByRef cod_con As String, _
                                                                                ByRef entidad_financiera As String, _
                                                                                ByRef numero As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                    entidad_financiera = Trim(element.GetElementsByTagName("entidad_financiera")(0).InnerText)
                    numero = Trim(element.GetElementsByTagName("numero")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetMnt_Edificacion(ByVal result As String, _
                                              ByRef accion As String, _
                                              ByRef sector_destino As String, _
                                              ByRef subsector As String, _
                                              ByRef tipologia As String, _
                                              ByRef descripcion As String, _
                                              ByRef edi_orden_listado As String) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    sector_destino = Trim(element.GetElementsByTagName("sector_destino")(0).InnerText)
                    subsector = Trim(element.GetElementsByTagName("subsector")(0).InnerText)
                    tipologia = Trim(element.GetElementsByTagName("tipologia")(0).InnerText)
                    descripcion = Trim(element.GetElementsByTagName("descripcion")(0).InnerText)

                    edi_orden_listado = Trim(element.GetElementsByTagName("edi_orden_listado")(0).InnerText)

                Next

                'If accion = "" Then Throw New Exception("accion")
                'If nombre_usuario = "" Then Throw New Exception("nombre_usuario")
                'If correo_electronico = "" Then Throw New Exception("correo_electronico")
                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")
                'If nombre_completo = "" Then Throw New Exception("nombre_completo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

#End Region

#Region "Conexion ORACLE"

        Public Function Valida_SetGraba_Datos_Exploratorio(ByVal result As String, _
                                            ByRef strCodigoProyecto As String, _
                                            ByRef strCodigoProceso As String, _
                                            ByRef strNombreProyecto As String, _
                                            ByRef strObjeto As String, _
                                            ByRef strCodigoRegion As String, _
                                            ByRef strCodigoProvincia As String, _
                                            ByRef strCodigoComuna As String, _
                                            ByRef strCodigoBip As String, _
                                            ByRef strAnoInicio As String, _
                                            ByRef strMontoEstimado As String, _
                                            ByRef strEtapaMideplan As String, _
                                            ByRef strMontoEstimadoxEtapa As String _
                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetGrabaEtapa.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    strCodigoProyecto = Trim(element.GetElementsByTagName("codigoproyecto")(0).InnerText)
                    strCodigoProceso = Trim(element.GetElementsByTagName("codigoproceso")(0).InnerText)
                    strNombreProyecto = Trim(element.GetElementsByTagName("nombreproyecto")(0).InnerText)
                    strObjeto = Trim(element.GetElementsByTagName("objeto")(0).InnerText)
                    strCodigoRegion = Trim(element.GetElementsByTagName("codigoregion")(0).InnerText)
                    strCodigoProvincia = Trim(element.GetElementsByTagName("codigoprovincia")(0).InnerText)
                    strCodigoComuna = Trim(element.GetElementsByTagName("codigocomuna")(0).InnerText)
                    strCodigoBip = Trim(element.GetElementsByTagName("codigobip")(0).InnerText)
                    strAnoInicio = Trim(element.GetElementsByTagName("anoinicio")(0).InnerText)
                    strMontoEstimado = Trim(element.GetElementsByTagName("montoestimado")(0).InnerText)
                    strEtapaMideplan = Trim(element.GetElementsByTagName("etapamideplan")(0).InnerText)
                    strMontoEstimadoxEtapa = Trim(element.GetElementsByTagName("montoestimadoxetapa")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function



        Public Function Valida_GetObtener_Numero_Exploratorio(ByVal result As String _
                                                             , ByRef Codigo_BIP As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    Codigo_BIP = Trim(element.GetElementsByTagName("codigo_bip")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

#End Region

#Region "Patrimonio"


        Public Function Valida_Get_busca_uso_historico(ByVal result As String _
                                                   , ByRef codigo_proyecto As String _
                                                   ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_mnt_uso_historico(ByVal result As String _
                                                , ByRef accion As String _
                                                , ByRef codigo_proyecto As String _
                                                , ByRef categoria_uso As String _
                                                , ByRef tipologia_de_uso As String _
                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetOfertasPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    categoria_uso = Trim(element.GetElementsByTagName("categoria_uso")(0).InnerText)
                    tipologia_de_uso = Trim(element.GetElementsByTagName("tipologia_de_uso")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO
        Public Function Valida_Get_busca_CODIGO_USOS_PATRIMONIAL_HISTORICO(ByVal result As String _
                                                           , ByRef categoria As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    categoria = Trim(element.GetElementsByTagName("categoria")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_uso_actual(ByVal result As String _
                                                   , ByRef codigo_proyecto As String _
                                                   ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Set_mnt_uso_actual(ByVal result As String _
                                                        , ByRef accion As String _
                                                        , ByRef codigo_proyecto As String _
                                                        , ByRef categoria_uso As String _
                                                        , ByRef tipologia_de_uso As String _
                                                        ) As Boolean

            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetOfertasPropuestas.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    accion = Trim(element.GetElementsByTagName("accion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    categoria_uso = Trim(element.GetElementsByTagName("categoria_uso")(0).InnerText)
                    tipologia_de_uso = Trim(element.GetElementsByTagName("tipologia_de_uso")(0).InnerText)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'Get_busca_CODIGO_USOS_PATRIMONIAL
        Public Function Valida_Get_busca_CODIGO_USOS_PATRIMONIAL(ByVal result As String _
                                                           , ByRef categoria As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetPry_procesos_list.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    categoria = Trim(element.GetElementsByTagName("categoria")(0).InnerText)

                Next

                'If tipologia = "" Then Throw New Exception("tipologia")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GET_MANTENCION_PATRIMONIO_BUSCA(ByVal result As String, _
                                                                                ByRef cod_proyecto As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico_suma.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

#End Region

#Region "EKV"
        Public Function Valida_Get_rpt_patrimonio(ByVal result As String, _
                                                                                ByRef cod_proyecto As String _
                                                                                ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico_suma.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    cod_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)

                Next

                'If cod_con = "" Then Throw New Exception("cod_con")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        'EKV
        Public Function Valida_Set_MANTENCION_PATRIMONIO(ByVal result As String, _
                                                                ByRef opcion As String _
                                                                , ByRef codigo_proyecto As String _
                                                                , ByRef actualizacion_data_p As String _
                                                                , ByRef autor_ficha As String _
                                                                , ByRef tipo_ubicacion As String _
                                                                , ByRef latitud_coordenada As String _
                                                                , ByRef latitud_grados As String _
                                                                , ByRef latitud_minutos As String _
                                                                , ByRef latitud_segundos As String _
                                                                , ByRef longitud_coordenada As String _
                                                                , ByRef longitud_grados As String _
                                                                , ByRef longitud_minutos As String _
                                                                , ByRef longitud_segundos As String _
                                                                , ByRef utm_x As String _
                                                                , ByRef utm_y As String _
                                                                , ByRef utm_uso As String _
                                                                , ByRef propietario As String _
                                                                , ByRef administrador As String _
                                                                , ByRef figura_legal As String _
                                                                , ByRef modelo_gestion As String _
                                                                , ByRef inmueble_conservacion_historica As String _
                                                                , ByRef zona_conservacion_historica As String _
                                                                , ByRef componente_arqueologico As String _
                                                                , ByRef componente_ambiental As String _
                                                                , ByRef complemento_ambiental As String _
                                                                , ByRef otras_superficies As String _
                                                                , ByRef antecedentes_historicos As String _
                                                                , ByRef estado_conservacion_actual As String _
                                                                , ByRef principales_valores As String _
                                                                , ByRef culturales As String _
                                                                , ByRef proyecto_intervencion As String _
                                                                , ByRef estructura_muros As String _
                                                                , ByRef estructura_techumbre As String _
                                                                , ByRef acabado_fachadas As String _
                                                                , ByRef acabado_cubierta As String _
                                                                , ByRef ornamentacion_relevante As String _
                                                                , ByRef otros As String _
                                                                , ByRef descripcion_componentes As String _
                                                                , ByRef rev_anteproy_cmn_envio As String _
                                                                , ByRef rev_anteproy_cmn_recepcion As String _
                                                                , ByRef rev_proy_cmn_envio As String _
                                                                , ByRef rev_proy_cmn_recepcion As String _
                                                                , ByRef rev_dom_envio As String _
                                                                , ByRef rev_dom_recepcion As String _
                                                                , ByRef rev_sea_envio As String _
                                                                , ByRef rev_sea_recepcion As String _
                                                                , ByRef rev_minvu_envio As String _
                                                                , ByRef rev_minvu_recepcion As String _
                                                                , ByRef rev_otra_envio As String _
                                                                , ByRef rev_otra_recepcionas As String _
                                                                , ByRef monumento_historico As String _
                                                                , ByRef tipo_docto_mh As String _
                                                                , ByRef numero_docto_mh As String _
                                                                , ByRef fecha_docto_mh As String _
                                                                , ByRef zona_tipica As String _
                                                                , ByRef tipo_docto_zt As String _
                                                                , ByRef numero_docto_zt As String _
                                                                , ByRef fecha_docto_zt As String _
                                                                , ByRef monumento_arqueologico As String _
                                                                , ByRef tipo_docto_ma As String _
                                                                , ByRef numero_docto_ma As String _
                                                                , ByRef fecha_docto_ma As String _
                                                                , ByRef sis_contructivo_proy_rest As Integer _
                                                                , ByRef sis_contructivo_obra_nueva As Integer _
                                                                , ByRef princ_caracteristicas_constru As String _
                                                                , ByRef rate As String _
                                                                , ByRef superficie_total As String _
                                                            ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    opcion = Trim(element.GetElementsByTagName("opcion")(0).InnerText)
                    codigo_proyecto = Trim(element.GetElementsByTagName("codigo_proyecto")(0).InnerText)
                    actualizacion_data_p = Trim(element.GetElementsByTagName("actualizacion_data_p")(0).InnerText)
                    autor_ficha = Trim(element.GetElementsByTagName("autor_ficha")(0).InnerText)
                    tipo_ubicacion = Trim(element.GetElementsByTagName("tipo_ubicacion")(0).InnerText)
                    latitud_coordenada = Trim(element.GetElementsByTagName("latitud_coordenada")(0).InnerText)
                    latitud_grados = Trim(element.GetElementsByTagName("latitud_grados")(0).InnerText)
                    latitud_minutos = Trim(element.GetElementsByTagName("latitud_minutos")(0).InnerText)
                    latitud_segundos = Trim(element.GetElementsByTagName("latitud_segundos")(0).InnerText)
                    longitud_coordenada = Trim(element.GetElementsByTagName("longitud_coordenada")(0).InnerText)
                    longitud_grados = Trim(element.GetElementsByTagName("longitud_grados")(0).InnerText)
                    longitud_minutos = Trim(element.GetElementsByTagName("longitud_minutos")(0).InnerText)
                    longitud_segundos = Trim(element.GetElementsByTagName("longitud_segundos")(0).InnerText)
                    utm_x = Trim(element.GetElementsByTagName("utm_x")(0).InnerText)
                    utm_y = Trim(element.GetElementsByTagName("utm_y")(0).InnerText)
                    utm_uso = Trim(element.GetElementsByTagName("utm_uso")(0).InnerText)
                    propietario = Trim(element.GetElementsByTagName("propietario")(0).InnerText)
                    administrador = Trim(element.GetElementsByTagName("administrador")(0).InnerText)
                    figura_legal = Trim(element.GetElementsByTagName("figura_legal")(0).InnerText)
                    modelo_gestion = Trim(element.GetElementsByTagName("modelo_gestion")(0).InnerText)
                    inmueble_conservacion_historica = Trim(element.GetElementsByTagName("inmueble_conservacion_historica")(0).InnerText)
                    zona_conservacion_historica = Trim(element.GetElementsByTagName("zona_conservacion_historica")(0).InnerText)
                    componente_arqueologico = Trim(element.GetElementsByTagName("componente_arqueologico")(0).InnerText)
                    componente_ambiental = Trim(element.GetElementsByTagName("componente_ambiental")(0).InnerText)
                    complemento_ambiental = Trim(element.GetElementsByTagName("complemento_ambiental")(0).InnerText)
                    otras_superficies = Trim(element.GetElementsByTagName("otras_superficies")(0).InnerText)
                    antecedentes_historicos = Trim(element.GetElementsByTagName("antecedentes_historicos")(0).InnerText)
                    estado_conservacion_actual = Trim(element.GetElementsByTagName("estado_conservacion_actual")(0).InnerText)
                    principales_valores = Trim(element.GetElementsByTagName("principales_valores")(0).InnerText)
                    culturales = Trim(element.GetElementsByTagName("culturales")(0).InnerText)
                    proyecto_intervencion = Trim(element.GetElementsByTagName("proyecto_intervencion")(0).InnerText)
                    estructura_muros = Trim(element.GetElementsByTagName("estructura_muros")(0).InnerText)
                    estructura_techumbre = Trim(element.GetElementsByTagName("estructura_techumbre")(0).InnerText)
                    acabado_fachadas = Trim(element.GetElementsByTagName("acabado_fachadas")(0).InnerText)
                    acabado_cubierta = Trim(element.GetElementsByTagName("acabado_cubierta")(0).InnerText)
                    ornamentacion_relevante = Trim(element.GetElementsByTagName("ornamentacion_relevante")(0).InnerText)
                    otros = Trim(element.GetElementsByTagName("otros")(0).InnerText)
                    descripcion_componentes = Trim(element.GetElementsByTagName("descripcion_componentes")(0).InnerText)
                    rev_anteproy_cmn_envio = Trim(element.GetElementsByTagName("rev_anteproy_cmn_envio")(0).InnerText)
                    rev_anteproy_cmn_recepcion = Trim(element.GetElementsByTagName("rev_anteproy_cmn_recepcion")(0).InnerText)
                    rev_proy_cmn_envio = Trim(element.GetElementsByTagName("rev_proy_cmn_envio")(0).InnerText)
                    rev_proy_cmn_recepcion = Trim(element.GetElementsByTagName("rev_proy_cmn_recepcion")(0).InnerText)
                    rev_dom_envio = Trim(element.GetElementsByTagName("rev_dom_envio")(0).InnerText)
                    rev_dom_recepcion = Trim(element.GetElementsByTagName("rev_dom_recepcion")(0).InnerText)
                    rev_sea_envio = Trim(element.GetElementsByTagName("rev_sea_envio")(0).InnerText)
                    rev_sea_recepcion = Trim(element.GetElementsByTagName("rev_sea_recepcion")(0).InnerText)
                    rev_minvu_envio = Trim(element.GetElementsByTagName("rev_minvu_envio")(0).InnerText)
                    rev_minvu_recepcion = Trim(element.GetElementsByTagName("rev_minvu_recepcion")(0).InnerText)
                    rev_otra_envio = Trim(element.GetElementsByTagName("rev_otra_envio")(0).InnerText)
                    rev_otra_recepcionas = Trim(element.GetElementsByTagName("rev_otra_recepcionas")(0).InnerText)

                    monumento_historico = Trim(element.GetElementsByTagName("monumento_historico")(0).InnerText)
                    tipo_docto_mh = Trim(element.GetElementsByTagName("tipo_docto_mh")(0).InnerText)
                    numero_docto_mh = Trim(element.GetElementsByTagName("numero_docto_mh")(0).InnerText)
                    fecha_docto_mh = Trim(element.GetElementsByTagName("fecha_docto_mh")(0).InnerText)
                    zona_tipica = Trim(element.GetElementsByTagName("zona_tipica")(0).InnerText)
                    tipo_docto_zt = Trim(element.GetElementsByTagName("tipo_docto_zt")(0).InnerText)
                    numero_docto_zt = Trim(element.GetElementsByTagName("numero_docto_zt")(0).InnerText)
                    fecha_docto_zt = Trim(element.GetElementsByTagName("fecha_docto_zt")(0).InnerText)
                    monumento_arqueologico = Trim(element.GetElementsByTagName("monumento_arqueologico")(0).InnerText)
                    tipo_docto_ma = Trim(element.GetElementsByTagName("tipo_docto_ma")(0).InnerText)
                    numero_docto_ma = Trim(element.GetElementsByTagName("numero_docto_ma")(0).InnerText)
                    fecha_docto_ma = Trim(element.GetElementsByTagName("fecha_docto_ma")(0).InnerText)

                    sis_contructivo_proy_rest = Trim(element.GetElementsByTagName("sis_contructivo_proy_rest")(0).InnerText)
                    sis_contructivo_obra_nueva = Trim(element.GetElementsByTagName("sis_contructivo_obra_nueva")(0).InnerText)
                    princ_caracteristicas_constru = Trim(element.GetElementsByTagName("princ_caracteristicas_constru")(0).InnerText)

                    rate = Trim(element.GetElementsByTagName("rate")(0).InnerText)
                    superficie_total = Trim(element.GetElementsByTagName("superficie_total")(0).InnerText)

                Next

                'If accion = "" Then Throw New Exception("accion")
                'If nombre_usuario = "" Then Throw New Exception("nombre_usuario")
                'If correo_electronico = "" Then Throw New Exception("correo_electronico")
                'If codigo_tipo_usuario = 0 Then Throw New Exception("codigo_tipo_usuario")
                'If nombre_completo = "" Then Throw New Exception("nombre_completo")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_tipo_proceso(ByVal result As String, _
                                                                                ByRef codigo_contrato As String _
                                                                                ) As Boolean
            'GSI: 13/01/2012

            Dim IsValid As Boolean = False

            Try

                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_contratos_detalle_avance_fisico.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_contrato = Trim(element.GetElementsByTagName("codigo_contrato")(0).InnerText)

                Next

                'If tipo_grilla = "" Then Throw New Exception("tipo_grilla")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_valida_existencia_contrato(ByVal result As String, _
                                                       ByRef cod_con As String, _
                                                       ByRef codigo_da As String) As Boolean


            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    cod_con = element.GetElementsByTagName("cod_con")(0).InnerText
                    codigo_da = element.GetElementsByTagName("codigo_da")(0).InnerText
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function


        Public Function Valida_SetMnt_updateImagenesContratos(ByVal result As String, _
                                                       ByRef cod_con As String, _
                                                       ByRef codigo_da As String, _
                                                       ByRef pathImagen As String, _
                                                       ByRef nombImagen As String, _
                                                       ByRef TipoImagen As String) As Boolean


            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    cod_con = element.GetElementsByTagName("cod_con")(0).InnerText
                    codigo_da = element.GetElementsByTagName("codigo_da")(0).InnerText
                    pathImagen = element.GetElementsByTagName("pathimagen")(0).InnerText
                    nombImagen = element.GetElementsByTagName("nombimagen")(0).InnerText
                    TipoImagen = element.GetElementsByTagName("tipoimagen")(0).InnerText
                Next



            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetMnt_ImagenesContrato_BorraContrato(ByVal result As String, _
                                                       ByRef cod_con As String) As Boolean


            Dim IsValid As Boolean = False

            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.SetMnt_Dom_Mandante.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    cod_con = element.GetElementsByTagName("cod_con")(0).InnerText
                Next

                'If accion = 0 Then Throw New Exception("accion")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_Get_busca_imgFichaProyecto(ByVal result As String, _
                                                      ByRef cod_con As String) As Boolean

            Dim IsValid As Boolean = False
            'GSI EK: 14/01/2013
            Try
                'CambiaConfiguracionRegional()
                'Cargo los XSD que estan como atributos del assembly...
                'Dim sm As Stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PYC.Utilities.GetBusca_Datos_Usuario.xsd")
                'Dim schema As New XmlSchemaSet()
                'schema.Add(XmlSchema.Read(sm, New ValidationEventHandler(AddressOf ValidationEventHandler)))
                'schema.Compile()

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))
                'xDoc.Schemas = schema

                'Valido el XML con el XSD
                'xDoc.Validate(New ValidationEventHandler(AddressOf ValidationEventHandler))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    cod_con = Trim(element.GetElementsByTagName("cod_con")(0).InnerText)
                Next

                'If usuario = "" Then Throw New Exception("usuario")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

#End Region

#Region "Metodos para Programación de Montos IDEA"

        Public Function Valida_SetGrabaProgramacionMontoIdea(ByVal result As String _
                                                           , ByRef region As String _
                                                           , ByRef codigo_da As String _
                                                           , ByRef agno As String _
                                                           , ByRef monto As String _
                                                           ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                    monto = Trim(element.GetElementsByTagName("monto")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If agno = "" Then Throw New Exception("agno")
                If monto = "" Then Throw New Exception("monto")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_SetEliminaProgramacionMontoIdea(ByVal result As String _
                                                         , ByRef region As String _
                                                         , ByRef codigo_da As String _
                                                         , ByRef agno As String _
                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    agno = Trim(element.GetElementsByTagName("agno")(0).InnerText)
                Next

                If region = "" Then Throw New Exception("region")
                If codigo_da = "" Then Throw New Exception("codigo_da")
                If agno = "" Then Throw New Exception("agno")

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

        Public Function Valida_GetProgramacionMontoIdea(ByVal result As String _
                                                      , ByRef region As String _
                                                      , ByRef codigo_da As String _
                                                      ) As Boolean

            Dim IsValid As Boolean = False

            Try

                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespace(result.ToString()))

                IsValid = True

                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)
                    region = Trim(element.GetElementsByTagName("region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                Next


            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function

#End Region


#Region "Metodo para guardar codigo relacional de contrato entre SPC y SAFI"
        Public Function Valida_SetGraba_Codigo_Relacional_Contrato(ByVal result As String, _
                                                                    ByRef codigo_region As String, _
                                                                    ByRef codigo_da As String, _
                                                                    ByRef cod_con_spc As String, _
                                                                    ByRef cod_con_safi As String _
                                                                    ) As Boolean

            Dim IsValid As Boolean = False

            Try

                'Cargo el XML y asigno el namespace correspondiente
                Dim xDoc As New XmlDocument()
                xDoc.LoadXml(SetNamespaceSave(result.ToString()))

                IsValid = True


                For Each node As XmlNode In xDoc.GetElementsByTagName("parametros")
                    Dim element As XmlElement = CType(node, XmlElement)

                    codigo_region = Trim(element.GetElementsByTagName("codigo_region")(0).InnerText)
                    codigo_da = Trim(element.GetElementsByTagName("codigo_da")(0).InnerText)
                    cod_con_spc = Trim(element.GetElementsByTagName("cod_con_spc")(0).InnerText)
                    cod_con_safi = Trim(element.GetElementsByTagName("cod_con_safi")(0).InnerText)

                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return IsValid
        End Function
#End Region

    End Class

End Namespace
