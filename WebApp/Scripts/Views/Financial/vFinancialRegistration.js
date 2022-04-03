﻿this.Create = function () {

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

ReglasValidacionCrear = function () {
    $("#frmFinancialCreate").submit(function (e) {
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

function limpiarFormulario() {
    $("#frmFinancialCreate")[0].reset();
}


$(document).ready(function () {
    ReglasValidacionCrear();
});

