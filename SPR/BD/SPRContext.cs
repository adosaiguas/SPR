using SPR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.Service
{
    class SPRContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<ServerPerformance> ServerPerformances { get; set; }

        public SPRContext()
            : base("name=DefaultConnection")
        {

        }
    }
}
