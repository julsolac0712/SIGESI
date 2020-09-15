Imports System.Net.Mail
Imports System.Configuration
Imports System.Net.Mime

Public Class Mailing

    Private CuentaSistema As Net.Mail.MailAddress
    Private _Host As String
    Private _Port As Integer

    Public Sub New(ByVal adminMail As String, ByVal appName As String, ByVal host As String, ByVal port As Integer)
        CuentaSistema = New MailAddress(adminMail, appName)
        _Host = host
        _Port = port
    End Sub

    Public Function EnvioCorreo(ByVal subject As String, ByVal cuerpoCorreo As String, ByVal correoSolicitante As String, Optional correosCopia As String = Nothing, Optional adjuntos As List(Of String) = Nothing) As Boolean

        Dim correo As New Net.Mail.MailMessage
        Dim tryAgain As Integer = 5

        Dim smtp As New SmtpClient
        smtp.Host = _Host
        smtp.Port = _Port
        '--------- ENVIO CORREO AL SOLICITANTE ----------------
        correo.From = CuentaSistema
        correo.IsBodyHtml = True
        correo.Subject = subject
        Try
            'correo.To.Add(correoSolicitante)
            correo.To.Add("randall.vargas@iica.int")
            If (correosCopia IsNot Nothing) Then
                'correo.CC.Add(correosCopia)
            End If
        Catch e As Exception
            correo.To.Clear()
            correo.CC.Clear()
            correo.To.Add(CuentaSistema)
            correo.Subject += "_ERROR al enviar este Correo:" + correo.ToString
            correo.Body = "El error es:" & e.Message
            smtp.Send(correo)
            Return False
        End Try
        correo.Body = cuerpoCorreo
        If (adjuntos IsNot Nothing) Then
            GestionarAdjuntos(correo, adjuntos)
        End If
        While (tryAgain > 0)
            Try
                smtp.Send(correo)
                correo.To.Clear()
                Return True
            Catch ex As Exception
                tryAgain = tryAgain - 1
                If (tryAgain = 0) Then
                    correo.To.Clear()
                    correo.CC.Clear()
                    correo.To.Add(CuentaSistema)
                    correo.Subject += "_ERROR al enviar este Correo"
                    correo.Body = "El error es:" & ex.Message
                    smtp.Send(correo)
                    Return False
                End If
            End Try
        End While
        Return False
    End Function

    Private Sub GestionarAdjuntos(ByRef correo As Net.Mail.MailMessage, ByVal adjuntos As List(Of String))
        For Each adjunto As String In adjuntos
            Dim Attachment As Attachment = New Attachment(adjunto, MediaTypeNames.Application.Octet)
            correo.Attachments.Add(Attachment)
        Next
    End Sub

End Class
