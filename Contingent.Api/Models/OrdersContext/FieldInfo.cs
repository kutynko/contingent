namespace Contingent.Api.Models.OrdersContext
{
    public struct FieldInfo
    {
        public FieldInfo(string id, string caption, string type)
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