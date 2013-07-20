function attachEventHandler(element, eventType, eventHandler) {
    if (document.attachEvent) {
        element.attachEvent("on" + eventType, eventHandler);
    } else if (document.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        element["on" + eventType] = eventHandler;
    }
}

var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    },
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    },

    addUrl: function (urlToAdd) {
        this.urls.push(urlToAdd);
    },

    render: function () {
        var folderContainer = document.createElement("div");
        folderContainer.className = "folder-container";
        var folderTitle = document.createElement("a");
        folderTitle.className = "title-folder";
        folderTitle.onclick = function (ev) {
            if (!ev) {
                ev = window.event;
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            if (ev.preventDefault) {
                ev.preventDefault();
            }

            var clickedItem = ev.target;
            var parent = clickedItem.parentElement;
            var container = parent.querySelector("div");

            if (container.style.display == "none") {
                container.style.display = "block";
            }
            else {
                container.style.display = "none";
            }
        }

        folderTitle.innerHTML = this.title;
        folderContainer.appendChild(folderTitle);

        var urlContainer = document.createElement("div");
        for (var i = 0, len = this.urls.length; i < len; i++) {
            var currentUrl = document.createElement("a");
            currentUrl.className = "url-anchor";
            currentUrl.target = "_blank";
            currentUrl.title = this.urls[i].title;
            currentUrl.href = this.urls[i].url;
            currentUrl.innerHTML = this.urls[i].title;
            urlContainer.appendChild(currentUrl);
        }

        urlContainer.style.display = "none";
        folderContainer.appendChild(urlContainer);
        
        return folderContainer;
    }
});


var SiteBar = Class.create({
    init: function (urls, folders) {
        this.urls = urls;
        this.folders = folders;
    },

    addUrl: function (urlToAdd) {
        this.urls.push(urlToAdd);
    },

    addFolder: function (folderToAdd) {
        this.folders.push(folderToAdd);
    },

    render: function (selector) {
        var documentFragment = document.createDocumentFragment();
        var urlContainer = document.createElement("div");
        for (var i = 0, len = this.urls.length; i < len; i++) {
            var currentUrl = document.createElement("a");
            currentUrl.className = "url-anchor";
            currentUrl.target = "_blank";
            currentUrl.title = this.urls[i].title;
            currentUrl.href = this.urls[i].url;
            currentUrl.innerHTML = this.urls[i].title;
            urlContainer.appendChild(currentUrl);
        }

        documentFragment.appendChild(urlContainer);

        for (var i = 0, len = this.folders.length; i < len; i++) {
            var currentFolder = this.folders[i].render();
            documentFragment.appendChild(currentFolder);
        }

        var elementToAppendTo = document.querySelector(selector);
        elementToAppendTo.appendChild(documentFragment);
    }
});

var firstTelerikUrl = new Url("Telerik", "http://www.telerik.com/");
var secondTelerikUrl = new Url("Telerik Academy", "http://academy.telerik.com/");
var thirdTelerikUrl = new Url("Telerik Student System", "http://telerikacademy.com/");

var firstNewsUrl = new Url("Cnn", "http://edition.cnn.com/");
var secondNewsUrl = new Url("Nbc", "http://www.nbc.com/");
var thirdNewsUrl = new Url("Reuters", "http://www.reuters.com/");

var firstVideoUrl = new Url("YouTube", "https://www.youtube.com/");
var secondVideoUrl = new Url("Vbox", "http://vbox7.com/");

var telerikFolder = new Folder("Telerik sites", [firstTelerikUrl, secondTelerikUrl]);
telerikFolder.addUrl(thirdTelerikUrl);

var newsFolder = new Folder("News sites", [firstNewsUrl, secondNewsUrl]);
newsFolder.addUrl(thirdNewsUrl);

var siteBar = new SiteBar([], []);
siteBar.addUrl(firstVideoUrl);
siteBar.addUrl(secondVideoUrl);
siteBar.addFolder(telerikFolder);
siteBar.addFolder(newsFolder);

siteBar.render("#bar-container");