
using System;
using System.Collections.Generic;

namespace SPR.Model
{
    class Receiver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string surname1 { get; set; }
        public string surname2 { get; set; }
        public IList<ServerPerformance> ServerPerformances { get; set; }
    }
}