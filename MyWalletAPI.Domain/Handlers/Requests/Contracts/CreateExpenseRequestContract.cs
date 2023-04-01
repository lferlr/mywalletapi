using Flunt.Validations;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Commands.Contracts;

namespace MyWalletAPI.Domain.Handlers.Requests.Contracts;

public class CreateExpenseRequestContract : Contract<CreateExpenseRequest>
{
    public CreateExpenseRequestContract(CreateExpenseRequest request)
    {
        Requires()
            .IsNotNullOrEmpty(request.Description, "Description", "A description não foi informada");
    }
}