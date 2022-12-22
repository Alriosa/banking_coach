function vEntityRegistration() {

    this.ctrlActions = new ControlActions();

    this.Create = function () {

        var entityData = {};

        entityData = this.ctrlActions.GetDataForm('frmEntityCreate');
        entityData["User_Login"] = $("#txtID").val();

        this.ctrlActions.PostToAPI('entity', entityData, function () {
            resetForm();
            setTimeout(function redirection() { window.location.href = '/EntityUser/vEntityList'; }, 4000);
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmEntityCreate").valid()) {
            this.Create();
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

    $("#frmEntityCreate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
           /* txtLogin: {
                required: "Ingrese un nombre representativo",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },*/
            txtName: {
                required: "Ingrese un nombre",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas y espacios",
            },
            /*txtEmail: {
                required: "Ingrese un nombre de usuario",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },*/
        },
        rules: {
            //txtLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
            txtName: { required: true, regex: /^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$/, minlength: 6, maxlength: 20 },
           // txtEmail: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
        }
    });

}

function resetForm() {
    $("#frmEntityCreate")[0].reset();
}

$(document).ready(function () {
    RulesValidateCreate();
});

