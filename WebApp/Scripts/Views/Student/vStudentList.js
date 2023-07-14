

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

                btnActions = '<button title="Perfil de estudiante" class="btn btn-primary" style="margin: 5px 6px;width:46px;" onclick="profileStudent(' + data[i].StudentID + ')" id="profileStudent"><i class="fa fa-user"></i></button ><button ' + (data[i].UserActiveStatus == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + data[i].StudentID + '" title="' + (data[i].UserActiveStatus == 'Activo' ? 'Desactivar Estudiante' : 'Activar Estudiante') + '" style="margin: 5px 6px;width:46px;"  onclick="changeStatusStudent(' + data[i].StudentID + ',\'' + data[i].UserActiveStatus + '\',\'' + data[i].Email + '\', this)">' + (data[i].UserActiveStatus == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button ><button class="btn btn-warning" style="margin: 5px 6px;width:46px;" title="Restablecer contraseña" onclick="resetPassword(' + data[i].StudentID + ', \'' + data[i].Email + '\')"  ><i class="fa fa-key"></i></button>';


                 
                btnFinish = (data[i]['EntityName'] == "F_DEFAULT" || data[i]['EntityName'] == "" ? '' : '<button style="cursor:pointer;" class="btn btn-danger" onclick="finishProcessRecruitment(' + data[i].StudentID + ',' + data[i].IdHistoryRecruitment + ')">Ya no trabaja en el banco</button>')


                var newRow = t.row.add([
                    data[i].FirstName + ' ' + data[i].FirstLastName + ' ' + data[i].SecondLastName,
                    data[i].IdType,
                    data[i].IdentificationNumber,
                    data[i].Email,
                    data[i].BankingStudent,
                    '<select onchange="changeEntity(' + data[i].StudentID + ',' + data[i].IdHistoryRecruitment + ', selectEntity' + data[i].StudentID + ')"  class="form-select select-tests" id="selectEntity' + data[i].StudentID + '" aria-label="Entidad Bancaria"><option value="0" selected>Ninguna</option></select >' + btnFinish ,
                    '<select onchange="updateProcessTestEconomic(' + data[i].StudentID + ', selectE' + data[i].StudentID + ')" class="form-select select-tests" id="selectE' + data[i].StudentID + '" aria-label="Pruebas económicas"><option value="0" selected>Sin Realizar Pruebas Económicas</option ><option value="1" >Aprobó Pruebas Económicas</option ><option value="2">Reprobó Pruebas Econoómicas</option></select >' +
                    '<select onchange="updateProcessTestPsychometric(' + data[i].StudentID + ', selectP' + data[i].StudentID + ')"  class="form-select select-tests" id="selectP' + data[i].StudentID + '" aria-label="Pruebas psicométricas"><option value="0" selected>Sin Realizar Pruebas Psicométricas</option ><option value="1" >Aprobó Pruebas Psicométricas</option ><option value="2">Reprobó Pruebas Psicométricas</option></select >' +
                    '<select onchange="updateProcessInterview(' + data[i].StudentID + ', selectI' + data[i].StudentID + ')"  class="form-select select-tests" id="selectI' + data[i].StudentID + '" aria-label="Entrevista"><option value="0" selected>Sin Realizar Entrevista</option ><option value="1" >Pasó Entrevista</option ><option value="2">No Pasó Entrevista</option></select>' +
                    '<select onchange="updateProcessHiring(' + data[i].StudentID + ', selectH' + data[i].StudentID + ')"  class="form-select select-tests" id="selectH' + data[i].StudentID + '" aria-label="Contratación"><option value="0" selected>Seleccione Opción Contratación</option ><option value="1" >Contratado</option ><option value="2">No Se Contrató</option></select >',
                     data[i].UserActiveStatus,
                     btnActions
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

	/*$('#removeStudent').click(function (data) {
        var studentData = {};
        studentData["StudentID"] = JSON.parse(sessionStorage.getItem('tblStudent_selected'))[2];
		ctrlActions = new ControlActions();
		ctrlActions.DeleteToAPI(studentList.service, studentData, function () {
			var callback = new vStudentList();
		//	callback.ReloadTable();
		});
	});*/
    $('#addStudent').click(function () {
        window.location.href = "/student/vStudentRegistration";
    });


    $('#profileStudent').click(function () {
		window.location.href = "/student/vStudentAccount/" + localStorage.getItem('selectedID');
	});
});

async function changeStatusStudent(data, data2, dataEmail, button) {
    var studentList = new vStudentList();
    var studentData = {};
    studentData["StudentID"] = data;

    studentData['UserActiveStatus'] = (data2 == 'Activo') ? '0' : '1'
    console.log(studentData)

    ctrlActions = new ControlActions();
    ctrlActions.PutToAPI(studentList.service + "/changeStatus", studentData, function () {
        //window.location.reload();
        var t = $('#tblStudent').DataTable();
        var index = t.row($(button).parents('tr')).index();
        var data = t.row($(button).parents('tr')).data();
        data[7] = (studentData.UserActiveStatus == '1') ? 'Activo' : 'Inactivo'

        let btnActions = '<button class="btn btn-primary" style="margin: 5px 6px;width:46px;" onclick="profileStudent(' + studentData.StudentID + ')" id="profileStudent"><i class="fa fa-user"></i></button ><button ' + (data[7] == 'Activo' ? 'class="btn btn-danger"' : 'class="btn btn-success"') + ' id="changeStatus' + studentData.StudentID + '" style="margin: 5px 6px;width:46px;" onclick="changeStatusStudent(' + studentData.StudentID + ',\'' + data[7] + '\',\'' + dataEmail + '\', this)">' + (data[7] == 'Activo' ? '<i class="fa fa-eye-slash"></i>' : '<i class="fa fa-eye"></i>') + '</button ><button class="btn btn-warning" style="margin: 5px 6px;width:46px;" title="Restablecer contraseña" onclick="resetPassword(' + studentData.StudentID + ', \'' + dataEmail + '\')"  ><i class="fa fa-key"></i></button>';
        data[8] = btnActions
        t.row(index).data(data).draw();
        topFunction()
    });
};

function profileStudent(selectedID) {
    window.location.href = "/student/vStudentAccount/" + selectedID;

};


function resetPassword(selectedID, email) {
    console.log(selectedID)
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: selectedID,
        Email: email
    }
    this.ctrlActions.PostToAPI('student/resetPassword', student);

    
}

function updateProcessTestEconomic(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusEconomicTest'] = parseInt(selectId.value);
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.PutToAPI('student/updateTestEconomic', student,
                 setTimeout(function redirection() { window.location.reload() })
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
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.PutToAPI('student/updateTestPsychometric', student,
                 setTimeout(function redirection() { window.location.reload() })
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
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.PutToAPI('student/updateProcessInterview', student,
                 setTimeout(function redirection() { window.location.reload() })
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
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.PutToAPI('student/updateStatusHiring', student,
                 setTimeout(function redirection() { window.location.reload() })
            );
        })
}



async function changeEntity(studentID, historyID, selectId) {
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
    let user = JSON.parse(getCookie('user'));
    var historyData = {};

    
    await finishProcessRecruitment(studentID, historyID)

     await this.ctrlActions.GetById('student/' + studentID, async function (student) {
         if (selectId.value != '0') {

             student['EntityId'] = Number(selectId.value);
             student['StatusEconomicTest'] = 0;
             student['StatusPsychometricTest'] = 0;
             student['StatusInterview'] = 0;
             student['StatusHired'] = 0;

             historyData["StudentID"] = student["StudentID"]
             historyData["FirstName"] = student["FirstName"]
             historyData["FirstLastName"] = student["FirstLastName"]
             historyData["SecondLastName"] = student["SecondLastName"]
             historyData["IdType"] = student["IdType"]
             historyData["IdentificationNumber"] = student["IdentificationNumber"]
             historyData['EntityId'] = selectId.value;
             historyData['EntityUser'] = selectId[selectId.value].text
             historyData['RecruiterUser'] = user['UserLogin'];
             historyData['RecruiterName'] = user['Name'];
             historyData['StatusEconomic'] = "Sin realizar";
             historyData['StatusPsychometric'] = "Sin realizar";
             historyData['StatusInterview'] = "Sin realizar";
             historyData['StatusHired'] = "Sin realizar";
             historyData['CreateDate'] = new Date().toLocaleString({ timeZone: 'America/Costa_Rica' });
             historyData['UpdateDate'] = new Date().toLocaleString({ timeZone: 'America/Costa_Rica' });

             this.ctrlActions2 = new ControlActions();
             await this.ctrlActions2.PostToAPI('history/recruited/student/', historyData, async function (history) {
                 student['IdHistoryRecruitment'] = history.Data['Id'];
                 this.ctrlActions3 = new ControlActions();

                 await this.ctrlActions3.PutToAPI('student/recruitStudent', student, async function (data) {
                     this.ctrlActions4 = new ControlActions();
                     await this.ctrlActions4.PutToAPI('student/updateStatusRecruitment', student,
                         setTimeout(function redirection(data) { window.location.reload() }, 5000));

                 });
             })
         } else {
             setTimeout(function redirection() { window.location.reload() }, 5000);
         }
    })
   
}

function topFunction() {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}


async function finishProcessRecruitment(studentID, historyID) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

    var historyData = {};
    historyData["Id"] = historyID;
    historyData["StudentID"] = studentID
    historyData['RecruiterUser'] = user['UserLogin'];
    historyData['RecruiterName'] = user['Name'];
    historyData['FinishDate'] = new Date().toLocaleString({ timeZone: 'America/Costa_Rica' });

    console.log(historyData)
    await this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
        //setID Entity to studentData
        this.ctrlActions2 = new ControlActions();
        
        await this.ctrlActions2.PutToAPI('student/finishRecruitStudent', student);

        await this.ctrlActions2.PutToAPI("history/recruited/student/finish", historyData, function () {
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            setTimeout(function redirection() { window.location.reload() }, 3000)
        });

    });
}