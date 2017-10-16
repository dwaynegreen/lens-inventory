$(document).ready(function () {
    var counter = $('#updateInventory_Count').val();
    $('#plus').click(function () {
        var counter = $('#updateInventory_Count').val();
        counter++;
        $('#updateInventory_Count').val(counter);
    });
    $('#minus').click(function () {
        var counter = $('#updateInventory_Count').val();
        counter--;
        $('#updateInventory_Count').val(counter);
    });
});