function vStudentAccount() {
    this.ctrlActions = new ControlActions();
    var StudentProfileData = {};
    StudentProfileData = JSON.parse(sessionStorage.getItem("user"));
    var idStudent = document.getElementById("txtIdStudent").value;

    this.GetData = function () {
        if (idStudent != 'null') {
            this.ctrlActions.GetById("student/" + idStudent, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            servicioData = {};
            document.querySelector('#P_UserName').append(data['StudentLogin']);
        }
    }


    this.Update = function () {

        var studentData = {};

        studentData = this.ctrlActions.GetDataForm('frmStudentUpdatePassword');
        studentData.StudentPassword = studentData["Password"];
        this.ctrlActions.PutToAPI('student', studentData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentUpdatePassword").valid()) {
            this.Update();
            resetForm();
        }
    }
}



RulesValidateCreate = function () {


    $("#frmStudentUpdatePassword").validate({
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
    $("#frmStudentUpdatePassword")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});