using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoCoreMvc.Models;
using Newtonsoft.Json.Linq;
using DemoCoreMvc.Services;

namespace DemoCoreMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Dashboard()
        {
            DashboardApi dashboardApi = new DashboardApi();
            JArray list_years = dashboardApi.get_all_years();
            ViewBag.list_years = list_years;            
            string current_year = list_years[0].ToString();                     
            JObject loan_amt = dashboardApi.get_loan_amt(current_year);
            ViewBag.loan_amt = loan_amt;
            JObject loan_count = dashboardApi.get_loan_count(current_year);
            ViewBag.loan_count = loan_count;
            JObject default_amt = dashboardApi.get_default_amt(current_year);
            ViewBag.default_amt = default_amt;
            JObject default_count = dashboardApi.get_default_count(current_year);
            ViewBag.default_count = default_count;
            JObject month_loan = dashboardApi.get_month_loan(current_year);
            ViewBag.month_loan = month_loan; 
            JObject month_count = dashboardApi.get_month_count(current_year);
            ViewBag.month_count = month_count;
            JObject purpose = dashboardApi.get_purpose(current_year);
            ViewBag.purpose = purpose;                     
            JObject occupation = dashboardApi.get_occupation(current_year);
            ViewBag.occupation = occupation;                      
            return View("/Views/Dashboard/Dashboard.cshtml");       
        }

    public IActionResult Pages()
    {
        return View("/Views/Pages/Pages.cshtml");
    }

    public IActionResult Settings()
    {
        return View("/Views/Settings/Settings.cshtml");
    }

    public IActionResult MachineLearning()
    {
        return View("/Views/MachineLearning/MachineLearning.cshtml");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
