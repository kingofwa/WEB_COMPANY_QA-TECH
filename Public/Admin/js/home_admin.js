$(document).ready(function () {
    $('#myTable2').DataTable();
    $('#myTable3').DataTable();
    $('#khachhangdangkysudungphanmem').DataTable();
    $(".nav-tabs a").click(function () {
        $(this).tab('show');
    });
    $('[data-toggle="tooltip"]').tooltip();
});
function TaiKhoan_KH(id) {
    var data = JSON.stringify({
        id: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/AdminHome/Save_Status_KhachHang",
        data: data,
        success: function (result) {
            if (result == 1) {
                $("#color_status_" + id).html("Hoạt động")
                $("#color_status_" + id).removeClass("btn-danger")
                $("#color_status_" + id).addClass("btn-success")
                toastr.success("Cập nhật thành công !");
            } else {
                $("#color_status_" + id).html("Khóa")
                $("#color_status_" + id).removeClass("btn-success")
                $("#color_status_" + id).addClass("btn-danger")
                toastr.success("Cập nhật thành công !");
            }
        },
        error: function () {
            alert("eurro");
        }
    });
};


function CapDo(id) {
    var data = JSON.stringify({
        id: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/AdminHome/Save_Status_CapDo",
        data: data,
        success: function (result) {
            if (result == 1) {
                $("#color_status_user_" + id).html("Khách")
                $("#color_status_user_" + id).removeClass("btn-primary")
                $("#color_status_user_" + id).addClass("btn-warning")
                toastr.success("Cập nhật thành công !");
            } else {
                $("#color_status_user_" + id).html("Nhân viên")
                $("#color_status_user_" + id).removeClass("btn-warning")
                $("#color_status_user_" + id).addClass("btn-primary")
                toastr.success("Cập nhật thành công !");
            }
        },
        error: function () {
            alert("eurro");
        }
    });
};

function Duyet_Binh_Luan(id) {
    var data = JSON.stringify({
        id: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/AdminHome/PheDuyetBinhLuan",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#binhluan_color_status_" + id).html("Duyệt bình luận")
                $("#binhluan_color_status_" + id).removeClass("badge-success")
                $("#binhluan_color_status_" + id).addClass("badge-warning")
                toastr.success("Cập nhật thành công !");
            } else {
                $("#binhluan_color_status_" + id).html("Duyệt xong")
                $("#binhluan_color_status_" + id).removeClass("badge-warning")
                $("#binhluan_color_status_" + id).addClass("badge-success")
                toastr.success("Cập nhật thành công !");
            }
        },
        error: function () {
            alert("eurro");
        }
    });
}