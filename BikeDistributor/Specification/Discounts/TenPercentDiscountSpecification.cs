namespace BikeDistributor.Specification.Discounts
{
    /// <summary>
    /// Specification for 10% discount
    /// </summary>
    public class TenPercentDiscountSpecification : DiscountSpecification
    {
        /// <summary>
        /// Number of items, when discount starts to work
        /// </summary>
        protected const int QuantityForDiscount = 20;
        
        /// <summary>
        /// Discount coefficient
        /// </summary>
        protected const double DiscountCoefficient = 0.9d;

        public TenPercentDiscountSpecification(Line line) : base(line)
        {
            if (IsSatisfied())
                DiscountValue = DiscountCoefficient;

        }

        /// <summary>
        /// Returs true if the specification matches the critirea, otherwise returns false
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied()
        {
            return (Quantity >= QuantityForDiscount && 
                    Price == Bike.OneThousand);
        }
    }
}
