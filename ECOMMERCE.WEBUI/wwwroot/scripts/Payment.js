$(document).ready(function () {
    $("#btnPay").click(function () {
        pay();
    });
});

var pay = function () {
    $.ajax({
        type: "POST",
        url: "/Payment/Pay",
        contentType: "application/x-www-form-urlencoded",
        dataType: 'json',
        async: false,
        success: function (response) {
            if (response.data) {
                window.location.href = window.location.origin + '/PaymentSuccessful';
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}