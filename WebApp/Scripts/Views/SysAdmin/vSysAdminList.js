function vSysAdminList() {

	this.tblSysAdminId = 'tblSysAdmin';
	this.ctrlActions = new ControlActions();
	this.service = 'sysadmin';
	this.columns = "AdminLogin,Name,Email,UserActiveStatus";

	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["SysAdminUserID"]);
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblSysAdminId, false);
	}
	 
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSysAdminId, true);
	}
}

$(document).ready(function () {
	var sysAdminList = new vSysAdminList();
	sysAdminList.RetrieveAll();

	

	$('#tblSysAdmin tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblSysAdmin tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});

	$('#removeAdmin').click(function () {
		var adminData = {};
		adminData["SysAdminUserID"] = localStorage.getItem('selectedID');
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(sysAdminList.service, adminData, function () {
			var callback = new vSysAdminList();
			callback.ReloadTable();
		});
	});

	$('#updateAdmin').click(function (data) {
		window.location.href = "/sysAdmin/vSysAdminUpdate/" + localStorage.getItem('selectedID');;;
		console.log(data);
	});

	$('#profileAdmin').click(function () {
		window.location.href = "/sysAdmin/vSysAdminAccount/" + localStorage.getItem('selectedID');;;
	});
});