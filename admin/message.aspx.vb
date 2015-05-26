Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim MsgID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        ElseIf Session("AdminMsgID") = "" Then
            Response.Redirect("mail.aspx")
        Else
            MsgID = Session("AdminMsgID")

            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DT As New DataTable

            DB.AddParameter("AdminMsgID", MsgID)
            DB.Execute("sp_AdminMessage_ReturnMsg")

            DT = DB.QueryResults
            txtMessage.Text = DT.Rows(0)("Msg")
            lblFrom.Text = Session("AdminMsgID")
            lblFrom.Text = "<strong>FROM:</strong> " & DT.Rows(0)("FromName") & "<strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Date: </strong>" & DT.Rows(0)("MsgDate")
            Session("FromName") = DT.Rows(0)("FromName")
            Session("FromID") = DT.Rows(0)("FromID")
            txtMessage.Enabled = False
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("AdminMsgID", MsgID)
        DB.Execute("sp_AdminMessage_DeleteMsg")
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub BtnMarkUnread_Click(sender As Object, e As EventArgs) Handles BtnMarkUnread.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("AdminMsgID", MsgID)
        DB.Execute("sp_AdminMessage_UpdateUnread")
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        Session("IsReply") = "True"
        Response.Redirect("send.aspx")
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

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("../admin/mail.aspx")
    End Sub
End Class

