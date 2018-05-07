using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace TCG_App.Models
{
    public class CommunityViewModels
    {
    }
    
    //[Authorize]
    public class CreateCommunityViewModel
    {
        [Required]
        [Display(Name ="Community Name")]
        public string CommunityName { get; set; }

        [Required]
        [Display(Name = "Community Description")]
        public string CommunityDesc { get; set; }

        [Display(Name = "Community Location")]
        public string CommunityLoc { get; set; }
    }

    public class CommunityIndexViewModel
    {
    }

    public class Community
    {
        public int CommunityId;
        public string CommunityName;
        public string CommunityLocation;
        public string CommunityDesc;
    }

    public class CommunityUserList
    {

    }



    public class CommunityList
    {
        public List<Community> _listOfCommunity { get; set; }

        public List<Community> GetListOfCommunities()
        {
            List<Community> Communities = new List<Community>(); 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetCommunityList";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while(reader.Read())
                {
                    Communities.Add(new Community() { CommunityId =  Convert.ToInt32(reader[0].ToString()), CommunityName = reader[1].ToString(), CommunityLocation = reader[2].ToString(), CommunityDesc = reader[3].ToString()});
                }
                conn.Close();
                return Communities;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
    }
}