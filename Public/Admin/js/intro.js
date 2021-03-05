$("html").on("click", "#Modal_intro", function () {
    $("#Modal_intros").modal("show");
    $("#QA_admin_Modal_work_form_intro")[0].reset();
});

$("html").on("click", "#Save_intro", function () {
    var Intro_name = $("#Intro_name").val();
    //var Intro_desc = $("#Intro_desc").val();
    var Intro_desc = (CKEDITOR.instances.Intro_desc.getData());
    var Intro_image = $("#Intro_image").val(); 
    var Intro_link = $("#Intro_link").val();
    var Intro_title = $("#Intro_title").val();
    var id = $("#Id_intro").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var intro = [];
    intro.length = 0;
    intro.push({
        Id: parseInt(id),
        Intro_name: Intro_name,
        Intro_desc: Intro_desc,
        Intro_image: Intro_image,
        Intro_title: Intro_title,
        Intro_link: Intro_link
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        intro: intro
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Introduc/Save_Intro",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_intros").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_intro", function () {
    debugger
    var activecheckedit = document.getElementsByClassName("activecheckedit");
    var Id_User = 0;
    for (let j = 0; j < activecheckedit.length; j++) {
        if (activecheckedit[j].checked == true) {
            Id_User = parseInt(activecheckedit[j].value);
        }
    }
    var data = JSON.stringify({
        Id: Id_User
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Introduc/Edit_Intro/",
        data: data,
        success: function (result) {
            $("#Modal_intros").modal('show');
            $("#Intro_name").val(result.Intro_name); 
            //$("#Intro_desc").val(result.Intro_desc);

            CKEDITOR.instances['Intro_desc'].setData(result.Intro_desc);
            $("#Intro_link").val(result.Intro_link);
            $("#Intro_title").val(result.Intro_title);
            $("#Id_intro").val(Id_User);
            $("#Intro_image").val(result.Intro_image);
            $("#show_image_intro").html("");
            var SetData = $("#show_image_intro");
            var Dataa = '<img src="' + result.Intro_image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Introduction(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Introduc/Save_Status",
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
$("html").on("click", "#delete_intro", function () {
    var activecheckedit = document.getElementsByClassName("activecheckedit");
    var Id_User = 0;
    for (let j = 0; j < activecheckedit.length; j++) {
        if (activecheckedit[j].checked == true) {
            Id_User = parseInt(activecheckedit[j].value);
        }
    }
    var data = JSON.stringify({
        Id: Id_User
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Introduc/DeleteIntro",
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



function BrowseServerIntro() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_intro").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('Intro_image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_intro").removeClass("disabled");
    $("#delete_intro").removeClass("disabled");
});
$("html").on('click', "#delete_intro", function () {
    $("#delete_intro").addClass("disabled");
    $("#edit_intro").addClass("disabled");
})