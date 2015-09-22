<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="Styles.css" />
    <script src="js/jquery-1.11.3.js" type="text/javascript"></script>
    <script src="js/JavaScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div id="dashboard-layout">
        <div id="dashboard_setting">
            <div id="setting">
                 <asp:ImageButton ID="lnkpwd" Text="Change password" runat="server" ImageUrl="~/images/pwd.png" Width="120px" Height="30px" PostBackUrl="~/change_password.aspx"></asp:ImageButton>
            </div>
            <div id="logout">
              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/logout.jpg" PostBackUrl="~/login.aspx" Height="25px" />
            </div>
             <div id="project_details">
            <div id="project_heading" align="center">
                <strong>Project details</strong>
            </div>
            <div id="project_settings">
                <div id="sort_dropdown">
                   <asp:DropDownList ID="dropdown" ClientIDMode="Static" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" >
                        <asp:ListItem Value="0">Current project details</asp:ListItem>
                        <asp:ListItem Value="1">Completed project details</asp:ListItem>
                    </asp:DropDownList>
                   
                    <div id="search">
                   <asp:TextBox ID="textbox1" ClientIDMode="Static"  runat="server"></asp:TextBox>
           <asp:Button ID="btn_search" ClientIDMode="Static" Text="Search" runat="server" OnClientClick="btn_search" OnClick="btn_search_Click" />
                      <div class="suggestions">  
              
                        </div>
                </div>
                    <div id="gridview_finance">
                        <asp:GridView ID="dtgproject" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="invoicenumber"
                        AllowPaging="True"
                        BackColor="White"
                        BorderColor="#CC9966"
                        BorderStyle="None"
                        BorderWidth="1px"
                        CellPadding="4">
             <FooterStyle BackColor="#FFFFCC" ForeColor="#000009" />
             <RowStyle BackColor="White" ForeColor="#000099" Width="100px"/>
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" /> <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center"/>
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />   
                 <Columns>
                      <asp:TemplateField HeaderText="project-id" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblsno" runat="server" Text='<%# Eval("id") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Invoice-number" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblinvoicenumber" runat="server" Text='<%# Eval("invoicenumber") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="Project Manager" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="projectName" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblprojectname" runat="server" Text='<%# (Eval("projectName").ToString())  %>' Width="300px"></asp:Label>
                           </ItemTemplate>
                          
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Hours" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblhrate" runat="server" Text='<%# Eval("total_rate") %>' Width="70px"></asp:Label>                               
                           </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField HeaderText="Completed Hours" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lbltbgt1" runat="server" Text='<%# Eval("completedHours") %>' Width="70px"></asp:Label>                             
                           </ItemTemplate>                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Hourly Rate" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lbltbgt" runat="server" Text='<%# Eval("hourly_rate") %>' Width="70px"></asp:Label>                             
                           </ItemTemplate>                         
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Budget" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblBudget" runat="server" Text='<%# Eval("total_budget") %>' Width="70px"></asp:Label>                              
                           </ItemTemplate>
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Invoice Value" SortExpression="type" ControlStyle-Width="70px">
                           <ItemTemplate>
                               <asp:Label ID="lblInvoice" runat="server" Text='<%# Eval("totalpay") %>' Width="70px"></asp:Label>                              
                           </ItemTemplate>
       
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Status" SortExpression="type" ControlStyle-Width="70px">
                         <ItemTemplate> 
                             <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("invoicestatus") %>' Width="70px"></asp:Label>
                         </ItemTemplate> 
                         <EditItemTemplate >
                             <asp:DropDownList runat="server" ID="invoicestatusdrop" >   
                                 <asp:ListItem Value="Pending">Pending</asp:ListItem> 
                                 <asp:ListItem Value="sent">Sent</asp:ListItem>
                             </asp:DropDownList>
                         </EditItemTemplate>
                     </asp:TemplateField>
                   <asp:CommandField ShowEditButton="true" />
               </Columns>
         </asp:GridView>
                    </div> 
                </div>
            </div>
        </div>
     </div>
  </div>
</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dropdown" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(registerMethods);
        function registerMethods() {
            registerStartup();
        }
    </script>
</asp:Content>

