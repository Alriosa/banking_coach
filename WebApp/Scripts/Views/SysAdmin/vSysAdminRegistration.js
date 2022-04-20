function vSysAdminRegistration() {
    this.ctrlActions = new ControlActions();

    this.Create = function () {
        var sysAdmin = {};

        sysAdmin = this.ctrlActions.GetDataForm('frmSysAdminCreate');

        this.ctrlActions.PostToAPI('sysadmin', sysAdmin, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmSysAdminCreate").valid()) {
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

    $("#frmSysAdminCreate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
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
            txtLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
            txtPassword: { required: true, minlength: 6, maxlength:20 },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
        }
    });
}

$("#txtLogin").rules("add", { pattern: "/^[a-z0-9_]{2,10}$/" })

function resetForm() {
    $("#frmSysAdminCreate")[0].reset();
}

$(document).ready(function () {
    RulesValidateCreate();
});