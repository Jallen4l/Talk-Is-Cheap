Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim AdminID As String
    Dim PhoneNoGen As String
    Dim first As String
    Dim last As String
    Dim DOB As Integer
    Dim Gender As String
    Dim City As String
    Dim Postcode As String
    Dim ContractType As String
    Dim trFindLast As IO.TextReader
    Dim alFirstName As New ArrayList
    Dim alLastName As New ArrayList
    Dim alCity As New ArrayList
    Dim RandomName As New Random

    Dim lPath As String = "l:\Talk-Is-Cheap\Talk-Is-Cheap\assets\"


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdminID = Session("AdminID")
        Session("Error") = 0
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            lblDate.Text = Day(Now)
            lblDateText.Text = MonthName(Month(Now))

            Dim RandUserAmount As New Random
            If Not IsPostBack Then
                Call UserDetails()
                Call Msgs()
                Call LogInDate()
                Call Stats()
                For i = 1 To RandUserAmount.Next(0, 10)
                    Call UserGen()
                Next
            End If
        End If
    End Sub

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
    End Sub

    Sub UserDetails()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@Username", Session("LoggedIn"))
        DB.Execute("sp_AdminDefault_GetDetails")
        Dim Details As New DataTable
        Details = DB.QueryResults

        Dim DBsuspendnumber As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DBsuspendnumber.AddParameter("@AdminID", AdminID)
        DBsuspendnumber.Execute("sp_AdminDefault_SuspendLookup")
        Dim DTsuspendnumber As New DataTable
        DTsuspendnumber = DBsuspendnumber.QueryResults

        lblWelcome.Text = "Welcome back, " & Details.Rows(0)("AdminFirstname")
        lblEmail.Text = Details.Rows(0)("AdminEmail")
        lblNumbers.Text = DTsuspendnumber.Rows.Count

    End Sub

    Sub Msgs()
            Dim DBmsg As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            Dim DTmsg As New DataTable
            DBmsg.AddParameter("AdminID", AdminID)
            DBmsg.Execute("sp_AdminMail_GetMail")
            DTmsg = DBmsg.QueryResults
            If DTmsg.Rows.Count > 0 Then
                btnMail.BackColor = Drawing.Color.OrangeRed
                lblMessages.Text = DTmsg.Rows.Count
            End If
    End Sub

    Sub LogInDate()
        Dim DBdate As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTdate As New DataTable
        DBdate.AddParameter("@AdminID", AdminID)
        DBdate.Execute("sp_AdminDefault_LastLogIn")
        DTdate = DBdate.QueryResults

        If DTdate.Rows(0)("LastLogIn") = Now() Then
            lblLast.Text = DTdate.Rows(0)("LastLogIn")
        Else
            lblLast.Text = Session("LastLogIn")
        End If


        If DTdate.Rows(0)("LastLogIn") <> Now() Then
            Session("LastLogIn") = DTdate.Rows(0)("LastLogIn")
            Dim DBUpdate As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DBUpdate.AddParameter("@AdminID", AdminID)
            DBUpdate.Execute("sp_AdminDefault_UpdateLogIn")
        End If
    End Sub

    Sub Stats()
        Dim DBnewUsers As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTnewUsers As DataTable
        DBnewUsers.Execute("sp_AdminDefault_StatNewUsers")
        DTnewUsers = DBnewUsers.QueryResults
        lblNewUsers.Text = DTnewUsers.Rows.Count()

        Dim DBreturning As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTreturning As DataTable
        DBreturning.Execute("sp_AdminDefault_StatReturning")
        DTreturning = DBreturning.QueryResults
        lblReturning.Text = DTreturning.Rows.Count()

        Dim DBCalls As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTCalls As DataTable
        DBCalls.Execute("sp_AdminDefault_StatCalls")
        DTCalls = DBCalls.QueryResults
        lblCalls.Text = DTCalls.Rows.Count()

        Dim DBsms As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DTsms As DataTable
        DBsms.Execute("sp_AdminDefault_StatSMS")
        DTsms = DBsms.QueryResults
        lblTexts.Text = DTsms.Rows.Count()
    End Sub

    Sub UserGen()
        PhoneNoGen = ""
        first = ""
        last = ""
        DOB = Nothing
        Gender = ""
        City = ""
        Postcode = ""

        Dim Generator As New Random
        PhoneNoGen = "07" & Generator.Next(100, 999) & Generator.Next(100, 999) & Generator.Next(100, 999)

        Dim RandomName As New Random()
        Dim aLine As String
        Dim trFIRST As IO.TextReader = System.IO.File.OpenText(lPath & "first.txt")
        Do While trFIRST.Peek <> -1
            aLine = trFIRST.ReadLine()
            alFirstName.Add(aLine)
        Loop
        Dim FileLinesFirst() As String = Split(trFIRST.ReadToEnd(), vbCrLf)
        trFIRST.Close()
        Dim FirstLines As Integer = RandomName.Next(0, alFirstName.Count)
        first = alFirstName(FirstLines)

        Dim trLast As IO.TextReader = System.IO.File.OpenText(lPath & "last.txt")
        Do While trLast.Peek <> -1
            aLine = trLast.ReadLine()
            alLastName.Add(aLine)
        Loop
        Dim FileLinesLast() As String = Split(trLast.ReadToEnd(), vbCrLf)
        trLast.Close()
        Dim LastLines As Integer = RandomName.Next(0, alLastName.Count)
        last = alLastName(LastLines)

        
        DOB = RandomName.Next(-60, -18)

        Dim RandomGender As New Random
        If RandomGender.Next(0, 2) = 0 Then
            Gender = "Male"
        Else
            Gender = "Female"
        End If

        Dim trCity As IO.TextReader = System.IO.File.OpenText(lPath & "city.txt")
        Do While trCity.Peek <> -1
            aLine = trCity.ReadLine()
            alCity.Add(aLine)
        Loop
        Dim FileLinesCity() As String = Split(trCity.ReadToEnd(), vbCrLf)
        trCity.Close()
        Dim CityLines As Integer = RandomName.Next(0, alCity.Count)
        City = alCity(CityLines)

        Dim RandPostcode As New Random
        Dim smallPost As String = RandPostcode.Next(0, 9)
        Postcode = Left(City, 2).ToUpper() & smallPost & " " & smallPost & Left(City, 2).ToUpper()

        Call RegisterToDB()
    End Sub

    Sub RegisterToDB()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", PhoneNoGen)
        DB.AddParameter("@Firstname", first)
        DB.AddParameter("@Lastname", last)
        DB.AddParameter("@Passcode", "password")
        DB.AddParameter("@DOB", DOB)
        DB.AddParameter("@Gender", Gender)
        DB.AddParameter("@Addr", "1 Test Street")
        DB.AddParameter("@City", City)
        DB.AddParameter("@Postcode", Postcode)
        DB.AddParameter("@Email", "P10539448@myemail.dmu.ac.uk")
        DB.Execute("sp_Contracts_RegisterDetails")

        Call AccountToDB()
    End Sub

    Sub AccountToDB()
        Dim IDGenerator As New Random
        Dim AccountID As Integer

        AccountID = IDGenerator.Next(10000, 99999)

        Dim MinutesLeft As Integer
        Dim TextsLeft As Integer
        Dim Overdrawn As Integer = 0

        Dim ContractGen As New Random
        Dim ContractNo As Integer = ContractGen.Next(0, 100)
        If ContractNo >= 0 And ContractNo <= 24 Then
            ContractType = "Basic"
            MinutesLeft = 25
            TextsLeft = 25
        ElseIf ContractNo >= 25 And ContractNo <= 54 Then
            ContractType = "Standard"
            MinutesLeft = 100
            TextsLeft = 200
        ElseIf ContractNo >= 55 And ContractNo <= 80 Then
            ContractType = "Premium"
            MinutesLeft = 200
            TextsLeft = 1000
        ElseIf ContractNo >= 81 And ContractNo <= 94 Then
            ContractType = "Ultimate"
            MinutesLeft = 1000
            TextsLeft = 1000
        ElseIf ContractNo >= 95 And ContractNo <= 100 Then
            ContractType = "International"
            MinutesLeft = 400
            TextsLeft = 200
        End If

        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@AccountID", AccountID)
        DB.AddParameter("@PhoneNo", PhoneNoGen)
        DB.AddParameter("@ContractType", ContractType)
        DB.AddParameter("@MinutesLeft", MinutesLeft)
        DB.AddParameter("@TextsLeft", TextsLeft)
        DB.AddParameter("@Overdrawn", Overdrawn)
        DB.Execute("sp_Contracts_RegisterAccount")

        AccountID = Nothing

        Call ClearSessions()
    End Sub


    Sub ClearSessions()
        Session("PhoneNo") = Nothing
        Session("FirstName") = Nothing
        Session("LastName") = Nothing
        Session("Password") = Nothing
        Session("DOB") = Nothing
        Session("Gender") = Nothing
        Session("Address") = Nothing
        Session("City") = Nothing
        Session("Postcode") = Nothing
        Session("Email") = Nothing
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

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Response.Redirect("../admin/details.aspx")
    End Sub

    Protected Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Response.Redirect("../admin/reports.aspx")
    End Sub

    Protected Sub btnAddAdmin_Click(sender As Object, e As EventArgs) Handles btnAddAdmin.Click
        Response.Redirect("../admin/admins.aspx")
    End Sub
End Class

