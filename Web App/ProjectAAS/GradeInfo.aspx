<%@ Page Title="Grade Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GradeInfo.aspx.cs" Inherits="ProjectAAS.GradeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Faculty Number
    <br />
    <asp:TextBox ID="TextBoxFacultyNumber" runat="server" Enabled="false" />
    <br />
    Specialty ID
    <br />
    <asp:TextBox ID="TextBoxSubjectID" runat="server" Enabled="false" />
    <br />
    Final Grade
    <br />
    <asp:TextBox ID="TextBoxFinalGrade" runat="server" />
    <br />
    <br />
    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" />
</asp:Content>
