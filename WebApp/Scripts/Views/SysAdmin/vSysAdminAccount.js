function vSysAdminAccount() {
    this.ctrlActions = new ControlActions();
    var SysAdminProfileData = {};
    SysAdminProfileData = getCookie('user');;
    if (SysAdminProfileData != null) {
        SysAdminProfileData = localStorage.getItem('selectedID');
    }

    this.GetData = function () {
        var idSysAdmin = document.getElementById("txtIdSysAdmin").value;
        if (idSysAdmin != 'null') {
            this.ctrlActions.GetById("sysadmin/" + idSysAdmin, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            document.querySelector('#P_UserName').append(data['AdminLogin']);
        }
    }

}


