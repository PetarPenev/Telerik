module("Food.Init");
test("Test the constructor of the food.", function () {
    var position = {
        x: 100,
        y: 100
    };

    var size = 10;
    var food = new snakeGame.Food(position, size);

    equal(food.position.x, position.x, "X coordinate is set.");
    equal(food.position.y, position.y, "Y coordinate is set.");
    equal(food.size, size, "Size is set.");
});

test("Test the constructor of the food with different set of arguments.", function () {
    var position = {
        x: 210,
        y: -50
    };

    var size = 1;
    var food = new snakeGame.Food(position, size);

    equal(food.position.x, position.x, "X coordinate is set.");
    equal(food.position.y, position.y, "Y coordinate is set.");
    equal(food.size, size, "Size is set.");
});

module("Food.ChangePosition");
test("Change the position once with a set of new coordinates.", function () {
    var position = {
        x: 100,
        y: 100
    };

    var size = 10;
    var food = new snakeGame.Food(position, size);

    var newPosition = {
        x: 50,
        y: 50
    };

    food.changePosition(newPosition);

    equal(food.position.x, newPosition.x, "X coordinate is correctly changed.");
    equal(food.position.y, newPosition.y, "Y coordinate is correctly changed.");
});

test("Change the position with a set of new coordinates and then return to the old position.", function () {
    var position = {
        x: 100,
        y: 100
    };

    var size = 10;
    var food = new snakeGame.Food(position, size);

    var newPosition = {
        x: 50,
        y: 50
    };

    food.changePosition(newPosition);

    equal(food.position.x, newPosition.x, "X coordinate is correctly changed.");
    equal(food.position.y, newPosition.y, "Y coordinate is correctly changed.");

    food.changePosition(position);

    equal(food.position.x, position.x, "X coordinate is correctly returned to old value.");
    equal(food.position.y, position.y, "Y coordinate is correctly returned to old value.");
});