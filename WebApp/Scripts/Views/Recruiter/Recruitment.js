
var students = [];
var languageListStudents = [];



function Recruitment() {

	this.tblStudentId = 'tblStudent';
	this.ctrlActions = new ControlActions();
	this.service = 'student';
	this.columns = "IdentificationNumber,Email,BankingStudent,UserActiveStatus";


	this.BindFields = function (data) {
		//window.location.href = "/student/vStudentUpdate/" + data["StudentID"];
		localStorage.setItem('selectedID', data["StudentID"]);
	}


	this.RetrieveStudents = function () {
		this.ctrlActions = new ControlActions();
		this.ctrlActions.GetById(this.service, function (data) {
			console.log(data)
			students = data;
        });
      
	}

    this.ReloadResults = function () {
        var searchData = {};
        searchData = this.ctrlActions.GetDataForm('frmSearchStudents');

        $("#results").empty();

        var checkboxes = document.querySelectorAll('input[name=driverLicenses]:checked');
        var values = [];
        for (const value of checkboxes.values()) {
            values.push(value.value);
        }

        var studentsResults = students.filter(x => x.Country == searchData['Country'] || x.Province == searchData['Province'] || x.Canton == searchData['Canton'] || x.District == searchData['District']
            || x.Sex == searchData['Sex'] || languageListStudents.find(l => l.LanguageName == searchData['LanguageName'] || intersection( x["DriverLicenses"].split(", "), values) > 0)

        )
        //var studentsResults = students.filter(x => x["DriverLicenses"].split(", ").retainAll(checkboxes))


        var cantResults = studentsResults.length;
        $('#cant_results').empty();
        $('#cant_results').append(cantResults);
		studentsResults.forEach((s) => {
			var li = document.createElement("li");
            var p = document.createElement("p");
            p.innerHTML = s.FirstName + ' ' + s.FirstLastName + ' ' + s.SecondLastName
            p.style.display = "flex";
            p.style.justifyContent = "space-evenly";


            var downloadBtn = document.createElement("button");
            downloadBtn.innerHTML = 'Descargar';
            downloadBtn.type = 'button';
            downloadBtn.className = "btn btn-orange";
            downloadBtn.addEventListener('click', async function () {
               await getData(s)
            });


            p.appendChild(downloadBtn);
			li.appendChild(p);

			document.querySelector("#results").append(li);
		})
	}
}

function intersection(first, second) {
    var s = new Set(second);
    var l = first.filter(item => s.has(item));
    return l.length;
};

$(document).ready(function () {


    $(function () {

        this.ctrlActions = new ControlActions();
        this.ctrlActions.GetById('student', function (data) {
            console.log(data)
            students = data;
        });

        this.ctrlActions.GetById('language', function (data) {
            console.log(data)
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

async function getData(student) {
    this.ctrlActions = new ControlActions();

    await this.ctrlActions.GetById("laboral/student/" + student.StudentID, (data) => {
        laboralList = data
        for (let i in data) {
            $('#profileContent').append(data[i].Responsabilites);
            if ((i + 1) < data.length) {
                $('#profileContent').append(', ');
            }
        }
    });
    await sleep(1000)
    await this.ctrlActions.GetById("academic/student/" + student.StudentID, (data) => { academicList = data });
    await sleep(1000)
    await this.ctrlActions.GetById("extracourse/student/" + student.StudentID, (data) => { courseList = data });
    await this.ctrlActions.GetById("reference/student/" + student.StudentID, (data) => { referenceList = data });
    await sleep(1000)
    await this.ctrlActions.GetById("language/student/" + student.StudentID, async (data) => {
        languageList = data
        await DowlandCV(student);
        await $('.bg-gray').css("color", "white");
    });
}

async function DowlandCV(student) {

    $('.bg-gray').css("color", "black");

    let name = student['FirstName'] + ' ' + student['FirstLastName'] + ' ' + student['SecondLastName'];

    document.querySelector('#P_JobAvailability').append(student['JobAvailability']);
    document.querySelector('#P_Id_Type').append(student['IdType']);
    document.querySelector('#P_DriverLicenses').append(student['DriverLicenses']);
    document.querySelector('#P_CompleteName').append(name);
    document.querySelector('#P_IdentificationNumber').append(student['IdentificationNumber']);
    document.querySelector('#P_Email').append(student['Email']);
    document.querySelector('#P_PhoneNumber').append(student['FirstPhoneNumber']);
    document.querySelector('#P_SecondPhoneNumber').append(student['SecondPhoneNumber']);
    document.querySelector('#P_Vehicle').append(student['Vehicle']);
    if (student['Type_Vehicle'] != null && student['Type_Vehicle'] != "") {
        document.querySelector('#P_Type_Vehicle').append("Tipo: " + student['Type_Vehicle']);
    }
    document.querySelector('#P_Location').append(student['NProvince'] + ", " + student['NCanton'] + ", " + student['NDistrict']);

    document.querySelector('#P_Country').append(student['Country']);

    document.querySelector('#P_Birthdate').append(formatDate(new Date(student['Birthdate'])));
    document.querySelector('#P_Age').append(student['Age']);

    if (student['Vehicle'] == "Sí") {
        $('.selectedVehicle').show();
    } else {
        $('.selectedVehicle').hide();
    }

    document.querySelector('#P_BankingStudent').append(student['BankingStudent']);

    // getData(student.StudentID);
    


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
    var academic =  academicList;
    for (let i in academic) {
        let dateEnd = formatDateStringMonths(academic[i].EndDate);

        if (dateEnd == "1900-01") {
            dateEnd = "Actualidad";
        }
        p1 = document.createElement('p');
        p1.append(formatDateStringMonths(academic[i].StartDate) + " - " + dateEnd);
        p2 = document.createElement('p');
        p2.append(academic[i].Institution + " - " + academic[i].DegreeType + " - " + academic[i].University_Preparation);
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
    var course =  courseList;
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
    var language =  languageList;
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
    var reference =  referenceList;
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

    var img = document.getElementById("logo");

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
