'<summary>
'Creado por: Erick Kleiner - GSI Asesorias
'Fecha: 17-10-2012
'Descripción: Reportes Varios
'</summary>

Imports System.Text

Namespace PYC.Utilities
    Public Class ResultMessages
        Public Enum Information
            Success = 0
            NoResult = 1
            Critical = 2
        End Enum

#Region "Defino un singleton para acceder a los metodos de esta clase..."
        Private Shared hlp As ResultMessages
        Private Shared _classLock As Object = GetType(ResultMessages)

        Private Sub New()
        End Sub
        Public Shared Function GetInstance() As ResultMessages
            SyncLock _classLock
                If hlp Is Nothing Then hlp = New ResultMessages()

                Return hlp
            End SyncLock
        End Function
#End Region

        Public Function GetResultXML(Optional ByVal info As Information = Information.Success, _
                                     Optional ByVal message As String = "") As String

            Dim str As New StringBuilder()
            str.Append("<respuesta>")
            str.AppendFormat("<codigo>{0}</codigo>", CInt(info))
            str.Append("<descripcion>")

            Select Case info
                Case Information.Success
                    str.Append("Procedimiento ejecutado exitosamente")
                Case Information.NoResult
                    str.Append("La consultado no ha retornado valores")
                Case Information.Critical
                    str.Append(message)
            End Select

            str.Append("</descripcion>")
            str.Append("</respuesta>")

            Return str.ToString()
        End Function

        Public Function GetResultXML_SinSP() As String

            Dim str As New StringBuilder()
            str.Append("<respuesta>")
            str.Append("<codigo>1</codigo>")
            str.Append("<descripcion>Parametro Tipo no valido</descripcion>")
            str.Append("</respuesta>")

            Return str.ToString()
        End Function

    End Class
End Namespace