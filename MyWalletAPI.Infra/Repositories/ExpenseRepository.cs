using Microsoft.EntityFrameworkCore;
using MyWalletAPI.Domain.Entities;
using MyWalletAPI.Domain.Repositories;
using MyWalletAPI.Infra.Context;

namespace MyWalletAPI.Infra.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DataContext _context;

    public ExpenseRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Expense expense)
    {
        _context.Expenses.Add(expense);
        _context.SaveChanges();
    }

    public void Update(Expense expense)
    {
        _context.Entry(expense).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public Expense GetById(Guid id, string user)
    {
        return _context.Expenses
            .FirstOrDefault(x => x.Id == id && x.UserId == user)!;
    }

    public IEnumerable<Expense> GetAll(string user)
    {
        return _context.Expenses
            .AsNoTracking()
            //.Where(x => x.UserId == "128e916d-9f7e-439f-8844-061ae658dbf1")
            .OrderBy(x => x.DueDate);
    }
}