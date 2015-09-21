<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newinvoice.aspx.cs" Inherits="mypage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">

 </script>
      <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script src="js/script.js"></script>
    <link rel="stylesheet" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="newinvoice">
        <h3>Invoice Details</h3>

        <table cellspacing="20px" style="width: 379px">
            <tr>
                <td ><asp:Label runat="server" Text="Start Date" Width="150px"></asp:Label></td> 
                <td><asp:TextBox ID="txtstartdate" AutoPostBack="True" OnTextChanged="FTE_Load" CssClass="pick1" runat="server"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>End Date</td> 
                <td><asp:TextBox ID="txtenddate" AutoPostBack="True" OnTextChanged="FTE_Load" EnableViewState="false" CssClass="pick1" runat="server" ></asp:TextBox>
                </td>       
            </tr>
            <tr>
                <td>Invoicing Date</td>
                <td><asp:TextBox ID="txtinvoicedate" OnLoad="txtinvoicedate_Load" CssClass="pick1"  runat="server" /></td>
            </tr>
            <tr>
                <td>No.of special holidays</td>
                <td><asp:TextBox ID="txtspecialholidays" ReadOnly="true" placeholder="Like festivals & etc" AutoPostBack="false"  runat="server"  Width="145px"  /><asp:ImageButton runat="server" ID="edittxtspecialholidays" OnClick="edittxtspecialholidays_Click" ImageUrl="~/images/edit.png " CssClass="edit" style="margin-left:5px; margin-bottom:-8px; " /></td>
            </tr> 
            <tr>
                <td >Hours per day</td>        
                <td><asp:TextBox AutoPostBack="true" OnTextChanged="txthoursday_TextChanged" ID="txthoursday" value="8" runat="server" Width="145px" ></asp:TextBox><asp:ImageButton runat="server" ID="edittxthoursday" OnClick="edittxthoursday_Click" ImageUrl="~/images/edit.png " CssClass="edit" style="margin-left:5px; margin-bottom:-8px; " />
            </tr>
            <tr>
                <td >Completed hours</td>        
                <td><asp:TextBox AutoPostBack="false" ID="txtcompletedhours" ClientIDMode="Static" runat="server" OnTextChanged="txtcompletedhours_TextChanged"  Width="145px" ></asp:TextBox><asp:ImageButton ID="edittxtcompletedhours" OnClick="edittxtcompletedhours_Click"  runat="server" CssClass="edit" ImageUrl="~/images/edit.png " style="margin-left:5px; margin-bottom:-8px; " />
            </tr>
            <tr>
                <td>Hourly Rate</td>        
                <td><asp:TextBox AutoPostBack="true" OnTextChanged="txthourlyrate_TextChanged" ID="txthourlyrate" runat="server" Width="145px" ></asp:TextBox><asp:ImageButton ID="edittxthourlyrate" OnClick="edittxthourlyrate_Click" runat="server" ImageUrl="~/images/edit.png" CssClass="edit" style="margin-left:5px; margin-bottom:-8px; " />
            </tr>
            <tr>
                <td >Total Pay</td>
                <td><asp:TextBox  ID="txttotalpay" runat="server" Width="145px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Timesheet</td>
                <td><asp:FileUpload ID="futimesheet" runat="server" /></td>
            </tr>    
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="70px" Height="25px" OnClick="btnsubmit_Click" />                     
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="70px" Height="25px" OnClick="btncancel_Click" />
                </td>
            </tr> 
     </table>
   </div>
</asp:Content>

