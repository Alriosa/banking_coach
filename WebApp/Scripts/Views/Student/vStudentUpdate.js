function vStudentUpdate() {
    this.service = 'student';
    this.ctrlActions = new ControlActions();

    this.GetData = function () {
        var idStudent = document.getElementById("txtIdStudent").value;
        if (idStudent != 'null') {
            this.ctrlActions.GetById("student/" + idStudent, this.FillDataForm);
        }
    }

    this.FillDataForm = function (data) {
        document.querySelector('#txtBankingStudent').value = data['BankingStudent'];
        document.querySelector('#txtStudentLogin').value = data['StudentLogin'];
        document.querySelector('#txtEmail').value = data['Email'];
        document.querySelector('#txtIdentificationNumber').value =  data['IdentificationNumber'];
        document.querySelector('#txtFirstName').value = data['FirstName'];
        document.querySelector('#txtSecondName').value = data['SecondName'];
        document.querySelector('#txtLastName').value = data['LastName'];
        document.querySelector('#txtSecondLastName').value = data['SecondLastName'];
        document.querySelector('#txtIdType').value = data['IdType'];
        document.querySelector('#txtIdentificationNumber').value = data['IdentificationNumber'];
        document.querySelector('#txtBirthdate').value = formatDateString(data['Birthdate']);
        document.querySelector('#txtGender').value = data['Gender'];
        document.querySelector('#txtPrimaryPhone').value = data['PrimaryPhone'];
        document.querySelector('#txtSecondaryPhone').value = data['SecondaryPhone'];
        document.querySelector('#txtLaboralExperience').value = data['LaboralExperience'];
        document.querySelector('#txtLaboralStatus').value = data['LaboralStatus'];
        document.querySelector('#txtProvince').value = data['Province'];
        document.querySelector('#txtCanton').value = data['Canton'];
        document.querySelector('#txtDistrict').value = data['District'];
        document.querySelector('#txtWorkAddress').value = data['WorkAddress'];
        localStorage.setItem('keyStudent', data['StudentPassword'])
    }

    this.Update = function () {
        var studentData = {};
        var id = document.getElementById("txtIdStudent").value;
        var studentLogin = document.getElementById("txtStudentLogin").value;
        studentData = this.ctrlActions.GetDataForm('frmStudentUpdate');
        studentData["StudentLogin"] = studentLogin;
        this.ctrlActions.PutToAPI(this.service, studentData,
           setTimeout(function redirection() { window.location.href = '/Student/vStudentList/'}, 3000));
    }

    this.UpdatePassword = function () {
        var studentData = {};
        var id = document.getElementById("txtIdStudent").value;
        var studentLogin = document.getElementById("txtStudentLogin").value;
        studentData = this.ctrlActions.GetDataForm('frmStudentUpdatePassword');
        studentData["StudentLogin"] = studentLogin;
        this.ctrlActions.PutToAPI(this.service + "/changePassword", studentData,
            setTimeout(function redirection() { window.location.href = '/Student/vStudentList/' }, 3000));
    }

    this.ValidateInputs = function () {
        if ($("#frmStudentUpdate").valid()) {
            this.Update();

        }
    }

    this.ValidateInputsPassword = function () {
        if ($("#frmStudentUpdatePassword").valid()) {
            this.UpdatePassword();

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

    $("#frmStudentUpdate").validate({
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
            txtSecondName: {
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
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },
        },
        rules: {
            txtBankingStudent: { required: true },
            txtEntryDate: { required: true },
            txtFirstName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtSecondName: { regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtSecondLastName: { required: true, regex: /^[a-zA-ZáäéëíïóöúüñÑÁÄÉËÍÏÓÖÚÜ ]+$/ },
            txtIdType: { required: true },
            txtIdentificationNumber: { required: true },
            txtBirthdate: { required: true },
            txtGender: { required: true },
            txtProvince: { required: true, notEqual: "0" },
            txtCanton: { required: true, notEqual: "0" },
            txtDistrict: { required: true, notEqual: "0" },
            txtStudentLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
            txtPassword: { required: true, minlength: 6, maxlength: 20 },
            txtConfirmPassword: { required: true, equalTo: "#txtPassword" },
            txtLaboralStatus: { required: true },
            txtWorkAddress: { required: true },
            txtEmail: { required: true, email: true },
            txtPrimaryPhone: { required: true, digits: true },
            txtSecondaryPhone: { digits: true },
            txtLaboralExperience: { required: true },
        },
    });


    $("#frmStudentUpdatePassword").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtOldPassword: {
                required: "Ingrese una contraseña",
                minlength: "La contraseña debe de tener mínimo 6 caracteres",
                maxlength: "La contraseña debe de tener máximo 20 caracteres",
            },
            txtNewPassword: {
                required: "Ingrese una contraseña",
                minlength: "La contraseña debe de tener mínimo 6 caracteres",
                maxlength: "La contraseña debe de tener máximo 20 caracteres",
            },
            txtConfirmNewPassword: {
                required: "Ingrese una contraseña",
                equalTo: "No coinciden las contraseñas"
            },
        },
        rules: {
            txtOldPassword: { required: true, minlength: 6, maxlength: 20 },
            txtNewPassword: {
                required: true, minlength: 6, maxlength: 20, new_password_not_same: true },
            txtConfirmNewPassword: { required: true, equalTo: "#txtNewPassword" },
        },
    });
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