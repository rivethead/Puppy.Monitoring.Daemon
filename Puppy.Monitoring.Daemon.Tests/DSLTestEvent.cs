using System;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Publishing;

namespace Puppy.Monitoring.Daemon.Tests
{
    public class DSLTestEvent : Event
    {
        public DSLTestEvent(Categorisation categorisation, Guid correlationId) : base(categorisation, correlationId)
        {
        }

        public DSLTestEvent(Categorisation categorisation, Timings timings, Guid correlationId) : base(categorisation, timings, correlationId)
        {
        }

        public DSLTestEvent(DateTime publishedOn, Categorisation categorisation, Timings timings) : base(publishedOn, categorisation, timings)
        {
        }

        public DSLTestEvent(PublishingContext context, EventTiming eventAudit, Categorisation categorisation, Guid correlationId, Timings timings,
                            Guid id) : base(context, eventAudit, categorisation, correlationId, timings, id)
        {
        }

        public DSLTestEvent(DateTime publishedOn, Categorisation categorisation, Timings timings, Guid correlationId)
            : base(publishedOn, categorisation, timings, correlationId)
        {
        }
    }
}