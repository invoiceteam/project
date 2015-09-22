<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery-1.11.0.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <link href="Styles1.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            $(".pick1").datepicker();
            $(".pick").datepicker();
        });



    </script>

    <style type="text/css">
        .auto-style1
        {
            width: 447px;
        }
        .auto-style2
        {
            width: 322px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="message" runat="server" />
    <asp:Panel ID="mngView" runat="server">
        <div class="tabl">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table id="tbl1">
                        <tr>
                            <th colspan="3">New Project</th>
                        </tr>

                        <tr>
                            <td>Project Name</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox2" placeholder="Project name" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Project Name is Empty" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>Type of Project</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="DropDownList2" CssClass="drop1 drop2" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" onchange>
                                    <asp:ListItem Value="" Text="<-- Select the project type -->"></asp:ListItem>
                                    <asp:ListItem Text="Fixed Project" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Full Time Engagement Project" Value="1"></asp:ListItem>

                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Project Description</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="desc" CssClass="desc" runat="server" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Technology</td>
                            <td class="auto-style2">
                                <asp:DropDownList CssClass="drop1" ID="dropdown" runat="server">
                                    <asp:ListItem Value="" Text="<-- Select Technology -->"></asp:ListItem>
                                    <asp:ListItem Text="Ektron"></asp:ListItem>
                                    <asp:ListItem Text="Sharepoint"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select the technology" ControlToValidate="dropdown" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>Point of Contact</td>
                            <%-- <td style="width: 305px"><asp:TextBox ID="text1" runat="server" placeholder="name"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBox3" runat="server" placeholder="Email id"></asp:TextBox></td>--%>
                            <td class="auto-style2">
                                <input type="text" placeholder="name" name="pocName[]"></td>
                            <td>
                                <input type="Email" placeholder="Email id" name="pocEmail[]"></td>
                            <td style="width: 168px;"><a href="javascript:void(0);" id='anc_add'>
                                <img src="images/Netvibes1.png" class="add" /></a><a href="javascript:void(0);" id='anc_rem'>
                                    <img src="images/button_remove.png" class="add" /></a>
                            </td>
                        </tr>

                        <tr>
                            <td>Period Of Invoice</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="DropDownList1" CssClass="drop1" runat="server">
                                    <asp:ListItem Text="<-- Select Period of Invoice-->"></asp:ListItem>


                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Finance Assignee</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="DropDownList3" CssClass="drop1" runat="server">
                                    <asp:ListItem Value="" Text="<-- Select Assignee name-->"></asp:ListItem>
                                    <asp:ListItem Text="Kavitha" Value="Kavitha"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select the assignee name" ControlToValidate="DropDownList3" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>Start Date</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="start" TextMode="Date" CssClass="pick1" runat="server"></asp:TextBox>
                                <a href="javascript:void(0);" id='a2'>
                                    <img src="images/file_edit.png" class="fileedit" />

                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>End Date</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="enddate" TextMode="Date" CssClass="pick" runat="server"></asp:TextBox>
                                <a href="javascript:void(0);" id='a1'>

                                    <img src="images/file_edit.png" class="fileedit" /></a>

                            </td>
                        </tr>
                        <tr>
                            <td>Total Hours</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="thours" CssClass="thours" runat="server"></asp:TextBox>
                                <a href="javascript:void(0);" id='a3'>
                                    <img src="images/file_edit.png" class="fileedit" />
                                </a>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1">Hourly Rate</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="rate" CssClass="rate1" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter the hourly rate" ControlToValidate="rate" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">SOW</td>
                            <td class="auto-style2">
                                <asp:FileUpload runat="server" AllowMultiple="false" ID="sowupload" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="sowupload" ErrorMessage="Please attach the SOW file"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="auto-style2">

                                <asp:Button ID="btnsubmit" CssClass="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click" />
                                <asp:Button ID="Button1" CssClass="cancel" Text="Cancel" runat="server" OnClick="Button1_Click" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
                    <asp:PostBackTrigger ControlID="btnsubmit" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(afterAsycUpdate);

        function afterAsycUpdate() {
            pageEvents();
        }
    </script>
</asp:Content>

