namespace Contingent.Api.Models.OrdersContext
{
    public class Action
    {
        public int Id { get; set; }
        public string Description{ get; set; }
        public bool IsBatch { get; set; }
        public FieldInfo[] Fields { get; set; }
    }
}