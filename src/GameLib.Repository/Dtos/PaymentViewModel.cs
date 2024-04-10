using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public GameLowViewModel Game { get; set; }
        
    }
    public class PaymentCreateModel
    {
        public UserDto User { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public GameLowViewModel Game { get; set; }
    }
}
