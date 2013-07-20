/// <reference path="jquery-1.10.1.min.js" />

function loadStudents(students) {
    var container = document.createElement("div");
    container.id = "table-container";
    document.body.appendChild(container);

    var table = document.createElement("table");
    table.id = "table-students";
    table = $(table);
    var htmlTable = "<thead><tr><th>First name</th><th>Last name</th><th>Grade</th></tr></thead>";
    if (students.length > 0) {
        htmlTable = htmlTable + "<tbody>";
    }

    for (var i = 0; i < students.length; i++) {
        var rowHTML = "<tr><td>" + students[i].firstname + "</td><td>" + students[i].lastname + "</td><td>" + students[i].grade + "</td></tr>";
        htmlTable = htmlTable + rowHTML;
    }

    if (students.length > 0) {
        htmlTable = htmlTable + "</tbody>";
    }

    table.html(htmlTable);
    var container = $("#table-container");
    container.append(table);
}


var students = [{"firstname":"Peter","lastname": "Ivanov", "grade": "3"},
{"firstname":"Milena","lastname": "Grigorova", "grade": "6"},
{"firstname":"Gargana","lastname": "Borisova", "grade": "12"},
{"firstname":"Boyko","lastname": "Petrov", "grade": "7"}];

loadStudents(students);