using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var con = new SqlConnection("Server=.;Database=Books;Trusted_Connection=True;"))
            {
                con.Open();
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Books";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var id = Convert.ToInt32(reader["BookId"]);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
