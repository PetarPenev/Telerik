using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 13 - shooting racket class
    public class ShootingRacket :Racket
    {
        private bool checkShot = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> missile = new List<GameObject>();
            if (this.checkShot)
            {
                missile.Add(new Bullet(new MatrixCoords(topLeft.Row, topLeft.Col + 2)));
                this.checkShot = false;
            }
            return missile;
        }

        public void Shoot()
        {
            this.checkShot = true;
        }
    }
}
