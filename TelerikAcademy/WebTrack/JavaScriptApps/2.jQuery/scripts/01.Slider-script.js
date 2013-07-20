/// <reference path="jquery-1.10.1.min.js" />

var Slider = {
    init: function (timeToChange, idOfSliderContainer) {
        this.timeToChange = timeToChange;
        this.slides = [];
        this.id = idOfSliderContainer;
        this.currentSlide = 0;
    },

    addSlide: function (slideCode) {
        this.slides.push(slideCode);
    },

    previousSlide: function () {
        var self = this;
        clearInterval(this.interval);

        this.currentSlide--;
        if (this.currentSlide < 0) {
            this.currentSlide = this.slides.length - 1;
        }

        this.renderSlide();
        this.interval = setInterval(function () {
            self.nextSlide();
        }, this.timeToChange);
    },

    nextSlide: function () {
        var self = this;

        clearInterval(this.interval);

        this.currentSlide++;
        if (this.currentSlide == this.slides.length) {
            this.currentSlide = 0;
        }

        this.renderSlide();
        this.interval = setInterval(function () {
            self.nextSlide();
        }, this.timeToChange);
    },


    renderWhole: function () {
        var self = this;

        var container = $("#" + this.id).first();
        container.html = "";
        
        var docFragment = $(document.createDocumentFragment());

        var slideImage = document.createElement("div");
        slideImage.id = "slider-content-container";
        docFragment.append(slideImage);

        var previousButton = $("<button>previous</button> ");
        previousButton.id = "prev-button";
        previousButton.on("click", function () {
            self.previousSlide();
        });

        var nextButton = $("<button>next</button> ");
        nextButton.id = "next-button";
        nextButton.on("click", function () {
            self.nextSlide();
        });

        docFragment.append(previousButton.first());
        docFragment.append(nextButton.first());

        container.append(docFragment);
        self.renderSlide();

        this.interval = setInterval(function () {
            self.nextSlide();
        }, self.timeToChange);
    },

    renderSlide: function () {
        var contentContainer = $("#slider-content-container").first();
        contentContainer.html(this.slides[this.currentSlide]);
    }
}

var slider = Object.create(Slider);
slider.init(5000, "slider-container");
slider.addSlide("<ul><li>1</li><li>2</li><li>3</li>");
slider.addSlide("<div>first</div><div>second</div>");
slider.addSlide("<div>Telerik</div><div>Academy</div>");
slider.renderWhole();