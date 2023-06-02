namespace TeamPilot.Domain.Entities;

public class Player : User
{
    public decimal MonthlySalary { get; set; }
    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }
    public List<RegisteredUser> Followers { get; set; } = new List<RegisteredUser>();

    public List<RoundEvent> KillingPlayerRoundEvents { get; set; }
    public List<RoundEvent> KilledPlayerRoundEvents { get; set; }
}
