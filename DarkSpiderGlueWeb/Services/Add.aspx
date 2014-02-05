<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DarkSpiderGlueWeb.Services.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Here you can install you Service.</p>
<p>
    <asp:Label ID="lblServiceFiles" runat="server" Text="ServiceFile(in zip)"></asp:Label>
    <asp:FileUpload ID="flUpload" runat="server" />
    <br />
    <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
        Text="Upload" />
</p>
</asp:Content>
