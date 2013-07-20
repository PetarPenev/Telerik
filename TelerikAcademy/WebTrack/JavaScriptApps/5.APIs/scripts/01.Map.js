var map;
var City = Class.create({
    init: function (name, lattitude, longitude, population, link) {
        this.name = name;
        this.lattitude = lattitude;
        this.longitude = longitude;
        this.population = population;
    }
});

var currentCity = 0;

var tokyo = new City("Tokyo", 35.7, 139.7, "Population: 13,185,502");
var washington = new City("Washington", 38.8, -77.02, "Population: 6,897,012");
var moscow = new City("Moscow", 55.75, 37.6, "Population: 11,503,501");
var berlin = new City("Berlin", 52.5, 13.4, "Population: 3,292,365");
var johannesburg = new City("Johannesburg", -26.21, 28.05, "Population: 4,434,827");
var rio = new City("Rio de Jeneiro", -22.9, -43.2, "Population: 6,323,037");
var sofia = new City("Sofia", 42.67, 23.3, "Population: 1,241,396");
var ottawa = new City("Ottawa", 45.417, -75.7, "Population: 1,236,324");
var budapest = new City("Budapest", 47.5000, 19.0500, "Population: 1,741,041");
var sidney = new City("Sidney", -33.86, 151.21, "Population: 4,627,345");

var capitals = [tokyo, washington, moscow, berlin, johannesburg, rio, sofia, ottawa, budapest, sidney];

(function visualiseCities() {
    var container = document.getElementById("list-of-capitals");   
    container.onclick = function (ev) {       
        if (ev.target instanceof HTMLAnchorElement) {
            currentCity = parseInt(ev.target.id);
            initialize();
        }
    };

    for (var i = 0; i < capitals.length; i++) {
        container.innerHTML += "<li><a href='#' class='cityLinc' id="+i+">" + capitals[i].name + "</a></li>";
    }
}());

function nextCity() {
    currentCity += 1;
    if (currentCity >= capitals.length) {
        currentCity = 0;
    }
	
    initialize();
};

function prevCity() {
    currentCity -= 1;
    if (currentCity < 0) {
        currentCity = capitals.length-1;
    }
	
    initialize();
};

function initialize() {
    var lattitude = capitals[currentCity].lattitude;
    var longitude = capitals[currentCity].longitude;
    var z = 7;

    var mapOptions = {
        zoom: z,
        center: new google.maps.LatLng(lattitude, longitude),
        mapTypeId: google.maps.MapTypeId.ROADMAP //SATELLITE
    };
	
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var contentString = '<div id="content">' +
     capitals[currentCity].population +
      '</div>';

    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });

    var marker = new google.maps.Marker({
        position: map.getCenter(),
        map: map,
        title: capitals[currentCity].name
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(map, marker);
    });
}

google.maps.event.addDomListener(window, 'load', initialize());

console.log(map);