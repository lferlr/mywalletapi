using Flunt.Notifications;

namespace MyWalletAPI.Domain.Entities;

public class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
 
    public Guid Id { get; private set; }
    
    public bool Equals(Entity? other)
    {
        return Id == other?.Id;
    }
}