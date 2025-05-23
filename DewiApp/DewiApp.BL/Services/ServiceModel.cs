using DewiApp.BL.ViewModels;
using DewiApp.DAL.Contexts;
using DewiApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DewiApp.BL.Services;

	public class ServiceModel
	{
		private readonly AppDbContext _context;

    public ServiceModel(AppDbContext appDbContext)
    {
        _context = appDbContext;
        
    }
    #region Create

    public void Create(TeamCreateVM teamCreateVM)
    {
        //new
        TeamModel teamModel = new TeamModel();

        //mapping 
        teamModel.Name = teamCreateVM.Name;
        teamModel.Job = teamCreateVM.Job;
        
        
            string filename = Path.GetFileNameWithoutExtension(teamCreateVM.Image.Name);
            string extension = Path.GetExtension(teamCreateVM.Image.Name);
            string fullname = filename + Guid.NewGuid().ToString() + extension;
            teamModel.Image = fullname;


            string uploadPath = @"C:\Users\I Novbe\source\repos\DewiApp\DewiApp.MVC\wwwroot\assets\UploadedImages";
            uploadPath = Path.Combine(uploadPath, filename);
            using FileStream stream = new FileStream(uploadPath,FileMode.Create);
            teamCreateVM.Image.CopyTo(stream);

            _context.Add(teamModel);
            _context.SaveChanges();
       
        
         

    }
    #endregion

    #region Read
    public TeamModel GetById(int id)
    {
       TeamModel teamModel = _context.teamModels.Find(id);

        return teamModel;
    }
    public void GetAllTeams()
    {
       List<TeamModel> teamModels =  _context.teamModels.ToList();
    
    }

    #endregion

    #region Delete
    public void Delete(int id)
    {
      TeamModel teamModel = GetById(id);

        _context.teamModels.Remove(teamModel);
        _context.SaveChanges();
    }


    #endregion

    #region Update
    public void Update(int id,TeamUpdateVM teamUpdateVM)
    {
        TeamModel teamModel = new TeamModel();

        teamUpdateVM.Name = teamModel.Name;
        teamUpdateVM.Job = teamModel.Job;

        string filename = Path.GetFileNameWithoutExtension(teamUpdateVM.Image.Name);
        string extension = Path.GetExtension(teamUpdateVM.Image.Name);
        string fullname = filename + Guid.NewGuid().ToString() + extension;
        teamModel.Image = fullname;


        string uploadPath = @"C:\Users\I Novbe\source\repos\DewiApp\DewiApp.MVC\wwwroot\assets\UploadedImages";
        uploadPath = Path.Combine(uploadPath, filename);
        using FileStream stream = new FileStream(uploadPath, FileMode.Create);
        teamUpdateVM.Image.CopyTo(stream);

        
        _context.SaveChanges();


    }

    #endregion

}
