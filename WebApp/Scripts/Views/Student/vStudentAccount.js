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
        studentData = this.ctrlActions.GetDataForm('frmEditInfoBasic');
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
        console.log(laboralData)
        /*this.ctrlActions.PostToAPI('laboral', laboralData, function () {
            resetForm();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);

        });
    }*/

        this.ValidateInputs = function () {
            if ($("#frmAddLaboral").valid()) {
                this.Create();

            }
        }

    }
}
    function padTo2Digits(num) {
        return num.toString().padStart(2, '0');
    }

    function formatDate(date) {
        return ([
            date.getFullYear(),
            padTo2Digits(date.getMonth() + 1),
            padTo2Digits(date.getDate()),
        ].join('-')
        );
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

