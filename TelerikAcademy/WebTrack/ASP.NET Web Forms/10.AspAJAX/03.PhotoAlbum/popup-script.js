document.ready((function () {
    debugger;
    $("#form1").on("click", "#Image1", function (ev) {
        debugger;
        var attr = $("#Image1").attr("src");

        window.open(attr, 'Popup', 'toolbar=no, location=yes, status=no, menubar=no,scrollbars=yes,resizable=no, width=500,height=750,left=430,top=23');

    });
})());