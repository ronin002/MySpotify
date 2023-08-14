
using MySpotify.Models.Dtos;
using MySpotify.Models;

namespace MySpotify.Data.Interfaces
{
    public interface IRoleRepository
    {
        public List<UserRolesDto> GetUserRoles(Guid idUser);

        public List<UserRolesDto> ObjetctRoles(Guid idUser);
    }
}
