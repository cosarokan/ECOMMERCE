$(document).ready(function () {
    $("#btnPay").click(function () {
        pay();
    });

    $('#chkCities').on('change', function () {
        getDistrictsByCityId($(this).val());
    });

    getDistrictsByCityId(1);
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

var getDistrictsByCityId = function (cityId) {
    var param = { cityId: cityId };

    $.ajax({
        type: "POST",
        url: "/Payment/GetDistrictsByCityId",
        contentType: "application/x-www-form-urlencoded",
        dataType: 'json',
        data: param,
        async: false,
        success: function (response) {
            if (response.data != null && response.data.length > 0) {
                var districtOptions = '';
                for (var i = 0; i < response.data.length; i++) {
                    var district = response.data[i];

                    districtOptions += '<option value="' + district.id + '">' + district.name + '</option>';
                }

                $('#chkDistricts').empty();
                $('#chkDistricts').append(districtOptions);
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}