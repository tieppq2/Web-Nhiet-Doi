var files;
$(document).ready(function () {
    //var dataTinTuc = @ViewBag.TinTuc_Details;
    var pageURL = $(location).attr("href");
    if (pageURL.indexOf('DangBai') != -1) {
        if (id !== 0) {
            $.ajax({
                url: "/Administrator/GetDetailsTinTuc/" + id,
                type: "POST",
                contentType: false,
                processData: false,
                //data: valdata,
                success: function (response) {
                    //$("#danhmuc").append("<option value='" + response[0].LoaiTinTuc + "' selected>" + response[0].TenMenu + "</option>");
                    $("#danhmuc").val(response[0].LoaiTinTuc).trigger('change.select2');;
                    //$('#danhmuc').select2(response[0].LoaiTinTuc, response[0].TenMenu);
                    $("#tieude").val(response[0].TieuDe);
                    $("#txtlead").val(response[0].TomTatNoiDung);
                    CKEDITOR.instances['htmlNoiDung'].setData(response[0].NoiDung)
                    //$("#htmlNoiDung").val(response.);
                    $('#imghinhanh').attr('src', response[0].Avata);
                    $('#trangthai').val(response[0].Type);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        }
    }
    else {
        var data = "type=" + $("#trangthai").val() + "&status=" + $("#type_delete").val() + "&loaitintuc=0"
            + "&tungay=" + $("#datepicker_tungay").val() + "&denngay=" + $("#datepicker_denngay").val();
        loaddataDefault(data);
    }
});
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
        } 
    }
}
function renderdata() {
    var formData = new FormData(); 
    formData.append("idTinTuc", id);
    formData.append("LoaiTinTuc", $("#danhmuc option:selected").val().trim());
    formData.append("TieuDe", $("#tieude").val());
    formData.append("TomTatNoiDung", $("#txtlead").val());
    var editorText = CKEDITOR.instances.htmlNoiDung.getData();
    formData.append("NoiDung", editorText);
    if(id === 0 )
        formData.append("Avata", '/Images/' + files[0].name);
    else
        formData.append("Avata", $("#imghinhanh").attr('src'));
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
    if (files !== undefined)
        formData.append("FileImages", files[0]);
    return formData;
    
}

function loaddataDefault(data) {
    

    var table = $('#example1').DataTable();
    table.destroy();

    var url = "/Administrator/DanhSachTinTuc?" + data;

    $('#example1').DataTable({
        autofill: true,
        select: true,
        responsive: true,
        buttons: true,
        length: 10,
        //"bSort": false,
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
            "type": "POST"
        },
        "columns": [
            {
                "data": "idTinTuc",
                "name": "ID",
                render: function (data) {
                    return '<a  href="/Administrator/DangBai/' + data + '" style="color: #031fe6;" >' + data+'</a>'
                }
            },
            {
                "data": "TieuDe",
                "name": "Title"
            },
            {
                "data": "TomTatNoiDung",
                "name": "Sampo"
            },
            {
                "data": "TenMenu",
                "name": "Danh mục"
            },
            {
                "data": "NgayTao",
                "name": "Ngày đăng",
                render: function (data) {
                    return data.substring(0, 10);
                }
            },
            {
                "data": "NguoiDuyet",
                "name": "Người Đăng"
            },
            {
                "data": "Avata",
                "name": "Avata",
                render: function (data, type, full, meta) {
                    if (data === null || data === undefined || data === "")
                        return '';
                    else
                        return '<a><img " style="max-width: 200px; max-height=100px" src="' + data + '" alt="" /></a>';
                    //return '<img  data-image-id-anhdaidien ="' + data.camera_image + '" style="max-width: 80px;" src="' + HOST_UPLOAD_ADMIN + '/uploads/' + data.camera_image + '" alt="" />';
                }
            },
            {
                "data": "CrawData",
                "name": "CrawData",
                render: function (data) {
                    if (data === 1)
                        return '\n\ <label class="switch"><input class="checkStatus" type= "checkbox" id="' + data + '" checked disabled="disabled"><span class="slider round"></span></label>';
                    else
                        return '\n\ <label class="switch"><input class="checkStatus" type= "checkbox" id="' + data + '" disabled="disabled"><span class="slider round"></span></label>';
                }
            },
            {
                "data": null,
                "name": 'Status',
                render: function (data) {
                    var _Type = data.Type == 2 ? 'true' : 'false';
                    if (data.TrangThai === 1)
                        return '\n\ <label class="switch"><input class="checkStatus" onchange="AdminUpdateStatusMes(this.id,this.checked,' + _Type + ')" type= "checkbox" id="' + data.idTinTuc + '" checked ><span class="slider round"></span></label>';
                    else
                        return '\n\ <label class="switch"><input class="checkStatus" onchange="AdminUpdateStatusMes(this.id,this.checked,' + _Type  + ')"  type= "checkbox" id="' + data.idTinTuc + '"><span class="slider round"></span></label>';
                }
            },
            {
                "data": null,
                "name": 'Duyệt Bài',
                render: function (data) {
                    var _TrangThai = data.TrangThai == 1 ? 'true' : 'false';
                    if (data.Type === 1)
                        return '\n\ <label class="switch"><input class="checkStatus" onchange="AdminUpdateStatusMes(this.id,' + _TrangThai + ',this.checked)" type= "checkbox" id="' + data.idTinTuc + '"  ><span class="slider round"></span></label>';
                    else
                        return '\n\ <label class="switch"><input class="checkStatus" onchange="AdminUpdateStatusMes(this.id,' + _TrangThai + ',this.checked)" type= "checkbox" id="' + data.idTinTuc + '" checked><span class="slider round"></span></label>';
                }
            }
        ],
        order: [
            [0, 'DECS']
        ]
    });
}
$('#loadtinbai').click(function () {
    var data = "type=" + $("#trangthai").val() + "&status=" + $("#type_delete").val() + "&loaitintuc=" + $("#danhmuc option:selected").val()
        + "&tungay=" + $("#datepicker_tungay").val() + "&denngay=" + $("#datepicker_denngay").val();
    loaddataDefault(data);    
})

function AdminUpdateStatusMes(id, TrangThai, type) {
    var _trangthai = TrangThai ? 2 : 1;
    var _type = type ? 2 : 1;
    var url = '/Administrator/AdminUpdateStatusMes?ID=' + id + '&TrangThai=' + _trangthai + '&type=' + _type;
    $.ajax({
        type: "POST",
        url: url,
        contentType: false,
        processData: false,
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
}
