namespace BikeDistributor.Factories
{
    /// <summary>
    /// Interface of factory wich creates receipt reports
    /// </summary>
    public interface IReceiptReportFactory
    {
        /// <summary>
        /// Creates receipt as a text for file
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        string CreateTextReceipt(Order order);


        /// <summary>
        /// Creates receipt as HTML formatted control
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        string CreateHtmlReceipt(Order order);
    }
}
