using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RabbitReceive
    {
        public string Email { get; set; }
        public List<int> Tables { get; set; }
    }
}
