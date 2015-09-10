namespace BikeDistributor.Specification.Discounts
{
    /// <summary>
    /// Specification for 20% discount
    /// </summary>
    public class TwentyPercentDiscountSpecification : DiscountSpecification
    {
        /// <summary>
        /// Number of items, when discount starts to work
        /// </summary>
        protected int _quantityForDiscount;

        /// <summary>
        /// Discount coefficient
        /// </summary>
        protected const double DiscountCoefficient = 0.8d;

        public TwentyPercentDiscountSpecification(Line line) : base(line)
        {
            if (IsSatisfied())
            {
                DiscountValue = DiscountCoefficient;
            }
        }

        /// <summary>
        /// Returs true if the specification matches the critirea, otherwise returns false
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied()
        {
            return IsLargeAmountOfTwoThousandBikes() ||
                    IsLargeAmountOfFiveThousandBikes();
                    // SOLUTION: add new discount algorithm methods here...
        }

        /// <summary>
        /// Discount algorithm for two thousand bikes
        /// </summary>
        /// <returns></returns>
        private bool IsLargeAmountOfTwoThousandBikes()
        {
            _quantityForDiscount = 10;
            return Quantity >= _quantityForDiscount && Price == Bike.TwoThousand;
        }


        /// <summary>
        /// Discount algorithm for five thousand bikes
        /// </summary>
        private bool IsLargeAmountOfFiveThousandBikes()
        {
            _quantityForDiscount = 5;
            return Quantity >= _quantityForDiscount && Price == Bike.FiveThousand;
        }


        // SOLUTION: add new discount algorithms here...
    }
}
