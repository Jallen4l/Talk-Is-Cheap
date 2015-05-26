Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim PhoneNo As Integer
    Dim ClientName As String
    Dim AdminID As String
    Dim SendTo As String
    Dim ClientMsgID As New Random
    Dim AdminMsgID As New Random
    Dim MsgID As String
    Dim CaseNo As Integer
    Dim AdminToID As Integer
    Dim isSent As Boolean

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("PhoneNumber") = SendTo
        Session("CaseNo") = CaseNo
        Session("AdminToID") = AdminToID
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            If IsPostBack Then
                SendTo = Session("PhoneNumber")
                CaseNo = Session("CaseNo")
                AdminToID = Session("AdminToID")
            Else : End If
        End If
    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim DBListAdmins As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTListAdmins As DataTable
        DBListAdmins.Execute("ListAdmins")
        DTListAdmins = DBListAdmins.QueryResults

        For i = 0 To DTListAdmins.Rows.Count - 1
            Dim DBAdmin As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DBAdmin.AddParameter("@AdminMsgID", AdminMsgID.Next(10000, 99999))
                DBAdmin.AddParameter("@AdminID", DTListAdmins.Rows(i)("AdminID"))
            DBAdmin.AddParameter("@FromID", Session("LoggedIn"))
            DBAdmin.AddParameter("@Msg", txtMessage.Text)
            DBAdmin.Execute("SendToAdmin")
        Next
        Response.Redirect("mail.aspx")
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

End Class

