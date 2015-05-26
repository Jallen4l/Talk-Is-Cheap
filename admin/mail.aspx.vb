Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim AdminID As String
    Dim isNew As Boolean

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("isNew") = isNew
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            AdminID = Session("AdminID")
            If Not IsPostBack Then
                Call getNewMail()
                isNew = True
            Else
                isNew = Session("isNew")
            End If
        End If
        Call Msgs()
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

    Sub getNewMail()
        lblMessages.Text = "Your New Messages"
        btnOpen.Visible = False
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As New DataTable

        DB.AddParameter("AdminID", AdminID)
        DB.Execute("sp_AdminMail_GetMail")

        DT = DB.QueryResults

        lstMessages.DataSource = DT
        lstMessages.DataTextField = "AdminMsg"
        lstMessages.DataValueField = "AdminMsgID"
        lstMessages.DataBind()
        If DT.Rows.Count > 0 Then
            btnOpen.Visible = True
        End If
        btnOld.Text = "View Old Messages"
        isNew = True
        Me.btnOpen.Style.Add("left", "595px")
    End Sub

    Protected Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Session("AdminMsgID") = lstMessages.SelectedValue
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As New DataTable
        DB.AddParameter("AdminMsgID", lstMessages.SelectedValue)
        DB.Execute("sp_AdminMail_MsgViewed")
        Response.Redirect("message.aspx")
    End Sub

    Protected Sub btnOld_Click(sender As Object, e As EventArgs) Handles btnOld.Click
        If isNew = True Then
            Dim AdminID As String = Session("AdminID")

            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DT As New DataTable

            DB.AddParameter("AdminID", AdminID)
            DB.Execute("sp_AdminMail_OldMail")

            DT = DB.QueryResults
            If DT.Rows.Count > 0 Then
                lstMessages.DataSource = DT
                lstMessages.DataTextField = "AdminMsg"
                lstMessages.DataValueField = "AdminMsgID"
                lstMessages.DataBind()
            End If
            lblMessages.Text = "Your Old Messages"
            btnOld.Text = "View New Messages"
            If DT.Rows.Count > 0 Then
                btnOpen.Visible = True
            End If
            Me.btnOpen.Style.Add("left", "590px")
            isNew = False
        Else
            Call getNewMail()
        End If

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

    Protected Sub btnMessages_Click(sender As Object, e As EventArgs) Handles btnMessages.Click
        Response.Redirect("../admin/send.aspx")
    End Sub

End Class

