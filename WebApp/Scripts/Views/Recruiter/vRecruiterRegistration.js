function vRecruiterRegistration() {
    this.Create = function () {

        var recruiterData = {};

        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterCreate');



        this.ctrlActions.PostToAPI('recruiter', recruiterData, function () {
            resetForm();
        });

    }


    this.ValidateInputs = function () {
        if ($("#frmRecruiterCreate").valid()) {
            this.Create();
            resetForm();

        }
    }
}

this.RulesValidateCreate = function () {
    $("#frmRecruiterCreate").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtUserName: { required: true },
            txtPassword: { required: true },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword"  },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });
           
        }
    });
}



function resetForm() {
    $("#frmRecruiterCreate")[0].reset();
}


$(document).ready(function () {
    ReglasValidacionCrear();
});


