$(document).ready(function () {
    //var counter = $('#TextBox').val();
    $('#plus').click(function () {
        var counter = $('#QTYtext').val();
        counter++;
        $('#QTYtext').val(counter);
    });
    $('#minus').click(function () {
        var counter = $('#QTYtext').val();
        counter--;
        $('#QTYtext').val(counter);
    });
});