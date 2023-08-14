
using System.Data;

using MySpotify.Data.Interfaces;
using MySpotify.Models.Dtos;
using MySpotify.Models;
using MySpotity.Data;

namespace MySpotify.Data.Repositories
{
    public class IRoleRepositoryImpl : IRoleRepository
    {
        private readonly DataContext _context;
        public IRoleRepositoryImpl(DataContext context)
        {
            _context = context;
        }
        public List<UserRolesDto> ObjetctRoles(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public List<UserRolesDto> GetUserRoles(Guid idUser)
        {
            var listRoles = new List<UserRolesDto>();
            /*
            using (MySqlConnection conn = new MySqlConnection(Globals._Conn))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_UserRoles", conn))
                {


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //Se abre la conexión
                    conn.Open();
                    cmd.Parameters.AddWithValue("v_IdUser", idUser);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        var roleDto = new UserRolesDto();

                        roleDto.Id = dr.Field<int>("id");
                        roleDto.OwnerId = dr.Field<int>("OwnerId");
                        roleDto.CompanyId = dr.Field<int>("CompanyId");
                        roleDto.Name = dr.Field<string>("Name");


                        roleDto.LevelProcess = dr.Field<int>("LevelProcess");
                        roleDto.LevelShapes = dr.Field<int>("LevelShapes");
                        roleDto.LevelConnectors = dr.Field<int>("LevelConnectors");
                        roleDto.LevelOperations = dr.Field<int>("LevelOperations");
                        roleDto.LevelFluxogram = dr.Field<int>("LevelFluxogram");
                        roleDto.UseApi = dr.Field<bool>("UseApi");

                        listRoles.Add(roleDto);
                    }

                }
            }
            */
            return listRoles;
        }
    }
}
