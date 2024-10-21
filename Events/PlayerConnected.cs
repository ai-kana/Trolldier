using System.Threading.Tasks;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Users.Events;
using Trolldier.Services;

namespace Trolldier.Events;


public class PlayerConnected : IEventListener<UnturnedUserConnectedEvent>
{
    private readonly IAirDataStore _Store;
    public PlayerConnected(IAirDataStore store)
    {
        _Store = store;
    }

    public Task HandleEventAsync(object? sender, UnturnedUserConnectedEvent @event)
    {
        _Store.RegisterPlayer(@event.User.Player);
        return Task.CompletedTask;
    }
}
