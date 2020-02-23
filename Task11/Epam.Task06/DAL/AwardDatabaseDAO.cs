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
    public class AwardDatabaseDAO : IAwardDAO
    {
        public int Add(Award award)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = award.Title,
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
                command.CommandText = "dbo.DeleteAwardById";
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

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAwards";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award()
                    {
                        Id = (int)reader["Id"],
                        Title =(string) reader["Title"]
                    });
                }
            }

            return awards;
        }

        public Award GetAwardById(int id)
        {
            Award award = new Award();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAwardById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    award = new Award()
                    {
                        Id = (int) reader["Id"],
                        Title =(string) reader["Title"]
                    };
                }
            }

            return award;
        }

        public void Update(int id, Award newAward)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAwardById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var titleParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@AwardTitle",
                    Value = newAward.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(titleParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
