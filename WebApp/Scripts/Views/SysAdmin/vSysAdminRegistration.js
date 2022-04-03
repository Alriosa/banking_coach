this.Create = function () {

    var sysAdmin = {};

    sysAdmin = this.ctrlActions.GetDataForm('frmSysAdminCreate');


    this.ctrlActions.PostToAPI('sysAdmin', sysAdmin, function () {
            var vSysAdmin = new vSysAdminlList();
            vSysAdmin.ReloadTable();
    });

}



this.ValidateInputs = function () {
    if ($("#frmSysAdminCreate").valid()) {
        this.Create();
    }
}

this.RulesValidateCreate = function () {
    $("#frmSysAdminCreate").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtUserName: { required: true },
            textPassword: { required: true },
            textConfirmPassword: { required: true, equalTo: "#textPassword" },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });

        }
    });
}



function resetForm() {
    $("#frmSysAdminCreate")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});


