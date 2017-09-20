$(document).ready(function () {
    var counter = $('#updateInventory_count').val();
    $('#plus').click(function () {
        var counter = $('#updateInventory_count').val();
        counter++;
        $('#updateInventory_count').val(counter);
    });
    $('#minus').click(function () {
        var counter = $('#updateInventory_count').val();
        counter--;
        $('#updateInventory_count').val(counter);
    });
});