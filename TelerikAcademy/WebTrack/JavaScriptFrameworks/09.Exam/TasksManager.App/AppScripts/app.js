/// <reference path="libs/_references.js" />


(function () {

    function checkPermissions() {
        if (data.users.currentUser()) {
            return true;
        }

        return false;
    }

    function checkLogin() {
        if (data.users.currentUser()) {
            $("#login-container").hide();
            $("#logout-container").show();
        }
        else {
            $("#logout-container").hide();
        }
    }

    function clearMainContent() {
        var view = new kendo.View("<div></div>");
        appLayout.showIn("#main-content", view);
    }


    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var logoutLayout = new kendo.Layout("<div id='log-menu'></div>");
    var menuLayout = new kendo.Layout("<div id='menu'></div>");

    var data = persisters.get("http://localhost:16183/api");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        debugger;
        clearMainContent();
        checkLogin();

            viewsFactory.getLogView()
                .then(function (loginHtml) {
                    debugger;
                    var loginVm = vmFactory.getLogViewModel(
                            function(){
                            },
                            function () {
                                debugger;
                                router.navigate("/");
                            }, function () {
                                debugger;
                                checkLogin();
                                clearMainContent();
                                debugger;
                                viewsFactory.getMainMenuUnlogged()
                                    .then(function (menuHtml) {
                                        debugger;
                                        var view = new kendo.View(menuHtml);
                                        menuLayout.showIn("#menu", view);
                                        $("#unlogged-menu").kendoMenu();
                                        router.navigate("/");
                            });
                            });
                    debugger;
                    var view = new kendo.View(loginHtml,
                        { model: loginVm });
                    logoutLayout.showIn("#log-menu", view);
                    $("#login-container").kendoValidator().data('kendoValidator');
                    debugger;
                    if (data.users.currentUser()) {
                        $("#login-container").hide();
                        $("#logout-container").show();
                        viewsFactory.getMainMenuLogged()
                            .then(function (menuHtml) {
                                debugger;
                                var view = new kendo.View(menuHtml);
                                menuLayout.showIn("#menu", view);
                                $("#logged-menu").kendoMenu();
                            });
                    }
                    else {
                        $("#login-container").hide();
                        $("#logout-container").hide();
                        viewsFactory.getMainMenuUnlogged()
                            .then(function (menuHtml) {
                                debugger;
                                var view = new kendo.View(menuHtml);
                                menuLayout.showIn("#menu", view);
                                $("#unlogged-menu").kendoMenu();
                            });
                    }
                });})

    router.route("/login", function () {
        debugger;
        clearMainContent();
        checkLogin();
        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        $("#main-content").html("");
        if (!data.users.currentUser()){

            $("#login-container").show();
            $("#label-mail").hide();
            $("#tb-mail").hide();
            $("#register-btn").hide();
            $("#login-btn").show();
        }
        $("#logout-container").hide();
    });

    router.route("/register", function () {
        debugger;
        clearMainContent();
        checkLogin();
        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        $("#main-content").html("");
        if (!data.users.currentUser()) {

            $("#login-container").show();
            $("#label-mail").show();
            $("#tb-mail").show();
            $("#register-btn").show();
            $("#login-btn").hide();
        }
        $("#logout-container").hide();
    });

    router.route("/about", function () {

        debugger;
        clearMainContent();
        checkLogin();
        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        if (data.users.currentUser()) {
            $("#login-container").hide();
            $("#logout-container").show();
        }
        else {
            $("#login-container").hide();
            $("#logout-container").hide();
        }

        viewsFactory.getAboutPage()
            .then(function (aboutHtml) {
                var view = new kendo.View(aboutHtml);
                appLayout.showIn("#main-content", view);
            });
    });

    router.route("/appointments", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getMainAppointmentsView()
            .then(function (appHtml) {
                debugger;
                vmFactory.getMainAppointmentsModel()
                 .then(function (vm) {
                    debugger;
                    var view = new kendo.View(appHtml, { model: vm });
                    appLayout.showIn("#main-content", view);
                    /*$("#date-field").kendoDateTimePicker({
                        parseFormats: ["MMMM yyyy", "HH:mm"] ,
                        timeFormat: "HH:mm",//24 hours format
                        format: "yyyy/MM/dd HH:mm tt"
                    });*/
                    $("#app-validate").kendoValidator().data('kendoValidator');
                });
            });
    });

    router.route("/see-upcomming-appointments", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getUpcommingAppointmentsView()
            .then(function (appHtml) {
                debugger;
                vmFactory.getUpcommingAppointmentsModel()
                 .then(function (vm) {
                     debugger;
                     var view = new kendo.View(appHtml, { model: vm });
                     appLayout.showIn("#main-content", view);
                 });
            });
    });

    router.route("/see-today-appointments", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getTodayAppointmentsView()
            .then(function (appHtml) {
                debugger;
                vmFactory.getTodayAppointmentsModel()
                 .then(function (vm) {
                     debugger;
                     var view = new kendo.View(appHtml, { model: vm });
                     appLayout.showIn("#main-content", view);
                 });
            });
    });

    router.route("/see-current-appointments", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getCurrentAppointmentsView()
            .then(function (appHtml) {
                debugger;
                vmFactory.getCurrentAppointmentsModel()
                 .then(function (vm) {
                     debugger;
                     var view = new kendo.View(appHtml, { model: vm });
                     appLayout.showIn("#main-content", view);
                 });
            });
    });

    router.route("/search-appointments-by-date", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getDateAppointmentsView()
            .then(function (appHtml) {
                debugger;
                var vm = vmFactory.getDateAppointmentsModel()
                     debugger;
                     var view = new kendo.View(appHtml, { model: vm });
                     appLayout.showIn("#main-content", view);
                     //$("#date-field").kendoDatePicker();
            });
    });

    router.route("/todo-lists", function () {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getTodoMainView()
            .then(function (appHtml) {
                debugger;
                vmFactory.getTodoMainModel(function (idRoute) {
                    router.navigate("/todo-list/" + idRoute);
                })
                    .then(function (vm) {
                        debugger;
                        var view = new kendo.View(appHtml, { model: vm });
                        appLayout.showIn("#main-content", view);
                    });
                //$("#date-field").kendoDatePicker();
            });
    });

    router.route("/todo-list/:id", function (id) {
        debugger;
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        var checkAvailability = $("#login-container");
        if (checkAvailability.length == 0) {
            router.navigate("/");
        }

        viewsFactory.getIndividualListView()
            .then(function (listHtml) {
                vmFactory.getIndividualListModel(id)
                    .then(function (vm) {
                        var view = new kendo.View(listHtml, { model: vm });
                        appLayout.showIn("#main-content", view);
                        $("#todo-validation").kendoValidator().data('kendoValidator');
                    });
            });
    });

    $(function () {
        appLayout.render("#app");
        logoutLayout.render("#log-div");
        menuLayout.render("#menu");
        router.start();
    });
}());