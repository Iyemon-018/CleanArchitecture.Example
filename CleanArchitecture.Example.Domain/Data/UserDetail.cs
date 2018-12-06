namespace CleanArchitecture.Example.Domain.Data
{
    using System;

    public sealed class UserDetail
    {
        public DateTime CreateDateTime { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Masterpiece { get; set; }
    }
}