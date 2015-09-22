$(document).ready(function () {

    registerStartup();
    registerStartup1();
  });

function registerStartup() {
    $("#textbox1").keyup(function () {
        var queryString = (location.search).substr(1);        
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "findashboard.aspx/search?" + queryString,
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
                alert("Search was not found");
            }
        });

    });
}
function registerStartup1() {
    $("#txtsearch").keyup(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Dashboard.aspx/search",
            data: "{'searchtext':'" + document.getElementById('txtsearch').value + "'}",
            dataType: "json",
            success: function (data) {

                if (data && data.d) {
                    $('.suggestions').empty();
                    for (var i = 0; i < data.d.length; i++) {
                        $('.suggestions').append('<a>' + data.d[i] + '</a><br/>');
                        $("a").click(function () {
                            $("#txtsearch").val($(this).text());
                        });
                    }
                }
            },
            error: function (result) {
                alert("Search was not found");
            }
        });

    });
}