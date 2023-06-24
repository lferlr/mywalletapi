using Flunt.Validations;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Commands.Contracts;

namespace MyWalletAPI.Domain.Handlers.Requests.Contracts;

public class DeleteExpenseRequestContract : Contract<DeleteExpenseRequest>
{
    public DeleteExpenseRequestContract(DeleteExpenseRequest request)
    {
        Requires()
            .IsNotNullOrEmpty(request.Description, "Description", "A description não foi informada");
    }
}