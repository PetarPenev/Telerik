using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 8- the unstopable ball. It bounces only from unpassable blocks and the racket. 
    // It moves through blocks and indestructible blocks, destroying the simple blocks
    // and leaving the indestructible blocks intact.
    public class UnstopableBall :Ball
    {
        public new const string CollisionGroupString = "UnstoppableBall";
        public new const char Symbol = '@';
        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { Symbol } };
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString==Racket.CollisionGroupString || otherCollisionGroupString==UnpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var c in collisionData.hitObjectsCollisionGroupStrings)
            {
                if ((c==UnpassableBlock.CollisionGroupString) || (c==Racket.CollisionGroupString))
                    base.RespondToCollision(collisionData);
            }
        }
    }
}
