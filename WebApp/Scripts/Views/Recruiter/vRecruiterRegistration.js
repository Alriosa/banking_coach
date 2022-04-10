function vRecruiterRegistration() {

    this.ctrlActions = new ControlActions();


    this.FillFinancial = function () {
        this.ctrlActions.GetById('financial', function (financials) {
            $(financials).each(function (index, value) {
               if (value.UserActiveStatus == "1") {
                    $('#selectFinancial').append("<option value=" + value.FinancialUserID + "> " + value.FinancialLogin + "</option> ");
                }
            });
        })
    }

    this.Create = function () {
        var recruiterData = {};

        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterCreate');
        recruiterData.FinantialAssociation = $('#selectFinancial').val();

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

RulesValidateCreate = function () {
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            if (regexp.constructor != RegExp)
                regexp = new RegExp(regexp);
            else if (regexp.global)
                regexp.lastIndex = 0;
            return this.optional(element) || regexp.test(value);
        },
        "Revisa los campos."
    );

    $("#frmRecruiterCreate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            financial: {
                required: "Seleccione una entidad financiera"
            },
            txtLogin: {
                required: "Ingrese un nombre de usuario",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 10 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },
            txtPassword: {
                required: "Ingrese una contraseña",
                minlength: "La contraseña debe de tener mínimo 6 caracteres",
                maxlength: "La contraseña debe de tener máximo 20 caracteres",
            },

            txtConfirmPassword: {
                required: "Ingrese una contraseña",
                equalTo: "No coinciden las contraseñas"
            },
        },
        rules: {
            financial: { required: true },
            txtLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 10  },
            txtPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
        },
    });
}

function resetForm() {
    $("#frmRecruiterCreate")[0].reset();
}

$(document).ready(function () {
    RulesValidateCreate();

    var vrecruiter = new vRecruiterRegistration();
    vrecruiter.FillFinancial();
});
