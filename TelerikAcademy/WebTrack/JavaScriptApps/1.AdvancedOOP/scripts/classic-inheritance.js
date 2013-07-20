var Class = (function() {
  function createClass(properties) {
      var f = function () {
          //This is an addition to enable super (base) class with inheritance
        if(this._superConstructor){
            this._super = new this._superConstructor(arguments);
            }
      this.init.apply(this, arguments);
    }
    for (var prop in properties) {
      f.prototype[prop] = properties[prop];
    }
    if (!f.prototype.init) {
      f.prototype.init = function() {}
    }
    return f;
  }

  Function.prototype.inherit = function(parent) {
    var oldPrototype = this.prototype;
	var parentPrototype = new parent();
    this.prototype = Object.create(parentPrototype);
    this.prototype._superConstructor = parent;
    for (var prop in oldPrototype) {
      this.prototype[prop] = oldPrototype[prop];
    }
  }

  return {
    create: createClass,
  };
}());