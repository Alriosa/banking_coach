this.Create = function () {

    var financialData = {};

    financialData = this.ctrlActions.GetDataForm('frmFinancialCreate');

    this.ctrlActions.PostToAPI('financial', financialData, function () {
            var vFinancial = new vFinancialList();
            vFinancial.ReloadTable();
    });
}

this.ValidateInputs = function () {
    if ($("#frmFinancialCreate").valid()) {
        this.Create();
    }
}

this.RulesValidateCreate = function () {
    $("#frmFinancialCreate").submit(function (e) {
        e.preventDefault();
    }).validate({
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
            txtUserName: { required: true },
            txtPassword: { required: true },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });

        }
    });

}

function resetForm() {
    $("#frmFinancialCreate")[0].reset();
}


$(document).ready(function () {
    RulesValidateCreate();
});

