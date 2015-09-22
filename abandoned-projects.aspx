<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="abandoned-projects.aspx.cs" Inherits="Abandant_projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="abandantprojects.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="dashboard_layout">
        <div id="logout-abandant">
              <asp:ImageButton ID="imgbtnlogout" runat="server" ImageUrl="~/images/logout.jpg" Height="25px" OnClick="imgbtnlogout_Click" />
        </div>
        <div id="project_details">
             <div id="project_heading" align="center">
                 <asp:Label runat="server" ID="lblnote" Text="Abandoned projects list"></asp:Label>
             </div>
                 <div id="currentproject">
                     <asp:Button CssClass="abandant-back" ID="btnbac" OnClick="btnbac_Click"  runat="server"  Text="Back to dashboard" />
                   <table cellspacing="10px">
                       <tr>
                           <td class="style">No.of abandoned projects :</td>
                           <td class="style"><asp:Label ID="lblnoofprojects" runat="server"></asp:Label></td>                                    
                       </tr>
                   </table>
                 </div>
             <div id="project_gridview">
                <div id="abandant-projects">
                 <asp:GridView ID="grdabandantprojects" runat="server" AutoGenerateColumns="False" DataKeyNames="id" BackColor="White" 
                     BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"  AllowPaging="True" CellPadding="4" OnPageIndexChanging="PageIndexChanging"
                     OnRowEditing = "Edit" OnRowCancelingEdit = "CancelEdit" OnRowUpdating="Update" PageSize="5" >
                     <Columns>
                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="ID" SortExpression="id" ItemStyle-Height="35px">
                             <ItemTemplate>
                                <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("id") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="50px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Name" SortExpression="name">
                             <ItemTemplate>
                                <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="300px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Technology" SortExpression="technology">
                             <ItemTemplate>
                                <asp:Label ID="lbl_technology" runat="server" Text='<%#Eval("technology") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="120px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Type" SortExpression="type">
                             <ItemTemplate>
                                <asp:Label ID="lbl_type" runat="server" Text='<%#Eval("type") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="105px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Total hours" SortExpression="total_hours">
                             <ItemTemplate>
                                <asp:Label ID="lbl_totalhours" runat="server" Text='<%#Eval("total_hours") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="105px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Hourly rate" SortExpression="totalpay">
                             <ItemTemplate>
                                <asp:Label ID="lbl_hourlyrate" runat="server" Text='<%#Eval("hourly_rate") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="105px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Total pay" SortExpression="hourly_rate">
                             <ItemTemplate>
                                <asp:Label ID="lbl_totalpay" runat="server" Text='<%#Eval("total_budget") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="105px"></ItemStyle>
                         </asp:TemplateField>

                         <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Project status" SortExpression="hourly_rate">
                             <ItemTemplate>
                                <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("project_status") %>'></asp:Label>  
                             </ItemTemplate>
                             <ItemStyle Width="105px"></ItemStyle>
                             <EditItemTemplate>
                                 <asp:DropDownList ID="dwstatus" runat="server" Height="30px">
                                    <asp:ListItem Text="Current"></asp:ListItem>
                                    <asp:ListItem Text="Completed"></asp:ListItem>
                                    <asp:ListItem Text="Abandoned"></asp:ListItem>
                                </asp:DropDownList>
                             </EditItemTemplate>
                         </asp:TemplateField>
                         <asp:CommandField ShowEditButton="True" ControlStyle-Width="150px"/>
                     </Columns>
                     
                     
                     <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                     <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                     <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                     <HeaderStyle Height="30px" />
                     <PagerStyle BackColor="Silver" ForeColor="#330099" HorizontalAlign="Center" />
                     <SortedAscendingCellStyle BackColor="#FEFCEB" />
                     <SortedAscendingHeaderStyle BackColor="#AF0101" />
                     <SortedDescendingCellStyle BackColor="#F6F0C0" />
                     <SortedDescendingHeaderStyle BackColor="#7E0000" />
                     <PagerStyle CssClass="gridpaging" />
                     
                 </asp:GridView>  
                </div>  
             </div>
            </div>
    </div>
    <script>
     function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };

    </script>
</asp:Content>

