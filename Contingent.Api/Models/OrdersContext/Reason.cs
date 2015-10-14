namespace Contingent.Api.Models.OrdersContext
{
    public class Reason
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Field[] Fields { get; set; }

        public struct Field
        {
            public Field(string caption, string type)
            {
                Caption = caption;
                Type = type;
            }

            public string Caption { get; private set; }
            public string Type { get; private set; }
        }
    }
}