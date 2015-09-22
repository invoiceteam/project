<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboardpm.aspx.cs" Inherits="Dashboardpm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Styles.css" />
    <script type="text/javascript" src="jquery-1.11.3.js"></script>
    <script type="text/javascript" src="JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="dashboard_layout">
        <div id="dashboard_setting">
            <div id="setting">
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/seettings.png" Height="30px" />
            </div>
            <div id="logout">
              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/logout.jpg" Height="25px" />
            </div>
        </div>
        <div id="project_details">
            <div id="project_heading" align="center">
                <strong>Project details</strong>
            </div>
            <div id="project_settings">
                <div id="sort_dropdown">
                    <asp:DropDownList ID="dropdown" runat="server" >
                        <asp:ListItem>Current project details</asp:ListItem>
                        <asp:ListItem>Completed project details</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="new_project" align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/addproject.jpg" Height="20px" Width="40px" />
                    <asp:LinkButton ID="add_project" PostBackUrl="~/New.aspx" runat="server">Add Project</asp:LinkButton>
                </div>
                <div id="search">
                    <asp:TextBox ID="textbox1" ClientIDMode="Static"  runat="server"></asp:TextBox>
           <asp:Button ID="btn_search" ClientIDMode="Static" Text="Search" runat="server" OnClientClick="btn_search"  />
                      <div class="suggestions">
              
                        </div>
                </div>
            </div>
            <div id="project_gridview">
            <asp:GridView ID="grid_project" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView3_RowCommand"
                AllowPaging="True"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"  >
             <FooterStyle BackColor="#FFFFCC" ForeColor="#000009" />
             <RowStyle BackColor="White" ForeColor="#000099" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" /> <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center"/>
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />   
                 <Columns>
                      <asp:TemplateField HeaderText="Project id" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblsno" runat="server" Text='<%# Eval("id") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="PM name" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblsno" runat="server" Text='<%# Eval("name") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Projectname" SortExpression="type">
                           <ItemTemplate>
                               <asp:LinkButton ID="lnkbtnedit" runat="server" PostBackUrl="~/Edit.aspx" CommandName="Action"  CommandArgument='<%# Bind("id") %>' Text='<%# (Eval("projectName").ToString())  %>' Width="300px"></asp:LinkButton>
                               <%--<asp:Label ID="lblprojectname" runat="server" Text='<%# (Eval("projectName").ToString())  %>' Width="300px"></asp:Label>--%>
                           </ItemTemplate>
                          
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total hours"  SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblstdate" runat="server" Text='<%# Eval("total_rate") %>' Width="100px"></asp:Label>
                           </ItemTemplate>
                                                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Complited hours" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbleddate" runat="server" Text='<%# Eval("completedHours") %>' Width="100px"></asp:Label>                               
                           </ItemTemplate>
                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Hourlyrate" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblhrate" runat="server" Text='<%# Eval("total_budget") %>' Width="100px"></asp:Label>                               
                           </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField HeaderText="Total budget" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbltbgt" runat="server" Text='<%# Eval("totalpay") %>' Width="100px"></asp:Label>                             
                           </ItemTemplate>                         
                       </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Invoice View" SortExpression="type">
                           <ItemTemplate>
                        <asp:LinkButton ID="lnbtnview" runat="server" Text="View" width="70px"></asp:LinkButton>      
                           </ItemTemplate>
                       </asp:TemplateField>                                 
                     
                      <asp:TemplateField HeaderText="Edit" SortExpression="type">
                           <ItemTemplate>
                              <asp:LinkButton ID="lnkbtnedit" runat="server"  Text="Edit"  Width="70px"></asp:LinkButton>                              
                           </ItemTemplate>
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Delete" SortExpression="type">
                           <ItemTemplate>
                               <asp:LinkButton ID="lnkbtndelete" runat="server" Text="delete" width="70px"></asp:LinkButton>                        
                           </ItemTemplate>
                       </asp:TemplateField>
                      
                   </Columns>
            </asp:GridView>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=AMX-534-PC;Initial Catalog=invoice;Integrated Security=True" 
                     SelectCommand="select u.name as [name], p.name as [projectName],p.total_rate as [total_rate],
                                    (case WHEN  i.completedhours is NULL then 0 else i.completedhours end) as [completedHours],
                                     (case WHEN  i.completedhours is NULL then 0 else i.completedhours end) as [total_budget] ,
                                        p.id as [id],
                                     (case WHEN i.totalpay is NULL then 0 else i.totalpay end) as [totalpay]
                                        from user_details u inner join project p
                                    on u.emp_id=p.emp_id
                                     left outer join invoice_details i on i.project_id=p.id" FilterExpression="name LIKE  '%{0}%'">
                   <FilterParameters>
                        <asp:ControlParameter Name="name" ControlID="textbox1" PropertyName="Text" />
                        </FilterParameters>
               </asp:SqlDataSource>
                </div>
        </div>
        <div id="barchart">
            <div id="chart_heading" align="center">
                <strong>Chart view</strong>
            </div>
            <asp:Chart ID="MobileSalesChart" runat="server" Width="300px" Height="300px" ToolTip="Project Details" BorderlineColor="Gray">
                <Series>
                    <asp:Series Name="samsung" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="complitedhrs"></asp:Series>
                    <asp:Series Name="nokia" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="Remaining hrs"></asp:Series>
                </Series>
                <Legends>
                    <asp:Legend Name="projectdescription" Docking="Bottom" Title="project description" TableStyle="Wide" BorderDashStyle="Solid" BorderColor="#e8eaf1" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                    </asp:Legend>
                </Legends>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX>
                            <MajorGrid Enabled="false" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
        <div id="pending_details">
           <div id="pending_heading" align="center">
           <strong>Pending invoices</strong>
              
           </div>
        </div>
        <div id="updated_details" align="center">
            <div id="update_heading">
            <strong>Raised invoice</strong>
            </div>
        </div>
    </div>
</asp:Content>

