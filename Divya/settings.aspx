<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="jquery-1.11.3.js"></script>
    <script src="js/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tabl">
        <div class="setting">
            <div class="settingtop">
                <a href="Dashboard.aspx"><img src="images/back.png" /></a>
                <h2 >Settings</h2>
            </div>
            <div class="align">
                <div>
                <asp:Label ID="label1" ClientIDMode="Static"  runat="server" Text="Change password"></asp:Label>
                 </div>
                <div class="pwd">
                    
                    <div style="height:35px">
                        <asp:Label runat="server" ID="oldpwd" Text="Old Password " Width="200px" ></asp:Label>
                        <asp:TextBox ID="TextBox1" TextMode="Password" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="You can't leave this empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="Label5" Text="New Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="You can't leave this empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="Label6" Text="Confirm Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="These passwords don't match." ForeColor="#CC0000"></asp:CompareValidator>
                    </div>
                    <asp:Button CssClass="buttan" ID="Button7" runat="server" Text="Submit" OnClick="Button7_Click" />
                </div>
                <div><asp:Label ID="label2" ClientIDMode="Static"  runat="server" Text="Technology"></asp:Label> </div>
                <div class="pwd">
                    <table style="border:0;padding:0;width:700px">
                        <tr>
                            <td class="addtech">Add Technolgy</td>                                                    
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Width="80px" Text="Add"  CausesValidation="false" OnClick="Button1_Click" />
                            </td>
                            
                        </tr>
                      
                        <tr>
                            <td class="removetech">Remove Technolgy</td>                                                    
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="dropdown" runat="server">
                                     <asp:ListItem Value="" Text="<-- Select Technology -->"></asp:ListItem>                                 
                                 </asp:DropDownList>
                                 <asp:Button ID="Button2" runat="server" Width="80px" Text="Remove"  CausesValidation="false" OnClick="Button2_Click" />
                             </td>
                             
                        </tr>
                      
                    </table>
                    </div>
                <div><asp:Label ID="label4" ClientIDMode="Static"  runat="server" Text="Types of Project"></asp:Label> </div>
                 <div class="pwd">
                   <table style="border:0;padding:0;width:700px">
                        <tr>
                            <td class="addtype">Add Project Types</td>          
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                <asp:Button ID="Button3" runat="server" CausesValidation="false" Width="80px" Text="Add" OnClick="Button3_Click" />
                            </td>
                            
                        </tr>
                      
                        <tr>
                            <td class="removetype" >Remove Project Types</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="DropDownList1" runat="server">
                                     <asp:ListItem Value="" Text="<-- Project Types -->"></asp:ListItem>                                 
                                 </asp:DropDownList>
                                 <asp:Button ID="Button4" runat="server" CausesValidation="false" Width="80px" Text="Remove" OnClick="Button4_Click" />
                             </td>
                             
                        </tr>
                      
                    </table>
                     </div>
                <div><asp:Label ID="label3" ClientIDMode="Static"  runat="server" Text="Period  of Invoice"></asp:Label> </div>
                <div class="pwd">
                     <table style="border:0;padding:0;width:700px">
                        <tr>
                            <td class="addinvoice">Add Period Of Invoice</td>                            
                        
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                <asp:Button ID="Button5" runat="server" CausesValidation="false" Width="80px" Text="Add" OnClick="Button5_Click" />
                            </td>
                            
                        </tr>
                      
                        <tr>
                            <td class="removeinvoice" >Remove Period Of Invoice</td> 
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="DropDownList2" runat="server">
                                     <asp:ListItem Value="" Text="<-- Project Types -->"></asp:ListItem>                                 
                                 </asp:DropDownList>
                                 <asp:Button ID="Button6" runat="server" CausesValidation="false"  Width="80px" Text="Remove" OnClick="Button6_Click" />
                             </td>
                             
                        </tr>
                      
                    </table>
                    </div>
             </div>
        </div>
        

    </div>
</asp:Content>

