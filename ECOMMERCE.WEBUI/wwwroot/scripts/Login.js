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
        var userinput = $('#txtEmail').val();
        var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
        if (!pattern.test(userinput)) {
            alert('Geçerli bir Email adresi girin!');
            return;
        }

        var param = { name: $('#txtName').val(), email: $('#txtEmail').val(), password: $('#txtPassword').val() };

        $.ajax({
            type: "POST",
            url: "/Login/SignIn",
            contentType: "application/x-www-form-urlencoded",
            data: param,
            dataType: 'json',
            success: function (response) {
                alert("Üyeliğiniz oluşturulmuştur. Mail adresinize gönderilen aktivasyon linkini tıklayarak üyeliğinizi aktif ediniz!");
            },
            error: function (xhr, err) {
                alert(JSON.parse(xhr.responseText).Message);
            }
        });

    });
}