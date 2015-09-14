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