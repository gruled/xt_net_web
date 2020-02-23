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
    public class WebUserDatabaseDAO:IWebUserDAO
    {
        public void AddWebUser(WebUser user)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddWebUser";
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(loginParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);
                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = user.Password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);
                var roleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Role",
                    Value = user.Role,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int GetRoleById(int id)
        {
            int role = 0;
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleByWebUserId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@WebUserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var roleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Role",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(roleParameter);
                connection.Open();
                command.ExecuteNonQuery();
                role = (int) roleParameter.Value;
            }

            return role;
        }

        public WebUser GetWebUserById(int id)
        {
            WebUser user = new WebUser();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetWebUserById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@WebUserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new WebUser()
                    {
                        Id = (int)reader["Id"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Role = (int)reader["Role"]
                    };
                }
            }

            return user;
        }

        public IEnumerable<WebUser> GetAllWebUsers()
        {
            List<WebUser> users = new List<WebUser>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllWebUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new WebUser()
                    {
                        Id = (int)reader["Id"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Role = (int)reader["Role"]
                    });
                }
            }

            return users;
        }

        public void DeleteWebUserById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteWebUserById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@WebUserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateWebUserById(int id, WebUser webUser)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateWebUserById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@WebUserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@WebUserLogin",
                    Value = webUser.Login,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(loginParameter);
                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@WebUserPassword",
                    Value = webUser.Password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);
                var roleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@WebUserRole",
                    Value = webUser.Role,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
