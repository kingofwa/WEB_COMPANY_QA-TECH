$("html").on("click", "#Modal_system", function () {
    $("#Modal_systems").modal("show");
});

$("html").on("click", "#Save_system", function () {
    var Ten_DuAn = $("#Ten_DuAn").val();
    var Ten_KySu = $("#Ten_KySu").val(); 
    var Motangan = $("#Motangan").val();
    var Diachi_DuAn = $("#Diachi_DuAn").val();
    var Thoigiankhoicong = $("#Thoigiankhoicong").val();
    var Thoigianhoanthanh = $("#Thoigianhoanthanh").val();
    var Tongtien_DuAn = $("#Tongtien_DuAn").val();
    var Hinhanhmota = $("#Hinhanhmota").val();
    var Hinhanhchitiet = $("#Hinhanhchitiet").val();
    var Ghi_chu = $("#Ghi_chu").val();
    var ChiTietDuAn = (CKEDITOR.instances.ChiTietDuAn.getData());
    var id = $("#Id_system").val();
    //khai báo mảng slide chứa các thông tin chuyển thành json
    var system = [];
    system.length = 0;
    system.push({
        Id: parseInt(id),
        Ten_DuAn: Ten_DuAn,
        Ten_KySu: Ten_KySu,
        Motangan: Motangan,
        Diachi_DuAn: Diachi_DuAn,
        Thoigiankhoicong: Thoigiankhoicong,
        Thoigianhoanthanh: Thoigianhoanthanh,
        Tongtien_DuAn: Tongtien_DuAn,
        Hinhanhmota: Hinhanhmota,
        Hinhanhchitiet: Hinhanhchitiet,
        Ghi_chu: Ghi_chu,
        ChiTietDuAn: ChiTietDuAn
    })
    // chuyển mảng thành chuỗi json
    var data = JSON.stringify({
        system: system
    })
    //Khai báo Ajax gọi đến hàm Save_Slide
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Project_System/Save_System",
        data: data,
        success: function (result) {
            if (result > 0) {
                $("#Modal_systems").modal("hide");
                location.reload();
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
//Edit User
$("html").on("click", "#edit_system", function () {
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
        url: "/Admin/Project_System/Edit_System/",
        data: data,
        success: function (result) {
            $("#Modal_systems").modal('show');

            $("#Ten_DuAn").val(result.Ten_DuAn);
            $("#Ten_KySu").val(result.Ten_KySu);
            $("#Motangan").val(result.Motangan);
            $("#Diachi_DuAn").val(result.Diachi_DuAn);
            $("#Thoigiankhoicong").val(result.Thoigiankhoicong);
            $("#Thoigianhoanthanh").val(result.Thoigianhoanthanh);
            $("#Tongtien_DuAn").val(result.Tongtien_DuAn);
            $("#Ghi_chu").val(result.Ghi_chu);
            $("#ChiTietDuAn").val(result.ChiTietDuAn);
            CKEDITOR.instances['ChiTietDuAn'].setData(result.ChiTietDuAn);
            $("#Hinhanhmota").val(result.Hinhanhmota);
            $("#Id_system").val(result.Id);
            $("#show_image_Image_mota").html("");
            var SetData = $("#show_image_Image_mota");
            var Dataa = '<img src="' + result.Hinhanhmota + '"style="width:30px;height:30px;">';
            SetData.append(Dataa);
            $("#Hinhanhchitiet").val(result.Hinhanhchitiet);
            $("#show_image_Image_duan").html("");
            if (result.Hinhanhchitiet != null) {
                var mangimate = result.Hinhanhchitiet.split("|");
                var SetData2 = $("#show_image_Image_duan");
                for (var i = 0; i < mangimate.length; i++) {
                    var Dataa2 = '<div  class="d-inline-block" id="delhtml_' + i + '"><img class="dataimage"  src="' + mangimate[i] + '"style="width:30px;height:30px;margin-right:20px;"><i data-id="' + i + '" data-url="' + mangimate[i] + '" class="fa fa-minus"></i></div>';
                    SetData2.append(Dataa2);
                }
            }
        },
        error: function () {
            alert("Error!");
        }
    });

})

$("html").on("click", ".fa.fa-minus", function () {
    debugger
    var url = $(this).data("url");
    var id = $(this).data("id");
    $("#delhtml_" + id).html("");
    var DeleteHtml = $("#Hinhanhchitiet").val();
    var arrayimg = DeleteHtml.split("|");
    var savelist = "";
    for (i = 0; i < arrayimg.length; i++) {
        if (url != arrayimg[i]) {
            savelist += arrayimg[i] + "|";
        }
    }
    if (savelist.length > 2) {
        //loai bo phan tu dau & cuoi mang .
        savelist = savelist.substring(0, savelist.length - 1);
    }
    $("#Hinhanhchitiet").val(savelist);
})

//Delete
$("html").on("click", "#delete_system", function () {
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
        url: "/Admin/Project_System/DeleteSystem",
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



function BrowseServer_Image_Mota() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField;
    finder.popup();
};
// lưu lấy đường dẫn ảnh (show ảnh)
function SetFileField(fileUrl) {
    var Data_Set = $("#show_image_Image_mota").html("");
    var Data = "<img src='" + fileUrl + "' style='width:30px;height:30px;'>";
    Data_Set.append(Data);
    document.getElementById('Hinhanhmota').value = fileUrl;
}



// hình ảnh chi tiết dự án
function BrowseServer_Image_Du_An() {
    var finder = new CKFinder();
    finder.selectActionFunction = SetFileField2;
    finder.popup();
};
function SetFileField2(fileUrl) {
    debugger
    var Data_Set = $("#show_image_Image_duan").html("");
    var Hinhanhchitiet = $("#Hinhanhchitiet").val();
    if (Hinhanhchitiet == "") {
        Hinhanhchitiet = fileUrl;
    }
    else {
        Hinhanhchitiet = Hinhanhchitiet + "|" + fileUrl;
    }
    document.getElementById('Hinhanhchitiet').value = Hinhanhchitiet;
    if (Hinhanhchitiet != "") {
        var Url_Image_Array = Hinhanhchitiet.split("|");
        for (var i = 0; i < Url_Image_Array.length; i++) {
            var Data = "<img src='" + Url_Image_Array[i] + "' style='width:30px;height:30px;margin-right:3px;'>";
            Data_Set.append(Data);
        };
    };

}; 
function Sys_tem(id) {
    debugger
    var data = JSON.stringify({
        id: id
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Project_System/Save_Status",
        data: data,
        success: function (result) {
            debugger
            switch (result)
            {
                case 1:
                    $("#color_status_" + id).html("Khóa")
                    $("#color_status_" + id).removeClass("btn-warning")
                    $("#color_status_" + id).addClass("btn-danger")
                break;
                case 2:
                    $("#color_status_" + id).html("Nỗi bật")
                    $("#color_status_" + id).removeClass("btn-danger")
                    $("#color_status_" + id).addClass("btn-primary")
                break;
                case 3:
                    $("#color_status_" + id).html("Phổ biến")
                    $("#color_status_" + id).removeClass("btn-primary")
                    $("#color_status_" + id).addClass("btn-warning")
                break;
            }
        },
        error: function () {
            alert("eurro");
        }
    })
};



//active button edit-delete
$("html").on('click', ".activecheckedit", function () {
    $("#edit_system").removeClass("disabled");
    $("#delete_system").removeClass("disabled");
});
$("html").on('click', "#delete_system", function () {
    $("#delete_system").addClass("disabled");
    $("#edit_system").addClass("disabled");
})