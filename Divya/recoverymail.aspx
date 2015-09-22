<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recoverymail.aspx.cs" Inherits="recoverymail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="content_recovery">
         <table runat="server">
             <tr>
       <td>Enter your recovery email</td>
      <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td> 
             </tr>
             <tr>
       <td><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
       <td><asp:Label ID="error" runat="server" Text="Recovery mail incorrect" ForeColor="Red" Visible="false"></asp:Label></td>
    </tr>
                 </table>
             </div>
   
</asp:Content>

