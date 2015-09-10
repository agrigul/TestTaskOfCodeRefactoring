using BikeDistributor.Factories;
using BikeDistributor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        IReceiptReportFactory ReceiptFactory { get; set; }
        IDiscountCalculationService DiscountCalcService { get; set; }
        IOrderFactory OrderFactory { get; set; }

        public OrderTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US"); // Fix for my location to display  $ correclty

            ReceiptFactory = new ReceiptReportFactory();
            DiscountCalcService = new DiscountCalculationService();
            OrderFactory = new OrderFactory(DiscountCalcService);
        }


        [TestMethod]
        public void ReceiptOneDefy()
        {
            var linesList = new List<Line>() { new Line(Defy, 1) };
            Order order = OrderFactory.CreateOrder("Anywhere Bike Shop", linesList);
            string result = ReceiptFactory.CreateTextReceipt(order);
            Assert.AreEqual(ResultStatementOneDefy, result);
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void ReceiptOneElite()
        {
            var linesList = new List<Line>() { new Line(Elite, 1) };
            Order order = OrderFactory.CreateOrder("Anywhere Bike Shop", linesList);
            string result = ReceiptFactory.CreateTextReceipt(order);
            Assert.AreEqual(ResultStatementOneElite, result);
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            var linesList = new List<Line>() { new Line(DuraAce, 1) };
            Order order = OrderFactory.CreateOrder("Anywhere Bike Shop", linesList);
            string result = ReceiptFactory.CreateTextReceipt(order);
            Assert.AreEqual(ResultStatementOneDuraAce, result);
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            OrderFactory.RecalculateOrder(order);
            string result = ReceiptFactory.CreateHtmlReceipt(order);
            Assert.AreEqual(HtmlResultStatementOneDefy, result);
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            OrderFactory.RecalculateOrder(order);
            string result = ReceiptFactory.CreateHtmlReceipt(order);
            Assert.AreEqual(HtmlResultStatementOneElite, result);
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            OrderFactory.RecalculateOrder(order);
            string result = ReceiptFactory.CreateHtmlReceipt(order);
            Assert.AreEqual(HtmlResultStatementOneDuraAce, result);
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";
    }
}


