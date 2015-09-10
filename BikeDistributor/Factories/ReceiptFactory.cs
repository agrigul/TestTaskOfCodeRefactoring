using System;
using System.Linq;
using System.Text;

namespace BikeDistributor.Factories
{
    /// <summary>
    /// Facatory wich creates receipts
    /// </summary>
    public class ReceiptReportFactory : IReceiptReportFactory
    {        

        /// <summary>
        /// Creates text  receipt
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public string CreateTextReceipt(Order order)
        {            
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", order.CompanyName, Environment.NewLine));

            foreach (var line in order.LinesList)
            {
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}",
                                                    line.Quantity,
                                                    line.Bike.Brand,
                                                    line.Bike.Model,
                                                    line.Amount.ToString("C")));
            }

            result.AppendLine(string.Format("Sub-Total: {0}", order.TotalAmountWithoutTax.ToString("C")));
            result.AppendLine(string.Format("Tax: {0}", order.TaxAmount.ToString("C")));
            result.Append(string.Format("Total: {0}", order.TotalAmount.ToString("C")));

            return result.ToString();
        }


        /// <summary>
        /// Creates HTML formatted receipt
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public string CreateHtmlReceipt(Order order)
        {

            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", order.CompanyName));
            if (order.LinesList.Any())
            {
                result.Append("<ul>");
                foreach (var line in order.LinesList)
                {
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>",
                                                    line.Quantity,
                                                    line.Bike.Brand,
                                                    line.Bike.Model,
                                                    line.Amount.ToString("C")));
                }
                result.Append("</ul>");
            }

            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", order.TotalAmountWithoutTax.ToString("C")));
            result.Append(string.Format("<h3>Tax: {0}</h3>", order.TaxAmount.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", order.TotalAmount.ToString("C")));
            result.Append("</body></html>");

            return result.ToString();
        }        
    }
}
