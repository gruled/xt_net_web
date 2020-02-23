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
    public class ImagesDatabaseDAO : IImagesDAO
    {
        public int AddImage(Image image)
        {
            int id = 0;
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddImage";
                var valueParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Value",
                    Value = image.Value,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(valueParameter);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                id = (int) idParameter.Value;
            }

            return id;
        }

        public void DeleteImageById(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteImageById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.UInt32,
                    ParameterName = "@ImageId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Image GetImageById(int id)
        {
            Image image = new Image();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetImageById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ImageId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    image = new Image()
                    {
                        Id = (int) reader["Id"],
                        Value = (byte[]) reader["Value"]
                    };
                }
            }

            return image;
        }

        public void UpdateImageById(int id, Image image)
        {
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateImageById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.UInt32,
                    ParameterName = "@ImageId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                var valueParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@ImageValue",
                    Value = image.Value,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(valueParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Image> GetAll()
        {
            List<Image> images = new List<Image>();
            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllImages";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    images.Add(new Image()
                    {
                        Id = (int) reader["Id"],
                        Value = (byte[]) reader["Value"]
                    });
                }
            }

            return images;
        }
    }
}
