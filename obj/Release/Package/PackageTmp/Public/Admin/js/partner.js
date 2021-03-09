$("html").on("click", "#Modal_partner", function () {
    $("#Modal_partners").modal("show");
});
$("html").on("click", "#Save_partner", function () {
    var Name_partner = $("#Name_partner").val();
    var image_partner = $("#image_partner").val();
    var id = $("#Id_partner").val();
    var partner = [];
    partner.length = 0;
    partner.push({
        Id: parseInt(id),
        Name_partner: Name_partner,
        image_partner: image_partner
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        partner: partner
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Partner/Save_Partner",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_partners").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_partner", function () {
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
        url: "/Admin/Partner/Edit_Partner/",
        data: data,
        success: function (result) {
            $("#Modal_partners").modal('show');
            $("#Name_partner").val(result.Name_partner);
            $("#Id_partner").val(Id_User);
            $("#image_partner").val(result.image_partner);
            alert(result.image_partner)
            $("#show_image_partner").html("");
            var SetData = $("#show_image_partner");
            var Dataa = '<img src="' + result.image_partner + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Partner(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Partner/Save_Status",
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
$("html").on("click", "#delete_partner", function () {
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
        url: "/Admin/Partner/DeletePartner",
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



function BrowseServerPartner() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_partner").html("");
    var Data = "<img src='" + fileUrl + "' style='width:80px;height:80px;'>";
    Data_Set.append(Data);
    document.getElementById('image_partner').value = fileUrl;
}


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_partner").removeClass("disabled");
    $("#delete_partner").removeClass("disabled");
});
$("html").on('click', "#delete_partner", function () {
    $("#delete_partner").addClass("disabled");
    $("#edit_partner").addClass("disabled");
})