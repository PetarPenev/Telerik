// Some helper functions that are used to "protect" the constructors - an example of defensive
// programming in JavaScript.
function isPropulsionUnitArrayOk(propulsionUnits) {
    for (var i = 0, len = propulsionUnits.length; i < len; i++) {
        if (!(propulsionUnits[i] instanceof propulsions.PropulsionUnit)) {
            return false;
        }
    }

    return true;
}

function hasAmphibianPropulsionUnits(propulsionUnits) {
    var hasPropeller = false;
    var hasMultiplePropellers = false;
    var hasWheel = false;
    for (var i = 0, len = propulsionUnits.length; i < len; i++) {
        if (propulsionUnits[i] instanceof propulsions.Wheel) {
            hasWheel = true;
        }
        else {
            if (propulsionUnits[i] instanceof propulsions.Propeller) {
                if (hasPropeller) {
                    hasMultiplePropellers = true;
                    break;
                }
                hasPropeller = true;
            }
        }
    }

    var isConstructorOk = (hasPropeller && hasWheel && !hasMultiplePropellers);
    return isConstructorOk;
}

function areVehiclePropulsionsOk(propulsionUnits) {
    for (var i = 0, len = propulsionUnits.length; i < len; i++) {
        if (!(propulsionUnits[i] instanceof propulsions.Wheel)) {
            return false;
        }
    }

    return true;
}

var vehicles = (function () {
    var LAND_VEHICLE_WHEEL_NUMBER = 4;

    var amphibianMode = {
        "land": "land",
        "water": "water"
    }

    if (Object.freeze) {
        Object.freeze(amphibianMode);
    }

    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    function LandVehicle(speed, propulsionUnits) {
        // It may seem that all this checks should be in the parent class Vehicle. However, due to the peculiarities
        // of JavaScript if we inherit a class in a closure, during inheritance all its prototype functions are actually being
        // run with an undefined this argument. Thus, for example, the check whether something is a number cannot function 
        // properly and will throw an error before even the first instantiation of the "class" is made.
        if (!(isNumberParameterOk(speed))) {
            throw new Error("The speed parameter should be a positive number.");
        }

        if (!(isPropulsionUnitArrayOk(propulsionUnits))) {
            throw new Error("The propulsionUnits parameter should be an array of propulsion units.");
        }

        if ((propulsionUnits.length != LAND_VEHICLE_WHEEL_NUMBER) || !(areVehiclePropulsionsOk(propulsionUnits))) {
            throw Error("Land vehicles should have four wheels.");
        }

        Vehicle.apply(this, [speed, propulsionUnits]);
    }

    LandVehicle.inherit(Vehicle);

    function AirVehicle(speed, propulsionUnits) {
        if (!(isNumberParameterOk(speed))) {
            throw new Error("The speed parameter should be a positive number.");
        }

        if (!(isPropulsionUnitArrayOk(propulsionUnits))) {
            throw new Error("The propulsionUnits parameter should be an array of propulsion units.");
        }

        if ((propulsionUnits.length != 1) || !(propulsionUnits[0] instanceof propulsions.PropellingNozzle)) {
            throw Error("Aird vehicles should have one propelling nozzle.");
        }

        Vehicle.apply(this, [speed, propulsionUnits]);
    }

    AirVehicle.inherit(Vehicle);

    AirVehicle.prototype.switchAfterburners = function (afterburnerState) {
        this.propulsionUnits[0].afterburnerSwitch = afterburnerState;
    }

    function WaterVehicle(speed, propulsionUnits) {
        if (!(isNumberParameterOk(speed))) {
            throw new Error("The speed parameter should be a positive number.");
        }

        if (!(isPropulsionUnitArrayOk(propulsionUnits))) {
            throw new Error("The propulsionUnits parameter should be an array of propulsion units.");
        }

        for (var i = 0, len = propulsionUnits.length; i < len; i++) {
            if (!(propulsionUnits[i] instanceof propulsions.Propeller)) {
                throw Error("Water vehicles can have only propellers.");
            }
        }

        Vehicle.apply(this, [speed, propulsionUnits]);
    }

    WaterVehicle.inherit(Vehicle);

    WaterVehicle.prototype.changeDirection = function (spinDirection) {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].spinDirection = spinDirection;
            }
        }
    }

    function AmphibianVehicle(speed, propulsionUnits, mode) {
        if (!(isNumberParameterOk(speed))) {
            throw new Error("The speed parameter should be a positive number.");
        }

        if (!(isPropulsionUnitArrayOk(propulsionUnits))) {
            throw new Error("The propulsionUnits parameter should be an array of propulsion units.");
        }

        if (!(hasAmphibianPropulsionUnits(propulsionUnits))) {
            throw Error("The amphibian vehicle should have both a propeller and wheels.");
        }

        Vehicle.apply(this, [speed, propulsionUnits]);
        this.mode = mode;
    }

    AmphibianVehicle.inherit(Vehicle);
    AmphibianVehicle.extend(WaterVehicle, "changeDirection");

    AmphibianVehicle.prototype.accelerate = function () {
        if (this.mode == amphibianMode.land) {
            for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
                if (this.propulsionUnits[i] instanceof propulsions.Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
        else {
            for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
                if (this.propulsionUnits[i] instanceof propulsions.Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }

    return {
        LandVehicle: LandVehicle,
        WaterVehicle: WaterVehicle,
        AirVehicle: AirVehicle,
        AmphibianVehicle: AmphibianVehicle
    }
})();