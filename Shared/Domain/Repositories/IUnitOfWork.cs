namespace Security.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}