function vRecruiterList() {

	this.tblRecruiterId = 'tblRecruiter';
	this.ctrlActions = new ControlActions();
	this.service = 'recruiter';
	this.columns = "RecruiterLogin,Name,Email,EntityAssociationName,UserActiveStatus";

	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["RecruiterUserID"]);
	}

	this.RetrieveAll = async function () {
		//this.ctrlActions.FillTable(this.service, this.tblRecruiterId, false);

		await this.ctrlActions.GetById('recruiter', function (data) {
            var t = $('#tblRecruiter').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay entidades financieras",
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
            $('#tblRecruiter tbody').on('click', 'tr', function () {
                var data = t.row(this).data();
                sessionStorage.setItem('tblRecruiter_selected', JSON.stringify(data));
            });
            for (let i in data) {
                t.row.add([
					data[i].Name,
                    data[i].IdType,
                    data[i].IdentificationNumber,
                    data[i].Email,
                    data[i].EntityAssociationName,
					data[i].UserActiveStatus,
					'<button title="Editar Reclutador" class="btn btn-primary" style="margin-right: 10px;" onclick="updateRecruiter(' + data[i].RecruiterUserID + ')" id="updateRecruiter"><i class="fa fa-user-edit"></i></button ><button ' + (data[i].UserActiveStatus == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + data[i].RecruiterUserID + '" title="' + (data[i].UserActiveStatus == 'Activo' ? 'Desactivar Reclutador' : 'Activar Reclutador') + '"  onclick="changeStatusRecruiter(' + data[i].RecruiterUserID + ',\'' + data[i].UserActiveStatus + '\', this)">' + (data[i].UserActiveStatus == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button >'

                ]).draw(false);

               
            }

        });

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
			$('#updateRecruiter').prop("disabled", true);
			$('#removeRecruiter').prop("disabled", true);
		} else {
			$('#tblRecruiter tr.selected').removeClass('selected');
			$(this).addClass('selected');
			$('#updateRecruiter').prop("disabled", false);
			$('#removeRecruiter').prop("disabled", false);
		}
	});

	

	
	$('#addRecruiter').click(function () {
		window.location.href = "/recruiter/vRecruiterRegistration";
	});

	$('#updateRecruiter').click(function () {
		window.location.href = "/recruiter/vRecruiterUpdate/" + localStorage.getItem('selectedID');
	});

	$('#profileRecruiter').click(function () {
		window.location.href = "/recruiter/vRecruiterAccount/" + localStorage.getItem('selectedID');
	});
});

function updateRecruiter(data) {
	window.location.href = "/recruiter/vRecruiterUpdate/" + data;
};


function removeRecruiter(data, button) {

	var recruiterList = new vRecruiterList();
	var recruiterData = {};
	recruiterData["RecruiterUserID"] = data;
	
	ctrlActions = new ControlActions();
	ctrlActions.DeleteToAPI(recruiterList.service, recruiterData, function () {
		var t = $('#tblRecruiter').DataTable();
		t.row($(button).parents('tr')).remove().draw();
		topFunction()
	});
}


async function changeStatusRecruiter(data, data2, button) {
	var recruiterList = new vRecruiterList();
	var recruiterData = {};
	recruiterData["RecruiterUserID"] = data;
	recruiterData['UserActiveStatus'] = (data2 == 'Activo') ? '0' : '1'
	console.log(recruiterData)

	ctrlActions = new ControlActions();
	ctrlActions.PutToAPI(recruiterList.service + "/changeStatus", recruiterData, function () {
		//window.location.reload();
		var t = $('#tblRecruiter').DataTable();
		var index = t.row($(button).parents('tr')).index();
		var data = t.row($(button).parents('tr')).data();
		data[5] = (recruiterData.UserActiveStatus == '1') ? 'Activo' : 'Inactivo'
		let btnActions = '<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateRecruiter(' + recruiterData.RecruiterUserID + ')" id="updateRecruiter"><i class="fa fa-user-edit"></i></button ><button ' + (data[5] == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + recruiterData.RecruiterUserID + '"  onclick="changeStatusRecruiter(' + recruiterData.RecruiterUserID + ',\'' + data[5] + '\', this)">' + (data[5] == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button >';
		data[6] = btnActions
		t.row(index).data(data).draw();
		topFunction()
	});
};

function topFunction() {
	document.body.scrollTop = 0; // For Safari
	document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}