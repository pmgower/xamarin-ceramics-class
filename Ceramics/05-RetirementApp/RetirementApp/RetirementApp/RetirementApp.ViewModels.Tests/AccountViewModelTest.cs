using FluentAssertions;
using RetirementApp.Models;
using Xunit;

namespace RetirementApp.ViewModels.Tests
{
    public class AccountViewModelTest
    {
        [Fact]
        public void Constructor_ValidAccountModel_ExpectSuccess()
        {
            //Setup
            var name = "Account Name 1";
            var balance = 100m;
            var expectedRateOfReturn = 0.1m;
            var contributionAmount = 150m;
            var account = new Account(name, balance, expectedRateOfReturn, contributionAmount);

            //Test
            AccountViewModel viewModel = new AccountViewModel(account);

            //Assert
            viewModel.Name.Should().Be(account.Name);
            viewModel.Balance.Should().Be(account.Balance.ToString("C"));
            viewModel.ExpectedRateOfReturn.Should().Be(account.ExpectedRateOfReturn.ToString("P"));
            viewModel.ContributionAmount.Should().Be(account.ContributionAmount.ToString("C"));
        }
    }
}