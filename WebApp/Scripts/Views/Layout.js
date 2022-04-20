$(document).ready(function () {
    
    var user = {};
    user = JSON.parse(getCookie('user'));
    if (user != null) {
        ShowBarLogin();
        HideBarVisit();
        //redirection();
    } else {
        ShowBarVisit();
        HideBarLogin();
        window.location.href = "/Home";
    }


    $("#btnLogout").click(function () {
        LogOut();
    });
});
function LogOut() {
    sessionStorage.clear();
    document.cookie = "user=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "type=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    window.location.href = "/Home"
}

function ShowBarLogin() {
    $("#barLogin").removeClass("d-none");
    $("#barLogin").addClass("d-inline");
}

function HideBarLogin() {
    $("#barLogin").removeClass("d-inline");
    $("#barLogin").addClass("d-none");
}

function ShowBarVisit() {
    $("#barVisit").removeClass("d-none");
    $("#barVisit").addClass("d-inline");
}

function HideBarVisit() {
    $("#barVisit").removeClass("d-inline");
    $("#barVisit").addClass("d-none");
}


function redirection() {
    var control = new ControlActions();

    var user = JSON.parse(getCookie("user"));
    var userLogin = getCookie("type");
    switch (userLogin) {
        case "1":
                window.location.href = "/sysadmin/vSysAdminAccount/" + user["SysAdminUserID"] ;
            break;
        case "2":
                window.location.href = "/student/vStudentAccount/" + user["StudentID"];
            break;
        case "3":
                window.location.href = "/recruiter/vRecruiterAccount/" + user["RecruiterUserID"];
            break;
        case "4":
                window.location.href = "/financial/vFinancialAccount/" + user["FinancialUserID"];
            break;
        default:
            console.log("404");
            break;
    }
};
