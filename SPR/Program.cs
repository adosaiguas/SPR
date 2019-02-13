using SPR.Controller;
using System;

namespace SPR
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.ConfigureServcie.ConfigureService.Configure();
            FileController.createLogFile("log");
            FileController.createLogFile("Data"); //TODO: Remove it  
            Console.WriteLine(FileController.writeDataIntoALog("SERVICE HAS BEEN LAUNCHED", FileController.fileStr));

        }
    }
}

