Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim AdminID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            AdminID = Session("AdminID")
            Call ListAdmins()
            Call Msgs()
        End If
    End Sub

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
    End Sub

    Sub Msgs()
            Dim DBmsg As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DTmsg As New DataTable
            DBmsg.AddParameter("AdminID", AdminID)
            DBmsg.Execute("sp_AdminMail_GetMail")
            DTmsg = DBmsg.QueryResults
            If DTmsg.Rows.Count > 0 Then
                btnMail.BackColor = Drawing.Color.OrangeRed
            End If
    End Sub

    Sub ListAdmins()
        lstAdmins.Items.Clear()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As DataTable
        DB.Execute("sp_AdminSend_ListAdmins")
        DT = DB.QueryResults
        lstAdmins.DataSource = DT
        lstAdmins.DataTextField = "Fullname"
        lstAdmins.DataValueField = "AdminID"
        lstAdmins.DataBind()
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Response.Redirect("../admin/Default.aspx")
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Response.Redirect("../global/Default.aspx")
    End Sub

    Protected Sub btnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Response.Redirect("../admin/mail.aspx")
    End Sub

    Protected Sub btnSuspend_Click(sender As Object, e As EventArgs) Handles btnSuspend.Click
        Response.Redirect("../admin/suspend.aspx")
    End Sub

    Protected Sub btnAddAdmin_Click(sender As Object, e As EventArgs) Handles btnAddAdmin.Click
        If txtFirstname.Text = "" Or txtLastName.Text = "" Or txtEmail.Text = "" Or txtUsername.Text = "" Then
            If txtFirstname.Text = "" Then
                txtFirstname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtFirstname.BorderStyle = BorderStyle.Solid
            End If
            If txtLastName.Text = "" Then
                txtLastName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtLastName.BorderStyle = BorderStyle.Solid
            End If
            If txtEmail.Text = "" Then
                txtEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtEmail.BorderStyle = BorderStyle.Solid
            End If
            If txtUsername.Text = "" Then
                txtUsername.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtUsername.BorderStyle = BorderStyle.Solid
            End If
        Else
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@FirstName", txtFirstname.Text)
            DB.AddParameter("@LastName", txtLastName.Text)
            DB.AddParameter("@Email", txtEmail.Text)
            DB.AddParameter("@Username", txtUsername.Text)
            DB.Execute("sp_ClientAdmins_AddAdmin")
            Dim SMTPServer As New System.Net.Mail.SmtpClient("mail.cse.dmu.ac.uk")
            Dim Message As New System.Net.Mail.MailMessage("noreply@dmu.ac.uk", txtEmail.Text, "Talk-is-Cheap: Welcome to the team!", "Your username is: " & txtUsername.Text & " and your password is: changeme")
            SMTPServer.Send(Message)
        End If
    End Sub

    Protected Sub btnDisable_Click(sender As Object, e As EventArgs) Handles btnDisable.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@AdminID", lstAdmins.SelectedValue)
        DB.Execute("sp_AdminAdmins_DisableAdmin")
        Call ListAdmins()
    End Sub
End Class

