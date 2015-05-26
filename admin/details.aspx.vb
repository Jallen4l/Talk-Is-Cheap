Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim AdminID As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdminID = Session("AdminID")
        If Session("LoggedIn") = "" Then
            Session("Error") = 1
            Response.Redirect("../global/Default.aspx")
        Else
            If Not IsPostBack Then
                Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
                Dim DT As New DataTable
                DB.AddParameter("@AdminID", AdminID)
                DB.Execute("sp_AdminDetails_CurrentDetails")
                DT = DB.QueryResults
                txtUsername.Text = Trim(DT.Rows(0)("AdminUsername"))
                txtLastName.Text = Trim(DT.Rows(0)("AdminLastName"))
                txtEmail.Text = Trim(DT.Rows(0)("AdminEmail"))
            End If
        End If
    End Sub

    Protected Sub btnSaveDetails_Click(sender As Object, e As EventArgs) Handles btnSaveDetails.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim DT As New DataTable
        DB.AddParameter("@AdminID", AdminID)
        If txtUsername.Text = "" Or txtLastName.Text = "" Or txtEmail.Text = "" Then
            If txtUsername.Text = "" Then
                txtUsername.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtUsername.BorderStyle = BorderStyle.Solid
            Else : End If
            If txtLastName.Text = "" Then
                txtLastName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtLastName.BorderStyle = BorderStyle.Solid
            Else : End If
            If txtEmail.Text = "" Then
                txtEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                txtEmail.BorderStyle = BorderStyle.Solid
            Else : End If
        Else
            DB.AddParameter("@Username", txtUsername.Text)
            Session("LoggedIn") = txtUsername.Text
            DB.AddParameter("@LastName", txtLastName.Text)
            DB.AddParameter("@Email", txtEmail.Text)
            DB.Execute("sp_AdminDetails_UpdateDetail")
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub btnSavePassword_Click(sender As Object, e As EventArgs) Handles btnSavePassword.Click
        Dim DBgetpass As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf") : Dim DTgetpass As DataTable
        DBgetpass.AddParameter("@AdminID", AdminID)
        DBgetpass.AddParameter("@Password", txtPassword.Text)
        DBgetpass.Execute("sp_AdminDetails_GetPass")
        DTgetpass = DBgetpass.QueryResults

        txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#abadb3")
        txtPassword.BorderWidth = 1
        txtNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#abadb3")
        txtNew.BorderWidth = 1
        txtConfirmNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#abadb3")
        txtConfirmNew.BorderWidth = 1

        If DTgetpass.Rows.Count = 0 Then
            txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtPassword.BorderStyle = BorderStyle.Solid
            txtPassword.BorderWidth = 2
            txtPassword.Text = "Password Incorrect"
        Else
            Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCHeapDB.mdf")
            Dim DT As New DataTable
            DB.AddParameter("@AdminID", AdminID)
            If txtPassword.Text = "" Or txtNew.Text = "" Or txtConfirmNew.Text = "" Then
                If txtPassword.Text = "" Then
                    txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                    txtPassword.BorderStyle = BorderStyle.Solid
                    txtPassword.BorderWidth = 2
                Else : End If
                If txtNew.Text = "" Then
                    txtNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                    txtNew.BorderStyle = BorderStyle.Solid
                    txtNew.BorderWidth = 2
                Else : End If
                If txtConfirmNew.Text = "" Then
                    txtConfirmNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                    txtConfirmNew.BorderStyle = BorderStyle.Solid
                    txtConfirmNew.BorderWidth = 2
                Else : End If
            Else
                Dim Compare As Integer = String.Compare(txtNew.Text, txtConfirmNew.Text)
                If Compare = 0 Then
                    DB.AddParameter("@Password", txtNew.Text)
                    DB.Execute("sp_AdminDetails_NewPassword")
                    Response.Redirect("Default.aspx")
                Else
                    txtNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                    txtNew.BorderStyle = BorderStyle.Solid
                    txtNew.Text = "Passwords do not match"
                    txtConfirmNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
                    txtConfirmNew.BorderStyle = BorderStyle.Solid
                    txtConfirmNew.Text = "Passwords do not match"
                End If
            End If
        End If
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

    Protected Sub btnSuspend_Click(sender As Object, e As EventArgs) Handles btnSuspend.Click
        Response.Redirect("suspend.aspx")
    End Sub
End Class

