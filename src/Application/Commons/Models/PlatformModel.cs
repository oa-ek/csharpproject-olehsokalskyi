using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class PlatformModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<GameLowViewModel> Games { get; set; }

    }
    public class PlatformCreateModel
    {
        [Required]
        public string Title { get; set; }

    }
    public class PlatformEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }


    }
}
