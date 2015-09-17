<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jquery-1.11.0.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <link href="Styles1.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tabl">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
 <table  id="tbl1"  >
     <tr><th colspan="3">Edit Project</th></tr>
    
     <tr><td >Project Name</td>
         <td><asp:TextBox ID="TextBox2" placeholder="Project name" runat="server"></asp:TextBox></td>
         <td>
             &nbsp;</td>
     </tr>
     <tr>
         <td >Type of Project</td>
         <td>
             <asp:DropDownList ID="DropDownList2" CssClass="drop1 drop2" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" onchange>
                
                 <asp:ListItem Text="Fixed Project" Value="0"></asp:ListItem>
                 <asp:ListItem Text="Full Time Engagement Project" Value="1"></asp:ListItem>
                  
             </asp:DropDownList>
            
         </td>
     </tr>
          <tr><td >Period Of Invoice</td>
         <td>
              <asp:DropDownList ID="DropDownList1" CssClass="drop1" runat="server">
                 <asp:ListItem  Text="<-- Select Period of Invoice-->"></asp:ListItem>
            
                 
             </asp:DropDownList>
               
         </td>
     </tr>
     <tr><td >Project Description</td><td><asp:TextBox ID="desc" CssClass="desc" runat="server" TextMode="MultiLine" Height="80px"></asp:TextBox></td></tr>
    
     <tr><td >Technology</td>
         <td>
             <asp:DropDownList CssClass="drop1" AutoPostBack="true" ID="dropdown" runat="server">
             </asp:DropDownList>
            </td>
         <td>
             &nbsp;</td>
     </tr>
        <tr><td >Point of Contact</td>
         <td>
              <asp:DropDownList ID="DropDownList4" CssClass="drop1"  runat="server">
                 <asp:ListItem  Text="<-- Select Point of Contact-->"></asp:ListItem>
            
                 
             </asp:DropDownList>
               
         </td>
     </tr>
     
    

     <tr><td >Finance Assignee</td>
         <td>
            <asp:DropDownList ID="DropDownList3" CssClass="drop1" runat="server">
                 <asp:ListItem Value="" Text="<-- Select Assignee name-->"></asp:ListItem>
                 <asp:ListItem Text="Kavitha" Value="name"></asp:ListItem>
             </asp:DropDownList>            
         </td>
         <td>
             &nbsp;</td>
     </tr>
     <tr><td >Start Date</td>
         <td ><asp:TextBox ID="start" TextMode="Date" CssClass="pick1"  runat="server"></asp:TextBox>
          
         </td></tr>
     <tr><td >End Date</td>
         <td> <asp:TextBox ID="enddate" TextMode="Date" CssClass="pick"  runat="server" ></asp:TextBox>
             
            
         </td></tr>
     <tr><td >Total Hours</td><td><asp:TextBox ID="thours" CssClass="thours" runat="server"></asp:TextBox>
        
          </td></tr>
     
     <tr>
         <td class="auto-style1">Hourly Rate</td>
         <td><asp:TextBox ID="rate" CssClass="rate1" runat="server"></asp:TextBox></td>
         <td>
             &nbsp;</td>
     </tr>
     
      <tr>
         <td>Project Status</td>
         <td>
             <asp:DropDownList ID="status" CssClass="drop1 drop2" AutoPostBack="True" runat="server" >
                
                 <asp:ListItem Text="In progress" Value="0"></asp:ListItem>
                 <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                  
             </asp:DropDownList>

         </td>
     </tr>
     <tr><td ></td>
         <td>
            
             <asp:Button ID="btnsubmit" CssClass="btnsubmit" Text="Submit" runat="server"  OnClick="btnsubmit_Click"  />
              <asp:Button ID="Button1" CssClass="cancel"  Text="Cancel" runat="server" OnClick="Button1_Click"  />
         </td>
     </tr>
    
 
</table>
   </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
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

