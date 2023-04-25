using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Site.Models;
using System.Data.SqlClient;

namespace MVC_Site.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
		SqlDataReader dr;

		// GET: Account
		[HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=(LocalDB)\\MSSQLLocalDB; database=SampleDB;";
        }
        [HttpPost]
		public ActionResult Verify(Account acc)
		{
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from MVCregUser where Uname='"+acc.Name+"' and Upwd='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
				con.Close();
				return View("Create");
			}
            else
            {
				con.Close();
				return View("Error");
			}
            
			
		}
	}
}