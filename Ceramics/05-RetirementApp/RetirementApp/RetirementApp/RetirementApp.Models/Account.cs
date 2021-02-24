using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RetirementApp.Models
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal ExpectedRateOfReturn { get; set; }
        public decimal ContributionAmount { get; set; }

        public Account(string name, decimal balance, decimal expectedRateOfReturn, decimal contributionAmount)
        {
            Name = name;
            Balance = balance;
            ExpectedRateOfReturn = expectedRateOfReturn;
            ContributionAmount = contributionAmount;
        }

        public decimal FutureBalance(DateTime targetDate) =>
            CompoundInterestCalculator.Calculate(Balance, ExpectedRateOfReturn, 12,
                CompoundInterestCalculator.FutureDateTimeToYears(targetDate), ContributionAmount);
        
    }
}