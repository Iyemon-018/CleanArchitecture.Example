namespace CleanArchitecture.Example.Domain.Services
{
    public class DialogData : IDialogData
    {
        public string Caption { get; }

        public string Message { get; }

        internal DialogData(string caption, string message)
        {
            Caption = caption;
            Message = message;
        }

        public static IDialogData Build(string caption, string message) => new DialogData(caption, message);
    }
}