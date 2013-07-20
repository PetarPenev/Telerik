namespace CookingRoutine
{
    public class Vegetable
    {
        private bool hasBeenPeeled = false;
        private bool isRotten = false;

        public bool HasBeenPeeled
        {
            get { return this.hasBeenPeeled; }
            set { this.hasBeenPeeled = value; }
        }

        public bool IsRotten
        {
            get { return this.isRotten; }
            set { this.isRotten = value; }
        }
    }
}
