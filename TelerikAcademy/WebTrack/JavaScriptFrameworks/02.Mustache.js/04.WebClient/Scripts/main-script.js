/// <reference path="jquery-2.0.3.min.js" />
/// <reference path="mustache.js" />
/// <reference path="TableView.js" />
var studentsUrl = "http://localhost:5103/api/students";
var marksUrl = "http://localhost:5103/api/marks/";
var tableRowCount = 3;
var tableColumnCount = 2;

function getJSON(url, success, error) {
    $.ajax({
        url: url,
        type: "GET",
        timeout: 5000,
        contentType: "application/json",
        success: success,
        error: error
    });
}

$("#show-students-btn").on("click", function () {
    $("#table-container-div").html("The students' table appears here.");
    $("#marks-container-div").html("The selected student's marks appear here.");

    getJSON(studentsUrl, function (data) {
        var tableView = controls.getTableView(tableRowCount, tableColumnCount, data);
        var templateData = $("#student-template").html();
        var studentTemplate = Mustache.compile(templateData);
        var tableHtml = tableView.render(studentTemplate);
        $("#table-container-div").html(tableHtml);
        $(".clickClass").on("click", function (ev) {
            getJSON(marksUrl + this.id, function (data) {
                var tableView = controls.getTableView(tableRowCount, tableColumnCount, data);
                var templateData = $("#mark-template").html();
                var markTemplate = Mustache.compile(templateData);
                var tableHtml = tableView.render(markTemplate);
                $("#marks-container-div").html(tableHtml);
            },
            function (err) {
            });
        });
    },
    function (err) {
    });
});