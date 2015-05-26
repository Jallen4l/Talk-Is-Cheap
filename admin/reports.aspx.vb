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

    Protected Sub btnSuspend_Click(sender As Object, e As EventArgs) Handles btnSuspend.Click
        Response.Redirect("suspend.aspx")
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
                    doc.WriteLine("<td>" & "Phone Number" & "</td>")
                    doc.WriteLine("<td>" & "First Name" & "</td>")
                    doc.WriteLine("<td>" & "Last Name" & "</td>")
                    doc.WriteLine("<td>" & "Email" & "</td>")
                    doc.WriteLine("<td>" & "Postcode" & "</td>")
                Case 2
                    doc.WriteLine("<td>" & "Phone Number" & "</td>")
                    doc.WriteLine("<td>" & "First Name" & "</td>")
                    doc.WriteLine("<td>" & "Last Name" & "</td>")
                    doc.WriteLine("<td>" & "Email" & "</td>")
                    doc.WriteLine("<td>" & "Start Date" & "</td>")
                Case 3
                    doc.WriteLine("<td>" & "Phone Number" & "</td>")
                    doc.WriteLine("<td>" & "Dialled Number" & "</td>")
                    doc.WriteLine("<td>" & "Call Length" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 4
                    doc.WriteLine("<td>" & "Phone Number" & "</td>")
                    doc.WriteLine("<td>" & "Recipient Number" & "</td>")
                    doc.WriteLine("<td>" & "Date And Time" & "</td>")
                Case 5
                    doc.WriteLine("<td>" & "Phone Number" & "</td>")
                    doc.WriteLine("<td>" & "Suspend Date" & "</td>")
                    doc.WriteLine("<td>" & "Reason" & "</td>")
            End Select

            doc.WriteLine("</tr>")

            Select Case CaseNo
                Case 1
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("PhoneNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Firstname") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Lastname") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("EmailAddress") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Postcode") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 2
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("PhoneNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Firstname") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Lastname") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("EmailAddress") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("AccountStartDate") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 3
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("PhoneNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DialedNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Length") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 4
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("PhoneNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("RecipientNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("DateAndTime") & "</td>")
                        doc.WriteLine("</tr>")
                    Next
                Case 5
                    For i = 1 To DT.Rows.Count() - 1
                        doc.WriteLine("<tr>")
                        doc.WriteLine("<td>" & DT.Rows(i)("PhoneNo") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Suspend Date") & "</td>")
                        doc.WriteLine("<td>" & DT.Rows(i)("Reason") & "</td>")
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

    Protected Sub btnAllUsers_Click(sender As Object, e As EventArgs) Handles btnAllUsers.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_AllUsers")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "ALL_USERS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 1
        ReportName = "All Users - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnNewUsersMonth_Click(sender As Object, e As EventArgs) Handles btnNewUsersMonth.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_MonthNewUsers")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "LAST_MONTHS_NEW_USERS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 2
        ReportName = "Last Months New Users - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnAllCalls_Click(sender As Object, e As EventArgs) Handles btnAllCalls.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_AllOutgoing")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "ALL_OUTGOING_CALLS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 3
        ReportName = "All Outgoing Calls - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnCallsLastMonth_Click(sender As Object, e As EventArgs) Handles btnCallsLastMonth.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_LastMonthOutgoingCalls")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "LAST_MONTHS_OUTGOING_CALLS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 3
        ReportName = "Last Months Outgoing Calls - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnAllTexts_Click(sender As Object, e As EventArgs) Handles btnAllTexts.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_AllTexts")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "ALL_SENT_TEXTS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 4
        ReportName = "All Sent Texts - Up until " & Now().ToString("dd-mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnTextsLastMonth_Click(sender As Object, e As EventArgs) Handles btnTextsLastMonth.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_LastMonthSentTexts")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "LAST_MONTHS_SENT_TEXTS_" & Now().ToString("mm-yyyy") & ".html"
        CaseNo = 4
        ReportName = "Last Months Sent Texts - Month of " & Now().ToString("mm-yyyy")
        Call ReportGen(report, DT)
    End Sub

    Protected Sub btnSuspendedUsers_Click(sender As Object, e As EventArgs) Handles btnSuspendedUsers.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.Execute("sp_AdminReport_Suspend")
        DT = DB.QueryResults
        Dim report As String
        report = lPath & "ALL_SUSPENDED_ACCOUNTS_" & Now().ToString("dd-mm-yyyy") & ".html"
        CaseNo = 5
        ReportName = "All Suspended Accounts - Month of " & Now().ToString("dd-mm-yyyy") & ".html"
        Call ReportGen(report, DT)
    End Sub

End Class

