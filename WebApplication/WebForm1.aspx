<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ClientCalendar" runat="server">
    <asp:Calendar ID="calendar1" runat="server"></asp:Calendar>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TrainingInfo" runat="server">
    Trenér:
    <asp:Label ID="coachName" runat="server"></asp:Label><br />
    Čas:
    <asp:Label ID="time" runat="server"></asp:Label><br />
    Druh:
    <asp:Label ID="type" runat="server"></asp:Label><br />
    Poznámky:
    <asp:Label ID="notes" runat="server"></asp:Label><br />
</asp:Content>

