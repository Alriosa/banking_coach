function vLogin() {

    this.service = 'security';
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmLogin');
        this.ctrlActions.Login(this.service + "/login", data);
    }

    this.ValidateInputs = function () {
        if ($("#frmLogin").valid()) {
            //this.Login();
        }
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