<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editinvoice.aspx.cs" Inherits="editinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script src="js/script.js"></script>
    <link rel="stylesheet" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="editinvoice">
        <h3>Edit Invoice Details</h3>
        <table cellspacing="20px" style="width: 379px">
            <tr>
                <td ><asp:Label ID="lbleditstartdate" runat="server" Text="Start Date" Width="150px"></asp:Label></td> 
                <td><asp:TextBox ID="txteditstartdate" OnTextChanged="FTE_Load" AutoPostBack="True" CssClass="pick1" runat="server"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>End Date</td> 
                <td><asp:TextBox ID="txteditenddate" OnTextChanged="FTE_Load" AutoPostBack="True" EnableViewState="false" CssClass="pick1" runat="server" ></asp:TextBox>
                </td>       
            </tr>
            <tr>
                <td>Invoicing Date</td>
                <td><asp:TextBox ID="txteditinvoicedate" OnLoad="txteditinvoicedate_Load" CssClass="pick1"  runat="server" /></td>
            </tr>
            <tr>
                <td>No.of special holidays</td>
                <td><asp:TextBox value="0" ID="txteditspecialholidays" OnTextChanged="txteditspecialholidays_TextChanged" ReadOnly="true" placeholder="Like festivals & etc" AutoPostBack="false"  runat="server"  Width="145px"  /><asp:ImageButton runat="server" ID="imgedittxtspecialholidays" ImageUrl="~/images/edit.png" CssClass="edit" style="margin-left:5px; margin-bottom:-8px;" OnClick="imgedittxtspecialholidays_Click"  /></td>
            </tr> 
            <tr>
                <td >Hours per day</td>        
                <td><asp:TextBox AutoPostBack="true" OnTextChanged="txtedithoursday_TextChanged" ID="txtedithoursday" runat="server" Width="145px" ></asp:TextBox><asp:ImageButton runat="server" ID="imgedittxthoursday" ImageUrl="~/images/edit.png " CssClass="edit" style="margin-left:5px; margin-bottom:-8px; " OnClick="imgedittxthoursday_Click" />
            </tr>
            <tr>
                <td >Completed hours</td>        
                <td><asp:TextBox AutoPostBack="false" OnTextChanged="txteditcompletedhours_TextChanged" ID="txteditcompletedhours" runat="server"   Width="145px"></asp:TextBox><asp:ImageButton ID="imgedittxtcompletedhours"  runat="server" CssClass="edit" ImageUrl="~/images/edit.png " style="margin-left:5px; margin-bottom:-8px; " OnClick="imgedittxtcompletedhours_Click"/>
            </tr>
            <tr>
                <td>Hourly Rate</td>        
                <td><asp:TextBox OnTextChanged="txtedithourlyrate_TextChanged" AutoPostBack="true" ID="txtedithourlyrate" runat="server" Width="145px" ></asp:TextBox><asp:ImageButton ID="imgedittxthourlyrate" runat="server" ImageUrl="~/images/edit.png" CssClass="edit" style="margin-left:5px; margin-bottom:-8px; " OnClick="imgedittxthourlyrate_Click" />
            </tr>
            <tr>
                <td >Total Pay</td>
                <td><asp:TextBox  ID="txtedittotalpay" runat="server" Width="145px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Timesheet</td>
                <td><asp:FileUpload ID="fuedittimesheet" runat="server" /></td>
            </tr>    
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btneditinvoice" runat="server" Text="Update changes" Width="110px" Height="25px" OnClick="btneditinvoice_Click" />                     
                    <asp:Button ID="btnEditInvoiceCancel" runat="server" Text="Back" Width="100px" Height="25px" OnClick="btnEditInvoiceCancel_Click"/>
                </td>
            </tr> 
     </table>
   </div>
</asp:Content>

