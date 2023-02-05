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
        document.querySelector('#txtIdType').value = data['IdType'];
        document.querySelector('#txtIdentificationNumber').value = data['IdentificationNumber'];
    }
    this.UpdatePassword = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var adminData = {};
        var email = document.querySelector('#txtEmail').value;
        adminData = this.ctrlActions.GetDataForm('frmSysAdminUpdatePassword');
        adminData["Email"] = email;
        this.ctrlActions.PutToAPI(this.service + "/changePassword", adminData, function () {
            setTimeout(function redirection() { window.location.href = '/SysAdmin/vSysAdminList'; }, 4000);
        })
    }


    this.ValidateInputsPassword = function () {
        if ($("#frmSysAdminUpdatePassword").valid()) {
            this.UpdatePassword();

        }
    }

    this.Update = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var adminData = {};
        adminData = this.ctrlActions.GetDataForm('frmSysAdminUpdate');
        adminData["AdminLogin"] = document.getElementById("txtAdminLogin").value;
        this.ctrlActions.PutToAPI(this.service, adminData,
            setTimeout(function redirection() { window.location.href = '/SysAdmin/vSysAdminList'; }, 4000)
        );
    }

    this.ValidateInputs = function () {
        if ($("#frmSysAdminUpdate").valid()) {
            this.Update();
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