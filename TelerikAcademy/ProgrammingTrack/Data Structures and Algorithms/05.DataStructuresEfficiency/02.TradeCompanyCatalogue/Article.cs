namespace _02.TradeCompanyCatalogue
{
    using System;

    public class Article : IComparable<Article>
    {
        private string barcode;

        private string vendor;

        private string title;

        private decimal price;

        public Article(string barcode, string title, decimal price, string vendor)
        {
            this.barcode = barcode;
            this.title = title;
            this.price = price;
            this.vendor = vendor;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        public string Title
        {
            get
            {
                return string.Copy(this.title);
            }
        }

        public int CompareTo(Article other)
        {
            if (this.price != other.Price)
            {
                return this.price.CompareTo(other.Price);
            }
            else
            {
                return this.title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return "Product: " + this.title + ", price: " + this.price + ", vendor: " + this.vendor + ", barcode: " + this.barcode;
        }
    }
}
