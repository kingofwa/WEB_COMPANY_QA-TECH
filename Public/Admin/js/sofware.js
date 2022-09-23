$("html").on("click", "#Modal_software", function () {
    $("#Modal_softwares").modal("show");
});

$("html").on("click", "#Save_software", function () {
    var Sw_name = $("#Sw_name").val();
    var Sw_title = $("#Sw_title").val();
    var Sw_link = $("#Sw_link").val();
    var Sw_note = $("#Sw_note").val();
    //var Sw_desc = $("#Sw_desc").val();
    var Sw_image = $("#Sw_image").val(); 
    var Sw_author = $("#Sw_author").val(); 
    var Sw_desc = (CKEDITOR.instances.Sw_desc.getData());
    var id = $("#Id_software").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var software = [];
    software.length = 0;
    software.push({
        Id: parseInt(id),
        Sw_name: Sw_name,
        Sw_title: Sw_title,
        Sw_link: Sw_link,
        Sw_note: Sw_note,
        Sw_desc: Sw_desc,
        Sw_image: Sw_image,
        Sw_author: Sw_author
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        soft: software
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/SoftWare/Save_SoftWare",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_softwares").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_software", function () {
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
        url: "/Admin/SoftWare/Edit_SoftWare/",
        data: data,
        success: function (result) {
            $("#Modal_softwares").modal('show');
            $("#Sw_name").val(result.Sw_name);
            $("#Sw_title").val(result.Sw_title);
            $("#Sw_link").val(result.Sw_link);
            $("#Sw_note").val(result.Sw_note);
            $("#Sw_desc").val(result.Sw_desc);
            CKEDITOR.instances['Sw_desc'].setData(result.Sw_desc);
            $("#Id_software").val(Id_User);
            $("#Sw_author").val(result.Sw_author);
            $("#Sw_image").val(result.Sw_image);
            $("#show_image_software").html("");
            var SetData = $("#show_image_software");
            var Dataa = '<img src="' + result.Sw_image + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function SoftWare(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/SoftWare/Save_Status",
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
$("html").on("click", "#delete_software", function () {
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
        url: "/Admin/SoftWare/DeleteSoftWare",
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



function BrowseServerSoftWare() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_software").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('Sw_image').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_software").removeClass("disabled");
    $("#delete_software").removeClass("disabled");
});
$("html").on('click', "#delete_software", function () {
    $("#delete_software").addClass("disabled");
    $("#edit_software").addClass("disabled");
})