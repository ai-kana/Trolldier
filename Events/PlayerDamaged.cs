using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Players.Life.Events;
using OpenMod.Unturned.Users;
using Trolldier.Services;

namespace Trolldier.Events;

public class PlayerDamaged : IEventListener<UnturnedPlayerDamagingEvent>
{
    private readonly UnturnedUserDirectory _Directory;
    private readonly IAirDataStore _Store;
    private readonly IConfiguration _Configuration;

    public PlayerDamaged(IAirDataStore store, UnturnedUserDirectory directory, IConfiguration configuration)
    {
        _Directory = directory;
        _Store = store;
        _Configuration = configuration;
    }

    public async Task HandleEventAsync(object? sender, UnturnedPlayerDamagingEvent @event)
    {
        UnturnedUser? user = _Directory.FindUser(@event.Killer);
        if (user == null)
        {
            return;
        }

        if (user.Player.Player.equipment.itemID != _Configuration.GetValue<ushort>("MarketGardener"))
        {
            return;
        }

        if (_Store.GetAirStatus(user.Player))
        {
            @event.DamageAmount = byte.MaxValue;
        }
    }
}

