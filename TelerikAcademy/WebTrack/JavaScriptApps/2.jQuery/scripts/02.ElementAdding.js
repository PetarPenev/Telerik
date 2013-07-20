/// <reference path="jquery-1.10.1.min.js" />

function appendBefore() {
    var selector = $("#selector-input").first().val();
    var element = $("#element-type-input").first().val();
    var newElement = document.createElement(element);
    newElement = $(newElement);
    newElement.html("Appended element");
    newElement.insertBefore($(selector));
}

function appendAfter() {
    var selector = $("#selector-input").first().val();
    var element = $("#element-type-input").first().val();
    var newElement = document.createElement(element);
    newElement = $(newElement);
    newElement.html("Appended element");
    newElement.insertAfter($(selector));
}

// You have to enter the exact CSS selector in order for the task to work (like #list).
$("#button-before").first().on("click", appendBefore);
$("#button-after").first().on("click", appendAfter);