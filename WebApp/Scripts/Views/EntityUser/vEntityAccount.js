function vEntityAccount() {
    this.ctrlActions = new ControlActions();
    var EntityData = {};
    EntityData = getCookie('user');
    if (EntityData != null) {
        EntityData = localStorage.getItem('selectedID');
    }
  

    this.GetData = function () {
        var idEntity = document.getElementById("txtIdEntity").value;
        if (idEntity != 'null') {
            this.ctrlActions.GetById("entity/" + idEntity, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            document.querySelector('#P_UserName').append(data['EntityLogin']);
        }
    }


}
