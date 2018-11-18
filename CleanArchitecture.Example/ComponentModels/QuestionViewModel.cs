﻿using CleanArchitecture.Example.Domain.Services;
using CleanArchitecture.Example.ViewModels;

namespace CleanArchitecture.Example.ComponentModels
{
    public class QuestionViewModel : ViewModelBase
    {
        public QuestionViewModel()
        {

        }
        public QuestionViewModel(IDialogData dialogData)
        {
            _caption = dialogData.Caption;
            _message = dialogData.Message;
        }

        private string _caption;

        public string Caption
        {
            get => _caption;
            private set => SetProperty(ref _caption, value);
        }

        private string _message;

        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }
    }
}