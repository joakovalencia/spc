Imports System.Configuration
Imports System.Data.SqlClient

Namespace PYC.Utilities.DataAccess

    Partial Public Class AccessLayer
        Public Function GetBusca_AL_Flujo_financiero() As DataTable

            Dim ConnectionString As String = ConfigurationManager.AppSettings("PYC")
            Dim oConn As New SqlConnection
            Dim oCmd As SqlCommand = Nothing
            Dim Adp As New SqlDataAdapter
            Dim DsSalida As New DataSet
            oConn.ConnectionString = ConnectionString
            Try
                oConn.Open()

                oCmd = New SqlCommand("SP_BUSCA_FLUJO_FINANCIERO", oConn)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = ConfigurationManager.AppSettings("TimeOut")

                Adp.SelectCommand = oCmd
                Adp.Fill(DsSalida, "Tabla_fujo_financiero")
            Catch ex As Exception
                Throw ex
            Finally
                oCmd.Dispose()
                oConn.Dispose()
            End Try

            Return DsSalida.Tables(0)

        End Function
    End Class
End Namespace

