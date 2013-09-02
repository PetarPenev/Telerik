define(["jquery"], function ($) {

    function isLoggedIn(){
        var truth =  localStorage.getItem("sessionKey") != null &&
            localStorage.getItem("sessionKey") != undefined &&
            localStorage.getItem("nickname") != null &&
            localStorage.getItem("nickname") != undefined;

        return truth;
    }

    return {
        isLoggedIn: isLoggedIn
    }
});