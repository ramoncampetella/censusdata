namespace drill_csharp
{
    public class QueryFileResponse : QueryResponse
    {
        public new FileResponse[] Rows { get; set; }
    }

    public class FileResponse
    {
        public string Name { get; set; }
        public string IsDirectory { get; set; }
        public string IsFile { get; set; }
        public string Length { get; set; }
        public string Owner { get; set; }
        public string Group { get; set; }
        public string Permissions { get; set; }
        public string AccessTime { get; set; }
        public string ModificationTime { get; set; }


    }
}