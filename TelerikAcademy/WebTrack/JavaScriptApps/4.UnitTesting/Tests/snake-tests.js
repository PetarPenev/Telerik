module("Snake.init");
test("When snake is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  ok(snake.pieces,"SnakePieces are created");
  equal(snake.pieces.length, 5,"Five SnakePieces are created");
  ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);
  var size = snake.size;
  snake.consume(new snakeGame.Food());
  var actual = snake.size;
  var expected = size + 1;
  equal(actual, expected);
});

test("When object is SnakePiece, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.SnakePiece());
  ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.Obstacle());
  ok(isDead, "The snake is dead");
});

module("Snake.Grow");
test("When the snake grows, its size should increase by one", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    var snakeSizeBefore = snake.size;
    snake.grow();
    var snakeSizeAfter = snake.size;

    equal(snakeSizeAfter, snakeSizeBefore + 1, "Snake grew correctly.");
});

test("When the snake grows multiple times, its size should increase with the appropriate number", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    var snakeSizeBefore = snake.size;
    snake.grow();
    snake.grow();
    snake.grow();
    snake.grow();
    var snakeSizeAfter = snake.size;

    equal(snakeSizeAfter, snakeSizeBefore + 4, "Snake grew correctly.");
});

module("Snake.AddDieHandler");
test("When you add die handler to the snake, it should be stored correctly.", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    var dieFunction = function () {
        isDead = true;
    };

    snake.addDieHandler(dieFunction);

    equal(1, snake.dieHandlers.length, "Snake die handler correctly added.");
    equal(snake.dieHandlers[0], dieFunction, "Snake die handler correctly initialized.");
});

test("When you add multiple die handlers to the snake, they should be stored correctly.", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;
    var isDeadAgain = false;

    var dieFunction = function () {
        isDead = true;
    };

    var secondDieFunction = function () {
        isDeadAgain = true;
    };

    snake.addDieHandler(dieFunction);
    snake.addDieHandler(secondDieFunction);

    equal(2, snake.dieHandlers.length, "Snake die handlers correctly added.");
    equal(snake.dieHandlers[0], dieFunction, "Snake die handler 1 correctly initialized.");
    equal(snake.dieHandlers[1], secondDieFunction, "Snake die handler 2 correctly initialized.");
});

module("Snake.Die");
test("Single die handler that functions correctly.", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;
    var isDeadAgain = false;

    var dieFunction = function () {
        isDead = true;
    };

    var initialSize = snake.size;

    snake.addDieHandler(dieFunction);
    snake.grow();

    var result = snake.die();

    equal(isDead, true, "Die handler functions correctly.");
    equal(result, initialSize + 1, "Correct score is calculated.");
});

test("Multiple die handlers that functions correctly.", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;
    var isDeadAgain = false;

    var dieFunction = function () {
        isDead = true;
    };

    var secondDieFunction = function () {
        isDeadAgain = true;
    };

    var initialSize = snake.size;

    snake.addDieHandler(dieFunction);
    snake.addDieHandler(secondDieFunction);
    snake.grow();
    snake.grow();
    snake.grow();
    snake.grow();

    var result = snake.die();

    equal(isDead, true, "First die handler functions correctly.");
    equal(isDeadAgain, true, "Second die handler functions correctly.");
    equal(result, initialSize + 4, "Correct score is calculated.");
});