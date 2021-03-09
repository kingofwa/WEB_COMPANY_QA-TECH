$("html").on("click", "#Modal_category", function () {
    $("#Modal_categorys").modal("show");
});
$("html").on("click", "#Save_category", function () {
    var C_name = $("#C_name").val();
    var C_note = $("#C_note").val();
    var id = $("#Id_category").val();
    var category = [];
    category.length = 0;
    category.push({
        Id: parseInt(id),
        C_name: C_name,
        C_note: C_note
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        category: category
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Category/Save_Category",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_categorys").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_category", function () {
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
        url: "/Admin/Category/Edit_Category",
        data: data,
        success: function (result) {
            $("#Modal_categorys").modal('show');
            $("#C_name").val(result.C_name);
            $("#Id_category").val(Id_User);
            $("#C_note").val(result.C_note);
        },
        error: function () {
            alert("Error!");
        }
    });

})



function Category(id) {
    debugger
    var data = JSON.stringify({
        Id_User: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Category/Save_Status",
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
$("html").on("click", "#delete_category", function () {
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
        url: "/Admin/Category/DeleteCategory",
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
    $("#edit_category").removeClass("disabled");
    $("#delete_category").removeClass("disabled");
});
$("html").on('click', "#delete_category", function () {
    $("#delete_category").addClass("disabled");
    $("#edit_category").addClass("disabled");
})