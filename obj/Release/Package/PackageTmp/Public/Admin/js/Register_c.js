$("html").on("click", "#Save_Register", function () {
    debugger
    var Name_CPN = $("#Name_CPN").val();
    var Phone_hot = $("#Phone_hot").val();
    var Bank_number = $("#Bank_number").val();
    var Email_true = $("#Email_true").val();
    var Phone = $("#Phone").val();
    var Email = $("#Email").val();
    var Facebook = $("#Facebook").val();
    var Email_CPN = $("#Email_CPN").val();
    var Youtube = $("#Youtube").val();
    var Google = $("#Google").val();
    var Viber = $("#Viber").val();
    var Slogan = $("#Slogan").val();
    var Addred = $("#Addred").val();
    var Logo = $("#Logo").val();
    var Register = $("#Register").val();
    var Notification_TB = $("#Notification_TB").val();
    var Advertisement_QC = $("#Advertisement_QC").val();
    var Best_Company = $("#Best_Company").val();
    var register_admin = [];
    register_admin.length = 0;
    register_admin.push({
        Name_CPN: Name_CPN,
        Phone_hot: Phone_hot,
        Bank_number: Bank_number,
        Email_true: Email_true,
        Phone: Phone,
        Email: Email,
        Facebook: Facebook,
        Email_CPN: Email_CPN,
        Youtube: Youtube,
        Google: Google,
        Viber: Viber,
        Slogan: Slogan,
        Addred: Addred,
        Logo: Logo,
        Register: Register,
        Notification_TB: Notification_TB,
        Advertisement_QC: Advertisement_QC,
        Best_Company: Best_Company
    })
    var data = JSON.stringify({
        arr_list_Register: register_admin,
    });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/Admin/Register_Company/Save_Register_Admin",
        data: data,
        success: function (result) {
            if (result) {
                debugger
                toastr.success("Cập nhật thành công !");
            } else {
                toastr.warning("Cập nhật thất bại !");
            }
        },
        error: function () {
            alert("Error!");
        }
    });
});
 
function BrowseServer_Logo() {
    debugger
    var finder = new CKFinder();
    finder.selectActionFunction = lepvc;
    finder.popup();
};

function lepvc(fileUrl) {
    var Data_Set_logo = $("#show_logo").html("");
    var Data = "<img src='" + fileUrl + "'style='width:40px;height:30px;'>";
    Data_Set_logo.append(Data);
    document.getElementById('Logo').value = fileUrl;
};


function BrowseServer_Advertisement_QC() {
    debugger
    var finder2 = new CKFinder();
    finder2.selectActionFunction = lepvc2;
    finder2.popup();
};

function lepvc2(fileUrl) {
    var Data_Set_logo2 = $("#show_Advertisement_QC").html("");
    var Data2 = "<img src='" + fileUrl + "'style='width:40px;height:30px;'>";
    Data_Set_logo2.append(Data2);
    document.getElementById('Advertisement_QC').value = fileUrl;
};

