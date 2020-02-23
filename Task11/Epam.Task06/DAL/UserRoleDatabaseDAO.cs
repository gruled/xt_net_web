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
    public class UserRoleDatabaseDAO:IUserRoleDAO
    {
        public void AddRole(UserRole role)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddRole";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = role.Title,
                    Direction = ParameterDirection.Input
                };
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(titleParameter);
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string GetRoleById(int id)
        {
            string role = "";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    role = (string)reader["Title"];
                }
            }

            return role;
        }

        public IEnumerable<UserRole> GetAllRoles()
        {
            List<UserRole> roles = new List<UserRole>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRoles";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new UserRole()
                    {
                        Id = (int) reader["Id"],
                        Title = (string)reader["Title"]
                    });
                }
            }

            return roles;
        }

        public void DeleteRoleById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRoleById(int id, UserRole role)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@RoleTitle",
                    Value = role.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
