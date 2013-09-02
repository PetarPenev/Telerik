define(["jquery", "persister", "crypto", "mustache", "request"], function ($, persister, crypto, mustache, request) {
    function buildLoginForm() {
        var html =
            '<div id="login-form-holder">' +
				'<form>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="text" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="text" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-login" class="button selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="button">Register</a>' +
				'</form>' +
				'<div id="error-messages"></div>' +
            '</div>';

        return html;
    }

    function attachUIEventHandlers(selector, errSelector) {
        var wrapper = $(selector);
        var errContainer = $(errSelector);
        var self = this;

        wrapper.on("click", "#btn-show-login", function () {
            wrapper.find(".button.selected").removeClass("selected");
            $(this).addClass("selected");
            wrapper.find("#login-form").show();
            wrapper.find("#register-form").hide();
            event.stopPropagation();
        });
        wrapper.on("click", "#btn-show-register", function () {
            wrapper.find(".button.selected").removeClass("selected");
            $(this).addClass("selected");
            wrapper.find("#register-form").show();
            wrapper.find("#login-form").hide();
            event.stopPropagation();
        });

        wrapper.on("click", "#btn-login", function () {
            var user = {
                username: $(selector + " #tb-login-username").val(),
                password: $(selector + " #tb-login-password").val()
            }

            persister.login(user, function (data) {
                localStorage.setItem("nickname", data.nickname);
                localStorage.setItem("sessionKey", data.sessionKey);
                console.log("logged");
                window.location = "#/logged-in";
            }, function (err) {
                errContainer.append("<p>" + err.responseJSON.Message + "</p>");
            });

            return false;
        });

        wrapper.on("click", "#btn-register", function () {
            var user = {
                username: $(selector).find("#tb-register-username").val(),
                nickname: $(selector).find("#tb-register-nickname").val(),
                password: $(selector + " #tb-register-password").val()
            }

            persister.register(user, function () {
                localStorage.setItem("nickname", data.nickname);
                localStorage.setItem("sessionKey", data.sessionKey);
                console.log("registered");
                window.location = "#/logged-in";
            }, function (err) {
                errContainer.append("<p>" + err.responseJSON.Message + "</p>");
            });

            return false;
        });

        wrapper.on("click", "#btn-logout", function () {
            persister.logout(function (data) {
                localStorage.removeItem("sessionKey");
                localStorage.removeItem("nickname");
                window.location = "#/";               
            }, function (err) {
                if (err.status == "200") {
                    localStorage.removeItem("sessionKey");
                    localStorage.removeItem("nickname");
                    window.location = "#/";
                }
                else {
                    errContainer.append("<p>" + err.responseJSON.Message + "</p>");
                }
            });
        });

        wrapper.on("click", ".state-link", function () {
            var gameId = this.id;
            window.location = "#/" + gameId;
        });

        wrapper.on("click", "td img", function () {
            var unitInfo = JSON.parse(localStorage.getItem("unitData"));
            var id = this.id;
            if ((unitInfo[id] != undefined) && (unitInfo[id] != null)) {
                var unit = unitInfo[id];
                var template = request.getTemplate("unit.html").then(function (data) {
                    var unitTemplate = mustache.compile(data);
                    var unitHtml = unitTemplate(unit);
                    $("#unit-container").html(unitHtml);
                });
            }
        });

        wrapper.on("click", "#create-game-button", function () {
            debugger;
            var details;
            var title = $("#game-title").val();
            var password = $("#game-password").val();

            if (password != "") {
                details = {
                    title: title,
                    password: password
                }
            }
            else {
                details = {
                    title: title
                }
            }

            persister.createGame(details, function () {
                errContainer.append("<p>Game created.</p>");
            }, function (err) {
                if (err.status == "200") {
                    errContainer.append("<p>Game created.</p>");
                }
                else {
                    errContainer.append("<p>" + err.responseJSON.Message + "</p>");
                }
            });
        });
    }

    return {
        login: buildLoginForm,
        attachHandlers: attachUIEventHandlers
    }
});