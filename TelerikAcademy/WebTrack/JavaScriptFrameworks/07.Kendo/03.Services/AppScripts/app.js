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

    var data = persisters.get("http://localhost:13972/api/");
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

    router.route("/see-accounts", function () {
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

        viewsFactory.getAccountsView()
            .then(function (accountsHtml) {
                vmFactory.getAccountsModel()
                    .then(function (vm) {
                        debugger;
                        var view = new kendo.View(accountsHtml, { model: vm });
                        appLayout.showIn("#main-content", view);
                        debugger;
                        $("#account-list").kendoValidator().data('kendoValidator');
                    });
            });
        
    });

    router.route("/see-logs", function () {
        clearMainContent();
        checkLogin();
        if (!checkPermissions()) {
            router.navigate("/");
        }

        viewsFactory.getTransactionsView()
            .then(function (transactionsHtml) {
                vmFactory.getTransactionsModel()
                    .then(function (data) {
                        var view = new kendo.View(transactionsHtml);
                        appLayout.showIn("#main-content", view);
                        var transactionsDataSource = new kendo.data.DataSource({
                            data: data.transactions
                        });
                        $('#transactions-div').kendoGrid({
                            dataSource: transactionsDataSource,
                            pageable: {
                                input: true,
                                numeric: false
                            },
                            scrollable: false,
                            sortable: true,
                            filterable: false,
                            groupable: true,
                            columns: [
                                { field: "accountId", title: "AccountNumber", width: 130 },
                                { field: "transactionType", title: "Type of transaction", width: 200 },
                                { field: "amount", title: "Amount", width: 80 }
                            ]
                        });
                        debugger;
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