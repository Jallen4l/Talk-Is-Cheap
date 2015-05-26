Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim AdminID As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            AdminID = Session("AdminID")
            Call Msgs()
            If Not IsPostBack Then
                Call PopSuspended()
            End If
        End If
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

    Sub PopSuspended()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As DataTable
        DB.Execute("sp_AdminSuspend_ShowSuspended")
        DT = DB.QueryResults
        lstSuspended.DataSource = DT
        lstSuspended.DataTextField = "FullName"
        lstSuspended.DataValueField = "PhoneNo"
        lstSuspended.DataBind()
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Response.Redirect("../global/Default.aspx")
    End Sub

    Protected Sub btnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub btnSuspend_Click(sender As Object, e As EventArgs) Handles btnSuspend.Click
        Response.Redirect("suspend.aspx")
    End Sub

    Protected Sub btnSuspendNumber_Click(sender As Object, e As EventArgs) Handles btnSuspendNumber.Click
        Dim ConfirmError As String
        If txtPhoneNumber.Text = "" Or txtReason.Text = "" Or txtPhoneNumber.Text.Length() > 11 Then
            If txtPhoneNumber.Text = "" Then
                ConfirmError = "Please enter a phone number."
                lblConfirmError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPhoneNumber.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPhoneNumber.BorderStyle = BorderStyle.Solid
            End If
            If txtReason.Text = "" Then
                ConfirmError = ConfirmError & " Please enter a reason."
                lblConfirmError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtReason.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtReason.BorderStyle = BorderStyle.Solid
            End If
            If txtPhoneNumber.Text.Length() > 11 Then
                ConfirmError = ConfirmError & " Please enter a phone number of 11 digits."
                lblConfirmError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPhoneNumber.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPhoneNumber.BorderStyle = BorderStyle.Solid
            End If
        Else
            Dim DBcheck As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DTcheck As New DataTable
            DBcheck.AddParameter("@IDCheck", txtPhoneNumber.Text)
            DBcheck.Execute("sp_AdminSuspend_CheckExists")
            DTcheck = DBcheck.QueryResults

            If DTcheck.Rows.Count > 0 Then
                Dim DBinsert As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                Dim SuspendID As New Random
                Dim sID As Integer = SuspendID.Next(10000, 99999)
                DBinsert.AddParameter("@SuspendID", sID)
                DBinsert.AddParameter("@PhoneNo", txtPhoneNumber.Text)
                DBinsert.AddParameter("@AdminID", AdminID)
                DBinsert.AddParameter("@Reason", txtReason.Text)
                DBinsert.Execute("sp_AdminSuspend_SuspendPhoneNo")

                Dim DBupdate As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                DBupdate.AddParameter("@PhoneNo", txtPhoneNumber.Text)
                DBupdate.Execute("sp_AdminSuspend_DisableClient")
                Call PopSuspended()
                txtPhoneNumber.Text = ""
                txtReason.Text = ""
            Else
                lblConfirmError.Text = "Account not found."
                lblConfirmError.ForeColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            End If
        End If

        lblConfirmError.Text = ConfirmError

    End Sub

    Protected Sub btnUnsuspend_Click(sender As Object, e As EventArgs) Handles btnUnsuspend.Click
        Dim DBdelete As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DBdelete.AddParameter("PhoneNo", lstSuspended.SelectedValue)
        DBdelete.Execute("sp_AdminSuspend_DeleteSuspend")

        Dim DBupdate As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DBupdate.AddParameter("PhoneNo", lstSuspended.SelectedValue)
        DBupdate.Execute("sp_AdminSuspend_UpdateSuspend")

        Call PopSuspended()
    End Sub
End Class

