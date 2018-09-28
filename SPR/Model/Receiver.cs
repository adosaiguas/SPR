
namespace SPR.Model
{
    class Receiver : ServerPerformance
    {
        public string Name { get; }
        public string surname1 { get; }
        public string surname2 { get; }

        public Receiver(string name, string surname1, string surname2,
            string cPU, string rAM, string iO_Disk, string iIS_Sessions) : base(cPU, rAM, iO_Disk, iIS_Sessions)
        {
            this.Name = name;
            this.surname1 = surname1;
            this.surname2 = surname2;
        }

    }
}