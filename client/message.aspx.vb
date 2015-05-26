Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim MsgID As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        ElseIf Session("MsgID") = "" Then
            Response.Redirect("mail.aspx")
        Else
            MsgID = Session("MsgID")

            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DT As New DataTable

            DB.AddParameter("MsgID", MsgID)
            DB.Execute("sp_ClientMessage_ReturnMsg")

            DT = DB.QueryResults
            txtMessage.Text = DT.Rows(0)("Msg")
            lblFrom.Text = "<strong>FROM:</strong> " & DT.Rows(0)("FromName") & "<strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Date: </strong>" & DT.Rows(0)("MsgDate")
            Session("FromName") = DT.Rows(0)("FromName")
            Session("FromID") = DT.Rows(0)("AdminID")
            txtMessage.Enabled = False
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("MsgID", MsgID)
        DB.Execute("sp_ClientMessage_DeleteMsg")
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub BtnMarkUnread_Click(sender As Object, e As EventArgs) Handles BtnMarkUnread.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("MsgID", MsgID)
        DB.Execute("sp_ClientMessage_UpdateUnread")
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        Session("IsReply") = "True"
        Response.Redirect("send.aspx")
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

    Protected Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help button takes you to the help portal
        Response.Redirect("help.aspx")
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("mail.aspx")
    End Sub
End Class

