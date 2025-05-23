using DewiApp.BL.Services;
using DewiApp.BL.ViewModels;
using DewiApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DewiApp.MVC.Areas.Admin.Controllers;

public class ServiceController : Controller
{
    private readonly ServiceModel _service;

    public ServiceController(ServiceModel serviceModel)
    {
        _service = serviceModel;
    }


    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(TeamCreateVM teamCreateVM)
    {
        _service.Create(teamCreateVM);
        return RedirectToAction("Table", "Dashboard");
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction("Table","Dashboard");
    }


    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        TeamUpdateVM teamUpdateVM = new TeamUpdateVM();
        var model = _service.GetById(id);


        teamUpdateVM.Name = model.Name;
        teamUpdateVM.Job = model.Job;
        
        
        return View(teamUpdateVM);
       
    }
    [HttpPost]
    public IActionResult Update(int id,TeamUpdateVM teamUpdateVM)
    {

        _service.Update(id, teamUpdateVM);
        return RedirectToAction("Table","Dashboard");

    }

    #endregion

    #region Read
    [HttpGet]
    public IActionResult Index()
    {
        var model = _service.GetAllTeams();

        return View(model);
    }
    [HttpPost]
    
    public IActionResult Details(int id)
    {
        var model = _service.GetById(id);
        return View(model);
    }

    #endregion
}
