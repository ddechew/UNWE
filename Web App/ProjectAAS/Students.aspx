<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ProjectAAS.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewContent" runat="server" OnRowCommand="GridViewContent_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:ButtonField ButtonType="Link"
                CommandName="Select"
                HeaderText=""
                Text="Select" />
            <asp:BoundField HeaderText="Faculty Number" DataField="fnumber" />
            <asp:BoundField HeaderText="Specialty ID" DataField="SpecialtyId" />
            <asp:BoundField HeaderText="First Name" DataField="fname" />
            <asp:BoundField HeaderText="Middle Name" DataField="mname" />
            <asp:BoundField HeaderText="Last Name" DataField="lname" />
            <asp:BoundField HeaderText="Address" DataField="address" />
            <asp:BoundField HeaderText="Phone" DataField="phone" />
            <asp:BoundField HeaderText="Email" DataField="email" />
        </Columns>
    </asp:GridView>
</asp:Content>
