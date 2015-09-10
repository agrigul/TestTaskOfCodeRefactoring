namespace BikeDistributor.Specification.Discounts
{
    /// <summary>
    /// Specification when there is no discounts
    /// </summary>
    public class NoDiscountSpecification : DiscountSpecification
    {
        public NoDiscountSpecification(Line line) : base(line)
        {
        }


        /// <summary>
        /// Returs true if the specification matches the critirea, otherwise returns false
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied()
        {
            return (Price > 0 &&
                    Quantity > 0);
        }

    }
}
