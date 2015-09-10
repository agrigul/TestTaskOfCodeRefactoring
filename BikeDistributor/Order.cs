using System.Collections.Generic;
using System;

namespace BikeDistributor
{
    /// <summary>
    /// Class which stores information about Order, all items, taxes and amount
    /// </summary>
    public class Order
    {
        /// <summary>
        ///  Name of the company
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// List of order lines
        /// </summary>
        public readonly IList<Line> LinesList = new List<Line>();
        
        /// <summary>
        ///  Total amount without tax
        /// </summary>        
        public double TotalAmountWithoutTax
        {
            get
            {
                _totalAmountWithoutTax = 0;
                // SOLUTION: while the line.Amount will be updated  (after discount  was applied),
                // the total amount can change in runtime. We have to guaranty that always read latest value of total Amount

                foreach (var item in LinesList)
                {
                    _totalAmountWithoutTax += item.Amount;
                }
                return _totalAmountWithoutTax;
            }
        }

        /// <summary>
        /// Total amount without tax
        /// </summary>
        private double _totalAmountWithoutTax;

        /// <summary>
        /// Total amount with tax
        /// </summary>
        public double TotalAmount
        {
            get
            {
                return TotalAmountWithoutTax + TaxAmount;
            }
        }

        /// <summary>
        /// Rate of the tax
        /// </summary>
        private const double TaxRate = .0725d;

        /// <summary>
        /// Calcualted amount of tax
        /// </summary>
        public double TaxAmount
        {
            get
            {
                return TaxRate * TotalAmountWithoutTax;
            }
        }

        public Order(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                throw new ArgumentNullException("companyName", "company name can't be null or empty");

            CompanyName = companyName;
        }
        
        public Order(string companyName, IList<Line> linesList) : this(companyName)
        {
            if (linesList == null)
                throw new ArgumentNullException("linesList", "list of Lines can't be null");

            LinesList = linesList;
        }

        /// <summary>
        /// Adds new line to order
        /// </summary>
        /// <param name="line"></param>
        public void AddLine(Line line)
        {
            if (line == null)
                throw new ArgumentNullException("line", "null line can't be added to list");

            LinesList.Add(line);
        }
    }    
}
