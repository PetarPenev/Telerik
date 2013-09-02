/// <reference path="require.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="rsvp.min.js" />

define(["jquery", "rsvp"], function ($) {
	function getJSON(serviceUrl) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			jQuery.ajax({
				url: serviceUrl,
				type: "GET",
				dataType: "json",
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

	function postJSON(serviceUrl, data) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			jQuery.ajax({
				url: serviceUrl,
				dataType: "json",
				type: "POST",
				contentType: "application/json",
				data: JSON.stringify(data),
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

	function getTemplate(serviceUrl) {
	    var promise = new RSVP.Promise(function (resolve, reject) {
	        var templates = localStorage.getItem(serviceUrl);
	        if (templates != undefined) {
	            resolve(templates[serviceUrl]);
	        }

	        var path = "Scripts/templates/" + serviceUrl;
	        $.get(path, function (data) { resolve(data) });
	    });

	    return promise;
	}

	function putJSON(serviceUrl) {
	    var promise = new RSVP.Promise(function (resolve, reject) {
	        jQuery.ajax({
	            url: serviceUrl,
	            dataType: "json",
	            type: "PUT",
	            contentType: "application/json",
	            success: function (data) {
	                resolve(data);
	            },
	            error: function (err) {
	                reject(err);
	            }
	        });
	    });
	    return promise;
	}

	return {
		getJSON: getJSON,
		postJSON: postJSON,
		putJSON: putJSON,
        getTemplate: getTemplate
	}
});