Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim PhoneNoGen As String
    Dim RandomNo As New Random

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ContractRenew") = 1 Then
            lblContract.Text = "Your contract has ended. Please renew your contract."
            lblContract.ForeColor = System.Drawing.ColorTranslator.FromHtml("#bd362f")
            Session("Error") = 3
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Session("Error") = 3 Then
            Response.Redirect("Default.aspx")
        Else
            Response.Redirect("register.aspx")
        End If
    End Sub

    Protected Sub btnSelectBasic_Click(sender As Object, e As EventArgs) Handles btnSelectBasic.Click
        If Session("Error") = 3 Then
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@ContractType", "Basic")
            DB.Execute("sp_Contracts_UpdateContract")
        Else
            Session("ContractType") = "Basic"
            Call RegisterToDB()
            Call AccountToDB()
        End If
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnSelectStandard_Click(sender As Object, e As EventArgs) Handles btnSelectStandard.Click
        If Session("Error") = 3 Then
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@ContractType", "Standard")
            DB.Execute("sp_Contracts_UpdateContract")
        Else
            Session("ContractType") = "Standard"
            Call RegisterToDB()
            Call AccountToDB()
        End If
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnSelectPremium_Click(sender As Object, e As EventArgs) Handles btnSelectPremium.Click
        If Session("Error") = 3 Then
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@ContractType", "Premium")
            DB.Execute("sp_Contracts_UpdateContract")
        Else
            Session("ContractType") = "Premium"
            Call RegisterToDB()
            Call AccountToDB()
        End If
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnSelectUnlimited_Click(sender As Object, e As EventArgs) Handles btnSelectUnlimited.Click
        If Session("Error") = 3 Then
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@ContractType", "Unlimited")
            DB.Execute("sp_Contracts_UpdateContract")
        Else
            Session("ContractType") = "Unlimited"
            Call RegisterToDB()
            Call AccountToDB()
        End If
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnSelectInternational_Click(sender As Object, e As EventArgs) Handles btnSelectInternational.Click
        If Session("Error") = 3 Then
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
            DB.AddParameter("@ContractType", "International")
            DB.Execute("sp_Contracts_UpdateContract")
        Else
            Session("ContractType") = "International"
            Call RegisterToDB()
            Call AccountToDB()
        End If
        Response.Redirect("Default.aspx")
    End Sub

    Sub RegisterToDB()
        Dim Generator As New Random

        PhoneNoGen = "07" & Generator.Next(100, 999) & Generator.Next(100, 999) & Generator.Next(100, 999)

        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")

        DB.AddParameter("@PhoneNo", PhoneNoGen)
        DB.AddParameter("@Firstname", Session("Firstname"))
        DB.AddParameter("@Lastname", Session("Lastname"))
        DB.AddParameter("@Passcode", Session("Password"))
        DB.AddParameter("@DOB", RandomNo.Next(-60, -18))
        DB.AddParameter("@Gender", Session("Gender"))
        DB.AddParameter("@Addr", Session("Address"))
        DB.AddParameter("@City", Session("City"))
        DB.AddParameter("@Postcode", Session("Postcode"))
        DB.AddParameter("@Email", Session("Email"))

        DB.Execute("sp_Contracts_RegisterDetails")
    End Sub

    Sub AccountToDB()
        Dim IDGenerator As New Random
        Dim AccountID As String

        AccountID = IDGenerator.Next(10000, 99999)

        Dim MinutesLeft As Integer
        Dim TextsLeft As Integer
        Dim Overdrawn As Integer = 0

        If Session("ContractType") = "Basic" Then
            MinutesLeft = 30
            TextsLeft = 50
        ElseIf Session("ContractType") = "Standard" Then
            MinutesLeft = 120
            TextsLeft = 200
        ElseIf Session("ContractType") = "Premium" Then
            MinutesLeft = 240
            TextsLeft = 999999999
        ElseIf Session("ContractType") = "Unlimited" Then
            MinutesLeft = 999999999
            TextsLeft = 999999999
        ElseIf Session("ContractType") = "International" Then
            MinutesLeft = 600
            TextsLeft = 200
        End If

        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")

        DB.AddParameter("@AccountID", AccountID)
        DB.AddParameter("@PhoneNo", PhoneNoGen)
        DB.AddParameter("@ContractType", Session("ContractType"))
        DB.AddParameter("@MinutesLeft", MinutesLeft)
        DB.AddParameter("@TextsLeft", TextsLeft)
        DB.AddParameter("@Overdrawn", Overdrawn)

        DB.Execute("sp_Contracts_RegisterAccount")

        Dim SMTPServer As New System.Net.Mail.SmtpClient("mail.cse.dmu.ac.uk")
        Dim Message As New System.Net.Mail.MailMessage("noreply@dmu.ac.uk", Session("Email"), "Talk-is-Cheap: Your new number!", "Your username/phone number is: " & PhoneNoGen & " and your password is: " & Session("Password"))
        SMTPServer.Send(Message)

        Session("Error") = 2
        Call ClearSessions()
        Response.Redirect("Default.aspx")
    End Sub

    Sub ClearSessions()
        Session("PhoneNo") = ""
        Session("FirstName") = ""
        Session("LastName") = ""
        Session("Password") = ""
        Session("DOB") = ""
        Session("Gender") = ""
        Session("Address") = ""
        Session("City") = ""
        Session("Postcode") = ""
        Session("Email") = ""
    End Sub
End Class

