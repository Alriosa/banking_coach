function vSysAdminList() {

	this.tblSysAdminId = 'tblSysAdmin';
	this.ctrlActions = new ControlActions();
	this.service = 'sysadmin';
	this.columns = "AdminLogin,Name,Email,UserActiveStatus";

	this.BindFields = function (data) {
		localStorage.setItem('selectedID', data["SysAdminUserID"]);
	}

	this.RetrieveAll = async function () {
		//this.ctrlActions.FillTable(this.service, this.tblSysAdminId, false);
		await this.ctrlActions.GetById('sysadmin', function (data) {
			var t = $('#tblSysAdmin').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay administradores registrados",
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
			$('#tblSysAdmin tbody').on('click', 'tr', function () {
                var data = t.row(this).data();
				sessionStorage.setItem('tblSysAdmin_selected', JSON.stringify(data));
            });
            for (let i in data) {
                t.row.add([
                    data[i].Name,
                    data[i].IdType,
                    data[i].IdentificationNumber,
					data[i].Email,
					data[i].UserActiveStatus,
					'<button class="btn btn-primary" style="margin-right: 10px;" onclick="updateAdmin(' + data[i].SysAdminUserID + ')" id="updateAdmin"><i class="fa fa-user-edit"></i></button ><button class="btn btn-danger" id="changeStatus' + data[i].SysAdminUserID + '"  onclick="changeStatusAdmin(' + data[i].SysAdminUserID + ',\'' + data[i].UserActiveStatus + '\', this)"><i class="fa fa-eye"></i></button >',

                ]).draw(false);

            }

        });
	}
	 
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSysAdminId, true);
	}
}

$(document).ready(function () {
	var sysAdminList = new vSysAdminList();
	sysAdminList.RetrieveAll();

	

	$('#tblSysAdmin tbody').on('click', 'tr', function () {
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
		} else {
			$('#tblSysAdmin tr.selected').removeClass('selected');
			$(this).addClass('selected');
		}
	});

	
	$('#addAdmin').click(function () {
		window.location.href = "/sysAdmin/vSysAdminRegistration";
	})
	$('#updateAdmin').click(function (data) {
		window.location.href = "/sysAdmin/vSysAdminUpdate/" + localStorage.getItem('selectedID');;;
	});

	$('#profileAdmin').click(function () {
		window.location.href = "/sysAdmin/vSysAdminAccount/" + localStorage.getItem('selectedID');;;
	});
});

function updateAdmin(data) {
	window.location.href = "/sysAdmin/vSysAdminUpdate/" + data;
};

function removeAdmin(data, button) {

	var sysAdminList = new vSysAdminList();
	var adminData = {};
	adminData["SysAdminUserID"] = data;
	ctrlActions = new ControlActions();
	ctrlActions.DeleteToAPI(sysAdminList.service, adminData, function () {
		var t = $('#tblSysAdmin').DataTable();
		t.row($(button).parents('tr')).remove().draw();
		topFunction()
	});
};


async function changeStatusAdmin(data, data2, button) {
	var sysAdminList = new vSysAdminList();
	var adminData = {};
	adminData["SysAdminUserID"] = data;
	adminData['UserActiveStatus'] = (data2 == 'Activo') ? '0' : '1'
	console.log(adminData)

	ctrlActions = new ControlActions();
	ctrlActions.PutToAPI(sysAdminList.service + "/changeStatus", adminData, function () {
		//window.location.reload();
		var t = $('#tblSysAdmin').DataTable();
		var index = t.row($(button).parents('tr')).index();
		var data = t.row($(button).parents('tr')).data();
		data[4] = (adminData.UserActiveStatus == '1') ? 'Activo' : 'Inactivo'
		data[5] = data[5].replace(/Activo|Inactivo/g, data[4]);
		t.row(index).data(data).draw();
		topFunction()
	});
};


function topFunction() {
	document.body.scrollTop = 0; // For Safari
	document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}