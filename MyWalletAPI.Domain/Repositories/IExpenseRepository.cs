using MyWalletAPI.Domain.Entities;

namespace MyWalletAPI.Domain.Repositories;

public interface IExpenseRepository
{
    void Create(Expense expense);
    void Update(Expense expense);
    void Delete(Expense expense);
    Expense GetById(Guid id);
    IEnumerable<Expense> GetAll();
    IEnumerable<Expense> GetAllByUser(string user);
}