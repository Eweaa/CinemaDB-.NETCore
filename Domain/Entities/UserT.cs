using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserT
    {
        public bool Role { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
