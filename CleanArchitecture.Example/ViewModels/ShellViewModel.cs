using System.Windows.Input;
using CleanArchitecture.Example.Domain.Services;
using Prism.Commands;

namespace CleanArchitecture.Example.ViewModels
{
    public sealed class ShellViewModel : AppViewModelBase
    {
        public static readonly string DialogIdentifier = "DialogHostArea";

        public ShellViewModel(IDialogService dialogService) : base(dialogService)
        {
            InformationDialogCommand = new DelegateCommand(() => dialogService.Information(DialogData.Build("Test", "テスト的に情報メッセージを表示しています。表示されていればOKです。")));
        }

        public ICommand InformationDialogCommand { get; private set; }

        public ICommand QuestionDialogCommand { get; private set; }

        public ICommand ErrorDialogCommand { get; private set; }
    }
}