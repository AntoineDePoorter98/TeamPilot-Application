namespace TeamPilot.Domain.Entities;

public class RoundEvent
{
    public Guid RoundEventId { get; set; }
    public DateTime TimeStamp { get; set; }
    public Guid RoundId { get; set; }
    public Round Round { get; set; }
    public Guid KillingPlayerId { get; set; }
    public Player KillingPlayer { get; set; }
    public Guid KilledPlayerId { get; set; }
    public Player KilledPlayer { get; set; }
}
