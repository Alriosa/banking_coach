function vRecruiterUpdate() {
    this.ctrlActions = new ControlActions();
 
    this.GetData = function () {
        var idRecruiter = document.getElementById("txtIdRecruiter").value;
        if (idRecruiter != 'null') {
            this.ctrlActions.GetById("recruiter/" + idRecruiter, this.FillData);
        }
    }

    this.FillData = function (data) {
        document.querySelector('#txtRecruiterLogin').value = data['RecruiterLogin'];

    }
    
    this.UpdatePassword = function () {
        var recruiterData = {};
        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterUpdatePassword');
        recruiterData["RecruiterlLogin"] = document.getElementById("txtRecruiterlLogin").value;
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