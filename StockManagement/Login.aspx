 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockManagement.Login1" EnableViewState="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" id="holder" lang="en">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" charset="utf-8"/>
    <link href="Login.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" 
        rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
</head>
<body class="bg-light bg-gradient">
    <form id="form1" runat="server" class="frmalg">
        <div class="container bg-light bg-gradient shadow p-3 mb-5 bg-white rounded">
            <div style="text-align: center;">
                <h3>Sign in to continue</h3>
            </div>
            <label><b>Username</b></label>
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username" />
            <label><b>Password</b></label>
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password"/>
            <div style="text-align: center;">
                <asp:Button runat="server" ID="btn_Login" 
                    class="lgnbtn btn btn-secondary w-100" Text="Login" OnClick="btn_Login_Click" />
            </div>
            <div style="text-align: center;">
                <asp:Button runat="server" class="cnbtn btn btn-dark w-100" 
                    OnClick="btnCreateAccountOnClick" Text="Create an account"/>
            </div>
            <asp:CustomValidator runat="server" ControlToValidate="txt_Username" 
                ID="UserNameValidator" OnServerValidate="UserNameValidator_ServerValidate" ForeColor="Red"
                ErrorMessage="No user associated with this username" Display="Dynamic">
            </asp:CustomValidator>
            <asp:CustomValidator runat="server" ControlToValidate="txt_Username" 
                ID="PasswordValidator" OnServerValidate="PasswordValidator_ServerValidate" ForeColor="Red"
                ErrorMessage="Incorrect password" Display="Dynamic">
            </asp:CustomValidator>
        </div>
    </form>
</body>
</html>
