function vStudentRegistration() {
    this.Create = function () {

        var studentData = {};
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');
        this.ctrlActions.PostToAPI('student', studentData, function () {
            resetForm();
        });
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentCreate").valid()) {
            this.Create();

        }
    }
}

this.RulesValidateCreate = function () {

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
        ignore: [],
        lang: 'es',
        errorClass: "is-invalid",
        rules: {
           
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });

        }
    });


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
            txtEntryDate: {
                required: "Debe ingresar una fecha de ingreso"
            },
            txtFirstName: {
                required: "Debe ingresar el primer nombre"
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
            txtFirstName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ]+$/ },
            txtSecondName: { regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ]+$/ },
            txtLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ]+$/},
            txtSecondLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ]+$/ },
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


