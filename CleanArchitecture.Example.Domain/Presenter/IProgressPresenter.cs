namespace CleanArchitecture.Example.Domain.Presenter
{
    public interface IProgressPresenter
    {
        void SetMessage(string message);

        void UpdateValue(int value);

        bool IsCanceled { get; }

        void Initialize(int maximum);
    }
}