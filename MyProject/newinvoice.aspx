<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newinvoice.aspx.cs" Inherits="newinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="newinvoice">
        <h3>Invoice Details</h3>
        <table cellspacing="20px" style="width: 379px">
            <tr>
                <td >Start Date</td> 
                <td><asp:TextBox ID="txtstartdate" runat="server" TextMode="Date"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>End Date</td> 
                <td><asp:TextBox ID="txtenddate" runat="server" TextMode="Date"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>Invoicing Date</td>
                <td><asp:TextBox ID="txtinvoicedate" TextMode="Date"  runat="server" /></td>
            </tr>
            <tr>
                <td >Completed hours</td>        
                <td><asp:TextBox ID="txtcompletedhours" runat="server" Width="138px" OnTextChanged="txtcompletedhours_TextChanged"></asp:TextBox>
            </tr>
            <tr>
                <td>Hourly Rate</td>        
                <td><asp:TextBox ID="txthourlyrate" ReadOnly="true" value="8" runat="server" Width="138px" OnTextChanged="txthourlyrate_TextChanged"></asp:TextBox><asp:ImageButton runat="server" ImageUrl="~/images/edit.jpg" OnClick="Unnamed1_Click" />
            </tr>
            <tr>
                <td >Total Pay</td>
                <td><asp:TextBox  ID="txttotalpay" runat="server" Width="138px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Timesheet</td>
                <td><asp:FileUpload ID="futimesheet" runat="server" /></td>
            </tr>    
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="70px" Height="25px" OnClick="btnsubmit_Click"/>                     
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="70px" Height="25px" />
                </td>
            </tr> 
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>        
     </table>
   </div>
</asp:Content>