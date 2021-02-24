using System;
using FluentAssertions;
using Xunit;

namespace RetirementApp.Models.Tests
{
    public class AccountTest
    {
        [Fact]
        // public void Method_Description_Assertion()
        public void Constructor_ValidParams_ExpectSuccess()
        {
            //Setup
            var name = "Savings Account 1";
            var balance = 12.20m;
            var expectedRateOfReturn = 0.10m;
            var contributionAmount = 100m;
            
            //Test
            Account account = new Account(name, balance, expectedRateOfReturn, contributionAmount);
            
            //Assertion
            account.Name.Should().Be(name);
            account.Balance.Should().Be(balance);
            account.ExpectedRateOfReturn.Should().Be(expectedRateOfReturn);
            account.ContributionAmount.Should().Be(contributionAmount);
        }

        [Fact]
        public void FutureBalance_1YearForward_ExpectsCorrectFutureBalance()
        {
            //Setup
            var name = "Savings Account 1";
            var balance = 12.20m;
            var expectedRateOfReturn = 0.10m;
            var contributionAmount = 100m;
            DateTime targetDate = DateTime.Now.AddYears(1);
            decimal expectedFutureBalance = CompoundInterestCalculator.Calculate(balance, expectedRateOfReturn, 12,
                CompoundInterestCalculator.FutureDateTimeToYears(targetDate), contributionAmount);
            
            //Test
            Account account = new Account(name, balance, expectedRateOfReturn, contributionAmount);

            //Assertion
            account.FutureBalance(targetDate).Should().Be(expectedFutureBalance);
        }
    }
}