Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    'create database object
    Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
    'Dim Gen As New nsPhonecallgen.clsPhoneCallGen("Basic")

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Onload check that user has logged in
        If Session("LoggedIn") = "" Then
            'If user is NOT logged in an error will appear
            Session("Error") = 1
            'Return to login screen (Global default)
            Response.Redirect("../global/Default.aspx")
        Else
            'create database object
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            'Add parameter of currently logged in users PhoneNo
            DB.AddParameter("@ClientPhoneNo", Session("LoggedIn"))
            'Excecute procedure "ClientDetails"
            DB.Execute("sp_ClientDefault_ClientDetails")
            'Create new data table to store details
            Dim Details As New DataTable
            'Populate datatable with results from the procedure
            Details = DB.QueryResults
            If Details.Rows(0)("ContractEndDate") <= Now() Then
                Session("ContractRenew") = 1
                Response.Redirect("../global/contracts.aspx")
            End If
            'Call function to generate call(s)
            Call GenerateCall()
            'Call function to generate text(s)
            Call GenerateText()
            'Lable welcomes user using the firstname they registered with
            lblWelcome.Text = "Welcome back, " & Details.Rows(0)("Firstname")
            Session("ClientDetails") = Details.Rows(0)("ContractType")
        End If


        'Create new data table
        Dim ClientTileDetailsDT As New DataTable
        'Create new parameter using session object
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        'Execute the procedure "ClientTileDetails"
        DB.Execute("sp_ClientDefault_TileDetails")
        'Populate data table with procedure results
        ClientTileDetailsDT = DB.QueryResults
        'Set lable text to the value contained in the session object
        lblPhoneNo.Text = Session("LoggedIn")
        'set lable text to value located in the datatable, index value 0 and field name
        lblContactType.Text = Trim(ClientTileDetailsDT.Rows(0)("ContractType"))
        lblContractEnd.Text = ClientTileDetailsDT.Rows(0)("ContractEndDate")
        lblEmail.Text = ClientTileDetailsDT.Rows(0)("EmailAddress")
        'set lable text to the value located in the datatable, index value 0 and field name minus another value in the data table
        lblMinutesLeft.Text = ClientTileDetailsDT.Rows(0)("MinutesLeft")
        'set the lable text to the number of items foudn in the data table
        lblCallsMade.Text = ClientTileDetailsDT.Rows.Count()

        'create database object
        Dim DBText As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'Create new data table
        Dim ClientTextDetailsDT As New DataTable
        'create parameter using the session object
        DBText.AddParameter("@PhoneNo", Session("LoggedIn"))
        'execute procedure "Textdetails"
        DBText.Execute("sp_ClientDefault_TextDetails")
        'Populate data table with results of procedure
        ClientTextDetailsDT = DBText.QueryResults
        'Create varible to hold the amount of texts sent
        Dim Texts As Integer
        'Assign the amount of items in the datatable to variable
        Texts = ClientTextDetailsDT.Rows.Count()
        'set lable text to the amount of texts left minus the amount of texts sent (located in varible)
        lblTextsLeft.Text = ClientTextDetailsDT.Rows(0)("TextsLeft") - Texts
        'set lable text to the amount of items located in the data table
        lblTextsMade.Text = ClientTextDetailsDT.Rows.Count()
        'If the lable contract type is e.g basic it will show the amount needed to pay for that month
        Dim MinutesPerMonth, TextsPerMonth As Integer
        If lblContactType.Text = "Basic" Then
            lblBil.Text = "£5"
            MinutesPerMonth = 25
            TextsPerMonth = 25
        ElseIf lblContactType.Text = "Standard" Then
            lblBil.Text = "£20"
            MinutesPerMonth = 100
            TextsPerMonth = 200
        ElseIf lblContactType.Text = "Premium" Then
            lblBil.Text = "£30"
            MinutesPerMonth = 200
            lblTextsLeft.Text = "∞"
        ElseIf lblContactType.Text = "Unlimited" Then
            lblBil.Text = "£50"
            lblMinutesLeft.Text = "∞"
            lblTextsLeft.Text = "∞"
        ElseIf lblContactType.Text = "International" Then
            lblBil.Text = "£40"
            MinutesPerMonth = 400
            TextsPerMonth = 200
        End If
        'Sets lable text to how many days remain in the month
        lblDaysLeft.Text = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - Day(Now)


        pnlMinutesLeft.BackColor = System.Drawing.ColorTranslator.FromHtml("#51a351")
        pnlCallsMade.BackColor = System.Drawing.ColorTranslator.FromHtml("#51a351")
        pnlTextsLeft.BackColor = System.Drawing.ColorTranslator.FromHtml("#51a351")
        pnlTextsMade.BackColor = System.Drawing.ColorTranslator.FromHtml("#51a351")

        'if statement to change the colour of the boxes to represent minutes and texts left.
        If Not lblMinutesLeft.Text = "∞" Then
            If lblMinutesLeft.Text < 5 Then
                pnlMinutesLeft.BackColor = System.Drawing.ColorTranslator.FromHtml("#bd362f")
            End If
            If lblCallsMade.Text > (MinutesPerMonth - 5) Then
                pnlCallsMade.BackColor = System.Drawing.ColorTranslator.FromHtml("#bd362f")
            End If
        End If

        If Not lblTextsLeft.Text = "∞" Then
            If lblTextsLeft.Text < 5 Then
                pnlTextsLeft.BackColor = System.Drawing.ColorTranslator.FromHtml("#bd362f")
            End If
            If lblTextsMade.Text > (TextsPerMonth - 5) Then
                pnlTextsMade.BackColor = System.Drawing.ColorTranslator.FromHtml("#bd362f")
            End If
        End If
        Call Msgs()
    End Sub

    Sub Msgs()
        'create database object
        Dim DBmsg As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'create datatable
        Dim DTmsg As New DataTable
        'add parameter 
        DBmsg.AddParameter("PhoneNo", Session("LoggedIn"))
        'execute stored procedure
        DBmsg.Execute("sp_ClientMail_GetMail")
        'populate datatable with results
        DTmsg = DBmsg.QueryResults
        'if there's something in the datatable then change the colour of the mail button
        If DTmsg.Rows.Count > 0 Then
            btnMail.BackColor = Drawing.Color.OrangeRed
        End If
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        'Home button returns to the client default page
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        'logout button takes you to the login page (global default)
        Response.Redirect("../global/Default.aspx")
    End Sub

    Protected Sub btnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        'Mail button takes you to the mail portal
        Response.Redirect("mail.aspx")
    End Sub

    Protected Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help button takes you to the help portal
        Response.Redirect("help.aspx")
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Edit button take you to the edit details page
        Response.Redirect("details.aspx")
    End Sub

    Protected Sub btnActivity_Click(sender As Object, e As EventArgs) Handles btnActivity.Click
        'Activity button takes you to the reports portal
        Response.Redirect("activity.aspx")
    End Sub
    Public Function GenerateCall() As String
        'Create variables
        Dim Calls As Integer
        Dim Generator As New Random
        'create database object
        Dim DBContractType As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'Create new datatable
        Dim dtContractType As New DataTable
        Dim Contract As String
        'create parameter using session object
        DBContractType.AddParameter("@UserPhoneNo", Session("LoggedIn"))
        'execute procedure "getcontracttype"
        DBContractType.Execute("sp_ClientDefault_GetContractType")
        'populate data table with results from procedure 
        dtContractType = DBContractType.QueryResults
        'assign varibale contract the value located in data table 
        Contract = Trim(dtContractType.Rows(0)("ContractType"))
        'if statement to use a random generator based on which contract the user is on
        If Contract = "Basic" Then
            Calls = Generator.Next(0, 2)
        ElseIf Contract = "Standard" Then
            Calls = Generator.Next(0, 5)
        ElseIf Contract = "Premium" Then
            Calls = Generator.Next(0, 20)
        ElseIf Contract = "Unlimited" Then
            Calls = Generator.Next(0, 45)
        ElseIf Contract = "International" Then
            Calls = Generator.Next(0, 30)
        End If
        'loop
        'create database object
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'create database object
        Dim DBupdateCalls As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'for loop that will randomly generate call data, put them in a parameter and insert them into the database
        For i = 0 To Calls
            Dim Length As Integer = Generator.Next(0, 10)
            Dim Success As Integer
            DB.AddParameter("@OutgoingID", Generator.Next(10000, 99999))
            DB.AddParameter("@DialedNo", "07" & Generator.Next(100, 999) & Generator.Next(100, 999) & Generator.Next(100, 999))
            DB.AddParameter("@Prefix", Generator.Next(1, 99))
            DB.AddParameter("@Length", Length)
            DB.AddParameter("@Date", Generator.Next(-30, -0))
            If Length = 0 Then : Success = 0 : Else : Success = 1 : End If
            DB.AddParameter("@Successful", Success)
            DB.AddParameter("@UserPhoneNo", Session("LoggedIn"))
            DB.Execute("sp_ClientDefault_CallGenerator")
            DB.WriteToDatabase()

            DBupdateCalls.AddParameter("@Length", Length)
            DBupdateCalls.AddParameter("@UserPhoneNo", Session("LoggedIn"))
            DBupdateCalls.Execute("sp_ClientDefault_AccountCallUpdate")
            DBupdateCalls.WriteToDatabase()

        Next
        Return 0
    End Function

    Public Function GenerateText() As String
        Dim Texts As Integer
        Dim Generator As New Random
        'create database object
        Dim DBContractType As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'create new datatable
        Dim dtContractType As New DataTable
        Dim Contract As String
        DBContractType.AddParameter("@UserPhoneNo", Session("LoggedIn"))
        DBContractType.Execute("sp_ClientDefault_GetContractType")
        dtContractType = DBContractType.QueryResults
        Contract = Trim(dtContractType.Rows(0)("ContractType"))
        'if statement to use a random generator based on which contract the user is on
        If Contract = "Basic" Then
            Texts = Generator.Next(0, 2)
        ElseIf Contract = "Standard" Then
            Texts = Generator.Next(0, 5)
        ElseIf Contract = "Premium" Then
            Texts = Generator.Next(0, 20)
        ElseIf Contract = "Unlimited" Then
            Texts = Generator.Next(0, 45)
        ElseIf Contract = "International" Then
            Texts = Generator.Next(0, 30)
        End If
        'create database object
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DBupdateTexts As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        'for loop that will randomly generate data, put them in a parameter and insert them into the database
        For i = 0 To Texts
            DB.AddParameter("@SendID", Generator.Next(10000, 99999))
            DB.AddParameter("@DialedNo", "07" & Generator.Next(100, 999) & Generator.Next(100, 999) & Generator.Next(100, 999))
            DB.AddParameter("@Date", Generator.Next(-30, -0))
            DB.AddParameter("@Successful", Generator.Next(0, 2))
            DB.AddParameter("@UserPhoneNo", Session("LoggedIn"))
            DB.Execute("sp_ClientDefault_TextGenerator")
            DB.WriteToDatabase()

            DBupdateTexts.AddParameter("@UserPhoneNo", Session("LoggedIn"))
            DBupdateTexts.Execute("sp_ClientDefault_AccountTextUpdate")
        Next
        Return 0
    End Function
End Class

