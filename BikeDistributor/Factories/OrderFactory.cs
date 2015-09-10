using System;
using System.Collections.Generic;

namespace BikeDistributor.Services
{
    /// <summary>
    /// Factory which creates orders and perfoms manipulations with it like recalculation
    /// </summary>
    public class OrderFactory : IOrderFactory
    {
        /// <summary>
        /// Service, which calculates discounts
        /// </summary>
        private IDiscountCalculationService DiscountCalcService { get; set; }

        public OrderFactory(IDiscountCalculationService discountCalcService) // left just to let existing unit tests work.
        {

            if (discountCalcService == null)
                throw new ArgumentNullException("discountCalcService", "discountCalcService  can't be null");

            DiscountCalcService = discountCalcService;
        }

        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="linesList"></param>
        /// <returns></returns>
        public Order CreateOrder(string companyName, IList<Line> linesList)
        {
            var order = new Order(companyName, linesList);
            RecalculateOrder(order);
            return order;
        }


        /// <summary>
        /// Calculates the total amount, tax and cost of each item with discount
        /// </summary>
        public void RecalculateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("order", "order  can't be null");

            foreach (var line in order.LinesList)
            {
                line.SetLineAmount(DiscountCalcService.CalculateFinalAmount(line));
            }
        }
    }
}
