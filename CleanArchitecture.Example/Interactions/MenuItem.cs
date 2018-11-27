namespace CleanArchitecture.Example.Interactions
{
    using System.Windows.Input;
    using Prism.Mvvm;

    public sealed class MenuItem : BindableBase
    {
        private readonly ViewType _viewType;
        private string _name;

        public MenuItem(ViewType viewType)
        {
            _viewType = viewType;
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        public ICommand SelectionCommand { get; set; }
    }
}