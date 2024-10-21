using System.Threading.Tasks;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Users.Events;
using Trolldier.Services;

namespace Trolldier.Events;

public class PlayerDisconnected : IEventListener<UnturnedUserDisconnectedEvent>
{
    private readonly IAirDataStore _Store;
    public PlayerDisconnected(IAirDataStore store)
    {
        _Store = store;
    }

    public Task HandleEventAsync(object? sender, UnturnedUserDisconnectedEvent @event)
    {
        _Store.DeregisterPlayer(@event.User.Player);
        return Task.CompletedTask;
    }
}
