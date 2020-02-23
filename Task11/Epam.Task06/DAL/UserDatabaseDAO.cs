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
    public class UserDatabaseDAO:IUserDAO
    {
        public int Add(User user)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = user.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(nameParameter);
                var ageParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Age",
                    Value = user.Age,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ageParameter);
                var dateOfBirthParameter = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(dateOfBirthParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                id =(int) idParameter.Value;
            }

            return id;
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUserById";
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

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        Id = (int)reader["Id"],
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Name =(string) reader["Name"]
                    });
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = (int) reader["Id"],
                        Age = (int) reader["Age"],
                        DateOfBirth = (DateTime) reader["DateOfBirth"],
                        Name = (string) reader["Name"]
                    };
                }
            }

            return user;
        }

        public void Update(int id, User newUser)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUserById";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@UserName",
                    Value = newUser.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(nameParameter);
                var ageParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserAge",
                    Value = newUser.Age,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ageParameter);
                var dateOfBirthParameter = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@UserDateOfBirth",
                    Value = newUser.DateOfBirth,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(dateOfBirthParameter);
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
    }
}
