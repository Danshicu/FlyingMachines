using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    public class PlayerEvents
    {
        public static Action<Player> OnPlayerSpawned;
        public static void CallOnPlayerSpawned(Player player) => OnPlayerSpawned?.Invoke(player);
    }
}
