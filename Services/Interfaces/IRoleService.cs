
using MySpotify.Models.Dtos;
using MySpotify.Models;

namespace MySpotify.Services.Interfaces
{
    public interface IRoleService
    {
        public List<UserRolesDto> GetUserRoles(Guid idUser);

        public List<UserRolesDto> ObjetctRoles(Guid idUser);
    }
}
