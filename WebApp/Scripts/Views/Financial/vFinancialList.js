function vFinancialList() {

	this.tblFinancialId = 'tblFinancial';
	this.ctrlActions = new ControlActions();
	this.service = 'financial';
	this.columns = "FinancialLogin,UserActiveStatus";



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

});