<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="PrehledTreninku.aspx.cs" Inherits="WebApplication.PrehledTreninkuForm" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ClientCalendar" runat="server">
    <asp:Calendar ID="Calendar1" runat="server" SelectionMode="Day" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TrainingInfo" runat="server">
    Trenér:
    <asp:Label ID="coachName" runat="server"></asp:Label>
    <br />
    Čas:
    <asp:Label ID="time" runat="server"></asp:Label>
    <br />
    Poznámky:
    <asp:Label ID="notes" runat="server"></asp:Label><br />
    <asp:TextBox id="TextArea1" TextMode="multiline"  Visible="false" Columns="50" Rows="5" runat="server" placeholder="Důvod odmítnutí" style="resize: none;"/><br />
    <asp:Calendar ID="proposedDate" runat="server" Visible="false" ></asp:Calendar><br />
    <asp:Button ID="acceptBtton" runat="server" Visible="false" Text="Přijmout" OnClick="AcceptBtton_Click"/>
    <asp:Button ID="rejectButton" runat="server" Visible="false" Text="Odmítnout" OnClick="RejectButton_Click" /><br />
    <asp:Label ID="errorText" runat="server" Visible="false">Vyplňte důvod a náhradní datum nesmí být v minulosti.</asp:Label>
    <br />
</asp:Content>
