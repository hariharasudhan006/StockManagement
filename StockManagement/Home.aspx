<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="StockManagement.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" 
        rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
</head>
<body class="p-2 bg-light bg-gradient position-relative">
    <h4 class="position-absolute start-50 translate-middle mt-3">Stock Management System</h4>
    <div class="container bg-light bg-gradient mt-4" runat="server">
        <ul class="nav nav-tabs" runat="server">
            <li class="nav-item" runat="server">
                <a class="nav-link active" aria-current="page" href="#">Home</a>
            </li>
            <li class="nav-item" runat="server">
                <a class="nav-link" aria-current="page" href="StockInsert.aspx">Add Stock</a>
            </li>
            <li class="nav-item" runat="server">
               <a class="nav-link" aria-current="page" href="Manufacturer.aspx">Add Manufacturer</a>
            </li>
            <li class="nav-item" runat="server">
               <a class="nav-link" aria-current="page" href="Login.aspx">Logout</a>
            </li>
        </ul>
     </div>
    <form runat="server">
        <div class="container bg-light bg-gradient mt-4"  runat="server" style="text-align:center;">
            <asp:Label ID="NothingLabel" runat="server"></asp:Label>
            <asp:GridView ID="ContentGrid" runat="server" class="table table-striped" OnRowDataBound="ContentGrid_RowDataBound"></asp:GridView>
    </div>
    </form>
</body>
</html>
