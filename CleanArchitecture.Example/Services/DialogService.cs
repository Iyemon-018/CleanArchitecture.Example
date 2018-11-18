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
            return DialogHost.Show(dialog, _identifier);
        }

        public async Task<bool> Question(IDialogData dialogData)
        {
            var dialog = new QuestionDialog {DataContext = new QuestionViewModel(dialogData)};
            return (bool) await DialogHost.Show(dialog, _identifier);
        }

        public Task Error(IDialogData dialogData)
        {
            var dialog = new ErrorDialog {DataContext = new ErrorViewModel(dialogData)};
            return DialogHost.Show(dialog, _identifier);
        }
    }
}