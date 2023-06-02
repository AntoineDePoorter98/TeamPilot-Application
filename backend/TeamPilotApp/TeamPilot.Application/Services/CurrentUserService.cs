using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services;

public class CurrentUserService
{
    public User? CurrentUser { get; set; }

    public Player MockPlayer { get; set; } = new Player
    {
        UserId = new Guid("7F16DF81-1749-4467-9563-000E950E2DFF"),
        TeamId = new Guid("1B061FEE-83B0-4EC4-B694-59EC09A255DB"),
        AvatarUrl = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/294.jpg",
        Bio = "Placeat.",
        Email = " Layla.Larkin50@hotmail.com",
        Nickname = "Clementine_Walsh",
        FirstName = "Celia",
        LastName = "Wunsch",
        MonthlySalary = 443.76M,
    };

     public TeamManager MockTeamManager { get; set; } = new TeamManager
     {
        UserId = new Guid("cfd8c76b-e741-405c-8d03-25ce7d6ba5d8"),
        Nickname = "daps",
        FirstName = "Damian",
        LastName = "Steele",
        Email = "daps@liquid.com",
        AvatarUrl = "https://liquipedia.net/commons/images/thumb/e/e0/Daps_%40_BLAST_Premier_Abu_Dhabi_2022.jpg/600px-Daps_%40_BLAST_Premier_Abu_Dhabi_2022.jpg",
        Bio = "i am team manager of liquid"
     };
    public TournamentManager MockTournamentManager { get; set; } = new TournamentManager
    {
        UserId = new Guid("126AEBF7-0D3D-460E-AEAA-60AEDCAC7E41"),
        Nickname = "Rick.Wunsch72",
        FirstName = "Ernestina",
        LastName = "Hickle",
        Email = "Harley_Klocko@hotmail.com",
        AvatarUrl = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/505.jpg",
        Bio = "Voluptatum."
    };
    public RegisteredUser MockRegisteredUser { get; set; } = new RegisteredUser
    {
        UserId = new Guid("4aa85cde-4fab-41a2-9f7b-65dd29491a3f"),
        Nickname = "Earnest57",
        FirstName = "Yvonne",
        LastName = "Stroman",
        Email = "Alvina_MacGyver42@yahoo.com",
        AvatarUrl = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/920.jpg",
        Bio = "Et."
    };
}
