Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim DT As DataTable
    Dim CaseNo As Integer
    Dim ReportName As String
    Dim lPath As String = "L:\Talk-Is-Cheap\Talk-Is-Cheap\reports\"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("LoggedIn") = "" Then
            'If user is NOT logged in an error will appear
            Session("Error") = 1
            'Return to login screen (Global default)
            Response.Redirect("../global/Default.aspx")
        Else
            'this will populate the list box, only if not is post back
            If Not IsPostBack Then
                lstOldReports.Items.Clear()
                Call PopList()
            End If
        End If
    End Sub

    Protected Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpen.Click
        'Error if no item is selected 
        If lstOldReports.SelectedItem Is Nothing Then
            lblConfirmError.Text = "Select a Report"
        Else
            'if item IS selected, the item selected will start
            Dim Selected As String
            Selected = lPath & lstOldReports.SelectedItem.ToString
            Diagnostics.Process.Start(Selected)
            lstOldReports.Items.Clear()
            Call PopList()
        End If
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        'error if no item is selected
        If lstOldReports.SelectedItem Is Nothing Then
            lblConfirmError.Text = "Select a Report"
        Else
            'the selected item is then deleted from the list box and computer
            My.Computer.FileSystem.DeleteFile(lPath & lstOldReports.SelectedItem.ToString)
            lstOldReports.Items.Clear()
            Call PopList()
        End If
    End Sub

    Sub PopList()
        'get all reports located in the reports folder
        For Each i As String In Directory.GetFiles(lPath)
            lstOldReports.Items.Add(Path.GetFileName(i))
        Next
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogout.Click
        'Logout button takes you to the login
        Response.Redirect("../global/Default.aspx")
    End Sub

    Protected Sub btnMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMail.Click
        'Help button takes you to the mail portal
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help button takes you to the help portal
        Response.Redirect("help.aspx")
    End Sub

    Sub ReportGen(ByVal report As String, ByVal DT As DataTable)
        Using doc As New StreamWriter(report)
            doc.WriteLine("<!DOCTYPE html>")
            doc.WriteLine("<html lang='en'>")
            doc.WriteLine("<head>")
            doc.WriteLine("<title>" & report & "</title>")
            doc.WriteLine("<link rel=" & Chr(34) & "stylesheet" & Chr(34) & "href=" & Chr(34) & "../assets/css/main.css" & Chr(34) & "/>")
            doc.WriteLine("</head>")
            doc.WriteLine("<body>")
            doc.WriteLine("<div id=" & Chr(34) & "wrapper" & Chr(34) & ">")
            doc.WriteLine("<div id=" & Chr(34) & "header" & Chr(34) & ">")
            doc.WriteLine("<div class=" & Chr(34) & "title rockwell" & Chr(34) & "style=" & Chr(34) & "padding: 20px 0;" & Chr(34) & ">Talk-Is-Cheap</div>")
            doc.WriteLine("</div>")
            doc.WriteLine("<div class=" & Chr(34) & "content" & Chr(34) & ">")
            doc.WriteLine("<p class=" & Chr(34) & "welcome rockwell" & Chr(34) & "style=" & Chr(34) & "padding: 0 0 20px;" & "font-size: 28px;" & "text-align: center;" & Chr(34) & ">" & ReportName & "</p>")
            doc.WriteLine("<table border=" & Chr(34) & "0" & Chr(34) & "width=" & Chr(34) & "100%" & Chr(34) & ">")
            doc.WriteLine("<tr>")
            Select Case CaseNo
                Case 1
                    doc.WriteLine("<td>" & "Dialled Number" & "</td>")
                    doc.WriteLine("<td>" & "Call Length" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 2
                    doc.WriteLine("<td>" & "Incoming Number" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 3
                    doc.WriteLine("<td>" & "Recipient" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 4
                    doc.WriteLine("<td>" & "Sender" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 5
                    doc.WriteLine("<td>" & "Dialled Number" & "</td>")
                    doc.WriteLine("<td>" & "Call Length" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 6
                    doc.WriteLine("<td>" & "Incoming Number" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 7
                    doc.WriteLine("<td>" & "Recipient" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 8
                    doc.WriteLine("<td>" & "Sender" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
            End Select

            doc.WriteLine("</tr>")

            Select CaseNo
                Case 1
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DialedNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Length") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 2
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("IncomingNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 3
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("RecipientNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 4
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("SenderNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 5
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DialedNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Length") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 6
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("IncomingNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 7
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("RecipientNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 8
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("SenderNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
            End Select

            doc.WriteLine("</table>")
            doc.WriteLine("</div>")
            doc.WriteLine("</div>")
            doc.WriteLine("</body>")
            doc.Write("</html>")
        End Using
        lstOldReports.Items.Clear()
        Call PopList()
        Diagnostics.Process.Start(report)
    End Sub

    Protected Sub btnOutgoingCalls_Click(sender As Object, e As EventArgs) Handles btnOutgoingCalls.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_AllOutgoing")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "ALL_OUTGOING_CALLS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 1
        ReportName = "All Outgoing Calls - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnIncomingCalls_Click(sender As Object, e As EventArgs) Handles btnIncomingCalls.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_AllIncoming")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "ALL_INCOMING_CALLS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 2
        ReportName = "All Incoming Calls - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnSentSMS_Click(sender As Object, e As EventArgs) Handles btnSentSMS.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_AllSent")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "ALL_SENT_TEXTS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 3
        ReportName = "All Sent Texts - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnRecievedSMS_Click(sender As Object, e As EventArgs) Handles btnRecievedSMS.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_AllRecieved")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "ALL_RECEIVED_TEXTS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 4
        ReportName = "All Recieved Texts - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnLastOutgoing_Click(sender As Object, e As EventArgs) Handles btnLastOutgoing.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_LastMonthOutgoingCalls")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "LAST_MONTHS_OUTGOING_CALLS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 5
        ReportName = "Last Months Outgoing Calls - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnLastIncoming_Click(sender As Object, e As EventArgs) Handles btnLastIncoming.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_LastMonthIncomingCalls")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "LAST_MONTHS_INCOMING_CALLS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 6
        ReportName = "Last Months Incoming Calls - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnLastSent_Click(sender As Object, e As EventArgs) Handles btnLastSent.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_LastMonthSentTexts")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "LAST_MONTHS_SENT_TEXTS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 7
        ReportName = "Last Months Sent Texts - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnLastRecieved_Click(sender As Object, e As EventArgs) Handles btnLastRecieved.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientReport_LastMonthRecievedTexts")
        DT = DB.QueryResults

        Dim report As String
        report = lPath & "LAST_MONTHS_RECEIVED_TEXTS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 8
        ReportName = "Last Months Received Texts - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub
End Class

