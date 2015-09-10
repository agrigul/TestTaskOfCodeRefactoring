namespace BikeDistributor.Services
{
    /// <summary>
    /// Interface for service which calculates discounts for order line
    /// </summary>
    public interface IDiscountCalculationService
    {
        /// <summary>
        /// Calculates the final amount of the line (purchase)
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        double CalculateFinalAmount(Line line);
    }
}
