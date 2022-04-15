<%@ Page Title="" Language="C#" MasterPageFile="~/Insert.Master" AutoEventWireup="true" CodeBehind="StockInsert.aspx.cs" Inherits="StockManagement.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <form runat="server">
        <div class="container bg-light bg-gradient shadow p-3 mt-5 bg-white rounded w-50">
            <center><h4>Enter the stock details</h4></center>
            <asp:TextBox ID="StockId" runat="server" class="form-control mt-4" placeholder="Stock Id"></asp:TextBox>
            <asp:TextBox ID="Price" runat="server" TextMode="Number" class="form-control mt-4" placeholder="Price"></asp:TextBox>
            <asp:TextBox ID="DateOfBought" runat="server" TextMode="Date" class="form-control mt-4" placeholder="Date of bought"></asp:TextBox>
            <asp:TextBox ID="ManufacturerName" runat="server" class="form-control mt-4" placeholder="Manufacturer name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="StockId" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the stock Id">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Price" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the stock price">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="DateOfBought" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the date">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ManufacturerName" 
                ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the Manufacturer name">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="ManufacturerNameValidator" runat="server" ControlToValidate="ManufacturerName" ErrorMessage="No manufacturer with name" 
                OnServerValidate="ManufacturerNameValidator_ServerValidate" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
            <asp:CustomValidator ID="StockIdValidator" runat="server" ControlToValidate="StockId" ErrorMessage="Stock Id already available" 
                Display="Dynamic" ForeColor="Red" OnServerValidate="StockIdValidator_ServerValidate"></asp:CustomValidator>
            <center><asp:Button ID="SubmitBtn" runat="server" 
                class="lgnbtn btn btn-secondary w-75 mt-4" Text="Continue" OnClick="SubmitBtn_Click" /></center>
    </div>
    </form>
</asp:Content>
