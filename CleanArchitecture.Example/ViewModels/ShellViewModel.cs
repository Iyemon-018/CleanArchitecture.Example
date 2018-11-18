using System;
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
            QuestionDialogCommand = new DelegateCommand(async () =>
                                                        {
                                                            var result = await dialogService.Question(DialogData.Build("Test"
                                                                                                  , $"終了します。{Environment.NewLine}"
                                                                                                    + $"よろしいですか。"));
                                                            if (result)
                                                            {
                                                                App.Current.Shutdown();
                                                            }
                                                        });
            ErrorDialogCommand = new DelegateCommand(async () =>
                                                     {
                                                         await dialogService.Error(DialogData.Build("Test"
                                                                                                  , "エラーです。これはエラーであることを示しています。"));
                                                     });
        }

        public ICommand InformationDialogCommand { get; private set; }

        public ICommand QuestionDialogCommand { get; private set; }

        public ICommand ErrorDialogCommand { get; private set; }
    }
}