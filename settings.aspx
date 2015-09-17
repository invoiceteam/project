<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script src="js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="js/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
    <div class="tab">
        <div class="setting">
            <div class="settingtop">
                <a href="Dashboard.aspx"><img src="images/back_blue.png" /></a>
                <h2 >Settings</h2>
            </div>
            
            <div class="align">
               
                <div>
                <asp:Label ID="label1" ClientIDMode="Static"  runat="server" Text="Change password"></asp:Label>
                    <input type="button" value="Reload Page" onClick="document.location.reload(true)">
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
                            <td class="removetype" >Types of project</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="tpesofproject" runat="server">
                                                                  
                                 </asp:DropDownList>
                                
                             </td>
                             
                        </tr>

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
                            <td class="removetype" >Types of project</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" AutoPostBack="True"  ID="typesofproject" runat="server" OnSelectedIndexChanged="typesofproject_SelectedIndexChanged">
                                                                  
                                 </asp:DropDownList>
                                
                             </td>
                             
                        </tr>
                         <tr>
                            <td class="addtype">Add Period of invoice</td>          
                            <td>
                                <asp:TextBox ID="txtnewinvoice" runat="server"></asp:TextBox>
                                <asp:Button ID="addperiodinvoice" runat="server" Text="Add" Width="80px" CausesValidation="false" OnClick="addperiodinvoice_Click" />

                            </td>
                            
                        </tr>
                       <tr>
                            <td class="removetype" >Period of invoice</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="periodinvoice" runat="server">
                                                                  
                                 </asp:DropDownList>
                                <asp:Button ID="removepinvoice" runat="server"  CausesValidation="false" Width="80px" Text="Remove" OnClick="removepinvoice_Click"/>
                             </td>
                             
                        </tr>

                     
                    </table>
                     </div>



             </div>
        </div>
        

    </div>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="typesofproject" EventName="SelectedIndexChanged" />
                   
                </Triggers>
            </asp:UpdatePanel>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(afterAsycUpdate);

        function afterAsycUpdate() {
            pageEvents();
            datepicker();

        }
    </script>
</asp:Content>

