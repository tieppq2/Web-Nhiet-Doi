$("#btn_dangkikham").click(function () {
    $('#ModalPopUp').modal('show');
});
$("#btn_datlichkham").click(function () {
    var data = formatdata();
    $.ajax({
        url: "/Detail/ThemBNDatLich",
        type: "POST",
        contentType: false,
        processData: false,
        data: data,
        success: function (response) {
            if (response === 'Thêm thành công') {
                toastr.success('Đặt lịch khám thành công !', '');
                $(".form-group input[type='text']").each(function () {
                    $(this).val("");
                })
                $("#Index_sNoiDung").val('');
                $(".form-group input[type='date']").each(function () {
                    $(this).val("");
                })
            }
            else
                toastr.error(response, '');
        },
        error: function (xhr, status, p3, p4) {
            toastr.error(xhr.responseText, '');
        }
    });
});
function formatdata() {
    var formData = new FormData();
    formData.append("HoTen", $("#Index_sHoTen").val());
    formData.append("NgaySinh", $("#Index_NgaySinh").val());
    var gioitinh = 0;
    if (document.getElementById('Index_chkGioiTinhNam').checked) {
        gioitinh = 1
    } else if (document.getElementById('Index_chkGioiTinhNu').checked) {
        gioitinh = 2
    }
    formData.append("GioiTinh", gioitinh);
    formData.append("TheBHYT", $("#Index_sBHYT").val());
    formData.append("SDT", $("#Index_sDienThoai").val());
    formData.append("Email", $("#Index_sEmail").val());
    formData.append("DiaChi", $("#Index_sDiaChi").val());
    formData.append("NoiDungKham", $("#Index_sNoiDung").val());
    formData.append("NgayKham", $("#Index_NgayKham").val());
    return formData;
}