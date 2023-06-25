using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAdmin
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int BranchID { get; set; }
        public string ServiceName { get; set; }
        public string[] Questions { get; set; }
    }
}
