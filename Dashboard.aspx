<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="dashboard_layout">
        <div id="settings">
        </div>
        <div id="project_details">
            <asp:GridView ID="GridView1" runat="server" PageSize="10" AutoGenerateColumns="false"
                AllowPaging="true"
                BackColor="White"
                BorderColor="#CC9966"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#000009" />
                <RowStyle BackColor="White" ForeColor="#000099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <Columns>
                    <asp:TemplateField HeaderText="S.no">
                        <ItemTemplate>
                            <asp:Label ID="lblstId" runat="server" Text='<%#Eval ("stId")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Project name">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Visible="true" Width="450px" Text='<%#Eval ("name")%>'></asp:Label>

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total hours">
                        <ItemTemplate>
                            <asp:Label ID="lblClassName" runat="server" Width="20px" Visible="true" Text='<%#Eval ("Classname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Complited hours">
                        <ItemTemplate>
                            <asp:Label ID="lblRollNo" runat="server" Width="20px" Visible="true" Text='<%#Eval ("rollno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total budget">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailId" runat="server" Visible="true" Width="100px" Text='<%#Eval ("emailId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Complited budget" ShowHeader="false">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailId" runat="server" Visible="true" Width="80px" Text='<%#Eval ("emailId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="barchart">
            <asp:Chart ID="MobileSalesChart" runat="server" Width="300px" Height="300px" ToolTip="Mobile Sales" BorderlineColor="Gray">
                <Series>
                    <asp:Series Name="samsung" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="complitedhrs"></asp:Series>
                    <asp:Series Name="nokia" IsValueShownAsLabel="true" ChartType="StackedColumn" LegendText="Remaining hrs"></asp:Series>
                </Series>
                <Legends>
                    <asp:Legend Name="MobileBrands" Docking="Bottom" Title="project description" TableStyle="Wide" BorderDashStyle="Solid" BorderColor="#e8eaf1" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
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
        </div>
        <div id="updated_details">
        </div>
    </div>
</asp:Content>

