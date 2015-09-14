<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="popup.aspx.cs" Inherits="popup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        #element_to_pop_up
        {
            background-color: #fff;
            border-radius: 15px;
            color: #000;
            display: none;
            padding: 20px;
            min-width: 400px;
            min-height: 180px;
        }
    </style>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    <script src="jquery.bpopup.min.js"></script>
   <script type="text/javascript">
       $(function () {

           // DOM Ready
           //Short cut for document Ready
           $(function () {

               // Binding a click event
               // From jQuery v.1.7.0 use .on() instead of .bind()
               $('#<%=Button1.ClientID%>').bind('click', function (e) {

                   // Prevents the default action to be triggered.
                   e.preventDefault();

                   // Triggering bPopup when click event is fired
                   $('#element_to_pop_up').bPopup({
                       appendTo: 'form'
                   });
               });
               $('#<%=btnsubmit.ClientID%>').bind('click', function (e) {
                   alert("success...!");
               });
           });
       });
    </script>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <!-- Element to pop up -->
        <div id="element_to_pop_up">
            <asp:Label runat="server" ID="lblname" Text="Enter your name.."></asp:Label>
            <asp:TextBox runat="server" ID="txtname" placeholder="Your name please"></asp:TextBox>
            <asp:Button runat="server" id="btnsubmit" Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>

