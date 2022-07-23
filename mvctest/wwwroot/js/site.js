$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true
    });

    //$.ajax({
    //    type: "POST",
    //    url: "Home",
    //    data: JSON.stringify({}),
    //    contentType: "application/json:charset=utf-8",
    //    dataType: "json",
    //    success: function (json) {
    //        var values = json.GenderCount;
    //        var malecount = parseInt(values[0]);
    //        var femalecount = parseInt(values[1]);


    //    });

});
