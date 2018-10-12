// Write your Javascript code.
window.onload = function () {
    document.getElementById("filterByDetails").focus();
};

(function ($) {
    $.fn.jScroll = function (e) {
        var f = $.extend({}, $.fn.jScroll.defaults, e);
        return this.each(function () {
            var a = $(this);
            var b = $(window);
            var c = new location(a);
            b.scroll(function() {
                a.stop().animate(c.getMargin(b), f.speed);
            });
        }); function location(d) {
            this.min = d.offset().top;
            this.originalMargin = parseInt(d.css("margin-top"), 10) || 0;
            this.getMargin = function(a) {
                var b = d.parent().height() - d.outerHeight();
                var c = this.originalMargin;
                if (a.scrollTop() >= this.min) c = c + f.top + a.scrollTop() - this.min;
                if (c > b) c = b;
                return ({ "marginTop": c + 'px' });
            };
        }
    };
    $.fn.jScroll.defaults = { speed: "slow", top: 10 };
})(jQuery);

$(function () {
    $(".scroll").jScroll();
});

$('#filterByDetails').on('click', function () {
    event.preventDefault();
    FilterTable();
});

function FilterTable() {
    var table = $('.inventoryTable');
    var tr = $('.inventoryRow');

    var SphereFilter = $('#sphereFilter').val();
    var CylinderFilter = $('#cylinderFilter').val();
    var ARFilter = $('#arcbx').is(":checked");
    var TransitionFilter = $('#trcbx').is(":checked");

    $.each(tr, function (i, val) {
        var td = tr[i].getElementsByTagName("td")[0];

        if (td) {
            tr[i].style.display = "";

            if (ARFilter && tr[i].getElementsByTagName("td")[4].innerText === "None") {
                tr[i].style.display = "none";
            }

            if (TransitionFilter && tr[i].getElementsByTagName("td")[5].innerText === "No") {
                tr[i].style.display = "none";
            }

            if (SphereFilter != "" && tr[i].getElementsByTagName("td")[1].innerText != SphereFilter) {
                tr[i].style.display = "none";
            }
            
            if (CylinderFilter != "" && tr[i].getElementsByTagName("td")[2].innerText != CylinderFilter) {
                tr[i].style.display = "none";
            }
        }
    });
}