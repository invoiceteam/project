<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="login_form">
    <h3>Login</h3>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/login_form.jpg" Height="140px" />  
        <table cellspacing="20px">
            <tr>
                <td>Username</td> 
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>    
                               
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="Button1" runat="server" Text="Login" Height="23px" Width="50px" /></td>                 
            </tr>
            <tr>
                <td></td>
                <td><asp:LinkButton ID="LinkButton1" runat="server">Create account</asp:LinkButton></td>
                       
            </tr>
        </table> 
    </div>
</asp:Content>

