<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tabl">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
 <table  id="tbl1"  >
     <tr><th colspan="3">Edit Project</th></tr>
    
     <tr><td >Project Name</td>
         <td><asp:TextBox ID="txtname" placeholder="Project name" runat="server"></asp:TextBox></td>
         <td>
             &nbsp;</td>
     </tr>
     <tr>
         <td >Type of Project</td>
         <td>
             <asp:DropDownList ID="ddltype" CssClass="drop1 drop2" ClientIDMode="Static" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
               
             </asp:DropDownList>
            
         </td>
     </tr>
          <tr><td >Period Of Invoice</td>
         <td>
              <asp:DropDownList ID="ddlpoi" ClientIDMode="Static" AutoPostBack="true" CssClass="drop1" runat="server">
                 
             </asp:DropDownList>
               
         </td>
     </tr>
     <tr><td >Project Description</td><td><asp:TextBox ID="txtdesc" CssClass="desc" runat="server" TextMode="MultiLine" Height="80px"></asp:TextBox></td></tr>
    
     <tr><td >Technology</td>
         <td>
             <asp:DropDownList CssClass="drop1" AutoPostBack="true" ID="ddltech" runat="server">
             </asp:DropDownList>
            </td>
         <td>
             &nbsp;</td>
     </tr>
        <tr><td >Point of Contact</td>
         <td>
              <asp:DropDownList ID="ddlpoc" CssClass="drop1"  runat="server">
                 <asp:ListItem  Text="<-- Select Point of Contact-->"></asp:ListItem>
            
                 
             </asp:DropDownList>
               
         </td>
     </tr>
     
    

     <tr><td >Finance Assignee</td>
         <td>
            <asp:DropDownList ID="ddlassignee" CssClass="drop1" runat="server">
                 <asp:ListItem Value="" Text="<-- Select Assignee name-->"></asp:ListItem>
                 <asp:ListItem Text="Kavitha" Value="name"></asp:ListItem>
             </asp:DropDownList>            
         </td>
         <td>
             &nbsp;</td>
     </tr>
     <tr><td >Start Date</td>
         <td ><asp:TextBox ID="txtstart" TextMode="Date" CssClass="pick1"  runat="server"></asp:TextBox>
          
         </td></tr>
     <tr><td >End Date</td>
         <td> <asp:TextBox ID="txtenddate" TextMode="Date" CssClass="pick"  runat="server" ></asp:TextBox>
             
            
         </td></tr>
     <tr><td >Total Hours</td><td><asp:TextBox ID="txthours" CssClass="thours" runat="server"></asp:TextBox>
        
          </td></tr>
     
     <tr>
         <td class="auto-style1">Hourly Rate</td>
         <td><asp:TextBox ID="txtrate" CssClass="rate1" runat="server"></asp:TextBox></td>
         <td>
             &nbsp;</td>
     </tr>
      <tr>
            <td class="auto-style3">No of Resources</td>
            <td class="auto-style5">
            <asp:TextBox ID="txtresources1" CssClass="thours" runat="server"></asp:TextBox>
            <a href="javascript:void(0);" id='a1'>
             </a></td>
       </tr>
      <tr>
         <td>Project Status</td>
         <td>
             <asp:DropDownList ID="ddlstatus" CssClass="drop1 drop2" AutoPostBack="True" runat="server" OnSelectedIndexChanged="status_SelectedIndexChanged" >
                
                 <asp:ListItem Text="In progress" Value="0"></asp:ListItem>
                 <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                  
             </asp:DropDownList>

         </td>
     </tr>
     <tr><td ></td>
         <td>
            
             <asp:Button ID="btnsubmit" CssClass="btnsubmit" Text="Submit" runat="server"  OnClick="btnsubmit_Click"  />
              <asp:Button ID="btncancel" CssClass="cancel"  Text="Cancel" runat="server" OnClick="btncancel_Click"  />
         </td>
     </tr>
    
 
</table>
   </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddltype" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
      </div>  
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(afterAsycUpdate);


        function afterAsycUpdate() {
            pageEvents();
            datepicker();
        }
    </script>
</asp:Content>

