using DewiApp.DAL.Contexts;
using DewiApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DewiApp.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

        public HomeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
		{
			List<TeamModel> teamModels = _context.teamModels.ToList();
			return View(teamModels);
		}
	}
}
