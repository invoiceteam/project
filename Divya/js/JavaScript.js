$(document).ready(function () {

    registerStartup();
});

function registerStartup() {
    $("#textbox1").keyup(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Dashboard.aspx/search",
            data: "{'searchtext':'" + document.getElementById('textbox1').value + "'}",
            dataType: "json",
            success: function (data) {

                if (data && data.d) {
                    $('.suggestions').empty();
                    for (var i = 0; i < data.d.length; i++) {
                        $('.suggestions').append('<a>' + data.d[i] + '</a><br/>');
                        $("a").click(function () {
                            $("#textbox1").val($(this).text());
                        });
                    }
                }
            },
            error: function (result) {
                alert("Error....");
            }
        });

    });
}