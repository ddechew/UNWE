<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectAAS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
    Username
    <br />
    <asp:TextBox ID="username" runat="server" />
    <br />
    Password
    <br />
    <asp:TextBox ID="password" runat="server" TextMode="Password" />
    <br />
    <br />
    <asp:Button ID="submit" runat="server" Text="Login" OnClick="submit_Click" />
</asp:Content>
