namespace BikeDistributor
{
    /// <summary>
    /// Class which stores information about bike iteself, number of bikes and amount of this purchase
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Bike
        /// </summary>
        public Bike Bike { get; private set; }

        /// <summary>
        /// Number of items
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Amount of the purchase
        /// </summary>
        public double Amount { get; private set; }


        public Line(Bike bike, int quantity)
        {
            if (bike == null)
                throw new System.ArgumentNullException("bike", "entity can't be null in line");

            if (quantity < 0)
                throw new System.ArgumentOutOfRangeException("quantity", "quantity can't be less than zero");

            Bike = bike;
            Quantity = quantity;
        }


        /// <summary>
        /// Set the amount of the purchase
        /// </summary>
        /// <param name="amount"></param>
        public void SetLineAmount(double amount)
        {
            if (amount < 0)
                throw new System.ArgumentOutOfRangeException("amount", "amount can't be less than zero");
                
            Amount = amount;
        }
    }
}
