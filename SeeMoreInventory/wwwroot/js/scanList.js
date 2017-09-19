//var Lens = { ProductLabel: '', Sphere: '', CYL: '', Remaining: '', Axis: '', Material: '', Coatings: '', Quantity: '' };
//var productFound = false;
//$(document).ready(function () {
//    $('#ProductLabelText').focus();
//    $('#submit').click(function (e) {
//        if ($('#ProductLabelText').val() === '') {
//            $('#ProductLabelText').focus();
//            e.preventDefault();
//        }
//        else {

//            Lens.ProductLabel = $("#ProductLabelText").val();
//            Lens.Quantity = $("#QTYtext").val();
//            getParams(Lens);

//            if (productFound) {
//                $.ajax({
//                    url: '/Scan',
//                    type: 'POST',
//                    datatype: 'json',
//                    async: false,
//                    contentType: 'application/json; charset=utf-8',
//                    data: JSON.stringify(
//                        {
//                            id: Lens.ProductLabel,
//                            count: Lens.Quantity
//                        }),
//                    success: function (data) {
//                        getParams(Lens);
//                    }
//                });
//                var html = '<div><ul class="ReportRow" >' +
//                    '<li class="col-sm-1"></li>' +
//                    '<li class="col-sm-1">' + Lens.ProductLabel +
//                    '</li><li class="col-sm-1">' + Lens.Sphere +
//                    '</li><li class="col-sm-1">' + Lens.CYL +
//                    '</li><li class="col-sm-1">' + Lens.Axis +
//                    '</li><li class="col-sm-1">' + Lens.Material +
//                    '</li><li class="col-sm-2">' + Lens.Coatings +
//                    '</li><li class="col-sm-1">' + Lens.Quantity +
//                    '</li><li class="col-sm-2">' + Lens.Remaining +
//                    '</li><li class="col-sm-1"></li></ul><hr></div>';
//                $("#scanRows").prepend(html);



//                $("#QTYtext").val(-1);
//                $('#ProductLabelText').val('');
//                $('#ProductLabelText').focus();
//                productFound = false;
//                Lens = { ProductLabel: '', Sphere: '', CYL: '', Remaining: '', Axis: '', Material: '', Coatings: '' };
//            }
//            else {
//                $('#ProductLabelText').val('');
//                $('#ProductLabelText').focus();
//            }
//        }
//    });

//});

//function getParams(Lens) {
//    productFound = false;
//    console.log("In getParams");
//    $.ajax({
//        url: '/GetLensData',
//        async: false,
//        type: 'GET',
//        datatype: 'text',
//        contentType: 'application/json; charset=utf-8',
//        data:
//        {
//            id: Lens.ProductLabel
//        },
//        success: function (data) {
//            if (data.success) {
//                productFound = true;
//                Lens.Axis = data.axis;
//                Lens.CYL = data.cylinder;
//                Lens.Remaining = data.remainingCount;
//                Lens.Sphere = data.sphere;
//                Lens.Material = data.material;
//                Lens.Coatings = data.coatings;
//                console.log(data);
//                return Lens;
//            }
//            else {
//                productFound = false;
//            }
//        }
//    });
//}