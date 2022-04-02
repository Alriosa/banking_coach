function vSysAdminList() {

	this.tblSysAdminId = 'tblSysAdmin';
	this.ctrlActions = new ControlActions();
	this.service = 'sysadmin';
	this.columns = "UserName";



	this.BindFields = function (data) {


	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblSysAdminId, false);
	}
	 
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSysAdminId, true);
	}


	
	
$(document).ready(function () {

	var sysAdminList = new vSysAdminList();
	sysAdminList.RetrieveAll();


});

}