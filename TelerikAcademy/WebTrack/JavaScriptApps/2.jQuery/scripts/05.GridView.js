/// <reference path="jquery-1.10.1.min.js" />

var GridView = (function () {
    function initialize(numberOfFields, element) {
        return new Grid(numberOfFields, element);
    }

    function Grid(numberOfFields, element, nested) {
        this.numberOfArguments = numberOfFields;
        var headerRow = undefined;
        var rows = [];
        var tableView = $("<table></table>");
        tableView.addClass("grid");
        if (nested) {
            tableView.addClass("hidden");
        }

        element.after(tableView);

        this.addRow = function () {
            var newRow = $("<tr></tr>");
            newRow.addClass("row-of-grid");
            for (var i = 0; i < this.numberOfArguments; i++) {
                var currentCell = $("<td></td>");
                currentCell.addClass("cell-of-grid");
                currentCell.html(arguments[i]);
                newRow.append(currentCell);
            }

            rows.push(newRow);
            tableView.append(newRow);
            element.after(tableView);
            return new rowObject(newRow);
        }

        this.addHeader = function () {
            if (headerRow != undefined) {
                throw new Error("The grid already has a header row.");
            }

            headerRow = $("<tr></tr>");
            headerRow.addClass("header-of-grid");
            for (var i = 0; i < this.numberOfArguments; i++) {
                var headerCell = $("<th>" + arguments[i] + "</th>");
                headerCell.addClass("header-cell-of-grid");
                headerRow.append(headerCell);
            }

            var header = $("<thead></thead>");
            header.append(headerRow);
            tableView.prepend(header);
            element.after(tableView);
        }

        function rowObject(row) {
            this.rowElement = row;
            this.gridView = undefined;
            this.addGrid = function (numberOfFields) {
                if (this.gridView != undefined) {
                    throw new Error("The row already has a nested grid view.");
                }

                var toAdd = $($(this.rowElement).get(0));
                toAdd.addClass("with-nested-grid");
                var newGrid = new Grid(numberOfFields, toAdd, true);
                toAdd.on("click", function (ev) {
					ev.stopPropagation();
                    var gridTable = $(ev.target);
                    while (gridTable.is("td")) {
                        gridTable = $(gridTable.parent());
                    }

                    gridTable = gridTable.next("table");

                    if (gridTable.css("display") == "none") {
                        gridTable.css("display", "block");
                    }
                    else {
                        gridTable.css("display", "none");
                    }

                });

                this.gridView = newGrid;
                return newGrid;
            }
        }
    }

    return {
        init: initialize
    }
}());

var selector = "#grid-container";
var grid = GridView.init(4, $(selector), false);
var rowWithNested = grid.addRow("John", "Winston", "Bird", 24);
grid.addRow("John", "Tony", "Fortune", 31);
grid.addHeader("First name", "Second name", "Third name", "Age");
var nestedGrid = rowWithNested.addGrid(5);
nestedGrid.addRow("Honda", "Civic", 1997, 4, "old");
nestedGrid.addHeader("Brand", "Model", "Year", "Doors", "State");
var subnested = nestedGrid.addRow("Ford", "Escort", 1990, 4, "old");
nestedGrid.addRow("Lada", "Samara", 1970, 4, "old");
var subnestedGrid = subnested.addGrid(3);
subnestedGrid.addHeader("First name", "Second name", "Last name");
subnestedGrid.addRow("John", "Stoyanov", "Ivanov");