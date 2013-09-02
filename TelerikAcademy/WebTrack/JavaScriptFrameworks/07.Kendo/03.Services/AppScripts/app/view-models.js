/// <reference path="../libs/_references.js" />


window.vmFactory = (function () {

    function getLogViewModel(successCallbackLogin, successCallbackLogout) {
        var viewModel = {
            username: localStorage.getItem("username") || "username",
            password: "",
            login: function () {
                debugger;
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallbackLogin) {
					        successCallbackLogin();
					    }
					}, function (err) {

					});
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallbackLogin) {
					        successCallbackLogin();
					    }
					});
            },
            message: "",
            logout: function () {
                debugger;
                var transition = this;
                data.users.logout()
                .then(function () {
                    debugger;
                    if (successCallbackLogout) {
                        debugger;
                        transition.set("username","username");
                        successCallbackLogout();
                    }
                }, function () {
                    debugger;
                    if (successCallbackLogout) {
                        debugger;
                        transition.set("username", "username");
                        successCallbackLogout();
                    }
                });
            }
        };

        debugger;
        return kendo.observable(viewModel);
    }

    function getAccountsModel() {
        return data.accounts.getAll()
            .then(function (accounts) {
                var viewModel = {
                    accounts: accounts,
                    accountIdValue: accounts[0]["id"] || 1,
                    currentAccount: accounts[0] ? [accounts[0]] : [],
                    changeAccounts: function (ev) {
                        var accountId = this.get("accountIdValue");
                        var transition = this;
                        data.accounts.getById(accountId)
                            .then(function (data) {
                                debugger;
                                transition.set("currentAccount", [data]);
                            });
                    },
                    deposit: function () {
                        var sum = this.currentAccount[0]["sum"];
                        var id = this.currentAccount[0]["id"];
                        var transition = this;
                        debugger;
                        data.accounts.moneyTransfer(parseInt(sum, 10), id)
                            .then(function () {
                                debugger;
                                data.accounts.getById(id).
                                    then(function (data) {
                                        transition.set("currentAccount", [data]);
                                    });
                            }, function () {
                                debugger;
                                data.accounts.getById(id).
                                    then(function (data) {
                                        transition.set("currentAccount", [data]);
                                    });
                            });
                    },
                    withdraw: function () {
                        var sum = this.currentAccount[0]["sum"];
                        var id = this.currentAccount[0]["id"];
                        var transition = this;
                        data.accounts.moneyTransfer(-parseInt(sum, 10), id)
                        .then(function () {
                            debugger;
                            data.accounts.getById(id).
                                then(function (data) {
                                    debugger;
                                    transition.set("currentAccount", [data]);
                                });
                        }, function () {
                            debugger;
                            data.accounts.getById(id).
                                then(function (data) {
                                    debugger;
                                    transition.set("currentAccount", [data]);
                                });
                        });
                    }
                }


                return kendo.observable(viewModel);
            });
    }

        function getTransactionsModel() {
            return data.transactions.getTransactions()
                .then(function (data) {
                    var viewModel = {
                        transactions: data
                    };

                    return kendo.observable(viewModel);
                });
        }

    return {
        getLogViewModel: getLogViewModel,
        getAccountsModel: getAccountsModel,
        getTransactionsModel: getTransactionsModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());