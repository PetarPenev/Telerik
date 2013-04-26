using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 12 - GiftBlock dropping a gift
    public class GiftBlock :Block
    {
        public new const char Symbol = 'g';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                List<GameObject> droppedGift = new List<GameObject>();
                droppedGift.Add(new Gift(topLeft));
                return droppedGift;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
