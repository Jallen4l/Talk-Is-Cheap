<%@ Page Language="VB" AutoEventWireup="false" CodeFile="details.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/main.css" />
    <link rel="stylesheet" href="../assets/css/client.css" />
    <link rel="stylesheet" href="../assets/css/tipsy.css" />
  
    <script src="../assets/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../assets/js/jquery.tipsy.js" type="text/javascript">
        
    </script>
    <script type='text/javascript'>
        $(function () {
            $('#btnHome').tipsy({ gravity: 'e', fallback: "Home" });
            $('#btnMail').tipsy({ gravity: 'w', fallback: "Messages" });
            $('#btnHelp').tipsy({ gravity: 'e', fallback: "Help" });
            $('#btnLogout').tipsy({ gravity: 'w', fallback: "Logout" });
        });
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
		<div class="header">
            <asp:Label ID="lblTitle" runat="server" style="z-index: 3; left: 0px; top: 18px; position: relative;" Text="Talk-Is-Cheap" Width="960px" Height="58px" CssClass="rockwell title"></asp:Label>
			<asp:Button ID="btnHome" runat="server" style="z-index: 5; left: 0px; top: -31px; position: relative" Text="" CssClass="button std home" />
            <asp:Button ID="btnMail" runat="server" style="z-index: 5; left: 5px; top: -31px; position: relative" Text="" CssClass="button std mail"/>
            <asp:Button ID="btnHelp" runat="server" style="z-index: 5; right: -751px; top: -31px; position: relative" Text="" CssClass="button std help"/>
            <asp:Button ID="btnLogout" runat="server" style="z-index: 5; right: -756px; top: -31px; position: relative" Text="" CssClass="button std logout"/>
		</div>

		<div class="content" style="height:440px;">
            <asp:Panel ID="pnlDetails" runat="server" style="z-index: 1; left: 0px; top: 0px; position: relative; height: 275px; width: 432px; border-right: 1px solid #666;">
                <asp:Label ID="lblDetails" runat="server" style="z-index: 1; left: 22px; top: 0px; position: relative; width: 353px;" Text="Change your details:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblLastname" runat="server" style="position: relative; left: 18px; top: 14px; width: auto; height: 36px; font-weight: 700;" Text="First Name:"></asp:Label>
		    <asp:TextBox ID="txtFirstname" runat="server" style="z-index: 1; position: relative; left: 38px; top: 14px; width: 210px; height: 32px"></asp:TextBox>


            <br />
                <asp:Label ID="lblGender" runat="server" style="position: relative; left: 17px; top: 32px; height: 36px; font-weight: 700;" Text="Gender:"></asp:Label>
		    <asp:DropDownList ID="ddlGender" runat="server" style="z-index: 1; position: relative; left: 130px; top:-10px;width: 215px; height: 32px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>

                <br />

            <asp:Label ID="lblAddress" runat="server" style="position: relative; left: 18px; top: 10px; width: auto; height: 36px; font-weight: 700;" Text="Address:"></asp:Label>
		    <asp:TextBox ID="txtAddress" runat="server" style="z-index: 1; position: relative; left: 56px; top: 10px; width: 210px; height: 32px"></asp:TextBox>

                   <br />

            <asp:Label ID="lblCity" runat="server" style="position: relative; left: 18px; top: 20px; width: auto; height: 36px; font-weight: 700;" Text="City:"></asp:Label>
		    <asp:TextBox ID="txtCity" runat="server" style="z-index: 1; position: relative; left: 90px; top: 20px; width: 210px; height: 32px"></asp:TextBox>

                   <br />

            <asp:Label ID="lblPostcode" runat="server" style="position: relative; left: 18px; top: 30px; width: auto; height: 36px; font-weight: 700;" Text="Postcode:"></asp:Label>
		    <asp:TextBox ID="txtPostcode" runat="server" style="z-index: 1; position: relative; left: 47px; top: 34px; width: 210px; height: 32px"></asp:TextBox>

                <br />

            <asp:Label ID="lblEmail" runat="server" style="position: relative; left: 18px; top: 44px; width: auto; height: 36px; font-weight: 700;" Text="Email:"></asp:Label>
		    <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; position: relative; left: 78px; top: 44px; width: 210px; height: 32px"></asp:TextBox>

                <asp:Button ID="btnSaveDetails" runat="server" style="z-index: 1; left: -81px; top: 105px; position: relative" Text="Save new details" CssClass="button confirm save"/>
            </asp:Panel>


            <asp:Panel ID="pnlPassword" runat="server" style="z-index: 1; left: 346px; top: -280px; position: relative; height: 275px; width: 538px">
                
                <asp:Label ID="lblChangePassword" runat="server" style="z-index: 1; left: 140px; top: 0px; position: relative; width: 353px;" Text="Change your password:" CssClass="rockwell welcome" Width="350px"></asp:Label>

                <asp:Label ID="lblOldPassword" runat="server" style="position: relative; left: -229px; width: auto;  top: 68px; height: 36px; font-weight: 700;" Text="Old Password:"></asp:Label>
		    <asp:TextBox ID="txtOld" runat="server" style="z-index: 1; position: relative; left: 266px; top: 20px; width: 210px; height: 32px" TextMode="Password"></asp:TextBox>

            <br />

            <asp:Label ID="lblNewPassword" runat="server" style="position: relative; left: 128px; top: 40px; width: auto; height: 36px; font-weight: 700;" Text="New Password:"></asp:Label>
		    <asp:TextBox ID="txtNew" runat="server" style="z-index: 1; position: relative; left: 142px; top: 40px; width: 210px; height: 32px" TextMode="Password"></asp:TextBox>
                <br />

            <asp:Label ID="lblNewPassword2" runat="server" style="position: relative; left: 128px; top: 50px; width: 121px; height: 36px; font-weight: 700;" Text="Confirm New Password:"></asp:Label>
		    <asp:TextBox ID="txtNew2" runat="server" style="z-index: 1; position: relative; left: 142px; top: 40px; width: 210px; height: 32px" TextMode="Password"></asp:TextBox>

                <asp:Button ID="btnSavePassword" runat="server" style="z-index: 1; left: -34px; top: 99px; position: relative" Text="Save new password" CssClass="button confirm save"/>
            </asp:Panel>

		</div>

		    <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 516px; top: -104px; position: relative; text-align: center; color: #bd362f;" Text="" Width="380px"></asp:Label>

	</div>
    </form>
</body>
</html>
