function vFinancialAccount() {
    this.ctrlActions = new ControlActions();
    var FinancialProfileData = {};
    FinancialProfileData = JSON.parse(sessionStorage.getItem("user"));
  

    this.GetData = function () {
        var idFinancial = document.getElementById("txtIdFinancial").value;
        if (idFinancial != 'null') {
            this.ctrlActions.GetById("financial/" + idFinancial, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            document.querySelector('#P_UserName').append(data['FinancialLogin']);
        }
    }


    this.Update = function () {

        var financialData = {};

        financialData = this.ctrlActions.GetDataForm('frmFinancialUpdatePassword');
        financialData.FinancialPassword = financialData["Password"];
        this.ctrlActions.PutToAPI('financial', financialData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmFinancialUpdatePassword").valid()) {
            this.Update();
            resetForm();
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