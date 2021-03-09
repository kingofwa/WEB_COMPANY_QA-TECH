
$("html").on("click", "#Edit_User_client", function () {
    //$(".lepvc_table").removeClass("d-none");
    $("#myModal_edit_user").modal("show");
    
    var hovaten = $("#hovaten").html();
    var sodienthoai = $("#sodienthoai").html();
    var diachi = $("#diachi").html();
    var hinhanh = $("#hinhanh").attr("src");
    
    $("#HoVaTen_User").val(hovaten);
    $("#DiaChi_User").val(diachi);
    $("#Sodienthoai_User").val(sodienthoai);
    $('#Hinhanh_User').attr('src', hinhanh);
    $('#html_btnn').attr('src', hinhanh);
});

$('.new_Btn').click(function () {
    $('#html_btn').click();
});




function CapNhat() {
    debugger
    var hovatenn = $("#HoVaTen_User").val();
    var sodienthoai = $("#Sodienthoai_User").val();
    var diachi = $("#DiaChi_User").val(); 
    var hinhanh = $("#Hinhanh_User").val();
    var id_user = $("#id_user").val();
    var update_user = [];
    update_user.length = 0;
    update_user.push
        ({
            Id: parseInt(id_user),
            name: hovatenn,
            phone: sodienthoai,
            addred: diachi,
            Image_cus: hinhanh
        });
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        update_user: update_user
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Profile_User/Update_User",
        data: data,
        success: function (result) {
            if (result) {
                window.location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
};

//chuyển trạng thái sang public
function Private_User(id) {
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Profile_User/Chang_Status_P_",
        data: data,
        success: function (result) {
            if (result == "") {
                $("#color_status_" + id).html("Public")
                $("#color_status_" + id).removeClass("badge-warning")
                $("#color_status_" + id).addClass("badge-primary")
            } else {
                $("#color_status_" + id).html("Private")
                $("#color_status_" + id).removeClass("badge-primary")
                $("#color_status_" + id).addClass("badge-warning")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};

function Folow_Me(id) {
    var theodoi__ = $("#theodoi__").val();
    if (theodoi__ == 1) {
        $("#theodoi__").val(2);
    } else {
        $("#theodoi__").val(1);
    }
    var data = JSON.stringify({
        Id_User: id,
        theodoi__: theodoi__
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Profile_User/Chang_Folow_Me_",
        data: data,
        success: function (result) {
            if (result == 1) {
                $("#color_status_" + id).html("Theo dõi")
                $("#color_status_" + id).removeClass("badge-warning")
                $("#color_status_" + id).addClass("badge-primary")
                toastr.success("Đã bỏ theo dõi")
            } else {
                $("#color_status_" + id).html("Đang theo dõi")
                $("#color_status_" + id).removeClass("badge-primary")
                $("#color_status_" + id).addClass("badge-warning")
                toastr.success("Đã theo dõi")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};



$("html").on("click", "#baiviet_user_client", function () {
    $("#baiviet_user_client").addClass("active");
    $("#dangtheodoi_user").removeClass("active");
    $(".bai_dang_cua_ban").css({
        "display": "block"
    });
    $(".dang_theo_doi").css({
        "display": "none"
    });
});

$("html").on("click", "#dangtheodoi_user", function () {
    $("#baiviet_user_client").removeClass("active");
    $("#dangtheodoi_user").addClass("active");
    $(".bai_dang_cua_ban").css({
        "display" : "none"
    });
    $(".dang_theo_doi").css({
        "display": "block"
    });
});