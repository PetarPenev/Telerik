/// <reference path="jquery-1.10.1.min.js" />

// Caution! The input type="color" tag does not work in firefox. Instead, a text input
// field is created. Enter the name of the color (red, yellow, black, etc.) in it to change the background.
function changeBackgroundColor() {
    var colorInput = $("#color-picker").first().val();
    document.body.style.background = colorInput;
}

var colorPicker = document.createElement("input");
colorPicker.type = "color";
colorPicker.id = "color-picker";
colorPicker = $(colorPicker);
colorPicker.on("change", changeBackgroundColor);
var container = $("body");
container.append(colorPicker);