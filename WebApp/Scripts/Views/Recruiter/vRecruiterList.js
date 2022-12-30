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
					'<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateRecruiter(' + data[i].RecruiterUserID + ')" id="updateRecruiter"><i class="fa fa-user-edit"></i></button ><button class="btn btn-danger" id="remove' + data[i].RecruiterUserID + ' onclick="removeRecruiter(' + data[i].RecruiterUserID + ')"><i class="fa fa-trash"></i></button >',

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

	

	$('#removeRecruiter').click(function (data) {
		var recruiterData = {};
		recruiterData["RecruiterUserID"] = JSON.parse(sessionStorage.getItem('tblRecruiter_selected'))['RecruiterUserID'];

		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(recruiterList.service, recruiterData, function () {
			var callback = new vRecruiterList();
			callback.ReloadTable();
		});
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


function removeRecruiter(data) {
	var recruiterData = {};
	recruiterData["RecruiterUserID"] = data;

	ctrlActions = new ControlActions();
	ctrlActions.DeleteToAPI(recruiterList.service, recruiterData, function () {
		window.location.reload();

	});
}