function vFinancialAccount() {
    this.ctrlActions = new ControlActions();
    var FinancialProfileData = {};
    FinancialProfileData = JSON.parse(sessionStorage.getItem("usuario"));
    var idFinancial = localStorage.getItem("idFinancial");

    this.GetData = function () {
        if (idFinancial != 'nulo') {
            this.ctrlActions.GetById("financial/" + idFinancial, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            servicioData = {};
            document.querySelector('.nombreServicio').append(data['Nombre']);
            document.querySelector('.nombreServicioItem').append(data['Nombre']);
            document.getElementById('descripcionServicio').append(data['Descripcion']);
        }
    }


    this.Create = function () {

        var financialData = {};

        financialData = this.ctrlActions.GetDataForm('frmFinancialUpdatePassword');

        this.ctrlActions.PutToAPI('financial', financialData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmFinancialUpdatePassword").valid()) {
            this.UpdatePassword();
            resetForm();
        }
    }


    this.LlenarDatos = function () {
        var idServicio = $('#txtIdServicio').val();

        if (idServicio != 'nulo') {

            this.ctrlActions.GetById("servicio/traerUno/" + idServicio, this.LlenarInformacionServicio);
        }
    }

}



RulesValidateCreate = function () {


    $("#frmFinancialUpdatePassword").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtOldPassword: {
                required: "Ingrese la contraseña actual",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
            },
            txtPassword: {
                required: "Ingrese una nueva contraseña",
                minlength: "La contraseña debe de tener mínimo 6 caracteres",
                maxlength: "La contraseña debe de tener máximo 20 caracteres",
            },

            txtConfirmPassword: {
                required: "Ingrese nuevamente la nueva contraseña",
                equalTo: "No coinciden las contraseñas"
            },
        },
        rules: {
            txtOldPassword: { required: true, minlength: 6, maxlength: 20 },
            txtNewPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" },
        }
    });

}

function resetForm() {
    $("#frmFinancialUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});