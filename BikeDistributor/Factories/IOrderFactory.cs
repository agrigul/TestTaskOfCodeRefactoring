using System.Collections.Generic;

namespace BikeDistributor.Services
{

    /// <summary>
    /// Interface of factory which creates orders and perfoms manipulations with it like recalculation
    /// </summary>
    public interface IOrderFactory
    {
        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="linesList"></param>
        /// <returns></returns>
        Order CreateOrder(string companyName, IList<Line> linesList);
        
        /// <summary>
        /// Calculates the total amount, tax and cost of each item with discount
        /// </summary>
        void RecalculateOrder(Order order);
    }
}
