function vStudentAccount() {
    this.ctrlActions = new ControlActions();
    var StudentProfileData = {};
    StudentProfileData = getCookie('user');
    if (StudentProfileData != null) {
        StudentProfileData = localStorage.getItem('selectedID');
    }

    this.GetData = function () {
        var idStudent = document.getElementById("txtIdStudent").value;

        if (idStudent != 'null') {
            this.ctrlActions.GetById("student/" + idStudent, this.FillData);
            this.ctrlActions.GetById("laboral/student/" + idStudent, this.GetLaboral);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            servicioData = {};
            this.ctrlActionsInto = new ControlActions();
            const [date] = formatDate(new Date(data["Birthdate"])).split(' ');

            this.ctrlActionsInto.BindFields('frmEditInfoBasic', data);
            const dateInput = document.getElementById('txtBirthdate');
            dateInput.value = date;
            let name = data['FirstName'] + ' ' + data['FirstLastName'] + ' ' + data['SecondLastName'];
            document.querySelector('#P_WelcomeName').append(data['FirstName'] + ' ' + data['FirstLastName']);

            document.querySelector('#P_LaboralStatus').append(data['LaboralStatus']);
            /*document.querySelector('#P_Workstation').append(data['Workstation']);
            document.querySelector('#P_Experience').append(data['Experience']);
            document.querySelector('#P_DriverLicenses').append(data['DriverLicenses']);
            document.querySelector('#P_LaboralExperience').append(data['LaboralExperience']);*/
            document.querySelector('#P_JobAvailability').append(data['JobAvailability']);
            document.querySelector('#P_Id_Type').append(data['IdType']);

            document.querySelector('#P_CompleteName').append(name);
            document.querySelector('#P_IdentificationNumber').append(data['IdentificationNumber']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_PhoneNumber').append(data['FirstPhoneNumber']);
            document.querySelector('#P_SecondPhoneNumber').append(data['SecondPhoneNumber']);
            //document.querySelector('#P_Language').append(data['Language']);
            document.querySelector('#P_Vehicle').append(data['Vehicle']);



            /*  document.querySelector('#P_Id_Type').append(data['IdType']);
              document.querySelector('#P_Identification_Number').append(data['IdentificationNumber']);
              document.querySelector('#P_Last_Name').append(data['LastName']);
              document.querySelector('#P_Email').append(data['Email']);
              document.querySelector('#P_Phone_Number').append(data['PhoneNumber']);
              */
            /*document.querySelector('#P_Second_Last_Name').append(data['SecondLastName']);
            switch (data['IdType']) {
                case "N":
                    document.querySelector('#P_Id_Type').append("Nacional");

                    break
                case "P":
                    document.querySelector('#P_Id_Type').append("Pasaporte");

                    break;
            }

            document.querySelector('#P_Identification_Number').append(data['IdentificationNumber']);
            document.querySelector('#P_Birthdate').append(data['Birthdate']);

            
            document.querySelector('#P_Primary_Phone').append(data['PrimaryPhone']);
            document.querySelector('#P_Secondary_Phone').append(data['SecondaryPhone']);

            if (data['LaboralExperience'] == "1") {
                document.querySelector('#P_Laboral_Experience').append("Sí");
            } else {
                document.querySelector('#P_Laboral_Experience').append("No");
            }

            if (data['LaboralStatus'] == "1") {
                document.querySelector('#P_LaboralStatus').append("Sí");
            } else {
                document.querySelector('#P_LaboralStatus').append("No");
            }
            document.querySelector('#P_Province').append(data['NProvince']);
            document.querySelector('#P_Canton').append(data['NCanton']);
            document.querySelector('#P_District').append(data['NDistrict']);

            if (data['BankingStudent'] == "1") {
                document.querySelector('#P_BankingStudent').append("Sí");
            } else {
                document.querySelector('#P_BankingStudent').append("No");
            }*/

        }
    }


    this.Update = function () {
        var studentData = {};
        var id = document.getElementById("txtIdStudent").value;
        var studentLogin = document.getElementById("txtStudentLogin").value;
        studentData = this.ctrlActions.Get('frmEditInfoBasic');
        if (studentData["JobAvailability"] == "Sí") {
            studentData["LaboralStatus"] = "No";
        } else {
            studentData["LaboralStatus"] = "Sí";
        }
        studentData["StudentLogin"] = studentLogin;
        studentData["StudentID"] = id;
        this.ctrlActions.PutToAPI('student/', studentData,
            function () {
                $('#modalEditInfo').modal('hide');

                setTimeout(function () {
                    window.location.reload();
                }, 3000)
            }

        );
    }



    this.CreateLaboral = function () {

        var laboralData = {};
        laboralData = this.ctrlActions.GetDataForm('frmAddLaboral');


        if (laboralData["EndDate"] == null) {
            laboralData["EndDate"] = null;
        }
        laboralData["StudentID"] = document.getElementById("txtIdStudent").value;
        console.log(laboralData)
        this.ctrlActions.PostToAPI('laboral', laboralData, function () {
            resetFormLaboral();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);

        });
    }

    this.ValidateInputsLaboral = function () {
        if ($("#frmAddLaboral").valid()) {
            this.CreateLaboral();

        }
    }

    this.GetLaboral = function (data) {

        console.log(data);

        let start = '';
        let end = '';

        let text2 = '';

        for (let i in data) {

            start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
            let endIsNull = new Date(data[i].EndDate);
            if (endIsNull.getFullYear() == 1900) {
                end = "Actualidad";
            } else {
                end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });

            }
            console.log(start);
            let responsabilities = data[i].Responsabilites.split(',');
            text2 += `<div class="card-laboral>"
                           <div class="container">
                                <div class="row">
                                    <div class="col-lg-1"
                                        style="text-align: center; font-size: 2em; color:#5e5e5e;">
                                        <i class="fa-solid fa-suitcase"></i>
                                    </div>
                                    <div class="col-lg-9">
                                        <ul class="unstyled">
                                            <li style="list-style-type: none;">
                                                <strong>${data[i].Company}</strong>
                                                <span> ${start} - ${end}</span>
                                            </li>
                                            <li style="list-style-type: none;">
                                                ${data[i].Workstation}
                                            </li>
                                            <li style="list-style-type: none;">
                                                Responsabilidades:
                                
                                                <ul>`;
                                        for (let j in responsabilities) {
                                            text2 += `<li>${responsabilities[j]}</li>`
                                        }

                                        text2 += `</ul>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-lg-2">
                                        <button class="btn btn-orange my-2"
                                            style="width: 170px;">
                                            Editar
                                        </button>
                                        <button class="btn btn-orange my-2"
                                            style="width: 170px;">
                                            Eliminar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>\n
                        <hr style="width:100%;text-align:left;margin-left:0" />\n`;


        }
        document.getElementById("listLaboral").innerHTML = text2;

    }


    this.CreateAcademic = function () {
    }

    this.CreateExtraCourse = function () {
    }
}
function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

function resetFormLaboral() {
    $("#frmAddLaboral")[0].reset();
}


function formatDate(date) {
    return ([
        date.getFullYear(),
        padTo2Digits(date.getMonth() + 1),
        padTo2Digits(date.getDate()),
    ].join('-')
    );
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

    /*$("#frmStudentUpdate").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtEntryDate: {
                required: "Debe ingresar una fecha de ingreso",
                regex: "No se permiten números ni caracteres especiales",
            },
            txtStudentLogin: {
                required: "Ingrese un nombre de usuario",
                minlength: "El nombre de usuario debe contener mínimo 6 caracteres",
                maxlength: "El nombre de usuario debe contener máximo 20 caracteres",
                regex: "Solo se permiten minusculas, numeros y el _",
            },
        },
        rules: {
            txtEntryDate: { required: true },
            txtStudentLogin: { required: true, regex: /^[a-z0-9_]+$/, minlength: 6, maxlength: 20 },
            
        },
    });*/


    $("#frmAddLaboral").validate({
        lang: 'es',
        errorClass: "is-invalid",
        messages: {
            txtWorkPosition: {
                required: "Ingrese un puesto",
            },
            txtWorkstation: {
                required: "Ingrese los cargos",
            },
            txCompany: {
                required: "Ingrese la compañía",
            },
            txtResponsabilites: {
                required: "Ingrese las responsabilidades",
            },
            txtStartDate: {
                required: "Ingrese una fecha",
            },

        },
        rules: {
            txtWorkPosition: { required: true },
            txtWorkstation: {
                required: true
            },
            txCompany: { required: true },
            txtResponsabilites: { required: true },
            txtStartDate: { required: true },
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


        RulesValidateCreate();

    });


    $("#editInformation").on("click", function () {
        $('#contentInformation').toggle();
        $('#contentLaboral').hide();
        $('#contentAcademic').hide();
    });

    $("#editLaboral").on("click", function () {
        $('#contentLaboral').toggle();
        $('#contentAcademic').hide();
        $('#contentInformation').hide();
    });

    $("#editAcademic").on("click", function () {
        $('#contentAcademic').toggle();
        $('#contentLaboral').hide();
        $('#contentInformation').hide();
    });

    $("#btnSaveChanges").attr("disabled", "disabled");


    // When the user clicks on the button, scroll to the top of the document
    var btn = $('#btnToTop');

    $(window).scroll(function () {
        if ($(window).scrollTop() > 300) {
            btn.addClass('show');
        } else {
            btn.removeClass('show');
        }
    });

    btn.on('click', function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, '300');
    });



})

