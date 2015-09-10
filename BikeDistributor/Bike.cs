using System;

namespace BikeDistributor
{        
    /// <summary>
    /// Class which stores information about Item(Bike)
    /// </summary>
    public class Bike
    {
        // SOLUTION: I supposed that it's some kind of type for business logic and can't be replaced with Amount property in Bike class. 
        // That's why I've left it as const in Bike class. But it's very possible that it have to be a sepratete value object.

        /// <summary>
        /// Bikes for $1000 (type) 
        /// </summary>
        public const int OneThousand = 1000;

        /// <summary>
        /// Bikes for $2000 (type) 
        /// </summary>
        public const int TwoThousand = 2000;

        /// <summary>
        /// Bikes for $5000 (type) 
        /// </summary>
        public const int FiveThousand = 5000;

        public Bike(string brand, string model, int price)
        {
            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException("brand", "brand of bike can't be null or empty");

            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException("model", "model of bike can't be null or empty");

            if (price <= 0)
                throw new ArgumentOutOfRangeException("price", "price of bike can't be zero or less");

            Brand = brand;
            Model = model;
            Price = price;
        }

        /// <summary>
        /// Name of the brand
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Name of the model
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Price of the Bike
        /// </summary>
        public int Price { get; private set; }
    }
}
