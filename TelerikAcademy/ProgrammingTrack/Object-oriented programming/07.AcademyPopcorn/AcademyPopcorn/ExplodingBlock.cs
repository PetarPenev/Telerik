using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 10 - the exploding block
    public class ExplodingBlock :Block
    {
        public new const char Symbol='e';
        private bool checkHit = false;

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { Symbol } };
        }

        // It is producing explosion waves that have a lifespan of 1 move and destroy blocks around
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (checkHit)
            {
                List<GameObject> explosionWaves = new List<GameObject>();
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(0, -1)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(0, 1)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(1, 0)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(-1, 0)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(1, -1)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(-1, 1)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(-1, -1)));
                explosionWaves.Add(new ExplosionWave(topLeft, new MatrixCoords(1, 1)));
                return explosionWaves;
            }
            else
            {
                return new List<GameObject>();
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.checkHit = true;
            this.ProduceObjects();
        }
    }
}
