$(document).ready(function () {
	$(".cart_quantity_down").click(function () {
		var quantityValue = parseInt($('#' + $(this).attr('productId')).val());
		if (quantityValue > 1) {
			quantityValue--;
			$('#' + $(this).attr('productId')).attr("value", quantityValue);
        }
        updateShoppingCart(parseInt($(this).attr('productId')), quantityValue);
	});

	$(".cart_quantity_up").click(function () {
		var quantityValue = parseInt($('#' + $(this).attr('productId')).val());
		if (quantityValue < 100) {
			quantityValue++;
			$('#' + $(this).attr('productId')).attr("value", quantityValue);
        }
        updateShoppingCart(parseInt($(this).attr('productId')), quantityValue);
    });

    $('#btnRemoveFromShoppingCart').on('click', function () {
        removeFromShoppingCart(parseInt($(this).attr('productId')));
    });
});

var updateShoppingCart = function (productId, quantity) {
    var param = { productId: productId, quantity: quantity };

    $.ajax({
        type: "POST",
        url: "/ShoppingCart/UpdateShoppingCart",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        async: false,
        success: function (response) {
            if (response.data) {
                window.location.href = window.location.origin + '/ShoppingCart';
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}

var removeFromShoppingCart = function (productId) {
    var param = { productId: productId };

    $.ajax({
        type: "POST",
        url: "/ShoppingCart/RemoveFromShoppingCart",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        async: false,
        success: function (response) {
            if (response.data) {
                window.location.href = window.location.origin + '/ShoppingCart';
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}