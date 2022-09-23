$("html").on("click", "#Modal_service", function () {
    $("#Modal_services").modal("show");
});

$("html").on("click", "#Save_service", function () {
    var Services_name = $("#Services_name").val();
    var Services_title = $("#Services_title").val();
    var Services_link = $("#Services_link").val();
    var Services_desc = $("#Services_desc").val();
    var Services_note = $("#Services_note").val();
    var Services_image = $("#Services_image").val();
    var id = $("#Id_service").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var service = [];
    service.length = 0;
    service.push({
        Id: parseInt(id),
        Services_name: Services_name,
        Services_title: Services_title,
        Services_link: Services_link,
        Services_desc: Services_desc,
        Services_note: Services_note,
        Services_image: Services_image
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        service: service
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Service/Save_Service",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_services").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_service", function () {
    debugger
    var activecheckedit = document.getElementsByClassName("activecheckedit");
    var Id_User = 0;
    for (let j = 0; j < activecheckedit.length; j++) {
        if (activecheckedit[j].checked == true) {
            Id_User = parseInt(activecheckedit[j].value);
        }
    }
    var data = JSON.stringify({
        Id_User: Id_User
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Service/Edit_Service/",
        data: data,
        success: function (result) {
            $("#Modal_services").modal('show');
            $("#Services_name").val(result.Services_name);
            $("#Services_title").val(result.Services_title);
            $("#Services_link").val(result.Services_link);
            $("#Services_desc").val(result.Services_desc);
            $("#Services_note").val(result.Services_note);
            $("#Id_service").val(Id_User);
            $("#Services_image").val(result.Services_image);
            $("#show_image_service").html("");
            var SetData = $("#show_image_service");
            var Dataa = '<img src="' + result.Services_image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Service(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Service/Save_Status",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#color_status_" + id).html("Khóa")
                $("#color_status_" + id).removeClass("btn-success")
                $("#color_status_" + id).addClass("btn-danger")
            } else {
                $("#color_status_" + id).html("Kích hoạt")
                $("#color_status_" + id).removeClass("btn-danger")
                $("#color_status_" + id).addClass("btn-success")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};
function Maketting(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Service/Save_Maketting",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#color_status_mk_" + id).html("Khóa")
                $("#color_status_mk_" + id).removeClass("btn-success")
                $("#color_status_mk_" + id).addClass("btn-danger")
            } else {
                $("#color_status_mk_" + id).html("Kích hoạt")
                $("#color_status_mk_" + id).removeClass("btn-danger")
                $("#color_status_mk_" + id).addClass("btn-success")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};
//Delete
$("html").on("click", "#delete_service", function () {
    var activecheckedit = document.getElementsByClassName("activecheckedit");
    var Id_User = 0;
    for (let j = 0; j < activecheckedit.length; j++) {
        if (activecheckedit[j].checked == true) {
            Id_User = parseInt(activecheckedit[j].value);
        }
    }
    var data = JSON.stringify({
        Id_User: Id_User
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Service/DeleteService",
        data: data,
        success: function (result) {
            if (result == true) {
                alert("Bạn xóa thành công");
                $("#row_" + Id_User).remove();
            } else {
                alert("Bạn bị lổi");
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});



function BrowseServerService() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_service").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('Services_image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_service").removeClass("disabled");
    $("#delete_service").removeClass("disabled");
});
$("html").on('click', "#delete_service", function () {
    $("#delete_service").addClass("disabled");
    $("#edit_service").addClass("disabled");
})