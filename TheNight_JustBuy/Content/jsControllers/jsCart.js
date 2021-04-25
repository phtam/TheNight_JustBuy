var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/home";
        });
        $('#btnUpdate-cart').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Bouquet: {
                        BouquetID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });

        $('.btnDelete-item').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });

        $('#btnCoupon').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $("#txtCoupon").val() },
                url: '/Cart/Coupon',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == false) {
                        $("#noticeCoupon").empty().append('<b style="color:red">' + res.notice + '</b>');
                        $("#coupon_apply").empty().append('' + res.total + ' VND');
                    }
                    if (res.status == true) {
                        $("#noticeCoupon").empty().append('<b style="color:green">' +res.notice+ '</b>');
                        $("#coupon_apply").empty().append('' + res.total + ' VND');
                    }
                    
                }
            })
        });


        

        $('.btnLater-item').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Later',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });
    }
}
cart.init();