using System;
using System.Collections;
using OpenMod.Unturned.Players;
using Trolldier.Services;
using UnityEngine;

namespace Trolldier.Components;

public class AirTracker : MonoBehaviour
{
    private IEnumerator? _Routine;

    public void StartTracking(UnturnedPlayer player, IAirDataStore store)
    {
        _Routine = TrackAirState(player, store);
        StartCoroutine(_Routine);
    }

    public void StopTracking(UnturnedPlayer player, IAirDataStore store)
    {
        if (_Routine == null)
        {
            return;
        }

        StopCoroutine(_Routine);
    }

    private IEnumerator TrackAirState(UnturnedPlayer player, IAirDataStore store)
    {
        while (true)
        {
            yield return new WaitUntil(IsInAir);
            store.UpdateAirStatus(player, true);

            yield return new WaitForSeconds(0.1f);

            yield return new WaitUntil(HasLanded);
            store.UpdateAirStatus(player, false);
        }

        bool HasLanded()
        {
            return player.Player.movement.isGrounded;
        }

        bool IsInAir()
        {
            return player.Player.movement.isGrounded 
                && player.Player.movement.pendingLaunchVelocity != Vector3.zero;
        }
    }
}
