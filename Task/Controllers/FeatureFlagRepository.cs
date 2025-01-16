using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.Controllers
{
    //public class FeatureFlagRepository : Controller
    //{
      

public class FeatureFlagRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<FeatureFlag> GetFeatureFlagsByDomain(string domain)
        {
            var featureFlags = new List<FeatureFlag>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FeatureFlags WHERE Domain = @Domain";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Domain", domain);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    featureFlags.Add(new FeatureFlag
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        IsEnabled = Convert.ToBoolean(reader["IsEnabled"]),
                        Domain = reader["Domain"].ToString()
                    });
                }
            }
            return featureFlags;
        }

        public void AddFeatureFlag(FeatureFlag featureFlag)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO FeatureFlags (Name, IsEnabled, Domain) VALUES (@Name, @IsEnabled, @Domain)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", featureFlag.Name);
                cmd.Parameters.AddWithValue("@IsEnabled", featureFlag.IsEnabled);
                cmd.Parameters.AddWithValue("@Domain", featureFlag.Domain);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateFeatureFlagStatus(int id, bool isEnabled)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE FeatureFlags SET IsEnabled = @IsEnabled WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IsEnabled", isEnabled);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFeatureFlag(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM FeatureFlags WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
}

        //public ActionResult Index()
        //{
        //    return View();
        //}
   // }
}