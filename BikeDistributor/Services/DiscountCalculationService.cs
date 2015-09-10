using BikeDistributor.Specification.Discounts;
using System.Collections.Generic;

namespace BikeDistributor.Services
{
    /// <summary>
    /// Service which calculates discounts for order line
    /// </summary>
    public class DiscountCalculationService : IDiscountCalculationService
    {
        /// <summary>
        /// List of discount specifications with own criterias
        /// </summary>
        IList<DiscountSpecification> _discountSpecsList;

        public DiscountCalculationService()
        {
            _discountSpecsList = new List<DiscountSpecification>();
        }


        /// <summary>
        /// Calculates the final amount of the line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public double CalculateFinalAmount(Line line)
        {
            DiscountSpecification discountSpec = FindRightDiscountSpec(line);
            return discountSpec.Quantity * discountSpec.Price * discountSpec.DiscountValue;
        }


        /// <summary>
        /// Finds the specification which is setified by the criterias of discount
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private DiscountSpecification FindRightDiscountSpec(Line line)
        {
            if (line == null)
                throw new System.ArgumentNullException("line", "line can't be null");

            _discountSpecsList = new List<DiscountSpecification>()
            {
                new TenPercentDiscountSpecification(line),
                new TwentyPercentDiscountSpecification(line)
                // SOLUTION: register next discount specification here...
            };            

            foreach (var spec in _discountSpecsList)
            {
                if (spec.IsSatisfied())
                    return spec;
            }

            return new NoDiscountSpecification(line);

        }
    }
}
