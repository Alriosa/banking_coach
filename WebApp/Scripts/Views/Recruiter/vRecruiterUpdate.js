﻿function vRecruiterUpdate() {
    this.ctrlActions = new ControlActions();
    this.service = 'recruiter';

    this.GetData = function () {
        var idRecruiter = document.getElementById("txtIdRecruiter").value;
        if (idRecruiter != 'null') {
            this.ctrlActions.GetById("recruiter/" + idRecruiter, this.FillData);
        }
    }

    this.FillData = function (data) {
        document.querySelector('#txtRecruiterLogin').value = data['RecruiterLogin'];
        document.querySelector('#txtName').value = data['Name'];
        document.querySelector('#txtEmail').value = data['Email'];
        document.querySelector('#txtIdType').value = data['IdType'];
        document.querySelector('#txtIdentificationNumber').value = data['IdentificationNumber'];

    }
    
    this.UpdatePassword = function () {
        var recruiterData = {};
        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterUpdatePassword');
        recruiterData["Email"] = document.querySelector('#txtEmail').value;
        this.ctrlActions.PutToAPI(this.service + "/changePassword", recruiterData,
            resetForm()
        );
    }

    this.ValidateInputPassword = function () {
        if ($("#frmRecruiterUpdatePassword").valid()) {
            this.UpdatePassword();
            resetForm();
        }
    }


    this.Update = function () {
        var recruiterData = {};
        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterUpdate');
        recruiterData["RecruiterLogin"] = document.getElementById("txtRecruiterLogin").value;
        recruiterData["IdType"] = document.getElementById("txtIdType").value;
        recruiterData["IdentificationNumber"] = document.getElementById("txtIdentificationNumber").value;
        this.ctrlActions.PutToAPI(this.service, recruiterData,
            resetForm()
        );
    }

    this.ValidateInputs = function () {
        if ($("#frmRecruiterUpdate").valid()) {
            this.Update();
            resetForm();
        }
    }
}

RulesValidateUpdate = function () {

    $("#frmRecruiterUpdatePassword").validate({
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
            txtNewPassword: { required: true, minlength: 6, maxlength: 20, new_password_not_same: true },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" },
        }
    });

}

function resetForm() {
    $("#frmRecruiterUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});