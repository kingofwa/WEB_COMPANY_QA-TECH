$("html").on("click", "#Modal_slide", function () {
    $("#Modal_slides").modal("show");
    $("#QA_admin_Modal_work_form_slide")[0].reset();
});

$("html").on("click", "#Save_slide", function () {
    var Name = $("#S_name").val();
    var Content = $("#S_description").val();
    var Link = $("#S_link").val();
    var Image = $("#S_image").val();
    var id = $("#Id_slide").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var slide = [];
    slide.length = 0;
    slide.push({
        Id: parseInt(id),
        S_name: Name,
        S_description: Content,
        S_image: Image,
        S_link: Link
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        slide: slide
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Slide/Save_Slide",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_slides").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_slide", function () {
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
        url: "/Admin/Slide/Edit_Slide/",
        data: data,
        success: function (result) {
            $("#Modal_slides").modal('show');
            $("#S_name").val(result.S_name);
            $("#S_description").val(result.S_description);
            $("#S_link").val(result.S_link);
            $("#Id_slide").val(Id_User);
            $("#S_image").val(result.S_image);
            $("#show_image_slide").html("");
            var SetData = $("#show_image_slide");
            var Dataa = '<img src="' + result.S_image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Users(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Slide/Save_Status",
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
//Delete
$("html").on("click", "#delete_slide", function () {
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
        url: "/Admin/Slide/DeleteSlide",
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



function BrowseServerSlide() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_slide").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('S_image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_slide").removeClass("disabled");
    $("#delete_slide").removeClass("disabled");
});
$("html").on('click', "#delete_slide", function () {
    $("#delete_slide").addClass("disabled");
    $("#edit_slide").addClass("disabled");
})