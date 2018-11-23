using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using CleanArchitecture.Example.Domain.Services;

namespace CleanArchitecture.Example.Services
{
    public sealed class ContentNavigator : IContentNavigator<ViewType>
    {
        internal static readonly Dictionary<ViewType, Uri> ViewTypeToContentCache;

        static ContentNavigator()
        {
            ViewTypeToContentCache = new Dictionary<ViewType, Uri>
                                     {
                                         {
                                             ViewType.GetCurrentDateTime
                                           , new Uri("Views/GetCurrentDateTimeView.xaml", UriKind.Relative)
                                         }
                                        ,
                                         {
                                             ViewType.DetailDataList
                                           , new Uri("Views/DetailDataListView.xaml", UriKind.Relative)
                                         }
                                     };
        }

        private NavigationService _navigationService;

        public void SetNavigationService(object navigationService) =>
            _navigationService = navigationService is NavigationService s ? s : throw new ArgumentException($"{nameof(navigationService)} は型 : {typeof(NavigationService)} ではありません。", nameof(navigationService));

        public void Navigate(ViewType key)
        {
            Navigate(key, null);
        }

        public void Navigate(ViewType key, object parameter)
        {
            var uri = ViewTypeToContentCache.TryGetValue(key, out var value) ? value : null;
            if (uri == null) throw new InvalidOperationException($"{key} に指定したコンテンツが尊くされていません。");
            _navigationService.Navigate(uri, parameter);
        }
    }
}