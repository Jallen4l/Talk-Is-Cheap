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
    Dim AdminToID As String
    Dim isSent As Boolean

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("PhoneNumber") = SendTo
        Session("CaseNo") = CaseNo
        Session("AdminToID") = AdminToID
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblSendTo.Text = "Sending to: " & Session("SendTo")
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            pnlChoose.Visible = False
            AdminID = Session("AdminID")
            If Session("IsReply") = True Then
                If Session("FromID").Length = 5 Then
                    CaseNo = 3
                ElseIf Session("FromID").Length = 11 Then
                    CaseNo = 1
                End If
                AdminToID = Session("FromID")
                SendTo = Session("FromID")
                lblSendTo.Text = "Sending to: " & Session("FromName")
            Else
                If IsPostBack Then
                    SendTo = Session("PhoneNumber")
                    CaseNo = Session("CaseNo")
                    AdminToID = Session("AdminToID")
                    pnlChoose.Visible = True
                    lstSearchResults.Enabled = False
                    lstSearchResults.BorderColor = Drawing.Color.Gray
                Else
                    pnlChoose.Visible = False
                End If
            End If
        End If
        Session("IsReply") = False
    End Sub

    Protected Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        lstSearchResults.Items.Clear()
        txtPhoneNo.Text = ""
        txtLastname.Text = ""
        txtPostcode.Text = ""
        pnlChoose.Visible = True
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As New DataTable

        DB.AddParameter("@PhoneNo", txtPhoneNo.Text)
        DB.AddParameter("@Lastname", txtLastname.Text)
        DB.AddParameter("@Postcode", txtPostcode.Text)

        DB.Execute("ClientSearch")

        DT = DB.QueryResults

        Dim DTRows As Integer
        DTRows = DT.Rows.Count

        lstSearchResults.Items.Clear()

        If DTRows = 0 Then
            lstSearchResults.Items.Add("NO CLIENTS FOUND")
            lstSearchResults.BorderColor = Drawing.Color.Red
            lstSearchResults.BorderWidth = 1

        Else
            lstSearchResults.Enabled = True
            lstSearchResults.DataSource = DT
            lstSearchResults.DataTextField = "Fullname"
            lstSearchResults.DataValueField = "PhoneNo"
            lstSearchResults.DataBind()
        End If
        CaseNo = 1
    End Sub

    Protected Sub btnAllClients_Click(sender As Object, e As EventArgs) Handles btnAllClients.Click
        lblSendTo.Text = "Sending to: ALL CLIENTS"
        pnlChoose.Visible = False
    End Sub

    Protected Sub btnAdmins_Click(sender As Object, e As EventArgs) Handles btnAdmins.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As New DataTable
        DB.Execute("sp_AdminSend_ListAdmins")
        DT = DB.QueryResults
        lstSearchResults.DataSource = DT
        lstSearchResults.DataTextField = "Fullname"
        lstSearchResults.DataValueField = "AdminID"
        lstSearchResults.DataBind()
        lstSearchResults.Enabled = True
        CaseNo = 2
        Session("AdminToID") = ""
    End Sub

    Protected Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Select Case CaseNo
            Case 1
                SendTo = lstSearchResults.SelectedValue
            Case 2
                SendTo = lstSearchResults.SelectedItem.Text
                AdminToID = lstSearchResults.SelectedValue
        End Select
        lblSendTo.Text = "Sending to: " & SendTo
        Session("SendTo") = SendTo
        pnlChoose.Visible = False
    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If lblSendTo.Text = "Sending to:" Then
            lblSendTo.Text = "Sending to: No Recipient Selected"
        Else
            If lblSendTo.Text = "Sending to: ALL CLIENTS" Then
                Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                Dim DT As New DataTable
                DB.Execute("ClientLookUp")
                DT = DB.QueryResults

                Dim DTRows As Integer
                DTRows = DT.Rows.Count - 1

                For i = 0 To DTRows
                    SendTo = DT.Rows(i)("PhoneNo")
                    MsgID = ClientMsgID.Next(10000, 99999)
                    Call WriteToDB()
                Next

            Else
                Call WriteToDB()
            End If
            Response.Redirect("mail.aspx")
        End If
    End Sub

    Sub WriteToDB()
        Dim Today As Date = Format(Now(), "d")
        Select Case CaseNo
            Case 1
                MsgID = ClientMsgID.Next(10000, 99999)
                Dim DBALL As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                DBALL.AddParameter("@ClientMsgID", MsgID)
                DBALL.AddParameter("@SendTo", SendTo)
                DBALL.AddParameter("@AdminID", Session("AdminID"))
                DBALL.AddParameter("@Msg", txtMessage.Text)
                DBALL.Execute("SendToAll")
            Case 2, 3
                Dim DBAdmin As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                DBAdmin.AddParameter("@AdminMsgID", AdminMsgID.Next(10000, 99999))
                DBAdmin.AddParameter("@AdminID", AdminToID)
                DBAdmin.AddParameter("@FromID", Session("AdminID"))
                DBAdmin.AddParameter("@Msg", txtMessage.Text)
                DBAdmin.Execute("SendToAdmin")
        End Select
        Return
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

End Class

