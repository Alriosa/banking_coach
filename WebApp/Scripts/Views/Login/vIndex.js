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
                    control.LoginByUser("sysadmin/getUser/" + userLogin, this.redirection);
                    break;
                case "2":
                    control.LoginByUser("student/getUser/" + userLogin, this.redirection);
                    break;
                case "3":
                    control.LoginByUser("recruiter/getUser/" + userLogin, this.redirection);
                    break;
                case "4":
                    control.LoginByUser("financial/getUser/" + userLogin, this.redirection);
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

    this.redirection = function () {
        window.location.href = '/Student/vStudentList';
    }

    
   
}
function resetForm() {
    $("#frmLogin")[0].reset();
}
//ON DOCUMENT READY
$(document).ready(function () {
    RulesValidateCreate();
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