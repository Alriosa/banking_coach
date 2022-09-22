function vLogin() {

    this.service = 'security';
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmLogin');
        this.ctrlActions.Login(this.service + "/login", data, function (response) {
            var control = new ControlActions();
            var userLogin = response["UserLogin"];
            switch (response["UserType"]) {
                case "1":
                    control.LoginByUser("sysadmin/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Home" }, 3000);
                    });
                    break;
                case "2":
                    control.LoginByUser("student/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Student/VStudentAccount/" + data['StudentID'] }, 3000);
                    });
                    break;
                case "3":
                    control.LoginByUser("recruiter/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Recruiter/vRecruiterAccount/" }, 3000);
                    });
                    break;
                case "4":
                    control.LoginByUser("financial/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Home" }, 3000);
                    });
                    break;
                default:
                    console.log("404");
                    break;
            }
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmLogin").valid()) {
            this.Login();
            
        }
    }

 
   
}
function resetForm() {
    $("#frmLogin")[0].reset();
}
//ON DOCUMENT READY
$(document).ready(function () {
    RulesValidateCreate();
    var user = {};
    user = JSON.parse(getCookie('user'));
    if (user == null) {
        ShowFormLogin();
    } else {
        HideFormLogin();
    }
});

RulesValidateCreate = function () {
 
    $("#frmLogin").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtLogin: {
                required: "Ingrese un nombre de usuario",
            },
            txtPassword: {
                required: "Ingrese una contraseña",
            }
        },
        rules: {
            txtLogin: { required: true },
            txtPassword: { required: true },
        }
    });


  




}



function ShowFormLogin() {
    $("#containerFormLogin").removeClass("d-none");
    $("#containerFormLogin").addClass("d-inline");
}

function HideFormLogin() {
    $("#containerFormLogin").removeClass("d-inline");
    $("#containerFormLogin").addClass("d-none");
}
