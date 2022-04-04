function vLogin() {

    this.service = 'security';
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmLogin');


        this.ctrlActions.Login(this.service + "/login", data);
    }

    this.ValidarInputs = function () {
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
});

RulesValidateCreate = function () {
    $("#frmLogin").submit(function (e) {
        e.preventDefault();
    }).validate({
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtCorreo: "required EMAIL",
            txtContrasenna: { required: true/*, minlength: 6*/ }
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });
            error.insertAfter(element);
        }
    });
}