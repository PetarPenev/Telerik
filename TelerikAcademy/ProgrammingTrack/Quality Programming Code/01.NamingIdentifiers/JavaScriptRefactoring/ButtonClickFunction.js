// Used standartd naming and refactoring conventions. Removed the unnecessary
// input parameters as they were never used.
function isMozilla() {
    var myWindow = window;
    var browserUsed = myWindow.navigator.appCodeName;
    var isMozilla = (browserUsed === "Mozilla");
    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
