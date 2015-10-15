namespace Contingent.Api.Models.OrdersContext
{
    public class Reason
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public FieldInfo[] Fields { get; set; }

       
    }
}