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
    /// This class contains functionality that supports the business process of creating an invoice for the car wash department.
    /// The CarWashInvoice class derives from the Invoice class.
    /// </summary>
    public class CarWashInvoice : Invoice
    {
        /// <summary>
        /// Fields used in this car wash invoice class.
        /// </summary>
        private decimal packageCost, fragranceCost;

        /// <summary>
        /// Gets and sets the amount charged for the chosen package.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the property is set to less than 0.</exception>
        public decimal PackageCost
        {
            get
            {
                return this.packageCost;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else
                {
                    this.packageCost = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen fragrance.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the property is set to less than 0.</exception>
        public decimal FragranceCost
        {
            get
            {
                return this.fragranceCost;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else
                {
                    this.fragranceCost = value;
                }
            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer.
        /// No provincial sales tax is charged for a car wash.
        /// </summary>
        /// <returns>The amount of provincial sales tax charged to the customer.</returns>
        public override decimal ProvincialSalesTaxCharged()
        {
            return this.fragranceCost * base.ProvincialSalesTaxRate;
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        /// <returns>The amount of goods and services tax charged to the customer.</returns>
        public override decimal GoodsAndServicesTaxCharged()
        {
            return (this.fragranceCost + this.packageCost) * base.GoodsAndServicesTaxRate;
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        /// <returns>The subtotal of the Invoice.</returns>
        public override decimal SubTotal()
        {
            return this.fragranceCost + this.packageCost;
        }

        /// <summary>
        /// Gets the total of the Invoice.
        /// </summary>
        public override decimal Total()
        { 
            return this.SubTotal() + this.ProvincialSalesTaxCharged() + this.GoodsAndServicesTaxCharged();
        } 
            
        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods and services tax rates. The package cost and fragrance cost are zero.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the rate of provincial sales tax and goods and services tax rate is less than 0 or greater than 1.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate) : base (provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be greater than 1.");
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
                this.ProvincialSalesTaxRate = provincialSalesTaxRate;
                this.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;
            }
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods, services tax rate, package cost and fragrance cost.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <param name="packageCost">The cost of the chosen package.</param>
        /// <param name="fragranceCost">The cost of the chosen fragrance.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the rate of provincial sales tax and goods and services tax rate is less than 0 or greater than 1.
        /// Also throw when the cost of package and fragrance is less than 0.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate, decimal packageCost, decimal fragranceCost) : base (provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (provincialSalesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be less than 0.");
            }
            else if (provincialSalesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("provincialSalesTaxRate", "The argument cannot be greater than 1.");
            }
            else if (goodsAndServicesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be less than 0.");
            }
            else if (goodsAndServicesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("goodsAndServicesTaxRate", "The argument cannot be greater than 1.");
            }
            else if (packageCost < 0)
            {
                throw new ArgumentOutOfRangeException("packageCost", "The argument cannot be less than 0.");
            }
            else if (fragranceCost < 0)
            {
                throw new ArgumentOutOfRangeException("fragranceCost", "The argument cannot be less than 0.");
            }
            else
            {
                base.ProvincialSalesTaxRate = provincialSalesTaxRate;
                base.GoodsAndServicesTaxRate = goodsAndServicesTaxRate;
                this.PackageCost = packageCost;
                this.FragranceCost = fragranceCost;
            }
        }
    }
}
