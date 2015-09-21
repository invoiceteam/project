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
                <asp:ImageButton ID="imbback" ClientIDMode="Static" runat="server" ImageUrl="~/images/back1.png" CausesValidation="false" OnClick="imbback_Click" />
                <h2 >Settings</h2>
            </div>
            
            <div class="align">
               
                <div>
                <asp:Label ID="lblchangepwd" ClientIDMode="Static"  runat="server" Text="Change password"></asp:Label>
                    <input type="button" value="Reload Page" onClick="document.location.reload(true)">
                 </div>
                <div class="pwd">
                    
                    <div style="height:35px">
                        <asp:Label runat="server" ID="lbloldpwd" Text="Old Password " Width="200px" ></asp:Label>
                        <asp:TextBox ID="txtoldpassword" TextMode="Password" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvoldpassword" runat="server" ControlToValidate="txtoldpassword" ErrorMessage="You can't leave this empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="lblnewpasword" Text="New Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtnewpassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpassword" ErrorMessage="You can't leave this empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        
                    </div>
                    <div style="height:35px">
                        <asp:Label runat="server" ID="lblconfirmpwd" Text="Confirm Password" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtconfirmpwd" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpassword" ControlToValidate="txtconfirmpwd" ErrorMessage="These passwords don't match." ForeColor="#CC0000"></asp:CompareValidator>
                    </div>
                    <asp:Button CssClass="buttan" ID="btnsubmit" ClientIDMode="Static" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                </div>
                <div><asp:Label ID="lbltech" ClientIDMode="Static"  runat="server" Text="Technology"></asp:Label> </div>
                <div class="pwd">
                    <table style="border:0;padding:0;width:700px">
                        <tr>
                            <td class="addtech">Add Technolgy</td>                                                    
                            <td>
                                <asp:TextBox ID="txttechnology" runat="server"></asp:TextBox>
                                <asp:Button ID="btntech" ClientIDMode="Static" runat="server" Width="80px" Text="Add"  CausesValidation="false" OnClick="btntech_Click" />
                            </td>
                            
                        </tr>
                      
                        <tr>
                            <td class="removetech">Remove Technolgy</td>                                                    
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="ddltechnology" runat="server">
                                 </asp:DropDownList>
                                 <asp:Button ID="btnremovetech" ClientIDMode="Static" runat="server" Width="80px" Text="Remove"  CausesValidation="false" OnClick="btnremovetech_Click" />
                             </td>
                             
                        </tr>
                      
                    </table>
                    </div>
               
                <div><asp:Label ID="lbltype" ClientIDMode="Static"  runat="server" Text="Types of Project"></asp:Label> </div>
                 <div class="pwd">
                   <table style="border:0;padding:0;width:700px">

                        <tr>
                            <td class="removetype" >Types of project</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="ddltpesofproject" runat="server">
                                                                  
                                 </asp:DropDownList>
                                
                             </td>
                             
                        </tr>

                        <tr>
                            <td class="addtype">Add Project Types</td>          
                            <td>
                                <asp:TextBox ID="txtaddtype" runat="server"></asp:TextBox>
                                <asp:Button ID="btntype" runat="server" ClientIDMode="Static" CausesValidation="false" Width="80px" Text="Add" OnClick="btntype_Click" />
                            </td>
                            
                        </tr>
                      
                        <tr>
                            <td class="removetype" >Remove Project Types</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="ddlremovetype" runat="server">                              
                                 </asp:DropDownList>
                                 <asp:Button ID="btnremovetype" ClientIDMode="Static" runat="server" CausesValidation="false" Width="80px" Text="Remove" OnClick="btnremovetype_Click" />
                             </td>
                             
                        </tr>
                      
                    </table>
                     </div>
                <div><asp:Label ID="lblpoi1" ClientIDMode="Static"  runat="server" Text="Period  of Invoice"></asp:Label> </div>
                <div class="pwd">
                   <table style="border:0;padding:0;width:700px">

                        <tr>
                            <td class="removetype" >Types of project</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" AutoPostBack="True" ClientIDMode="Static"  ID="ddltypesofproject" runat="server" OnSelectedIndexChanged="typesofproject_SelectedIndexChanged">
                                                                  
                                 </asp:DropDownList>
                                
                             </td>
                             
                        </tr>
                         <tr>
                            <td class="addtype">Add Period of invoice</td>          
                            <td>
                                <asp:TextBox ID="txtnewinvoice" runat="server"></asp:TextBox>
                                <asp:Button ID="addperiodinvoice" runat="server" Text="Add" Width="80px" ClientIDMode="Static" CausesValidation="false" OnClick="addperiodinvoice_Click" />

                            </td>
                            
                        </tr>
                       <tr>
                            <td class="removetype" >Period of invoice</td>                 
                        
                             <td>
                                 <asp:DropDownList CssClass="drop1" ID="periodinvoice" runat="server">
                                                                  
                                 </asp:DropDownList>
                                <asp:Button ID="removepinvoice" runat="server"  ClientIDMode="Static" CausesValidation="false" Width="80px" Text="Remove" OnClick="removepinvoice_Click"/>
                             </td>
                             
                        </tr>

                     
                    </table>
                     </div>



             </div>
        </div>
        

    </div>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddltypesofproject" EventName="SelectedIndexChanged" />
                   
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

