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
					'<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateEntity(' + data[i].EntityUserID + ')"><i class="fa fa-pen-to-square"></i></button ><button class="btn btn-danger" id="remove' + data[i].EntityUserID + '"  onclick="removeEntity(' + data[i].EntityUserID + ')"><i class="fa fa-trash"></i></button >',

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
	$('#removeEntity').click(function (data) {
		var entityData = {};
		entityData["EntityUserID"] = JSON.parse(sessionStorage.getItem('tblEntity_selected'))['EntityUserID'];
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(entityList.service, entityData, function () {
			window.location.reload();

		});
	});

	$('#updateEntity').click(function () {
		window.location.href = "/EntityUser/vEntityUpdate/" + localStorage.getItem('selectedID');
	});

});


function removeEntity(data) {
	var entityList = new vEntityList();
	entityList.RetrieveAll();

	var entityData = {};
	entityData["EntityUserID"] = data;
	ctrlActions = new ControlActions();
	ctrlActions.DeleteToAPI(entityList.service, entityData, function () {
		var callback = new vEntityList();
		callback.ReloadTable();
	});
};

function updateEntity(data) {
	window.location.href = "/EntityUser/vEntityUpdate/" + data;
};