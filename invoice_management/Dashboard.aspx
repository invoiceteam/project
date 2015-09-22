<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript" src="js/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="js/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div id="dashboard_layout">
        <div id="dashboard_setting">
             <div id="deletedash">
                 </div>
            <div id="setting">
              <asp:ImageButton ID="imbsettings" OnClick="Imgsettings1_Click" runat="server" ImageUrl="~/images/seettings.png" Height="30px" />
            </div>
            <div id="logout">
              <asp:ImageButton ID="imblogout" runat="server" OnClick="logout" ImageUrl="~/images/logout.jpg" Height="25px" />
            </div>
        </div>
        <div id="project_details">
           
            <div id="project_heading" align="center">
                <strong>Project details</strong>
            </div>
            <div id="project_settings">
                <div id="sort_dropdown">
                    <asp:DropDownList ID="ddldwnproject" ClientIDMode="Static" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" >
                        <asp:ListItem Value="0">Current project details</asp:ListItem>
                        <asp:ListItem Value="1">Completed project details</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="btnabort1">
                    <asp:Button runat="server" ClientIDMode="Static" Text="Abandoned projects" ID="btnabort" OnClick="btnabort_Click" />
                </div>
                <div id="new_project" align="center">
                    <asp:Image ID="imgaddproject" runat="server" ImageUrl="~/images/addproject.jpg"  />
                    <asp:LinkButton ID="add_project" OnClick="add_project_Click" runat="server">Add Project</asp:LinkButton>
                </div>
                <div id="search">
                    <asp:TextBox ID="txtsearch" ClientIDMode="Static"  runat="server"></asp:TextBox>
                     <asp:Button ID="btn_search" ClientIDMode="Static" Text="Search" runat="server" OnClientClick="btn_search" OnClick="btn_search_Click" />
                      <div class="suggestions">              
                       </div>
                </div>
            </div>
            <div id="project_gridview">
               
                <asp:Label runat="server"  CssClass="projectwelcome" ID="lblwelcome1" Text="Welcome to Invoice management System Please go to Add Project" Visible="false"></asp:Label>                 
                    
            <asp:GridView ID="dtgproject" runat="server" AutoGenerateColumns="False"  DataKeyNames="id" PageSize="7"  
                AllowPaging="True"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"  OnRowCommand="GridView3_RowCommand" OnPageIndexChanging="dtgproject_PageIndexChanging">
             <FooterStyle BackColor="#FFFFCC" ForeColor="#000009" />
             <RowStyle BackColor="White" ForeColor="#000099" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" /> <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center"/>
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />   
                 <Columns>
                       <asp:TemplateField HeaderText="Project Id" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblsno" runat="server" Text='<%# Eval("id") %>' Width="160px" Height="25px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Name" SortExpression="type">
                           <ItemTemplate>
                               <asp:LinkButton ID="lnkbtnedit" runat="server"  CommandName="Action"  CommandArgument='<%# Bind("id") %>' Text='<%# (Eval("name").ToString())  %>' Width="250px"></asp:LinkButton>  
                           </ItemTemplate>
                            
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Hours"  SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblstdate" runat="server" Text='<%# Eval("total_hours") %>' Width="160px"></asp:Label>
                           </ItemTemplate>
                                                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Completed Hours" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbleddate" runat="server" Text='<%# Eval("completedhours") %>' Width="160px"></asp:Label>                               
                           </ItemTemplate>
                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Hourly Rate" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblhrate" runat="server" Text='<%# Eval("hourly_rate") %>' Width="160px"></asp:Label>                               
                           </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField HeaderText="Total Budget" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lbltbgt" runat="server" Text='<%# Eval("total_budget") %>' Width="160px"></asp:Label>                             
                           </ItemTemplate>                         
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Completed Budget" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblcbgt" runat="server" Text='<%# Eval("totalpay") %>' Width="160px"></asp:Label>                             
                           </ItemTemplate>                      
                       </asp:TemplateField>                                                          
                   </Columns>
            </asp:GridView>
              
                </div>
        </div>
        <div id="barchart">
            <div id="chart_heading" align="center">
                <strong>Chart view</strong>
            </div>
            <asp:Chart ID="MobileSalesChart" runat="server" Width="300px" Height="300px" ToolTip="Project Details" BorderlineColor="Gray">
                <Series>
                    <asp:Series Name="completed" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="Raised hrs"></asp:Series>
                    <asp:Series Name="pending" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="Remaining hrs"></asp:Series>
                </Series>
                <Legends>
                    <asp:Legend Name="projectdescription" Docking="Bottom" Title="project description" TableStyle="Wide" BorderDashStyle="Solid" BorderColor="#e8eaf1" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                    </asp:Legend>
                </Legends>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX>
                            <MajorGrid Enabled="true" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
        <div id="pending_details">
           <div id="pending_heading" align="center">
           <strong>Outstanding Invoices</strong>   
                </div>
            <div class="pendinggrid">
            <asp:GridView ID="dtgpending" runat="server" AutoGenerateColumns="False"  DataKeyNames="project_id"  
                AllowPaging="True"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"  OnRowCommand="GridView3_RowCommand">
             <FooterStyle BackColor="#FFFFCC" ForeColor="#000009"  />
             <RowStyle BackColor="White" ForeColor="#000099" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" /> <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center"/>
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />   
                 <Columns>
                       <asp:TemplateField HeaderText="Project id" SortExpression="type">
                           <ItemTemplate>
                            
                               <asp:Label ID="lblid" runat="server" Text='<%# Eval("project_id") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Projectname" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Invoicenumber" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblno" runat="server" Text='<%# Eval("invoicenumber") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      </Columns>
                </asp:GridView>
          <asp:Panel runat="server" ID="pnlpending" Visible="false" CssClass="projectwelcome2" ClientIDMode="Static">
             <asp:Label runat="server"  ID="lblwelcome" Text="No Outstanding invoices " ></asp:Label>
                </asp:Panel>
        </div>
        </div>
        <div id="updated_details" align="center">
            <div id="update_heading">
            <strong>Raised invoices</strong>
            </div>
            <div class="raisedgrid">
            <asp:GridView ID="dtgraisedinvoice" runat="server" AutoGenerateColumns="False"  DataKeyNames="project_id"  
                AllowPaging="True"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"  OnRowCommand="GridView3_RowCommand" >
             <FooterStyle BackColor="#FFFFCC" ForeColor="#000009" />
             <RowStyle BackColor="White" ForeColor="#000099" />
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" /> <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center"/>
             <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />   
                 <Columns>
                       <asp:TemplateField HeaderText="Project id" SortExpression="type">
                           <ItemTemplate>
                            
                               <asp:Label ID="lblid1" runat="server" Text='<%# Eval("project_id") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Projectname" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblname1" runat="server" Text='<%# Eval("name") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Invoicenumber" SortExpression="type">
                           <ItemTemplate>
                               <asp:Label ID="lblinvoiceno" runat="server" Text='<%# Eval("invoicenumber") %>' Width="30px"></asp:Label>
                           </ItemTemplate>
                            </asp:TemplateField>
                      </Columns>
                </asp:GridView>
                
                     <asp:Panel runat="server" ID="pnlraised" CssClass="projectwelcome1" ClientIDMode="Static" Visible="false">
             <asp:Label runat="server" CssClass="projectwelcome1" ID="lblraisedinvoice" Text="Your Invoices are not yet Raised by the Finance team" ></asp:Label>
                </asp:Panel>
                  </div>       
        
        </div>
    </div>
              </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddldwnproject" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(registerMethods);
        function registerMethods() {
            registerStartup1();
        }
  
       function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };

    </script>
 
</asp:Content>

