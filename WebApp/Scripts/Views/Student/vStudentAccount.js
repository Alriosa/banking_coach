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
            this.ctrlActions.GetById("academic/student/" + idStudent, this.GetAcademic);
            this.ctrlActions.GetById("extracourse/student/" + idStudent, this.GetCourse);
            this.ctrlActions.GetById("reference/student/" + idStudent, this.GetReference);
            this.ctrlActions.GetById("language/student/" + idStudent, this.GetLanguages);
        }
    }



    this.FillData = function (data) {
        let licences = ["A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2"];
        let cont = -1;
       
        if (data != null) {
            
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
            document.querySelector('#P_DriverLicenses').append(data['DriverLicenses']);
            document.querySelector('#P_CompleteName').append(name);
            document.querySelector('#P_IdentificationNumber').append(data['IdentificationNumber']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_PhoneNumber').append(data['FirstPhoneNumber']);
            document.querySelector('#P_SecondPhoneNumber').append(data['SecondPhoneNumber']);
            //document.querySelector('#P_Language').append(data['Language']);
            document.querySelector('#P_Vehicle').append(data['Vehicle']);
            if (data['Type_Vehicle'] != null){
                document.querySelector('#P_Type_Vehicle').append( data['Type_Vehicle']);

            }

                

            document.querySelector('#P_Country').append(data['Country']);
            document.querySelector('#P_Age').append(data['Age']);



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

        var array = [];

        var checkboxes = document.querySelectorAll('input[name=driverLicenses]:checked');
        for (var i = 0; i < checkboxes.length; i++) {
            array.push(checkboxes[i].value);
        }
        studentData["DriverLicenses"] = array.join(', ');

        this.ctrlActions.PutToAPI('student/', studentData,
            function () {
                /*$('#modalEditInfo').modal('hide');

                setTimeout(function () {
                    window.location.reload();
                }, 3000)*/
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
        var academicData = {};
        academicData = this.ctrlActions.GetDataForm('frmAddAcademic');
        academicData['DegreeType'] = $('input[name="rdDegreeType"]:checked').val();
        academicData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PostToAPI('academic', academicData, function () {
            resetFormAcademic();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
            $('#addAcademic').modal('toggle');
        });
    }

    this.UpdateAcademic = function () {
        var academicData = {};
        academicData = this.ctrlActions.GetDataForm('frmEditAcademic');
        academicData['DegreeType'] = $('input[name="rdDegreeType"]:checked').val();
        academicData['AcademicID'] = document.querySelector('#academic_token').value;
        academicData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PutToAPI('academic', academicData, function () {
            resetFormEditAcademic();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("academic/student/" + academicData["StudentID"], this.student.GetAcademic);
            $('#editAcademic').modal('toggle');
        });
    }


    this.CreateExtraCourse = function () {
        var courseData = {};
        courseData = this.ctrlActions.GetDataForm('frmAddCourse');
        courseData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PostToAPI('extracourse', courseData, function () {
            resetFormCourse();
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            //setTimeout(function redirection() { location.reload; }, 5000);
            this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
            $('#addCourse').modal('toggle');
        });
    }

    this.UpdateExtraCourse = function () {
        var courseData = {};
        courseData = this.ctrlActions.GetDataForm('frmEditCourse');
        courseData['CourseID'] = document.querySelector('#course_token').value;
        courseData["StudentID"] = document.getElementById("txtIdStudent").value;

        this.ctrlActions.PutToAPI('extracourse', courseData, function () {
            resetFormEditCourse();
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new vStudentAccount();

            this.ctrlActions2.GetById("extracourse/student/" + courseData["StudentID"], this.student.GetCourse);
            $('#editCourse').modal('toggle');
        });
    }

    this.CreateReference = function () {
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
        if (data.length > 0) {
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
                                    <div class="col-lg-2">
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
            $("#infoProgress").outerWidth($("#infoProgress").width() - 100);
            $('#profileContent').append("Sin datos");

        }

    }

    this.GetAcademic = function (data) {
        let start = '';
        let end = '';

        let text2 = '';
        if (data.length > 0) {

            for (let i in data) {

                start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
                let endIsNull = new Date(data[i].EndDate);
                if (endIsNull.getFullYear() == 1900) {
                    end = "Actualidad";
                } else {
                    end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });

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
                                                    ${data[i].DegreeType}
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
        if (data.length > 0) {
        for (let i in data) {

            start = new Date(data[i].StartDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
            let endIsNull = new Date(data[i].EndDate);
            if (endIsNull.getFullYear() == 1900) {
                end = "Actualidad";
            } else {
                end = new Date(data[i].EndDate).toLocaleDateString('es-us', { year: "numeric", month: "long" });
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
        if (data.length > 0) {

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
        if (data.length > 0) {

            for (let i in data) {

                text2 += `<div class="card-language">
                               <div class="container">
                                    <div class="row">
                                        <div class="col-lg-10">
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
            $("#infoProgress").outerWidth($("#infoProgress").width() - 100);

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
    document.querySelector('#txtEditInstitution').value = data['Institution'];
    document.querySelector('#txtEditCareer').value = data['Career'];
    $(`#txtEditStatus option[value="${data['Status']}"]`).attr("selected", "selected");
    document.querySelector('#txtEditStartDate').value = formatDateStringMonths(data['StartDate']);
    document.querySelector('#txtEditUniversityPreparation').value = data['UniversityPreparation'];
    if (formatDateStringMonths(data['EndDate']) == "1900-01") {
        document.querySelector('#txtEditEndDate').value = "";
    } else {
        document.querySelector('#txtEditEndDate').value = formatDateStringMonths(data['EndDate']);
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

})

