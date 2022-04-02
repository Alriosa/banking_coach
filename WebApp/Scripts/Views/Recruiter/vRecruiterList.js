function vRecruiterList() {

	this.tblRecruiterId = 'tblRecruiter';
	this.ctrlActions = new ControlActions();
	this.service = 'recruiter';
	this.columns = "UserName";



	this.BindFields = function (data) {


	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblRecruiterId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblRecruiterId, true);
	}
	 



	$(document).ready(function () {

		var recruiterList = new vRecruiterList();
		recruiterList.RetrieveAll();


	});

}