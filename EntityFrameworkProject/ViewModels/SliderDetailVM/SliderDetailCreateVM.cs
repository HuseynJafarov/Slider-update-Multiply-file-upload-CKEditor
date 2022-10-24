using EntityFrameworkProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.ViewModels.SliderDetailVM
{
    public class SliderDetailCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> SingPhotos { get; set; }

        public string Desc { get; set; }

        public string Header { get; set; }

    }
}
