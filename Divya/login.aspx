<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Styles.css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.3.min.js"></script>
   
    <style type="text/css">
        .auto-style1
        {
            height: 43px;
        }
        .auto-style2
        {
            height: 45px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="login_form">
    <h3>Login</h3>
        
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/login_form.jpg" CssClass="loginimg" />  
          <asp:Label ID="error" runat="server" Text="Label" Visible="false">Invalid Username</asp:Label>
         <table cellspacing="20px">
            <tr>
                <td>Email</td> 
                <td><asp:TextBox ID="u_name" runat="server"></asp:TextBox></td>   
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="u_name"  ForeColor="Red" ErrorMessage="Please enter your username"></asp:RequiredFieldValidator></td>                     
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td class="auto-style2"><asp:TextBox ID="p_word" runat="server" TextMode="Password" Height="24px" Width="196px"></asp:TextBox></td>    
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="p_word"  ForeColor="Red" ErrorMessage="Please enter your password"></asp:RequiredFieldValidator></td>                           
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1"><asp:Button ID="Button1" runat="server" Text="Login" Height="23px" Width="50px" OnClick="Button1_Click"/></td>                 
            </tr>
            <tr>
               <td></td>
                <td><asp:LinkButton ID="LinkButton1" PostBackUrl="~/signup.aspx" runat="server" CausesValidation="false">New user?</asp:LinkButton></td>
                </tr>
             <tr>
                 <td></td>
                  <td><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CausesValidation="false">forget password?</asp:LinkButton></td>
            </tr>
        </table> 
    </div>
</asp:Content>

