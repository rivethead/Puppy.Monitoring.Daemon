using System.Configuration;
using System.Data.SqlClient;
using Common.Logging;
using Puppy.Monitoring.Publishing;
using Puppy.Monitoring.SqlServer.Imps.Dapper.NET;
using Quartz;

namespace Puppy.Monitoring.SqlServer.Imps
{
    public class StoredEventRepublishJob : IJob
    {
        private readonly IProviderStoredEvents eventProvider;
        private static readonly ILog log = LogManager.GetLogger<StoredEventRepublishJob>();

        public StoredEventRepublishJob(IProviderStoredEvents eventProvider)
        {
            this.eventProvider = eventProvider;
        }

        public StoredEventRepublishJob()
        {
            this.eventProvider = new SqlServerDatabaseStoredEvents();
        }

        public void Execute(IJobExecutionContext context)
        {
            var events = eventProvider.GetEvents();

            log.DebugFormat("Found {0} events to republish", events.Count);

            var publisher = new Publisher();

            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["puppy.sqlserver"].ConnectionString))
            {
                connection.Open();

                foreach (var @event in events)
                {
                    publisher.Publish(@event);
                    connection.Execute("UPDATE reportingEvent SET Republished = 1 WHERE Id = @id", new { id = @event.Id });
                }
            }
        }


    }
}
