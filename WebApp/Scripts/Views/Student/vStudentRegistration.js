function vStudentRegistration() {

    this.ctrlActions = new ControlActions();

    this.Create = function () {

        var studentData = {};
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');



        this.ctrlActions.PostToAPI('student', studentData, function () {
            resetForm();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);

        });
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentCreate").valid()) {
            this.Create();

        }
    }
}

this.RulesValidateCreate = function () {

    $.validator.addMethod("notEqual", function (value, element, param) {
        return this.optional(element) || value != param;
    }),

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

    $("#frmStudentCreate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtEntryDate: {
                required: "Debe ingresar una fecha de ingreso",
                regex: "No se permiten números ni caracteres especiales",
            },
            txtFirstName: {
                regex: "No se permiten números ni caracteres especiales",
            },
            txtFirstName: {
                required: "Debe ingresar el primer nombre",
                regex: "No se permiten números ni caracteres especiales",
            },
            txtLastName: {
                required: "Debe ingresar el primer apellido",
                regex: "No se permiten números ni caracteres especiales"
            },
            txtSecondLastName: {
                required: "Debe ingresar el segundo apellido",
                regex: "No se permiten números ni caracteres especiales"
            },
            txtIdentificationNumber: {
                required: "Debe ingresar el número de identificación"
            },
            txtBirthdate: {
                required: "Debe ingresar la fecha de nacimiento"
            },
            txtLaboralStatus: {
                required: "Debe ingresar el estado laboral"
            },
            txtWorkAddress: {
                required: "Debe ingresar la dirección del trabajo"
            },
            txtEmail: {
                required: "Debe ingresar el correo electrónico",
                email: "Debe ingresar un correo electrónico con el formato correcto"
            },
            txtPrimaryPhone: {
                required: "Debe ingresar el número de teléfono principal",
                digits: "Debe ingresar digitos"
            },
            txtSecondaryPhone: {
                digits: "Debe ingresar digitos"
            },
            txtLaboralExperience: {
                required: "Debe ingresar la experiencia laboral"
            },
            txtStudentLogin: {
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
            txtBankingStudent: { required: true },
            txtEntryDate: { required: true },
            txtFirstName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtSecondName: { regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/},
            txtSecondLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtIdType: { required: true },
            txtIdentificationNumber: { required: true },
            txtBirthdate: { required: true },
            txtGender: { required: true },
            txtProvince: { required: true, notEqual: "0" },
            txtCanton: { required: true, notEqual: "0" },
            txtDistrict: { required: true, notEqual: "0" },
            txtStudentLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 10 },
            txtPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
            txtLaboralStatus: { required: true },
            txtWorkAddress: { required: true },
            txtEmail: { required: true, email: true },
            txtPrimaryPhone: { required: true, digits: true },
            txtSecondaryPhone: { digits: true  },
            txtLaboralExperience: { required: true },
        },
    });
}



function resetForm() {
    $("#frmStudentCreate")[0].reset();
}


$(document).ready(function () {

    $(function () {
        var showCanton = function (selectedProvince) {
            $('#txtCanton option').hide();
          //  $('#txtCanton').find('option').filter("option[data ^= '" + selectedProvince + "']").show();
            //$('#txtCanton').find(`option`).hide(); // hide all

            $('#txtCanton').find(`option[data-parent=${selectedProvince}]`).show();

            //set default value
            var defaultCanton = "Seleccione una provincia";
          //  $('#txtCanton').val(defaultCanton);
            $("#txtCanton").val($("#txtCanton option:first").val());

        };

        var showDistrict = function (selectedCanton) {
            $('#txtDistrict option').hide();
            //$('#txtDistrict').find('option').filter("option[data.pc ^= '" + selectedCanton + "']").show();
            $('#txtDistrict').find(`option[data-parent=${selectedCanton}]`).show()
            //set default value
            var defaultDistrito = "Seleccione un cantón";
            //$('#txtDistrict').val(defaultDistrito);
            $("#txtDistrict").val($("#txtDistrict option:first").val());

        };

        //set default provincia
        var province = $('#txtProvince').val();
        showCanton(province);
        $('#txtProvince').change(function () {
            showCanton($(this).val());
        });

        //set default canton
        var canton = $('#txtCanton').val();
        showDistrict(canton);
        $('#txtCanton').change(function () {
            showDistrict($(this).val());
        });

        $('#txtDistrict').change(function () {

        });
    });

    RulesValidateCreate();
});


