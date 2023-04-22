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

    public IEnumerable<Expense> GetAll()
    {
        return _context.Expenses
            .AsNoTracking()
            .OrderBy(x => x.DueDate);
    }
    
    public IEnumerable<Expense> GetAllByUser(string user)
    {
        return _context.Expenses
            .AsNoTracking()
            .Where(x => x.UserId == user)
            .OrderBy(x => x.DueDate);
    }
}