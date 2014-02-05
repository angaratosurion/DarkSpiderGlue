<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DarkSpiderGlueWeb.Services.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="tblServices" runat="server" Height="263px" Width="806px" 
    HorizontalAlign="Left" BorderStyle="Solid" 
        Caption="Services Currently Running" GridLines="Both">
        <asp:TableRow ID="ServiceName" runat="server">
        </asp:TableRow>
        <asp:TableRow ID="EndPoit" runat="server">
        </asp:TableRow>
    </asp:Table>
</asp:Content>
