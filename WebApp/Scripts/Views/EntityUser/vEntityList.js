function vEntityList() {

	this.tblEntityId = 'tblEntity';
	this.ctrlActions = new ControlActions();
	this.service = 'entity';
	this.columns = "Name,Id,Quantity,UserActiveStatus";


	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["EntityUserID"]);
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblEntityId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblEntityId, true);
	}

}


$(document).ready(function () {

	var entityList = new vEntityList();
	entityList.RetrieveAll();


	$('#tblEntity tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblEntity tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});


	$('#removeEntity').click(function (data) {
		var entityData = {};
		entityData["EntityUserID"] = localStorage.getItem('selectedID');
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(entityList.service, entityData, function () {
			var callback = new vEntityList();
			callback.ReloadTable();
		});
	});

	$('#updateEntity').click(function () {
		window.location.href = "/EntityUser/vEntityUpdate/" + localStorage.getItem('selectedID');
	});

	$('#profileEntity').click(function () {
		window.location.href = "/EntityUser/vEntityAccount/" + localStorage.getItem('selectedID');
	});
});