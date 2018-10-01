
using System;

namespace SPR.Model
{
    class Receiver : ServerPerformance
    {
        public string Name { get; set; }
        public string surname1 { get; set; }
        public String surname2 { get; set; }

        public Receiver(string name, string surname1, String surname2,
            string cPU, string rAM, string iO_Disk, string iIS_Sessions) : base(cPU, rAM, iO_Disk, iIS_Sessions)
        {
            //TODO: Call the method that reads the file and get the values from CSV

            this.Name = name;
            this.surname1 = surname1;
            this.surname2 = surname2;
        }

    }
}