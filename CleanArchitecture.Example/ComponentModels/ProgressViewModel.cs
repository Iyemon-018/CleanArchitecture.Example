namespace CleanArchitecture.Example.ComponentModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using CleanArchitecture.Example.Domain.Services;
    using CleanArchitecture.Example.ViewModels;
    using Prism.Commands;

    public sealed class ProgressViewModel : ViewModelBase, IProgressMessenger
    {
        private bool _isCanceled;

        private int _maximum = 100;

        private string _message;

        private int _value;

        private double _valuePercentage;

        public ProgressViewModel()
        {
            CancelCommand = new DelegateCommand(() => _isCanceled = true);
        }

        public bool IsCanceled => _isCanceled;

        public ICommand CancelCommand { get; private set; }

        public int Maximum
        {
            get => _maximum;
            private set => SetProperty(ref _maximum, value);
        }

        public int Value
        {
            get => _value;
            private set => SetProperty(ref _value, value);
        }

        public double ValuePercentage
        {
            get => _valuePercentage;
            private set => SetProperty(ref _valuePercentage, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public void Initialize(int maximum)
        {
            Value   = 0;
            Maximum = maximum;
        }

        public void UpdateValue(int value)
        {
            Value = value;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            switch (args.PropertyName)
            {
                case nameof(Value):
                    OnValueChanged(Value);
                    break;

                case nameof(Maximum):
                    OnMaximumChanged(Maximum);
                    break;
            }
        }

        private void OnMaximumChanged(int newValue)
        {
            SetProgressPercentage(Value, newValue);
        }

        private void OnValueChanged(int newValue)
        {
            SetProgressPercentage(newValue, Maximum);
        }

        private void SetProgressPercentage(int value, int maximum)
        {
            ValuePercentage = (double)value / (double)maximum;
        }
    }
}