<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="stylesheet" href="../assets/css/tipsy.css" />
  
    <script src="../assets/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../assets/js/jquery.tipsy.js" type="text/javascript">
        
    </script>
    <script type='text/javascript'>
        $(function () {
            $('#txtPassword').tipsy({ trigger: 'focus', gravity: 'w', fallback: "Password must be at least 8 characters" });
            $('#txtDOB').tipsy({ trigger: 'focus', gravity: 'w', fallback: "Enter your DOB as DD/MM/YYYY" });
        });
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper" style="width: 460px; padding: 0 0 20px; clear:both;">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="460px" Height="58px" CssClass="rockwell title"></asp:Label>
		</div>

		<div class="content thin" style="height: 580px;">
            <asp:Label ID="lblRequired" runat="server" style="position: relative; left:  0px; top: 0px; height: 20px; Width: 380px; text-align: center;" Text="All fields marked with an asterix are required." Width="360px"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="position: relative; left:  0px; top: 6px; height: 60px; Width: 380px; text-align: center; color: #bd362f;" Text="" Width="360px"></asp:Label>
			<br />
			<asp:Label ID="lblFirstName" runat="server" style="position: relative; left:  12px; top: 0px; height: 36px; font-weight: 700;" Text="*First Name:"></asp:Label>
		    <asp:TextBox ID="txtFirstName" runat="server" style="z-index: 1; position: relative; left: 32px; top: 0px; width: 230px; height: 32px"></asp:TextBox>

            <br />

            <asp:Label ID="lblLastName" runat="server" style="position: relative; left:  12px; top: 14px; height: 36px; font-weight: 700;" Text="*Last Name:"></asp:Label>
		    <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1; position: relative; left: 33px; top: 14px; width: 230px; height: 32px"></asp:TextBox>

            <br />

            <asp:Label ID="lblPassword" runat="server" style="position: relative; left: 12px; top: 28px; height: 36px; font-weight: 700;" Text="*Password:"></asp:Label>
		    <asp:TextBox ID="txtPassword" runat="server" style="z-index: 1; position: relative; left: 37px; top: 28px; width: 230px; height: 32px" TextMode="Password"></asp:TextBox>

            <br />

            <asp:Label ID="lblDOB" runat="server" style="position: relative; left: 12px; top: 42px; height: 36px; font-weight: 700;" Text="*Date of Birth:"></asp:Label>
		    <asp:TextBox ID="txtDOB" runat="server" style="z-index: 1; position: relative; left: 19px; top: 42px; width: 230px; height: 32px"></asp:TextBox>

            <asp:Label ID="lblGender" runat="server" style="position: relative; left: 12px; top: 56px; height: 36px; font-weight: 700;" Text="*Gender:"></asp:Label>
		    <asp:DropDownList ID="ddlGender" runat="server" style="z-index: 1; position: relative; left: 58px; top: 56px;width: 234px; height: 32px">
                <asp:ListItem>Please pick a gender</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            
            <br />
            
            <asp:Label ID="lblAddress" runat="server" style="position: relative; left: 12px; top: 70px; height: 36px; font-weight: 700;" Text="*Address:"></asp:Label>
		    <asp:TextBox ID="txtAddress" runat="server" style="z-index: 1; position: relative; left: 50px; top: 70px; width: 230px; height: 32px"></asp:TextBox>

            <br />

            <asp:Label ID="lblCity" runat="server" style="position: relative; left: 12px; top: 84px; height: 36px; font-weight: 700;" Text="*City:"></asp:Label>
		    <asp:TextBox ID="txtCity" runat="server" style="z-index: 1; position: relative; left: 84px; top: 84px; width: 230px; height: 32px"></asp:TextBox>

             <br />

             <asp:Label ID="lblPostcode" runat="server" style="position: relative; left: 12px; top: 98px; height: 36px; font-weight: 700;" Text="*Postcode:"></asp:Label>
		    <asp:TextBox ID="txtPostcode" runat="server" style="z-index: 1; position: relative; left: 41px; top: 98px; width: 230px; height: 32px"></asp:TextBox>
		    
            <br />
		    
            <asp:Label ID="lblEmail" runat="server" style="position: relative; left: 12px; top: 112px; height: 36px; font-weight: 700;" Text="*Email:"></asp:Label>
		    <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; position: relative; left: 72px; top: 112px; width: 230px; height: 32px"></asp:TextBox>


            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 14px; top: 142px; position: relative" Text="Cancel" CssClass="button std cancel"/>

		    <asp:Button ID="btnRegister" runat="server" style="z-index: 1; left: 109px; top: 142px; position: relative" Text="Choose contract" CssClass="button confirm register"/>



		</div>
	</div>
    </form>
</body>
</html>
