using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class AchievementViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GameTitle { get; set; }
        public int PlayersGet { get; set; }
    }
    public class AchievementCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        public Guid GameId { get; set; }
    }
    public class AchievementEditModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid GameId { get; set; }
        [Required]
        public int PlayersGet { get; set; }
    }

}
