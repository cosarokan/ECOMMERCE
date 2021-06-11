$(document).ready(function () {
    $('#btnLogout').on('click', function () {
        logout();
    });
});

var logout = function () {
    $.ajax({
        type: "POST",
        url: "/Login/Logout",
        contentType: "application/x-www-form-urlencoded",
        dataType: 'json',
        success: function (response) {
            if (response.result) {
                window.location.href = window.location.origin;
            }
            else {
                alert("Oturum kapatılırken bir hata oluştu!");
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}