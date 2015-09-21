<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="currentprojectdetails.aspx.cs" Inherits="currentprojectdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="js/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="dashboard_layout">
    <div id="dashboard_setting">
        <div id="delete">
             <asp:Button ID="btndelete" runat="server" Text="Delete" Width="50px" OnClick="btndelete_Click" OnClientClick="return confirmDelete()" />
        </div>
        <div id="setting">
            <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" Width="50px" />
        </div>
        <div id="logout">
              <asp:ImageButton ID="imgbtnlogout" runat="server" OnClick="logout" ImageUrl="~/images/logout.jpg" Height="25px" />
            </div>
    </div>
    <div id="project_details">
         <div id="project_heading" align="center">
             <asp:Label runat="server" Text="" ID="lblnote"></asp:Label>
         </div>
         <div id="project_settings">
                <div id="sort_dropdown">
                   <asp:Button runat="server" ID="btnnewinvoice" Text="New invoice" Width="100px" Height="30px" OnClick="btnnewinvoice_Click" />
                 </div>
         </div> 
        <div id="currentproject">
       <table cellspacing="10px">
           <tr>
               <td class="style">Project name</td>
               <td class="style"><asp:Label ID="lblprojectname" runat="server"></asp:Label></td>
               <td class="style"><asp:Label ID="lblprojectnamevalue" runat="server"></asp:Label></td>                    
               <td class="style">Technology</td>
               <td class="style"><asp:Label ID="lbltechnology" runat="server"></asp:Label></td> 
               <td class="style"><asp:Label ID="lbltechnologyvalue" runat="server"></asp:Label></td>                       
               <td class="style">Type of project</td>
               <td class="style"><asp:Label ID="lblprojecttype" runat="server"></asp:Label></td> 
               <td class="style"><asp:Label ID="lblprojecttypevalue" runat="server"></asp:Label></td>                                       
           </tr>
       </table>
    </div>
   <div id="project_gridview">
    <asp:GridView ID="GridView1" CssClass="currentgrid" runat="server"  AutoGenerateColumns="False" AllowPaging="True"  
     OnRowEditing="GridView1_RowEditing" DataKeyNames="invoicenumber" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="5" OnPageIndexChanging="grdData_PageIndexChanging">
    <Columns>
         <asp:TemplateField HeaderText="Project ID" ItemStyle-Width="130px" ItemStyle-Height="35px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_projectid" runat="server" Text='<%#Eval("project_id") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Invoice Number" ItemStyle-Width="130px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_invoicenumber" runat="server" Text='<%#Eval("invoicenumber") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Start date" ItemStyle-Width="130px">  
                   <ItemTemplate>  
                        <asp:Label ID="lbl_startdate" runat="server" Text='<%#Eval("startdate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
         </asp:TemplateField>
        <asp:TemplateField HeaderText="End date" ItemStyle-Width="130px">  
                   <ItemTemplate>  
                        <asp:Label ID="lbl_enddate" runat="server" Text='<%#Eval("enddate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice date" ItemStyle-Width="130px">  
                   <ItemTemplate>  
                        <asp:Label ID="lbl_invoicedate" runat="server" Text='<%#Eval("invoicedate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Completed hours" ItemStyle-Width="130px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_completedhours" runat="server" Text='<%#Eval("completedhours") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount of invoice" ItemStyle-Width="130px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_invoiceamount" runat="server" Text='<%#Eval("totalpay") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" ItemStyle-Width="130px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px"></ItemStyle>
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="100px">  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" width="100px" height="30px" />  
                    </ItemTemplate>  
                    <ItemStyle Width="100px"></ItemStyle>
        </asp:TemplateField> 

    </Columns>    
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="Silver" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <PagerStyle CssClass="gridpaging" />
    </asp:GridView>
    </div>
    </div>
    <div id="hours">
       <table cellspacing="10px">
           <tr>
               <td>Totalhours</td>   
                <td><asp:Label ID="lbltotalhours" runat="server"></asp:Label></td>                    
           </tr>
           <tr>
               <td>Totalbudget</td>
               <td><asp:Label ID="lbltotalpay" runat="server"></asp:Label></td>                    
           </tr>
       </table>
    </div>
    <div id="budget">
       <table cellspacing="10px">
           <tr>
               <td>Complitedhours</td>  <td>
                   <asp:Label ID="lblchrs" runat="server"></asp:Label></td>             
           </tr>
           <tr>
               <td>Complitedbudget</td>
               <td><asp:Label ID="lblcompletedbudjet" runat="server"></asp:Label></td>       
           </tr>
       </table>
    </div>
</div>


</asp:Content>

