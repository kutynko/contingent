using System.ServiceModel;
using Contingent.Scheduler.Contracts;

namespace Contingent.Api.SchedulerClient
{
    public class Scheduler : ClientBase<IScheduler>, IScheduler
    {
        public void Add(string data)
        {
            Channel.Add(data);
        }
    }
}