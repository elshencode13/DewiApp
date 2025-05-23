using DewiApp.DAL.Contexts;
using DewiApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DewiApp.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		private readonly AppDbContext _context;
        public DashboardController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
		{
			return View();
		}
        public IActionResult Table()
        {
            List<TeamModel> list = _context.teamModels.ToList();
            return View(list);
        }
    }
}
