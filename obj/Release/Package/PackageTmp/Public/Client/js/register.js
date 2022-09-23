function KiemTra_matkhau() {
    var pass2 = $("#password2").val();
    var pass1 = $("#password").val();
    if (pass2 != pass1) {
        $("#password2").css({
            "border": "1px solid red",
        })
    }
    if (pass2 == pass1) {
        $("#button_register").css({
            "border": "1px solid #FA6742",
            "background":"#FA6742"
        })
    }
}