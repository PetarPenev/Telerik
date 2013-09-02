/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="modernizr.custom.94633.js" />
Modernizr.load({
    test: Modernizr.canvas,
    nope: "flashcanvas.js",
    complete: function () {
        var element = document.getElementById("canvas-element");
        if (typeof FlashCanvas != "undefined") {
            FlashCanvas.initElement(element);
        }

        var ctx = element.getContext('2d');
        ctx.fillRect(25, 25, 100, 100);
    }
});