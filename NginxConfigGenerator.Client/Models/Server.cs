namespace NginxConfigGenerator.Client.Models
{
    public record Server
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Domain { get; set; }
        public int Port { get; set; }

        public ServerType ServerType { get; set; }

        public string? AccessLog { get; set; }
        public string? ErrorLog { get; set; }

        public string? Root { get; set; }

        public List<ServerLocation> Locations { get; set; } = new List<ServerLocation>();

    }
}

public enum ServerType
{
    Proxy,
    StaticFiles
}
