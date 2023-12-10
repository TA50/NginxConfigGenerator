

using System.Collections.ObjectModel;

namespace NginxConfigGenerator.Client.Models
{
    public record Config
    {
        public List<Server> Servers { get; set; } = new List<Server>();



    }
}
