/// <reference path="libs/require.js" />
require.config({
	paths: {
		jquery: "libs/jquery-2.0.3",
		rsvp: "libs/rsvp.min",
		httpRequester: "libs/http-requester",
		mustache: "libs/mustache"
	}
});

require(["jquery","mustache", "app/data-persister", "app/controls"], function ($, mustache, data, controls) {

    var people = [
  { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" }, 
  { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" },
    { id: 3, name: "Svetlin Nakov", age: 18, avatarUrl: "images/nakov.jpg" }, 
    { id: 4, name: "Nikolay Kostov", age: 18, avatarUrl: "images/niki.jpg" }];

    var comboBox = controls.ComboBox(people);
    var temp = $("#person-template").html();
    var template = mustache.compile(temp);

    var comboBoxHtml = comboBox.render(template);
    $("#container").html(comboBoxHtml);  
});