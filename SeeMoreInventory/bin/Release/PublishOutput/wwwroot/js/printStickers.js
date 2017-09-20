$(document).ready(function () {
    $('.productSelector').click(function () {
        var productId = $(this).data('value');
        alert(productId);
        console.log(productId);
    });
});