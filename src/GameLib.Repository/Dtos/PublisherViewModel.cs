using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class PublisherViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<GameLowViewModel> Games { get; set; } = new List<GameLowViewModel>();

    }
    public class PublisherCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
    public class PublisherEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
