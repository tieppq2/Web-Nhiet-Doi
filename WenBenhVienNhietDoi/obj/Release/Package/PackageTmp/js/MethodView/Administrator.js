var files;
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imghinhanh').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$.post("/Administrator/PostMethod",
function (response) {
        $("#danhmuc").select2ToTree({ treeData: { dataArr: response }, maximumSelectionLength: 3 });
    }
)
$("#btn_brow_IMG").change(function () {
    files = this.files;
    readURL(this);
});
$('#datepicker_NgayDang').datepicker({
    weekStart: 1,
    daysOfWeekHighlighted: "6,0",
    autoclose: true,
    todayHighlight: true,
});
$('#datepicker_NgayDang').datepicker("setDate", new Date());
$('#capnhat').click(function () { 
    var valdata = renderdata();
    $.ajax({
        url: "/Administrator/CreateTinTuc",
        type: "POST",
        contentType: false,
        processData: false,
        data: valdata,
        success: function (response) {
            if (response == 'File uploaded successfully')
                location.reload();
            console.log(response);
        },
        error: function (xhr, status, p3, p4) {
            var err = "Error " + " " + status + " " + p3 + " " + p4;
            if (xhr.responseText && xhr.responseText[0] == "{")
                err = JSON.parse(xhr.responseText).Message;
            console.log(err);
        }
    });  
})
function uploadImage () {
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            data.append("file", files[0]);

            $.ajax({
                type: "POST",
                url: '/Administrator/UploadHomeReport',
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    console.log(result);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
}
function renderdata() {

    var formData = new FormData(); 
    formData.append("idTinTuc", 0);
    formData.append("LoaiTinTuc", $("#danhmuc option:selected").val().trim());
    formData.append("TieuDe", $("#tieude").val());
    formData.append("TomTatNoiDung", $("#txtlead").val());
    var editorText = CKEDITOR.instances.htmlNoiDung.getData();
    formData.append("NoiDung", editorText);
    formData.append("Avata", '/Images/'+files[0].name);
    formData.append("NgayTao", $("#datepicker_NgayDang").val());
    formData.append("NgaySua", $("#datepicker_NgayDang").val());
    formData.append("NgayDuyet", $("#datepicker_NgayDang").val());
    formData.append("TrangThai",2 );
    formData.append("NguoiTao", 1);
    formData.append("NguoiSua", 1);
    formData.append("NguoiDuyet", 1);
    formData.append("Url_file", null);
    formData.append("SoLuongXem", 0);
    formData.append("CrawData", null);
    formData.append("Type", $("#trangthai option:selected").val().trim());
    formData.append("MenuParent", "");
    formData.append("TenMenu", "");
    formData.append("CapMenu", 1);
    formData.append("FileImages", files[0]);
    //Objectdata["TieuDe"] = $("#tieude").val().trim();
    //var Objectdata = {};    
    //Objectdata["LoaiTinTuc"] = $("#danhmuc option:selected").val().trim();

    //Objectdata["TieuDe"] = $("#tieude").val().trim();

    //Objectdata["TomTatNoiDung"] = $("#txtlead").val();
    //Objectdata["NoiDung"] = $("#htmlNoiDung").text();
    //Objectdata["Avata"] = files[0];
    ////Objectdata["TrangThai"] = $("#group").val().trim();
    //Objectdata["NgayTao"] = $("#datepicker_NgayDang").val();
    //Objectdata["NgaySua"] = $("#datepicker_NgayDang").val();
    //Objectdata["TrangThai"] = $("#trangthai option:selected").val();
    //Objectdata["NguoiTao"] = 1; 

    return formData;
    
}
$('#loadtinbai').click(function () {
    var formData = new FormData();
    formData.append("type", $("#trangthai").val());
    formData.append("status", $("#type_delete").val());
    formData.append("loaitintuc", $("#danhmuc option:selected").val());
    formData.append("tungay", JSON.stringify($("#datepicker_tungay").val()));
    formData.append("denngay", JSON.stringify($("#datepicker_denngay").val()));
    var data = "type=" + $("#trangthai").val() + "&status=" + $("#type_delete").val() + "&loaitintuc=" + $("#danhmuc option:selected").val()
        + "&tungay=" + $("#datepicker_tungay").val() + "&denngay=" + $("#datepicker_denngay").val();
    var table = $('#example1').DataTable();
    table.destroy();

    var url = "/Administrator/DanhSachTinTuc?" + data;
    $.ajax({
        type: "POST",
        url: url,
        //data: "query=" + query + '&_token=' + _token,
        cache: false,

        success: function (html) {
            //html is a json_encode array so we need to parse it before using
            var result = jQuery.parseJSON(html);
            $('#example1').DataTable({
                //here is the solution
                "data": result,
                "ajax": {
                    "url": result,
                    "dataSrc": ""
                },
                "columns": [
                    { "data": "idTinTuc" },
                    { "data": "TieuDe" },
                    { "data": "TomTatNoiDung" },
                    { "data": "TenMenu" },
                    { "data": "NgayDuyet" },
                    { "data": "NgayDuyet" },
                    { "data": "Avata" },
                    { "data": "CrawData" },
                    { "data": "Type" },
                    { "data": "TrangThai" }
                ]
            });
        }
    });
    //$.ajax({
    //    url: "/Administrator/DanhSachTinTuc?" + data,
    //    type: "POST",
    //    contentType: false,
    //    async: false,
    //    dataType: 'text',
    //    processData: false,
    //    //data: {
    //    //    type: $("#trangthai").val(),
    //    //    status: $("#type_delete").val(),
    //    //    loaitintuc: $("#danhmuc option:selected").val(),
    //    //    tungay: JSON.stringify($("#datepicker_tungay").val()),
    //    //        denngay: JSON.stringify($("#datepicker_denngay").val())
    //    //},
    //    success: function (response) {
    //        var tblEmployee = $("#example1"); 
    //        var data = JSON.parse(response)
    //        //if (response == 'File uploaded successfully')
    //        $.each(data, function (index, item) {
    //                var tr = $("<tr></tr>");
    //                tr.html(("<td>" + item.idTinTuc + "</td>")
    //                    + " " + ("<td>" + item.TieuDe + "</td>")
    //                    + " " + ("<td>" + item.TomTatNoiDung + "</td>")
    //                    + " " + ("<td>" + item.TenMenu + "</td>")
    //                    + " " + ("<td>" + item.NgayDuyet + "</td>")
    //                    + " " + ("<td>" + item.NguoiDuyet + "</td>")
    //                    + " " + ("<td>" + item.Avata + "</td>")
    //                    + " " + ("<td>" + item.CrawData + "</td>")
    //                    + " " + ("<td>" + item.Type + "</td>")
    //                    + " " + ("<td>" + item.TrangThai + "</td>"));
    //                tblEmployee.append(tr);
    //            }); 
    //        console.log(response);
    //    },
    //    error: function (xhr, status, p3, p4) {
    //        var err = "Error " + " " + status + " " + p3 + " " + p4;
    //        if (xhr.responseText && xhr.responseText[0] == "{")
    //            err = JSON.parse(xhr.responseText).Message;
    //        console.log(err);
    //    }
    //});
})