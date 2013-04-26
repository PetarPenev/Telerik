using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 11 - moving object that only falls down
    public class Gift :MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '$' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (string collisionItem in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionItem.Equals(Racket.CollisionGroupString))
                {
                    this.IsDestroyed = true;
                }
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                ShootingRacket newRacket = new ShootingRacket(new MatrixCoords(topLeft.Row, topLeft.Col), 6);
                List<GameObject> shooterList = new List<GameObject>();
                shooterList.Add(newRacket);
                return shooterList;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
