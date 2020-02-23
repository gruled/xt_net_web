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
    public class UsersAndImagesDatabaseDAO:IUsersAndImagesDAO
    {
        public void AddLink(int userId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUsersAndImagesLink";
                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);
                var idImageParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ImageId",
                    Value = imageId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idImageParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<EntityAndImages> GetAll()
        {
            List<EntityAndImages> entityAndImages = new List<EntityAndImages>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsersAndImagesLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityAndImages.Add(new EntityAndImages()
                    {
                        EntityId =(int)reader["userId"],
                        ImageId = (int)reader["imageId"]
                    });
                }
            }

            return entityAndImages;
        }

        public void DeleteLinkByUserId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndImagesLinkByUserId";
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

        public void DeleteLinkByImageId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndImagesLinkByImageId";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ImageId",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLink(int userId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteUsersAndImagesLinkByUserIdAndImageId";
                var userIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(userIdParameter);
                var imageIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ImageId",
                    Value = imageId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(imageIdParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
