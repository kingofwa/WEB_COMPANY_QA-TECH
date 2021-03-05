$("html").on("click", "#Modal_post", function () {
    $("#Modal_posts").modal("show");
});

$("html").on("click", "#Save_post", function () {
    var Name = $("#Name").val();
    var Id_brand = $("#Id_brand").val();
    var Title = $("#Title").val();
    var Author = $("#Author").val();
    var Image = $("#Image").val();
    var Details = (CKEDITOR.instances.Details.getData());
    var id = $("#Id_post").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var post = [];
    post.length = 0;
    post.push({
        Id: parseInt(id),
        Name: Name,
        Id_brand: Id_brand,
        Title: Title,
        Author: Author,
        Image: Image,
        Details: Details
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        post: post
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Post/Save_Post",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_posts").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_post", function () {
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
        url: "/Admin/Post/Edit_Post/",
        data: data,
        success: function (result) {
            $("#Modal_posts").modal('show');
            $("#Name").val(result.Name);
            $("#Id_brand").val(result.Id_brand);
            $("#Title").val(result.Title);
            $("#Author").val(result.Author);
            $("#Details").val(result.Details);
            CKEDITOR.instances['Details'].setData(result.Details);
            $("#Id_post").val(Id_User);
            $("#Image").val(result.Image);
            $("#show_image_Image").html("");
            var SetData = $("#show_image_Image");
            var Dataa = '<img src="' + result.Image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Post(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Post/Save_Status",
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
function Save_Common(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Post/Save_Common",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#color_status_pb_" + id).html("Khóa")
                $("#color_status_pb_" + id).removeClass("btn-success")
                $("#color_status_pb_" + id).addClass("btn-danger")
            } else {
                $("#color_status_pb_" + id).html("Kích hoạt")
                $("#color_status_pb_" + id).removeClass("btn-danger")
                $("#color_status_pb_" + id).addClass("btn-success")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};
function Save_Prominence(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Post/Save_Prominence",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#color_status_nb_" + id).html("Khóa")
                $("#color_status_nb_" + id).removeClass("btn-success")
                $("#color_status_nb_" + id).addClass("btn-danger")
            } else {
                $("#color_status_nb_" + id).html("Kích hoạt")
                $("#color_status_nb_" + id).removeClass("btn-danger")
                $("#color_status_nb_" + id).addClass("btn-success")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};
function Save_Type_post(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Post/Save_Type_post",
        data: data,
        success: function (result) {
            if (result == false) {
                $("#color_status_type_" + id).html("Video")
                $("#color_status_type_" + id).removeClass("btn-success")
                $("#color_status_type_" + id).addClass("btn-primary")
            } else {
                $("#color_status_type_" + id).html("Ảnh")
                $("#color_status_type_" + id).removeClass("btn-primary")
                $("#color_status_type_" + id).addClass("btn-success")
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};

//Delete
$("html").on("click", "#delete_post", function () {
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
        url: "/Admin/Post/DeletePost",
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



function BrowseServer_Image() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_Image").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('Image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_post").removeClass("disabled");
    $("#delete_post").removeClass("disabled");
});
$("html").on('click', "#delete_post", function () {
    $("#delete_post").addClass("disabled");
    $("#edit_post").addClass("disabled");
})