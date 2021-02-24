using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace RetirementApp.Models.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void Constructor_ValidParams_ExpectsSuccess()
        {
            //Setup
            List<Account> accounts = new List<Account>()
            {
                new Account(name: "Savings Account 2", balance: 2000m, expectedRateOfReturn: 0.025m, contributionAmount: 200m),
                new Account(name: "401k Account", balance: 2000m, expectedRateOfReturn: 0.08m, contributionAmount: 500m),
                new Account(name: "Roth IRA", balance: 2000m, expectedRateOfReturn: 0.1m, contributionAmount: 300m)
            };
            
            //Test
            Calculator calculator = new Calculator(accounts);

            //Assertion
            // calculator.TargetDate.Should().BeCloseTo(DateTime.Now + TimeSpan.FromDays(365 * 10), 5000);
            calculator.TargetDate.Should().BeCloseTo(DateTime.Now.AddYears(10), precision: 5000);
            calculator.Accounts.Count.Should().Be(accounts.Count);
            accounts.ForEach(account =>
            {
                calculator.Accounts.Should().Contain(account);
            });
        }

        [Theory]
        [InlineData("07/01/2021")]
        [InlineData("08/01/2021")]
        [InlineData("09/01/2021")]
        [InlineData("12/01/2021")]
        public void TargetDate_SetInvalidData_ExpectArgumentOutOfRangeException(string dateAsString)
        {
            //Setup
            var date = DateTime.Parse(dateAsString);
            var calculator = new Calculator(new List<Account>());

            //Test
            Action testAction = () =>
            {
                calculator.TargetDate = date;
            };

            //Assertion
            testAction.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("07/01/2031")]
        [InlineData("08/01/2031")]
        [InlineData("09/01/2031")]
        [InlineData("12/01/2031")]
        public void TargetDate_SetValidData_ExpectAssigned(string dateAsString)
        {
            //Setup
            var date = DateTime.Parse(dateAsString);
            var calculator = new Calculator(new List<Account>());

            //Test
            calculator.TargetDate = date;

            //Assertion
            calculator.TargetDate.Should().Be(date);
        }

        [Fact]
        public void CurrentBalance_SeveralAccounts_ExpectsSummation()
        {
            //Setup
            var balance1 = 123.45m;
            var balance2 = 678.90m;
            var balance3 = 987.65m;
            var accounts = new List<Account>()
            {
                new Account("Test Account 1", balance1, 0.1m, 100m),
                new Account("Test Account 2", balance2, 0.1m, 100m),
                new Account("Test Account 3", balance3, 0.1m, 100m)
            };
            
            //Test
            var calculator = new Calculator(accounts);

            //Assertion
            calculator.CurrentBalance.Should().Be(balance1 + balance2 + balance3);
        }

        [Fact]
        public void BalanceAtTargetDate_OneValidAccount_ExpectsValidCalculation()
        {
            //Setup
            var balance1 = 123.45m;
            var accounts = new List<Account>()
            {
                new Account("Test Account 1", balance1, 0.1m, 100m)
            };
            var targetDate = DateTime.Now.AddYears(2);
            var expectedBalanceAtTargetDate = accounts.First().FutureBalance(targetDate);
            // var expectedBalanceAtTargetDate = accounts.Sum(account => account.FutureBalance(targetDate));
            var calculator = new Calculator(accounts);
            
            //Test
            calculator.TargetDate = targetDate;
            
            //Assert
            calculator.BalanceAtTargetDate.Should().Be(expectedBalanceAtTargetDate);
        }

        [Fact]
        public void CurrentBalance_AccountAdded_ExpectUpdatedSummation()
        {
            //Setup
            var balance1 = 123.45m;
            var balance2 = 678.90m;
            var balance3 = 987.65m;
            var accounts = new List<Account>()
            {
                new Account("Test Account 1", balance1, 0.1m, 100m),
                new Account("Test Account 2", balance2, 0.1m, 100m)
            };
            
            //Test
            var calculator = new Calculator(accounts);
            calculator.Accounts.Add(new Account("Test Account 3", balance3, 0.1m, 100m));
            
            //Assert
            calculator.CurrentBalance.Should().Be(balance1 + balance2 + balance3);
        }

        [Fact]
        public void CurrentBalance_AccountBalanceModified_ExpectCurrentBalanceChangedEvent()
        {
            //Setup
            var balance1 = 123.45m;
            var balance2 = 678.90m;
            var accounts = new List<Account>()
            {
                new Account("Test Account 1", balance1, 0.1m, 100m),
                new Account("Test Account 2", balance2, 0.1m, 100m)
            };
            
            //Test
            var calculator = new Calculator(accounts);
            bool wasNotified = false;
            calculator.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(calculator.CurrentBalance))
                {
                    wasNotified = true;
                }
            };
            calculator.Accounts.First().Balance = balance2;

            //Assert
            wasNotified.Should().Be(true);
        }
    }
}