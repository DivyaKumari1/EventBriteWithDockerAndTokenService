using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Domain
{
    public class Permissions
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
