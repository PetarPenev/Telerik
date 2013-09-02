/// <reference path="../libs/jquery-2.0.3.js" />
define(["libs/class", "jquery", "app/data-persister", "mustache"], function (Class, $, data, mustache) {
    var controls = controls || {};

    function getId(el) {
        var element = $(el);
        while (element[0].id == "" || element[0].id == undefined || element[0].nodeName != "LI") {
            element = element.parent();
        }

        return element[0].id;
    }

    var ComboBox = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource must be an array!";
            }
            this.itemsSource = itemsSource;
            this.isSelected = false;
            this.currentSelectedId = -1;

            var item = $("#event-msg-box");
            item.bind("onCollapsing", function () {
                $("#event-msg-box").append("<p>ComboBox collapsed</p>");
            });

            item.bind("onExpanding", function () {
                $("#event-msg-box").append("<p>ComboBox expanded</p>");
            });

            item.bind("onSelectionChanged", function () {
                $("#event-msg-box").append("<p>Selected item changed.</p>");
            });
        },

        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                listItem.className = "element";
                listItem.id = this.itemsSource[i].id;
                list.appendChild(listItem);
            }

            var listObject = $(list);
            var self = this;
            listObject.on("click", ".element", function (e) {
                var id = getId(e.target);
                var elements;

                if (self.isSelected) {
                    elements = $("#container ul li");
                    for (var i = 0, len = elements.length; i < len; i++) {
                        $(elements[i]).show('slow');
                    }

                    self.isSelected = false;
                    var msgBox = $("#message-state");
                    msgBox.html("Combo element not selected.");
                    msgBox.removeClass("selected");
                    msgBox.addClass("unselected");
                    $("#event-msg-box").trigger("onExpanding");
                    if (id != self.currentSelectedId) {
                        $("#event-msg-box").trigger("onSelectionChanged");
                    }

                    self.currentSelectedId = id;
                }
                else {
                    elements = $("#container ul li");
                    for (var i = 0, len = elements.length; i < len; i++) {
                        if (elements[i].id == id) {
                            $(elements[i]).show('slow');
                        }
                        else {
                            $(elements[i]).hide('slow');
                        }
                    }

                    self.isSelected = true;
                    var msgBox = $("#message-state");
                    msgBox.html("Combo element selected.");
                    msgBox.removeClass("unselected");
                    msgBox.addClass("selected");
                    $("#event-msg-box").trigger("onCollapsing");
                    if (id != self.currentSelectedId) {
                        $("#event-msg-box").trigger("onSelectionChanged");
                    }

                    self.currentSelectedId = id;
                }
            });

            $("#message-state").html("Combo element not selected.");
            return listObject;
        },
    });

	controls.ComboBox = function (itemsSource) {
		return new ComboBox(itemsSource);
	}

	return controls;
});