function vFinancialList() {

	this.tblFinancialId = 'tblFinancial';
	this.ctrlActions = new ControlActions();
	this.service = 'financial';
	this.columns = "FinancialLogin,UserActiveStatus";


	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["FinancialUserID"]);
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblFinancialId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblFinancialId, true);
	}

}


$(document).ready(function () {

	var financialList = new vFinancialList();
	financialList.RetrieveAll();


	$('#tblFinancial tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblFinancial tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});


	$('#removeEntity').click(function (data) {
		var financialData = {};
		financialData["FinancialUserID"] = localStorage.getItem('selectedID');
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(financialList.service, financialData, function () {
			var callback = new vFinancialList();
			callback.ReloadTable();
		});
	});

	$('#updateEntity').click(function () {
		window.location.href = "/financial/vFinancialUpdate/" + localStorage.getItem('selectedID');
	});

	$('#profileEntity').click(function () {
		window.location.href = "/financial/vFinancialAccount/" + localStorage.getItem('selectedID');
	});
});