using Flunt.Notifications;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Commands.Contracts;
using MyWalletAPI.Domain.Entities;
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
        // Fail Fast Validation
        if (request.IsValid == false)
            return new GenericCommandResult(false, "Oop, parece que seu registro está errado!", request.Notifications);

            // Gerar um item
        var expense = new Expense(
            request.Category,
            request.Description,
            request.Tag,
            request.Value,
            DateTime.UtcNow,
            DateTime.UtcNow,
            request.Status,
            request.UserId);
        
        // Salvar
        _repository.Create(expense);
        
        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", expense);
    }
    
    public ICommandResult Handle(UpdateExpenseRequest request)
    {
        // Fail Fast Validation
        if (request.IsValid == false)
            return new GenericCommandResult(false, "Oop, parece que seu registro está errado!", request.Notifications);

        // Gerar um item
        var expense = new Expense(
            request.Category,
            request.Description,
            request.Tag,
            request.Value,
            DateTime.UtcNow,
            DateTime.UtcNow,
            request.Status,
            request.UserId);
        
        // Salvar
        _repository.Create(expense);
        
        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", expense);
    }
}