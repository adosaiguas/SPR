using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.Model
{
    public class ServerPerformance
    {
        public int Id { get; set; }
        public string CPU { get; }
        public string RAM { get; }
        public string IO_Disk { get; }
        public string IIS_Sessions { get; }

    }
}
