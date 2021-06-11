$(document).ready(function () {
    registerEvents();
});

var registerEvents = function () {
    $('#btnSignin').on('click', function () {
        if ($('#txtName').val() == '') {
            alert('İsim zorunlu alan!');
            return;
        }
        if ($('#txtEmail').val() == '') {
            alert('Email zorunlu alan!');
            return;
        }
        if ($('#txtPassword').val() == '') {
            alert('Parola zorunlu alan!');
            return;
        }
        if (!checkEmailAddress($('#txtEmail').val())) {
            alert('Geçerli bir Email adresi girin!');
            return;
        }

        signIn();
    });

    $('#btnLogin').on('click', function () {
        if ($('#txtLoginEmail').val() == '') {
            alert('Email alanını doldurunuz!');
            return;
        }
        if ($('#txtLoginPassword').val() == '') {
            alert('Parola alanını doldurunuz!');
            return;
        }

        if (!checkEmailAddress($('#txtLoginEmail').val())) {
            alert('Geçerli bir Email adresi girin!');
            return;
        }

        login();
    });
}

var signIn = function () {
    var param = { name: $('#txtName').val(), email: $('#txtEmail').val(), password: $('#txtPassword').val() };

    $.ajax({
        type: "POST",
        url: "/Login/SignIn",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        success: function (response) {
            if (!response.isSuccess) {
                alert(response.message);
                return;
            }
            alert("Üyeliğiniz oluşturulmuştur. Mail adresinize gönderilen aktivasyon linkini tıklayarak üyeliğinizi aktif ediniz!");
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}

var login = function () {
    var param = { emailAddress: $('#txtLoginEmail').val(), password: $('#txtLoginPassword').val() };

    $.ajax({
        type: "POST",
        url: "/Login/Login",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        success: function (response) {
            if (response.isSuccess) {
                window.location.href = window.location.origin;
            }
            if (!response.isSuccess) {
                alert(response.message);
                return;
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}

var checkEmailAddress = function (emailAddress) {
    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

    return pattern.test(emailAddress);
}