<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recoverymail.aspx.cs" Inherits="recoverymail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="content_recovery">
         <table id="Table1" runat="server">
             <tr>
       <td style="padding: 21px;">Enter your recovery email</td>
      <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td> 
                 <td><asp:Label ID="error" runat="server" Text="Recovery mail incorrect" ForeColor="Red" Visible="false"></asp:Label></td>
             </tr>
             <tr>
                 <td></td>
       <td><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
           <asp:Button ID="btncancel" runat="server" CausesValidation="false" OnClick="btncancel_Click" Text="Cancel" />
       </td>
       
    </tr>
                 </table>
             </div>
   
</asp:Content>

