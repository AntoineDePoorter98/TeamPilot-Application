namespace TeamPilot.Domain.Entities;

public class Round
{
    public Guid RoundId { get; set; }
    public int RoundCounter { get; set; }
    public Guid? MatchId { get; set; }
    public Match? Match { get; set; }
    public Guid PlayerMVPId { get; set; }
    public Guid TeamWinnerId { get; set; }
    public List<RoundEvent> RoundEvents { get; set; } = new List<RoundEvent>();
}
