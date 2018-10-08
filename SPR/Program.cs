using SPR.Controller;
using System;

namespace SPR
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.ConfigureServcie.ConfigureService.Configure();
            FileController.createLogFile();
            //Console.WriteLine(FileController.writeDataIntoALog("SERVICE HAS BEEN LAUNCHED", FileController.fileStr));

            //TODO: Remove this: This line is just for a commit test
        }
    }
}
s