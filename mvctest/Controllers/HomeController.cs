using Microsoft.AspNetCore.Mvc;
using mvctest.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace mvctest.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        SqlConnection con = new SqlConnection();

        List<Person> person = new List<Person>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = mvctest.Properties.Resources.ConnectionString;
        }


        public IActionResult Index()
        {

            FetchData();
            return View(person);
        }

        Person db = new Person();

        private void FetchData()
        {
            try
            {

                con.Open();
                com.Connection = con;
                com.CommandText= "SELECT TOP (1000) [PersonName],[PersonSurname],[PersonAGE],[PersonGender],[PersonID],[PersonCity] FROM[AgeCalculator].[dbo].[Tbl_Person]";

                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["PersonGender"].ToString()=="erkek")
                    {

                    };

                    person.Add(new Person() {
                        PersonName = dr["PersonName"].ToString(),
                        PersonSurname= dr["PersonSurname"].ToString(),
                        PersonAge = dr["PersonAge"].ToString(),
                        PersonGender = dr["PersonGender"].ToString(),
                        PersonCity = dr["PersonCity"].ToString(),

                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public JsonResult GenderCount()
        //{
        //    try
        //    {
        //        string[] GenderCount = new string[2];

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select count(PersonGender) as erkek , (select count(PersonGender) from dbo.Tbl_Person where PersonGender='kadin')as kadin from dbo.Tbl_Person where PersonGender='erkek'", con);
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
        //        cmd1.Fill(dt);
        //        if (dt.Rows.Count == 0)
        //        {
        //            GenderCount[0] = "0";
        //            GenderCount[1] = "0";
        //        }
        //        else
        //        {
        //            GenderCount[0] = dt.Rows[0]["male"].ToString();
        //            GenderCount[1] = dt.Rows[1]["female"].ToString();

        //        }
        //        return Json(GenderCount);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}