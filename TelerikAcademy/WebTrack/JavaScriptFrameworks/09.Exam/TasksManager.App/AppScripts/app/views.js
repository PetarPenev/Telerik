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

    function getMainAppointmentsView() {
        return httpRequester.getTemplate("main-appointments");
    }

    function getUpcommingAppointmentsView() {
        return httpRequester.getTemplate("upcomming-appointments");
    }

    function getTodayAppointmentsView() {
        return httpRequester.getTemplate("today-appointments");
    }

    function getCurrentAppointmentsView() {
        return httpRequester.getTemplate("current-appointments");
    }

    function getDateAppointmentsView() {
        return httpRequester.getTemplate("date-search");
    }

    function getTodoMainView() {
        return httpRequester.getTemplate("todo-main");
    }

    function getIndividualListView() {
        return httpRequester.getTemplate("individual-list");
    }

    return {
        getLogView: getLogView,
        getMainMenuLogged: getMainMenuLogged,
        getMainMenuUnlogged: getMainMenuUnlogged,
        getAboutPage: getAboutPage,
        getMainAppointmentsView: getMainAppointmentsView,
        getUpcommingAppointmentsView: getUpcommingAppointmentsView,
        getTodayAppointmentsView: getTodayAppointmentsView,
        getCurrentAppointmentsView: getCurrentAppointmentsView,
        getDateAppointmentsView: getDateAppointmentsView,
        getTodoMainView: getTodoMainView,
        getIndividualListView: getIndividualListView
    };
}());