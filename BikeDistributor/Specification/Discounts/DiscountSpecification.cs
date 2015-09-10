using BikeDistributor.Specification;

namespace BikeDistributor
{
    /// <summary>
    /// Abstract class for implementation of logic with discounts
    /// 
    /// // SOLUTION: while number of discounts in common case
    /// is limited to values like 5%, 10%, 20%, 30%, 50%, 70%  then it's more easy to increase number of classes which handle this discounts algoruthms
    /// and manipulate with quantity and price inside
    /// </summary>
    public abstract class DiscountSpecification : ISpecification
    {
        /// <summary>
        /// Default value of coefficient, when there is no any discounts
        /// </summary>
        public const double DefaultDiscountCoefficient = 1d;

        /// <summary>
        /// Value of discount after calculations according to the algorithom and type
        /// </summary>
        public double DiscountValue { get; protected set; }

        /// <summary>
        /// Price of the bike
        /// </summary>
        public double Price { get; protected set; }

        /// <summary>
        /// Number of bikes in line. 
        /// </summary>
        public int Quantity { get; protected set; }

        public DiscountSpecification(Line line)
        {
            if (line == null)
                throw new System.ArgumentNullException("line", "line can't be null");

            Price = line.Bike.Price;
            Quantity = line.Quantity;
            DiscountValue = DefaultDiscountCoefficient;
        }

        /// <summary>
        /// Returs true if the specification matches the critirea, otherwise returns false
        /// </summary>
        /// <returns></returns>
        public abstract  bool IsSatisfied();

    }   
}
