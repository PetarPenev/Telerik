// The extension functions necessary to mimick inheritance.
Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = this;
}

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
}

function isNumberParameterOk(number) {
    if (!(typeof number === "number")) {
        return false;
    }

    if (number <= 0) {
        return false;
    }

    return true;
}

var propulsions = (function () {
    // A way to mimick enumerations in JavaScript. In order to ensure backwards compatibility, the objects are frozen (meaning, sealed)
    // only if the function is supported.
    var afterburnerSwitchState = {
        "off": "off",
        "on": "on"
    }

    if (Object.freeze) {
        Object.freeze(afterburnerSwitchState);
    }

    var spinDirection = {
        "clockwise": "clockwise",
        "counterclockwise": "counterclockwise"
    }

    if (Object.freeze) {
        Object.freeze(spinDirection);
    }

    function PropulsionUnit() {
    }

    // Implementing functionality in case another developer tries to use the class. We have to return the base class because in
    // the vehicles closure we use polymorphism in order to check whether all members of a propulsions array are
    // propulsion units.
    PropulsionUnit.prototype.getAcceleration = function () {
        throw Error("Propulsion unit is an abstract class, should not be instantiated and does not have acceleration.");
    }

    function Wheel(radius) {
        if (!(isNumberParameterOk(radius))) {
            throw Error("The radius parameter should be a positive number.");
        }

        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        return 2 * Math.PI * this.radius;
    }

    function PropellingNozzle(power, afterburnerSwitch) {
        if (!(isNumberParameterOk(power))) {
            throw Error("The power parameter should be a positive number.");
        }

        this.power = power;
        this.afterburnerSwitch = afterburnerSwitch;
    }

    PropellingNozzle.inherit(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        var acceleration = this.power;
        if (this.afterburnerSwitch == afterburnerSwitchState.on) {
            acceleration *= 2;
        }

        return acceleration;
    }

    function Propeller(finsNumber, spinDirection) {
        if (!(isNumberParameterOk(finsNumber))) {
            throw Error("The finsNumber parameter should be a positive number.");
        }

        this.finsNumber = finsNumber;
        this.spinDirection = spinDirection;
    }

    Propeller.inherit(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        var acceleration = this.finsNumber;
        if (this.spinDirection == spinDirection.counterclockwise) {
            acceleration *= -1;
        }

        return acceleration;
    }

    return {
        PropulsionUnit: PropulsionUnit,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller
    }
})();
