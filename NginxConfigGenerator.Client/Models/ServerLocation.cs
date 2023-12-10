namespace NginxConfigGenerator.Client.Models
{
    public record ServerLocation
    {
        public string Path { get; set; }
        public string? Root { get; set; }
        public string? Index { get; set; }
        public List<Header> Headers { get; set; } = [];
    }
}
