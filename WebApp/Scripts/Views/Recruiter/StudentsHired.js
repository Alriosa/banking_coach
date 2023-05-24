var students = [];
var languageListStudents = [];

function StudentsHired() {

    this.studentsHiredList = 'studentHiredList';
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
                    var t = $('#studentHiredList').DataTable({
                        language: {
                            "decimal": "",
                            "emptyTable": "No hay estudiantes contratados",
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
                        if (data[i].StatusHired == 1) {
                            t.row.add([
                                data[i].FirstName,
                                data[i].FirstLastName,
                                data[i].IdType,
                                data[i].IdentificationNumber,
                                data[i].Country,
                                data[i].NProvince + ", " + data[i].NCanton + ", " + data[i].NDistrict,
                                data[i].DriverLicenses,
                                data[i].DriverLicenses,
                            ]).draw(false);

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
    var students = new StudentsHired();
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

