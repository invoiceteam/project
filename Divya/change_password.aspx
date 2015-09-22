<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="change_password">
                       <div style="height:35px">
                        <asp:Label runat="server" ID="oldpwd" Text="Old Password " Width="200px" ></asp:Label>
                        <asp:TextBox ID="TextBox1" TextMode="Password" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="You can't leave this empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="Label5" Text="New Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Password length must be between 7 to 10 characters" ControlToValidate="TextBox2" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" ForeColor="Red" />
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="Label6" Text="Confirm Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="These passwords don't match." ForeColor="#CC0000"></asp:CompareValidator>
                    </div>
                    <asp:Button CssClass="buttan" ID="Button7" runat="server" Text="Submit" OnClick="Button7_Click" />
                </div>
          
</asp:Content>

