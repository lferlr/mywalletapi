using Flunt.Notifications;
using MyWalletAPI.Domain.Enum;
using MyWalletAPI.Domain.Handlers.Requests.Contracts;

namespace MyWalletAPI.Domain.Handlers.Requests;

public class DeleteExpenseRequest : Notifiable<Notification>
{
    public DeleteExpenseRequest(
        string category, 
        string description, 
        Tag tag, 
        decimal value, 
        DateTime dueDate, 
        DateTime registrationDate, 
        bool status, 
        string userId,
        Payment methodPayment)
    {
        Category = category;
        Description = description;
        Tag = tag;
        Value = value;
        DueDate = dueDate;
        RegistrationDate = registrationDate;
        Status = status;
        UserId = userId;
        MethodPayment = methodPayment;
        
        AddNotifications(new DeleteExpenseRequestContract(this));
    }

    public string Category { get; set; }
    public string Description { get; set; }
    public Tag Tag { get; set; }
    public decimal Value { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool Status { get; set; }
    public string UserId { get; set; }
    public int Installments { get; set; }
    public Payment MethodPayment { get; set; }
}