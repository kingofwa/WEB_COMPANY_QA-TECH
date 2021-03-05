$("html").on("click", "#Modal_fechback", function () {
    $("#Modal_fechbacks").modal("show");
});

$("html").on("click", "#Save_fechback", function () {
    var F_name = $("#F_name").val();
    var F_content = $("#F_content").val();
    var F_email = $("#F_email").val();
    var F_image = $("#F_image").val();
    var id = $("#Id_fechback").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var fechback = [];
    fechback.length = 0;
    fechback.push({
        Id: parseInt(id),
        F_name: F_name,
        F_content: F_content,
        F_email: F_email,
        F_image: F_image
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        soft: fechback
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/FechBack/Save_FechBack",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_fechbacks").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_fechback", function () {
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
        url: "/Admin/FechBack/Edit_FechBack/",
        data: data,
        success: function (result) {
            $("#Modal_fechbacks").modal('show');
            $("#F_name").val(result.F_name);
            $("#F_content").val(result.F_content);
            $("#F_email").val(result.F_email);
            $("#Id_fechback").val(Id_User);
            $("#F_image").val(result.F_image);
            $("#show_image_fechback").html("");
            var SetData = $("#show_image_fechback");
            var Dataa = '<img src="' + result.Sw_image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function FechBack(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/FechBack/Save_Status",
        data: data,
        success: function (result) {
            if (result == 1) {
                $("#color_status_" + id).html("Kích hoạt")
                $("#color_status_" + id).removeClass("btn-danger")
                $("#color_status_" + id).addClass("btn-success")
            } else {
                $("#color_status_" + id).html("Khóa")
                $("#color_status_" + id).removeClass("btn-success")
                $("#color_status_" + id).addClass("btn-danger")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};
//Delete
$("html").on("click", "#delete_fechback", function () {
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
        url: "/Admin/FechBack/DeleteFechBack",
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



function BrowseServerFechBack() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_fechback").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('F_image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_fechback").removeClass("disabled");
    $("#delete_fechback").removeClass("disabled");
});
$("html").on('click', "#delete_fechback", function () {
    $("#delete_fechback").addClass("disabled");
    $("#edit_fechback").addClass("disabled");
})