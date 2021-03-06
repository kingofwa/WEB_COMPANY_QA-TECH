$(document).ready(function () {
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Home/GetData_Information_Register",
        success: function (result) {
            if (result) {
                $(".diachi").html(result[0].Addred);
                $(".sodienthoai").html(result[0].Phone);
                $(".email").html(result[0].Email);
                $(".Email_CPN").html(result[0].Email_CPN);
                $(".Facebook").attr("href", result[0].Facebook);
                $(".Youtube").attr("href", result[0].Youtube);
                $(".Google").attr("href", result[0].Google);
                $(".Twitter").attr("href", result[0].Viber);
                $(".Slogan").html(result[0].Slogan);
                $(".Logo").attr("src", result[0].Logo);
                $(".thongbao").html(result[0].Notification_TB); 
                $(".anhquangcao").attr("src", result[0].Advertisement_QC);
                $(".tieude").html(result[0].Best_Company);
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});

$("html").on("click", "#show_modal_login", function () {
    $("#myModal_Login").modal("show");
});

$("html").on("click", "#quetion_client_home", function () {
    let question = $("#cauhoi_cuaban").val();
    let email = $("#email_cuaban").val();
    let emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    let checkmail = "";
    if (!emailReg.test(email)) {
        toastr.error("Không đúng định dạng Email");
        checkmail = true;
    } else {
        checkmail = false;
    };
    if (question == "" || email == "" || checkmail == true) {
        let orro_qs = "";
        let orro_email = "";
        if (question == "") {
            orro_qs = "Câu hỏi không được để trống";
        } if (email == "") {
            orro_email = "Email không được để trống";
        }
        if (orro_qs != "" || orro_email != "") {
            toastr.warning(orro_qs + " " + orro_email);
        }
    } else {
        var data = JSON.stringify({
            question: question,
            email: email
        });
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            data: data,
            url: "/Home/Question_CLient",
            success: function (result) {
                if (result == true) {
                    toastr.success("Cảm ơn bạn đã gửi câu hỏi !!! <b>Thành công</b>");
                    $('#Form_question').trigger("reset");
                } else {
                    toastr.error("Lỗi hệ thống !")
                }
            },
            error: function () {
                alert("Error!");
            }
        });
    }
});


//function Login_custommer() {
//    debugger
//    var Email_login = $("#Email_login").val();
//    var Password_login = $("#Password_login").val();
//    if (Email_login == "" || Password_login == "") {
//        toastr.warning("Mời nhập tài khoản của bạn")
//    } else {
//        var login = [];
//        login.length = 0;
//        login.push({
//            Email_login: Email_login,
//            Password_login: Password_login
//        })
//        var data = JSON.stringify({
//            login: login
//        });
//        $.ajax({
//            contentType: 'application/json; charset=utf-8',
//            dataType: 'json',
//            type: 'POST',
//            url: "/Home/Login_account",
//            data: data,
//            success: function (result) {
//                if (result) {
//                    alert(result.value);
//                    $('#myModal_Login').modal('hide');
//                    toastr.success("Đăng nhập thành công")
//                } else {
//                    toastr.error("Tài khoản hoặc mật khẩu không đúng !!!");
//                }
//            },
//            error: function () {
//                toastr.error("Lỗi hệ thống !!!");
//            }
//        });
//    }
//}

