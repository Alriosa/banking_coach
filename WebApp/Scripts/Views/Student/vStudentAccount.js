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
          
            this.ctrlActionsInto.BindFields('formEditStudent', data);
            const dateInput = document.getElementById('txtBirthdate');
            dateInput.value = date;

            document.querySelector('#P_WelcomeName').append(data['CompleteName']);

            document.querySelector('#P_LaboralStatus').append(data['LaboralStatus']);
            document.querySelector('#P_Workstation').append(data['Workstation']);
            document.querySelector('#P_Experience').append(data['Experience']);
            document.querySelector('#P_LaboralExperience').append(data['LaboralExperience']);
            document.querySelector('#P_JobAvailability').append(data['JobAvailability']);

            document.querySelector('#P_CompleteName').append(data['CompleteName']);
            document.querySelector('#P_IdentificationNumber').append(data['IdentificationNumber']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_PhoneNumber').append(data['PhoneNumber']);
            document.querySelector('#P_Language').append(data['Language']);
            document.querySelector('#P_DriverLicenses').append(data['DriverLicenses']);
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
        studentData = this.ctrlActions.GetDataForm('formEditStudent');
        studentData["StudentLogin"] = studentLogin;
        studentData["StudentID"] = id;
        this.ctrlActions.PutToAPI('student/', studentData,
            //setTimeout(function redirection() { window.location.href = '/Student/vStudentList/' }, 3000)
        );
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
})
