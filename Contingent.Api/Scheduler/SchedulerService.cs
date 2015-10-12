using System.ServiceModel;
using Contingent.Api.Models.OrdersContext;
using Contingent.Scheduler.Contracts;

namespace Contingent.Api.Scheduler
{
    public class SchedulerService: ClientBase<IScheduler>, IScheduler
    {
        public void Process(string data)
        {
            

            Channel.Process(data.ToString());
        }

        public void Undo(string order)
        {

        }
    }
}