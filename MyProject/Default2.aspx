<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<html>
    <head>
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
                    $('#element_to_pop_up').bPopup()({
                        appendTo: 'form'
                    });;

                });

            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <!-- Element to pop up -->
        <div id="element_to_pop_up">
            Content of popup</div>
    </div>
    </form>
</body>
</html>