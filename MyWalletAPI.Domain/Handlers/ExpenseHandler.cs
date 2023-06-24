using Flunt.Notifications;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Commands.Contracts;
using MyWalletAPI.Domain.Entities;
using MyWalletAPI.Domain.Enum;
using MyWalletAPI.Domain.Handlers.Requests;
using MyWalletAPI.Domain.Repositories;

namespace MyWalletAPI.Domain.Handlers;

public class ExpenseHandler : Notifiable<Notification>
{
    private readonly IExpenseRepository _repository;

    public ExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }
    
    public ICommandResult Handle(CreateExpenseRequest request)
    {
        if (request.IsValid == false)
            return new GenericCommandResult(false, "Oops, parece que seu registro está errado!", request.Notifications);

        var expense = new Expense(
            request.Category,
            request.Description,
            request.Tag,
            request.Value,
            DateTime.UtcNow,
            DateTime.UtcNow,
            request.Status,
            request.UserId,
            request.Installments,
            request.MethodPayment);

        _repository.Create(expense);

        return new GenericCommandResult(true, "Tarefa salva!", expense);
    }
    
    public ICommandResult Handle(UpdateExpenseRequest request)
    {
        if (request.IsValid == false)
            return new GenericCommandResult(false, "Oop, parece que seu registro está errado!", request.Notifications);
        
        var expense = new Expense(
            request.Category,
            request.Description,
            request.Tag,
            request.Value,
            DateTime.UtcNow,
            DateTime.UtcNow,
            request.Status,
            request.UserId,
            request.Installments,
            request.MethodPayment);
        
        _repository.Create(expense);
        
        return new GenericCommandResult(true, "Tarefa salva!", expense);
    }

    public ICommandResult Handle(Guid idExpense)
    {
        var expense = _repository.GetById(idExpense);
        
        _repository.Delete(expense);
        
        return new GenericCommandResult(true, "Dispesa deletada!", expense);
    }
}