Imports System.Xml

Namespace PYC.Utilities.Input


    Partial Public Class ValidateInput
        Public Function Valida_Get_Flujo_Financiero(ByVal result As String, _
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
    End Class
End Namespace
