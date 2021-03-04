using System;
using System.Globalization;
using RetirementApp.Models;

namespace RetirementApp.ViewModels
{
    public class AccountViewModel
    {
        private readonly Account account;
        public AccountViewModel(Account account)
        {
            if (account != null)
            {
                this.account = account;
            }
            else
            {
                throw new ArgumentNullException(nameof(account));
            }
        }

        public string Name
        {
            get => account.Name;
            set => account.Name = value;
        }

        public string Balance
        {
            get => account.Balance.ToString("C");
            set
            {
                try
                {
                    account.Balance = Decimal.Parse(value, NumberStyles.Currency);
                }
                catch (Exception ignored)
                {
                    // intentionally suppressing errors while the user types
                }
            }
        }

        public string ExpectedRateOfReturn
        {
            get => account.ExpectedRateOfReturn.ToString("P");
            set
            {
                try
                {
                    string valueAsNumber = value.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    account.ExpectedRateOfReturn = Decimal.Parse(valueAsNumber) / 100m;
                }
                catch (Exception ignored)
                {
                    // intentionally suppressing errors while the user types
                }
            }
        }

        public string ContributionAmount
        {
            get => account.ContributionAmount.ToString("C");
            set
            {
                try
                {
                    account.ContributionAmount = Decimal.Parse(value, NumberStyles.Currency);
                }
                catch (Exception ignored)
                {
                    // intentionally suppressing errors while the user types
                }
            }
        }
    }
}