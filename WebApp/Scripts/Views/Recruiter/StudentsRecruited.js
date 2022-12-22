var students = [];
var languageListStudents = [];

function StudentsRecruited() {

    this.studentRecruitedList = 'studentRecruitedList';
    this.ctrlActions = new ControlActions();
    this.service = 'student';
    this.columns = "FirstName,FirstLastName,IdType,IdentificationNumber,Country,Residence,Licenses,TestEconomic,TestPsychometric";

    this.BindFields = function (data) {
        //window.location.href = "/student/vStudentUpdate/" + data["StudentID"];
        localStorage.setItem('selectedID', data["StudentID"]);
    }

    this.RetrieveStudents = async function () {
        let columns = [];

        let user = JSON.parse(getCookie('user'));

        if (user['UserType'] == '3') {
            this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
                let id = recruiter['EntityAssociation'];
                this.ctrlActions2 = new ControlActions();

                this.ctrlActions2.GetById('student/allInRecruitment/' + id, function (data) {
                    var t = $('#studentRecruitedList').DataTable({
                        language: {
                            "decimal": "",
                            "emptyTable": "No hay estudiantes reclutados",
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

                    for (let i in data) {
                        t.row.add([
                            data[i].FirstName,
                            data[i].FirstLastName,
                            data[i].IdType,
                            data[i].IdentificationNumber,
                            data[i].Country,
                            data[i].NProvince + ", " + data[i].NCanton + ", " + data[i].NDistrict,
                            data[i].DriverLicenses,
                            '<select onchange="updateProcessTestEconomic(' + data[i].StudentID + ', selectE' + data[i].StudentID + ')" class="form-select select-tests" id="selectE' + data[i].StudentID +'" aria-label="Pruebas económicas"><option value="0" selected disabled>Seleccione</option ><option value="1" >Aprobó Pruebas Econoómicas</option ><option value="2">Reprobó Pruebas Econoómicas</option></select >'+
                            '<select onchange="updateProcessTestPsychometric(' + data[i].StudentID + ', selectP' + data[i].StudentID + ')"  class="form-select select-tests" id="selectP' + data[i].StudentID +'" aria-label="Pruebas psicométricas"><option value="0" selected disabled>Seleccione</option ><option value="1" >Aprobó Pruebas Psicométricas</option ><option value="2">Reprobó Pruebas Psicométricas</option></select >'+
                            '<select onchange="updateProcessInterview(' + data[i].StudentID + ', selectI' + data[i].StudentID + ')"  class="form-select select-tests" id="selectI' + data[i].StudentID +'" aria-label="Entrevista"><option value="0" selected disabled>Seleccione</option ><option value="1" >Pasó Entrevista</option ><option value="2">No Pasó Entrevista</option></select>'+
                            '<select onchange="updateProcessHiring(' + data[i].StudentID + ', selectH' + data[i].StudentID + ')"  class="form-select select-tests" id="selectH' + data[i].StudentID +'" aria-label="Contratación"><option value="0" selected disabled>Seleccione</option ><option value="1" >Contratado</option ><option value="2">No Se Contrató</option></select >',
                            '<button onclick="finishProcessRecruitemt(' + data[i].StudentID + ')" type="button" class="btn btn-danger btn-radius"><i class="fa fa-close" style="cursor:pointer;"></i></button>',
                        ]).draw(false);

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

                    students = data;
                });
            })
        }
    }
}

function intersection(first, second) {
    var s = new Set(second);
    var l = first.filter(item => s.has(item));
    return l.length;
};

$(document).ready(function () {

    var table = $('#resultList').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
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
    var students = new StudentsRecruited();
    students.RetrieveStudents();
});

$(document).ready(function () {
    $(function () {
        this.ctrlActions = new ControlActions();

        this.ctrlActions.GetById('language', function (data) {
            languageListStudents = data;
        });
    });
});

function padTo2Digits(num) {
    return num.toString().padStart(2, '0');
}

function formatDate(date) {
    return ([
        date.getFullYear(),
        padTo2Digits(date.getMonth() + 1),
        padTo2Digits(date.getDate()),
    ].join('-')
    );
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function updateProcessTestEconomic(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusEconomicTest'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateTestEconomic', student,
               // setTimeout(function redirection() { window.location.reload() })
            );
        })
    }
}

function updateProcessTestPsychometric(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }
    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusPsychometricTest'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateTestPsychometric', student,
                // setTimeout(function redirection() { window.location.reload() })
            );
        })
    }
}


function updateProcessInterview(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusInterview'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateProcessInterview', student,
                //  setTimeout(function redirection() { window.location.reload() })
            );
        })
    }
}


function updateProcessHiring(studentID, selectId) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            student['StatusHired'] = parseInt(selectId.value);
            this.ctrlActions.PutToAPI('student/updateStatusHiring', student,
                // setTimeout(function redirection() { window.location.reload() })
            );
        })
    }
}

function finishProcessRecruitemt(studentID) {
    let user = JSON.parse(getCookie('user'));
    this.ctrlActions = new ControlActions();
    let student = {
        StudentID: studentID
    }

    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {
            //setID Entity to studentData
            this.ctrlActions.PutToAPI('student/finishRecruitStudent', student,
                setTimeout(function redirection() { window.location.reload() }, 5000));
        })
    }
}
