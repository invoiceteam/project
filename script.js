function pageEvents() {


    var cnt = 1;
    $("#a2").click(function () {
        $(".pick1").prop("disabled", false);
    });
    $("#a1").click(function () {
        $(".pick").prop("disabled", false);
    });
    $("#a3").click(function () {
        $(".thours").prop("disabled", false);
    });
    var click = 0, j = 0, cnt = 5, val = 0;
    $("#anc_add").click(function () {


        click++;

        for (var i = j; i < click; i++) {
            $('#tbl1 tr:eq(' + cnt + ')').first().after('<tr><td>Point of Contact </td><td> <input type="text" placeholder="name2" name="pocName[]"></td><td> <input type="Email" placeholder="Email id" name="pocEmail[]"></td></tr>');
            cnt++;
            val++;
        }
        j++;

    });

    $("#anc_rem").click(function () {
        if (click > 0) {
            click--;
            for (var i = j; i > click; i--) {
                $('#tbl1 tr:eq(' + cnt + ')').remove();
                cnt--;
            }
            j--;
        }
    });


    $(".rate1").click(function () {
        var date1 = $(".pick1").val();
        var date2 = $(".pick").val();
        var d1 = new Date(date1);
        var d2 = new Date(date2);
        if (d1 > d2)
            alert('Please give correct date');
    });

    $("form").submit(function (event) {
        console.log($(this).serializeArray());
        //event.preventDefault();
    });

}

$(document).ready(function () {
  //  $(".pwd tr td:first-of-type").next().hide();
    $(".pwd tr td:first-of-type").click(function () {
        $(this).next().toggle(); // why toggle is not performed in this line 
    });
    $(function () {

        $(".pick1").datepicker();
        $(".pick").datepicker();
    });

});
function datepicker() {

    $(function () {

        $(".pick1").datepicker();
        $(".pick").datepicker();
    });





}
