namespace _01.Knapsack
{
    public class Item
    {
        private string name;

        private int weight;

        private int cost;

        public Item(string name, int weight, int value)
        {
            this.name = name;
            this.weight = weight;
            this.cost = value;
        }

        public string Name
        {
            get { return this.name; }
        }       

        public int Weight
        {
            get { return this.weight; }
        }       

        public int Cost
        {
            get { return this.cost; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}