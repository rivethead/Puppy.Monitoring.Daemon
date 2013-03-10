using System.Configuration;
using Topshelf;

namespace Puppy.Monitoring.Daemon
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceName = ConfigurationManager.AppSettings["puppy.Daemon.Name"];
            var serviceDescription = ConfigurationManager.AppSettings["puppy.Daemon.Description"];
            var serviceDisplayName = ConfigurationManager.AppSettings["puppy.Daemon.DisplayName"];


            HostFactory.Run(x =>                                 
            {
                x.Service<Daemon>(s =>                        
                {
                    s.ConstructUsing(name => new Daemon());     
                    s.WhenStarted(tc => tc.Start());              
                    s.WhenStopped(tc => tc.Stop());               
                });

                x.RunAsLocalSystem();                            

                x.SetDescription(serviceDescription);        
                x.SetDisplayName(serviceDisplayName);                       
                x.SetServiceName(serviceName);                       
            });        
        }
    }
}
