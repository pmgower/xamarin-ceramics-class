using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using PropertyChanged;

namespace RetirementApp.Models
{
    public class Calculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public readonly ObservableCollection<Account> Accounts = new ObservableCollection<Account>();

        public Calculator(List<Account> accounts)
        {
            Accounts.CollectionChanged += AccountsCollectionChanged;
            accounts.ForEach(account => Accounts.Add(account));
        }

        private void AccountsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newAccounts = e.NewItems?.Cast<Account>().ToList();
            newAccounts?.ForEach(account => account.PropertyChanged += AccountPropertyChanged);
            NotifyBalanceCalculationChanged();
        }

        private void AccountPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyBalanceCalculationChanged();
        }

        private void NotifyBalanceCalculationChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentBalance)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BalanceAtTargetDate)));
        }


        private DateTime targetDate = DateTime.Now.AddYears(10);
        public DateTime TargetDate
        {
            get => targetDate;
            set
            {
                if (value < DateTime.Now.AddYears(1))
                {
                    throw new ArgumentOutOfRangeException("Target Date should be greater than a year");
                }

                targetDate = value;
            }
        }

        public decimal CurrentBalance => Accounts.Sum(account => account.Balance);

        [DependsOn(nameof(TargetDate))]
        public decimal BalanceAtTargetDate => Accounts.Sum(account => account.FutureBalance(targetDate));
    }
}