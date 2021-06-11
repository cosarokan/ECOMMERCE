$(document).ready(function () {
    getProductCount();
    getProducts(1);
});

function getProductCount() {
    $.ajax({
        type: "POST",
        url: "/Home/GetProductsCount",
        contentType: "application/x-www-form-urlencoded",
        dataType: 'json',
        success: function (response) {
            $('#pagination').off('bootpag').bootpag({
                total: (parseInt(response.data % itemsPerPage) == 0) ? (parseInt(response.data / itemsPerPage)) : (parseInt(response.data / itemsPerPage) + 1),
                page: 1,
                leaps: true,
                maxVisible: (parseInt(response.data / itemsPerPage)) < 5 ? (parseInt(response.data % itemsPerPage) == 0) ? parseInt(response.data / itemsPerPage) : (parseInt(response.data / itemsPerPage) + 1) : 5
            }).off('page').on('page', function (event, num) {
                getProducts(num);
            });
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}

function getProducts(pageNumber) {
    var param = { pageNumber: pageNumber };

    $.ajax({
        type: "POST",
        url: "/Home/GetProducts",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        success: function (response) {
            buildProducts(response.data);
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}

function buildProducts(data) {
    var products = '';
    for (var i = 0; i < data.length; i++) {
        var item = data[i];
        products +=
            '<div class="col-sm-4">'+
                '<div class="product-image-wrapper">'+
                    '<div class="single-products">'+
                        '<div class="productinfo text-center">'+
                            '<a href="' + item.url + '"><img class="img-fluid" src="' +item.imageSrc+ '" alt="" /></a>'+
                            '<h2>' + item.price + ' ' + item.currency +'</h2>'+
                            '<p>' + item.brand + ' ' +  item.model +'</p>'+
                            '<a class="btn btn-default add-to-cart" id="' + item.id + '"><i class="fa fa-shopping-cart"></i>Sepete Ekle</a>'+
                        '</div>'+
                    '</div>'+
                    '<div class="choose">'+
                        '<ul class="nav nav-pills nav-justified">'+
                        '</ul>'+
                    '</div>'+
                '</div>'+
            '</div>';
    }
    $('#products_area').empty().append(products);

    $('.add-to-cart').on('click', function () {
        addToShoppingCart($(this).attr('id'));
    });
}

var addToShoppingCart = function (productId) {
    var param = { productId: productId };

    $.ajax({
        type: "POST",
        url: "/Product/AddToShoppingCart",
        contentType: "application/x-www-form-urlencoded",
        data: param,
        dataType: 'json',
        success: function (response) {
            if (response.data) {
                alert('Ürün sepetinize eklenmiştir.');
            }
        },
        error: function (xhr, err) {
            alert(JSON.parse(xhr.responseText).Message);
        }
    });
}