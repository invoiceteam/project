<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="password_change.aspx.cs" Inherits="password_change" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="content_recovery">
         <table>
           <tr><td><asp:Label ID="Label2" runat="server" Text="OTP has been send your email!!!"  ForeColor="Blue"></asp:Label></td></tr>
           <tr>
               <td> <asp:Label ID="Label3" runat="server" Text="Enter your OTP" ></asp:Label></td>
               <td><asp:TextBox ID="otp" runat="server" ></asp:TextBox></td>
           </tr>
           <tr>
                <td> <asp:Label ID="Label4" runat="server" Text="New password"></asp:Label>  </td>
                <td> <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Height="25px" Width="195px" ></asp:TextBox> </td>
               <td><asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Password length must be between 7 to 10 characters" ControlToValidate="TextBox3" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" ForeColor="Red" /></td>
           </tr>
           <tr>
               <td> <asp:Label ID="Label5" runat="server" Text="Confirm password"></asp:Label></td>
               <td> <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Height="28px" Width="195px"></asp:TextBox></td>  
               <td ><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4"  ErrorMessage= "Passwords do not match" ForeColor="Red" >
                       </asp:CompareValidator> </td>     
           </tr>
            <tr>
                   <td></td>
                   <td>  <asp:Button ID="Button1" runat="server" Text="Change password" OnClick="btnclick" /></td>
            </tr>
        </table>
        <asp:Label ID="error" runat="server" Text="your OTP is wrong.Try again" Visible="false" ForeColor="Red"></asp:Label>
   </div>
</asp:Content>

