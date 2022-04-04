function vLogin() {

    this.service = 'seguridad';
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmEdition');
        var paginaInicio = "/home/vHoteles";//pagina de inicio del usuario
       

        this.ctrlActions.Login(this.service + "/login", data, paginaInicio);
    }

    this.ValidarInputs = function () {
        if ($("#frmLogin").valid()) {
            this.Login();
        }
    }
    
   
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vlogIn = new vLogin();
    ReglasValidacionLogin();
});

ReglasValidacionLogin = function () {
    $("#frmEdition").submit(function (e) {
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