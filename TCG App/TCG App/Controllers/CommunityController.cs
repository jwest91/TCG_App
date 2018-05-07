using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using TCG_App.Models;
using System.Configuration;
using System.Data;

namespace TCG_App.Controllers
{
    //[Authorize]
    public class CommunityController : Controller
    {

        public CommunityController()
        {

        }
        private CommunityList com = new CommunityList();

        private List<Community> communities;

        public ActionResult CommunityIndex()
        {
            var model = new List<Community>();

            model = com.GetListOfCommunities();

            return View(model);
        }

        public ActionResult Community(string commId)
        {

            Community vm = new Models.Community();
            if(commId != null)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetCommunity";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = Convert.ToInt32(commId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        vm.CommunityId = Convert.ToInt32(reader[0]);
                        vm.CommunityName = reader[1].ToString();
                        vm.CommunityDesc = reader[4].ToString();
                        vm.CommunityLocation = reader[2].ToString();
                    }
                }
                catch
                { }
            }

            return View(vm);
        }

        public ActionResult CreateCommunity()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommunity(CreateCommunityViewModel model)
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CreateNewCommunity";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@commName", SqlDbType.VarChar);
                cmd.Parameters.Add("@commDesc", SqlDbType.Text);
                cmd.Parameters.Add("@commLoc", SqlDbType.VarChar);
                cmd.Parameters.Add("@CreatedByUser", SqlDbType.VarChar);
                cmd.Parameters["@commName"].Value = model.CommunityName;
                cmd.Parameters["@commDesc"].Value = model.CommunityDesc;
                cmd.Parameters["@commLoc"].Value = model.CommunityLoc;
                cmd.Parameters["@CreatedByUser"].Value = User.Identity.Name.ToString();

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {

                }

            }
            return View(model);
        }
    }
}
