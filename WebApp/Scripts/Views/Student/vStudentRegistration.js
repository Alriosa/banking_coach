function vStudentRegistration() {
    this.Create = function () {

        var studentData = {};
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');
        this.ctrlActions.PostToAPI('student', studentData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentCreate").valid()) {
            this.Create();

        }
    }
}

this.RulesValidateCreate = function () {
    $("#frmStudentCreate").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtBankingStudent: { required: true },
            textEntryDate: { required: true },
            textFirstName: { required: true },
            textSecondName: { required: true },
            textLastName: { required: true },
            textSecondLastName: { required: true },
            textIdType: { required: true },
            textIdentificationNumber: { required: true },
            textBirthdate: { required: true },
            textGender: { required: true },
            textProvince: { required: true },
            textCanton: { required: true },
            textDistrict: { required: true },
            textStudent_Login: { required: true },
            textStudent_Password: { required: true },
            textStudent_Password_Confirm: { required: true, equalTo: "#textStudent_Password" },
            textLaboralStatus: { required: true },
            textWork_Address: { required: true },
            textEmail: { required: true },
            textPrimaryPhone: { required: true },
            textSecondaryPhone: { required: true },
            textLaboralExperience: { required: true },
            textDistrict: { required: true },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });

        }
    });
}



function resetForm() {
    $("#frmStudentCreate")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});


