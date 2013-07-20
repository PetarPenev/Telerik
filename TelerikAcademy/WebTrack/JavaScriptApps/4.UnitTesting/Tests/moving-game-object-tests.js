module("MovingGameObject.init");
test("Test the constructor of the moving object.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 250;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 10;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(snake.position, position, "Position is set");
    equal(snake.speed, speed, "Speed is set");
    equal(snake.direction, direction, "Direction is set");
    equal(snake.size, size, "Size is set");
    equal(snake.fcolor, fcolor, "Fcolor is set");
    equal(snake.scolor, scolor, "Scolor is set");
});

test("Second test of the constructor with some negative values.", function () {
    var position = {
        x: -10,
        y: 0
    };
    var speed = -5;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 1;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(snake.position, position, "Position is set");
    equal(snake.speed, speed, "Speed is set");
    equal(snake.direction, direction, "Direction is set");
    equal(snake.size, size, "Size is set");
    equal(snake.fcolor, fcolor, "Fcolor is set");
    equal(snake.scolor, scolor, "Scolor is set");
});

module("MovingGameObject.move");
test("Moving object in direction 0.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    position = {
        x: 80,
        y: 100
    };
    snake.move();

    equal(snake.position.x, position.x, "X coordinate is correctly changed.");
    equal(snake.position.y, position.y, "Y coordinate is the same.");
});

test("Moving object in direction 1.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    position = {
        x: 100,
        y: 80
    };
    snake.move();

    equal(snake.position.x, position.x, "X coordinate is the same.");
    equal(snake.position.y, position.y, "Y coordinate is correctly changed.");
});

test("Moving object in direction 2.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 2;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    position = {
        x: 120,
        y: 100
    };
    snake.move();

    equal(snake.position.x, position.x, "X coordinate is correctly changed.");
    equal(snake.position.y, position.y, "Y coordinate is the same.");
});

test("Moving object in direction 3.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 3;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    position = {
        x: 100,
        y: 120
    };
    snake.move();

    equal(snake.position.x, position.x, "X coordinate is the same.");
    equal(snake.position.y, position.y, "Y coordinate is correctly changed.");
});

module("MovingGameObject.changeDirection");
test("Changing direction from 0 to 0 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(0);

    equal(snake.direction, 0, "Direction not changed.");
});

test("Changing direction from 0 to 2 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(2);

    equal(snake.direction, 0, "Direction not changed.");
});

test("Changing direction from 0 to 1 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(1);

    equal(snake.direction, 1, "Direction changed successfully.");
});

test("Changing direction from 0 to 3 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 0;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(3);

    equal(snake.direction, 3, "Direction changed successfully.");
});

test("Changing direction from 1 to 0 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(0);

    equal(snake.direction, 0, "Direction not changed.");
});

test("Changing direction from 1 to 1 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(1);

    equal(snake.direction, 1, "Direction not changed.");
});

test("Changing direction from 1 to 2 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(2);

    equal(snake.direction, 2, "Direction changed successfully.");
});

test("Changing direction from 1 to 3 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 1;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(3);

    equal(snake.direction, 1, "Direction changed successfully.");
});

test("Changing direction from 2 to 0 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 2;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(0);

    equal(snake.direction, 2, "Direction not changed.");
});

test("Changing direction from 2 to 1 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 2;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(1);

    equal(snake.direction, 1, "Direction not changed.");
});

test("Changing direction from 2 to 2 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 2;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(2);

    equal(snake.direction, 2, "Direction changed successfully.");
});

test("Changing direction from 2 to 3 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 2;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(3);

    equal(snake.direction, 3, "Direction changed successfully.");
});

test("Changing direction from 3 to 0 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 3;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(0);

    equal(snake.direction, 0, "Direction not changed.");
});

test("Changing direction from 3 to 1 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 3;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(1);

    equal(snake.direction, 3, "Direction not changed.");
});

test("Changing direction from 3 to 2 - change successful.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 3;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(2);

    equal(snake.direction, 2, "Direction changed successfully.");
});

test("Changing direction from 3 to 3 - no change.", function () {
    var position = {
        x: 100,
        y: 100
    };
    var speed = 20;
    var direction = 3;
    var fcolor = '#fff0aa';
    var scolor = '#aa0fff';
    var size = 5;
    var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    snake.changeDirection(3);

    equal(snake.direction, 3, "Direction changed successfully.");
});