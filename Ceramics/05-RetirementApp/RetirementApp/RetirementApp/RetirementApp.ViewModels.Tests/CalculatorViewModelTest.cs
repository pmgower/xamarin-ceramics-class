using System.Collections.Generic;
using FluentAssertions;
using RetirementApp.Models;
using Xunit;

namespace RetirementApp.ViewModels.Tests
{
    public class CalculatorViewModelTest
    {
        [Fact]
        public void Constructor_ValidCalculatorModel_ExpectSuccess()
        {
            //Setup
            var accounts = new List<Account>()
            {
                new Account(name: "Savings Account 2", balance: 2000m, expectedRateOfReturn: 0.025m, contributionAmount: 200m),
                new Account(name: "401k Account", balance: 2000m, expectedRateOfReturn: 0.08m, contributionAmount: 500m),
                new Account(name: "Roth IRA", balance: 2000m, expectedRateOfReturn: 0.1m, contributionAmount: 300m)
            };
            var calculator = new Calculator(accounts);

            //Test
            CalculatorViewModel viewModel = new CalculatorViewModel(calculator);

            //Assert
            viewModel.Accounts.Count.Should().Be(calculator.Accounts.Count);
            viewModel.BalanceAtTargetDate.Should().Be(calculator.BalanceAtTargetDate.ToString("C"));
            viewModel.CurrentBalance.Should().Be(calculator.CurrentBalance.ToString("C"));
            viewModel.TargetDate.Should().Be(calculator.TargetDate);
            
            for (var i = 0; i < calculator.Accounts.Count; ++i)
            {
                viewModel.Accounts[i].Should().BeEquivalentTo(new AccountViewModel(calculator.Accounts[i]));
            }
        }
    }
}