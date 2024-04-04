using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public  class Payment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public double Amount { get; set; } = 0;


    }
}
