$('.AddLabel').on('click',
    function () {
        var LabelNumber = $(this).data('value');
        $.each($('.labelTable tr td'),
            function (index, value) {
                if ($(this).find('input[type=checkbox]').is(':checked')) {
                } else {
                    if ($(this).find('.labelSticker').val() == '') {
                        $(this).find('.labelSticker').val(LabelNumber);
                        return false;
                    }
                }
            });
    });

function clearSticker(id) {
    var sheetValue = id.substring(3, 4);
    if (id === 'cbx' + sheetValue) {
        ($('#cbxSheet' + sheetValue).val(''));
    }
}

function clearAll() {
    $('input[type=checkbox]').prop('checked', false);
    $('.labelSticker').val('');
}