$(document).ready(function () {
    $("#submit").on('click', function () {
        $("#grid").data('kendoGrid').dataSource.data([]);
        $("#grid").data('kendoGrid').dataSource.read();
    });
});

function onAdditionalData() {
    return {
        text: $("#products").val()
    };
}

function moreData() {
    console.log($("#sampleForm").serializeArray());
    console.log(JSON.parse(JSON.stringify($("#sampleForm").serializeArray())));
   // return { product: { ProductId: $('#ProductId').val(), ProductName: $('#ProductName').val() } };

    var formdata = $("#sampleForm").serializeArray();
    var data = {};
    $(formdata).each(function (index, obj) {
        data[obj.name] = obj.value;
    });

    return { product: data };

}
