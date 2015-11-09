namespace FindProductInRange
{
    using System;
    
    public class Product : IComparable<Product>
    {
        private const string InvalidPriceExceptionMessage = "Price must be a positive number.";

        private string name;
        private decimal price;

        /// <summary>
        /// Creates new instance of Product class
        /// </summary>
        /// <param name="name">Initial name of the product</param>
        /// <param name="price">Initial price of the product</param>
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets and sets name of the product
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets price of the product
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(InvalidPriceExceptionMessage);
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Define logic for compare two products -> compare them by price
        /// </summary>
        /// <param name="other">Product to be compared</param>
        /// <returns>
        /// Returns -1 if the price of first product is smaller than price of the second.
        /// Returns 0 if the price of first product is equal to the second.
        /// Returns 1 if the price of first product is larger than the price of the second.
        /// </returns>
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
