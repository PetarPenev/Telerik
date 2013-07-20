function attachEventHandler (element, eventType, eventHandler) {
    if (document.attachEvent) {
        element.attachEvent("on" + eventType, eventHandler);
    } else if (document.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        element["on" + eventType] = eventHandler;
    }
}

var Image = {
    init: function (title, urlLarge, urlSmall) {
        this.title = title;
        this.largeImage = urlLarge;
        this.smallImage = urlSmall;
        this.selected = false;
    },
}

var ImageSlider = {
    init: function (images) {
        this.images = images;
    },


    appendToDom: function (selector, id) {
        var instanceSlider = this;
        var docFragment = document.createDocumentFragment();
        var imgContainer = document.createElement("div");

        var largeImageContainer = document.createElement("div");
        largeImageContainer.id = "large-image-container";
        var largeImage = document.createElement("img");
        largeImage.id = "large-image";
        largeImage.src = this.images[0].largeImage;
        largeImageContainer.appendChild(largeImage);

        var container = document.createElement("div");
        container.id = id;

        for (var i = 0, len = this.images.length; i < len; i++) {
            var image = document.createElement("img");
            image.title = this.images[i].title;
            image.src = this.images[i].smallImage;
            image.className = "img-tumbnail";
            attachEventHandler(image, "click", function (ev) {
                var source = ev.target.title;
                instanceSlider.changeLargeImage(source);
            });
            docFragment.appendChild(image);
        }

        imgContainer.appendChild(docFragment);
        container.appendChild(largeImageContainer);
        container.appendChild(imgContainer);

        var previousButton = document.createElement("button");
        previousButton.innerHTML = "Previous";
        attachEventHandler(previousButton, "click", function () {
            instanceSlider.getPreviousImage();
        });
        container.appendChild(previousButton);

        var nextButton = document.createElement("button");
        nextButton.innerHTML = "Next";
        attachEventHandler(nextButton, "click", function () {
            instanceSlider.getNextImage();
        });
        container.appendChild(nextButton);

        this.images[0].selected = true;
        var elementToAppendTo = document.querySelector(selector);
        elementToAppendTo.appendChild(container);
    },

    getPreviousImage: function () {
        var currentImageIndex = -1;
        for (var i = 0, len = this.images.length; i < len; i++) {
            if (this.images[i].selected == true) {
                currentImageIndex = i;
                break;
            }
        }

        this.images[currentImageIndex].selected = false;
        var previousImageIndex = currentImageIndex - 1;
        if (previousImageIndex == -1) {
            previousImageIndex = len - 1;
        }

        this.images[previousImageIndex].selected = true;
        this.getLargeImage();
    },

    getNextImage: function () {
        var currentImageIndex = -1;
        for (var i = 0, len = this.images.length; i < len; i++) {
            if (this.images[i].selected == true) {
                currentImageIndex = i;
                break;
            }
        }

        this.images[currentImageIndex].selected = false;
        var nextImageIndex = currentImageIndex + 1;
        if (nextImageIndex == this.images.length) {
            nextImageIndex = 0;
        }

        this.images[nextImageIndex].selected = true;
        this.getLargeImage();
    },

    // The title is used as an image identifier. It is possible to use another unique data point (like give 
    // each image a custom id number and pass it as a custom attribute to the DOM element and then get it instead
    // of the title, but this is essentially the same solution.
    changeLargeImage: function (newTitle) {
        var image = "";
        for (var i = 0, len = this.images.length; i < len; i++) {
            if (this.images[i].title == newTitle) {
                image = this.images[i];
                break;
            }
        }

        for (var i = 0, len = this.images.length; i < len; i++) {
            if (this.images[i].selected) {
                this.images[i].selected = false;
            }
        }

        image.selected = true;
        this.getLargeImage();
    },

    getLargeImage: function () {
        var largeImageIndex = -1;
        for (var i = 0, len = this.images.length; i < len; i++) {
            if (this.images[i].selected) {
                largeImageIndex = i;
                break;
            }
        }

        document.querySelector("#large-image-container img").src = this.images[largeImageIndex].largeImage;
    }
}

var firstImage = Object.create(Image);
firstImage.init("First cat", "images/first-cat.jpg", "images/first-cat-small.jpg");

var secondImage = Object.create(Image);
secondImage.init("Second cat", "images/second-cat.jpg", "images/second-cat-small.jpg");

var thirdImage = Object.create(Image);
thirdImage.init("Third cat", "images/third-cat.jpg", "images/third-cat-small.jpg");

var fourthImage = Object.create(Image);
fourthImage.init("Fourth cat", "images/fourth-cat.jpg", "images/fourth-cat-small.jpg");

var fifthImage = Object.create(Image);
fifthImage.init("Fifth cat", "images/fifth-cat.jpg", "images/fifth-cat-small.jpg");

var imageSlider = Object.create(ImageSlider);
imageSlider.init([firstImage, secondImage, thirdImage, fourthImage, fifthImage]);
imageSlider.appendToDom("#slider-container", "slider");