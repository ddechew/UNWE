<%@ Page Title="Grades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grades.aspx.cs" Inherits="ProjectAAS.Grades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewContent" runat="server" OnRowCommand="GridViewContent_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:ButtonField ButtonType="Link"
                CommandName="Select"
                HeaderText=""
                Text="Select" />
            <asp:BoundField HeaderText="Faculty Number" DataField="FNumber" />
            <asp:BoundField HeaderText="Subject ID" DataField="SubjectId" />
            <asp:BoundField HeaderText="Final Grade" DataField="FinalGrade" />
        </Columns>
    </asp:GridView>
</asp:Content>
