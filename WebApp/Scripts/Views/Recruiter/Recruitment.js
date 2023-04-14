
var students = [];
var languageListStudents = [];
var img = document.getElementById("logo");



function Recruitment() {

    this.resultList = 'resultList';
    this.ctrlActions = new ControlActions();
    this.service = 'student';
    this.columns = "FirstName,FirstLastName,IdType,IdentificationNumber,Age,Country,Residence,JobAvailability,Type_Vehicle,Licenses,Sex,Curriculum";


    this.BindFields = function (data) {
        //window.location.href = "/student/vStudentUpdate/" + data["StudentID"];
        localStorage.setItem('selectedID', data["StudentID"]);
    }


    this.RetrieveStudents = async function () {
        let columns = [];

        this.ctrlActions.GetById(this.service, function (data) {
            $('#resultList thead tr')
                .clone(true)
                .addClass('filters')
                .appendTo('#resultList thead');

            var t = $('#resultList').DataTable({
                orderCellsTop: true,
                fixedHeader: true,
                initComplete: function () {
                    var api = this.api();

                    // For each column
                    api
                        .columns()
                        .eq(0)
                        .each(function (colIdx) {
                            // Set the header cell to contain the input element
                            var cell = $('.filters th').eq(
                                $(api.column(colIdx).header()).index()
                            );
                            var title = $(cell).text();
                            $(cell).html('<input type="text" placeholder="' + title + '" />');

                            // On every keypress in this input
                            $(
                                'input',
                                $('.filters th').eq($(api.column(colIdx).header()).index())
                            )
                                .off('keyup change')
                                .on('change', function (e) {
                                    // Get the search value
                                    $(this).attr('title', $(this).val());
                                    var regexr = '({search})'; //$(this).parents('th').find('select').val();

                                    var cursorPosition = this.selectionStart;
                                    // Search the column for that value
                                    api
                                        .column(colIdx)
                                        .search(
                                            this.value != ''
                                                ? regexr.replace('{search}', '(((' + this.value + ')))')
                                                : '',
                                            this.value != '',
                                            this.value == ''
                                        )
                                        .draw();
                                })
                                .on('keyup', function (e) {
                                    e.stopPropagation();

                                    $(this).trigger('change');
                                    $(this)
                                        .focus()[0]
                                        .setSelectionRange(cursorPosition, cursorPosition);
                                });
                        });
                },
                language: {
                    "decimal": "",
                    "emptyTable": "No hay estudiantes disponibles para reclutar",
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
                if (data[i].StatusRecruitment == '0') {
                    t.row.add([
                        data[i].FirstName,
                        data[i].FirstLastName,
                        data[i].IdType,
                        data[i].IdentificationNumber,
                        data[i].Age,
                        data[i].Country,
                        data[i].NProvince + ", " + data[i].NCanton + ", " + data[i].NDistrict,
                        data[i].JobAvailability,
                        data[i].Type_Vehicle,
                        data[i].DriverLicenses,
                        data[i].Sex,
                        '<button class="btn btn-orange" onclick="getData(' + data[i].StudentID + ')"><i class="fas fa-download"></i></button>'
                    ]).draw(false);
                }
            }
            students = data;
        });
    }
}

function intersection(first, second) {
    var s = new Set(second);
    var l = first.filter(item => s.has(item));
    return l.length;
};

$(document).ready(function () {


    var students = new Recruitment();
    students.RetrieveStudents();


 

});

$(document).ready(function () {
    $(function () {

        this.ctrlActions = new ControlActions();
        this.ctrlActions.GetById('student', function (data) {
            students = data;
        });

        this.ctrlActions.GetById('language', function (data) {
            languageListStudents = data;
        });

        var showCanton = function (selectedProvince) {
            $('#txtCanton option').hide();
            //  $('#txtCanton').find('option').filter("option[data ^= '" + selectedProvince + "']").show();
            //$('#txtCanton').find(`option`).hide(); // hide all

            $('#txtCanton').find(`option[data-parent=${selectedProvince}]`).show();

            //set default value
            var defaultCanton = "Seleccione una provincia";
            //  $('#txtCanton').val(defaultCanton);
            $("#txtCanton").val($("#txtCanton option:first").val());

        };

        var showDistrict = function (selectedCanton) {
            $('#txtDistrict option').hide();
            //$('#txtDistrict').find('option').filter("option[data.pc ^= '" + selectedCanton + "']").show();
            $('#txtDistrict').find(`option[data-parent=${selectedCanton}]`).show()
            //set default value
            var defaultDistrito = "Seleccione un cantón";
            //$('#txtDistrict').val(defaultDistrito);
            $("#txtDistrict").val($("#txtDistrict option:first").val());

        };

        //set default provincia
        var province = $('#txtProvince').val();
        showCanton(province);
        $('#txtProvince').change(function () {
            showCanton($(this).val());
        });

        //set default canton
        var canton = $('#txtCanton').val();
        showDistrict(canton);
        $('#txtCanton').change(function () {
            showDistrict($(this).val());
        });

        $('#txtDistrict').change(function () {

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

var laboralList = [];
var academicList = [];
var courseList = [];
var languageList = [];
var referenceList = [];


function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function getData(StudentID) {
    this.ctrlActions = new ControlActions();
    laboralList = [];
    academicList = [];
    courseList = [];
    languageList = [];
    referenceList = [];
    await this.ctrlActions.GetById("laboral/student/" + StudentID, (data) => {
        $('#profileContent').innerHTML = ""

        if (data.length > 0) {
            laboralList = data
            for (let i in data) {
                $('#profileContent').append(data[i].Responsabilites);
                if ((i + 1) < data.length) {
                    $('#profileContent').append(', ');
                }
            }
        } else {
            $('#profileContent').append('Sin experiencia profesional');
        }
    });
    await sleep(1000)
    await this.ctrlActions.GetById("academic/student/" + StudentID, (data) => { academicList = data });
    await sleep(1000)
    await this.ctrlActions.GetById("extracourse/student/" + StudentID, (data) => { courseList = data });
    await this.ctrlActions.GetById("reference/student/" + StudentID, (data) => { referenceList = data });
    await sleep(1000)
    await this.ctrlActions.GetById("language/student/" + StudentID, async (data) => {
        languageList = data
    });
    await sleep(1000)

    let student = {};
    let user = JSON.parse(getCookie('user'));

    if (user['UserType'] == '3') {
        this.ctrlActions.GetById('recruiter/getUser/' + user['UserLogin'], async function (recruiter) {

            this.ctrlActions.PutToAPI('recruiter/addQuantity', recruiter,
                function (response) {
                    if (response) {
                        setTimeout(function () {
                            this.ctrlActions2 = new ControlActions();

                            this.ctrlActions2.GetById('student/' + StudentID, async function (student) {
                                student['EntityId'] = recruiter['EntityAssociation'];

                                var historyData = {};
                                historyData["StudentID"] = student["StudentID"]
                                historyData["FirstName"] = student["FirstName"]
                                historyData["FirstLastName"] = student["FirstLastName"]
                                historyData["SecondLastName"] = student["SecondLastName"]
                                historyData["IdType"] = student["IdType"]
                                historyData["IdentificationNumber"] = student["IdentificationNumber"]
                                historyData['EntityId'] = recruiter['EntityAssociation']
                                historyData['EntityUser'] = recruiter['EntityAssociationName']
                                historyData['RecruiterUser'] = user['UserLogin'];
                                historyData['RecruiterName'] = user['Name'];
                                historyData['StatusEconomic'] = "Sin realizar";
                                historyData['StatusPsychometric'] = "Sin realizar";
                                historyData['StatusInterview'] = "Sin realizar";
                                historyData['StatusHired'] = "Sin realizar";
                                historyData['CreateDate'] = new Date().toLocaleString({ timeZone: 'America/Costa_Rica' });
                                historyData['UpdateDate'] = new Date().toLocaleString({ timeZone: 'America/Costa_Rica' });
                                console.log(historyData)

                                this.ctrlActions3 = new ControlActions();
                                this.ctrlActions3.PostToAPI('history/recruited/student/', historyData, async function (history) {
                                    student['IdHistoryRecruitment'] = history.Data['Id'];
                                    await DowlandCV(student);
                                    await $('.bg-gray').css("color", "white");
                                    
                                })
                            })
                        }, 4000)
                    }
                    else if (response.Data == "error") {
                        console.log(response)
                    }
                }
            )
        })
    } else if (user['UserType'] == '1') {
        setTimeout(function () {
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.GetById('student/' + StudentID, async function (student) {
                await DowlandCV(student);
                await $('.bg-gray').css("color", "white");
            })
        }, 4000)
    }
}

async function DowlandCV(student) {

    let user = JSON.parse(getCookie('user'));

    if (user['UserType'] == '3') {
        setTimeout(function () {
            this.ctrlActions2 = new ControlActions();
            this.ctrlActions2.PutToAPI('student/recruitStudent', student,
                setTimeout(function redirection() { window.location.reload() }, 5000));
        })
    }

    $('.bg-gray').css("color", "black");
    


    let name = student['FirstName'] + ' ' + student['FirstLastName'] + ' ' + student['SecondLastName'];
    document.querySelector('#P_JobAvailability').innerHTML = "";
    document.querySelector('#P_JobAvailability').append(student['JobAvailability']);
    document.querySelector('#P_Id_Type').innerHTML = "";
    document.querySelector('#P_Id_Type').append(student['IdType']);
    document.querySelector('#P_DriverLicenses').innerHTML = "";
    document.querySelector('#P_DriverLicenses').append(student['DriverLicenses']);
    document.querySelector('#P_CompleteName').innerHTML = "";
    document.querySelector('#P_CompleteName').append(name);
    document.querySelector('#P_IdentificationNumber').innerHTML = "";
    document.querySelector('#P_IdentificationNumber').append(student['IdentificationNumber']);
    document.querySelector('#P_Email').innerHTML = "";
    document.querySelector('#P_Email').append(student['Email']);
    document.querySelector('#P_PhoneNumber').innerHTML = "";
    document.querySelector('#P_PhoneNumber').append(student['FirstPhoneNumber']);
    document.querySelector('#P_SecondPhoneNumber').innerHTML = "";
    document.querySelector('#P_SecondPhoneNumber').append(student['SecondPhoneNumber']);
    document.querySelector('#P_Vehicle').innerHTML = "";
    document.querySelector('#P_Vehicle').append(student['Vehicle']);
    document.querySelector('#P_Type_Vehicle').innerHTML = "";
    if (student['Type_Vehicle'] != null && student['Type_Vehicle'] != "") {
        document.querySelector('#P_Type_Vehicle').append("Tipo: " + student['Type_Vehicle']);
    }
    document.querySelector('#P_Location').innerHTML = "";
    document.querySelector('#P_Location').append(student['NProvince'] + ", " + student['NCanton'] + ", " + student['NDistrict']);

    document.querySelector('#P_Country').innerHTML = "";
    document.querySelector('#P_Country').append(student['Country']);
     $('.selectedVehicle').hide();
    if (student['Vehicle'] == "Sí") {
        $('.selectedVehicle').show();
    } else {
        $('.selectedVehicle').hide();
    }
    document.querySelector('#P_BankingStudent').innerHTML = "";
    document.querySelector('#P_BankingStudent').append(student['BankingStudent']);

    var studentProfileData = student;
    var nameFile = studentProfileData["FirstName"] + " " + studentProfileData["FirstLastName"] + " " + studentProfileData["SecondLastName"] + ".pdf";

    container = document.createElement('div');

    let title = document.createElement('h3');
    title.textContent = "CURRICULUM VITAE";
    title.style.textAlign = 'center';

    let image = document.createElement("img");
    image.src = "../../Content/Logos/Imagotipo Banking Academy 2.png";
    image.width = "50px";

    //clone is required because otherwise you alter the current page.
    let titleInfo = document.createElement('h5');
    titleInfo.textContent = "Información Personal";
    titleInfo.style.textAlign = 'center';
    let cloneInfo = document.getElementById("my_info").cloneNode(true);

    let titleProfile = document.createElement('h5');
    titleProfile.textContent = "Perfil Profesional";
    titleProfile.style.textAlign = 'center';

    let cloneProfile = document.getElementById("profileContentContainer").cloneNode(true);
    let titleLaboral = document.createElement('h5');
    titleLaboral.textContent = "Experiencia Laboral";
    titleLaboral.style.textAlign = 'center';
    let titleAcademic = document.createElement('h5');
    titleAcademic.textContent = "Prepación Académica";
    titleAcademic.style.textAlign = 'center';

    let titleCourse = document.createElement('h5');
    titleCourse.textContent = "Educación Extracurricular";
    titleCourse.style.textAlign = 'center';

    let titleLanguage = document.createElement('h5');
    titleLanguage.textContent = "Idiomas";
    titleLanguage.style.textAlign = 'center';

    let titleReference = document.createElement('h5');
    titleReference.textContent = "Referencias";
    titleReference.style.textAlign = 'center';

    containerLaboral = document.createElement('ul');
    var laboral = laboralList;
    for (let i in laboral) {
        let dateEnd = formatDateStringMonths(laboral[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(laboral[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(laboral[i].WorkPosition + " - " + laboral[i].Workstation + " - " + laboral[i].Company);
        p3 = document.createElement('p');
        p3.append("Responsabilidades asignadas: " + laboral[i].Responsabilites);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liLaboral = document.createElement('li');
        liLaboral.append(d1);
        containerLaboral.append(liLaboral);
        containerLaboral.style.margin = "0 30px";
    }

    containerAcademic = document.createElement('ul');
    var academic = academicList;
    for (let i in academic) {
        let dateEnd = formatDateStringMonths(academic[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }
        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(academic[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(academic[i].Institution + " - " + academic[i].DegreeType + " - " + academic[i].UniversityPreparation);
        p3 = document.createElement('p');
        p3.append(academic[i].Status);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liAcademic = document.createElement('li');
        liAcademic.append(d1);
        containerAcademic.append(liAcademic);
        containerAcademic.style.margin = "0 30px";
    }

    containerCourse = document.createElement('ul');
    var course = courseList;
    for (let i in course) {
        let dateEnd = formatDateStringMonths(course[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }

        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(course[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(course[i].Institution + " - " + course[i].CourseName);
        p3 = document.createElement('p');
        p3.append(course[i].Status);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);
        d1.append(p3);

        liCourse = document.createElement('li');
        liCourse.append(d1);
        containerCourse.append(liCourse);
        containerCourse.style.margin = "0 30px";
    }

    containerLanguage = document.createElement('ul');
    var language = languageList;
    for (let i in language) {

        p1 = document.createElement('p');
        p1.append(language[i].LanguageName);
        p2 = document.createElement('p');
        p2.append(language[i].Level);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);

        liLanguage = document.createElement('li');
        liLanguage.append(d1);
        containerLanguage.append(liLanguage);
        containerLanguage.style.margin = "0 30px";
    }

    containerReference = document.createElement('ul');
    var reference = referenceList;
    for (let i in reference) {

        p1 = document.createElement('p');
        p1.append(reference[i].ReferrerName + ' - ' + reference[i].Phone);
        p2 = document.createElement('p');
        p2.append(reference[i].Company + ' - ' + reference[i].Workstation);
        d1 = document.createElement('div');

        d1.append(p1);
        d1.append(p2);

        liReference = document.createElement('li');
        liReference.append(d1);
        containerReference.append(liReference);
        containerReference.style.margin = "0 30px";
    }

    //remove some css browser might set.
    container.style.margin = '40px 35px';
    container.style.padding = '25px';
    container.style.display = "inline";
    container.style.fontFamily = "arial";
    container.style.fontSize = "12px";
    // container.style.color = "#000";
    container.style.lineHeight = "1.2";  //important for knowing break lines.

    //container.append(image);


    container.append(img);
    container.append(title);
    container.append(titleInfo);
    container.append(cloneInfo);
    container.append(titleProfile);
    container.append(cloneProfile);

    if (laboralList.length > 0) {
        container.append(titleLaboral);
        container.append(containerLaboral);
    }

    if (academicList.length > 0) {
        container.append(titleAcademic);
        container.append(containerAcademic);
    }
    if (courseList.length > 0) {
        container.append(titleCourse);
        container.append(containerCourse);
    }

    if (languageList.length > 0) {
        container.append(titleLanguage);
        container.append(containerLanguage);
    }
    if (referenceList.length > 0) {
        container.append(titleReference);
        container.append(containerReference);
    }

    var opt = {
        margin: 2,
        filename: nameFile,
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
    };

    // New Promise-based usage:
    html2pdf(container, opt);
    //html2pdf().set(opt).from(container).save();
}





