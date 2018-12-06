namespace CleanArchitecture.Example.Interactions
{
    using System;
    using CleanArchitecture.Example.Domain.Data;
    using Prism.Mvvm;

    public sealed class UserDetailData : BindableBase
    {
        private int _age;

        private DateTime _createDateTime;

        private string _masterpiece;

        private string _name;

        public UserDetailData()
        {

        }

        public UserDetailData(UserDetail userDetail)
        {
            _createDateTime = userDetail.CreateDateTime;
            _name           = userDetail.Name;
            _age            = userDetail.Age;
            _masterpiece    = userDetail.Masterpiece;
        }

        public DateTime CreateDateTime
        {
            get => _createDateTime;
            set => SetProperty(ref _createDateTime, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public string Masterpiece
        {
            get => _masterpiece;
            set => SetProperty(ref _masterpiece, value);
        }
    }
}