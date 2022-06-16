function vFinancialAccount() {
    this.ctrlActions = new ControlActions();
    var FinancialData = {};
    FinancialData = getCookie('user');
    if (FinancialData != null) {
        FinancialData = localStorage.getItem('selectedID');
    }
  

    this.GetData = function () {
        var idFinancial = document.getElementById("txtIdFinancial").value;
        if (idFinancial != 'null') {
            this.ctrlActions.GetById("financial/" + idFinancial, this.FillData);
        }
    }

    this.FillData = function (data) {
        if (data != null) {
            document.querySelector('#P_UserName').append(data['FinancialLogin']);
        }
    }


}
