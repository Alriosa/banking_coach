﻿function vRecruiterUpdate() {
    this.ctrlActions = new ControlActions();
 


    this.Update = function () {

        var recruiterData = {};

        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterUpdatePassword');
        recruiterData.RecruiterPassword = recruiterData["Password"];
        this.ctrlActions.PutToAPI('recruiter', recruiterData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmRecruiterUpdatePassword").valid()) {
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
            txtOldPassword: {
                required: "Ingrese la contraseña actual",
                minlength: "La contrasña debe contener mínimo 6 caracteres",
                maxlength: "La contrasña debe contener máximo 20 caracteres",
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
    $("#frmRecruiterUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});