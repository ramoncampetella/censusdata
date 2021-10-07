namespace drill_csharp
{
    public class QueryResponse
    {
        public string[] Columns { get; set; }

        public virtual dynamic[] Rows { get; set; }

        public dynamic[] Metadata { get; set; }

        public string QueryId { get; set; }
    }
}