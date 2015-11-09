namespace TradeCompany
{
    using System;

    public class Product : IComparable<Product>
    {
        private const string InvalidProductNameNullExceptionMessage = "Product name cannot be null.";
        private const string IvalidProductNameEmptyStringExceptionMessage = "Product name cannot be an empty string";
        private const string InvalidPriceExceptionMessage = "Price of the product cannoe be less than ${0}";
        private const int PriceMinimumValue = 0;

        private string name;
        private decimal price;

        /// <summary>
        /// Creates instance of Product class with initial title and price of the product
        /// </summary>
        /// <param name="title">Initial title of the product</param>
        /// <param name="price">Initial price of the product</param>
        public Product(string title, decimal price)
        {
            this.Name = title;
            this.Price = price;
        }

        /// <summary>
        /// Gets and sets the name of the product
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(InvalidProductNameNullExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(IvalidProductNameEmptyStringExceptionMessage);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets the price of the product
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < PriceMinimumValue)
                {
                    string errorMessage = string.Format(InvalidPriceExceptionMessage, PriceMinimumValue);
                    throw new IndexOutOfRangeException(errorMessage);
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Defines logic to compare two product
        /// </summary>
        /// <param name="other">Product to be compared</param>
        /// <returns>Returns the susbtraction between the two prices</returns>
        public int CompareTo(Product other)
        {
            return (int)(this.Price - other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} -> {2:C}", this.GetType().Name, this.Name, this.Price);
        }
    }
}
