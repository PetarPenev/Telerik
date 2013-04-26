using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 4 - inherit the engine class
    class InheritedEngine :Engine
    {
        public InheritedEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {

        }
        

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
                (this.playerRacket as ShootingRacket).Shoot();
        }

        protected override void AddRacket(GameObject obj)
        {
            bool check = true, secondCheck=true;
            ShootingRacket l;
            foreach (var c in this.allObjects)
            {
                if ((c is Racket) && !(c is ShootingRacket))
                    check = false;
                else if (c is ShootingRacket)
                    secondCheck = false;
            }
            if (check)
            {
                this.playerRacket = obj as Racket;
                this.AddStaticObject(obj);
            }
            else if (!secondCheck)
            {
                this.playerRacket = obj as ShootingRacket;
                this.AddStaticObject(obj);
            }
        }
    }
}
