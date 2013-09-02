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

	data.students()
		.then(function (people) {
			
		    var personTemplateString = $("#student-template").html();

			var template = mustache.compile(personTemplateString);

			var students = controls.getStudents(people);
			var studentsHtml = students.render(template);

			$("#container").html(studentsHtml);

		}, function (err) {
			console.error(err);
		});
});