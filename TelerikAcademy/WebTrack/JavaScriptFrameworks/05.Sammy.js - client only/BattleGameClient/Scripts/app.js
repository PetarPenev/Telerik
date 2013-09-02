(function initialFunction() {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            sammy: "libs/sammy-0.7.4",
            mustache: "libs/mustache",
            rsvp: "libs/rsvp.min",
            request: "libs/http-requester",
            templates: "templates/temps",
            persister: "apps/persister",
            crypto: "libs/CryptoJS",
            helper: "apps/helper"
        }
    })

    require(["jquery", "sammy", "templates", "helper", "request", "persister", "mustache"],
        function ($, sammy, templates, helper, request, persister, mustache) {

        var app = sammy(function () {
            this.get("#/", function () {
                if (helper.isLoggedIn()) {
                    window.location = "#/logged-in";
                }
                else {
                    //var templ = $("#login-template").html();
                    /*var templ = $.get("Scripts/templates/login.html", function (data) {
                        $("#main-content").html("");
                        $("#main-content").append(data);
                        $("#main-content").unbind();
                        templates.attachHandlers("#main-content", "#error-console");
                    });*/
                    var templ = request.getTemplate("login.html").then(function (data) {
                        $("#main-content").html("");
                        $("#main-content").append(data);
                        $("#main-content").unbind();
                        templates.attachHandlers("#main-content", "#error-console");
                    });
                }
            });

            this.get("#/logged-in", function () {
                $("#main-content").html("");
                $("#main-content").append("<h1>User: " + localStorage.getItem("nickname") + "</h1>");
                var templ = request.getTemplate("LoggedInTemplate.html").then(function (data) {
                    $("#main-content").append(data);
                    $("#main-content").unbind();
                    templates.attachHandlers("#main-content", "#error-console");
                    $("#error-console").html("");
                });
                /*$("#main-content").append('<button id="btn-logout">Logout</button><br />');
                $("#main-content").append('<a href="#/join-games">Active Games</a>');
                $("#main-content").append('<a href="#/my-games">My games</a>');
                $("#main-content").unbind();
                templates.attachHandlers("#main-content", "#error-console");*/
            });

            this.get("#/my-games", function () {
                $("#main-content").html("");
                $("#main-content").unbind();
                $("#error-console").html("");
                templates.attachHandlers("#main-content", "#error-console");
                var templ = request.getTemplate("ActiveGameTemplate.html").then(function (data) {
                    var gameTemplate = mustache.compile(data);
                    persister.getActive(function (data) {
                        for (var i = 0, len = data.length; i < len; i++) {
                            var game = gameTemplate(data[i]);
                            if (data[i].status == "in-progress") {
                                game += '<div id="' + data[i].id + '" class="state-link">See state</div>';
                            }

                            game += "</div>";

                            $("#main-content").append(game);
                            $("#main-content").append("<br />");
                        }

                        $("#main-content").append('<br /><a href="#/logged-in">Get Back</a>');
                    }, function (err) {
                        $("#error-console").append("<p>" + err.responseJSON.Message + "</p>");
                    }
                    );
                });
            });

            this.get("#/join-games", function () {
                $("#main-content").html("");
                $("#error-console").html("");
                $("#main-content").unbind();
                templates.attachHandlers("#main-content", "#error-console");
                var templ = request.getTemplate("OpenGameTemplate.html").then(function (data) {
                    var gameTemplate = mustache.compile(data);
                    persister.getOpen(function (data) {
                        for (var i = 0, len = data.length; i < len; i++) {
                            var game = gameTemplate(data[i]);
                            $("#main-content").append(game);
                            $("#main-content").append("<br />");
                        }

                        $("#main-content").append('<br /><a href="#/logged-in">Get Back</a>');
                    }, function (err) {
                        $("#error-console").append("<p>" + err.responseJSON.Message + "</p>");
                    }
                    );
                });
            });

            this.get("#/my-messages", function () {
                $("#main-content").html("");
                $("#error-console").html("");
                $("#main-content").unbind();
                templates.attachHandlers("#main-content", "#error-console");
                var templ = request.getTemplate("MessageTemplate.html").then(function (mainData) {
                    debugger;
                    $("#main-content").append(
                        '<div id="msg-all">All messages:</div><div id ="msg-unread">Unread messages:</div><a href="#/logged-in">Get back</a>');
                    var msgTemplate = mustache.compile(mainData);

                    persister.getAllMessages(function (data) {
                        debugger;
                        for (var i = 0, len = data.length; i < len; i++) {
                            var msg = msgTemplate(data[i]);
                            $("#msg-all").append(msg);
                            $("#main-content").append("<br />");
                        }
                    }, function (err) {
                        $("#error-console").append("<p>" + err.responseJSON.Message + "</p>");
                    }
                    );

                    persister.getUnreadMessages(function (data) {
                        debugger;
                        for (var i = 0, len = data.length; i < len; i++) {
                            var msg = msgTemplate(data[i]);
                            $("#msg-all").append(msg);
                            $("#main-content").append("<br />");
                        }
                    }, function (err) {
                        $("#error-console").append("<p>" + err.responseJSON.Message + "</p>");
                    }
                    );
                });
            });

            this.get("#/create-game", function () {
                $("#main-content").html("");
                $("#error-console").html("");
                $("#main-content").unbind();
                templates.attachHandlers("#main-content", "#error-console");
                var templ = request.getTemplate("CreateGame.html").then(function (data) {
                    $("#main-content").append(data);
                });
            });

            this.get("#/:id", function () {
                var cont = $("#main-content");
                $("#error-console").html("");
                cont.html("");
                cont.unbind();
                templates.attachHandlers("#main-content", "#error-console");
                var id = this.params["id"];
                id = parseInt(id, 10);
                persister.getState(id, function (data) {
                    localStorage.removeItem("unitData");
                    cont.append("<h1>" + data.title + "</h1>");
                    cont.append("<div>Turn: " + data.turn + "</div>");
                    cont.append('<div id="unit-container">Selected unit:</div>');
                    var nick = localStorage.getItem("nickname");
                    if (((data.inTurn == "red") && (nick == data.red.nickname)) ||
                        ((data.inTurn == "blue") && (nick == data.blue.nickname))) {
                        cont.append("<div>Your turn</div>");
                    }
                    else {
                        cont.append("<div>Opponent's turn</div>");
                    }

                    var templ = request.getTemplate("FieldTemplate.html").then(function (mainData) {
                        cont.append(mainData);
                        

                        $("#main-content").append('<br /><a href="#/my-games">Get Back</a>');

                        var unitData = {};
                        for (var i = 0, len = data.red.units.length; i < len; i++) {
                            var unit = data.red.units[i];
                            unitData[unit.id] = unit;
                            var selectorString = "#";
                            selectorString += unit.position.x;
                            selectorString += unit.position.y;
                            var container = $(selectorString);
                            var imgString = '<img src="Scripts/images/red-';
                            if (unit.type == "warrior") {
                                imgString += 'warrior';
                            }
                            else {
                                imgString += 'ranger';
                            }

                            imgString += '.png" width="65" heigth="65" alt="unit image">';
                            container.append(imgString);
                        }

                        for (var i = 0, len = data.blue.units.length; i < len; i++) {
                            var unit = data.blue.units[i];
                            unitData[unit.id] = unit;
                            var selectorString = "#";
                            selectorString += unit.position.x;
                            selectorString += unit.position.y;
                            var container = $(selectorString);
                            var imgString = '<img id="' + unit.id + '" ' + 'src="Scripts/images/blue-';
                            if (unit.type == "warrior") {
                                imgString += 'warrior';
                            }
                            else {
                                imgString += 'ranger';
                            }

                            imgString += '.png" width="65" heigth="65" alt="unit image">';
                            container.append(imgString);
                        }

                        localStorage.setItem("unitData", JSON.stringify(unitData));
                        }, function (err) {
                            $("#error-console").append("<p>" + err.responseJSON.Message + "</p>");
                        }
                        );                    
                }, function (err) {
                    errContainer.append("<p>" + err.responseJSON.Message + "</p>");
                });
            });
        });

        $(function () {
            app.run("#/");
        });
    });
}());