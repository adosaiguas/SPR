using SPR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SPR.Controller
{
    class ESARController : IEsarController
    {
        public static void Data()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://fridvhprl802.res.hpe.com/OVPM/?CUSTOMER=juan-carlos.franco-albardiaz@hp.com&PASSWORD=juancarlos_bsa&GRAPHTEMPLATE=BS+Online&MINY=0&MAXY=100&GRAPHTYPE=csv&GRAPH=CPU&SYSTEMNAME=netjb01p.bancsabadell.es&STARTTIME=2019,4,9,00,00,00&STOPTIME=2019,4,10,00,00,00", "reports/server_netjb01p_CPU.csv");
            }
        }
    }
}
