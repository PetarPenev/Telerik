using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Task 1 - first the left wall
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(indBlock);
            }

            // Then the right wall
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock indBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols-1));
                engine.AddObject(indBlock);
            }

            // Then the ceiling. 
            // For task 9 I have put Unpassable blocks on the ceiling.
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock indBlock = new UnpassableBlock(new MatrixCoords(0, i));
                engine.AddObject(indBlock);
            }

            // Testing Task 7 by replacing the normal ball with a Meteorite Ball
            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // Testing Task 5
            TrailObject trail = new TrailObject(new MatrixCoords(10, 10), 5);
            engine.AddObject(trail);

            // Task 9 - creating an additional unstopable ball
            Ball theGreatBall = new UnstopableBall(new MatrixCoords(WorldRows / 3, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theGreatBall);

            // Task 12 - testing by adding a Gift and a GiftBlock
            Gift theGift = new Gift(new MatrixCoords(10, 10));
            engine.AddObject(theGift);

            GiftBlock theGiftBlock = new GiftBlock(new MatrixCoords(10, 15));
            engine.AddObject(theGiftBlock);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
