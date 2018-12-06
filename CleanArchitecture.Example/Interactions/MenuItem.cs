namespace CleanArchitecture.Example.Interactions
{
    using Prism.Mvvm;

    public sealed class MenuItem : BindableBase
    {
        private readonly ViewType _viewType;

        private string _name;

        public MenuItem(ViewType viewType)
        {
            _viewType = viewType;
            _name = viewType.ToString();
        }

        public ViewType ViewType => _viewType;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}