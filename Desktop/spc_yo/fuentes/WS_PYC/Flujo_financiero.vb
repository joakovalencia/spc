Imports System.Web.Services
Imports System.Xml
Imports PYC.Utilities.PYC.Utilities
Imports PYC.Utilities.PYC.Utilities.DataAccess


Partial Public Class WSSPC
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function Get_Flujo_financiero() As XmlDocument

        Dim result As New StringBuilder("<Output>")


        Dim Retorno As Integer = 0
        Dim Dt As DataTable = Nothing

        Try

            Dim FF As New AccessLayer()

            Dt = FF.GetBusca_AL_Flujo_financiero()
            result.Append(GenerateResultXML(Dt, 1, True)) '1 Indica consulta con Resultados fuera 2 sin datos solo ejecucion

        Catch ex As Exception
            result.Append(ResultMessages.GetInstance().GetResultXML(ResultMessages.Information.Critical, ex.Message))
        Finally
            result.Append("</Output>")
        End Try

        'Retorno el XML de resultado
        Return CreateXMLDocument(result.ToString())

    End Function

End Class
