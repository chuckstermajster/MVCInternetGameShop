$(function () {
    $('.delete-product').click(function () {
        
        var recordToDelete = $(this).attr('data-id');
        if (recordToDelete != '') {
            $.post("/Cart/DeleteFromCart", { "id": recordToDelete },
                function (response) {
                    if (response.CurrentPostionQuantity == 0) {
                        $('#delete-row-js-' + response.CurrentPositionId).fadeOut('slow');                             
                        $('#total-price').text("Razem: " + response.TotalPrice);
                    }
                    else {
                        $('#cart-position-quantity-' + response.CurrentPositionId).text(response.CurrentPostionQuantity);
                        $('#total-price').text("Razem: " + response.TotalPrice);
                    }
                });

        }
    });
});