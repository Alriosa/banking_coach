function vStudentList() {

	this.tblStudentId = 'tblStudent';
	this.ctrlActions = new ControlActions();
	this.service = 'student';
	this.columns = "BankingStudent,UserActiveStatus";



	this.BindFields = function (data) {


	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblStudentId, false);
	} 

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblStudentId, true);
	}




	$(document).ready(function () {

		var studentList = new vStudentList();
		studentList.RetrieveAll();


	});

}