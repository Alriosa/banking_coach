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
            txtBankingStudent: { required: true },
            textEntryDate: { required: true },
            textFirstName: { required: true },
            textSecondName: { required: true },
            textLastName: { required: true },
            textSecondLastName: { required: true },
            textIdType: { required: true },
            textIdentificationNumber: { required: true },
            textBirthdate: { required: true },
            textGender: { required: true },
            textProvince: { required: true },
            textCanton: { required: true },
            textDistrict: { required: true },
            textStudent_Login: { required: true },
            textStudent_Password: { required: true },
            textStudent_Password_Confirm: { required: true, equalTo: "#textStudent_Password" },
            textLaboralStatus: { required: true },
            textWork_Address: { required: true },
            textEmail: { required: true },
            textPrimaryPhone: { required: true },
            textSecondaryPhone: { required: true },
            textLaboralExperience: { required: true },
            textDistrict: { required: true },
        },
        errorPlacement: function (error, element) {
            element: "div";
            $(error).addClass('input-group mb-3');
            error.css({ 'padding-left': '10px', 'margin-right': '20px', 'padding-bottom': '2px', 'color': 'red' });

        }
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


