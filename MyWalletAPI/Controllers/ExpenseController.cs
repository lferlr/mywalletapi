using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Entities;
using MyWalletAPI.Domain.Handlers;
using MyWalletAPI.Domain.Handlers.Requests;
using MyWalletAPI.Domain.Repositories;

namespace MyWalletAPI.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    [HttpGet("GetAll")]
    public IEnumerable<Expense> GetAll([FromServices] IExpenseRepository repository)
    {
        return repository.GetAll();
    }
    
    [HttpGet("GetAll/{idUser}")]
    public IEnumerable<Expense> GetAllByIdUser([FromServices] IExpenseRepository repository, string idUser)
    {
        // TODO: Este método deve conter um filtro para buscar todos os registros de um usuário
        
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllByUser(user);
    }
    
    [HttpPost("Create")]
    public GenericCommandResult Create(CreateExpenseRequest request, [FromServices] ExpenseHandler handler)
    {
        request.UserId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult) handler.Handle(request);
    }
    
    [HttpPut("")]
    public GenericCommandResult Update(UpdateExpenseRequest request, [FromServices] ExpenseHandler handler)
    {
        request.UserId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(request);
    }
    
    [HttpDelete("{idExpense}")]
    public GenericCommandResult Delete(UpdateExpenseRequest request, [FromServices] ExpenseHandler handler, Guid idExpense)
    {
        request.UserId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(request);
    }
}