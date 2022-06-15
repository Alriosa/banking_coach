function vStudentList() {

	this.tblStudentId = 'tblStudent';
	this.ctrlActions = new ControlActions();
	this.service = 'student';
	this.columns = "IdentificationNumber,Email,BankingStudent,UserActiveStatus";

	this.BindFields = function (data) {
		//window.location.href = "/student/vStudentUpdate/" + data["StudentID"];
		localStorage.setItem('selectedID', data["StudentID"]);
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblStudentId, false);
	} 

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblStudentId, true);
	}




	
}

$(document).ready(function () {
	var studentList = new vStudentList();
	studentList.RetrieveAll();
	var studentID = localStorage.getItem('selectedID');
}


	$('#tblStudent tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblStudent tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});

	$('#removeStudent').click(function (data) {
		var studentData = {};
		studentData["StudentID"] = studentID;
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(studentList.service, studentData, function () {
			var callback = new vStudentList();
			callback.ReloadTable();
		});
	});

	$('#updateStudent').click(function () {
		window.location.href = "/student/vStudentUpdate/" + studentID;
	});

	$('#ProfileStudent').click(function () {
		window.location.href = "/student/vStudentUpdate/" + studentID;
	});
});


