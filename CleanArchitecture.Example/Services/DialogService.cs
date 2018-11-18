using System.Threading.Tasks;
using CleanArchitecture.Example.ComponentModels;
using CleanArchitecture.Example.Components;
using CleanArchitecture.Example.Domain.Services;
using MaterialDesignThemes.Wpf;

namespace CleanArchitecture.Example.Services
{
    public sealed class DialogService : IDialogService
    {
        private readonly object _identifier;

        public DialogService(object identifier)
        {
            _identifier = identifier;
        }

        public Task Information(IDialogData dialogData)
        {
            var dialog = new InformationDialog {DataContext = new InformationViewModel(dialogData)};
            return DialogHost.Show(dialog);
        }

        public Task<bool> Question(IDialogData dialogData)
        {
            throw new System.NotImplementedException();
        }

        public Task Error(IDialogData dialogData)
        {
            throw new System.NotImplementedException();
        }


    }
}