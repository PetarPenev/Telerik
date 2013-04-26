using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // 5 task
    public class TrailObject :GameObject
    {
        public new const string CollisionGroupString = "Trail Object";
        public new const char Symbol = 't';
        public uint turns;

        // The new constructor
        public TrailObject(MatrixCoords matrixCoord, uint turns)
            : base(matrixCoord, new char[,] { {Symbol} })
        {
            if (turns == 0)
                throw new ArgumentException("Turns of the trailing object must be a positive integer number.");
            this.turns = turns;
        }

        // overriding update
        public override void Update()
        {
            this.turns -= 1;
            if (this.turns == 0)
                this.IsDestroyed = true;
        }
    }
}
