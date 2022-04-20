function vSysAdminAccount() {
    this.ctrlActions = new ControlActions();
    var SysAdminProfileData = {};
    SysAdminProfileData = JSON.parse(sessionStorage.getItem("user"));
   

    this.GetData = function () {
        var idSysAdmin = document.getElementById("txtIdSysAdmin").value;
        if (idSysAdmin != 'null') {
            this.ctrlActions.GetById("sysadmin/" + idSysAdmin, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            document.querySelector('#P_UserName').append(data['AdminLogin']);
        }
    }


    this.Update = function () {

        var sysadminData = {};

        sysadminData = this.ctrlActions.GetDataForm('frmSysAdminUpdatePassword');

        sysadminData.AdminPassword = sysadminData["Password"];

        this.ctrlActions.PutToAPI('sysadmin', sysadminData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmSysAdminUpdatePassword").valid()) {
            this.Update();
            resetForm();
        }
    }
}




RulesValidateCreate = function () {


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
            txtNewPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" },
        }
    });

}

function resetForm() {
    $("#frmSysAdminUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});