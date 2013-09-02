define(["jquery", "request"], function ($, request) {
    
    function login(user, success, error) {
        var userData = {
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };
        request.postJSON("http://localhost:22954/api/User/login", userData).then(success, error);
    }

    function register(user, success, error) {
        var userData = {
            username: user.username,
            nickname: user.nickname,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };

        request.postJSON("http://localhost:22954/api/User/register", userData).then(success, error);
    }

    function getActive(success, error) {
        request.getJSON("http://localhost:22954/api/Game/my-active/" + localStorage.getItem("sessionKey"))
            .then(success, error);
    }

    function getOpen(success, error) {
        request.getJSON("http://localhost:22954/api/Game/open/" + localStorage.getItem("sessionKey"))
            .then(success, error);
    }

    function getAllMessages(success, error) {
        request.getJSON("http://localhost:22954/api/messages/all/" + localStorage.getItem("sessionKey"))
            .then(success, error);
    }

    function getUnreadMessages(success, error) {
        request.getJSON("http://localhost:22954/api/messages/unread/" + localStorage.getItem("sessionKey"))
            .then(success, error);
    }

    function getState(id, success, error) {
        request.getJSON("http://localhost:22954/api/game/" + id + "/field/" + localStorage.getItem("sessionKey"))
            .then(success, error);
    }

    function logout( success, error) {
        var sessionKey = localStorage.getItem("sessionKey");
        if ((sessionKey == null) || (sessionKey == undefined)) {
            $("#error-console").append("<p> Incorrect login state. Please clear local storage and try again. </p>");
        }

        request.putJSON("http://localhost:22954/api/User/logout/" + sessionKey).then(success, error);
    }

    function createGame(data, success, error) {
        var sessionKey = localStorage.getItem("sessionKey");
        if ((sessionKey == null) || (sessionKey == undefined)) {
            $("#error-console").append("<p> Incorrect login state. Please clear local storage and try again. </p>");
        }

        request.postJSON("http://localhost:22954/api/Game/create/" + sessionKey, data).then(success, error);
    }

    return {
        login: login,
        register: register,
        logout: logout,
        getActive: getActive,
        getOpen: getOpen,
        getState: getState,
        getAllMessages: getAllMessages,
        getUnreadMessages: getUnreadMessages,
        createGame: createGame
    }
});