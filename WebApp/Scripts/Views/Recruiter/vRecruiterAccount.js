function vRecruiterAccount() {
    this.ctrlActions = new ControlActions();
    var RecruiterProfileData = {};
    RecruiterProfileData = getCookie('user');
    if (RecruiterProfileData != null) {
        RecruiterProfileData = localStorage.getItem('selectedID');
    
    }

    this.GetData = function () {
        var idRecruiter = document.getElementById("txtIdRecruiter").value;

        if (idRecruiter != 'null') {
            this.ctrlActions.GetById("recruiter/" + idRecruiter, this.FillData);
        }
    }

    this.FillData = function (data) {
    console.log(data);
    }

}


