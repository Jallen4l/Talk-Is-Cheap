Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim ClientDT As New DataTable
    Dim AdminDT As New DataTable

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("LoggedIn") = txtUsername.Text
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim CaseNo As Integer = Session("Error")
        txtUsername.BorderColor = System.Drawing.ColorTranslator.FromHtml("#abadb3")
        txtUsername.BorderWidth = 1
        txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#abadb3")
        txtPassword.BorderWidth = 1
        Select Case CaseNo
            Case 1
                txtUsername.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtUsername.BorderStyle = BorderStyle.Solid
                txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPassword.BorderStyle = BorderStyle.Solid
                lblError.Text = "You must log in first"
            Case 2
                lblError.Text = "Please check your email for your username. This may take a few minutes."
            Case 3
                lblError.Text = "Your contract has ended. Please renew your contract to log in."
            Case Nothing
                ChangeHeight.Style.Add("height", "240px")
        End Select
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        For i = 1 To 20
            Call ClientLogIn()
            Call AdminLogIn()
            If ClientDT.Rows.Count > 0 Then
                Response.Redirect("/Talk-Is-Cheap/client/Default.aspx")
            ElseIf AdminDT.Rows.Count > 0 Then
                Session("AdminID") = AdminDT.Rows(0)("AdminID")
                Response.Redirect("/Talk-Is-Cheap/admin/Default.aspx")
            Else : lblError.Text = "Either your Username or Password is incorrect."
                txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtPassword.BorderStyle = BorderStyle.Solid
            End If
        Next
    End Sub

    Public Sub ClientLogIn()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@PhoneNo", txtUsername.Text)
        DB.AddParameter("@Passcode", txtPassword.Text)
        DB.Execute("sp_Login_ClientLogin")
        ClientDT = DB.QueryResults
    End Sub
    Public Sub AdminLogIn()
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        DB.AddParameter("@AdminUsername", txtUsername.Text)
        DB.AddParameter("@AdminPassword", txtPassword.Text)
        DB.Execute("sp_Login_AdminLogin")
        AdminDT = DB.QueryResults
    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Response.Redirect("register.aspx")
    End Sub

    Protected Sub btnPasswordReminder_Click(sender As Object, e As EventArgs) Handles btnPasswordReminder.Click
        Response.Redirect("forgot.aspx")
    End Sub
End Class

