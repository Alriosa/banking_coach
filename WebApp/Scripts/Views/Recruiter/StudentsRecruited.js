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
                            '<button title="Modificar Estado de Reclutamiento" type="button" data-toggle="modal" data-target="#statusRecruitment" data-whatever="' + data[i].StudentID + ',' + data[i].FirstName + ' ' + data[i].FirstLastName + ',' + data[i].StatusEconomicTest + ',' + data[i].StatusPsychometricTest + ',' + data[i].StatusInterview + ',' + data[i].StatusHired + ',' + data[i].IdHistoryRecruitment + '"  class="btn btn-success btn-radius"><i class="fa fa-list-check" style="cursor:pointer;"></i></button>',
                            '<button title="Finalizar / Cancelar" onclick="finishProcessRecruitemt(' + data[i].StudentID + ')" type="button" class="btn btn-danger btn-radius"><i class="fa fa-close" style="cursor:pointer;"></i></button>',
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


    this.UpdateStatusRecruitment = function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        var recruitmentData = {};
        recruitmentData = this.ctrlActions.GetDataForm('formStatusRecruitment');
        recruitmentData["StudentID"] = Number(document.getElementById("txtIdStudent").value);
        recruitmentData['StatusEconomicTest'] = Number(document.querySelector('#selectEconomic').value);
        recruitmentData['StatusPsychometricTest'] = Number(document.querySelector('#selectPsychometric').value);
        recruitmentData['StatusInterview'] = Number(document.querySelector('#selectInterview').value);
        recruitmentData['StatusHired'] = Number(document.querySelector('#selectHired').value);
        console.log(recruitmentData)
        let user = JSON.parse(getCookie('user'));

        var historyData = {};
        historyData["Id"] = Number(document.getElementById("txtIdHistory").value);
        historyData["StudentID"] = recruitmentData["StudentID"]
        historyData['StatusEconomic'] = document.querySelector('#selectEconomic').options[document.querySelector('#selectEconomic').selectedIndex].text;
        historyData['StatusPsychometric'] = document.querySelector('#selectPsychometric').options[document.querySelector('#selectPsychometric').selectedIndex].text;
        historyData['StatusInterview'] = document.querySelector('#selectInterview').options[document.querySelector('#selectInterview').selectedIndex].text;
        historyData['StatusHired'] = document.querySelector('#selectHired').options[document.querySelector('#selectHired').selectedIndex].text;
        historyData['Recruiter_User'] = user['UserLogin'];
        historyData['Recruiter_Name'] = user['Name'];
        historyData['Update_Date'] = formatDate(new Date());

        console.log(historyData)

        /*this.ctrlActions.PutToAPI('student/updateStatusRecruitment', recruitmentData, function () {
            //setTimeout(function redirection() { window.location.href = '/Home/vLogin'; }, 5000);
            this.ctrlActions2 = new ControlActions();
            this.student = new StudentsRecruited();
            

            this.ctrlActions2.GetById("language/student/" + languageData["StudentID"], this.student.GetLanguages);
            $('#statusRecruitment').modal('toggle');
        });*/
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


    $('#statusRecruitment').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var identities = button.data('whatever').split(',');  // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text('Estado de Reclutamiento de ' + identities[1])
        modal.find('.modal-body #txtIdStudent').val(Number(identities[0]));
        modal.find('.modal-body #selectEconomic option[value="' + identities[2] + '"]').prop('selected', true);
        modal.find('.modal-body #selectPsychometric option[value="' + identities[3] + '"]').prop('selected', true);
        modal.find('.modal-body #selectInterview option[value="' + identities[4] + '"]').prop('selected', true);
        modal.find('.modal-body #selectHired option[value="' + identities[5] + '"]').prop('selected', true);
        modal.find('.modal-body #txtIdHistory').val(Number(identities[6]));
    })
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
