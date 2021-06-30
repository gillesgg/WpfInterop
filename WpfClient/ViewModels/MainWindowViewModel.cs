using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfClient.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private string  _value1;
        private string  _value2;
        private string  _result;
        private string  _status;
        private bool    _isFree;

        public bool IsFree
        {
            get => _isFree;
            set => SetProperty(ref _isFree, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        public string Value1
        {
            get => _value1;
            set
            {
                SetProperty(ref _value1, value);
                CalculateCommand?.NotifyCanExecuteChanged();
                CalculateCommand1?.NotifyCanExecuteChanged();
            }
        }               
        public string Value2
        {
            get => _value2;
            set
            {
                SetProperty(ref _value2, value);
                CalculateCommand?.NotifyCanExecuteChanged();
                CalculateCommand1?.NotifyCanExecuteChanged();
            }
        }
        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public IRelayCommand CalculateCommand { get; }

        public IRelayCommand CalculateCommand1 { get; }

        public ICommand ExecCommand { get; }

        public MainWindowViewModel()
        {
            ExecCommand = new AsyncRelayCommand(ExecAsync);


            CalculateCommand = new RelayCommand(
                execute: () =>
                {
                    try
                    {

                        var testInterop = new StubClient();
                        var res = testInterop.Add(int.Parse(Value1), int.Parse(Value2));

                        


                        Result = $"{Value1} + {Value2} = {res}";

                    }
                    catch
                    {
                        Result = "Error!";
                    }
                },
                canExecute: () =>
                {
                    return !string.IsNullOrEmpty(Value1) && !string.IsNullOrEmpty(Value2);
                });

            CalculateCommand1 = new RelayCommand(
               execute: () =>
               {
                   try
                   {
                       var testInterop = new StubClient();
                       var res = testInterop.Multiply(int.Parse(Value1), int.Parse(Value2));


                       Result = $"{Value1} * {Value2} = {res}";
                   }
                   catch
                   {
                       Result = "Error!";
                   }
               },
               canExecute: () =>
               {
                   return !string.IsNullOrEmpty(Value1) && !string.IsNullOrEmpty(Value2);
               });
        }



        private async Task ExecAsync()
        {
            IsFree = false;
            Status = "Processing...";


            Task<double> task = Task.Factory.StartNew(() => 
            {
                var testInterop = new StubClient();
                return( testInterop.PI(1000000));
            });

            double Result = await task;

            IsFree = true;
            Status = $"PI result={Result}";
        }
    }
}