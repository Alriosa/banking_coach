function vLogin() {

    this.service = 'security';
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmLogin');

        var studentLogin = $("#txtLogin").val().trim();;
        data["UserLogin"] = studentLogin;

        this.ctrlActions.Login(this.service + "/login", data, function (response) {
            var control = new ControlActions();
            var userLogin = response["UserLogin"];
            switch (response["UserType"]) {
                case "1":
                    setCookie('type', 1, 30);

                    control.LoginByUser("sysadmin/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Home" }, 3000);
                    });
                    break;
                case "2":
                    setCookie('type', 2, 30);
                    control.LoginByUser("student/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() {
                            this.ctrlActions2 = new ControlActions();

                            setCookie('token', JSON.stringify(data['StudentID']), 30);

                            window.location.href = "/Student/VStudentAccount/" + data['StudentID']
                        }, 3000);
                    });
                    break;
                case "3":
                    setCookie('type', 3, 30);
  control.LoginByUser("recruiter/getUser/" + userLogin, function (data) {
                        setTimeout(function redirection() { window.location.href = "/Home" }, 3000);
                    });
                    break;
                default:
                    window.location.href = "/Home"
                    break;
            }
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmLogin").valid()) {
            this.Login();

        }
    }

    this.RecoverPassword = function () {

        var user = {};

        user = this.ctrlActions.GetDataForm('formRecoverPassword');

        user['text'] = "Recuperación de Contraseña";
        user['subject'] = "Recuperación de Contraseña";

        this.ctrlActions.RecoverPassword(this.service + "/retrieveByEmail", user, function (response) {
            user['UserType'] = response["UserType"];
            this.ctrlActions2 = new ControlActions();

            switch (response["UserType"]) {
                case "1":
                    this.ctrlActions2.PostToAPI('mail/recoverPasswordAdmin', user, function () {
                        resetFormRecoverPassword();
                    });
                    break;
                case "2":
                    this.ctrlActions2.PostToAPI('mail/recoverPasswordStudent', user, function () {
                        resetFormRecoverPassword();
                    });
                    break;
                case "3":
                    this.ctrlActions2.PostToAPI('mail/recoverPasswordRecruiter', user, function () {
                        resetFormRecoverPassword();
                    });
                    break;
                default:
                    window.location.href = "/Home"
                    break;
            }
        })
    }
}

function resetFormRecoverPassword() {
    $("#formRecoverPassword")[0].reset();
    $('#modal-password').modal('toggle');
}

function resetForm() {
    $("#frmLogin")[0].reset();
}
//ON DOCUMENT READY
$(document).ready(function () {
    RulesValidateCreate();
    var user = {};
    if (getCookie('user')) {
        user = JSON.parse(getCookie('user'));
        HideFormLogin();
        document.getElementById("name").innerHTML = user.Name;
        document.getElementById("username").innerHTML = user.UserLogin;
        document.getElementById("email").innerHTML = user.Email;
        if (JSON.parse(getCookie('type')) == 2) {

            window.location.href = "/Student/VStudentAccount/" + getCookie("token");
        }
    } else {
        ShowFormLogin();
        document.getElementById("username").innerHTML = "";
        document.getElementById("name").innerHTML = "";
        document.getElementById("email").innerHTML = "";
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
    $("#page-title").removeClass("d-inline");
    $("#page-title").addClass("d-none");
    $("#home-title").removeClass("d-none");
    $("#home-title").addClass("d-inline");
}

function HideFormLogin() {
    $("#containerFormLogin").removeClass("d-inline");
    $("#containerFormLogin").addClass("d-none");
    $("#page-title").removeClass("d-none");
    $("#page-title").addClass("d-inline");
    $("#home-title").removeClass("d-inline");
    $("#home-title").addClass("d-none");
}
