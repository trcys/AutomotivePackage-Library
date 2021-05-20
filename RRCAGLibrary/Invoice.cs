using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Tracy Salak
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2021-01-31
 * Updated: 
 */
namespace Salak.Tracy.Business
{
    /// <summary>
    /// This abstract class contains functionality that supports the business process of creating an invoice.
    /// </summary>
    public abstract class Invoice
    {
        /// <summary>
        /// Fields applied to invoice.
        /// </summary>
        private decimal provincialSalesTaxRate, goodsAndServicesTaxRate;

        /// <summary>
        /// Gets and sets the provincial sales tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the value cannot be less than 0 and greater than 1.</exception>
        public decimal ProvincialSalesTaxRate
        {
            get
            {
                return this.provincialSalesTaxRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else if(value > 1)
                {
                    throw new ArgumentOutOfRangeException("value","The value cannot be greater than 1.");
                }
                else
                {
                    this.provincialSalesTaxRate = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the goods and services tax rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the value cannot be less than 0 and greater than 1.</exception>
        public decimal GoodsAndServicesTaxRate
        {
            get
            {
                return this.goodsAndServicesTaxRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else if (value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be greater than 1.");
                }
                else
                {
                    this.goodsAndServicesTaxRate = value;
                }
            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer.
        /// </summary>
        public abstract decimal ProvincialSalesTaxCharged();

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public abstract decimal GoodsAndServicesTaxCharged();

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public abstract decimal SubTotal();

        /// <summary>
        /// Gets the total of the Invoice (Subtotal + Taxes).
        /// </summary>
        public virtual decimal Total()
        {
            return this.SubTotal() + this.ProvincialSalesTaxCharged() + this.GoodsAndServicesTaxCharged();
        }

        /// <summary>
        /// Initializes an instance of Invoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer is needed.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer is needed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the rate of provincial tax is less than 0 or greater than 1.
        /// Also throw when the rate of goods and services tax is less than 0 or greater than 1.</exception>
        public Invoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
        {
            

            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }
            else if(provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate","The argument cannot be greater than 1.");
            }
            else if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be greater than 1.");
            }
            else
            {
                this.provincialSalesTaxRate = provincialSalesTaxRate;
                this.goodsAndServicesTaxRate = goodsAndServicesTaxRate;
            }

        }
    }
}
