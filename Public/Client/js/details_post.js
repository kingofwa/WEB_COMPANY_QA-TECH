function VoteUP(id) {
    var number_vote = $("#number_vote_" + id).html();
    var data = JSON.stringify({
        id: id
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Blog_details/Vote_up",
        data: data,
        success: function (result) {
            if (result == "Mời đăng nhập để bình chọn") {
                toastr.warning(result)
                $("#myModal_Login").modal("show");
                $("#neuchuacotaikhoan").html("");
                $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/dang-ky-tai-khoan"><b>Vào đây<b/> !</a>')
            } else {
                if (result == parseInt(number_vote)) {
                    toastr.warning("Bạn chỉ được bình chọn một lần !")
                } else {
                    $("#number_vote_" + id).html(result)
                    toastr.success("Cảm ơn bạn đã bình chọn bình luận hay nhất !")
                }
            }
        },
        error: function () {
            alert("Error!");
        }
    });
}


function VoteDOWN(id) {
    var number_vote = $("#number_vote_" + id).html();
    var data = JSON.stringify({
        id: id
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Blog_details/Vote_down",
        data: data,
        success: function (result) {
            if (result == "Mời đăng nhập để bình chọn") {
                toastr.warning(result)
                $("#myModal_Login").modal("show");
                $("#neuchuacotaikhoan").html("");
                $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/dang-ky-tai-khoan"><b>Vào đây<b/> !</a>')
            } else {
                if (result == parseInt(number_vote)) {
                    toastr.warning("Bạn chỉ được bình chọn một lần !")
                } else {
                    $("#number_vote_" + id).html(result)
                    toastr.success("Cảm ơn bạn đã bình chọn bình luận hay nhất !")
                }
            }
        },
        error: function () {
            alert("Error!");
        }
    });
}

// gửi comment
function Send_comment(id) {
    debugger
    var noidung = $("#noidung_" + id).val();
    if (noidung == "") {
        toastr.warning("Bạn chưa có câu trả lời !")
    } else {
        var id_post = $("#id_post").val();
        var data = JSON.stringify({
            noidung: noidung,
            id: id,
            id_post: id_post
        })
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Blog_details/Reply_Comment",
            data: data,
            success: function (result) {
                if (result == "Mời đăng nhập để trả lời bình luận") {
                    toastr.warning(result)
                    $("#myModal_Login").modal("show");
                    $("#neuchuacotaikhoan").html("");
                    $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/dang-ky-tai-khoan"><b>Vào đây<b/> !</a>')
                } else {
                    window.location.reload();
                }
            },
            error: function () {
                alert("Error!");
            }
        });
    }
};

function Show_felling_ul_hide(id) {
    if ($("#css_move_" + id).val() > 1) {
        $("#show_ul_li_" + id).css({
            "display": "none",
        });
        $("#css_move_" + id).val(1);
    } else {
        $("#show_ul_li_" + id).css({
            "display": "block",
        })
        $("#css_move_" + id).val(2);
    }
    
}