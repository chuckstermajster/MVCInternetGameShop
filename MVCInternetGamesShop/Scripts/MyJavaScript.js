﻿//AJAX Removeing from cart without reloading

$(function () {
    $('.delete-product').click(function () {
        
        var recordToDelete = $(this).attr('data-id');
        if (recordToDelete != '') {
            $.post("/Cart/DeleteFromCart", { "id": recordToDelete },
                function (response) {
                    if (response.CurrentPostionQuantity == 0) {
                        $('#delete-row-js-' + response.CurrentPositionId).fadeOut('slow');                             
                        $('#total-price').text("Razem: " + response.TotalPrice);                        
                        $('#items-quantity-js').text("Koszyk (" + response.CurrentItemsInCartQuantity + ")");
                        

                        
                    }
                    else {
                        $('#cart-position-quantity-' + response.CurrentPositionId).text(response.CurrentPostionQuantity);                        
                        $('#total-price').text("Razem: " + response.TotalPrice);
                        $('#items-quantity-js').text("Koszyk (" + response.CurrentItemsInCartQuantity + ")");
                    }
                });

        }
    });

    $('.add-to-cart-js').click(function (e) {
        e.preventDefault();
        var itemToAdd = $(this).attr("data-id");
        $.post("/Cart/AddToCart", {"id": itemToAdd},  function (data) {
            
            
            $('#items-quantity-js').text("Koszyk (" + data + ")");
            
        });
    });
});


    


