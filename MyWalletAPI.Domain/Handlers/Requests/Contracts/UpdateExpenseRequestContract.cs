using Flunt.Validations;
using MyWalletAPI.Domain.Commands;
using MyWalletAPI.Domain.Commands.Contracts;

namespace MyWalletAPI.Domain.Handlers.Requests.Contracts;

public class UpdateExpenseRequestContract : Contract<UpdateExpenseRequest>
{
    public UpdateExpenseRequestContract(UpdateExpenseRequest request)
    {
        Requires()
            .IsNotNullOrEmpty(request.Description, "Description", "A description não foi informada");
    }
}