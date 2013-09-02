/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {

    function getLogView() {
        return httpRequester.getTemplate("login-full");
    }

    function getMainMenuUnlogged() {
        return httpRequester.getTemplate("menu-unlogged");
    }

    function getMainMenuLogged() {
        return httpRequester.getTemplate("menu-logged");
    }

    function getAboutPage() {
        return httpRequester.getTemplate("about");
    }

    function getAccountsView() {
        return httpRequester.getTemplate("accounts");
    }

    function getTransactionsView() {
        return httpRequester.getTemplate("transactions");
    }

    return {
        getLogView: getLogView,
        getMainMenuLogged: getMainMenuLogged,
        getMainMenuUnlogged: getMainMenuUnlogged,
        getAboutPage: getAboutPage,
        getAccountsView: getAccountsView,
        getTransactionsView: getTransactionsView
    };
}());