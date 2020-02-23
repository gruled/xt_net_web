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
    public class AwardsAndImagesDatabaseDAO:IAwardsAndImagesDAO
    {
        public void AddLink(int awardId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAwardsAndImagesLink";
                var idAwardParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = awardId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idAwardParameter);
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
                command.CommandText = "dbo.GetAllAwardsAndImagesLinks";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entityAndImages.Add(new EntityAndImages()
                    {
                        EntityId =(int) reader["awardId"],
                        ImageId = (int)reader["imageId"]
                    });
                }
            }

            return entityAndImages;
        }

        public void DeleteLinkByAwardId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAwardsAndImagesLinkByAwardId";
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

        public void DeleteLinkByImageId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAwardsAndImagesLinkByImageId";
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

        public void DeleteLink(int awardId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteAwardsAndImagesLinkByAwardIdAndImageId";
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
