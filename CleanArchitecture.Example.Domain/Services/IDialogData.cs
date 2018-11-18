namespace CleanArchitecture.Example.Domain.Services
{
    public interface IDialogData
    {
        string Caption { get; }

        string Message { get; }
    }
}