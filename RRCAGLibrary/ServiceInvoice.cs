using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
    /// This class contains functionality that supports the business process of creating an invoice for the service department.
    /// The ServiceInvoice class derives from the Invoice class.
    /// </summary>
    public class ServiceInvoice : Invoice
    {
        /// <summary>
        /// Gets the amount charged for labour.
        /// </summary>
        public decimal LabourCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount charged for parts.
        /// </summary>
        public decimal PartsCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount charged for shop materials.
        /// </summary>
        public decimal MaterialCost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. 
        /// Provincial Sales Tax is not applied to labour cost. 
        /// </summary>
        /// <returns>The amount of provincial sales tax charged to the customer.</returns>
        public override decimal ProvincialSalesTaxCharged()
        {
            return (this.PartsCost + this.MaterialCost) * base.ProvincialSalesTaxRate;
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        /// <returns>The amount of goods and services tax charged to the customer.</returns>
        public override decimal GoodsAndServicesTaxCharged()
        {
            return (this.LabourCost + this.PartsCost + this.MaterialCost) * base.GoodsAndServicesTaxRate;
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        /// <returns>The subtotal of the Invoice.</returns>
        public override decimal SubTotal()
        {
            return this.LabourCost + this.PartsCost + this.MaterialCost;
        }

        /// <summary>
        /// Gets the total of the Invoice.
        /// </summary>
        public override decimal Total()
        {
            return this.ProvincialSalesTaxCharged() + this.GoodsAndServicesTaxCharged() + this.SubTotal();
        }

        /// <summary>
        /// Initializes an instance of ServiceInvoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer is needed.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer is needed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when rate of provincial tax is less than 0 or greater than 1.
        /// Also throw when rate of goods and services tax is less than 0 or greater than 1.</exception>
        public ServiceInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate) : base (provincialSalesTaxRate, goodsAndServicesTaxRate)
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
            else if(goodsAndServicesTaxRate > 1)
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
        /// Increments a specified cost by the specified amount.
        /// </summary>
        /// <param name="type">The type of cost being incremented.</param>
        /// <param name="amount">The amount the cost is being incremented by.</param>
        /// <exception cref="InvalidEnumArgumentException">Throw when the cost type is an invalid argument.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the amount is less than or equal to 0.</exception>
        public void AddCost(CostType type, decimal amount)
        {
            if (!Enum.IsDefined(typeof(CostType), type))
            {
                throw new InvalidEnumArgumentException("The argument is an invalid enumeration value.");
            }
            else if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "The argument cannot be less than or equal to 0.");
            }
            else
            {
                switch (type)
                {
                    case CostType.Labour:
                        LabourCost += amount;
                        break;
                    case CostType.Material:
                        MaterialCost += amount;
                        break;
                    case CostType.Part:
                        PartsCost += amount;
                        break;
                }
            }
        }
    }
}
