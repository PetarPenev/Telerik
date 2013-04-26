using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 10 - the helper class explosion wave
    public class ExplosionWave :MovingObject
    {
        public new const char Symbol = '{';

        public ExplosionWave(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { Symbol } }, speed)
        {
        }

        protected override void UpdatePosition()
        {
            this.IsDestroyed = true;
            this.TopLeft +=this.Speed;
            
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }

    }
}
