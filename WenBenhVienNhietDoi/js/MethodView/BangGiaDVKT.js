$(document).ready(function () {
    var url = '/BangGiaDVKT/GetDetailsTinTuc';
    $('#Table_DV').DataTable({
        autofill: true,
        "scrollY": "800px",
        "scrollCollapse": true,
        "paging": false,
        length: 10,
        "lengthChange": false,
        "searching": false,
        "ordering": false,
        "bInfo": false,
        "language": {
            "url": "/lib/Vietnamese.json",
            "paginate": {
                "first": '<i class="fa fa-angle-double-left"></i>',
                "previous": '<i class="fa fa-angle-left"></i>',
                "next": '<i class="fa fa-angle-right"></i>',
                "last": '<i class="fa fa-angle-double-right"></i>'
            }
        },
        "ajax": {
            "url": url,
            "dataSrc": "",
            "type": "GET"
        },
        "columns": [
            {
                "data": "STT",
                "name": "STT",
                //render: function (data) {
                //    return '<a  href="/Administrator/DangBai/' + data + '" style="color: #031fe6;" >' + data + '</a>'
                //}
            },
            {
                "data": "MA_DV",
                "name": "Mã dịch vụ"
            },
            {
                "data": "TEN_DV",
                "name": "Tên dịch vụ"
            },
            {
                "data": "GIA_TT13",
                "name": "Đơn Giá"
            },          
        ],
        order: [
            [0, 'ASC']
        ]
    });


    //var url = '/BangGiaDVKT/GetDetailsTinTuc';
    //$.ajax({
    //    type: "GET",
    //    url: url,
    //    contentType: false,
    //    processData: false,
    //    success: function (result) {
    //        var t = $('#Table_DV').DataTable();
    //        //$.each(result, function (nKey, oData) {
    //        //    t.row.add([{
    //        //        0: oData.STT,
    //        //        1: oData.MA_DV,
    //        //        2: oData.TEN_DV,
    //        //        3: oData.GIA_TT13,
    //        //    }]).draw(false);
    //        //});
            
    //        //t.row.add([
    //        //    result.STT,
    //        //    result.MA_DV,
    //        //    result.TEN_DV,
    //        //    result.GIA_TT13
    //        //]).draw(false);

    //    },
    //    error: function (xhr, status, p3, p4) {
    //        var err = "Error " + " " + status + " " + p3 + " " + p4;
    //        if (xhr.responseText && xhr.responseText[0] == "{")
    //            err = JSON.parse(xhr.responseText).Message;
    //        console.log(err);
    //    }
    //});
});
$('table').on('scroll', function () {
    $("#" + this.id + " > *").width($(this).width() + $(this).scrollLeft());
});