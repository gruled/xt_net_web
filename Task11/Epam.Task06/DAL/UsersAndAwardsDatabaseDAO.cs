using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL
{
    public class UsersAndAwardsDatabaseDAO:IUsersAndAwardsDAO
    {
        public void AddLink(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUsersAndAwardsLink";
                var idAwardParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = awardId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idAwardParameter);
                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UsersAndAwards> GetAll()
        {
            List<UsersAndAwards> usersAndAwards = new List<UsersAndAwards>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersAndAwardsLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usersAndAwards.Add(new UsersAndAwards()
                    {
                        IdAward = (int)reader["awardId"],
                        IdUser = (int)reader["userId"]
                    });
                }
            }

            return usersAndAwards;
        }

        public void DeleteLinkByUserId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAwardsLinkByUserId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLinkByAwardId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAwardsLinkByAwardId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLink(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndAwardsLinkByUserIdAndAwardId";
                var awardIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = awardId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(awardIdParameter);
                var imageIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageIdParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
