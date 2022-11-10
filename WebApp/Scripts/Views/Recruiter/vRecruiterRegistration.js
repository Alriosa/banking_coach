function vRecruiterRegistration() {

    this.ctrlActions = new ControlActions();


    this.FillEntity = function () {
        this.ctrlActions.GetById('entity', function (financials) {
            $(financials).each(function (index, value) {
               if (value.UserActiveStatus == "Activo") {
                    $('#selectEntity').append("<option value=" + value.EntityUserID + "> " + value.Name + "</option> ");
                }
            });
        })
    }

    this.Create = function () {
        var recruiterData = {};

        recruiterData = this.ctrlActions.GetDataForm('frmRecruiterCreate');
        recruiterData.EntityAssociation = $('#selectEntity').val();

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
            entityUser: {
                required: "Seleccione una entidad financiera"
            },
            txtLogin: {
                required: "Ingrese un nombre de usuario",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
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
            entityUser: { required: true },
            txtLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20  },
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
    vrecruiter.FillEntity();
});
