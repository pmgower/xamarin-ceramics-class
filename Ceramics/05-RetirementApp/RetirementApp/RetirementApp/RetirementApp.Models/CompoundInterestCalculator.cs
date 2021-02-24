using System;

namespace RetirementApp.Models
{
    public static class CompoundInterestCalculator
    {
        // IMPORTANT: not extensively tested
        // From https://www.dotnetperls.com/compound-interest, added monthly contribution
        public static decimal Calculate(decimal principal,
            decimal interestRate,
            int timesPerYear,
            double years,
            decimal monthlyContributionAmount)
        {
            // To accommodate monthly contributions, calculate on a per month basis.    We estimate
            // this from the years parameter
            int months = ((int)years) * 12;
            double partialMonth = years % 12;

            double amount = (double)principal;

            // Calculate the amount  in a monthly loop to allow the application
            // of the monhtly contributions each month
            do
            {
                // (1 + r/n)
                double body = 1 + (double)(interestRate / timesPerYear);

                // nt
                double exponent = timesPerYear * (1.0 / 12); // One month

                // We are out of "whole" months.   Apply any leftover partial monthly amount.
                if (months == 0)
                {
                    exponent = timesPerYear * (1.0 / 12) * partialMonth; // residual of last month
                }

                // P(1 + r/n)^nt
                amount = amount * Math.Pow(body, exponent);

                months--;

                if (months >= 0)
                {
                    amount += (double)monthlyContributionAmount;
                }
            }
            while (months > 0);

            return (decimal)amount;
        }
        
        public static double FutureDateTimeToYears(DateTime targetDate)
        {
            var timeSpan = targetDate - DateTime.Now;
            var years = timeSpan.Days / 365;
            return years < 0 ? 0 : years;
        }
    }
}