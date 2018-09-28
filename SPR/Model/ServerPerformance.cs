using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.Model
{
    class ServerPerformance
    {
        public string CPU { get; }
        public string RAM { get; }
        public string IO_Disk { get; }
        public string IIS_Sessions { get; }

        public ServerPerformance(string cPU, string rAM, string iO_Disk, string iIS_Sessions)
        {
            CPU = cPU;
            RAM = rAM;
            IO_Disk = iO_Disk;
            IIS_Sessions = iIS_Sessions;
        }
    }
}
