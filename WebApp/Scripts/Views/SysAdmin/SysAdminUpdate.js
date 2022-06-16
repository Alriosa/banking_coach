function vSysAdminUpdate() {
    this.ctrlActions = new ControlActions();
   


    this.GetData = function () {
        var idSysAdmin = document.getElementById("txtIdSysAdmin").value;
        if (idSysAdmin != 'null') {
            this.ctrlActions.GetById("sysadmin/" + idSysAdmin, this.FillData);
        }
    }

    this.FillData = function (data) {
        document.querySelector('#txtAdminLogin').value = data['AdminLogin'];
    }
    this.UpdatePassword = function () {
        var adminData = {};
        var adminLogin = document.getElementById("txtAdminLogin").value;
        adminData = this.ctrlActions.GetDataForm('frmSysAdminUpdatePassword');
        adminData["AdminLogin"] = adminLogin;
        this.ctrlActions.PutToAPI(this.service + "/changePassword", adminData,
            resetForm());
    }


    this.ValidateInputsPassword = function () {
        if ($("#frmSysAdminUpdatePassword").valid()) {
            this.UpdatePassword();

        }
    }

}



RulesValidateUpdate = function () {
    $("#frmSysAdminUpdatePassword").validate({
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
            txtNewPassword: { required: true, minlength: 6, maxlength: 20, new_password_not_same: true  },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" },
        }
    });

}

function resetForm() {
    $("#frmSysAdminUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateUpdate();
});