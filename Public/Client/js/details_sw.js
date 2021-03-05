// gửi comment
function Send_comment_SW(id) {
    debugger
    $("#neuchuacotaikhoan").html("");
    var noidung = $("#noidung_" + id).val();
    if (noidung == "") {
        toastr.warning("Bạn chưa có câu trả lời !")
    } else {
        var id_software = $("#id_software").val();
        var data = JSON.stringify({
            noidung: noidung,
            id: id,
            id_software: id_software
        })
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: "/Details_SW_/Reply_Comment",
            data: data,
            success: function (result) {
                if (result.mesage != "") {
                    toastr.warning(result.mesage);
                  
                    $("#myModal_Login").modal("show");
                    $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/Register/Dangky"><b>Vào đây<b/> !</a>')
                }
                if (result.valueee != "") {
                    window.location.reload();
                }
            },
            error: function () {
                alert("Error!");
            }
        });
    }
};

//vote biểu cảm icon
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

function VoteUP(id) {
    debugger
    var number_vote = $("#number_vote_" + id).html();
    var data = JSON.stringify({
        id: id
    })
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Details_SW_/Vote_up",
        data: data,
        success: function (result) {
            if (result != null) {
                toastr.warning(result)
                $("#myModal_Login").modal("show");
                $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/Register/Dangky"><b>Vào đây<b/> !</a>')
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
        url: "/Details_SW_/Vote_down",
        data: data,
        success: function (result) {
            if (result != null) {
                toastr.warning(result)
                $("#myModal_Login").modal("show");
                $("#neuchuacotaikhoan").append('Nếu chưa có tài khoản <a href="/Register/Dangky"><b>Vào đây<b/> !</a>')
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