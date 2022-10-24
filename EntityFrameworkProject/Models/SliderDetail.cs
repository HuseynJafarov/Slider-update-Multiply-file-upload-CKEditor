
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkProject.Models
{
    public class SliderDetail : BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Can't be empty")]
        public IFormFile SignImage { get; set; }
    }
}
