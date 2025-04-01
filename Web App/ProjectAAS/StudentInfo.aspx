<%@ Page Title="Student Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="ProjectAAS.StudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Faculty Number
    <br />
    <asp:TextBox ID="TextBoxFacultyNumber" runat="server" Enabled="false" />
    <br />
    Specialty ID
    <br />
    <asp:TextBox ID="TextBoxSpecialtyId" runat="server" />
    <br />
    First Name
    <br />
    <asp:TextBox ID="TextBoxFirstName" runat="server" />
    <br />
    Middle Name
    <br />
    <asp:TextBox ID="TextBoxMiddleName" runat="server" />
    <br />
    Last Name
    <br />
    <asp:TextBox ID="TextBoxLastName" runat="server" />
    <br />
    Address
    <br />
    <asp:TextBox ID="TextBoxAddress" runat="server" />
    <br />
    Phone
    <br />
    <asp:TextBox ID="TextBoxPhone" runat="server" />
    <br />
    E-Mail
    <br />
    <asp:TextBox ID="TextBoxEmail" runat="server" />
    <br />
    <br />
    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" />
</asp:Content>
