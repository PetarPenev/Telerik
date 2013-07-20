namespace _02.ProductsInPriceRange
{
    using System;

    public class Product : IComparable<Product>
    {
        private decimal price;

        private string name;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
