<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="Styles.css" />
     <style type="text/css">
         .auto-style1
         {
             width: 175px;
         }
         .auto-style2
         {
             height: 44px;
         }
         .auto-style3
         {
             width: 175px;
             height: 44px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="signup_form">
        <h3>Sign Up</h3>
         <table cellspacing="20px">
            <tr>
                <td>Type of user</td> 
                <td ><asp:DropDownList ID="dropdown" runat="server">
                    <asp:ListItem Selected="True" Text="Project Manager"></asp:ListItem>
                    <asp:ListItem Text="Finance team"></asp:ListItem>
                    </asp:DropDownList></td>   
                                    
            </tr>
            <tr>
                <td>Enter your Employee ID</td>
                <td ><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>  
                <td><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Employee_ID is a required" ForeColor="Red"></asp:RequiredFieldValidator></td>  
              </tr>
             <tr>
                 <td>Enter your Name</td>
                 <td ><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                  <td><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Name is a required" ForeColor="Red"></asp:RequiredFieldValidator></td>  
             </tr>
             <tr>
                 <td>Enter your Email ID</td>
                 <td class="auto-style1"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                 <td> <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    runat="server" ErrorMessage="Please Enter Valid Email ID"
                  ValidationGroup="vgSubmit" ControlToValidate="TextBox3"
                  ForeColor="Red"
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                  </asp:RegularExpressionValidator></td>
             </tr>
             <tr>
                 <td>Create your Password</td>
                 <td ><asp:TextBox ID="TextBox4" TextMode="Password" runat="server" Height="23px" Width="196px"></asp:TextBox></td>
                 <td><asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Password length must be between 7 to 10 characters" ControlToValidate="TextBox4" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" ForeColor="Red" /></td>
             </tr>
             <tr>
                 <td >Confirm your Password</td>
                 <td><asp:TextBox ID="TextBox5" TextMode="Password" runat="server" Height="24px" Width="193px"></asp:TextBox></td>
                 <td ><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5"  ErrorMessage= "Passwords do not match" ForeColor="Red" >
                       </asp:CompareValidator> </td>
             </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="Button1" runat="server" Text="Signup" Height="23px" Width="50px" OnClick="Button1_Click"/></td>                 
            </tr>
         </table> 
    </div>
</asp:Content>
