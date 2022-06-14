function vFinancialList() {

	this.tblFinancialId = 'tblFinancial';
	this.ctrlActions = new ControlActions();
	this.service = 'financial';
	this.columns = "FinancialLogin,UserActiveStatuss";


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

	var financialID = localStorage.getItem('selectedID');;

	var table = $('#tblFinancial');

	$('#tblFinancial tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			//table.$('tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});


	$('#removeEntity').click(function (data) {
		var financialData = {};
		financialData["FinancialUserID"] = financialID;
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(financialList.service, financialData, function () {
			var callback = new vFinancialList();
			callback.ReloadTable();
		});
	});

	$('#updateEntity').click(function () {
		window.location.href = "/financial/vFinancialUpdate/" + financialID;
	});

	$('#profileEntity').click(function () {
		window.location.href = "/financial/vFinancialAccount/" + financialID;
	});
});