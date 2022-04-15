function vStudentAccount() {
    this.ctrlActions = new ControlActions();
    var StudentProfileData = {};
    StudentProfileData = JSON.parse(sessionStorage.getItem("user"));

    this.GetData = function () {
        var idStudent = document.getElementById("txtIdStudent").value;

        if (idStudent != 'null') {
            this.ctrlActions.GetById("student/" + idStudent, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            servicioData = {};
            document.querySelector('#P_UserName').append(data['StudentLogin']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_First_Name').append(data['FirstName']);
            document.querySelector('#P_Second_Name').append(data['SecondName']);
            document.querySelector('#P_Last_Name').append(data['LastName']);
            document.querySelector('#P_Second_Last_Name').append(data['SecondLastName']);
            document.querySelector('#P_Id_Type').append(data['IdType']);
            document.querySelector('#P_Identification_Number').append(data['IdentificationNumber']);
            document.querySelector('#P_Birthdate').append(data['Birthdate']);
            document.querySelector('#P_Gender').append(data['Gender']);
            document.querySelector('#P_Primary_Phone').append(data['PrimaryPhone']);
            document.querySelector('#P_Secondary_Phone').append(data['SecondaryPhone']);
            /*document.querySelector('#P_Last_Name').append(data['LaboralExperience']);
            document.querySelector('#P_LaboralStatus').append(data['LaboralStatus']);
            document.querySelector('#P_Province').append(data['Province']);
            document.querySelector('#P_Canton').append(data['Canton']);
            document.querySelector('#P_District').append(data['District']);
            document.querySelector('#P_BankingStudent').append(data['BankingStudent']);*/
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