
namespace SPR.Model
{
    public class ServerPerformance
    {
        public int Id { get; set; }
        public double CPU { get; set; }
        public double RAM { get; set; }
        public double IO_Disk { get; set; }
        public int IIS_Sessions { get; set; }
    }
}
