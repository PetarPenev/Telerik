/// <reference path="jquery-2.0.3.min.js" />
/// <reference path="mustache.js" />
/// <reference path="ua-min.js" />
/// <reference path="modernizr.js" />

var parser = new UAParser();
var resultingObject = parser.getResult();
var template = Mustache.compile(document.getElementById("info-template").innerHTML);
var resultingHtml = template(resultingObject);
$("#features-container").html(resultingHtml);

jQuery(function ($) {
    var target = $('#features-table > tbody');

    var traverse = function (object, prefix) {
        prefix = prefix ? prefix + '.' : '';

        for (property in object) {
            if (typeof object[property] == 'object') {
                traverse(object[property], prefix + property);
            } else if (typeof object[property] == 'boolean') {
                var
                    tr = $('<tr />'),
                    name = $('<th />', {
                        text: prefix + property
                    }),
                    value = $('<td />', {
                        text: object[property] ? 'Yes' : 'Nope'
                    });

                target.append(tr.append(name).append(value));
            }
        }
    };

    traverse(Modernizr, 'Modernizr');
});