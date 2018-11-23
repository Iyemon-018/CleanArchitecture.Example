namespace CleanArchitecture.Example.Domain.Services
{
    public interface IContentNavigator<in TKey>
    {
        void SetNavigationService(object navigationService);

        void Navigate(TKey key);

        void Navigate(TKey key, object parameter);
    }
}