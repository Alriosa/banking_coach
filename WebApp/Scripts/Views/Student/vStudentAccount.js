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
            document.querySelector('#P_UserName').append(data['StudentLogin']);
            document.querySelector('#P_Email').append(data['Email']);
            document.querySelector('#P_First_Name').append(data['FirstName']);
            document.querySelector('#P_Second_Name').append(data['SecondName']);
            document.querySelector('#P_Last_Name').append(data['LastName']);
            document.querySelector('#P_Second_Last_Name').append(data['SecondLastName']);
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

            switch (data['Gender'] ) {
                case "M":
                    document.querySelector('#P_Gender').append("Masculino");

                    break
                case "F":
                    document.querySelector('#P_Gender').append("Femenino");

                    break;
            }
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
            }

        }
    }


    
}



