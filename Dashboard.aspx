<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript" src="jquery-1.11.3.js"></script>
    <script type="text/javascript" src="JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                    <asp:DropDownList ID="dwnproject" ClientIDMode="Static" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" >
                        <asp:ListItem Value="1">Current project details</asp:ListItem>
                        <asp:ListItem Value="0">Completed project details</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="new_project" align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/addproject.jpg" Height="20px" Width="40px" />
                    <asp:LinkButton ID="add_project" runat="server">Add Project</asp:LinkButton>
                </div>
                <div id="search">
                    <asp:TextBox ID="textbox1" ClientIDMode="Static"  runat="server"></asp:TextBox>
           <asp:Button ID="btn_search" ClientIDMode="Static" Text="Search" runat="server" OnClientClick="btn_search"  />
                      <div class="suggestions">              
                        </div>
                </div>
            </div>
            <div id="project_gridview">
            <asp:GridView ID="dtgproject" runat="server" AutoGenerateColumns="False"  DataKeyNames="id"  DataSourceID="sqldatasource" 
                AllowPaging="True"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"  OnRowCommand="GridView3_RowCommand">
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
                        <asp:TemplateField HeaderText="Projectname" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblprojectname" runat="server" Text='<%# (Eval("name").ToString())  %>' Width="300px"></asp:Label>
                           </ItemTemplate>
                          
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total hours"  SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblstdate" runat="server" Text='<%# Eval("total_hours") %>' Width="100px"></asp:Label>
                           </ItemTemplate>
                                                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Complited hours" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbleddate" runat="server" Text='<%# Eval("completedhours") %>' Width="100px"></asp:Label>                               
                           </ItemTemplate>
                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Hourlyrate" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblhrate" runat="server" Text='<%# Eval("hourly_rate") %>' Width="100px"></asp:Label>                               
                           </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField HeaderText="Total budget" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbltbgt" runat="server" Text='<%# Eval("total_budget") %>' Width="100px"></asp:Label>                             
                           </ItemTemplate>                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Complited budget" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblcbgt" runat="server" Text='<%# Eval("totalpay") %>' Width="90px"></asp:Label>                             
                           </ItemTemplate>                      
                       </asp:TemplateField>   
                     <asp:TemplateField HeaderText="Invoice View" SortExpression="type">
                           <ItemTemplate>
                        <asp:LinkButton ID="lnbtnview" runat="server" Text="View" width="70px"></asp:LinkButton>      
                           </ItemTemplate>
                       </asp:TemplateField>                                 
                      <asp:TemplateField HeaderText="Edit" SortExpression="type">
                           <ItemTemplate>
                              <asp:LinkButton ID="lnkbtnedit" runat="server"  Text="Edit"  CommandName="Action"  CommandArgument='<%# Bind("id") %>' Width="70px"></asp:LinkButton>                              
                           </ItemTemplate>
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Delete" SortExpression="type">
                           <ItemTemplate>
                               <asp:LinkButton ID="lnkbtndelete" runat="server" Text="delete" width="70px"></asp:LinkButton>                        
                           </ItemTemplate>
                       </asp:TemplateField>
                      
                   </Columns>
            </asp:GridView>
              
                 <asp:SqlDataSource runat="server" ID="sqldatasource" ConnectionString="Data Source=AMX-504-PC;Initial Catalog=sample;Integrated Security=True" SelectCommand="Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,s.completedhours,s.totalpay From project e LEFT JOIN invoice_details s on e.id = project_id where e.project_status=1 " FilterExpression="name LIKE  '%{0}%'">
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
              </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dwnproject" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

