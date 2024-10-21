using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;
using OpenMod.Unturned.Players;
using Trolldier.Components;

namespace Trolldier.Services;

[Service]
public interface IAirDataStore
{
    public void RegisterPlayer(UnturnedPlayer player);
    public void DeregisterPlayer(UnturnedPlayer player);
    public bool GetAirStatus(UnturnedPlayer player);
    public void UpdateAirStatus(UnturnedPlayer player, bool state);
}

[PluginServiceImplementation(Lifetime = ServiceLifetime.Singleton)]
public class AirDataStore : IAirDataStore
{
    private ConcurrentDictionary<UnturnedPlayer, bool> _Status = new();

    public void RegisterPlayer(UnturnedPlayer player)
    {
        _Status.TryAdd(player, false);
        AirTracker tracker = player.Player.gameObject.AddComponent<AirTracker>();
        tracker.StartTracking(player, this);
    }

    public void DeregisterPlayer(UnturnedPlayer player)
    {
        _Status.TryRemove(player, out _);
    }

    public void UpdateAirStatus(UnturnedPlayer player, bool state)
    {
        _Status[player] = state;
    }

    public bool GetAirStatus(UnturnedPlayer player)
    {
        return _Status[player];
    }
}
