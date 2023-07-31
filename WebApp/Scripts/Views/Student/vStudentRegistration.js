function vStudentRegistration() {

    this.ctrlActions = new ControlActions();

    this.Create = function () {
        var studentData = {};
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');

        var studentLogin = $("#txtIdentificationNumber").val().trim();;
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');
       
        studentData["StudentLogin"] = studentLogin;
        studentData["UserLogin"] = studentLogin;

        this.ctrlActions.PostToAPI('student', studentData, function (response) {
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
            txtIdentificationNumber: {
                required: "Debe ingresar el número de identificación"
            },
            txtEmail: {
                required: "Debe ingresar el correo electrónico",
                email: "Debe ingresar un correo electrónico con el formato correcto"
            },
        },
        rules: {
            txtBankingStudent: { required: true },
            txtIdType: { required: true },
            txtIdentificationNumber: { required: true },
            txtEmail: { required: true, email: true },
        },
    });
}


function resetForm() {
    $("#frmStudentCreate")[0].reset();
}

function getEdad(dateString) {
    let hoy = new Date()
    let fechaNacimiento = new Date(dateString)
    let edad = hoy.getFullYear() - fechaNacimiento.getFullYear()
    let diferenciaMeses = hoy.getMonth() - fechaNacimiento.getMonth()
    if (
        diferenciaMeses < 0 ||
        (diferenciaMeses === 0 && hoy.getDate() < fechaNacimiento.getDate())
    ) {
        edad--
    }
    return edad;
}


$(document).ready(function () {

    let maxDate = new Date()
    maxDate.setFullYear(maxDate.getFullYear() - 18)

    $('#txtBirthdate').attr('max', maxDate.toISOString().split('T')[0])

    let user = getCookie('user');
    if (user != undefined) {
        $('.isAdmin').removeClass("d-none");
        $('.isStudent').addClass("d-none");
    } else {
        $('.isAdmin').addClass("d-none");
        $('.isStudent').removeClass("d-none");
    }


    $(function () {
        var showCanton = function (selectedProvince) {
            $('#txtCanton option').hide();

            $('#txtCanton').find(`option[data-parent=${selectedProvince}]`).show();
            //set default value
            var defaultCanton = "Seleccione una provincia";
            $("#txtCanton").val($("#txtCanton option:first").val());

        };

        var showDistrict = function (selectedCanton) {
            $('#txtDistrict option').hide();
            $('#txtDistrict').find(`option[data-parent=${selectedCanton}]`).show()
            //set default value
            var defaultDistrito = "Seleccione un cantón";
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

        $('#txtBirthdate').change(function () {
            let edad = getEdad($('#txtBirthdate').val())
            $('#txtAge').val(edad);
            if (edad < 18) {
                $('#btnRegister').attr('disabled', 'disabled')
            } else {
                $('#btnRegister').removeAttr('disable')
            }
        });

        $("#txtVehicle").change(function () {
            if ($('#txtVehicle').val() == "Sí") {
                $('.selectedVehicle').show();
            } else {
                $('.selectedVehicle').hide();
            }
        });
    });

    RulesValidateCreate();
});

