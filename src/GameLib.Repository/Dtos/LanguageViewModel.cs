using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class LanguageViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public List<GameLowViewModel>? Games { get; set; }

    }
    public class LanguageCreateModel
    {
        [Required]
        public string Title { get; set; }
      
    }
    public class LanguageEditModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
      

    }
}
