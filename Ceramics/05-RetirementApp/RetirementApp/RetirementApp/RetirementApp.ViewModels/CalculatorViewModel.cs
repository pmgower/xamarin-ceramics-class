using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using RetirementApp.Models;

namespace RetirementApp.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly Calculator calculator;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<AccountViewModel> Accounts { get; } = new ObservableCollection<AccountViewModel>();
        public string BalanceAtTargetDate => calculator.BalanceAtTargetDate.ToString("C");
        public string CurrentBalance => calculator.CurrentBalance.ToString("C");

        public DateTime TargetDate
        {
            get => calculator.TargetDate;
            set => calculator.TargetDate = value;
        }

        public CalculatorViewModel(Calculator calculator)
        {
            if (calculator != null)
            {
                this.calculator = calculator;
                this.calculator.Accounts.ToList().ForEach(account => Accounts.Add(new AccountViewModel(account)));
                this.calculator.Accounts.CollectionChanged += AccountsOnCollectionChanged;
                
                // this rebroadcasts all events from the backing model to the view model listeners
                // this only works when the model and view model have identical property names
                // start with the explicit breakdown into separate method calls and then reduce to this single line
                calculator.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(sender, args);
            }
            else
            {
                throw new ArgumentNullException(nameof(calculator));
            }
        }

        private void AccountsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Accounts.Clear();
            calculator.Accounts.ToList().ForEach(account => Accounts.Add(new AccountViewModel(account)));
        }
    }
}