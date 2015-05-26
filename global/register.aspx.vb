Imports System.IO
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim RanBefore As Boolean

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("RanBefore") = RanBefore
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RanBefore = Session("RanBefore")
        If Not Page.IsPostBack Then
            If RanBefore Then
                txtFirstName.Text = Session("FirstName")
                txtLastName.Text = Session("LastName")
                txtDOB.Text = Session("DOB")
                ddlGender.Text = Session("Gender")
                txtAddress.Text = Session("Address")
                txtCity.Text = Session("City")
                txtPostcode.Text = Session("Postcode")
                txtEmail.Text = Session("Email")
            End If
        Else
            RanBefore = False
        End If
    End Sub


    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If txtFirstName.Text = "" Then
            txtFirstName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtFirstName.BorderStyle = BorderStyle.Solid
        Else : Session("FirstName") = txtFirstName.Text : End If

        If txtLastName.Text = "" Then
            txtLastName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtLastName.BorderStyle = BorderStyle.Solid
        Else : Session("LastName") = txtFirstName.Text : End If

        If txtPassword.Text = "" Then
            txtPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtPassword.BorderStyle = BorderStyle.Solid
        Else : Session("Password") = txtPassword.Text : End If

        If txtDOB.Text = "" Then
            txtDOB.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtDOB.BorderStyle = BorderStyle.Solid
        Else : Session("DOB") = txtDOB.Text : End If

        If ddlGender.Text = "Please pick a gender" Then
            ddlGender.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            ddlGender.BorderStyle = BorderStyle.Solid
            ddlGender.BorderWidth = 2
        Else : Session("Gender") = ddlGender.Text : End If

        If txtAddress.Text = "" Then
            txtAddress.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtAddress.BorderStyle = BorderStyle.Solid
        Else : Session("Address") = txtAddress.Text : End If

        If txtCity.Text = "" Then
            txtCity.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtCity.BorderStyle = BorderStyle.Solid
        Else : Session("City") = txtCity.Text : End If

        If txtPostcode.Text = "" Then
            txtPostcode.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtPostcode.BorderStyle = BorderStyle.Solid
        Else : Session("Postcode") = txtPostcode.Text : End If

        If txtEmail.Text = "" Then
            txtEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#da3610")
            txtEmail.BorderStyle = BorderStyle.Solid
        Else : Session("Email") = txtEmail.Text : End If

        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtPassword.Text = "" Or txtDOB.Text = "" Or ddlGender.Text = "Please pick a gender" Or txtAddress.Text = "" Or txtCity.Text = "" Or txtPostcode.Text = "" Or txtEmail.Text = "" Then
            lblError.Text = "Please fill in all fields"
        Else
            RanBefore = True
            Response.Redirect("contracts.aspx")
        End If

    End Sub

   
End Class

