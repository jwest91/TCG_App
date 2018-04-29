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
    public class CommunityController : Controller
    {

        public CommunityController()
        {

        }

        // GET: Community
        public ActionResult Index()
        {
            return View();
        }

        // GET: Community/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Community/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Community/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Community/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Community/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Community/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Community/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
