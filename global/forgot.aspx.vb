Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim ClientDT As New DataTable
    Dim AdminDT As New DataTable

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtEmail.Text = "" Then
            lblError.Text = "Please enter an email address"
            txtEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtEmail.BorderStyle = BorderStyle.Solid
        Else
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DT As DataTable
            DB.AddParameter("@Email", txtEmail.Text)
            DB.Execute("sp_Forgot_GetPassword")
            DT = DB.QueryResults
            Dim Email As String = txtEmail.Text
            Dim Passcode As String = DT.Rows(0)("Passcode")

            Dim SMTPServer As New System.Net.Mail.SmtpClient("mail.cse.dmu.ac.uk")
            Dim Message As New System.Net.Mail.MailMessage("noreply@dmu.ac.uk", Email, "Talk-is-Cheap: Password reminder", "Your password is: " & Passcode)
            SMTPServer.Send(Message)
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class

