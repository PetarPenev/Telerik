using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 6 - Create the meteorite ball
    public class MeteoriteBall :Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {

        }

        // overriding ProduceObjects method so that we have the trail
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trailList = new List<TrailObject>();
            trailList.Add(new TrailObject(this.GetTopLeft(),3));
            return trailList;
        }
    }
}
