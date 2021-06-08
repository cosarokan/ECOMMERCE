var categoryCode = null;
var subCategoryCode = null;
var productTypeCode = null;

$(document).ready(function () {
    registerUrlParameters();
    getProductCount();
    getProducts(1);
    registerEvents();
    $('.tooltip-inner').text('');
});

function registerEvents() {
    $('.btn-filter').on('click', function () {
        var checkBrandCheckBoxesIds = $.map($('.brand-checkbox:checked'), function (c) {
            return parseInt(c.id);
        });

        var priceFilter = $('.tooltip-inner').text();
        var minValue = null;
        var maxValue = null;
        if ($('.tooltip-inner').text() != '' && $('.tooltip-inner').text().split(':').length > 1) {
            minValue = parseInt(priceFilter.split(':')[0].trim());
            maxValue = parseInt(priceFilter.split(':')[1].trim());
        }

        debugger;
        var productPropertyValues = new Array();
        $.each($('.product-property-values:checked'), function (i, n) {
            var productPropertyValue =
            {
                Key: parseInt(n.id),
                Value: n.value
            };
            productPropertyValues.push(productPropertyValue);
        });

        var filterModel = {
            BrandIdList: checkBrandCheckBoxesIds,
            PriceMinValue: minValue,
            PriceMaxValue: maxValue,
            ProductProperties: productPropertyValues
        };

        getProductCount(filterModel);
        getProducts(1, filterModel);
    });
}

function registerUrlParameters() {
    var path = window.location.pathname;
    var pathValues = path.split('/');
    if (pathValues.length > 2) {
        categoryCode = pathValues[2];
    }
    if (pathValues.length > 3) {
        subCategoryCode = pathValues[3];
    }
    if (pathValues.length > 4) {
        productTypeCode = pathValues[4];
    }
}

function getProductCount(filterModel) {
    var param = {
        filterModel: filterModel,
        categoryCode: categoryCode,
        subCategoryCode: subCategoryCode,
        productTypeCode: productTypeCode
    };

    $.ajax({
        type: "POST",
        url: "/Product/GetProductsCount",
        contentType: "application/x-www-form-urlencoded",
        dataType: 'json',
        data: param,
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

function getProducts(pageNumber, filterModel) {
    var param = {
        filterModel: filterModel,
        categoryCode: categoryCode,
        subCategoryCode: subCategoryCode,
        productTypeCode: productTypeCode,
        pageNumber: pageNumber
    };

    $.ajax({
        type: "POST",
        url: "/Product/GetProducts",
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
            '<div class="col-sm-4">' +
            '<div class="product-image-wrapper">' +
            '<div class="single-products">' +
            '<div class="productinfo text-center">' +
            '<a href="' + item.url + '"><img class="img-fluid" src="' + item.imageSrc + '" alt="" /></a>' +
            '<h2>' + item.price + ' ' + item.currency + '</h2>' +
            '<p>' + item.brand + ' ' + item.model + '</p>' +
            '<a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Sepete Ekle</a>' +
            '</div>' +
            '</div>' +
            '<div class="choose">' +
            '<ul class="nav nav-pills nav-justified">' +
            '<li><a href="#"><i class="fa fa-plus-square"></i>Favorilere Ekle</a></li>' +
            '<li><a href="#"><i class="fa fa-plus-square"></i>Karşılaştır</a></li>' +
            '</ul>' +
            '</div>' +
            '</div>' +
            '</div>';
    }
    $('#products_area').empty().append(products);
}