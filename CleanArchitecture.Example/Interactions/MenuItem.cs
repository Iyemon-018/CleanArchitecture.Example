using Prism.Mvvm;

namespace CleanArchitecture.Example.Interactions
{
    public sealed class MenuItem : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}