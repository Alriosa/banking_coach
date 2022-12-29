function vStudentList() {

	this.tblStudentId = 'tblStudent';
	this.ctrlActions = new ControlActions();
	this.service = 'student';
	this.columns = "FirstName,FirstLastName,SecondLastName,IdentificationNumber,Email,BankingStudent,UserActiveStatus";

	this.BindFields = function (data) {
		//window.location.href = "/student/vStudentUpdate/" + data["StudentID"];
		localStorage.setItem('selectedID', data);
	}

	this.RetrieveAll = async function () {
		//await this.ctrlActions.FillTable(this.service, this.tblStudentId, false);
        await this.ctrlActions.GetById('student',async function (data) {
            var t = $('#tblStudent').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay estudiantes registrados",
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
            $('#tblStudent tbody').on('click', 'tr', function () {
                var data = t.row(this).data();
                sessionStorage.setItem('tblStudent_selected', JSON.stringify(data));
            });
            for (let i in data) {
                t.row.add([
                    data[i].FirstName + ' ' + data[i].FirstLastName + ' ' + data[i].SecondLastName,
                    data[i].IdType,
                    data[i].IdentificationNumber,
                    data[i].Email,
                    data[i].BankingStudent,
                    '<select onchange="changeEntity(' + data[i].StudentID + ', selectEntity' + data[i].StudentID + ')"  class="form-select select-tests" id="selectEntity' + data[i].StudentID + '" aria-label="Entidad Bancaria"><option value="0" selected>Ninguna</option></select>',
                    '<select onchange="updateProcessTestEconomic(' + data[i].StudentID + ', selectE' + data[i].StudentID + ')" class="form-select select-tests" id="selectE' + data[i].StudentID + '" aria-label="Pruebas económicas"><option value="0" selected disabled>Seleccione</option ><option value="1" >Aprobó Pruebas Econoómicas</option ><option value="2">Reprobó Pruebas Econoómicas</option></select >' +
                    '<select onchange="updateProcessTestPsychometric(' + data[i].StudentID + ', selectP' + data[i].StudentID + ')"  class="form-select select-tests" id="selectP' + data[i].StudentID + '" aria-label="Pruebas psicométricas"><option value="0" selected disabled>Seleccione</option ><option value="1" >Aprobó Pruebas Psicométricas</option ><option value="2">Reprobó Pruebas Psicométricas</option></select >' +
                    '<select onchange="updateProcessInterview(' + data[i].StudentID + ', selectI' + data[i].StudentID + ')"  class="form-select select-tests" id="selectI' + data[i].StudentID + '" aria-label="Entrevista"><option value="0" selected disabled>Seleccione</option ><option value="1" >Pasó Entrevista</option ><option value="2">No Pasó Entrevista</option></select>' +
                    '<select onchange="updateProcessHiring(' + data[i].StudentID + ', selectH' + data[i].StudentID + ')"  class="form-select select-tests" id="selectH' + data[i].StudentID + '" aria-label="Contratación"><option value="0" selected disabled>Seleccione</option ><option value="1" >Contratado</option ><option value="2">No Se Contrató</option></select >',
                    '<button class="btn btn-primary" style="margin-right: 10px;" onclick="profileStudent(' + data[i].StudentID + ')" id="profileStudent"><i class="fa fa-user"></i></button ><button class="btn btn-danger" id="remove' + data[i].StudentID + '" onclick="removeStudent(' + data[i].StudentID +')"><i class="fa fa-trash"></i></button >',

                ]).draw(false);

                this.ctrlActions2 = new ControlActions();

                this.ctrlActions2.GetById('entity', function (financials) {
                    $(financials).each(function (index, value) {
                        if (value.UserActiveStatus == "Activo") {
                            if (data[i].EntityId == value.EntityUserID ) {
                                $("#selectEntity" + data[i].StudentID).append("<option value=" + value.EntityUserID + " selected> " + value.Name + "</option> ");

                            } else {
                                $("#selectEntity" + data[i].StudentID).append("<option value=" + value.EntityUserID + "> " + value.Name + "</option> ");

                            }
                        }
                    });
                })
                

                let select1 = $("#selectE" + data[i].StudentID);
                if (data[i].StatusEconomicTest == '1') {
                    select1.val('1').attr('selected', 'selected');
                } else if (data[i].StatusEconomicTest == '2') {
                    select1.val('2').attr('selected', 'selected');
                } else {
                    select1.val('0').attr('selected', 'selected');
                }

                let select2 = $("#selectP" + data[i].StudentID);
                if (data[i].StatusPsychometricTest == '1') {
                    select2.val('1').attr('selected', 'selected');
                } else if (data[i].StatusPsychometricTest == '2') {
                    select2.val('2').attr('selected', 'selected');
                } else {
                    select2.val('0').attr('selected', 'selected');
                }

                let select3 = $("#selectI" + data[i].StudentID);
                if (data[i].StatusInterview == '1') {
                    select3.val('1').attr('selected', 'selected');
                } else if (data[i].StatusInterview == '2') {
                    select3.val('2').attr('selected', 'selected');
                } else {
                    select3.val('0').attr('selected', 'selected');
                }

                let select4 = $("#selectH" + data[i].StudentID);
                if (data[i].StatusHired == '1') {
                    select4.val('1').attr('selected', 'selected');
                } else if (data[i].StatusHired == '2') {
                    select4.val('2').attr('selected', 'selected');
                } else {
                    select4.val('0').attr('selected', 'selected');
                }

            }

        });

	} 
	
}

$(document).ready(async function () {
	var studentList = new vStudentList();
	await studentList.RetrieveAll();


	if (getCookie('type') == 3) {
		$('#profileStudent').hide();
		$('#removeStudent').hide();
    }


    $('#tblStudent tbody').on('click', 'tr', function () {

		if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            $('#profileStudent').prop("disabled", true);
            $('#removeStudent').prop("disabled", true);
        } else {
			$('#tblStudent tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $('#profileStudent').prop("disabled", false);
            $('#removeStudent').prop("disabled", false);
            
		}
	});

	$('#removeStudent').click(function (data) {
        var studentData = {};
        studentData["StudentID"] = JSON.parse(sessionStorage.getItem('tblStudent_selected'))[2];
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(studentList.service, studentData, function () {
			var callback = new vStudentList();
		//	callback.ReloadTable();
		});
	});
    $('#addStudent').click(function () {
        window.location.href = "/student/vStudentRegistration";
    });


    $('#profileStudent').click(function () {
		window.location.href = "/student/vStudentAccount/" + localStorage.getItem('selectedID');
	});
});

async function removeStudent() {
    var studentList = new vStudentList();
    await studentList.RetrieveAll();
    var studentData = {};
    studentData["StudentID"] = JSON.parse(sessionStorage.getItem('tblStudent_selected'))[2];
    ctrlActions = new ControlActions();
    ctrlActions.DeleteToAPI(studentList.service, studentData, function () {
        window.location.reload();

    });
};

function profileStudent(selectedID) {
    window.location.href = "/student/vStudentAccount/" + selectedID;

};

function updateProcessTestEconomic(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusEconomicTest'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateTestEconomic', student,
                // setTimeout(function redirection() { window.location.reload() })
            );
        })
}

function updateProcessTestPsychometric(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusPsychometricTest'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateTestPsychometric', student,
                // setTimeout(function redirection() { window.location.reload() })
            );
        })
}


function updateProcessInterview(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusInterview'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateProcessInterview', student,
                //  setTimeout(function redirection() { window.location.reload() })
            );
        })
}


function updateProcessHiring(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusHired'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateStatusHiring', student,
                // setTimeout(function redirection() { window.location.reload() })
            );
        })
}



function changeEntity(studentID, selectId) {
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

    student['EntityId'] = selectId.value;

    //setID Entity to studentData
    this.ctrlActions.PutToAPI('student/recruitStudent', student,
        setTimeout(function redirection() { window.location.reload() }, 5000));
}

