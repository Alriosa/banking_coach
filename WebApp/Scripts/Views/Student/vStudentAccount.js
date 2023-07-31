var laboralList = [];
var academicList = [];
var courseList = [];
var languageList = [];
var referenceList = [];
var dataStudent;
var apiURl = 'https://api-bcjyd.azurewebsites.net/';
function vStudentAccount() {
    this.ctrlActions = new ControlActions();
    var StudentProfileData = {};
    

    StudentProfileData = getCookie('user');
    if (StudentProfileData != null || getCookie('type') != 2) {
        StudentProfileData = localStorage.getItem('selectedID');
    }


    this.UpdatePassword = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var studentData = {};
        var studentLogin = document.getElementById("P_Email").textContent;
        studentData = this.ctrlActions.GetDataForm('frmEditPassword');

        if (studentData['StudentPassword'] == studentData['ConfirmNewPassword']) {
            studentData["Email"] = studentLogin;
            this.ctrlActions.PutToAPI("student/changePassword", studentData,
                setTimeout(function redirection() { LogOut() }, 3000));
        } else {
            this.ctrlActions.ShowMessage('E', "Las contraseñas no coinciden");
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        }
        

       
    }

    this.GetData = async function () {
        var idStudent = document.getElementById("txtIdStudent").value;

        if (idStudent != 'null') {
            this.ctrlActions.GetById("student/" + idStudent, this.FillData);
            this.ctrlActions.GetById("laboral/student/" + idStudent, this.GetLaboral);
            this.ctrlActions.GetById("academic/student/" + idStudent, this.GetAcademic);
            this.ctrlActions.GetById("extracourse/student/" + idStudent, this.GetCourse);
            this.ctrlActions.GetById("reference/student/" + idStudent, this.GetReference);
            await this.ctrlActions.GetById("language/student/" + idStudent, this.GetLanguages);
        }
    }

    this.FillData = function (data) {
        let licences = ["A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2"];
        let typeVehicles = ["Motocicleta", "Vehículo Particular", "Camioneta", "Buseta", "Camión"];
        let cont = -1;
       
        if (data != null) {
            if (getCookie('type') != 2) {
                dataStudent = data;
            }
            servicioData = {};
            this.ctrlActionsInto = new ControlActions();
            const [date] = formatDate(new Date(data["Birthdate"])).split(' ');

            this.ctrlActionsInto.BindFields('frmEditInfoBasic', data);

            var array = data["DriverLicenses"].split(", ");
            $("input[name=driverLicenses]").each(function () {
                cont++;
                $(this).val(licences[cont]);

                if (array.includes(licences[cont])) {
                    $(this).prop("checked", true)
                }
            })
            cont = -1;

            var array = data["Type_Vehicle"].split(", ");
            $("input[name=typeVehicles]").each(function () {
                cont++;
                $(this).val(typeVehicles[cont]);

                if (array.includes(typeVehicles[cont])) {
                    $(this).prop("checked", true)
                }
            })

            const dateInput = document.getElementById('txtBirthdate');
            dateInput.value = date;
            let name = data['FirstName'] + ' ' + data['FirstLastName'] + ' ' + data['SecondLastName'];

            document.querySelector('#P_JobAvailability').append(data['JobAvailability']);
            document.querySelector('#P_Id_Type').append(data['IdType']);
            document.querySelector('#P_DriverLicenses').append(data['DriverLicenses']);
            document.querySelector('#P_CompleteName').append(name);
            document.querySelector('#P_IdentificationNumber').append(data['IdentificationNumber']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_PhoneNumber').append(data['FirstPhoneNumber']);
            document.querySelector('#P_SecondPhoneNumber').append(data['SecondPhoneNumber']);
            document.querySelector('#P_Vehicle').append(data['Vehicle']);
            if (data['Type_Vehicle'] != null && data['Type_Vehicle'] != ""){
                document.querySelector('#P_Type_Vehicle').append("Tipo: " + data['Type_Vehicle']);
            }
            document.querySelector('#P_Location').append(data['NProvince'] + ", " + data['NCanton'] + ", " + data['NDistrict']);

            document.querySelector('#P_Country').append(data['Country']);

            document.querySelector('#P_Birthdate').append(formatDate(new Date(data['Birthdate'])));
            document.querySelector('#P_Age').append(data['Age']);

            if (data['Vehicle'] == "Sí") {
                $('#chkVehiclesTypes').show();
            } else {
                $('#chkVehiclesTypes').hide();
            }

            document.querySelector('#P_BankingStudent').append(data['BankingStudent']);

            var entityName = (data['EntityName'] == "F_DEFAULT" || data['EntityName'] == "") ? "Sin reclutar" : data['EntityName'] + ((data['StatusHired'] == 1) ? " ( Contratado )" : entityName + '( En Proceso de Reclutamiento )') ;
            document.querySelector('#P_EntityName').append(entityName);

            var province = $('#txtProvince').val();
            showCanton(province);
            $("#txtCanton").val(data['Canton']);
            showDistrict($('#txtCanton').val());

            var selectDistrict = $("#txtDistrict");
            var districtSelected = selectDistrict.find("option[data-parent='" + data['Canton'] + "'][value='" + data['District'] + "']");
            districtSelected.prop("selected", true);
        }
    }

    this.Update = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
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
        laboralData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PostToAPI('laboral', laboralData, function () {
            resetFormLaboral();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2.GetById("laboral/student/" + laboralData["StudentID"], this.student.GetLaboral);

            $('#addLaboral').modal('toggle');
        });
    }

    this.UpdateLaboral = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var laboralData = {};
        laboralData = this.ctrlActions.GetDataForm('frmEditLaboral');
        laboralData['LaboralID'] = document.querySelector('#laboral_token').value;
        laboralData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PutToAPI('laboral', laboralData, function () {
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            resetFormEditLaboral();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2.GetById("laboral/student/" + laboralData["StudentID"], this.student.GetLaboral);
            $('#editLaboral').modal('toggle');
        });
    }

    this.CreateAcademic = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var academicData = {};
        academicData = this.ctrlActions.GetDataForm('frmAddAcademic');
        academicData['DegreeType'] = $('input[name="rdDegreeType"]:checked').val();
        academicData["StudentID"] = document.getElementById("txtIdStudent").value;
        var fileUpload = $("#txtCertificateA").get(0);
        var files = fileUpload.files;

        var fileData = new FormData();

        //fileData.append(files[0].name, files[0]);

        if (fileUpload.files.length > 0) {
            fileData.append("fileName", files[0].name);
            fileData.append("file", files[0]);
        }
        fileData.append("academic", JSON.stringify(academicData));

        $.ajax({
            url: apiURl + 'api/academic',
            type: 'post',
            datatype: 'json',
            contentType: false,
            processData: false,
            async: false,
            data: fileData,
            success: function (response) {
                $('#addAcademic').modal('toggle');
                this.ctrlActions2 = new ControlActions();
                this.student = new vStudentAccount();

                //setTimeout(function redirection() { location.reload; }, 5000);
                this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
                $('#addAcademic').modal('toggle');
                $('.selectedFinishA').hide();

            }
        });
        /*this.ctrlActions.PostToAPI('academic', academicData, function () {
            resetFormAcademic();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
            $('#addAcademic').modal('toggle');
        });*/
    }

    this.UpdateAcademic = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var academicData = {};
        academicData = this.ctrlActions.GetDataForm('frmEditAcademic');
        academicData['DegreeType'] = $('input[name="rdDegreeType"]:checked').val();
        academicData['AcademicID'] = document.querySelector('#academic_token').value;
        academicData["StudentID"] = document.getElementById("txtIdStudent").value;


        var fileUpload = $("#txtEditCertificateA").get(0);
        var files = fileUpload.files;

        var fileData = new FormData();

        //fileData.append(files[0].name, files[0]);

        if (fileUpload.files.length > 0) {
            fileData.append("fileName", files[0].name);
            fileData.append("file", files[0]);
        }
        fileData.append("academic", JSON.stringify(academicData));

        $.ajax({
            url: apiURl + 'api/academic',
            type: 'put',
            datatype: 'json',
            contentType: false,
            processData: false,
            async: false,
            data: fileData,
            success: function (response) {
                $('#editAcademic').modal('toggle');
                this.ctrlActions2 = new ControlActions();
                this.student = new vStudentAccount();

                //setTimeout(function redirection() { location.reload; }, 5000);
                this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
                $('#editAcademic').modal('toggle');
                $('.selectedFinishA').hide();

            }
        });


      /*  this.ctrlActions.PutToAPI('academic', academicData, function () {
            resetFormEditAcademic();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
            $('#editAcademic').modal('toggle');
        });*/
    }

    this.CreateExtraCourse = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var courseData = {};
        courseData = this.ctrlActions.GetDataForm('frmAddCourse');
        courseData["StudentID"] = document.getElementById("txtIdStudent").value;

        var fileUpload = $("#txtCertificateC").get(0);
        var files = fileUpload.files;

        var fileData = new FormData();

        //fileData.append(files[0].name, files[0]);

        if (fileUpload.files.length > 0) {
            fileData.append("fileName", files[0].name);
            fileData.append("file", files[0]);
        }
        fileData.append("course", JSON.stringify(courseData));

        $.ajax({
            url: apiURl + 'api/extracourse',
            type: 'post',
            datatype: 'json',
            contentType: false,
            processData: false,
            async: false,
            data: fileData,
            success: function (response) {
                this.ctrlActions2 = new ControlActions();
                this.student = new vStudentAccount();

                //setTimeout(function redirection() { location.reload; }, 5000);
                this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
                $('#addCourse').modal('toggle');
                $('.selectedFinishC').hide();

            }
        });


        /*this.ctrlActions.PostToAPI('extracourse', courseData, function () {
            resetFormCourse();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
            $('#addCourse').modal('toggle');
        });*/
    }

    this.UpdateExtraCourse = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var courseData = {};
        courseData = this.ctrlActions.GetDataForm('frmEditCourse');
        courseData['CourseID'] = document.querySelector('#course_token').value;
        courseData["StudentID"] = document.getElementById("txtIdStudent").value;

        var fileUpload = $("#txtCertificateC").get(0);
        var files = fileUpload.files;

        var fileData = new FormData();

        //fileData.append(files[0].name, files[0]);

        if (fileUpload.files.length > 0) {
            fileData.append("fileName", files[0].name);
            fileData.append("file", files[0]);
        }
        fileData.append("course", JSON.stringify(courseData));

        $.ajax({
            url: apiURl + 'api/extracourse',
            type: 'put',
            datatype: 'json',
            contentType: false,
            processData: false,
            async: false,
            data: fileData,
            success: function (response) {
                $('#editCourse').modal('toggle');
                this.ctrlActions2 = new ControlActions();
                this.student = new vStudentAccount();

                //setTimeout(function redirection() { location.reload; }, 5000);
                this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
                $('#editCourse').modal('toggle');
                $('.selectedFinishC').hide();

            }
        });

        /*this.ctrlActions.PutToAPI('extracourse', courseData, function () {
            resetFormEditCourse();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
            $('#editCourse').modal('toggle');
        });*/
    }

    this.CreateReference = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var referenceData = {};
        referenceData = this.ctrlActions.GetDataForm('frmAddReference');
        referenceData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PostToAPI('reference', referenceData, function () {
            resetFormReference();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();
            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("reference/student/" + referenceData["StudentID"], this.student.GetReference);
            $('#addReference').modal('toggle');
        });
    }

    this.UpdateReference = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var referenceData = {};
        referenceData = this.ctrlActions.GetDataForm('frmEditReference');
        referenceData['ReferenceID'] = document.querySelector('#reference_token').value;
        referenceData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PutToAPI('reference', referenceData, function () {
            resetFormEditReference();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("reference/student/" + referenceData["StudentID"], this.student.GetReference);
            $('#editReference').modal('toggle');
        });
    }

    this.CreateLanguage = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var languageData = {};
        languageData = this.ctrlActions.GetDataForm('frmAddLanguage');
        languageData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PostToAPI('language', languageData, function () {
            resetFormLanguage();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("language/student/" + languageData["StudentID"], this.student.GetLanguages);
            $('#addLanguage').modal('toggle');
        });
    }

    this.UpdateLanguage = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var languageData = {};
        languageData = this.ctrlActions.GetDataForm('frmEditLanguage');
        languageData['LanguageID'] = document.querySelector('#language_token').value;
        languageData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PutToAPI('language', languageData, function () {
            resetFormEditReference();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("language/student/" + languageData["StudentID"], this.student.GetLanguages);
            $('#editLanguage').modal('toggle');
        });
    }
    
    this.ValidateInputsAddLaboral = function () {
        if ($("#frmAddLaboral").valid()) {
            this.CreateLaboral();
        }
    }

    this.ValidateInputsEditLaboral = function () {
        if ($("#frmEditLaboral").valid()) {
            this.UpdateLaboral();
        }
    }

    this.ValidateInputsAddAcademic = function () {
        if ($("#frmAddAcademic").valid()) {
            this.CreateAcademic();
        }
    }

    this.ValidateInputsEditAcademic = function () {
        if ($("#frmEditAcademic").valid()) {
            this.UpdateAcademic();
        }
    }

    this.ValidateInputsAddCourse = function () {
        if ($("#frmAddCourse").valid()) {
            this.CreateExtraCourse();
        }
    }

    this.ValidateInputsEditCourse = function () {
        if ($("#frmEditCourse").valid()) {
            this.UpdateExtraCourse();
        }
    }

    this.ValidateInputsAddReference = function () {
        if ($("#frmAddReference").valid()) {
            this.CreateReference();
        }
    }

    this.ValidateInputsEditReference = function () {
        if ($("#frmEditReference").valid()) {
            this.UpdateReference();
        }
    }

    this.ValidateInputsAddLanguage = function () {
        if ($("#frmAddLanguage").valid()) {
            this.CreateLanguage();
        }
    }

    this.ValidateInputsEditLanguage = function () {
        if ($("#frmEditLanguage").valid()) {
            this.UpdateLanguage();
        }
    }

    this.GetLaboral = function (data) {
        let start = '';
        let end = '';

        let text2 = '';
        $('#profileContent').empty();
        laboralList = [];
        if (data.length > 0) {
            laboralList = data;

            for (let i in data) {

                start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
                let endIsNull = new Date(data[i].EndDate);
                if (endIsNull.getFullYear() == 1900) {
                    end = "Actualidad";
                } else {
                    end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });

                }

                $('#profileContent').append(data[i].Responsabilites);
                if ((i + 1) < data.length) {
                    $('#profileContent').append(', ');
                }

                let responsabilities = data[i].Responsabilites.split(',');
                text2 += `<div class="card-laboral">
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
                                    <div class="col-lg-2 acciones">
                                        <button class="btn btn-orange my-2" type="button" data-toggle="modal"
                                            data-target="#editLaboral" style="width: 170px;"
                                            onclick="GetDataLaboral(${data[i].LaboralID})">
                                            Editar
                                        </button>
                                        <button class="btn btn-orange my-2"
                                            style="width: 170px;"  onclick="DeleteLaboral(${data[i].LaboralID})">
                                            Eliminar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>\n
                        <hr style="width:100%;text-align:left;margin-left:0" />\n`;
            }
            document.getElementById("listLaboral").innerHTML = text2;
            $("#infoProgress").width($("#infoProgress").width() + 100);
        } else {
            document.getElementById("listLaboral").innerHTML = "Sin experiencia laboral";
            
            $('#profileContent').append("Sin experiencia laboral");
            $("#infoProgress").width($("#infoProgress").width() - 100);

        }
    }

    this.GetAcademic = function (data) {
        let start = '';
        let end = '';

        let text2 = '';
        academicList = [];
        if (data.length > 0) {
            academicList = data;
            for (let i in data) {

                start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
                let endIsNull = new Date(data[i].EndDate);
                if (endIsNull.getFullYear() == 1900) {
                    end = "Actualidad";
                } else {
                    end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });

                }
                let btnDownload = "";
                if (data[i].Certificate_File != null && data[i].Certificate_File != "") {
                    btnDownload = `<button class="btn btn-orange my-2" type="button" style="width: 170px;padding: 0 10px;"
                                                onclick="DownlandCertificateAcademic('${data[i].Certificate_File}', '${data[i].Certificate_Name}')">
                                                Descargar Certificado
                                            </button>`;
                } 
                let levelAcademic = "";
                if (data[i].DegreeType == "Universitario") {
                    levelAcademic = data[i].UniversityPreparation + " " + data[i].DegreeType;
                } else {
                    levelAcademic = data[i].DegreeType;
                }

                text2 += `<div class="card-academic">
                               <div class="container">
                                    <div class="row">
                                        <div class="col-lg-1"
                                            style="text-align: center; font-size: 2em; color:#5e5e5e;">
                                            <i class="fa-solid fa-graduation-cap"></i>
                                        </div>
                                        <div class="col-lg-9">
                                            <ul class="unstyled">
                                                <li style="list-style-type: none;">
                                                    ${levelAcademic}
                                                </li>
                                                <li style="list-style-type: none;">
                                                    <strong>${data[i].Institution}</strong>
                                                    <span> ${start} - ${end}</span>
                                                </li>
                                            
                                                <li style="list-style-type: none;">
                                                    ${data[i].Career}
                                                </li>
                                                <li style="list-style-type: none;">
                                                    ${data[i].Status}
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-2">
                                            <button class="btn btn-orange my-2" type="button" data-toggle="modal"
                                                data-target="#editAcademic" style="width: 170px;"
                                                onclick="GetDataAcademic(${data[i].AcademicID})">
                                                Editar
                                            </button>
                                            <button class="btn btn-orange my-2"
                                                style="width: 170px;"
                                                onclick="DeleteAcademic(${data[i].AcademicID})"
                                                >
                                                Eliminar
                                            </button>
                                           ${btnDownload}
                                        </div>
                                    </div>
                                </div>
                            </div>\n
                            <hr style="width:100%;text-align:left;margin-left:0" />\n`;
            }
            document.getElementById("listAcademic").innerHTML = text2;
            $("#infoProgress").width($("#infoProgress").width() + 100);
        } else {
            document.getElementById("listAcademic").innerHTML = "Sin experiencia académica";
            $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        }
    }


    this.GetCourse = function (data) {
        let start = '';
        let end = '';
        let text2 = '';
        courseList = [];
        if (data.length > 0) {
            courseList = data;

        for (let i in data) {
            start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
            let endIsNull = new Date(data[i].EndDate);
            if (endIsNull.getFullYear() == 1900) {
                end = "Actualidad";
            } else {
                end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
            }

            let btnDownload = "";
            if (data[i].Certificate_File != null && data[i].Certificate_File != "") {
                btnDownload = `<button class="btn btn-orange my-2" type="button" style="width: 170px;padding: 0 10px;"
                                                onclick="DownlandCertificateCourse('${data[i].Certificate_File}', '${data[i].Certificate_Name}')">
                                                Descargar Certificado
                                            </button>`;
            }

            text2 += `<div class="card-course">
                           <div class="container">
                                <div class="row">
                                    <div class="col-lg-1"
                                        style="text-align: center; font-size: 2em; color:#5e5e5e;">
                                        <i class="fa-solid fa-graduation-cap"></i>
                                    </div>
                                    <div class="col-lg-9">
                                        <ul class="unstyled">
                                            <li style="list-style-type: none;">
                                                <strong>${data[i].Institution}</strong>
                                                <span> ${start} - ${end}</span>
                                            </li>
                                            <li style="list-style-type: none;">
                                                ${data[i].CourseName}
                                            </li>
                                            <li style="list-style-type: none;">
                                                ${data[i].Status}
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-lg-2">
                                        <button class="btn btn-orange my-2" type="button" data-toggle="modal"
                                            data-target="#editCourse" style="width: 170px;"
                                            onclick="GetDataCourse(${data[i].CourseID})">
                                            Editar
                                        </button>
                                        <button class="btn btn-orange my-2"
                                            style="width: 170px;"
                                            onclick="DeleteCourse(${data[i].CourseID})"
                                            >
                                            Eliminar
                                        </button>
                                            ${btnDownload}
                                    </div>
                                </div>
                            </div>
                        </div>\n
                        <hr style="width:100%;text-align:left;margin-left:0" />\n`;
        }
            document.getElementById("listCourse").innerHTML = text2;
            $("#infoProgress").width($("#infoProgress").width() + 100);
        } else {
            document.getElementById("listCourse").innerHTML = "Sin educación extracurricular";
        $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        }
    }

    this.GetReference = function (data) {
        let text2 = '';
        referenceList = [];
        $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        if (data.length > 0) {
            referenceList = data;
            for (let i in data) {
                text2 += `<div class="card-reference">
                               <div class="container">
                                    <div class="row">
                                        <div class="col-lg-10">
                                            <ul class="unstyled" style="padding: 0;">
                                                <li style="list-style-type: none;">
                                                    ${data[i].ReferrerName}
                                                </li>
                                                <li style="list-style-type: none;">
                                                    ${data[i].Workstation}
                                                </li>
                                                <li style="list-style-type: none;">
                                                    ${data[i].Company}
                                                </li>
                                                <li style="list-style-type: none;">
                                                    ${data[i].Phone}
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-2">
                                            <button class="btn btn-orange my-2" type="button" data-toggle="modal"
                                                data-target="#editReference" style="width: 170px;"
                                                onclick="GetDataReference(${data[i].ReferenceID})">
                                                Editar
                                            </button>
                                            <button class="btn btn-orange my-2"
                                                style="width: 170px;"
                                                onclick="DeleteReference(${data[i].ReferenceID})"
                                                >
                                                Eliminar
                                            </button> 
                                        </div>
                                    </div>
                                </div>
                            </div>\n
                            <hr style="width:100%;text-align:left;margin-left:0" />\n`;
            }
            document.getElementById("listReference").innerHTML = text2;
            $("#infoProgress").width($("#infoProgress").width() + 100);
        }
        else {
            document.getElementById("listReference").innerHTML = "Sin referencias";
            $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        }
    }

    this.GetLanguages = function (data) {
        let text2 = '';
        languageList = [];
        $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        if (data.length > 0) {
            languageList = data;
            for (let i in data) {

                text2 += `<div class="card-language">
                               <div class="container">
                                    <div class="row">
                                        <div class="col-lg-1"
                                            style="text-align: center; font-size: 2em; color:#5e5e5e;">
                                            <i class="fa-solid fa-earth-americas"></i>
                                        </div>
                                        <div class="col-lg-9">
                                            <ul class="unstyled" style="padding: 0;">
                                                <li style="list-style-type: none;">
                                                    <strong>${data[i].LanguageName}</strong>
                                                </li>
                                                <li style="list-style-type: none;">
                                                    ${data[i].Level}
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-2">
                                            <button class="btn btn-orange my-2" type="button" data-toggle="modal"
                                                data-target="#editLanguage" style="width: 170px;"
                                                onclick="GetDataLanguage(${data[i].LanguageID})">
                                                Editar
                                            </button>
                                            <button class="btn btn-orange my-2"
                                                style="width: 170px;"
                                                onclick="DeleteLanguage(${data[i].LanguageID})"
                                                >
                                                Eliminar
                                            </button> 
                                        </div>
                                    </div>
                                </div>
                            </div>\n
                            <hr style="width:100%;text-align:left;margin-left:0" />\n`;
            }
            document.getElementById("listLanguages").innerHTML = text2;
            $("#infoProgress").width($("#infoProgress").width() + 100);
        }
        else {
            document.getElementById("listLanguages").innerHTML = "Sin idiomas";
          //  $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
        }
    }
}
 
function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

function resetFormLaboral() {
    $("#frmAddLaboral")[0].reset();
}
function resetFormAcademic() {
    $("#frmAddAcademic")[0].reset();
    $('input[name="rdDegreeType"][value="Secundaria"').prop("checked", true);

}

function resetFormEditLaboral() {
    $("#frmEditLaboral")[0].reset();
}
function resetFormEditAcademic() {
    $("#frmEditAcademic")[0].reset();
}

function resetFormCourse() {
    $("#frmAddCourse")[0].reset();
}
function resetFormEditCourse() {
    $("#frmEditCourse")[0].reset();
}

function resetFormReference() {
    $("#frmAddReference")[0].reset();
}
function resetFormEditReference() {
    $("#frmEditReference")[0].reset();
}

function resetFormLanguage() {
    $("#frmAddLanguage")[0].reset();
}
function resetFormEditLanguage() {
    $("#frmEditLanguage")[0].reset();
}

function formatDate(date) {
    return ([
        date.getFullYear(),
        padTo2Digits(date.getMonth() + 1),
        padTo2Digits(date.getDate()),
    ].join('-')
    );
}

GetDataLaboral = function (idLaboral) {
    this.ctrlActions = new ControlActions();
    this.student = vStudentAccount();
    if (idLaboral != 'null') {
        this.ctrlActions.GetById("laboral/" + idLaboral, FillDataFormLaboral);
    }
}

FillDataFormLaboral = function (data) {
    document.querySelector('#laboral_token').value = data['LaboralID'];
    document.querySelector('#txtEditWorkPosition').value = data['WorkPosition'];
    document.querySelector('#txtEditWorkstation').value = data['Workstation'];
    document.querySelector('#txtEditCompany').value = data['Company'];
    document.querySelector('#txtEditResponsabilites').value = data['Responsabilites'];
    document.querySelector('#txtEditStartDate').value = formatDateStringMonths(data['StartDate']);
    if (formatDateStringMonths(data['EndDate']) == "1900-01") {
        document.querySelector('#txtEditEndDate').value = "";
    } else {
        document.querySelector('#txtEditEndDate').value = formatDateStringMonths(data['EndDate']);
    }
}

GetDataAcademic = function (idAcademic) {
    this.ctrlActions = new ControlActions();
    this.student = vStudentAccount();
    if (idAcademic != 'null') {
        this.ctrlActions.GetById("academic/" + idAcademic, FillDataFormAcademic);
    }
}

FillDataFormAcademic = function (data) {
    document.querySelector('#academic_token').value = data['AcademicID'];
    $(`input[name="rdDegreeType"][value="${data['DegreeType']}"]`).prop("checked", true);
    if (data['DegreeType'] == "Secundaria") {
        $(".selectedUniversity").hide();
    } else if (data['DegreeType'] == "Universitario") {
        $(".selectedUniversity").show();
    }
    document.querySelector('#txtEditInstitution').value = data['Institution'];
    document.querySelector('#txtEditCareer').value = data['Career'];
    $(`#txtEditStatusAcademic option[value="${data['Status']}"]`).attr("selected", "selected");
    if (data['Status'] == "Finalizado") {
        $('.selectedFinishA').show();
    } else {
        $('.selectedFinishA').hide();
    }
    document.querySelector('#txtEditStartDate').value = formatDateStringMonths(data['StartDate']);
    document.querySelector('#txtEditUniversityPreparation').value = data['UniversityPreparation'];
    if (formatDateStringMonths(data['EndDate']) == "1900-01") {
        document.querySelector('#txtEditEndDateA').value = "";
    } else {
        document.querySelector('#txtEditEndDateA').value = formatDateStringMonths(data['EndDate']);
    }
}

DeleteAcademic = function (idAcademic) {
    this.ctrlActions = new ControlActions();

    let academic = {};
    academic['AcademicID'] = idAcademic;

    this.ctrlActions.DeleteToAPI('academic', academic, function () {
        this.ctrlActions2 = new ControlActions();
        this.student = new vStudentAccount();

        //setTimeout(function redirection() { location.reload; }, 5000);
        this.ctrlActions2.GetById("academic/student/" + $("#txtIdStudent").val(), this.student.GetAcademic);
    });
}

DeleteLaboral = function (idLaboral) {
    this.ctrlActions = new ControlActions();

    let laboral = {};
    laboral['LaboralID'] = idLaboral;

    this.ctrlActions.DeleteToAPI('laboral', laboral, function () {
        this.ctrlActions2 = new ControlActions();
        this.student = new vStudentAccount();

        //setTimeout(function redirection() { location.reload; }, 5000);
        this.ctrlActions2.GetById("laboral/student/" + $("#txtIdStudent").val(), this.student.GetLaboral);
    });
}

GetDataCourse = function (idCourse) {
    this.ctrlActions = new ControlActions();
    this.student = vStudentAccount();
    if (idCourse != 'null') {
        this.ctrlActions.GetById("extracourse/" + idCourse, FillDataFormCourse);
    }
}

FillDataFormCourse = function (data) {
    document.querySelector('#course_token').value = data['CourseID'];
    document.querySelector('#txtEditInstitutionCourse').value = data['Institution'];
    document.querySelector('#txtEditCourseName').value = data['CourseName'];
    $(`#txtEditStatusCourse option[value="${data['Status']}"]`).attr("selected", "selected");
    if (data['Status'] == "Finalizado") {
        $('.selectedFinishC').show();
    } else {
        $('.selectedFinishC').hide();
    }
    document.querySelector('#txtEditStartDateCourse').value = formatDateStringMonths(data['StartDate']);
    if (formatDateStringMonths(data['EndDate']) == "1900-01") {
        document.querySelector('#txtEditEndDateCourse').value = "";
    } else {
        document.querySelector('#txtEditEndDateCourse').value = formatDateStringMonths(data['EndDate']);
    }
}

DeleteCourse = function (idCourse) {
    this.ctrlActions = new ControlActions();

    let course = {};
    course['CourseID'] = idCourse;

    this.ctrlActions.DeleteToAPI('extracourse', course, function () {
        this.ctrlActions2 = new ControlActions();
        this.student = new vStudentAccount();

        //setTimeout(function redirection() { location.reload; }, 5000);
        this.ctrlActions2.GetById("extracourse/student/" + $("#txtIdStudent").val(), this.student.GetCourse);
    });
}

GetDataReference = function (idReference) {
    this.ctrlActions = new ControlActions();
    this.student = vStudentAccount();
    if (idReference != 'null') {
        this.ctrlActions.GetById("reference/" + idReference, FillDataFormReference);
    }
}

FillDataFormReference = function (data) {
    document.querySelector('#reference_token').value = data['ReferenceID'];
    document.querySelector('#txtEditReferrerName').value = data['ReferrerName'];
    document.querySelector('#txtEditWorkstationR').value = data['Workstation'];
    document.querySelector('#txtEditCompanyR').value = data['Company'];
    document.querySelector('#txtEditPhone').value = data['Phone'];
}

DeleteReference = function (idReference) {
    this.ctrlActions = new ControlActions();

    let reference = {};
    reference['ReferenceID'] = idReference;

    this.ctrlActions.DeleteToAPI('reference', reference, function () {
        this.ctrlActions2 = new ControlActions();
        this.student = new vStudentAccount();

        //setTimeout(function redirection() { location.reload; }, 5000);
        this.ctrlActions2.GetById("reference/student/" + $("#txtIdStudent").val(), this.student.GetReference);
    });
}



GetDataLanguage = function (idLanguage) {
    this.ctrlActions = new ControlActions();
    this.student = vStudentAccount();
    if (idLanguage != 'null') {
        this.ctrlActions.GetById("language/" + idLanguage, FillDataFormLanguage);
    }
}

FillDataFormLanguage = function (data) {
    document.querySelector('#language_token').value = data['LanguageID'];
    document.querySelector('#txtEditLanguage').value = data['LanguageName'];
    document.querySelector('#txtEditLevel').value = data['Level'];
}

DeleteLanguage = function (idLanguage) {
    this.ctrlActions = new ControlActions();
    let language = {};
    language['LanguageID'] = idLanguage;
    this.ctrlActions.DeleteToAPI('language', language, function () {
        this.ctrlActions2 = new ControlActions();
        this.student = new vStudentAccount();
        this.ctrlActions2.GetById("language/student/" + $("#txtIdStudent").val(), this.student.GetLanguages);
    });
}

function ChangeInputs(myRadio) {
    if (myRadio.value == "Secundaria") {
        $(".selectedUniversity").hide();
    } else if (myRadio.value == "Universitario" ) {
        $(".selectedUniversity").show();
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


var showCanton = function (selectedProvince) {
    if (selectedProvince == null) {
        selectedProvince = "01"
    }
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
    if (selectedCanton == null) {
        selectedCanton = "01"
    }
    $('#txtDistrict option').hide();
    //$('#txtDistrict').find('option').filter("option[data.pc ^= '" + selectedCanton + "']").show();
    $('#txtDistrict').find(`option[data-parent=${selectedCanton}]`).show()
    //set default value
    var defaultDistrito = "Seleccione un cantón";
    //$('#txtDistrict').val(defaultDistrito);
    $("#txtDistrict").val($("#txtDistrict option:first").val());

};

$(document).ready(function () {
    $(function () {
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

        $('#txtStatusAcademic').change(function () {
            if ($('#txtStatusAcademic').val() == "Finalizado") {
                $('.selectedFinishA').show();
            } else {
                $('.selectedFinishA').hide();
            }
        });

        $('#txtEditStatusAcademic').change(function () {
            if ($('#txtEditStatusAcademic').val() == "Finalizado") {
                $('.selectedFinishA').show();
            } else {
                $('.selectedFinishA').hide();
            }
        });

        $('#txtStatusCourse').change(function () {
            if ($('#txtStatusCourse').val() == "Finalizado") {
                $('.selectedFinishC').show();
            } else {
                $('.selectedFinishC').hide();
            }
        });

        $('#txtEditStatusCourse').change(function () {
            if ($('#txtEditStatusCourse').val() == "Finalizado") {
                $('.selectedFinishC').show();
            } else {
                $('.selectedFinishC').hide();
            }
        });

        $('#txtCountry').change(function () {
            if ($('#txtCountry').val() == "CR") {
                $('.selectedCostaRica').show();
            } else {
                $('.selectedCostaRica').hide();
            }
        });

        $('#txtBirthdate').change(function () {
            $('#txtAge').val(getEdad($('#txtBirthdate').val()));
        });
        RulesValidateCreate();
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

    $("#downloadCV").click(async function () {
        setTimeout(async function () {
            await DowlandCV()
            await $('.bg-gray').css("color", "white");
        }, 2000)
    });

    $("#txtVehicle").change(function () {
        if ($('#txtVehicle').val() == "Sí") {
            $('#chkVehiclesTypes').show();
        } else {
            $('#chkVehiclesTypes').hide();
        }
    });
})

function DownlandCertificateCourse(url, fileName) {
    const anchor = document.createElement("a");
    anchor.href = url;
    anchor.setAttribute("download", fileName);
    anchor.setAttribute('target', '_blank');

    anchor.click();
}


function DownlandCertificateAcademic(url, fileName) {

    const anchor = document.createElement("a");
    anchor.href = url;
    anchor.setAttribute("download", fileName);
    anchor.setAttribute('target', '_blank');

    anchor.click();
}

async function DowlandCV() {
   
    $('.bg-gray').css("color", "black");

    var nameFile = "";
    var doc = new jspdf();
    var studentProfileData;
    if (getCookie('type') == 2) {
        studentProfileData = JSON.parse(getCookie('user'));
        nameFile = studentProfileData["Name"] + ".pdf";
    } else if (getCookie('type') == 1) {
        studentProfileData = dataStudent;
        nameFile = studentProfileData["FirstName"] + " " + studentProfileData["FirstLastName"] + " " + studentProfileData["SecondLastName"] + ".pdf";
    }

    elementHTML = "";
    var laboral = laboralList;
    for (let i in laboral) {
        doc.setFontSize(12);
        doc.setFontType("normal");
        doc.setTextColor(0, 0, 0);

        let dateEnd = formatDateStringMonths(laboral[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        let text = formatDateStringMonths(laboral[i].StartDate) + " - " + dateEnd + "\n" + laboral[i].WorkPosition + " - " +
            laboral[i].Workstation + " - " + laboral[i].Company + "\nResponsabilidades asignadas: " + laboral[i].Responsabilites
        doc.text(20, 60 + (i * 20), text);
    }

    var academic = academicList;
    for (let i in academic) {
        doc.setFontSize(12);
        doc.setFontType("normal");
        doc.setTextColor(0, 0, 0);

        let dateEnd = formatDateStringMonths(academic[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        let text = formatDateStringMonths(academic[i].StartDate) + " - " + dateEnd + "\n" + academic[i].Institution + " - " +
            academic[i].DegreeType + " - " + academic[i].UniversityPreparation + "\n" + academic[i].Status
        doc.text(20, 135 + (i * 20), text);
    }

    var course = courseList;
    for (let i in course) {
        doc.setFontSize(12);
        doc.setFontType("normal");
        doc.setTextColor(0, 0, 0);

        let dateEnd = formatDateStringMonths(course[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        let text = formatDateStringMonths(course[i].StartDate) + " - " + dateEnd + "\n" + course[i].Institution + " - " +
            course[i].CourseName + "\n" + course[i].Status
        doc.text(20, 200 + (i * 20), text);
    }

    var language = languageList;
    for (let i in language) {
        doc.setFontSize(12);
        doc.setFontType("normal");
        doc.setTextColor(0, 0, 0);

        let text = language[i].LanguageName + "\n" + language[i].Level
        doc.text(20, 30 + (i * 15), text);
    }

    var reference = referenceList;
    for (let i in reference) {
        doc.setFontSize(12);
        doc.setFontType("normal");
        doc.setTextColor(0, 0, 0);

        let text = reference[i].ReferrerName + ' - ' + reference[i].Phone + "\n" + reference[i].Company + ' - ' + reference[i].Workstation
        doc.text(20, 90 + (i * 15), text);
    }

    container = document.createElement('div');

    doc.setFontSize(18);
    doc.setTextColor(0, 170, 228);
    doc.setFontType("bold");
    doc.text('CURRICULUM VITAE', 70, 20, { align: 'center' });

    let title = document.createElement('h3');
    title.textContent = "CURRICULUM VITAE";
    title.style.textAlign = 'center';

    let image = document.createElement("img");
    image.src = "../../Content/Logos/Imagotipo Banking Academy 2.png";
    image.width = "50px";

    //clone is required because otherwise you alter the current page.
    let titleInfo = document.createElement('h5');
    titleInfo.textContent = "Información Personal";
    titleInfo.style.textAlign = 'center';
    $("#birthdateText").hide();
    $("#ageText").hide();
    let cloneInfo = document.getElementById("my_info").cloneNode(true);
    $("#birthdateText").show();
    $("#ageText").show();
    let titleProfile = document.createElement('h5');
    titleProfile.textContent = "Perfil Profesional";
    titleProfile.style.textAlign = 'center';

    let cloneProfile = document.getElementById("profileContentContainer").cloneNode(true);
    let titleLaboral = document.createElement('h5');
    titleLaboral.textContent = "Experiencia Laboral";
    titleLaboral.style.textAlign = 'center';
    let titleAcademic = document.createElement('h5');
    titleAcademic.textContent = "Prepación Académica";
    titleAcademic.style.textAlign = 'center';

    let titleCourse = document.createElement('h5');
    titleCourse.textContent = "Educación Extracurricular";
    titleCourse.style.textAlign = 'center';

    let titleLanguage = document.createElement('h5');
    titleLanguage.textContent = "Idiomas";
    titleLanguage.style.textAlign = 'center';

    let titleReference = document.createElement('h5');
    titleReference.textContent = "Referencias";
    titleReference.style.textAlign = 'center';

    containerLaboral = document.createElement('ul');
    var laboral = laboralList;
    for (let i in laboral) {
        let dateEnd = formatDateStringMonths(laboral[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(laboral[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(laboral[i].WorkPosition + " - " + laboral[i].Workstation + " - " + laboral[i].Company);
        p3 = document.createElement('p');
        p3.append("Responsabilidades asignadas: " + laboral[i].Responsabilites);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liLaboral = document.createElement('li');
        liLaboral.append(d1);
        containerLaboral.append(liLaboral);
        containerLaboral.style.margin = "0 30px";
    }

    containerAcademic = document.createElement('ul');
    var academic = academicList;
    for (let i in academic) {
        let dateEnd = formatDateStringMonths(academic[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }
        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(academic[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(academic[i].Institution + " - " +  academic[i].DegreeType + " - " + academic[i].UniversityPreparation);
        p3 = document.createElement('p');
        p3.append(academic[i].Status);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liAcademic = document.createElement('li');
        liAcademic.append(d1);
        containerAcademic.append(liAcademic);
        containerAcademic.style.margin = "0 30px";
    }

    containerCourse = document.createElement('ul');
    var course = courseList;
    for (let i in course) {
        let dateEnd = formatDateStringMonths(course[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(course[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(course[i].Institution + " - " +  course[i].CourseName);
        p3 = document.createElement('p');
        p3.append(course[i].Status);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liCourse = document.createElement('li');
        liCourse.append(d1);
        containerCourse.append(liCourse);
        containerCourse.style.margin = "0 30px";
    }

    containerLanguage = document.createElement('ul');
    var language = languageList;
    for (let i in language) {

        p1 = document.createElement('p');
        p1.append(language[i].LanguageName);
        p2 = document.createElement('p');
        p2.append(language[i].Level);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);

        liLanguage = document.createElement('li');
        liLanguage.append(d1);
        containerLanguage.append(liLanguage);
        containerLanguage.style.margin = "0 30px";
    }

    containerReference = document.createElement('ul');
    var reference = referenceList;
    for (let i in reference) {

        p1 = document.createElement('p');
        p1.append(reference[i].ReferrerName + ' - ' + reference[i].Phone);
        p2 = document.createElement('p');
        p2.append(reference[i].Company + ' - ' + reference[i].Workstation);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);

        liReference = document.createElement('li');
        liReference.append(d1);
        containerReference.append(liReference);
        containerReference.style.margin = "0 30px";
    }

    //remove some css browser might set.
    container.style.margin = '40px 35px';
    container.style.padding = '25px';
    container.style.display = "inline";
    container.style.fontFamily = "arial";
    container.style.fontSize = "12px";
    container.style.lineHeight = "1.2";  //important for knowing break lines.

    //container.append(image);

    var img = document.getElementById("logo");

    container.append(img);
    container.append(title);
    container.append(titleInfo);
    container.append(cloneInfo);
    container.append(titleProfile);
    container.append(cloneProfile);

    if (laboralList.length > 0) {
        container.append(titleLaboral);
        container.append(containerLaboral);
    }

    if (academicList.length > 0) {
        container.append(titleAcademic);
        container.append(containerAcademic);
    }
    if (courseList.length > 0) {
        container.append(titleCourse);
        container.append(containerCourse);
    }

    if (languageList.length > 0) {
        container.append(titleLanguage);
        container.append(containerLanguage);
    }
    if (referenceList.length > 0) {
        container.append(titleReference);
        container.append(containerReference);
    }

    var opt = {
        margin: 2,
        filename: nameFile,
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
    };

    // New Promise-based usage:
    html2pdf(container, opt);
}

