using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;

[assembly: PluginMetadata("Kana.Trolldier", DisplayName = "Trolldier")]
namespace Trolldier;

public class Trolldier : OpenModUnturnedPlugin
{
    private readonly IConfiguration m_Configuration;
    private readonly IStringLocalizer m_StringLocalizer;
    private readonly ILogger<Trolldier> m_Logger;

    public Trolldier(
            IConfiguration configuration,
            IStringLocalizer stringLocalizer,
            ILogger<Trolldier> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
    {
        m_Configuration = configuration;
        m_StringLocalizer = stringLocalizer;
        m_Logger = logger;
    }

    protected override UniTask OnLoadAsync()
    {
        return UniTask.CompletedTask;
    }

    protected override UniTask OnUnloadAsync()
    {
        return UniTask.CompletedTask;
    }
}
