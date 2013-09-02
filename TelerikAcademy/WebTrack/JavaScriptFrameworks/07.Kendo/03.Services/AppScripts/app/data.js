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
			return httpRequester.postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    localStorage.setItem("sessionKey", data.sessionKey);
				    localStorage.setItem("username", data.displayName);
					sessionKey = data.sessionKey;
					username = data.displayName;
				});
		},
		register: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(username + password).toString()
			};
			return httpRequester.postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    localStorage.setItem("sessionKey", data.sessionKey);
				    localStorage.setItem("username", data.displayName);
					sessionKey = data.sessionKey;
					bashUsername = data.displayName;
					return data.displayName;
				});
		},
		logout: function () {
			var headers = {
			    "X-sessionKey": localStorage.getItem("sessionKey")
			};
			localStorage.removeItem("sessionKey");
			sessionKey = "";
			localStorage.removeItem("username");
			username = "";
			debugger;
			return httpRequester.putJSON(this.apiUrl + "logout", null, headers);
		},
		currentUser: function () {
			return localStorage.getItem("username");
		}
	});

	var AccountsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
        
	    getAll: function () {
	        var headers = {
	            "X-sessionKey": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "get-accounts", headers);
	    },

	    getById: function (id) {
	        var headers = {
	            "X-sessionKey": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "get-by-id/" + id, headers);
	    },

	    moneyTransfer: function (sum, id) {
	        var headers = {
	            "X-sessionKey": localStorage.getItem("sessionKey")
	        };

	        debugger;
	        return httpRequester.putJSON(this.apiUrl + "update-account?accountId=" + id, { sum: sum}, headers);
	    }
	});

	var TransactionsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },

	    getTransactions: function () {
	        var headers = {
	            "X-sessionKey": localStorage.getItem("sessionKey")
	        };

	        return httpRequester.getJSON(this.apiUrl + "get-transactions", headers);
	    }
	});

	

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "Users/");
			this.accounts = new AccountsPersister(apiUrl + "Accounts/");
			this.transactions = new TransactionsPersister(apiUrl + "Transactions/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());