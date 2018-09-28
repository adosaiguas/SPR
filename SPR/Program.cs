using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPR.Service.ConfigureServcie;

namespace SPR
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.ConfigureServcie.ConfigureService.Configure();
        }
    }
}
