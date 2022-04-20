$(document).ready(function () {
    

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