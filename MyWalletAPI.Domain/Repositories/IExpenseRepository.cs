using MyWalletAPI.Domain.Entities;

namespace MyWalletAPI.Domain.Repositories;

public interface IExpenseRepository
{
    void Create(Expense expense);
    void Update(Expense expense);
    Expense GetById(Guid id, string user);
    IEnumerable<Expense> GetAll();
    IEnumerable<Expense> GetAllByUser(string user);
}