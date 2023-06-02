using TeamPilot.Application.Dtos.team;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.ExtensionMethods
{
    public static class PlayerMapper
    {
        public static Player DTOToEntity(PlayerDTO dto)
        {
            decimal salary = 0;
            bool isSalary = decimal.TryParse(dto.MonthlySalary, out salary);

            return new Player
            {
                UserId = new Guid(dto.UserId),
                TeamId = new Guid(dto.TeamId),
                MonthlySalary = salary,
                AvatarUrl = dto.AvatarUrl,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Nickname = dto.Nickname,
                Bio = dto.Bio,
            };
        }

        public static PlayerDTO EntityToDTO(Player player)
        {
            return new PlayerDTO
            {
                UserId = player.UserId.ToString(),
                TeamId = player.TeamId.ToString(),
                MonthlySalary = player.MonthlySalary.ToString(),
                AvatarUrl = player.AvatarUrl,
                Email = player.Email,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Nickname = player.Nickname,
                Bio = player.Bio,
            };
        }

    }
}
