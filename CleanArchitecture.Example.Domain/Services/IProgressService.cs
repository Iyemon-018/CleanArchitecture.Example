namespace CleanArchitecture.Example.Domain.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IProgressService
    {
        Task Execute(Action<IProgressMessenger> work);
    }
}