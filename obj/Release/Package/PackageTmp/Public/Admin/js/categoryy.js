$("html").on("click", "#Modal_categoryy", function () {
    $("#Modal_categoryys").modal("show");
});
$("html").on("click", "#Save_categoryy", function () {
    var Name = $("#Name").val();
    var id_categories = $("#id_categories").val();
    var id = $("#Id_categoryy").val();
    var categoryy = [];
    categoryy.length = 0;
    categoryy.push({
        Id: parseInt(id),
        Name: Name,
        id_categories: id_categories
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        categoryy: categoryy
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Categoryy/Save_Categoryy",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_categoryys").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_categoryy", function () {
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
        url: "/Admin/Categoryy/Edit_Categoryy",
        data: data,
        success: function (result) {
            $("#Modal_categoryys").modal('show');
            $("#Name").val(result.Name);
            $("#Id_categoryy").val(Id_User);
            $("#id_categories").val(result.id_categories);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Categoryy(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Categoryy/Save_Status",
        data: data,
        success: function (result) {
            if (result == true) {
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
$("html").on("click", "#delete_categoryy", function () {
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
        url: "/Admin/Categoryy/DeleteCategoryy",
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


//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_categoryy").removeClass("disabled");
    $("#delete_categoryy").removeClass("disabled");
});
$("html").on('click', "#delete_category", function () {
    $("#delete_categoryy").addClass("disabled");
    $("#edit_categoryy").addClass("disabled");
})