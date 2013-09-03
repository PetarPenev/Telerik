window.httpRequester = (function () {
    var rootUrl = "AppScripts/partials/";

    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
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

    function deleteJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "DELETE",
                dataType: "json",
                headers: headers,
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

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
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

    function putJSON(requestUrl, data, headers) {
        debugger;
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    resolve(err);
                }
            });
        });
        return promise;
    }

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            var templates = localStorage.getItem("templates");

            if (templates != null && templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        var templateData = JSON.parse(localStorage.getItem("templates"));
                        if (templateData == null) {
                            templateData = {};
                        }

                        templateData[name] = templateHtml;
                        debugger;
                        localStorage.setItem("templates", JSON.stringify(templateData));
                        var div = localStorage.getItem("templates");
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }


    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON,
        deleteJSON: deleteJSON,
        getTemplate: getTemplate
    }
}());