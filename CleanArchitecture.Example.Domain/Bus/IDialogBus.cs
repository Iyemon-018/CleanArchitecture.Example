namespace CleanArchitecture.Example.Domain.Bus
{
    using System;
    using System.Threading.Tasks;
    using Services;

    public interface IDialogBus
    {
        Task Information(IDialogData dialogData);

        Task<bool> Question(IDialogData dialogData);

        Task Error(IDialogData dialogData);

        Task Execute(Action<IProgressMessenger> work);

        Task ExecuteCancellable(Action<IProgressMessenger> work);
    }
}