function vRecruiterList() {

	this.tblRecruiterId = 'tblRecruiter';
	this.ctrlActions = new ControlActions();
	this.service = 'recruiter';
	this.columns = "RecruiterLogin,FinantialAssociationName,UserActiveStatus";

	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["RecruiterUserID"]);
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblRecruiterId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblRecruiterId, true);
	}
}

$(document).ready(function () {
	var recruiterList = new vRecruiterList();
	recruiterList.RetrieveAll();


	$('#tblRecruiter tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblRecruiter tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});

	$('#removeRecruiter').click(function (data) {
		var recruiterData = {};
		recruiterData["RecruiterUserID"] = localStorage.getItem('selectedID');
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(recruiterList.service, recruiterData, function () {
			var callback = new vRecruiterList();
			callback.ReloadTable();
		});
	});

	$('#updateRecruiter').click(function () {
		window.location.href = "/recruiter/vRecruiterUpdate/" + localStorage.getItem('selectedID');
	});

	$('#profileRecruiter').click(function () {
		window.location.href = "/recruiter/vRecruiterAccount/" + localStorage.getItem('selectedID');
	});
});