Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim dtCurrentDetails As New DataTable
        DB.AddParameter("@PhoneNo", Session("LoggedIn"))
        DB.Execute("sp_ClientDetails_CurrentDetails")
        dtCurrentDetails = DB.QueryResults

        If Page.IsPostBack = False Then
            txtFirstname.Text = Trim(dtCurrentDetails.Rows(0)("FirstName"))
            txtAddress.Text = Trim(dtCurrentDetails.Rows(0)("Addr"))
            txtCity.Text = Trim(dtCurrentDetails.Rows(0)("City"))
            txtPostcode.Text = Trim(dtCurrentDetails.Rows(0)("Postcode"))
            txtEmail.Text = Trim(dtCurrentDetails.Rows(0)("EmailAddress"))
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

    Protected Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Response.Redirect("help.aspx")
    End Sub

    Protected Sub btnSaveDetails_Click(sender As Object, e As EventArgs) Handles btnSaveDetails.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        If txtFirstname.Text = "" Then
            txtFirstname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
        ElseIf txtAddress.Text = "" Then
            txtAddress.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
        ElseIf txtCity.Text = "" Then
            txtCity.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
        ElseIf txtPostcode.Text = "" Then
            txtPostcode.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
        ElseIf txtEmail.Text = "" Then
            txtEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
        Else
            DB.AddParameter("@PhoneNo", Session("LoggedIn"))
            DB.AddParameter("@Firstname", txtFirstname.Text)
            DB.AddParameter("@Gender", ddlGender.SelectedValue)
            DB.AddParameter("@Addr", txtAddress.Text)
            DB.AddParameter("@City", txtCity.Text)
            DB.AddParameter("@Postcode", txtPostcode.Text)
            DB.AddParameter("@Email", txtEmail.Text)
        End If

        DB.Execute("sp_ClientDetails_UpdateDetails")

        DB.WriteToDatabase()
        Response.Redirect("Default.aspx")


    End Sub

    Protected Sub btnSavePassword_Click(sender As Object, e As EventArgs) Handles btnSavePassword.Click
        Dim DB As New nsDataBasePortal.clsSQLServer("TalkIsCheapDB.mdf")
        Dim NewPassword As String

        If txtNew.Text = txtNew2.Text Then
            NewPassword = txtNew.Text
            DB.AddParameter("@PhoneNo", Session("LoggedIn"))
            DB.AddParameter("@PasswordNew", NewPassword)
            DB.AddParameter("@PasswordOld", txtOld.Text)
            DB.Execute("sp_ClientDetails_UpdatePassword")
            DB.WriteToDatabase()
            Response.Redirect("Default.aspx")
        Else
            lblError.Text = "New passwords do not match."
            txtNew.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtNew.BorderStyle = BorderStyle.Solid
            txtNew2.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtNew2.BorderStyle = BorderStyle.Solid
        End If
    End Sub
End Class

