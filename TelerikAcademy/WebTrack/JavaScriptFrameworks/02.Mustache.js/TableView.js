/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
		init: function (rows, cols, itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}
			
			this.rows = rows;
			this.cols = cols;
			this.itemsSource = itemsSource;
		},
		render: function (template) {
		    var table = document.createElement("table");
		    var itemCount = 0;

			for (var i = 0; i < this.rows; i++) {
			    var rowItem = document.createElement("tr");
			    for (var j = 0; j < this.cols; j++) {
			        var cell = document.createElement("td");
			        if (itemCount <= this.itemsSource.length) {
			            cell.innerHTML = template(this.itemsSource[itemCount]);
			            itemCount++;
			        }
			        else {
			            cell.innerHTML = "Empty";
			        }

			        rowItem.appendChild(cell);
			    }

			    table.appendChild = rowItem;
			}

			return table.outerHTML;
		}
	});

	c.getTableView = function (rows, cols, itemsSource) {
	    return new TableView(rows, cols, itemsSource);
	}
}(controls || {}));