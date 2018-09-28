using Quartz;
using SPR.Controller;
using SPR.Jobs;
using System;
using System.Threading;


namespace SPR.Hosts
{
    class SelfHostService : ISelfHostService
    {
        private readonly IScheduler scheduler;

        public SelfHostService(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public void Run()
        {
            //IMPORTANT INFO!!!:
            //Los informes serán cada 48 horas, semanales y mensuales donde mediante gráficas 
            //y servidor por servidor se evidenciará el uso y carga de CPU, RAM, I/O de disco y sesiones de usuario en el IIS.

            //Los informes se enviaran cada lunes, miércoles y viernes y tendrán la siguiente configuración:

            //•	Lunes: grafica de las últimas 48 horas
            //•	Miércoles: grafica de las últimas 48 horas
            //•	Viernes grafica de las últimas 48 horas y grafica de la última semana
            //•	Ultimo día hábil del mes: grafica del último mes
            //Uno diario, uno semanal, uno mensual, LO DE ARRIBA ES ANTIGUO

            //Scheduler
            var jobDetail =
                JobBuilder.Create<EmailJob>()  //attach the Job's Execute() method to the Run() method  
                .WithIdentity("EmailJob")
                .WithDescription("Send emails perferomance server reports")
                .Build();
            var trigger =
                TriggerBuilder.Create()
                .WithIdentity("EmailJob")
                //.WithCronSchedule("0 0 0 1/1 * ? *") //Cron expression, it will be start at 12pm, use http://www.cronmaker.com to generate it
                .WithCronSchedule("	0 0/3 * 1/1 * ? *") //Every three minutes
                //.WithCronSchedule("0 0 / 5 * 1/1 * ? *")  //Test for each 5 mins  //TODO: Continue here!!! Check that the service is launched
                .StartAt(DateTimeOffset.FromUnixTimeSeconds(1)) //start inmediatly
                .Build();
            this.scheduler.ScheduleJob(jobDetail, trigger);
            this.scheduler.Start();
        }

        public void ShutDown()
        {
            this.scheduler?.Shutdown();
        }

        public void Stop()
        {
            #region Remove this part, it's just a test    
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(FileController.writeDataIntoALog("SERVICE HAS BEEN STOPED", FileController.fileStr));
            Console.ResetColor();
            Thread.Sleep(1500);
            #endregion

            this.scheduler?.Shutdown();

        }
    }
}
