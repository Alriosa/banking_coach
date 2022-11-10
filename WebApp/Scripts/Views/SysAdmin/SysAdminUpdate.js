function vSysAdminUpdate() {
    this.ctrlActions = new ControlActions();
    this.service = 'sysadmin';



    this.GetData = function () {
        var idSysAdmin = document.getElementById("txtIdSysAdmin").value;
        if (idSysAdmin != 'null') {
            this.ctrlActions.GetById(this.service + "/" + idSysAdmin, this.FillData);
        }
    }

    this.FillData = function (data) {
        document.querySelector('#txtAdminLogin').value = data['AdminLogin'];
        document.querySelector('#txtName').value = data['Name'];
        document.querySelector('#txtEmail').value = data['Email'];
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

    this.Update = function () {
        var adminData = {};
        adminData = this.ctrlActions.GetDataForm('frmSysAdminUpdate');
        adminData["AdminLogin"] = document.getElementById("txtAdminLogin").value;
        this.ctrlActions.PutToAPI(this.service, adminData,
            resetForm()
        );
    }

    this.ValidateInputs = function () {
        if ($("#frmSysAdminUpdate").valid()) {
            this.Update();
            resetForm();
        }
    }
}

RulesValidateUpdate = function () {
    $("#frmSysAdminUpdatePassword").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
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
            txtNewPassword: { required: true, minlength: 6, maxlength: 20  },
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