namespace KnapsackProblem
{
    using System;

    public struct Product
    {
        private const string InvalidNameNullExceptionMessage = "Name cannot be null.";
        private const string InvalidNameEmptyStringExceptionMessage = "Name cannot be an empty string.";
        private const string InvalidProductWeightValue = "The product weight cannot be less than {0}.";
        private const int ProductWeightMinimumValue = 0;
        private const string InvalidProductPrice = "The product price cannot be less than {0}.";
        private const int ProductPriceMinimumValue = 0;

        private string name;
        private int weight;
        private int price;

        /// <summary>
        /// Creates instance of Product class with initial name, weight and price
        /// </summary>
        /// <param name="name">Initial name of the product</param>
        /// <param name="weight">Initial weight of the product</param>
        /// <param name="price">Initial price of the product</param>
        public Product(string name, int weight, int cost)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = cost;
        }

        /// <summary>
        /// Gets and sets the product name
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
                    throw new ArgumentNullException(InvalidNameNullExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(InvalidNameEmptyStringExceptionMessage);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets the product weight
        /// </summary>
        public int Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value < ProductWeightMinimumValue)
                {
                    string errorMessage = string.Format(InvalidProductWeightValue, ProductWeightMinimumValue);
                    throw new ArgumentOutOfRangeException(errorMessage);
                }

                this.weight = value;
            }
        }

        /// <summary>
        /// Gets and sets the product price
        /// </summary>
        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < ProductPriceMinimumValue)
                {
                    string errorMessage = string.Format(InvalidProductPrice, ProductPriceMinimumValue);
                    throw new ArgumentOutOfRangeException(errorMessage);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} -> Weight = {1} | Price = {2}", this.Name, this.Weight, this.Price);
        }
    }
}
