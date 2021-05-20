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
    /// Represents the process of determining the sales quote of a vehicle.
    /// </summary>
    public class SalesQuote
    {
        /// <summary>
        /// Fields needed to create the sales quote.
        /// </summary>
        private decimal vehicleSalePrice, tradeInAmount, salesTaxRate;
        private Accessories accessoriesChosen;
        private ExteriorFinish exteriorFinishChosen;

        /// <summary>
        /// Gets and sets the sale price of the vehicle.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when  the property is set to less than or equal to 0.</exception>
        public decimal VehicleSalePrice
        {
            get
            {
                return this.vehicleSalePrice;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value","The value cannot be less than or equal to 0.");
                }
                else
                {
                    this.vehicleSalePrice = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the trade in amount.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when  the property is set to less than or equal to 0.</exception>
        public decimal TradeInAmount
        {
            get
            {
                return this.tradeInAmount;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value cannot be less than 0.");
                }
                else
                {
                    this.tradeInAmount = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the accessories that were chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Throw the property is set to an invalid value.</exception>
        public Accessories AccessoriesChosen
        {
            get
            {
                return accessoriesChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(Accessories), value))
                {
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
                }
                else
                {
                    accessoriesChosen = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the exterior finish that was chosen.
        /// </summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Throw the property is set to an invalid value.</exception>
        public ExteriorFinish ExteriorFinishChosen
        {
            get
            {
                return exteriorFinishChosen;
            }

            set
            {
                if (!Enum.IsDefined(typeof(ExteriorFinish), value))
                {
                    throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
                }
                else
                {
                    exteriorFinishChosen = value;
                }
            }
        }

        /// <summary>
        /// Gets the cost of accessories chosen.
        /// </summary>
        public decimal AccessoriesCost
        {
            get
            {
                decimal stereoSystem = 505.05M, leatherInterior = 1010.10M, computerNavigation = 1515.15M;
                
                if (this.accessoriesChosen == Accessories.StereoSystem)
                {
                    return stereoSystem;
                }
                else if (this.accessoriesChosen == Accessories.LeatherInterior)
                {
                    return leatherInterior;
                }
                else if (this.accessoriesChosen == Accessories.ComputerNavigation)
                {
                    return computerNavigation;
                }
                else if (this.accessoriesChosen == Accessories.LeatherAndNavigation)
                {
                    return leatherInterior + computerNavigation;
                }
                else if (this.accessoriesChosen == Accessories.StereoAndLeather)
                {
                    return stereoSystem + leatherInterior;
                }
                else if (this.accessoriesChosen == Accessories.StereoAndNavigation)
                {
                    return stereoSystem + computerNavigation;
                }
                else if (this.accessoriesChosen == Accessories.All)
                {
                    return stereoSystem + leatherInterior + computerNavigation;
                }
                else
                {
                    return 0.00M;
                }
            }
        }
        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal FinishCost
        {
            get
            {
                decimal pearlized = 404.04M, custom = 606.06M, standard = 202.02M;
                if (this.exteriorFinishChosen == ExteriorFinish.Custom)
                {
                    return custom;
                }
                else if (this.exteriorFinishChosen == ExteriorFinish.Pearlized)
                {
                    return pearlized;
                }
                else if (this.exteriorFinishChosen == ExteriorFinish.Standard)
                {
                    return standard;
                }
                else
                {
                    return 0.00M;
                }
            }
            
        }

        /// <summary>
        /// Gets the sum of the vehicle’s sale price and the Accessory and Finish Cost (rounded to two decimal places).
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return Math.Round(this.VehicleSalePrice + this.AccessoriesCost + this.FinishCost, 2);
            }
            
        }

        /// <summary>
        /// Gets the amount of tax to charge based on the subtotal (rounded to two decimal places).
        /// </summary>
        public decimal SalesTax
        {
            get
            {
                return Math.Round(this.salesTaxRate * this.SubTotal, 2);
            }
        }

        /// <summary>
        /// Gets the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                return Math.Round(this.SubTotal + this.SalesTax, 2);
            }
        }

        /// <summary>
        /// Gets the result of subtracting the trade-in amount from the total (rounded to two decimal places).
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                return Math.Round(this.Total - this.tradeInAmount, 2);
            }
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in value, sales tax rate, 
        /// accessories chosen and exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">Sale price of the vehicle.</param>
        /// <param name="tradeInAmount">Value trade-in.</param>
        /// <param name="salesTaxRate">Sales tax rate.</param>
        /// <param name="accessoriesChosen">Chosen accessories.</param>
        /// <param name="exteriorFinishChosen">Chosen exterior finish.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the vehicle sale price, trade in amount, and sales tax rate is less than or equal to 0, or when sales tax rate is greater than 1.</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">Throw when the value is an invalid enumeration value.</exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate, Accessories accessoriesChosen, ExteriorFinish exteriorFinishChosen)
        {
            if (this.vehicleSalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice", "The argument cannot be less than or equal to 0.");
            }
            else if (this.tradeInAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount", "The argument cannot be less than or equal to 0.");
            }
            else if (this.salesTaxRate <= 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be less than or equal to 0.");
            }
            else if (this.salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be greater than 1.");
            }
            else if (!Enum.IsDefined(typeof(Accessories), accessoriesChosen))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
            }
            else if (!Enum.IsDefined(typeof(ExteriorFinish), exteriorFinishChosen))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException("The value is an invalid enumeration value.");
            }
            else
            {
                this.vehicleSalePrice = vehicleSalePrice;
                this.tradeInAmount = tradeInAmount;
                this.salesTaxRate = salesTaxRate;
                this.accessoriesChosen = accessoriesChosen;
                this.exteriorFinishChosen = exteriorFinishChosen;
            }
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in amount, sales tax rate, 
        /// no accessories chosen and no exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">The Sale price of the vehicle.</param>
        /// <param name="tradeInAmount">The value of the vehicle trade-in.</param>
        /// <param name="salesTaxRate">The sales tax rate.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when the vehicle sale price, trade in amount, and sales tax rate is less than or equal to 0, and sales tax rate is greater than 1.</exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate)
        {
            if (this.vehicleSalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice", "The argument cannot be less than or equal to 0.");
            }
            else if (this.tradeInAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount", "The argument cannot be less than or equal to 0.");
            }
            else if (this.salesTaxRate <= 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be less than or equal to 0.");
            }
            else if (this.salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate", "The argument cannot be greater than 1.");
            }
            else
            {
                this.vehicleSalePrice = vehicleSalePrice;
                this.tradeInAmount = tradeInAmount;
                this.salesTaxRate = salesTaxRate;
                accessoriesChosen = Accessories.None;
                exteriorFinishChosen = ExteriorFinish.None;
            }
        }
    }
}
