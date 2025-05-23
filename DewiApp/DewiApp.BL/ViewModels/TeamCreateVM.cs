using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DewiApp.BL.ViewModels
{
    public class TeamCreateVM
    {
        public string Name { get; set; }
        public IFormFile? Image { get; set; }

        public string Job { get; set; }
    }
}
