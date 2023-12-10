using Microsoft.FluentUI.AspNetCore.Components;
using NginxConfigGenerator.Client.Models;
using System.Reactive.Subjects;

namespace NginxConfigGenerator.Client.Pages.Generator
{
    public partial class ConfigGenerator
    {

        public Config Config { get; set; } = new Config();
        string? activeid = "config-tab";
        FluentTab? changedTo;

        private void HandleOnTabChange(FluentTab tab)
        {
            changedTo = tab;
        }
    }
}
