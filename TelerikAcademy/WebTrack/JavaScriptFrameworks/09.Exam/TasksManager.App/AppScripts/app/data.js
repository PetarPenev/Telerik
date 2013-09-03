/// <reference path="../libs/_references.js" />
window.persisters = (function () {
	var sessionKey = "";
	var username = "";

	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(username + password).toString()
			};
			return httpRequester.postJSON(this.apiUrl + "auth/token", user)
				.then(function (data) {
				    localStorage.setItem("sessionKey", data.accessToken);
				    localStorage.setItem("username", data.username);
				    localStorage.setItem("userId", data.id);
				    sessionKey = data.accessToken;
					username = data.displayName;
				});
		},
		register: function (username, password, mail) {
		    debugger;
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(username + password).toString(),
				email: mail
			};

			return httpRequester.postJSON(this.apiUrl + "users/register", user);
		},
		logout: function () {
			var headers = {
			    "X-accessToken": localStorage.getItem("sessionKey")
			};
			localStorage.removeItem("sessionKey");
			sessionKey = "";
			localStorage.removeItem("username");
			username = "";
			localStorage.removeItem("userId");
			debugger;
			return httpRequester.putJSON(this.apiUrl + "users/logout", null, headers);
		},
		currentUser: function () {
			return localStorage.getItem("username");
		}
	});

	var AppointmentsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    getAll: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "all", headers);
	    },
	    create: function (appData) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.postJSON(this.apiUrl, appData, headers);
	    },
	    getUpcomming: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "comming", headers);
	    },
	    getToday: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "today", headers);
	    },
	    getCurrent: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "current", headers);
	    },
	    getByDate: function (parsedDate) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        debugger;
	        return httpRequester.getJSON(this.apiUrl + "?date=" + parsedDate, headers);
	    }
	});

	var ListsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    getAll: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl, headers);
	    },
	    createList: function (title) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        var listData = {
	            title: title,
                todos: []
	        };

	        return httpRequester.postJSON(this.apiUrl, listData, headers);
	    },
	    getIndividual: function (id) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + id + "/todos", headers);
	    },
	    addTodo: function (id, text) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        var model = {
	            text: text
	        };

	        return httpRequester.postJSON(this.apiUrl + id + "/todos", model, headers);
	    }
	});

	var TodosPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    changeState: function (id) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.putJSON(this.apiUrl + id, null, headers);
	    }
	});

	

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "/");
			this.appointments = new AppointmentsPersister(apiUrl + "/appointments/");
			this.lists = new ListsPersister(apiUrl + "/lists/");
			this.todos = new TodosPersister(apiUrl + "/todos/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());