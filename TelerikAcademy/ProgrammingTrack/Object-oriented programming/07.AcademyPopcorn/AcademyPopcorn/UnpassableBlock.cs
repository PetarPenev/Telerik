using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 8 - first Unpassable Block that inherits IndestructibleBlock
    public class UnpassableBlock :IndestructibleBlock
    {
        public new const string CollisionGroupString = "UnpassableBlock";
        public new const char Symbol = '&';

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { Symbol } };
        }

        // Overriding the method
        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

    }
}
