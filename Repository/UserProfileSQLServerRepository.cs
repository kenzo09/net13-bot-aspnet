using Dapper;
using SimpleBot.Repository.Entities;
using SimpleBot.Repository.Interfaces;
using System.Data;

namespace SimpleBot.Repository
{
    public class UserProfileSQLServerRepository : IUserProfileRepository
    {
        public UserProfile GetProfile(string id)
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                const string query = @"
                                SELECT
                                	Id,
                                	Visitas
                                FROM 
                                	UserProfile 
                                WHERE
                                	Id = CAST(@Id AS VARCHAR)";

                var profile = connection.QueryFirstOrDefault<UserProfileSQLServer>(query, new { Id = id });

                return new UserProfile
                {
                    Id = profile.Id ?? id,
                    Visitas = profile != null 
                                    ? profile.Visitas
                                    : 0
                };
            }
        }

        public void SetProfile(string id, UserProfile profile)
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                const string proc = "UpInsertProfile";

                connection.Execute(proc, new { Id = id, profile.Visitas }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}