namespace Contingent.Scheduler.Contracts
{
    public interface IScheduler
    {
        void Process(string data);

        void Undo(string data);
    }
}
