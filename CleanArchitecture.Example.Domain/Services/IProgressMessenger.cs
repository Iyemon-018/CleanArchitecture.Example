namespace CleanArchitecture.Example.Domain.Services
{
    public interface IProgressMessenger
    {
        string Message { get; set; }

        bool IsCanceled { get; }

        void Initialize(int maximum);

        void UpdateValue(int value);
    }
}