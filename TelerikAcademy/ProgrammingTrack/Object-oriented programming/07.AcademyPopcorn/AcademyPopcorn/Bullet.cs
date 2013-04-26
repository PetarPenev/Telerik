using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 13 - helper Bullet class
    public class Bullet :MovingObject
    {
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '!' } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString==Block.CollisionGroupString 
                || otherCollisionGroupString==UnpassableBlock.CollisionGroupString 
                || otherCollisionGroupString==IndestructibleBlock.CollisionGroupString
                || otherCollisionGroupString == ExplodingBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
