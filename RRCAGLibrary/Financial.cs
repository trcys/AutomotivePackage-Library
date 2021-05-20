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
    /// This static class contains functionality that includes financial functions.
    /// </summary>
    public static class Financial
    {
        /// <summary>
        /// Returns the payment amount for an annuity based on periodic, fixed payments and a fixed interest rate.
        /// </summary>
        /// <param name="rate">The interest rate per period is needed.</param>
        /// <param name="numberOfPaymentPeriods">The total number of payment periods in the annuity is needed.</param>
        /// <param name="presentValue">The present value (or lump sum) that a series of payments to be paid in the future is worth now.</param>
        /// <returns>The payment amount for an annuity based on periodic, fixed payments and a fixed interest rate.</returns>
        public static decimal GetPayment(decimal rate, int numberOfPaymentPeriods, decimal presentValue)
        {
            decimal futureValue = 0, type = 0, payment;

            if (rate < 0)
            {
                throw new ArgumentOutOfRangeException("rate", "The argument cannot be less than 0.");
            }
            else if (rate > 1)
            {
                throw new ArgumentOutOfRangeException("rate", "The argument cannot be greater than 1.");
            }
            else if (numberOfPaymentPeriods <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfPaymentPeriods", "The argument cannot be less than or equal to 0.");
            }
            else if (presentValue <= 0)
            {
                throw new ArgumentOutOfRangeException("presentValue", "The argument cannot be less than or equal to 0.");
            }
            else if (rate == 0)
            {
                payment = presentValue / numberOfPaymentPeriods;
            }
            else
            {
                payment = rate * (futureValue + presentValue * (decimal)Math.Pow((double)(1 + rate), (double)numberOfPaymentPeriods)) /
                              (((decimal)Math.Pow((double)(1 + rate), (double)numberOfPaymentPeriods) - 1) * (1 + rate * type));
            }
            
            return Math.Round(payment, 2);

        }
    }
}
