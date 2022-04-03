this.Create = function () {

    var recruiterData = {};

    recruiterData = this.ctrlActions.GetDataForm('frmRecruiterCreate');



    this.ctrlActions.PostToAPI('recruiter', recruiterData, function () {
            var vRecruiter = new vRecruiterlList();
            vRecruiter.ReloadTable();
    });

}


this.ValidateInputs = function () {
    if ($("#frmRecruiterCreate").valid()) {
        this.Create();
    }
}

this.ReglasValidacionCrear = function () {
    $("#frmRecruiterCreate").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtUserName: { required: true },
            textPassword: { required: true },
            textConfirmPassword: { required: true, equalTo: "#textPassword"  },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });
           
        }
    });
}



function limpiarFormulario() {
    $("#frmRecruiterCreate")[0].reset();
}


$(document).ready(function () {
    ReglasValidacionCrear();
});


