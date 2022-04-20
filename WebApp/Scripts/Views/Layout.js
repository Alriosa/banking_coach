$(document).ready(function () {
    
    var user = {};
    user = JSON.parse(getCookie('user'));
    if (user != null) {
        ShowBarLogin();
        HideBarVisit();
    } else {
        ShowBarVisit();
        HideBarLogin();
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