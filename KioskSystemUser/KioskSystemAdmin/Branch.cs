using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAdmin
{
    public class Branch
    {
        public string Region { get; set; }
        public int CompanyId { get; set; }
        public int[] ServiceIds { get; set; }
    }
}
