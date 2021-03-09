
$("html").on("click", "#lepvc_dangkynhantin", function () {
    var email_nhantin = $("#Email_dangky_nhantin").val();
    let emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    let checkmail = "";
    if (!emailReg.test(email_nhantin)) {
        toastr.error("Không đúng định dạng Email");
        checkmail = true;
    } else {
        checkmail = false;
    };
    if (email_nhantin == "" || checkmail == true) {
        let orro_email = "";
        if (email_nhantin == "") {
            orro_email = "Vui lòng nhập email <b>!<b/>";
        }
        if (orro_email != "") {
            toastr.warning(orro_email);
        }
    } else {
        var data = JSON.stringify({
            email: email_nhantin
        });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            data: data,
            url: "/Home/Register_revice_news_client",
            success: function (result) {
                if (result.thongbao != null) {
                    toastr.warning(result.thongbao);
                } else {
                    if (result == true) {
                        toastr.success("Chúng tôi sẽ thông báo cho bạn khi có thông tin mới");
                        $("#Email_dangky_nhantin").val("");
                    } else {
                        toastr.error("Lỗi hệ thống !")
                    }
                }
            },
            error: function () {
                alert("Error!");
            }
        });
    }
})

$("html").on("click", "#lepvc_dangkynhantin_footer", function () {
    var email_nhantin = $("#Email_dangky_nhantin_footer").val();
    let emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    let checkmail = "";
    if (!emailReg.test(email_nhantin)) {
        toastr.error("Không đúng định dạng Email");
        checkmail = true;
    } else {
        checkmail = false;
    };
    if (email_nhantin == "" || checkmail == true) {
        let orro_email = "";
        if (email_nhantin == "") {
            orro_email = "Vui lòng nhập email <b>!<b/>";
        }
        if (orro_email != "") {
            toastr.warning(orro_email);
        }
    } else {
        var data = JSON.stringify({
            email: email_nhantin
        });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            data: data,
            url: "/Home/Register_revice_news_client",
            success: function (result) {
                if (result.thongbao != null) {
                    toastr.warning(result.thongbao);
                } else {
                    if (result == true) {
                        toastr.success("Chúng tôi sẽ thông báo cho bạn khi có thông tin mới");
                        $("#Email_dangky_nhantin_footer").val("");
                    } else {
                        toastr.error("Lỗi hệ thống !")
                    }
                }
            },
            error: function () {
                alert("Error!");
            }
        });
    }
})
