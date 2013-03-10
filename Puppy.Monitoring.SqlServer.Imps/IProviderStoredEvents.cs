using System.Collections.Generic;
using Puppy.Monitoring.Events;

namespace Puppy.Monitoring.SqlServer.Imps
{
    public interface IProviderStoredEvents
    {
        IList<IEvent> GetEvents();
    }
}