using System.Threading.Tasks;

namespace CleanArchitecture.Example.Domain.Services
{
    public interface IDialogService
    {
        Task Information(IDialogData dialogData);

        Task<bool> Question(IDialogData dialogData);

        Task Error(IDialogData dialogData);
    }
}