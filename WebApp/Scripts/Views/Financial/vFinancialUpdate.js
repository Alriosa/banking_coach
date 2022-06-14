function vFinancialUpdate() {
    this.ctrlActions = new ControlActions();
    var FinancialData = {};
    FinancialData = JSON.parse(sessionStorage.getItem("userFinancial"));


    this.GetData = function () {
        var idFinancial = document.getElementById("txtIdFinancial").value;
        if (idFinancial != 'null') {
            this.ctrlActions.GetById("financial/" + idFinancial, this.FillData);
        }
    }



    this.Update = function () {

        var financialData = {};

        financialData = this.ctrlActions.GetDataForm('frmFinancialUpdatePassword');
        financialData.FinancialPassword = financialData["FinancialPassword"];
        this.ctrlActions.PutToAPI('financial', financialData, function () {
            resetForm();
        });
    }


    this.UpdatePassword = function () {
        var financialData = {};
        var id = document.getElementById("txtIdFinancial").value;
        var financialLogin = document.getElementById("txtFinancialLogin").value;
        financialData = this.ctrlActions.GetDataForm('frmFinancialUpdatePassword');
        financialData["FinancialLogin"] = financialLogin;
        this.ctrlActions.PutToAPI(this.service + "/changePassword", financialData,
            setTimeout(function redirection() { window.location.href = '/Financial/vFinancialList/' }, 3000));
    }

    this.ValidateInputs = function () {
        if ($("#frmFinancialUpdate").valid()) {
            this.Update();
            resetForm();
        }
    }

    this.ValidateInputPassword = function () {
        if ($("#frmFinancialUpdatePassword").valid()) {
            this.UpdatePassword();
            resetForm();
        }
    }
}

RulesValidateUpdate = function () {

    $.validator.addMethod("new_password_not_same", function (value, element) {
        return $('#txtOldPassword').val() != $('#txtNewPassword').val()
    }, "* Debe elegir una contraseña diferente a la actual");

    $("#frmFinancialUpdatePassword").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtOldPassword: {
                required: "Ingrese la contraseña actual",
                minlength: "La contraseña debe contener mínimo 6 caracteres",
                maxlength: "La contraseña debe contener máximo 20 caracteres"
            },
            txtNewPassword: {
                required: "Ingrese una nueva contraseña",
                minlength: "La contraseña debe de tener mínimo 6 caracteres",
                maxlength: "La contraseña debe de tener máximo 20 caracteres",
            },

            txtConfirmNewPassword: {
                required: "Ingrese nuevamente la nueva contraseña",
                equalTo: "No coinciden las contraseñas"
            },
        },
        rules: {
            txtOldPassword: { required: true, minlength: 6, maxlength: 20 },
            txtNewPassword: { required: true, minlength: 6, maxlength: 20, new_password_not_same: true },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" }
        }
    });

}


$(document).ready(function () {

    RulesValidateUpdate();
});