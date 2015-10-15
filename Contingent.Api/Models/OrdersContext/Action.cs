namespace Contingent.Api.Models.OrdersContext
{
    public class Action
    {
        public int Id { get; set; }
        public string Description{ get; set; }
        public bool IsBatch { get; set; }
        public Field[] Fields { get; set; }

        public struct Field
        {
            public Field(string id, string caption, string type)
            {
                Id = id;
                Caption = caption;
                Type = type;
            }

            public string Id { get; private set; }
            public string Caption { get; private set; }
            public string Type { get; private set; }
        }
    }
}