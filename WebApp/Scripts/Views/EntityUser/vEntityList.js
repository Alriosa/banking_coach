function vEntityList() {

	this.tblEntityId = 'tblEntity';
	this.ctrlActions = new ControlActions();
	this.service = 'entity';
	this.columns = "Name,Id,Quantity,UserActiveStatus";


	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["EntityUserID"]);
	}

	this.RetrieveAll = async function () {
		//this.ctrlActions.FillTable(this.service, this.tblEntityId, false);

		await this.ctrlActions.GetById('entity', function (data) {
			var t = $('#tblEntity').DataTable({
				language: {
					"decimal": "",
					"emptyTable": "No hay entidades registradas",
					"info": "Mostrando _START_ a _END_ de _TOTAL_ Registros",
					"infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
					"infoFiltered": "(Filtrado de _MAX_ total registros)",
					"infoPostFix": "",
					"thousands": ",",
					"lengthMenu": "Mostrar _MENU_ registros",
					"loadingRecords": "Cargando...",
					"processing": "Procesando...",
					"search": "Buscar:",
					"zeroRecords": "Sin resultados encontrados",
					"paginate": {
						"first": "Primero",
						"last": "Ultimo",
						"next": "Siguiente",
						"previous": "Anterior"
					}
				},
			});
			$('#tblEntity tbody').on('click', 'tr', function () {
				var data = t.row(this).data();
				sessionStorage.setItem('tblEntity_selected', JSON.stringify(data));
			});
			for (let i in data) {
				t.row.add([
					data[i].Name,
					data[i].Id,
					data[i].Quantity,
					data[i].UserActiveStatus,
					'<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateEntity(' + data[i].EntityUserID + ')" id="updateEntity"><i class="fa fa-user-edit"></i></button ><button ' + (data[i].UserActiveStatus == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + data[i].EntityUserID + '"  onclick="changeStatusEntity(' + data[i].EntityUserID + ',\'' + data[i].UserActiveStatus + '\', this)">' + (data[i].UserActiveStatus == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button >'

				]).draw(false);

			}

		});
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
			$('#removeEntity').prop("disabled", true);
			$('#updateEntity').prop("disabled", true);

		} else {
			$('#tblEntity tr.selected').removeClass('selected');
			$(this).addClass('selected');
			$('#removeEntity').prop("disabled", false);
			$('#updateEntity').prop("disabled", false);
		}
	});

	$('#addEntity').click(function () {
		window.location.href = "/EntityUser/vEntityRegistration";
	})


	$('#updateEntity').click(function () {
		window.location.href = "/EntityUser/vEntityUpdate/" + localStorage.getItem('selectedID');
	});

});

function removeEntity(data, button) {
	var entityList = new vEntityList();
	var entityData = {};
	entityData["EntityUserID"] = data;
	ctrlActions = new ControlActions();
	ctrlActions.DeleteToAPI(entityList.service, entityData, function () {
		var t = $('#tblEntity').DataTable();
		t.row($(button).parents('tr')).remove().draw();
		topFunction()
	});
};

async function changeStatusEntity(data, data2, button) {
	var entityList = new vEntityList();
	var entityData = {};
	entityData["EntityUserID"] = data;
	entityData['UserActiveStatus'] = (data2 == 'Activo') ? '0' : '1'
	console.log(entityData)

	ctrlActions = new ControlActions();
	ctrlActions.PutToAPI(entityList.service + "/changeStatus", entityData, function () {
		//window.location.reload();
		var t = $('#tblEntity').DataTable();
		var index = t.row($(button).parents('tr')).index();
		var data = t.row($(button).parents('tr')).data();
		data[3] = (entityData.UserActiveStatus == '1') ? 'Activo' : 'Inactivo'
		let btnActions = '<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateEntity(' + entityData.EntityUserID + ')" id="updateEntity"><i class="fa fa-user-edit"></i></button ><button ' + (data[3] == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + entityData.EntityUserID + '"  onclick="changeStatusEntity(' + entityData.EntityUserID + ',\'' + data[3] + '\', this)">' + (data[3] == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button >';
		data[4] = btnActions
		t.row(index).data(data).draw();
		topFunction()
	});
};

function updateEntity(data) {
	window.location.href = "/EntityUser/vEntityUpdate/" + data;
};

function topFunction() {
	document.body.scrollTop = 0; // For Safari
	document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}