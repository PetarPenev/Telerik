if (!Object.create) {
  Object.create = function(obj) {
    function createObject() {};
    createObject.prototype = obj;
    return new createObject();
  }
}

if (!Object.prototype.extend) {
  Object.prototype.extend = function(properties) {
    function createObject() {};
    createObject.prototype = Object.create(this);
    for (var prop in properties) {
      createObject.prototype[prop] = properties[prop];
    }
	createObject.prototype._super = this;
    return new createObject();
  }
}