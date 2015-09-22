<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery-1.11.0.js" type="text/javascript"></script>
      <script src="js/script.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />


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
                            <td class="auto-style3">Project Name</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtprojectname" placeholder="Project name" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rqdvalidator" runat="server" ErrorMessage="Project Name is Empty" ControlToValidate="txtprojectname" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Type of Project</td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="ddltype" CssClass="drop1 drop2" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" onchange>
                                    <asp:ListItem Value="" Text="<-- Select the project type -->"></asp:ListItem>


                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Project Description</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtdesc" CssClass="desc" runat="server" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td class="auto-style3">Technology</td>
                            <td class="auto-style5">
                                <asp:DropDownList CssClass="drop1" ID="ddltech" runat="server">
                                   
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rqdtech" runat="server" ErrorMessage="Please select the technology" ControlToValidate="ddltech" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Point of Contact</td>
                           
                            <td class="auto-style5">
                                <input type="text" placeholder="name" name="pocName[]"></td>
                            <td>
                                <input type="Email" placeholder="Email id" name="pocEmail[]"></td>
                            <td style="width: 168px;"><a href="javascript:void(0);" id='anc_add'>
                                <img src="images/Netvibes1.png" class="add" /></a><a href="javascript:void(0);" id='anc_rem'>
                                    <img src="images/button_remove.png" class="add" /></a>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style3">Period Of Invoice</td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="ddlpoi" CssClass="drop1" runat="server">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Finance Assignee</td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="ddlfinanance" CssClass="drop1" runat="server">
                                    <asp:ListItem Value="" Text="<-- Select Assignee name-->"></asp:ListItem>
                                    
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select the assignee name" ControlToValidate="ddlfinanance" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Start Date</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtstart" TextMode="Date" CssClass="pick1" runat="server"></asp:TextBox>
                                <a href="javascript:void(0);" id='a2'>
                                    &nbsp;</a></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">End Date</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtenddate" TextMode="Date" CssClass="pick" runat="server"></asp:TextBox>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Total Hours</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtthours" CssClass="thours" runat="server"></asp:TextBox>
                                <a href="javascript:void(0);" id='a3'>
                                    &nbsp;</a></td>
                        </tr>

                        <tr>
                            <td class="auto-style3">Hourly Rate</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtrate" CssClass="rate1" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter the hourly rate" ControlToValidate="txtrate" ForeColor="Red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                              <td class="auto-style3">No of Resources</td>
                            <td class="auto-style5">
                               <asp:TextBox ID="txtresources" CssClass="thours"  runat="server"></asp:TextBox>
                               <a href="javascript:void(0);" id='a1'>
                                 </a></td>

                        </tr>
                        <tr>
                            <td class="auto-style3">SOW</td>
                            <td class="auto-style5">
                                <asp:FileUpload runat="server" AllowMultiple="false" ID="sowupload" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvsow" runat="server" ControlToValidate="sowupload" ErrorMessage="Please attach the SOW file" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3"></td>
                            <td class="auto-style5">

                                <asp:Button ID="btnsubmit" CssClass="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click" />
                                <asp:Button ID="Button1" CssClass="cancel" Text="Cancel" CausesValidation="false" runat="server" OnClick="Button1_Click" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddltype" EventName="SelectedIndexChanged" />
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
            datepicker();

        }
    </script>
</asp:Content>

