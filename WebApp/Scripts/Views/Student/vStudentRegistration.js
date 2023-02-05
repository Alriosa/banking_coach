function vStudentRegistration() {

    this.ctrlActions = new ControlActions();

    this.Create = function () {

        var studentData = {};
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');

        var studentLogin = $("#txtIdentificationNumber").val();
        studentData = this.ctrlActions.GetDataForm('frmStudentCreate');
        if (studentData["JobAvailability"] == "Sí") {
            studentData["LaboralStatus"] = "No";
        } else {
            studentData["LaboralStatus"] = "Sí";
        }
        studentData["StudentLogin"] = studentLogin;
        studentData["UserLogin"] = studentLogin;

        var array = [];

        if (studentData["Vehicle"] == "No") {
            studentData["Type_Vehicle"] = "";
        } else {
            var checkboxesV = document.querySelectorAll('input[name=typeVehicles]:checked');
            for (var i = 0; i < checkboxesV.length; i++) {
                array.push(checkboxesV[i].value);
            }
            studentData["Type_Vehicle"] = array.join(', ');

        }
        array = [];


        var checkboxes = document.querySelectorAll('input[name=driverLicenses]:checked');
        for (var i = 0; i < checkboxes.length; i++) {
            array.push(checkboxes[i].value);
        }
        studentData["DriverLicenses"] = array.join(', ');
        $("html, body").animate({ scrollTop: 0 }, 600);
        this.ctrlActions.PostToAPI('student', studentData, function (response) {

            let user = getCookie('user');

            if (user) {
                setTimeout(function redirection() { window.location.href = '/Student/vStudentList'; }, 4000);

            } else {
                setTimeout(function redirection() { window.location.href = '/Home'; }, 4000);
            }

          /* var user = {};


            user['text'] = "Estudiante Registrado";
            user['subject'] = "Registro de Estudiante";
            user['email'] = studentData['Email'];
            this.ctrlActions2.PostToAPI('mail/studentRegistered', user, function () {
                let user = JSON.parse(getCookie('user'));

                if (user) {
                    setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 4000);
                } else {
                    setTimeout(function redirection() { window.location.href = '/Student/vStudentList'; }, 4000);
                    resetForm();
                }
            });*/

            

        });
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentCreate").valid()) {
            this.Create();

        }
    }
}

$("#txtVehicle").change(function () {
    if ($('#txtVehicle').val() == "Sí") {
        $('.selectedVehicle').show();
    } else {
        $('.selectedVehicle').hide();
    }
});

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
            txtAge: {
                min: "Debe ser mayor de 18 años"
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
            
            txtStudentLogin: {
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
            txtBankingStudent: { required: true },
            txtFirstName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/},
            txtSecondLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtIdType: { required: true },
            txtIdentificationNumber: { required: true },
            txtBirthdate: { required: true },
            txtAge: { min: 18 },
            txtProvince: { required: true, notEqual: "0" },
            txtCanton: { required: true, notEqual: "0" },
            txtDistrict: { required: true, notEqual: "0" },
            txtStudentLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
            txtPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
            txtEmail: { required: true, email: true },
            txtPrimaryPhone: { required: true, digits: true },
            txtSecondaryPhone: { digits: true  },
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


