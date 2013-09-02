/// <reference path="../libs/jquery-2.0.3.js" />
define(["libs/class", "jquery", "app/data-persister", "mustache"], function (Class, $, data, mustache) {
    var controls = controls || {};

    function getId(el) {
        var element = $(el);
        while (element[0].id == "" || element[0].id == undefined) {
            element = element.parent();
        }

        return element[0].id;
    }

    var Students = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource must be an array!";
            }
            this.itemsSource = itemsSource;
        },

        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                listItem.className = "student";
                listItem.id = this.itemsSource[i].id;
                list.appendChild(listItem);
            }

            var listObject = $(list);
            listObject.on("click", ".student", function (e) {
                $("#container").html("");
                var id = getId(e.target);
                data.marks(id).then(function (dataMarks) {
                    var marks = controls.getMarks(dataMarks);
                    var newTemplate = document.getElementById("mark-template").innerHTML;
                    var marksHtml = marks.render(mustache.compile(newTemplate));
                    $("#container").html(marksHtml);
                });
            });

            return listObject;
        },
    });

    var Marks = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource must be an array!";
            }
            this.itemsSource = itemsSource;
        },

        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }

            var button = $(document.createElement("button"));
            button.html("Show students");
            button.on("click", function () {
                $("#container").html("");
                data.students().then(function (st) {
                    var students = controls.getStudents(st);
                    var studentsHtml = students.render(mustache.compile(document.getElementById("student-template").innerHTML));
                    $("#container").html(studentsHtml);
                }
                );
            });

            var listObject = $(list);
            listObject.append(button);

            return listObject;
        },
    });

	controls.getStudents = function (itemsSource) {
		return new Students(itemsSource);
	}

	controls.getMarks = function (itemsSource) {
	    return new Marks(itemsSource);
	}

	return controls;
});