using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<GameLowViewModel> Games { get; set; }
    }
    public class GenreCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
    public class GenreEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
